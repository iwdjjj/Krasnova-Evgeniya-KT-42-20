namespace KrasnovaEV_KT_42_20.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int? GradeNumber { get; set; }
        public DateTime? GradeDate { get; set; }

        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }

        public int? StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
