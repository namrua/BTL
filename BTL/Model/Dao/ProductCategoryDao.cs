using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        Dbcontext db = null;
        public ProductCategoryDao()
        {
            db = new Dbcontext();
        }
        public List<ProductCategory> ListProductCategory()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.CreatedDate).ToList();
        }

        public ProductCategory Details(long? ID)
        {
            return db.ProductCategories.Find(ID);
        }
    }
}
