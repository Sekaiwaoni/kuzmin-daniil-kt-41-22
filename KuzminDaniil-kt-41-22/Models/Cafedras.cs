namespace KuzminDaniil_kt_41_22
{
    public class Cafedra
    {
        public int idCafedra { get; set; }


        public string? NameCafedra { get; set; }

        public string? ZavCafName { get; set; }
        public int? idZavCaf { get; set; }

        public bool isZavCaf { get; set; }
        public DateOnly? FoudationDate { get; set; }

        public Teacher ZavCaf { get; set; }
    }
}