using System.Globalization;

namespace DesafioPratico1;

public static class Exercicio6
{
    public static void ExibirData()
    {
        var cultura = new CultureInfo("pt-BR");
        var agora = DateTime.Now;

        Console.WriteLine("Escolha o formato para exibir a data/hora atual:");
        Console.WriteLine("1 - Formato completo (dia da semana, dia, mês, ano, hora, minutos, segundos)");
        Console.WriteLine("2 - Apenas a data (dd/MM/yyyy)");
        Console.WriteLine("3 - Apenas a hora (HH:mm:ss) - 24h");
        Console.WriteLine("4 - Data com o mês por extenso");
        Console.Write("Opção: ");

        var opcao = Console.ReadLine();

        var saida = opcao switch
        {
            "1" => agora.ToString("dddd, dd 'de' MMMM 'de' yyyy HH:mm:ss", cultura),
            "2" => agora.ToString("dd/MM/yyyy", cultura),
            "3" => agora.ToString("HH:mm:ss", cultura),
            "4" => agora.ToString("dd 'de' MMMM 'de' yyyy", cultura),
            null or "" => "Opção vazia.",
            _ => "Opção inválida."
        };

        Console.WriteLine(saida);
    }
}