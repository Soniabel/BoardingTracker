import { Component } from '@angular/core';

@Component({
  selector: 'app-top-recruiters',
  templateUrl: './top-recruiters.component.html',
  styleUrls: ['./top-recruiters.component.scss']
})
export class TopRecruitersComponent {

  recruiters = 
  [
    {
      profileImage: "../../assets/2nd.png",
      name: "Karina Ivanova",
    },
    {
      profileImage: "../../assets/1st.png",
      name: "Demid Shevchenko",
    },
    {
      profileImage: "../../assets/image-4.jpeg",
      name: "Nina Semenova",
    }
  ];
  constructor() { }
}
