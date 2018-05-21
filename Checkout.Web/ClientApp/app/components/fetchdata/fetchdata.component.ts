import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public forecasts: null;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/v1.0/Cart').subscribe(result => {
            this.forecasts = result.json();
        }, error => console.error(error));
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
