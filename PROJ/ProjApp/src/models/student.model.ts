import { IStudentDegree } from "./studentDegree.model";

export interface IStudent {
    firstName: string
    lastName: string
    studentId: string
    email: string
    preferences: IStudentPreferences[]
    degree: IStudentDegree[]
}

export interface IStudentPreferences {
    studentId: string;
    groupwork: boolean
    essays: boolean
    presentations: boolean
    exams: boolean
    interests: string[]
}


export interface IStudentDegree {
    studentId: string
    degreeCode: string;
    degreeName: string;
    major: string;
  }
