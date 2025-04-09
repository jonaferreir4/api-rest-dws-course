using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Persistence.Context;

namespace api_rest.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDBContext _context;

        public BaseRepository(AppDBContext context)
        {
            _context = context;
        }
    }
}