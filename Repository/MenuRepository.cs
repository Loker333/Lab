using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public IEnumerable<Menu> GetAllMenu(bool trackChanges) => FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToList();
        public IEnumerable<Menu> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges).ToList();
        public void CreateMenu(Menu menu) => Create(menu);
        public Menu GetMenu(Guid menuId, bool trackChanges) => FindByCondition(c => c.Id.Equals(menuId), trackChanges).SingleOrDefault();
        public void DeleteMenu(Menu menu)
        {
            Delete(menu);
        }
    }
}