using System.Text.RegularExpressions;

namespace DesafioPratico1;

public static class Exercicio5
{
    public static string ValidarPlaca(string placa)
    {
        var isPlacaValid = Regex.IsMatch(placa, @"^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}");

        return isPlacaValid ? "Placa Verdadeira" : "Placa Falsa";
    }
}