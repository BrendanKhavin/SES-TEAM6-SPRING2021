export interface ISubject {
    courseArea: string
    code: string
    name: string
    creditPoint: number
    resultTypes: string[]
    requisites: ISubject[]
    description: string
    topics: string[]
    studentLearningOutcomes: string[]
    courseIntendedLearningOutcome: string[]
    assessmentTasks: IAssessmentTask[]
    availability: string[]
}

export interface IAssessmentTask {
    type: string
    isIndividual: boolean
    weight: string
}