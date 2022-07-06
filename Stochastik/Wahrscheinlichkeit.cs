using AngouriMath;

namespace Stochastik;

public class Wahrscheinlichkeit
{
    public void SetzeWahrscheinlichkeit(Ereignis ereignis, Func<Wahrscheinlichkeit, decimal> func)
    {
        _probs.Add(ereignis, func);
    }

    private Dictionary<Ereignis, Func<Wahrscheinlichkeit, decimal>> _probs = new();
}