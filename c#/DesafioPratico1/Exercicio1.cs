namespace DesafioPratico1;

public static class Exercicio1
{
    public static void Saudar()
    {
        Console.WriteLine("Insira seu nome abaixo");
        var nome = Console.ReadLine();
        Console.WriteLine($"Olá, {nome}. Seja bem vindo!");
    }
}