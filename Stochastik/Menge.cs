using System.Collections;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

namespace Stochastik;

public class Menge<T> : IEnumerable<T>
{
    private readonly IEnumerable<T> _elemente;
    public readonly Menge<T>? Ergebnisraum;

    public Menge(IEnumerable<T> elemente, Menge<T>? ergebnisraum = null)
    {
        _elemente = elemente.ToList();
        Ergebnisraum = ergebnisraum?.Ergebnisraum ?? ergebnisraum;
    }

    // Gegenereignis
    public static Menge<T> operator !(Menge<T> m)
    {
        if (m.Ergebnisraum == null)
            throw new InvalidOperationException("Ein Ergebnisraum hat kein Gegenereignis");
        return m.ErstelleTeilmenge(m.Ergebnisraum.Where(g => !m.Contains(g)));
    }

    // Vereinigt
    public static Menge<T> operator |(Menge<T> a, Menge<T> b) =>
        a.ErstelleAusErgebnisraum(g => g.Where(e => a.Contains(e) || b.Contains(e)));

    // Geschnitten
    public static Menge<T> operator &(Menge<T> a, Menge<T> b) =>
        a.ErstelleAusErgebnisraum(g => g.Where(e => a.Contains(e) && b.Contains(e)));

    // XOR
    public static Menge<T> operator ^(Menge<T> a, Menge<T> b) =>
        a.ErstelleAusErgebnisraum(g => g.Where(e => a.Contains(e) ^ b.Contains(e)));

    // Wahrscheinlichkeit
    public static double? operator ~(Menge<T> m)
    {
        var n = m.Ergebnisraum?.Count() ?? m.Count();
        if (n == 0) return null;
        return m.Count() / (double) n;
    }

    /// <summary>
    /// Gibt die Wahrscheinlichkeit dieser Menge als gekürzten Bruch aus
    /// </summary>
    public string? Bruch
    {
        get
        {
            var n = Ergebnisraum?.Count() ?? this.Count();
            var z = this.Count();
            if (n == 0) return null;
            var t = GCD(n, z);
            return $"{z / t}/{n / t}";
        }
    }

    /// <summary>
    /// Ausgabe der Menge in die Konsole
    /// </summary>
    /// <param name="notiz"></param>
    /// <returns></returns>
    public Menge<T> Ausgeben(string? notiz = null)
    {
        notiz = (notiz is not null or "") ? notiz + " :" : "";
        Console.WriteLine($"{notiz, 15} {Bruch, 6} {~this, 6:0.###} {{ {string.Join(", ", this.Cast<object>())} }} ");
        return this;
    }


    /// <summary>
    /// Erstellt eine Teilmenge aus dieser Gesamtmenge oder der Gesamtmenge dieser Teilmenge
    /// </summary>
    /// <param name="elemente"></param>
    /// <returns></returns>
    public Menge<T> ErstelleTeilmenge(IEnumerable<T> elemente) => new Menge<T>(elemente, this);

    private Menge<T> ErstelleAusErgebnisraum(Func<Menge<T>, IEnumerable<T>> act) =>
        new Menge<T>(act.Invoke(Ergebnisraum ?? this), this);


    public IEnumerator<T> GetEnumerator()
    {
        return _elemente.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_elemente).GetEnumerator();
    }

    private static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
}