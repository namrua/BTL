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
        public IEnumerable<Category> ListAll(String searchString, int page, int pagesize)
        {
            var model = db.Categories.OrderByDescending(x => x.CreatedDate);
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString)).OrderBy(x => x.CreatedDate);
            }
            return model.ToPagedList(page, pagesize);
        }

    }
}
