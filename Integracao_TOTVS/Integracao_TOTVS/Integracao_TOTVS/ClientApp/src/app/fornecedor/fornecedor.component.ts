import { Component , Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fornecedor',
  templateUrl: './fornecedor.component.html',
})
export class FornecedorComponent {
  cpfcnpj: string = '11167539000237';
  public fornecedor: Fornecedor;
  public http: HttpClient;
  public baseUrl: string;

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.http = _http;
    this.baseUrl = _baseUrl;    
  }

  public consultaCNPJ() {
    this.http.get<Fornecedor>(this.baseUrl + 'api/Fornecedor/' + this.cpfcnpj).subscribe(result => {
      this.fornecedor = result;
    }, error => console.error(error));
    
  }
}

interface Fornecedor {
  agencia: string;
  bairro: string;
  banco: string;
  cep: string;
  codigo_municipio: string;
  complemento: string;
  ddd: string;
  dv_agencia: string;
  dv_conta: string;
  email: string;
  endereco: string;
  estado: string;
  inscricao_estadual: string;
  municipio: string;
  natureza: string;
  nome_fantasia: string;
  nome_fornecedor: string;
  numero_conta: string;
  telefone: string;
  tipo_conta: string;
  tipo_fornecedor: string;
}
