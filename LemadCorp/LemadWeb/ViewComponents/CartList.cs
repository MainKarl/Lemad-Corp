﻿using FluentValidation.Validators;
using LemadDb.Data;
using LemadDb.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static LemadDb.Data.Enumerable;


namespace LemadWeb.ViewComponents
{
    public class CartList : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public CartList(ApplicationDbContext context) { _context = context; }

        public async Task<IViewComponentResult> InvokeAsync(
            Dictionary<int, int> products)
        {
            if (products == null) {
                return View(ListCart.CreateAsync(new Dictionary<Product, int>(), false));
            }

            Dictionary<Product, int> lstProducts = new Dictionary<Product, int>();

            foreach (var product in products) {
                lstProducts.Add(_context.Products.Where(c => c.Id == product.Key).SingleOrDefault(), product.Value);
            }

            return View(ListCart.CreateAsync(lstProducts, true));
        }
    }
}
