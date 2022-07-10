using System.Runtime.CompilerServices;
using AngouriMath;
using AngouriMath.Core;
using static AngouriMath.Entity;

namespace Stochastik.Ereignis;

public abstract record Ereignis
{
    public abstract Entity ToAngouri();
    public static ConditionalWeakTable<Entity, EreignisVar> Table;

    public static Ereignis operator &(Ereignis a, Ereignis b)
    {
        return new Schnittmenge(a, b);
    }

    public static Ereignis operator |(Ereignis a, Ereignis b)
    {
        return new Vereinigungsmenge(a, b);
    }

    public static Ereignis operator !(Ereignis a) => new Negierung(a);

    public static Ereignis FromAngouri(Entity f) =>
        f switch
        {
            Variable ereignis => new EreignisVar(ereignis.Name[0]),
            Andf sum => FromAngouri(sum.Left) & FromAngouri(sum.Right),
            Orf orf => FromAngouri(orf.Left) | FromAngouri(orf.Right),
            Impliesf i => !FromAngouri(i.Assumption) | FromAngouri(i.Conclusion),
            Notf not => !FromAngouri(not.Argument),
            _ => throw new NotImplementedException(
                $"Ereignis from Entity of type {f.GetType()} with representation {f.ToString()} is not implemented")
        };

    public int Priority =>
        this switch
        {
            EreignisVar => 1,
            Negierung => 2,
            Schnittmenge => 3,
            Vereinigungsmenge => 4,
            _ => throw new ArgumentOutOfRangeException()
        };

    public Ereignis Simplify() => FromAngouri(ToAngouri().Simplify());
    public bool HasPriority(Ereignis other) => Priority < other.Priority;
    public string ChildToStringPriority(Ereignis child) => HasPriority(child) ? $"({child})" : child.ToString();
    public string ToString(Ereignis parent) => parent.ChildToStringPriority(this);
    public bool Gleich(Ereignis other) => MathS.Equality(this.ToAngouri(), other.ToAngouri()).Simplify() == true;
    public static implicit operator Entity(Ereignis e) => e.ToAngouri();
}

public record EreignisVar : Ereignis
{
    public readonly char Symbol;

    public EreignisVar(char symbol)
    {
        if (symbol < 65 || symbol > 90)
            throw new ArgumentException($"Only upper case letters A-Z (utf32 65-90) are accepted. Provided: {symbol}",
                nameof(symbol));
        Symbol = symbol;
    }

    public override string ToString() => Symbol.ToString();

    public override Entity ToAngouri()
    {
        return MathS.Var(Symbol.ToString());
    }
}

public record Schnittmenge : Ereignis
{
    public readonly Ereignis Links;
    public readonly Ereignis Rechts;

    public Schnittmenge(Ereignis links, Ereignis rechts)
    {
        Links = links;
        Rechts = rechts;
    }

    public override Entity ToAngouri()
    {
        return new Andf(Links.ToAngouri(), Rechts.ToAngouri());
    }

    public override string ToString()
    {
        return $"{Links.ToString(this)} & {Rechts.ToString(this)}";
    }
}

public record Vereinigungsmenge : Ereignis
{
    public readonly Ereignis Links;
    public readonly Ereignis Rechts;

    public Vereinigungsmenge(Ereignis links, Ereignis rechts)
    {
        Links = links;
        Rechts = rechts;
    }

    public override Entity ToAngouri()
    {
        return new Orf(Links.ToAngouri(), Rechts.ToAngouri());
    }

    public override string ToString()
    {
        return $"{Links.ToString(this)} | {Rechts.ToString(this)}";
    }
}

public record Negierung : Ereignis
{
    public Ereignis Kind { get; init; }

    public Negierung(Ereignis kind)
    {
        Kind = kind;
    }

    public override string ToString()
    {
        return $"!{Kind.ToString(this)}";
    }

    public override Entity ToAngouri()
    {
        return new Notf(Kind.ToAngouri());
    }
}