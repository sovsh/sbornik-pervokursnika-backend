namespace SbornikBackend.DTOs
{
    public class FacultyPostDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public DivisionType Type { get; set; }
        public string Info { get; set; }
        public string Picture { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteLink { get; set; }
        public string VkLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string SicLink { get; set; }
        public string Email { get; set; }
    }
}