import { Injectable } from "@angular/core";
import * as signalR from "@aspnet/signalr";

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  hubConnection: signalR.HubConnection | undefined;

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7232/notificationHub')
      .build();

    this.hubConnection.on("ReceiveNotification", function (user) {
      // Update the table view here with the new data
      console.log("ReceiveNotification ==> ", user);
    });

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch((err: any) => console.log('Error while starting connection: ' + err))
  }
}
