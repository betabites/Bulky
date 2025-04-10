using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using SD7501Bulky.DataAccess.Repository;

namespace BulkyWeb.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Category> objCategoryList = _unitOfWork.CategoryRepository.GetAll().ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost,ActionName("Create")]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
            ModelState.AddModelError("Name", "Name cannot be the same as Display Order");
        if (ModelState.IsValid)
        {
            _unitOfWork.CategoryRepository.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category Added Successfully";
            return RedirectToAction("Index");
        }

        return View(obj);
    }

    public string GetAllCategories()
    {
        return "Return All Categories";
    }

    public string GetAllCategoriesByName(string name)
    {
        return $"Return All Categories by Name: {name}";
    }

    public IActionResult Edit(int id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        
        Category categoryFromDb = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        
        return View(categoryFromDb);
    }
    
    [HttpPost,ActionName("Edit")]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
            ModelState.AddModelError("Name", "Name cannot be the same as Display Order");
        if (ModelState.IsValid)
        {
            _unitOfWork.CategoryRepository.Update(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    
    public IActionResult Delete(int id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        
        Category categoryFromDb = _unitOfWork.CategoryRepository.Get(u=>u.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        
        return View(categoryFromDb);
    }
    
    [HttpPost,ActionName("Delete")]
    public IActionResult Delete(int? id)
    {
        Category? obj = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.CategoryRepository.Remove(obj);
        _unitOfWork.Save();
        return RedirectToAction("Index");
    }
}