class Musica
{

    public Musica(Banda artista, string nome)
    {
        Artista = artista;
        Nome = nome;
    }

    public string Nome { get; }
    public Banda Artista { get; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public string DescricaoResumida => $"a musica {Nome} pertence à banda {Artista}";
    //lambda para casos de somente leitura como a descrição resumida


    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        if(Disponivel)
        {
            Console.WriteLine("Disponivel  no plano.");
        }else {
            Console.WriteLine("adquira o plano Plus+");
                }
    }
}