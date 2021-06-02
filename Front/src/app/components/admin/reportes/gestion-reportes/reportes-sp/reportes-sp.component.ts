import {Component, OnInit} from '@angular/core';
import {FormGroup, FormControl} from '@angular/forms';
import {DetalleVentas} from '../../../../../models/Ventas/detalleventas';
import {HttpClient} from '@angular/common/http';
import {ConfiguracionService} from '../../../../../services/configuracion.service';
import {DATA_BAR_CHAR, ReporteSPM} from '../../../../../models/Reportes/reporte-spm';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import {IBarChart} from "../../../../../models/Reportes/charts.interface";

@Component({
  selector: 'app-reportes-sp',
  templateUrl: './reportes-sp.component.html',
  styleUrls: ['./reportes-sp.component.css']
})
export class ReportesSPComponent implements OnInit {
  data: IBarChart[];


  view: any[] = [700, 400];

  // options
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  xAxisLabel = 'SOLICITUDES PERSONALIZADAS';
  showYAxisLabel = true;
  yAxisLabel = 'CANTIDAD';

  colorScheme = {
    domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
  };

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });

  ReporteE: ReporteSPM;
Cotizada=0;

  constructor(private http: HttpClient,
              private configuracion: ConfiguracionService) {
  }

  downloadPDF(): void {
    alert('Generando Reporte');
    // Extraemos el
    const DATA = document.getElementById('htmlData');
    const doc = new jsPDF('p', 'pt', 'a4');
    const options = {
      background: 'white',
      scale: 3
    };
    html2canvas(DATA, options).then((canvas) => {

      const img = canvas.toDataURL('image/PNG');

      // Add image Canvas to PDF
      const bufferX = 15;
      const bufferY = 15;
      const imgProps = (doc as any).getImageProperties(img);
      const pdfWidth = doc.internal.pageSize.getWidth() - 2 * bufferX;
      const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;
      doc.addImage(img, 'PNG', bufferX, bufferY, pdfWidth, pdfHeight, undefined, 'FAST');
      return doc;
    }).then((docResult) => {
      docResult.save(`${new Date().toISOString()}_ReporteSolicitudesPersonalizadas.pdf`);
    });
  }

  Reporte(): void {

    this.http.get(this.configuracion.rootURL + '/Reportes/Solicitudes/' +
      this.range.get('start').value.toJSON() + '/' + this.range.get('end').value.toJSON()).toPromise().then(res => {
      this.ReporteE = res as ReporteSPM;
    });
  }

  ngOnInit(): void {
    this.data=DATA_BAR_CHAR;
    this.http.get(this.configuracion.rootURL +
      '/Reportes/Solicitudes/0001-01-01 00:00:00.0000000/0001-01-01 00:00:00.0000000').toPromise().then(res => {
      this.ReporteE = res as ReporteSPM;



    });
    this.data.push({
      name:'Cotizada',
      value: this.Cotizada,
      extra:{
        code:'co'
      }
    })


  }


}
