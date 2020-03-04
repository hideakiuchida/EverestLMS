import { Component, ViewChild, TemplateRef, ChangeDetectionStrategy, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { startOfDay, endOfDay, subDays, addDays, endOfMonth, isSameDay, isSameMonth, addHours } from 'date-fns';
import { Subject } from 'rxjs';
import { CalendarEvent, CalendarEventAction, CalendarEventTimesChangedEvent, CalendarView, CalendarDateFormatter } from 'angular-calendar';
import { Evento } from 'src/app/models/evento';
import { DatePipe } from '@angular/common';
import { Calendario } from 'src/app/models/calendario';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { CalendarioService } from 'src/app/services/calendario/calendario.service';
import { CriterioAceptacion } from 'src/app/models/criterioaceptacion';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';

@Component({
  selector: 'app-calendario',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './calendario.component.html',
  styleUrls: ['./calendario.component.css']
})
export class CalendarioComponent implements OnInit {
  @ViewChild('modalContent') modalContent: TemplateRef<any>;
  view: CalendarView = CalendarView.Month;
  CalendarView = CalendarView;
  viewDate: Date = new Date();
  activeDayIsOpen: any = true;
  events: CalendarEvent[] = [];
  eventos: Evento[] = [];
  locale = 'es';
  refresh: Subject<any> = new Subject();

  calendarios: Calendario[];
  criteriosAceptacion: CriterioAceptacion[];
  selectedCalendario: Calendario;
  selectedCalendarioId: any;
  selectedFechaInicio: any;
  selectedFechaFinal: any;

  actions: CalendarEventAction[] = [
    /*{
      label: '<i class="fa fa-fw fa-pencil"></i>',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('Edited', event);
      }
    },*/
    {
      label: '<i class="fa fa-fw fa-times"></i>',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.deleteEvent(event);
        this.handleEvent('Deleted', event);
      }
    }
  ];

  constructor(private calendarioService: CalendarioService, private alertifyService: AlertifyService,
              private datePipe: DatePipe, private spinner: NgxSpinnerService, private router: Router) {
  }

  ngOnInit() {
    this.loadCalendarios();
  }

  loadCalendarios() {
    this.spinner.show();
    this.calendarioService.getCalendarios().subscribe((calendarios: Calendario[]) => {
      this.calendarios = calendarios;
      if (this.calendarios != null && this.calendarios.length > 0) {
        var currentDate = new Date();
        const calendario = this.calendarios.filter(x => new Date(x.fechaInicio) <= currentDate && new Date(x.fechaFinal) >= currentDate)[0];
        if (calendario != null) {
          this.selectedCalendarioId = calendario.id;
          this.loadEventos(this.selectedCalendarioId);
          this.loadCriteriosAceptacion(this.selectedCalendarioId);
          this.calendarioSelected(this.selectedCalendarioId);
        }
      }
    }, error => {
      this.alertifyService.error(error.error);
    }, () => {
      this.spinner.hide();
    });
  }

  loadCriteriosAceptacion(idCalendario) {
    this.spinner.show();
    this.calendarioService.getCriteriosAceptacion(idCalendario).subscribe((criteriosAceptacion: CriterioAceptacion[]) => {
      this.criteriosAceptacion = criteriosAceptacion;
    }, error => {
      this.alertifyService.error(error.error);
    }, () => {
      this.spinner.hide();
    });
  }

  eliminarCriterioAceptacionEmitter(isEliminado: boolean) {
    if (isEliminado) {
      this.loadCriteriosAceptacion(this.selectedCalendarioId);
      this.router.navigate(['/calendario']);
    }
  }

  calendarioSelected(value) {
    this.selectedCalendario = this.calendarios.find(item => item.id === Number(value));
    this.selectedFechaInicio = this.datePipe.transform(this.selectedCalendario.fechaInicio, 'dd/MM/yyyy');
    this.selectedFechaFinal = this.datePipe.transform(this.selectedCalendario.fechaFinal, 'dd/MM/yyyy');
  }

  loadEventos(idCalendario) {
    this.spinner.show();
    this.calendarioService.getEventos(idCalendario).subscribe((eventos: Evento[]) => {
      this.eventos = eventos;
      this.mapEventosToCalendarEvents(this.eventos);
    }, error => {
      this.alertifyService.error(error.error);
    }, () => {
      this.spinner.hide();
    });
  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if ((isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) || events.length === 0) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
        this.viewDate = date;
      }
    }
  }

  eventTimesChanged({ event, newStart, newEnd }: CalendarEventTimesChangedEvent): void {
    event.start = newStart;
    event.end = newEnd;
    this.handleEvent('Dropped or resized', event);
    this.refresh.next();
  }

  handleEvent(action: string, event: CalendarEvent): void {
    console.log(action);
    console.log(event);
    const evento = this.eventos.find(item => item.id === event.id);
    console.log(evento);
  }

  deleteEvent(eventToDelete: CalendarEvent) {
    this.calendarioService.deleteEvento(this.selectedCalendarioId, eventToDelete.id).subscribe((isDeleted: boolean) => {
      if (isDeleted) {
        this.alertifyService.success('Se eliminó el evento.');
        this.loadEventos(this.selectedCalendarioId);
      } else {
        this.alertifyService.warning('No se puedo eliminar el evento.');
      }
    }, error =>  {
      this.alertifyService.error(error.error);
    });
  }

  setView(view: CalendarView) {
    this.view = view;
  }

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }

  mapEventosToCalendarEvents(eventos: Evento[]) {
    this.events = [];
    for (const evento of eventos) {
      this.events.push({
        id: evento.id,
        title: evento.titulo.toString(),
        start: new Date(evento.fechaInicio),
        end: new Date(evento.fechaFinal),
        color: {primary: evento.colorPrimario.toString(),
          secondary: evento.colorSecundario.toString()},
        resizable: {
          beforeStart: true,
          afterEnd: true
        },
        actions: this.actions
      });
    }
    this.refresh.next();
  }
}
