namespace Fundamentos;

public class Carro
{
    public required string Modelo { get; set; }
    public DateOnly DataLancamento { get; set; }
    public Cor Cor { get; set; }
    
    public override string ToString()
    {
        return $"{Modelo} - {DataLancamento} - {Cor}";
    }
}