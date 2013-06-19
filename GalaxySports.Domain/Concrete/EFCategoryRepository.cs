using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySports.Domain.Abstract;
using GalaxySports.Domain.Entities;

namespace GalaxySports.Domain.Concrete
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Category> Categories
        {
            get { return context.Categories; }
        }

        public void SaveCategory(Category category)
        {
            if (category.CategoryID == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                var cat = context.Categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
                cat.Name = category.Name;
                cat.ImageMimeType = category.ImageMimeType;
                cat.ImageData = category.ImageData;
            }
            context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
