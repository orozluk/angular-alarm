import { Component } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-alarm',
  template: `
    <p>{{ alarmStatus }}</p>
  `,
})
export class AlarmComponent {
  private connection: signalR.HubConnection;
  alarmStatus = 'Alarma OFF';

  constructor() {

    this.connection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5057/alarm-hub')
      .configureLogging(signalR.LogLevel.Debug)
      .build();

    this.connection.on('alarmStateChanged', (status: string) => {
      if(status == "on"){
        this.alarmStatus = "Alarm ON";
      }
      else {
        this.alarmStatus = "Alarm OFF";
      }
    });

    this.connection.start();
  }
}
