import { error } from '@angular/compiler/src/util';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Cidade } from '../models/Cidade';
import { CidadesService } from '../services/Cidades.service';


@Component({
  selector: 'app-cidade',
  templateUrl: './cidade.component.html',
  styleUrls: ['./cidade.component.css']
})
export class CidadeComponent implements OnInit {

  titleCidade = 'Cidades'
  public selectedCidade: Cidade;
  public cidadeForm: FormGroup;
  public modaRef: BsModalRef;

  public cidades : Cidade[];

  openModal(template: TemplateRef<any>){
    this.modaRef = this.modalService.show(template);
  }
  creatForm(){
    this.cidadeForm = this.fb.group({
    id: [''],
    nome: ['', Validators.required],
    estado: ['', Validators.required]
    });
  } 

  selectCidade(cidade: Cidade){
    this.selectedCidade = cidade;
    this.cidadeForm.patchValue(cidade);
  }

  back(){
    this.selectedCidade = null;
    this.loadCidade();
  }

  submit(){
    console.log(this.cidadeForm.value)
    this.saveCidade(this.cidadeForm.value);
  }

  saveCidade(cidade: Cidade){
    this.cidadeService.alter(cidade).subscribe(
      (retorno: Cidade) => {
        console.log(retorno);
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  loadCidade(){
    this.cidadeService.getAll().subscribe(
      (cidades: Cidade[]) => {
        this.cidades = cidades;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  deleteCidade(id: number){
    this.cidadeService.delete(id).subscribe(
      (modal: any) => {
        console.log(modal);
        this.loadCidade();
      },
      
      (error: any) => {
        console.log(error);
      }
    );
    
  }

  constructor(private fb: FormBuilder, private modalService:BsModalService, private cidadeService: CidadesService) {
    this.creatForm();
   }

   ngOnInit(): void {
    this.loadCidade();
  }

}
