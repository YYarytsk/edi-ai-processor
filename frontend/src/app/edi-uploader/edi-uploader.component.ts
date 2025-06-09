
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-edi-uploader',
  templateUrl: './edi-uploader.component.html'
})
export class EdiUploaderComponent {
  selectedFile!: File;
  segments: string[] = [];

  constructor(private http: HttpClient) {}

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  uploadFile() {
    const formData = new FormData();
    formData.append('file', this.selectedFile);

    this.http.post<any>('https://localhost:5001/api/EDI/upload', formData)
      .subscribe(response => {
        this.segments = response.segments;
      });
  }
}
