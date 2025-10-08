using Dapper;
using moon_light_rest_api.entities;
using System.Data;

namespace moon_light_rest_api.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private readonly IDbConnection _db;

        public ParentRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Parent>> GetAllAsync()
        {
            var sql = "SELECT * FROM public.parents";
            return await _db.QueryAsync<Parent>(sql);
        }

        public async Task AddAsync(Parent parent)
        {
            var sql = "INSERT INTO public.parents (name, phonenumber, email) VALUES (@Name, @PhoneNumber, @Email)";
            await _db.ExecuteAsync(sql, parent);
        }
    }
}
