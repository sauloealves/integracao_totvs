using Integracao_TOTVS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_TOTVS.Interface
{
    public interface IFornecedor
    {
        Fornecedor GetFornecedor(string cpfCnpj);
    }
}
