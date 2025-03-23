using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<Class, ID, RET>
    {
        RET Create(Class obj);
        List<Class> Read();
        Class Read(ID id);
        RET Update(Class obj);
        bool Delete(ID id);
    }
}
       
       
        

    

