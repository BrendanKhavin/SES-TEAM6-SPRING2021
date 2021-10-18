export interface ISubject {
    courseArea: string
    subjectCode: string
    subjectName: string
    creditPoints: number
    resultTypes: string[]
    requisites: ISubject[]
    description: string
    topics: string[]
    studentLearningOutcomes: string[]
    courseIntendedLearningOutcome: string[]
    assessmentTasks: IAssessmentTask[]
    availability: string[]
    isVisible: boolean
}

export interface IAssessmentTask {
    type: string
    isIndividual: boolean
    weight: string
}
