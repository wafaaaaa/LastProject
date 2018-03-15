using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CYJ.Models;

namespace CYJ.Services
{
    public class CategoryServices
    {
        private readonly UNFCYJEntities _dbContext;

        public CategoryServices()
        {
            _dbContext = new UNFCYJEntities();
        }

        public List<CATEGORY> GetAllCategories()
        {

            return _dbContext.CATEGORies.ToList();
        }
        public CATEGORY GetCategoryById(int id)
        {
            return _dbContext.CATEGORies.SingleOrDefault(t => t.categoryID == id);
        }

        public void Dispose()
        {
            //Cleanup Resources
            _dbContext.Dispose();
        }

    }
}