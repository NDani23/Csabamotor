using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Csabamotor.Web.Models;
using Csabamotor.Web.Services;

namespace Csabamotor.Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ICsabamotorService _service;

        public ItemsController(ICsabamotorService service)
        {
            _service = service;
        }

        public IActionResult? DisplayImage(int id)
        {
            var item = _service.GetItem(id);
            if (item != null && item.Image != null)
            {
                return File(item.Image, "image/jpg");
            }
            return null;
        }
    }
}
