using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserAuth<RET>
    {
        RET Authenticate(string username, string password);
        RET Register(string username, string password, string email);
    }
}
