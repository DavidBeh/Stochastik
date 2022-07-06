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


Variable a1 = Var("a");
Variable b1 = Var(Guid.NewGuid());

Entity f = a1 + b1;
var s = f.Substitute(a1, 1);
var s1 = f.Substitute(b1, 2);

var j = 
Console.WriteLine(f);
Console.WriteLine(s);
Console.WriteLine(Guid.NewGuid().ToString());