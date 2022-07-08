using System.Collections;
using System.Runtime.CompilerServices;
using AngouriMath;

namespace Stochastik;

public class Ergebnisraum
{




    
    
    public void GetWahrscheinlichkeit(Ereignis e)
    {
        
    }

    
}

public record P(Ereignis E, Ereignis? Bedingung = null) 
{
    static Hashtable t = new Hashtable();
    
    public static implicit operator Entity(P p)
    {
        return p.E;
    }
}