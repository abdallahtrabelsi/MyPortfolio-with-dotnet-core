﻿using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortfolioItem> _portfolio;

        public HomeController(IUnitOfWork<Owner> owner,IUnitOfWork<PortfolioItem> Portfolio)
        {
           _owner = owner;
            _portfolio = Portfolio;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().First(),
                portfolioItems = _portfolio.Entity.GetAll().ToList()
            };
            return View(homeViewModel);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
