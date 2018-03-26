using Model.EF;
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
    }
}
