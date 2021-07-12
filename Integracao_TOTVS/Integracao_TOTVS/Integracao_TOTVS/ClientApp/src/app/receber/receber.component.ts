import { Component , Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-receber',
  templateUrl: './receber.component.html',
})
export class ReceberComponent {
  
  public titulo: TituloReceber;
  public retorno: RetornoInclusao;
  public http: HttpClient;
  public baseUrl: string;

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.http = _http;
    this.baseUrl = _baseUrl;    
  }

  public incluir() {
    this.http.post<RetornoInclusao>(this.baseUrl + 'api/TituloReceber/', this.titulo ).subscribe(result => {
      this.retorno = result;
    }, error => console.error(error));
    
  }
}

interface TituloReceber {
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
