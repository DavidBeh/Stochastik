// See https://aka.ms/new-console-template for more information

using AngouriMath;
using static AngouriMath.MathS;
using static AngouriMath.Entity;
using AngouriMath.Core;
using Stochastik;

/*
Menge<int> omega = new Menge<int>(new[] { 1, 2, 3, 4, 5, 6 });

Menge<int> gerade = omega.ErstelleTeilmenge(omega.Where(i => i % 2 == 0));

Menge<int> primzahl = omega.ErstelleTeilmenge(new[] { 2, 3, 5 });

omega.Ausgeben("omega");
primzahl.Ausgeben("primzahl");
gerade.Ausgeben("gerade");
(gerade | primzahl).Ausgeben("g ver p");
(gerade & primzahl).Ausgeben("g ges p");
(!primzahl).Ausgeben("gegener p");
(primzahl ^ gerade).Ausgeben("entw p oder g");

*/
var v = MathS.Var("(N33)");

var a = new EreignisVar("a");
var b = new EreignisVar("b");

Char c = 'd';



//var g = a & b  & c;

Console.WriteLine(g.ToAngouri());