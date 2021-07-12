import { Component , Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
})
export class ClienteComponent {
  cpfcnpj: string = '29437740810';
  public cliente: Cliente;
  public http: HttpClient;
  public baseUrl: string;

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.http = _http;
    this.baseUrl = _baseUrl;    
  }

  public consultaCNPJ() {
    this.http.get<Cliente>(this.baseUrl + 'api/Cliente/' + this.cpfcnpj).subscribe(result => {
      this.cliente = result;
    }, error => console.error(error));
    
  }
}

interface Cliente {
  bairro: string;
  cep: string;
  codigo_municipio: string;
  complemento: string;
  ddd: string;
  email: string;
  endereco: string;
  estado: string;
  inscricao_estadual: string;
  municipio: string;
  natureza: string;
  nome_cliente: string;
  nome_fantasia: string;
  telefone: string;
  tipo_cliente: string;
}
