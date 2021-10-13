import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-recommendation',
  templateUrl: './recommendation.component.html',
  styleUrls: ['./recommendation.component.less']
})

export class RecommendationComponent implements OnInit {
  faculties = ['Engineering','Law','Medicine','Science','Architecture','Design'];
  selectedFaculties = [];
  creditPoints = [3,6,9,12,18,24];
  selectedCreditPoints = [];
  loading = true;
  searchValue = '';
  cards = [
    { id: 0, subjectCode: "41092", subjectName: "Network Fundementals", creditPoints: 6, description: "Today's internet is arguably the largest engineered system ever created by humanity, carrying petabytes of data every minute. It is important for data engineers to understand how data is transferred through the internet, and the guiding principles and structures of data transportation designs. This subject provides students with a modern introduction to the dynamic field of computer networking, including layered network architecture and the TCP/ IP protocol suite.Student practical works include observing network traffic in action and building their own network applications through socket programming.Students also have hands - on opportunities to build their own networks using Cisco network equipment. By developing problem - solving and design skills in this subject, students also acquire the ability to select the most appropriate network services, and design and develop network applications, e.g.web server and client, to achieve the best data performance.", courseArea: "Engineering", isVisible:false},
    { id: 1, subjectCode: "48430", subjectName: "Fundamentals of C Programming", creditPoints: 6, description: "Data engineers use C programming language to collect, process and store data", courseArea: "Engineering", isVisible: false},
    { id: 2, subjectCode: "48240", subjectName: "Design and Innovation Fundamentals", creditPoints: 6, description: "Design and innovation are explored as fundamental engineering activities through a contextualised, authentic project.", courseArea: "Engineering", isVisible: false},
    { id: 3, subjectCode: "48433", subjectName: "Software Architecture", creditPoints: 6, description: "This subject teaches students current industry practices to design", courseArea: "Engineering", isVisible: false}
  ]

  constructor() { }

  showModal(card: { isVisible: boolean; }): void {
    card.isVisible = true;
  }

  handleOk(card: { isVisible: boolean; }): void {
    card.isVisible = false;
  }

  handleCancel(card: { isVisible: boolean; }): void {
    card.isVisible = false;
  }

  handleRate(card: { id: any; }): void {
    //will have it redirect to the ratings page
  }

  ngOnInit(): void {
  }
}

