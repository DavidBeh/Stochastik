// See https://aka.ms/new-console-template for more information

using AngouriMath;
using static AngouriMath.Entity;
using AngouriMath.Core;
using AngouriMath.Extensions;
using HonkSharp.Functional;
using Stochastik;
using Stochastik.Ereignis;


var a = MathS.Var("A");
var b = MathS.Var("B");
var c = MathS.Var("C");
var d = MathS.Var("D");

Entity n = !a | b;
Entity m = b | !a;


Console.WriteLine(n.VergleicheEreignisse(m));