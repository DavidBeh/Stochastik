// See https://aka.ms/new-console-template for more information

using AngouriMath;

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


Console.WriteLine("U\u0305");
return;
EreignisVar a = new EreignisVar('A');
EreignisVar b = new EreignisVar('B');
EreignisVar c = new EreignisVar('C');

var g = a & (b | c);

Console.WriteLine(g.ToAngouri());

Console.WriteLine(Ereignis.FromAngouri(g.ToAngouri()));