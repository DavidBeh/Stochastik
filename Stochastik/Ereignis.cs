using System.Runtime.CompilerServices;
using AngouriMath;

namespace Stochastik;

public class Ereignis
{
    private readonly string _symbol = null!;

    protected ConditionalWeakTable<Entity, Ereignis> EntityTable;

    public Ereignis(string symbol)
    {
        _symbol = symbol;
    }

    public override string ToString()
    {
        return _symbol;
    }

    protected Ereignis()
    {
        
    }
    
    

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

    public virtual Entity ToAngouriEntity()
    {
        return MathS.Var("E" + Guid.NewGuid().ToString("N"));
    }
}

public class Schnittmenge : Ereignis
{
    public readonly Ereignis A;
    public readonly Ereignis B;
    
    public Schnittmenge(Ereignis a, Ereignis b)
    {
        A = a;
        B = b;
    }


    public override Entity ToAngouriEntity()
    {
        return base.ToAngouriEntity();
    }
}

public class Vereinigungsmenge : Ereignis
{
    public readonly Ereignis A;
    public readonly Ereignis B;
    
    
    public Vereinigungsmenge(Ereignis a, Ereignis b)
    {
        A = a;
        B = b;
    }
}

public class Negierung : Ereignis
{
    public readonly Ereignis E;

    public Vereinigungsmenge(Ereignis e)
    {
        E = e;
    }
}