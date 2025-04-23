namespace KuzminDaniil_kt_41_22
{
    public class Teacher
    {
        public int idTeacher { get; set; }

        public string? SurnameTeacher { get; set;}

        public string? NameTeacher { get; set; }

        public string? SecsurnameTeacher { get;set; }
        public int? idCafedra { get; set; }

        public Cafedra Cafedra { get; set;} 
    }
}