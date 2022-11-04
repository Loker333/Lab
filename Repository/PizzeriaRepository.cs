using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class PizzeriaRepository : RepositoryBase<Pizzeria>, IPizzeriaRepository
    {
        public PizzeriaRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
