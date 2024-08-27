using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionInloggning
{
    public interface IDatabaseService
    {
        bool AuthenticateUser(string username, string password);
    }
}
