﻿using ScreenSound_04.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound_04.Filtros;

internal class LinqOrder
{

    public static void  ExibirListaDeArtistasOrdenados(List<Musica> musica)
    {
        var artistasOrdenados = musica.OrderBy(musica => musica.Artista).Select(musica => musica.Artista).Distinct().ToList();
        Console.WriteLine("Lista de artistas ordenados ");
        foreach(var artista in artistasOrdenados)
        {
            Console.WriteLine($" -{artista}");
        }
    }

}
