using MyProject.Logic; // On importe ton namespace ici !

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var calculatrice = new Calculatrice(); // On utilise ta classe de Calculatrice.cs

app.MapGet("/", () => "Serveur Web de M-Bout prêt !");

app.MapGet("/somme", (int a, int b) =>
{
    int resultat = calculatrice.Additionner(a, b);
    return Results.Ok(new { operation = $"{a} + {b}", resultat = resultat });
});

app.Run();
