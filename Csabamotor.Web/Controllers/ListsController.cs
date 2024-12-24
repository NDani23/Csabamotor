using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Csabamotor.Web.Models;
using Csabamotor.Web.Services;
using Microsoft.Data.SqlClient;

namespace Csabamotor.Web.Controllers
{
    public class ListsController : Controller
    {
        private readonly ICsabamotorService _service;

        public ListsController(ICsabamotorService service)
        {
            _service = service;
        }

        // GET: Lists
        public IActionResult Index()
        {
            return View(_service.GetLists());
        }

        // GET: Lists/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                //ViewData["NameSortParam"] = sortOrder == SortOrder.NAME_DESC ? SortOrder.NAME_ASC : SortOrder.NAME_DESC;
                //ViewData["DeadLineSortParam"] = sortOrder == SortOrder.DEADLINE_DESC ? SortOrder.DEADLINE_ASC : SortOrder.DEADLINE_DESC;

                List list = _service.GetListDetails(id);

                //switch (sortOrder)
                //{
                //    case SortOrder.NAME_DESC:
                //        list.Items = list.Items.OrderByDescending(i => i.Name).ToList();
                //        break;
                //    case SortOrder.NAME_ASC:
                //        list.Items = list.Items.OrderBy(i => i.Name).ToList();
                //        break;
                //    case SortOrder.DEADLINE_DESC:
                //        list.Items = list.Items.OrderByDescending(i => i.Deadline).ToList();
                //        break;
                //    case SortOrder.DEADLINE_ASC:
                //        list.Items = list.Items.OrderBy(i => i.Deadline).ToList();
                //        break;
                //    default:
                //        break;
                //}

                return View(list);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
