using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using moon_light_rest_api.entities;

namespace moon_light_rest_api.Repositories
{
    public interface IParentRepository
    {
        Task<IEnumerable<Parent>> GetAllAsync();
        Task<Parent> AddAsync(Parent parent);
    }
}