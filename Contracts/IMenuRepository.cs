using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> GetAllMenu(bool trackChanges);
        Menu GetMenu(Guid menuId, bool trackChanges);
        void CreateMenu(Menu menu);
        IEnumerable<Menu> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteMenu(Menu menu);
    }
}
