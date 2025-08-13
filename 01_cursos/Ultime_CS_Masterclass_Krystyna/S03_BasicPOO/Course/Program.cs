var retangulo = new Retangulo(5, -1);
Console.ReadKey();

public class Retangulo
{
    public readonly int Altura { get; set; }
    public readonly int Largura { get; set; }

    public Retangulo(int altura, int largura)
    {
        Altura = ObterTamanhoOuPadrao(altura, nameof(Altura));
        Largura = ObterTamanhoOuPadrao(largura, nameof(Largura));
    }

    private int ObterTamanhoOuPadrao(int tamanho, string nome)
    {
        const int valorPadrao = 1;
        if (tamanho < 1)
        {
            Console.WriteLine($"O {nome} precisa ser maior que 1.");
            return valorPadrao;
        }
        else
        {
            return tamanho;
        }
    }
}