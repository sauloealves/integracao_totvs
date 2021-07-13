using Integracao_TOTVS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_TOTVS.Interface
{
    interface ITituloPagar
    {
        RetornoInclusao Incluir(Fornecedor fornecedor, TituloPagar titulo);
        RetornoInclusao Incluir(Inclui_Pagar dados);
    }
}
