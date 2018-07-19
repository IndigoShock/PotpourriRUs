using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PuffyAmiYumi.Models;
using PuffyAmiYumi.Models.Interfaces;
using PuffyAmiYumi.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {
        private IInventory _context;

        private readonly IConfiguration Configuration;

        public AdminController(IInventory context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}