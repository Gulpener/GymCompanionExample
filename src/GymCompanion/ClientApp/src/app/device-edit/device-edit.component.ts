import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { DeviceService } from '../services/device-service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Device } from '../models/device';

@Component({
  selector: 'app-device-edit',
  templateUrl: './device-edit.component.html'
})
export class DeviceEditComponent implements OnInit {

  public device: Device;

  constructor(
    private deviceService: DeviceService,
    private router: Router,
    private route: ActivatedRoute) {

  }
  ngOnInit(): void {
    if (this.route.snapshot.params.id) {
      this.loadDevice(this.route.snapshot.params.id);
    }
    else {
      this.device = { name: "", id: undefined, functionCollection: undefined };
    }
  }

  loadDevice(id: string) {
    this.deviceService.getDeviceById(id)
      .subscribe((result: Device) => {
        this.device = result;
        console.log(result.functionCollection);
      }, error => console.error(error));
  }

  onSubmit(f: NgForm) {
    console.log(f.value);
    this.device.name = f.value.name;
    this.deviceService
      .updateOrAddDevice(this.device)
      .subscribe(_ => this.router.navigate(['device-list']));
  }

  onAddFunctionClicked() {
    console.log('AddFunctionClicked');
  }
}


