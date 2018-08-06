using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PuffyAmiYumi.Data;
using PuffyAmiYumi.Models;
using PuffyAmiYumi.Models.Interfaces;
using PuffyAmiYumi.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {
        private IInventory _context;
        private YumiDbContext _orders;

        private readonly IConfiguration Configuration;

        public AdminController(IInventory context, IConfiguration configuration, YumiDbContext orders)
        {
            _context = context;
            _orders = orders;
            Configuration = configuration;
        }
        
        public ActionResult Index()
        {
            LoginViewModel lvm = new LoginViewModel();
            var posts = _orders.Orders.OrderByDescending(a => a.FullName)
                .Take(20).ToList();
            lvm.order = posts;
            return View(lvm);
        }
    }
}