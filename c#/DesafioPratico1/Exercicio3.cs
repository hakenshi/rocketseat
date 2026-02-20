namespace DesafioPratico1;

public static class Exercicio3
{
    private static double n1 = 10;
    private static double n2 = 20;

    public static double MathOperation(Operacao operacao)
    {
        return operacao switch
        {
            Operacao.SUBTRAIR => n1 - n2,
            Operacao.SOMAR => n1 + n2,
            Operacao.DIVIDIR => n1 >= 0
                ? n1 / n2
                : throw new InvalidOperationException("Não é possível dividir valores nulos."),
            Operacao.MULTIPLICAR => n1 * n2,
            _ => throw new ArgumentOutOfRangeException(nameof(operacao), operacao, null),
        };
    }
}