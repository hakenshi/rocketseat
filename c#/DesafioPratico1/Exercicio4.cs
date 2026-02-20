namespace DesafioPratico1;

public class Exercicio4
{
    public static void ContadorDePalavras()
    {
        Console.WriteLine("Insira uma frase: ");
        var frase = Console.ReadLine();
        var palavras = frase!.Split(' ');
        foreach (var palavra in palavras)
        {
            Console.WriteLine($"{palavra}: {palavra.Length}");
        }
    }
}