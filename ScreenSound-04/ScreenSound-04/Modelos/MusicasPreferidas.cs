using System.Text.Json;


using System.Runtime.InteropServices;

namespace ScreenSound_04.Modelos;

internal class MusicasPreferidas
{
    public string  Nome { get; set; }
    public List<Musica> ListaDeMusicasFavoritas { get; }

    public MusicasPreferidas(string nome) 
    {
        Nome = nome;
        ListaDeMusicasFavoritas = new List<Musica>();
    }

    public void AdicionarMusicasFavoritas(Musica musica)
    {
        ListaDeMusicasFavoritas.Add(musica);
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"essas sao as musicas favoritas do {Nome}");
        foreach(var musica in ListaDeMusicasFavoritas)
        {
            Console.WriteLine($"- {musica.Nome} -- {musica.Artista}");
        }
        Console.WriteLine( );
    }

    public void GerarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new 
        {
            nome = Nome,
            musicas = ListaDeMusicasFavoritas

        }) ;
        string nomeDoArquivo = $"musicas-favoritas-{Nome}.json";
        File.WriteAllText(nomeDoArquivo, json) ;
        Console.WriteLine($"json foi criado com sucesso {Path.GetFullPath(nomeDoArquivo)}");

    }
    

}
