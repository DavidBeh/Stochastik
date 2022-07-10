using System.Reflection;
using AngouriMath;
using AngouriMath.Core;
using Antlr4.Runtime.Atn;

namespace Stochastik.Ereignis;

public static class AngouriExtensions
{
    public static Entity SymboleKorrigieren(this Entity e)
    {
        return e.Simplify().Replace(entity => entity switch
        {
            Entity.Impliesf i => !i.Assumption | i.Conclusion,
            _ => entity,
        });
    }

    public static string ToStringE(this Entity e, bool vereinfachen = true)
    {
        if (vereinfachen) e = e.Simplify();
        e.SymboleKorrigieren();
        return ToString2(e, false);
    }

    private static string ToString2(this Entity e, bool klammern) =>
        (klammern ? "(" : "") +
        e switch
        {
            Entity.Andf o => $"{o.Left.ToString2(o)} & {o.Right.ToString2(e)}",
            Entity.Orf o => $"{o.Left.ToString2(o)} | {o.Right.ToString2(e)}",
            Entity.Xorf o => $"{o.Left.ToString2(o)} ^ {o.Right.ToString2(e)}",
            Entity.Variable o => o.Name,
            Entity.Notf o => $"!{o.NodeChild.ToString2(o)}",
            _ => throw new ArgumentOutOfRangeException(nameof(e), e, null)
        } + (klammern ? ")" : "");

    private static string ToString2(this Entity e, Entity parent) =>
        ToString2(e, e.GetPriority() < parent.GetPriority());

    private static int GetPriority(this Entity entity)
    {
        return (int)entity.GetType().GetProperty("Priority",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy)!.GetValue(entity)!;
    }

    public static bool VergleicheEreignisse(this Entity a, Entity b)
    {
        var varsA = a.Vars.OrderBy(variable => variable.Name).ToArray();
        var varsB = b.Vars.OrderBy(variable => variable.Name).ToArray();
        if (!varsA.SequenceEqual(varsB)) return false;
        return MathS.Boolean.BuildTruthTable(a, varsA) == MathS.Boolean.BuildTruthTable(b, varsB);
    }
}