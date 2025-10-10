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

        public async Task<Parent> AddAsync(Parent parent)
        {
            var sql = "INSERT INTO parents (name, phonenumber, email) VALUES (@Name, @PhoneNumber, @Email)";
            var affectedRows = await _db.ExecuteAsync(sql, parent);

            if (affectedRows == 0)
                throw new Exception("Kayıt eklenemedi.");

            return parent; // ID otomatik gelmez, SERIAL/IDENTITY varsa ayrı sorgu ile alınabilir
        }
    }
}
