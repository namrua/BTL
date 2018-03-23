using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        Dbcontext db = null;
        public MenuDao()
        {
            db = new Dbcontext();
        }
        public List<Menu> ListMenubyGroupID(int groupID)
        {
            return db.Menus.Where(x => x.TypeID == groupID && x.Status==true).ToList();
        }
    }
}
