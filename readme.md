# Stochastik

Paar C# Klassen um einfach und schnell Stochastik-Zeug auszuführen

## Vorbereitung

Ich empfehle Visual Studio zu verwenden

[Download](https://visualstudio.microsoft.com/de/vs/community/)

Bei der Installation muss das .Net desktop Enviroment Workload ausgewählt werden

![](https://docs.microsoft.com/de-de/visualstudio/get-started/csharp/media/vs-2022/dot-net-development-workload.png?view=vs-2022)

Um das Projekt nach der Installation schnell zu öffnen, am besten auf den *Open In Visual Studio* Knopf hier auf der Website drücken (sollte
spätestens nach Neustart des Computers in Chrome auftauchen)

![](https://i.imgur.com/mPdlPPW.png)

## Beispiel

```csharp
/// Definition des Ergebnisraums
Menge<int> omega = new Menge<int>(new[] { 1, 2, 3, 4, 5, 6 });

/// Definition von Teilmengen aus dem Ergebnisraum "omega"
Menge<int> gerade = omega.ErstelleTeilmenge(omega.Where(i => i % 2 == 0));
Menge<int> primzahl = omega.ErstelleTeilmenge(new[] { 2, 3, 5 });

omega.Ausgeben("omega");
primzahl.Ausgeben("primzahl");
gerade.Ausgeben("gerade");

// Die Operatoren |, &, !, ^ stellen Stochastische operationen dar.
// Sie können frei verknüpft werden
(gerade | primzahl).Ausgeben("g ver p");
(gerade & primzahl).Ausgeben("g ges p");
(!primzahl).Ausgeben("gegener p");
(primzahl ^ gerade).Ausgeben("entw p oder g");
```
Ausgabe:
```
        omega :    1/1      1 { 1, 2, 3, 4, 5, 6 }
     primzahl :    1/2    0,5 { 2, 3, 5 }
       gerade :    1/2    0,5 { 2, 4, 6 }
      g ver p :    5/6  0,833 { 2, 3, 4, 5, 6 }
      g ges p :    1/6  0,167 { 2 }
    gegener p :    1/2    0,5 { 1, 4, 6 }
entw p oder g :    2/3  0,667 { 3, 4, 5, 6 }
```


