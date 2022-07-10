using AngouriMath;
using Stochastik.Ereignis;

namespace Stochastik.Wahrscheinlichkeit;

public class Raum
{
    public List<Entity> Statements = new();
    public Dictionary<int, Entity> Mengen = new();

    public Entity RegistriereMenge(Entity menge)
    {
        var exst = Mengen.Values.FirstOrDefault(gespeicherte => menge.VergleicheEreignisse(gespeicherte));
        
    }
}