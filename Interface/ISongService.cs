using songsApi.Models;

namespace songsApi.Interface
{
    public interface ISongService
    {

        // Busca
        Task <IEnumerable<Song>> GetSongsAsync ();
        Task <Song> GetSongAsync (int id);
        Task<IEnumerable<Song>> GetSongsAlbum(string album);
        Task<IEnumerable<Song>> GetSongsArtista(string artista);
        Task<IEnumerable<Song>> GetSongsAno(string ano);
        Task<IEnumerable<Song>> GetSongsGenero(string genero);


        // Criacao
        Task AddSong (Song song);

        // Atualizar
        Task UpdateSong(int id, Song song);
        Task UpdateSongName(int id, string name);
        Task UpdateSongAlbum (int id, string album);
        Task UpdateSongArtista(int id, string artista);
        Task UpdateSongAno(int id, string ano);
        Task UpdateSongGenero (int id, string genero);



        // Apagar
        Task DeleteSong (int id);

        Task <bool> DeleteArtista(string artista);
    }
}
