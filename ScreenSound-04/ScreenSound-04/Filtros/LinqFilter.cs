
using ScreenSound_04.Modelos;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound_04.Filtros;

internal class LinqFilter
{

    public static void FiltrarTodosOsGenerosMusicais(List<Musica>musicas) 
    {
        var todosOsGenerosMusicais = musicas.Select(genero => genero.Genero).Distinct().ToList();
        
        foreach (var genero in todosOsGenerosMusicais)
        {
            Console.WriteLine($"-- {genero}");
        }
    }

    public static void FiltrarPorGeneroMusical(List<Musica> musica, string genero)
    {
        var artistasPorGenero = musica.Where(musica => musica.Genero!.Contains(genero)).Select(musica => musica.Artista).Distinct().ToList();
        Console.WriteLine($"Exibindo artista por genero musical ----> {genero}");

        foreach (var artista in artistasPorGenero)
        {
            Console.WriteLine($" - {artista}");
        }

    }

    public static void FiltrarMusicasDeUmArtista(List<Musica> musica, string nomeDoArtista)
    {
        var musicasDoArtista = musica.Where(musica => musica.Artista!.Equals(nomeDoArtista)).ToList();
        Console.WriteLine(nomeDoArtista);
        foreach(var musicas in musicasDoArtista)
        {
            Console.WriteLine($" - {musicas.Nome}");
        }
    }

    public static void FiltrarPorTonalidade(List<Musica> musica , string tonalidade)
    {
        var musicaPorTonalidade = musica.Where(musica => musica.Tonalidade!.Equals(tonalidade)).Select(musica => musica.Nome).Distinct().ToList();
        Console.WriteLine($"tonalidade: {tonalidade}");
        foreach(var musicaTonalidade in musicaPorTonalidade)
        {
            Console.WriteLine($" --{musicaTonalidade}");
        }
    }
}
