import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Device } from '../models/device';

@Injectable()
export class DeviceService {
  constructor(private http: HttpClient) { }

  deviceUrl = 'device';

  getDeviceList() {
    return this.http.get(this.deviceUrl + '/devices').pipe(
      catchError(this.handleError)
    );
  }

  getDeviceById(id: string) {
    return this.http.get(this.deviceUrl + '?id=' + id).pipe(
      catchError(this.handleError)
    );
  }

  removeDevice(id: string) {
    return this.http.post(this.deviceUrl + '/remove?id=' + id, null, {})
      .pipe(
        catchError(this.handleError)
      );
  }

  updateOrAddDevice(device: Device) {
    return this.http.post(this.deviceUrl + '/updateoradd', device, {})
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }
}
