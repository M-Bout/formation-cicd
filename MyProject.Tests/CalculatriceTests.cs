using MyProject.Logic;
using Xunit;

namespace MyProject.Tests
{
    public class CalculatriceTests
    {
        [Fact] // Cet attribut dit à .NET : "Ceci est un test"
        public void Additionner_DeuxNombres_RetourneSomme()
        {
            // 1. Arrange (On prépare)
            var calc = new Calculatrice();
            int a = 5;
            int b = 10;

            // 2. Act (On exécute)
            int resultat = calc.Additionner(a, b);

            // 3. Assert (On vérifie)
            Assert.Equal(15, resultat);
        }
    }
}
