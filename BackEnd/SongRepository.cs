using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;


public class SongRepository : BaseRepository, IRepository<Songs>
{

    public SongRepository(IConfiguration configuration) : base(configuration) { }

    public IEnumerable<Songs> GetAll()
    {
        using var connection = CreateConnection();
        IEnumerable<Songs> songs = connection.Query<Songs>("SELECT * FROM Songs;");
        return songs;
    }

    public async Task<Songs> Get(long id)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Songs>("SELECT * FROM Songs WHERE Id = @id ORDER BY RANDOM() LIMIT 1;", new { Id = id });

    }
    public async Task<Songs> Insert(Songs song)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Songs>("INSERT INTO Songs (Title, Artist, Link, SongCode) VALUES (@Title, @Artist, @Link, @SongCode); SELECT * FROM Songs LIMIT 1;", song);
    }

    public async Task<Songs> Update(Songs song)
    {
        using var connection = CreateConnection();
        return await connection.QuerySingleAsync<Songs>("UPDATE Songs SET Title = @Title, Artist = @Artist, Link = @Link, SongCode= @SongCode WHERE Id = @Id;", song);
    }


    public async Task Delete(long id)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync("DELETE FROM Songs WHERE Id = @Id;", new { Id = id });
    }
}
