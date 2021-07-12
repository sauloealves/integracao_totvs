using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_TOTVS.Model
{
    public interface ICliente
    {
        Cliente GetCliente(string cpfCnpj);
    }
}
