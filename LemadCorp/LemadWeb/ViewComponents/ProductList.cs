﻿using FluentValidation.Validators;
using LemadDb.Data;
using LemadDb.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LemadDb.Data.Enumerable;

namespace LemadWeb.ViewComponents
{
    public class ProductList : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ProductList(ApplicationDbContext context) { _context = context; }

        public async Task<IViewComponentResult> InvokeAsync(
            string sortOrder = null,
            List<string> search = null,
            string Pricefilter = null,
            string Statefilter = null,
            string Categoryfilter = null,
            string Discountfilter = null,
            int? pageNumber = 1)
        {
            int pageSize = 12;
            var item = _context.Products.ToList();

            switch (sortOrder)
            {
                case "date_desc":
                    item = item.OrderByDescending(p => p.DateNaissance).ToList();
                    break;
                case "date":
                    item = item.OrderBy(p => p.DateNaissance).ToList();
                    break;
                case "discount_desc":
                    item = item.OrderByDescending(p => p.Discount).ToList();
                    break;
                case "discount":
                    item = item.OrderBy(p => p.Discount).ToList();
                    break;
                case "name_desc":
                    item = item.OrderByDescending(p => p.Name).ToList();
                    break;
                case "price":
                    item = item.OrderBy(p => p.ActualPrice).ToList();
                    break;
                case "price_desc":
                    item = item.OrderByDescending(p => p.ActualPrice).ToList();
                    break;
                default:
                    item = item.OrderBy(p => p.Name).ToList();
                    break;
            }

            if (search[0] != "") {
                List<Product> newList = new List<Product>();
                foreach (string name in search) {
                    if (name != "" && name != " ")
                    {
                        foreach(Product product in item.Where(c => c.Name.ToLower().Contains(name.ToLower())))
                        {
                            if (!newList.Contains(product))
                                newList.Add(product);
                        }
                    }
                }
                item = newList;
            }

            if (!string.IsNullOrEmpty(Pricefilter))
            {
                switch (Pricefilter)
                {
                    case "tier1":
                        item = item.Where(c => c.ActualPrice <= 650000 && 
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                    case "tier2":
                        item = item.Where(c => c.ActualPrice > 650000 && c.ActualPrice <= 850000 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                    case "tier3":
                        item = item.Where(c => c.ActualPrice > 850000 && c.ActualPrice <= 1000000 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                    case "tier4":
                        item = item.Where(c => c.ActualPrice > 1000000 && c.ActualPrice <= 2000000 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                    case "tier5":
                        item = item.Where(c => c.ActualPrice > 2000000 && c.ActualPrice <= 10000000 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                    case "tier6":
                        item = item.Where(c => c.ActualPrice > 10000000 && c.ActualPrice <= 25000000 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                    case "tier7":
                        item = item.Where(c => c.ActualPrice > 25000000 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                }
            }
            if (!string.IsNullOrEmpty(Statefilter))
            {
                switch (Statefilter)
                {
                    case "AVAILABLE":
                        item = item.Where(c => c.Status == ProductStatus.AVAILABLE).ToList();
                        break;
                    case "INCOMMANDE":
                        item = item.Where(c => c.Status == ProductStatus.INCOMMANDE).ToList();
                        break;
                    case "UNAVAILABLE":
                        item = item.Where(c => c.Status == ProductStatus.UNAVAILABLE).ToList();
                        break;
                    case "LIQUIDATION":
                        item = item.Where(c => c.Status == ProductStatus.LIQUIDATION).ToList();
                        break;
                    case "PROMOTION":
                        item = item.Where(c => c.Status == ProductStatus.PROMOTION).ToList();
                        break;
                }
            }
            if (!string.IsNullOrEmpty(Categoryfilter))
            {
                switch (Categoryfilter)
                {
                    case "DRIVER":
                        item = item.Where(c => c.ProductCategory == ProductCategory.DRIVER).ToList();
                        break;
                    case "PRINCIPAL":
                        item = item.Where(c => c.ProductCategory == ProductCategory.PRINCIPAL).ToList();
                        break;
                    case "RACEENGINEER":
                        item = item.Where(c => c.ProductCategory == ProductCategory.RACEENGINEER).ToList();
                        break;
                    case "TECHNICALCHIEF":
                        item = item.Where(c => c.ProductCategory == ProductCategory.TECHNICALCHIEF).ToList();
                        break;
                    case "POWERUNIT":
                        item = item.Where(c => c.ProductCategory == ProductCategory.POWERUNIT).ToList();
                        break;
                }
            }
            if (!string.IsNullOrEmpty(Discountfilter))
            {
                switch (Discountfilter)
                {
                    case "tier0":
                        item = item.Where(c => c.Discount > 0 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                    case "tier1":
                        item = item.Where(c => c.Discount > 0 && c.Discount <= 5 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                    case "tier2":
                        item = item.Where(c => c.Discount > 5 && c.Discount <= 10 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                    case "tier3":
                        item = item.Where(c => c.Discount > 10 && c.Discount <= 20 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                    case "tier4":
                        item = item.Where(c => c.Discount > 20 && c.Discount <= 35 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                    case "tier5":
                        item = item.Where(c => c.Discount > 35 &&
                                         (c.Status == ProductStatus.AVAILABLE || c.Status == ProductStatus.PROMOTION || c.Status == ProductStatus.LIQUIDATION)).ToList();
                        break;
                }
            }

            ViewBag.Verification = (item.Count() > 0) ? true : false;
            return View(PaginatedList<Product>.CreateAsync(item, pageNumber ?? 1, pageSize, search, sortOrder, Pricefilter, Statefilter, Categoryfilter, Discountfilter));
        }
    }
}
