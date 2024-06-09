namespace TestWebApi.Core.Models
{
    public class Genre
    {
        private Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static Genre Create(int id, string name)
        {
            Genre genre = new Genre(id, name);

            return genre;
        }
    }
}
