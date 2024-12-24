using Csabamotor.Web.Models;

namespace Csabamotor.Web.Services
{
    public interface ICsabamotorService
    {
        List<List> GetLists(String? name = null);
        List GetListByID(int id);
        List<Item> GetItemsByListID(int id);
        List GetListDetails(int id);
        Item? GetItem(int id);
    }
}
