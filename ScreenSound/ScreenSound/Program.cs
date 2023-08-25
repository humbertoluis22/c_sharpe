/*
Banda queen = new Banda("queen");


Album albumDoQuenn = new Album("A night at the opera");


Musica musica1 = new Musica(queen, "Love of my life")
{
    Duracao = 213,
    Disponivel = true
};


Musica musica2 = new Musica(queen, "Bohemian Rhapsody")
{
    Duracao = 354,
    Disponivel = false
};

 
albumDoQuenn.AdicionarMusica(musica1);
albumDoQuenn.AdicionarMusica(musica2);
queen.AdicionarAlbum(albumDoQuenn);
musica1.ExibirFichaTecnica();
musica2.ExibirFichaTecnica();

albumDoQuenn.ExibirMusicaDoAlbum();
queen.ExibirDiscografia();
*/

Episodio ep1 = new Episodio(1, "técnicas de facilitação",45);
ep1.AdicionarConvidado("guilherme");
ep1.AdicionarConvidado("maria");


Episodio ep2 = new Episodio(2, "técnicas de aprendizado", 67);
ep2.AdicionarConvidado("fernando");
ep2.AdicionarConvidado("marco");
ep2.AdicionarConvidado("Flavia");


Podcast podcast = new Podcast("podcast especial", "Humberto");
podcast.AdicionarEpisodio(ep1);
podcast.AdicionarEpisodio(ep2);
podcast.ExibirDetalhes();