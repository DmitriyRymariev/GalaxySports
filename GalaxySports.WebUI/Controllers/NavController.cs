using GalaxySports.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaxySports.Domain.Entities;

namespace GalaxySports.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ICategoryRepository categoryRepository;

        public NavController(ICategoryRepository repository)
        {
            categoryRepository = repository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = categoryRepository.Categories
                .Where(x => !x.Deleted)
                .Select(x => x.Name)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }

        public FileContentResult GetImage(int categoryId)
        {
            Category category = categoryRepository.Categories.FirstOrDefault(n => n.CategoryID == categoryId);
            if (category != null)
            {
                return File(category.ImageData, category.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
