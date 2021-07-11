using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;


public class QuoteRepository : BaseRepository, IRepository<Quotes>
{

    public QuoteRepository(IConfiguration configuration) : base(configuration) { }

    public IEnumerable<Quotes> GetAll()
    {
        using var connection = CreateConnection();
        IEnumerable<Quotes> quotes = connection.Query<Quotes>("SELECT * FROM Quotes;");
        return quotes;
    }

    public async Task<Quotes> Get(long id)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Quotes>("SELECT * FROM Quotes ORDER BY RANDOM() LIMIT 1;");

    }
    public async Task<Quotes> Insert(Quotes quote)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Quotes>("INSERT INTO Quotes (Quote, SaidBy, SuggestedBy) VALUES (@Quote, @SaidBy, @SuggestedBy); SELECT * FROM Quotes LIMIT 1;", quote);
    }

    public async Task<Quotes> Update(Quotes quote)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Quotes>("UPDATE Quotes SET Quote = @Quote, SaidBy = @SaidBy, SuggestedBy = @SuggestedBy WHERE Id = @Id;", quote);
    }


    public async Task Delete(long id)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync("DELETE FROM Quotes WHERE Id = @Id;", new { Id = id });
    }

}
