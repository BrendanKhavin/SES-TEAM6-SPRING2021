import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NzButtonSize } from 'ng-zorro-antd/button';
@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.less'],
  encapsulation: ViewEncapsulation.None
})
export class HomepageComponent implements OnInit {
  constructor() { }
  banner = [
    {title: "Science", content:"UTS Science is research-driven, relevant, innovative and practical, achieving success and impact for its quality teaching and research."},
    {title: "Business", content: "UTS Business seeks to provide students with the knowledge, competencies and values necessary to develop critical, analytical and evaluative skills essential for a fulfilling and effective career in business."},
    {title: "Law", content: "UTS Law is a dynamic and innovative law school that has achieved great success for its quality of legal education and research."},
    {title: "Health", content:"We’re developing and supporting the health workforce of the future, through practical, relevant and research-inspired education."},
    {title: "IT", content: "UTS Information Technology produces graduates that are next-generation leaders with real-world intrapreneurship and digital transformation skills in new and emerging fields."},
    {title: "Engineering", content:"UTS Engineering graduates are next-generation leaders with real-world innovation and intrapreneurship skills in new and emerging fields."},
    {title: "Building", content:"The UTS Faculty of Design, Architecture and Building leads change: in urban spaces and living, in the understanding and application of design, and across the contemporary built environment."},
    {title: "Communication", content: "The UTS School of Communication has a global reputation for its dynamic, innovative and interdisciplinary academic programs in social science, communication and media."} 
  ]
  
 ngOnInit(): void {
  }

  gridStyle = {
    width: '25%',
    textAlign: 'center'
  };

 //array = [1, 2, 3];
}
