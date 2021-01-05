import { Component, OnInit, ViewChildren, QueryList } from '@angular/core';
import { FilmesService } from '../filmes.service';
import { Filme } from '../filme';
import { FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms';

import Swal from 'sweetalert2'

@Component({
  selector: 'app-filmes',
  templateUrl: './filmes.component.html',
  styleUrls: ['./filmes.component.css']
})
export class FilmesComponent implements OnInit {
  public filmes: Filme[];
  public filmesFormGroup: FormGroup
  public selecionados: number = 0;
  public vencedores: Filme[];
  public isHidden: boolean;
  constructor(private _filme: FilmesService, private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {

    this.filmesFormGroup = this.formBuilder.group({
      filme: this.formBuilder.array([])
    });
    this._filme.buscarTodos().subscribe(x => {
      this.filmes = x;

    });

  }
  onChange(event) {
    const filme = <FormArray>this.filmesFormGroup.get('filme') as FormArray;
    if (event.checked) {
      filme.push(new FormControl(event.source.value));
      this.selecionados++;
    } else {
      const i = filme.controls.findIndex(x => x.value === event.source.value);
      filme.removeAt(i);
      this.selecionados--;
    }

  }
  submit() {
    let filmesSelecionados: Filme[] = new Array<Filme>()
    for (let i = 0; i < this.filmes.length; i++) {
      for (let item in this.filmesFormGroup.controls.filme.value) {
        if (this.filmesFormGroup.controls.filme.value[item] === this.filmes[i].id) {
          filmesSelecionados.push(this.filmes[i]);
        }
      }
    }
    if (filmesSelecionados.length !== 8) {
      Swal.fire({
        title: 'Atenção!',
        text: 'Para fazer o campoenato é necessário selecionar 8 filmes',
        icon: 'warning',
      })
    } else {
      this._filme.fazerCompeticao(filmesSelecionados).subscribe(x => {
        this.filmes = [];
        this.vencedores = x;
        this.isHidden = true
      });
    }

  }

}
