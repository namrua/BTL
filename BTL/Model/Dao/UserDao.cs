using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDAO
    {
         Dbcontext db = null;
        public UserDAO()
        {
            db = new Dbcontext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public int Login(String userName, String passWord)
        {
            var res = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (res != null)
            {
                if (res.PassWord == passWord)
                {
                    if (!res.Status)
                        return 2; //tai khoan bi khoa
                    else return 1; //dang nhap thanh cong

                }
                else return -1; // mk sai
            }
            else return 0; //tai khoan k ton tai
        }
        public List<User> UsLogin()
        {
            return db.Users.ToList();
        }

        public User GetByID(String username)
        {
            var res = db.Users.SingleOrDefault(x => x.UserName == username);
            return res;
        }
        public IEnumerable<User> ListAll(String searchString, int page, int pagesize)
        {
            var model = db.Users.OrderByDescending(x => x.CreatedDate);
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString)).OrderBy(x => x.CreatedDate);
            }
            return model.ToPagedList(page, pagesize);
        }

        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }


        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = entity.ModifiedDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<Contact> TestDropdown()
        {
            return db.Contacts.ToList();
        }
        public String UserAddress(String id)
        {
            var useraddress = db.Contacts.Find(id);
            return useraddress.Content;
        }
    }
}
    
