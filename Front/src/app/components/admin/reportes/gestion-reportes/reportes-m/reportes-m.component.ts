import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {DATA_BAR_HORIZONTAL_CHAR, ReporteSPM} from '../../../../../models/Reportes/reporte-spm';
import {HttpClient} from '@angular/common/http';
import {ConfiguracionService} from '../../../../../services/configuracion.service';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import {IBarChart} from '../../../../../models/Reportes/charts.interface';
import {DATA_ADVANCE_CHAR} from '../../../../../models/Reportes/reporte-ventas';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-reportes-m',
  templateUrl: './reportes-m.component.html',
  styleUrls: ['./reportes-m.component.css']
})
export class ReportesMComponent implements OnInit {

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });

  ReporteE: ReporteSPM;
  data: IBarChart[];
  view: any[] = [600, 400];

  // options
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  yAxisLabel = 'CANTIDAD';
  noBarWhenZero = false;
  legendTitle = '';
  showYAxisLabel = true;
  xAxisLabel = '';

  colorScheme = {
    domain: ['#2C3461', '#317131', '#5290b1', '#AAAAAA', '#a3c4d5', '#A294BB', '#14232b', '#96E3DC', '#9ABB94', '#863531', '#4B6789']
  };

  constructor(private http: HttpClient,
              private configuracion: ConfiguracionService,
              private toastr: ToastrService) {
  }

  downloadPDF(): void {
    this.toastr.success('Generando Reporte', 'Reporte');
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

    this.http.get(this.configuracion.rootURL + '/Reportes/Montajes/' +
      this.range.get('start').value.toJSON() + '/' + this.range.get('end').value.toJSON()).toPromise().then(res => {
      this.data = [];
      this.ReporteE = res as ReporteSPM;

      const Cotizada = {
        name: 'Cotizada',
        value: this.ReporteE.Cotizada,
        extra: {
          code: 'co'
        }
      };
      const Aceptada = {
        name: 'Aceptada',
        value: this.ReporteE.Aceptada,
        extra: {
          code: 'ac'
        }
      };
      const Cancelada = {
        name: 'Cancelada',
        value: this.ReporteE.Cancelada,
        extra: {
          code: 'cn'
        }
      };
      const Devuelta = {
        name: 'Devuelta',
        value: this.ReporteE.Devuelta,
        extra: {
          code: 'dv'
        }
      };
      const ProcesoCotizacion = {
        name: 'En proceso de cotización',
        value: this.ReporteE.EnProcesoDeCotizacion,
        extra: {
          code: 'epc'
        }
      };
      const ProcesoFabricacion = {
        name: 'En proceso de fabricación',
        value: this.ReporteE.EnProcesoDeFabricacion,
        extra: {
          code: 'epf'
        }
      };
      const Entregada = {
        name: 'Entregada',
        value: this.ReporteE.Entregada,
        extra: {
          code: 'ent'
        }
      };
      const Modificada = {
        name: 'Modificada',
        value: this.ReporteE.Modificada,
        extra: {
          code: 'mdf'
        }
      };
      const Pagada = {
        name: 'Pagada',
        value: this.ReporteE.Pagada,
        extra: {
          code: 'pgd'
        }
      };
      const Rechazada = {
        name: 'Rechazada',
        value: this.ReporteE.Rechazada,
        extra: {
          code: 'rch'
        }
      };
      const Terminada = {
        name: 'Terminada',
        value: this.ReporteE.Terminada,
        extra: {
          code: 'ter'
        }
      };
      this.data = [...this.data, Cotizada, Aceptada, Cancelada, Devuelta,
        ProcesoCotizacion, ProcesoFabricacion, Entregada, Modificada, Pagada,
        Rechazada, Terminada];

    });
  }

  ngOnInit(): void {
    this.http.get(this.configuracion.rootURL +
      '/Reportes/Montajes/0001-01-01 00:00:00.0000000/0001-01-01 00:00:00.0000000').toPromise().then(res => {
      this.data = [];
      this.ReporteE = res as ReporteSPM;

      const Cotizada = {
        name: 'Cotizada',
        value: this.ReporteE.Cotizada,
        extra: {
          code: 'co'
        }
      };
      const Aceptada = {
        name: 'Aceptada',
        value: this.ReporteE.Aceptada,
        extra: {
          code: 'ac'
        }
      };
      const Cancelada = {
        name: 'Cancelada',
        value: this.ReporteE.Cancelada,
        extra: {
          code: 'cn'
        }
      };
      const Devuelta = {
        name: 'Devuelta',
        value: this.ReporteE.Devuelta,
        extra: {
          code: 'dv'
        }
      };
      const ProcesoCotizacion = {
        name: 'En proceso de cotización',
        value: this.ReporteE.EnProcesoDeCotizacion,
        extra: {
          code: 'epc'
        }
      };
      const ProcesoFabricacion = {
        name: 'En proceso de fabricación',
        value: this.ReporteE.EnProcesoDeFabricacion,
        extra: {
          code: 'epf'
        }
      };
      const Entregada = {
        name: 'Entregada',
        value: this.ReporteE.Entregada,
        extra: {
          code: 'ent'
        }
      };
      const Modificada = {
        name: 'Modificada',
        value: this.ReporteE.Modificada,
        extra: {
          code: 'mdf'
        }
      };
      const Pagada = {
        name: 'Pagada',
        value: this.ReporteE.Pagada,
        extra: {
          code: 'pgd'
        }
      };
      const Rechazada = {
        name: 'Rechazada',
        value: this.ReporteE.Rechazada,
        extra: {
          code: 'rch'
        }
      };
      const Terminada = {
        name: 'Terminada',
        value: this.ReporteE.Terminada,
        extra: {
          code: 'ter'
        }
      };
      this.data = [...this.data, Cotizada, Aceptada, Cancelada, Devuelta,
        ProcesoCotizacion, ProcesoFabricacion, Entregada, Modificada, Pagada,
        Rechazada, Terminada];

    });
    this.data = DATA_BAR_HORIZONTAL_CHAR;
  }

}
