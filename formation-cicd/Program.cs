using MyProject.Logic; // On importe ton namespace ici !

var builder = WebApplication.CreateBuilder(args);

// Récupérer une valeur nommée "GedSettings:EncryptionKey"
string encryptionKey = builder.Configuration["GedSettings:EncryptionKey"] ?? "Clé_Par_Défaut_Locale";

var app = builder.Build();

var calculatrice = new Calculatrice(); // On utilise ta classe de Calculatrice.cs

app.MapGet("/", () => "Bienvenue sur l'API de M-Bout !");

app.MapGet("/somme", (int a, int b) =>
{
    int resultat = calculatrice.Additionner(a, b);
    return Results.Ok(new { operation = $"{a} + {b}", resultat = resultat });
});

app.MapGet("/config-test", () => $"La clé utilisée est : {encryptionKey}");

app.Run();
