using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        Dbcontext db = null;
        public CategoryDao()
        {
            db = new Dbcontext();
        }
        public List<Category> ListByID(long ID)
        {
            return db.Categories.Where(x => x.ParentID == ID).ToList();
        }
        //danh sach san pham tren admin
        public IEnumerable<Category> ListAll(String searchString, int page, int pagesize)
        {
            var model = db.Categories.OrderByDescending(x => x.CreatedDate);
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString)).OrderBy(x => x.CreatedDate);
            }
            return model.ToPagedList(page, pagesize);
        }
        //danh san pham tren client
        public IEnumerable<Product> ListAllByProductCategoryID(String searchString, int page, int pagesize, long? ID = null)
        {
            var model = db.Products.Where(x=>x.CategoryID==ID).OrderByDescending(x => x.CreatedDate);
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString)).OrderBy(x=>x.CreatedDate);
            }
            return model.ToPagedList(page, pagesize);
        }
        //list category by ID
        public List<Category> ListCategoryByID(long ID)
        {
            return db.Categories.Where(x => x.ParentID == ID).ToList();
        }
    }
}
