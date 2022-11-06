using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPizzeriaRepository
    {
        IEnumerable<Pizzeria> GetAllPizzerias(bool trackChanges);
    }
}
