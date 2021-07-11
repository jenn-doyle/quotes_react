using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("pics")]
public class PicController : ControllerBase
{
    private readonly IRepository<Pics> _picRepository;

    public PicController(IRepository<Pics> picRepository)
    {
        _picRepository = picRepository;
    }

    [HttpGet]
    public IEnumerable<Pics> GetAll()
    {
        return _picRepository.GetAll();
    }

    [HttpGet("{rand}")]
    public async Task<IActionResult> Get(int rand)
    {
        try
        {
            var getPic = await _picRepository.Get(rand);
            return Ok(getPic);
        }
        catch (Exception)
        {
            //handle exception
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] Pics pic)
    {
        try
        {
            Console.WriteLine(ModelState.IsValid);
            var insertPic = await _picRepository.Insert(new Pics { PicName = pic.PicName, PicLink = pic.PicLink });
            return Ok(insertPic);

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
    public async Task<IActionResult> Update(long id, [FromBody] Pics pic)
    {
        try
        {
            var editPic = await _picRepository.Update(new Pics { Id = id, PicName = pic.PicName, PicLink = pic.PicLink });
            return Ok(editPic);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
            Console.WriteLine(error.StackTrace);
            //handle exception
            return NotFound("no pic updated");
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _picRepository.Delete(id);
        return Ok();
    }
}