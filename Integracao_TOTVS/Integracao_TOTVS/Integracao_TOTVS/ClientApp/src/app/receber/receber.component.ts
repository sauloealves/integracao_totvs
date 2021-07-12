import { Component , Inject} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-receber',
  templateUrl: './receber.component.html',
})
export class ReceberComponent {
  
  public titulo: TituloReceber;
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

    this.http.post<RetornoInclusao>(this.baseUrl + 'api/TituloReceber', this.arquivoJson, { headers } ).subscribe(result => {
      this.retorno = result;
      alert(result.mensagem);
    }, error => console.error(error));
    
  }

  ngOnInit() {
    this.titulo = new TituloReceber();

    this.titulo.cnpj_cliente = "29437740810";
    this.titulo.tipo_cliente = "f";
    this.titulo.nome_cliente = "saulo alves";
    this.titulo.nome_fantasia = "saulo alves";
    this.titulo.endereco = "rua itanhandu 25";
    this.titulo.complemento = "alphaville";
    this.titulo.bairro = "s.pedro";
    this.titulo.municipio = "belo horizonte";
    this.titulo.estado = "mg";
    this.titulo.codigo_municipio = "06200";
    this.titulo.cep = "36037873";
    this.titulo.inscricao_estadual = "isento";
    this.titulo.ddd = "32";
    this.titulo.telefone = "984015684";
    this.titulo.email = "sauloealves@gmail.com";
    this.titulo.natureza = "301001";
    this.titulo.filial_titulo = "0101";
    this.titulo.prefixo_titulo = "vda";
    this.titulo.numero_titulo = "902612";
    this.titulo.parcela_titulo = "1";
    this.titulo.tipo_titulo = "bra";
    this.titulo.forma_pagamento = "bol";
    this.titulo.data_emissao = "20210625";
    this.titulo.data_vencimento = "20210825";
    this.titulo.valor_titulo = "8332.65";
    this.titulo.historico = "";
    this.titulo.numero_projeto = "902119";
    this.titulo.centro_custo = "0102";
  }

  onSubmit() {
    this.incluir();
  }
}

export class TituloReceber {
  cnpj_cliente: string;
  tipo_cliente: string;
  nome_cliente: string;
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
  filial_titulo: string;
  prefixo_titulo: string;
  numero_titulo: string;
  parcela_titulo: string;
  tipo_titulo: string;
  forma_pagamento: string;
  data_emissao: string;
  data_vencimento: string;
  valor_titulo: string;
  historico: string;
  numero_projeto: string;
  centro_custo: string;
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
