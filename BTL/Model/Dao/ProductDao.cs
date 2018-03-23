using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        Dbcontext db = null;
        public ProductDao()
        {
            db = new Dbcontext();
        }
        
        public List<Product> ListAll()
        {
            return db.Products.Where(x => x.Status == true).OrderBy(x => x.CreatedDate).ToList();
        }

        public Product Details(long ID)
        {
            return db.Products.Find(ID);
        }
        public List<Product> ListReatedProducts(long ID)
        {
            var model = db.Products.Find(ID);
            return db.Products.Where(x => x.ID != ID && x.Status == true&& x.CategoryID==model.CategoryID).ToList();
        }
    }
}
