using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PizzeriaRepository : RepositoryBase<Pizzeria>, IPizzeriaRepository
    {
        public PizzeriaRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Pizzeria> GetAllPizzerias(bool trackChanges) => FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToList();
    }
}
