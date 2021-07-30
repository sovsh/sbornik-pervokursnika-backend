namespace SbornikBackend
{
    public class DeaneryTypeRelation
    {
        public int Id { get; set; }
        public DivisionType Type { get; set; }
        public string DivisionName { get; set; }
        public string DeaneryName { get; set; }
    }
}