using AngouriMath;

namespace Stochastik;

public class Wahrscheinlichkeit
{
    public void SetzeWahrscheinlichkeit(EreignisVar ereignis, Func<Wahrscheinlichkeit, decimal> func)
    {
        _probs.Add(ereignis, func);
    }

    private Dictionary<EreignisVar, Func<Wahrscheinlichkeit, decimal>> _probs = new();
}