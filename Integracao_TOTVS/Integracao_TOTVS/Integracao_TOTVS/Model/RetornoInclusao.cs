using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao_TOTVS.Model
{
    public class RetornoInclusao
    {
        public string STATUS_CODE { get; set; }
        public string FILIAL_TITULO { get; set; }
        public string PREFIXO_TITULO { get; set; }
        public string NUMERO_TITULO { get; set; }
        public string PARCELA_TITULO { get; set; }
        public string TIPO_TITULO { get; set; }
        public string CNPJ_CLIENTE { get; set; }
        public string CNPJ_FORNECEDOR { get; set; }
        public string MENSAGEM { get; set; }
    }
}
