using Model.EF;
using PagedList;
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
        public List<Product> ListAllByProductCategoryID(long? ID=null)
        {
            var model = db.Categories.Where(x => x.ParentID == ID).ToList();
            var modelx = new List<Product>();
            foreach (var item in model)
            {
                var m = db.Products.Where(x => x.CategoryID == item.ID);
                if (m != null)
                {
                    foreach (var itemx in m)
                    {
                        modelx.Add(itemx);
                    }
                }
            }
            return modelx;
        }
        //danh sach product tren client
        public IEnumerable<Product> ListAllByProductCategoryID(String searchString, int page, int pagesize, long? ID = null)
        {
            var model = db.Categories.Where(x => x.ParentID == ID);
            var modelx = new List<Product>();
            foreach (var item in model)
            {
                var m = db.Products.Where(x => x.CategoryID == item.ID);
                if (m != null)
                {
                    foreach (var itemx in m)
                    {
                        modelx.Add(itemx);
                    }
                }
            }
            if(!String.IsNullOrEmpty(searchString))
            {
                modelx = modelx.Where(x => x.Name.Contains(searchString)).ToList();
            }
            return modelx.ToPagedList(page, pagesize);
        }
        //danh sach san pham tren admin
        public IEnumerable<Product> ListAll(String searchString, int page, int pagesize, long? ID = null)
        {
            var model = db.Products.OrderByDescending(x => x.CreatedDate);
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString)).OrderBy(x => x.CreatedDate);
            }
            return model.ToPagedList(page, pagesize);
        }
        //update list image
        public void UpdateImages(long ProductId, string images)
        {
            var product = db.Products.Find(ProductId);
            product.MoreImages = images;
            db.SaveChanges();
        }
    }
}
