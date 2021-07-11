using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;


public class PicRepository : BaseRepository, IRepository<Pics>
{

    public PicRepository(IConfiguration configuration) : base(configuration) { }

    public IEnumerable<Pics> GetAll()
    {
        using var connection = CreateConnection();
        IEnumerable<Pics> pics = connection.Query<Pics>("SELECT * FROM Pics;");
        return pics;
    }

    public async Task<Pics> Get(long id)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Pics>("SELECT * FROM Pics ORDER BY RANDOM() LIMIT 1;");

    }
    public async Task<Pics> Insert(Pics pic)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Pics>("INSERT INTO Pics (PicName, PicLink, PicCode) VALUES (@PicName, @PicLink, @PicCode); SELECT * FROM Pics LIMIT 1;", pic);
    }

    public async Task<Pics> Update(Pics pic)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Pics>("UPDATE Pics SET PicName = @PicName, PicLink = @PicLink, PicCode = @PicCode WHERE Id = @Id;", pic);
    }



    public async Task Delete(long id)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync("DELETE FROM Pics WHERE Id = @Id;", new { Id = id });
    }
}
