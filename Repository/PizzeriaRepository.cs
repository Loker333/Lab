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

        public Pizzeria GetPizzeria(Guid menuId, Guid id, bool trackChanges) =>
        FindByCondition(e => e.Menu.Equals(menuId) && e.Id.Equals(id), trackChanges).SingleOrDefault();
        public void CreatePizzeriaForMenu(Guid menuId, Pizzeria pizzeria)
        {
            pizzeria.MenuId = menuId;
            Create(pizzeria);
        }
        public void DeletePizzeria(Pizzeria pizzeria)
        {
            Delete(pizzeria);
        }
        public IEnumerable<Pizzeria> GetPizzerias(Guid menuId, bool trackChanges) =>
        FindByCondition(e => e.Menu.Equals(menuId), trackChanges).OrderBy(e => e.Name);
    }
}
