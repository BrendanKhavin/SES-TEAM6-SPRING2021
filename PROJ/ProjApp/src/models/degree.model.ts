import { ISubject } from './subject.model';


export interface IDegree {
    degreeCode: string
    degreeName: string
    combinedDegree: boolean
    resultTypes: string[]
    courseArea: string
    majors: string
    subjectSample: ISubject[]
}

