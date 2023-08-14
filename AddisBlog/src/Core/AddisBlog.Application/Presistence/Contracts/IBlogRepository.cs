using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddisBlog.Domain.Entities;

namespace AddisBlog.Application.Presistence.Contracts
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        
    }
}