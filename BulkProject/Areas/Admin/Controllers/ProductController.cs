﻿using Microsoft.AspNetCore.Mvc;
using Bulk.DataAccess.Data;
using Bulk.Models;
using Bulk.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Bulk.Models.ViewModels;

namespace BulkProject.Areas.Admin.Controllers
{
    //User Admin role structural area
    [Area("Admin")]
    public class ProductController : Controller
    {
        //Readonly database object variable. 
        //No object created. Already created under Program.cs / Add services (Dependency Injection)
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        //Retrive data from database to show in page
        //public CategoryController(ApplicationDbContext db) 
        //{
        //    _db = db;
        //}

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        //Action controller to show Categories DbContext as a list 
        public IActionResult Index()
        {
            //Create list of DbContext Categories to initialize with View model
            List<Product> ProductListObj = _unitOfWork.Product.GetAll().ToList();
            
            //Pass product objects in DbContext to corresponded View model 
            return View(ProductListObj);
        }

        //New action method for new category addition
        public IActionResult CreateProduct()
        {
            //Projection object variable in another object view 
            //Press F12 while SelectListItem highlighted to see all List Items
            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            //{
            //    Text = u.Name,
            //    Value = u.Id.ToString(),
            //});

            //Pass created Category List to view with ViewBag
            //Alternatives:
            //ViewData ["CategoryList"] = CategoryList;
            //ViewBag.CategoryList = CategoryList;

            //Created ViewModel for Product and Category, passed to the View
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Product = new Product()
            };

            return View(productVM);
        }

        //Invoked when posted with +New Category through http
        //Create new Category Object
        [HttpPost]
        public IActionResult CreateProduct(ProductVM productVM)
        {
            //Custom validations for Name Field
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "Display Order can not be same as Name");
            //}
            //else if (int.TryParse(obj.Name, out int intValue))
            //{
            //    ModelState.AddModelError("Name", "Name can not be a number");
            //}

            //Check all validations 
            if (ModelState.IsValid)
            {
                //Point to SQL database to add created obj
                _unitOfWork.Product.Add(productVM.Product);
                //Add and save it to SQL database
                _unitOfWork.Save();
                //TempData
                TempData["success"] = "Product created successfully";
                //Redirect to View to category Index page
                return RedirectToAction("Index");
            }
            else 
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                return View(productVM);
            }
        }

        //New action method for new category edit
        public IActionResult EditProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            if (id != 0)
            {
                ModelState.AddModelError("Id", "Id field can NOT change!!");
            }

            //Retrive category by Id from database to edit (Link operation)
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //other ways to retrive category by Id from database to edit
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            //Projection
            var CategoryList = GenerateCategoryList();
            ViewBag.CategoryList = CategoryList;

            //Check if corresponding retrive value is null
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        //Invoked when posted with Edit through http
        //Create new Category Object
        [HttpPost]
        public IActionResult EditCategory(Product obj)
        {

            //Check all validations 
            if (ModelState.IsValid)
            {
                //Point to SQL database with Id to edit created obj
                _unitOfWork.Product.Update(obj);
                //Add and save it to SQL database
                _unitOfWork.Save();
                //TempData
                TempData["success"] = "Product Updated successfully";
                //Redirect to View to category Index page
                return RedirectToAction("Index");
            }

            return View();
        }


        //New action method for new category delete
        public IActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Retrive category by Id from database to edit
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //other ways to retrive category by Id from database to edit
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            //Check if corresponding retrive value is null
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        //Invoked when posted with Edit through http
        //Create new Category Object
        //ActionName will point IActionResult DeleteCategory
        [HttpPost, ActionName("DeleteProduct")]
        public IActionResult DeleteProductPost(int? id)
        {
            //Create new Category object
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            //Point to SQL database with Id to delete created obj
            _unitOfWork.Product.Remove(obj);
            //Add and save it to SQL database
            _unitOfWork.Save();
            //TempData
            TempData["success"] = "Product Deleted successfully";
            //Redirect to View to category Index page
            return RedirectToAction("Index");
        }

        //Temporary Category List Generator method (will carry Bulk.Utility)
        public IEnumerable<SelectListItem> GenerateCategoryList()
        {
            return _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
        }

    }
}
