using songsApi.Interface;
using songsApi.Data;
using songsApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace songsApi.Service
{
    public class SongService : ISongService
    {
        private readonly AppDbContext _context;

        public SongService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Song>> GetSongsAsync()
        {
            return await _context.Songs.ToListAsync();
        }


        public async Task<Song> GetSongAsync(int id)
        {
            return await _context.Songs.FindAsync(id);
        }


        public async Task<IEnumerable<Song>> GetSongsAlbum(string album)
        {
            album = album.Trim().ToLower();

            if (album.Length <= 3)
            {
                return await _context.Songs
                    .Where(s => s.Album.StartsWith(album))
                    .ToListAsync();
            }


            return await _context.Songs
                .Where(a => a.Album.ToLower().Contains(album))
                .ToListAsync();
        }

        public async Task<IEnumerable<Song>> GetSongsArtista(string artista)
        {
            artista = artista.Trim().ToLower();

            if (artista.Length <= 3)
            {
                return await _context.Songs
                    .Where(s => s.Artista.StartsWith(artista))
                    .ToListAsync();
            }


            return await _context.Songs
                .Where(a => a.Artista.ToLower().Contains(artista))
                .ToListAsync();
        }


        public async Task<IEnumerable<Song>> GetSongsAno(string ano)
        {
            return await _context.Songs
                .Where(a => a.AnoLancamento == ano)
                .ToListAsync();
        }



        public async Task<IEnumerable<Song>> GetSongsGenero(string genero)
        {
            genero = genero.Trim().ToLower();

            if (genero.Length <= 3)
            {
                return await _context.Songs
                    .Where(s => s.Genero.StartsWith(genero))
                    .ToListAsync();
            }

            return await _context.Songs
                .Where(a => a.Genero == genero)
                .ToListAsync();
        }




        public async Task AddSong(Song song)
        {

            await _context.Songs.AddAsync(song);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateSong(int id, Song song)
        {

            var songToUpdate = await FindSongRecursive(id);

            if (songToUpdate == null)
            {
                return;
            }
            songToUpdate.Id = song.Id;
            songToUpdate.Nome = song.Nome;
            songToUpdate.Album = song.Album;
            songToUpdate.Artista = song.Artista;
            songToUpdate.AnoLancamento = song.AnoLancamento;
            songToUpdate.Genero = song.Genero;

            await _context.SaveChangesAsync();
        }


        public async Task UpdateSongName(int id, string name)
        {
            var songToUpdateName = await FindSongRecursive(id);
            if (songToUpdateName == null)
            {
                return;
            }

            songToUpdateName.Nome = name;
            await _context.SaveChangesAsync();

        }

        public async Task UpdateSongAlbum(int id, string album)
        {
            var songToUpdate = await FindSongRecursive(id);
            if (songToUpdate == null)
            {
                return;
            }

            songToUpdate.Album = album;
            await _context.SaveChangesAsync();

        }


        public async Task UpdateSongArtista(int id, string artista)
        {
            var songToUpdate = await FindSongRecursive(id);
            if (songToUpdate == null)
            {
                return;
            }

            songToUpdate.Artista = artista;
            await _context.SaveChangesAsync();

        }

        public async Task UpdateSongAno(int id, string ano)
        {
            var songToUpdate = await FindSongRecursive(id);
            if (songToUpdate == null)
            {
                return;
            }

            songToUpdate.AnoLancamento = ano;
            await _context.SaveChangesAsync();

        }


        public async Task UpdateSongGenero(int id, string genero)
        {
            var songToUpdate = await FindSongRecursive(id);
            if (songToUpdate == null)
            {
                return;
            }

            songToUpdate.Genero = genero;
            await _context.SaveChangesAsync();

        }




        public async Task DeleteSong(int id)
        {

            var songToDelete = await FindSongRecursive(id);

            if (songToDelete == null)
            {
                return;
            }


            _context.Songs.Remove(songToDelete);
            await _context.SaveChangesAsync();
        }



        public async Task<Song> FindSongRecursive(int id)
        {
            var songToFind = await _context.Songs.FindAsync(id);

            if (songToFind != null)
            {
                return songToFind;
            }

            return null;
        }



        public async Task<bool> DeleteArtista(string artista)
        {
            artista = artista.Trim().ToLower();


            if (artista.Length <= 3)
            {
                var songsToDel = await _context.Songs
                .Where(a => a.Artista.ToLower().StartsWith(artista))
                .ToListAsync();

                if (!songsToDel.Any())
                {
                    return false;
                }

                _context.Songs.RemoveRange(songsToDel);
                await _context.SaveChangesAsync();
                return true;



            }
            else
            {
                var songsToDel = await _context.Songs
                .Where(a => a.Artista.ToLower().Contains(artista))
                .ToListAsync();

                if (!songsToDel.Any())
                {
                    return false;
                }

                _context.Songs.RemoveRange(songsToDel);
                await _context.SaveChangesAsync();
                return true;

            }

            //var songsToDel =  await _context.Songs
            //    .Where(a => a.Artista.ToLower().Contains(artista))
            //    .ToListAsync();

            //if (!songsToDel.Any())
            //{
            //    return false; 
            //}

            //_context.Songs.RemoveRange(songsToDel);
            //await _context.SaveChangesAsync();
            //return true;
        }





    }
}
