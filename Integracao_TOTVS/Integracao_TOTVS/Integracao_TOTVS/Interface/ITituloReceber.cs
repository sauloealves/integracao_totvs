using Integracao_TOTVS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_TOTVS.Interface
{
    interface ITituloReceber
    {
        RetornoInclusao Incluir(Cliente cliente, TituloReceber titulo);
        RetornoInclusao Incluir(string dados);
    }
}
