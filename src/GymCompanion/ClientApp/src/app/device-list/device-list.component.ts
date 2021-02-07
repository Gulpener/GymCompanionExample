import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { DeviceService } from '../services/device-service';
import { Router } from '@angular/router';
import { Device } from '../models/device';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html'
})
export class DeviceListComponent implements OnInit {

  public devices: Device[];

  constructor(private deviceService: DeviceService, private router: Router) {  }

  ngOnInit(): void {
    this.loadDevices();
  }

  onRemoveClicked(device: Device) {
    this.deviceService
      .removeDevice(device.id)
      .subscribe(_ => this.loadDevices());
  }

  onEditClicked(device: Device) {
    this.router.navigate(['device-edit', { id: device.id }]);
  }

  onAddClicked(device: Device) {
    this.router.navigate(['device-add']);
  }

  loadDevices() {
    this.deviceService.getDeviceList()
      .subscribe((result: Device[]) => {
        this.devices = result;
      }, error => console.error(error));
  }
}
