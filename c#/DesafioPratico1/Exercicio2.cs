namespace DesafioPratico1;

public static class Exercicio2
{
    public static void PrintNome(string[] args)
    {
        Console.WriteLine("Insira seu nome:");
        var firstName = Console.ReadLine();
        
        Console.WriteLine("Insira seu sobrenome:");
        var secondName = Console.ReadLine();
        
        Console.WriteLine($"{firstName} {secondName}");
    }
}