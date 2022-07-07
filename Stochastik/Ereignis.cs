using System.Runtime.CompilerServices;
using AngouriMath;

namespace Stochastik;

public abstract class Ereignis
{
    public abstract Entity ToAngouri();

    public static Ereignis operator &(Ereignis a, Ereignis b)
    {
        return new Schnittmenge(a, b);
    }


    public static Ereignis operator |(Ereignis a, Ereignis b)
    {
        return new Vereinigungsmenge(a, b);
    }

    public static Ereignis operator !(Ereignis a)
    {
        return new Negierung(a);
    }
}

public class EreignisVar : Ereignis
{
    private readonly string _symbol = null!;

    protected ConditionalWeakTable<Entity, EreignisVar> EntityTable;

    public EreignisVar(string symbol)
    {
        _symbol = symbol;
    }

    public override string ToString()
    {
        return _symbol;
    }

    public override Entity ToAngouri()
    {
        return MathS.Var("N" + Guid.NewGuid().ToString("N"));
    }
}

public class Schnittmenge : Ereignis
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
        return new Entity.Sumf(Links.ToAngouri(), Rechts.ToAngouri());
    }
}

public class Vereinigungsmenge : Ereignis
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
        return new Entity.Orf(Links.ToAngouri(), Rechts.ToAngouri());
    }
}

public class Negierung : Ereignis
{
    public readonly Ereignis Kind;

    public Negierung(Ereignis kind)
    {
        Kind = kind;
    }

    public override Entity ToAngouri()
    {
        return new Entity.Notf(Kind.ToAngouri());
    }
}