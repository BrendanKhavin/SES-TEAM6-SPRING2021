export interface ICompletedSubjects {

  UserId: string
  SubjectId: string
  Score: number

  /**
   * Use in processing completed subjects. Return value does not use
   * the same naming convention, so adding optional properties to
   * this interface. It is the easiest backwards-compatible solution.
   */
  subjectCode?: string
}
