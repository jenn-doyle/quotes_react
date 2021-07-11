using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("quotes")]
public class QuoteController : ControllerBase
{
    private readonly IRepository<Quotes> _quoteRepository;

    public QuoteController(IRepository<Quotes> quoteRepository)
    {
        _quoteRepository = quoteRepository;
    }

    [HttpGet]
    public IEnumerable<Quotes> GetAll()
    {
        return _quoteRepository.GetAll();
    }

    [HttpGet("{rand}")]
    public async Task<IActionResult> Get(int rand)
    {
        try
        {
            var quote = await _quoteRepository.Get(rand);
            return Ok(quote);
        }
        catch (Exception)
        {
            //handle exception
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] Quotes quote)
    {
        try
        {
            Console.WriteLine(ModelState.IsValid);
            var insertQuote = await _quoteRepository.Insert(new Quotes { Quote = quote.Quote, SaidBy = quote.SaidBy, SuggestedBy = quote.SuggestedBy });
            return Ok(insertQuote);

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
    public async Task<IActionResult> Update(long id, [FromBody] Quotes quote)
    {
        try
        {
            var editQuote = await _quoteRepository.Update(new Quotes { Id = id, Quote = quote.Quote, SaidBy = quote.SaidBy, SuggestedBy = quote.SuggestedBy });
            return Ok(editQuote);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
            Console.WriteLine(error.StackTrace);
            //handle exception
            return NotFound("no quote updated");
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _quoteRepository.Delete(id);
        return Ok();
    }
}