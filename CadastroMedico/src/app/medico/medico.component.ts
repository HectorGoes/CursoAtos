import { error } from '@angular/compiler/src/util';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Medico } from '../models/Medico';
import { MedicosService } from '../services/Medicos.service';

@Component({
  selector: 'app-medico',
  templateUrl: './medico.component.html',
  styleUrls: ['./medico.component.css']
})

export class MedicoComponent implements OnInit {

  titleMedico = 'Médicos'
  public selectedMedico: Medico;
  public medicoForm: FormGroup;
  public modaRef: BsModalRef;

  public medicos: Medico[];

  openModal(template: TemplateRef<any>){
    this.modaRef = this.modalService.show(template);
  }

  createForm(){
    this.medicoForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      especialidade: [''],
      crm: ['', Validators.required],
      telefone: ['', Validators.required]
    });
  }

  selectMedico(medico: Medico) {
    this.selectedMedico = medico;
    this.medicoForm.patchValue(medico);
  }
  /*
  back(medico: any){
    this.selectedMedico = medico;
  }
  */
  back(){
    this.selectedMedico = null;
    this.loadMedico();
  }

  submit(){
    console.log(this.medicoForm.value)
    this.saveMedico(this.medicoForm.value);
  }

  saveMedico(medico: Medico){
    this.medicoService.alter(medico).subscribe(
      (retorno: Medico) => {
        console.log(retorno);
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  loadMedico(){
    this.medicoService.getAll().subscribe(
      (medicos: Medico[]) => {
        this.medicos = medicos;
      },
      (error: any) => {
        console.log(error);
      }
      
    );
  }

  deleteMedico(id: number){
    this.medicoService.delete(id).subscribe(
      (modal: any) => {
        console.log(modal);
        this.loadMedico();
      },
      
      (error: any) => {
        console.log(error);
      }
    );
    
  }

  constructor(private fb: FormBuilder, private modalService:BsModalService, private medicoService: MedicosService) {
    this.createForm();
   }

  ngOnInit(): void {
    this.loadMedico();
  }

}
