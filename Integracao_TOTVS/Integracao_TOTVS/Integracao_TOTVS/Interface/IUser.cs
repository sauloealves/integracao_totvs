using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_TOTVS.Model
{
    public interface IUser
    {
        void getUserAuth(string username, string password);
    }
}
