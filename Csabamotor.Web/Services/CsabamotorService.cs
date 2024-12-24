using Csabamotor.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Csabamotor.Web.Services
{
    public class CsabamotorService : ICsabamotorService
    {
        private readonly CsabamotorDBContext _context;

        public CsabamotorService(CsabamotorDBContext context)
        {
            _context = context;
        }

        public List<List> GetLists(String? name = null)
        {
            return _context.Lists
                .Where(l => l.Name.Contains(name ?? ""))
                .OrderBy(l => l.Name)
                .ToList();
        }

        public List GetListByID(int id)
        {
            return _context.Lists
                .Single(l => l.Id == id); // throws exception if id not found
        }

        public List<Item> GetItemsByListID(int id)
        {
            return _context.Items
                 .Where(i => i.ListId == id)
                 .ToList();
        }

        public void AddItemToList(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void ChangeListName(int id, String newName)
        {
            var list = _context.Lists
                 .Single(l => l.Id == id); // throws exception if id not found

            list.Name = newName;

            _context.SaveChanges();
        }

        public void RemoveItemByName(int id, String name)
        {
            Item? item = _context.Items
                .Where(i => i.ListId == id)
                .FirstOrDefault(i => i.Name == name);

            if (item == null)
                return;

            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public List GetListDetails(int id)
        {
            return _context.Lists
                .Include(l => l.Items)
                .Single(l => l.Id == id);
        }

        public Item? GetItem(int id)
        {
            return _context.Items
                 .FirstOrDefault(i => i.Id == id);
        }
    }
}
