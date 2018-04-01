using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        Dbcontext db = null;
        public OrderDetailDao()
        {
            db = new Dbcontext();
        }
        public bool Insert(OrderDetail orderDetail)
        {
            try
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public List<OrderDetail> ListAll()
        {
            return db.OrderDetails.ToList();
        }
        //tra ve 1 danh sach order details theo ID hoa don
        public List<OrderDetail> ListByID(long? ID)
        {
            return db.OrderDetails.Where(x => x.OrderID == ID).ToList();
        }
    }
}
