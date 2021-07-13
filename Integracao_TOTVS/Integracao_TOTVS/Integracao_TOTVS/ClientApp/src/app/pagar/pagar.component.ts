import { Component , Inject} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-pagar',
  templateUrl: './pagar.component.html',
})
export class PagarComponent {
  
  public titulo: TituloPagar;
  public retorno: RetornoInclusao;
  public http: HttpClient;
  public baseUrl: string;
  arquivoJson: String;

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.http = _http;
    this.baseUrl = _baseUrl;    
  }

  public incluir() {
    
    this.arquivoJson =  JSON.stringify(this.titulo);
    const headers = new HttpHeaders().set('content-type', 'application/json');

    this.http.post<RetornoInclusao>(this.baseUrl + 'api/TituloPagar', this.arquivoJson, { headers } ).subscribe(result => {
      this.retorno = result;
      alert(result.mensagem);
    }, error => console.error(error));
    
  }

  ngOnInit() {
    this.titulo = new TituloPagar();

    this.titulo.cnpj_fornecedor = "33496058000127",
      this.titulo.tipo_fornecedor = "j",
      this.titulo.nome_fornecedor = "michel blumenfeld mendonca eireli",
      this.titulo.nome_fantasia = "franquia brasilia",
      this.titulo.endereco = "q shis qi 9 bloco a",
      this.titulo.complemento = "sala 8",
      this.titulo.bairro = "setor de habitacoes individuais sul",
      this.titulo.municipio = "brasilia",
      this.titulo.estado = "sp",
      this.titulo.codigo_municipio = "00108",
      this.titulo.cep = "71625171",
      this.titulo.inscricao_estadual = "0791392800193",
      this.titulo.ddd = "61",
      this.titulo.telefone = "98089082",
      this.titulo.email = "",
      this.titulo.natureza = "403002",
      this.titulo.banco_fornec = "033",
      this.titulo.agencia_fornec = "0931",
      this.titulo.dv_agencia_fornec = "",
      this.titulo.numero_conta_fornec = "13001209",
      this.titulo.dv_conta_fornec = "1",
      this.titulo.tipo_conta_fornec = "1",
      this.titulo.filial_titulo = "0101",
      this.titulo.prefixo_titulo = "",
      this.titulo.numero_titulo = "90188001",
      this.titulo.parcela_titulo = "1",
      this.titulo.tipo_titulo = "faf",
      this.titulo.data_emissao = "20210625",
      this.titulo.data_vencimento = "20210725",
      this.titulo.valor_titulo = "1500",
      this.titulo.historico = "parc 1 proj 901880",
      this.titulo.numero_projeto = "901880",
      this.titulo.centro_custo = "0110",
      this.titulo.banco_titulo = "",
      this.titulo.agencia_titulo = "",
      this.titulo.dv_agencia_titulo = "",
      this.titulo.numero_conta_titulo = "",
      this.titulo.dv_conta_titulo = ""
  }

  onSubmit() {
    this.incluir();
  }
}

export class TituloPagar {
  cnpj_fornecedor: string;
  tipo_fornecedor: string;
  nome_fornecedor: string;
  nome_fantasia: string;
  endereco: string;
  complemento: string;
  bairro: string;
  municipio: string;
  estado: string;
  codigo_municipio: string;
  cep: string;
  inscricao_estadual: string;
  ddd: string;
  telefone: string;
  email: string;
  natureza: string;
  banco_fornec: string;
  agencia_fornec: string;
  dv_agencia_fornec: string;
  numero_conta_fornec: string;
  dv_conta_fornec: string;
  tipo_conta_fornec: string;
  filial_titulo: string;
  prefixo_titulo: string;
  numero_titulo: string;
  parcela_titulo: string;
  tipo_titulo: string;
  data_emissao: string;
  data_vencimento: string;
  valor_titulo: string;
  historico: string;
  numero_projeto: string;
  centro_custo: string;
  banco_titulo: string;
  agencia_titulo: string;
  dv_agencia_titulo: string;
  numero_conta_titulo: string;
  dv_conta_titulo: string;
}

interface RetornoInclusao {
  status_inclusao: string;
  filial_titulo: string;
  prefixo_titulo: string;
  numero_titulo: string;
  parcela_titulo: string;
  tipo_titulo: string;
  cnpj_cliente: string;
  mensagem: string;
}
