using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("songs")]
public class SongController : ControllerBase
{
    private readonly IRepository<Songs> _songRepository;

    public SongController(IRepository<Songs> songRepository)
    {
        _songRepository = songRepository;
    }

    [HttpGet]
    public IEnumerable<Songs> GetAll()
    {
        return _songRepository.GetAll();
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var song = await _songRepository.Get(id);
            return Ok(song);
        }
        catch (Exception)
        {
            //handle exception
            return NotFound();
        }
    }


    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] Songs song)
    {
        try
        {
            Console.WriteLine(ModelState.IsValid);
            var insertSong = await _songRepository.Insert(new Songs { Title = song.Title, Artist = song.Artist, Link = song.Link });
            return Ok(insertSong);

        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
            Console.WriteLine(error.StackTrace);
            //handle exception
            return BadRequest();
        }
    }
    

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] Songs song)
    {
        try
        {
            var editSong = await _songRepository.Update(new Songs { Id = id, Title = song.Title, Artist = song.Artist, Link = song.Link });
            return Ok(editSong);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
            Console.WriteLine(error.StackTrace);
            //handle exception
            return NotFound("no song updated");
        }
    }


     [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _songRepository.Delete(id);
            return Ok();
        }
}