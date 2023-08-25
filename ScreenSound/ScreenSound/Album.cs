class Album
{
    private List<Musica> musicas = new List<Musica>();  //campo atributo privado
    public string Nome { get;}

    public Album(string nome)
    {
        Nome = nome;
    }

    public int DuracaoTotal => musicas.Sum(m => m.Duracao);

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirMusicaDoAlbum()
    {
        Console.WriteLine($"lista de musicas do album {Nome}:\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"MUSICA: {musica.Nome}");
        }
        Console.WriteLine($"\npara ouvir esse album inteiro você precisa de {DuracaoTotal} segundos");
    }

}