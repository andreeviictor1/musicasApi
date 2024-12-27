using Microsoft.AspNetCore.Mvc;
using songsApi.Models;
using songsApi.Service;
using songsApi.Interface;

namespace songsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }


        [HttpGet("buscar-todas-as-musicas")]
        public async Task <IActionResult> GetSongs()
        {
            var songs = await _songService.GetSongsAsync();
            if (songs == null)
            {
                return NotFound("Nenhuma musica no sistema.");
            }

            return Ok(songs);
        }


        [HttpGet("buscar-musica-por-id")]
        public async Task <IActionResult> GetSong(int id)
        {
            var song = await _songService.GetSongAsync(id);
            if (song == null)
            {
                return NotFound("Musica nao encontrada");
            }

            return Ok(song);
        }



        [HttpGet("busca-musicas-album")]
        public async Task <IActionResult> GetSongsAlbum(string album)
        {
            var songs = await _songService.GetSongsAlbum(album);
            if (songs == null)
            {
                return NotFound("Nenhuma musica deste album cadastrada");
            }
            return Ok(songs);
        }



        [HttpGet("busca-musicas-artista")]
        public async Task<IActionResult> GetSongsArtista(string artista)
        {
            var songs = await _songService.GetSongsArtista(artista);
            if (songs == null)
            {
                return NotFound("Nenhuma musica deste album cadastrada");
            }
            return Ok(songs);
        }


        [HttpGet("busca-musicas-ano")]
        public async Task<IActionResult> GetSongsAno(string ano)
        {
            var songs = await _songService.GetSongsAno(ano);
            if (songs == null)
            {
                return NotFound("Nenhuma musica deste album cadastrada");
            }
            return Ok(songs);
        }


        [HttpGet("busca-musicas-genero")]
        public async Task<IActionResult> GetSongsGenero(string genero)
        {
            var songs = await _songService.GetSongsGenero(genero);
            if (songs == null)
            {
                return NotFound("Nenhuma musica deste album cadastrada");
            }
            return Ok(songs);
        }





























        [HttpPost("cadastrar-musica")]
        public async Task <IActionResult> PostSong(Song song)
        {
            if (song == null)
            {
                return BadRequest("Erro");
            }

            await _songService.AddSong(song);  
            return CreatedAtAction(nameof(GetSong), new { id = song.Id }, song);
        }


        [HttpPut("atualiza-musica-geral")]
        public async Task <IActionResult> PutSong(int id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            await _songService.AddSong(song);
            return NoContent();
        }


        [HttpPut("atualiza-nome")]
        public async Task <IActionResult> PutSongName(int id, string name)
        {
            await _songService.UpdateSongName(id, name);
            return NoContent();
        }

        [HttpPut("atualiza-artista")]
        public async Task<IActionResult> PutSongArtista(int id, string artista)
        {
            await _songService.UpdateSongArtista(id, artista);
            return NoContent();
        }

        [HttpPut("atualiza-album")]
        public async Task<IActionResult> PutSongAlbum(int id, string album)
        {
            await _songService.UpdateSongAlbum(id, album);
            return NoContent();
        }


        [HttpPut("atualiza-ano-lancamento")]
        public async Task<IActionResult> PutSongAno(int id, string ano)
        {
            await _songService.UpdateSongAno(id, ano);
            return NoContent();
        }




        [HttpPut("atualiza-genero")]
        public async Task<IActionResult> PutSongGenero(int id, string genero)
        {
            await _songService.UpdateSongGenero(id, genero);
            return NoContent();
        }


        [HttpDelete("deletar-musica")]
        public async Task <IActionResult> DeleteSong(int id)
        {
            await _songService.DeleteSong(id);
            return NoContent();
        }



        [HttpDelete("deletar-musicas-artista")]
        public async Task <IActionResult> DeleteSongsArtista (string artista)
        {
            await _songService.DeleteArtista(artista);
            return NoContent();
        }
    }
}
