using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Menu>> GetAllMenuAsync(bool trackChanges)
        => await FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToListAsync();
        public async Task<Menu> GetMenuAsync(Guid menuId, bool trackChanges) =>
         await FindByCondition(c => c.Id.Equals(menuId), trackChanges)
         .SingleOrDefaultAsync();
        public async Task<IEnumerable<Menu>> GetByIdsAsync(IEnumerable<Guid> ids, bool
        trackChanges) =>
         await FindByCondition(x => ids.Contains(x.Id), trackChanges)
         .ToListAsync();

        public void DeleteMenu(Menu menu)
        {
            Delete(menu);
        }

    }
}