export interface IStudent {
    firstName: string
    lastName: string
    studentID: number
    email: string
    preferences: IStudentPreference[];
}

export interface IStudentPreference {
    name: string // should be in the format of is{PreferenceName} i.e. isAutumnSession
    value: boolean
}