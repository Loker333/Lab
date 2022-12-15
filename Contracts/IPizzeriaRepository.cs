using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPizzeriaRepository
    {
        IEnumerable<Pizzeria> GetPizzerias(Guid menuId, bool trackChanges);
        Pizzeria GetPizzeria(Guid menuId, Guid id, bool trackChanges);
        void CreatePizzeriaForMenu(Guid menuId, Pizzeria pizzeria);
        void DeletePizzeria(Pizzeria pizzeria);
    }
}
