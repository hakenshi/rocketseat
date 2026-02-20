namespace Fundamentos;

public class Program
{
    private Program(){}
    
    static void Main(string[] args)
    {
        const bool isGay = true;
        var validateSexuality = isGay switch
        {
            true => "É gay",
            false => "Não é gay",
        };

        Console.WriteLine(validateSexuality);
    }
}