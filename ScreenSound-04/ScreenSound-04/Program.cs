using ScreenSound_04.Modelos;
using System.Net.Http.Json;
using System.Text.Json;
using ScreenSound_04.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        //Console.WriteLine(resposta);

        // desserializaçaõ
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        musicas[0].ExibirDetalhesDaMusica();

        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarPorGeneroMusical(musicas, "rock");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "Linkin Park");
        LinqFilter.FiltrarPorTonalidade(musicas, "Eb");


        //var musicasFavoritas = new MusicasPreferidas("Humberto");
        //musicasFavoritas.AdicionarMusicasFavoritas(musicas[1]);
        //musicasFavoritas.AdicionarMusicasFavoritas(musicas[15]);
        //musicasFavoritas.AdicionarMusicasFavoritas(musicas[89]);
        //musicasFavoritas.AdicionarMusicasFavoritas(musicas[1300]);
        //musicasFavoritas.AdicionarMusicasFavoritas(musicas[1120]);

        //musicasFavoritas.ExibirMusicasFavoritas();
        //musicasFavoritas.GerarArquivoJson();



    }
    catch(Exception ex)
    {
        Console.WriteLine($"Temos um problema {ex.Message}");
    }
}