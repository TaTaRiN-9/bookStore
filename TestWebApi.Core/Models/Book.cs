namespace TestWebApi.Core.Models
{
    // это доменная модель, соответственно модель не имеет сеттеров. 
    // Небольшая инкапсуляция
    public class Book
    {
        public const int MAX_LENGTH_TITLE = 200;
        // при помощи конструктора будем задавать данные
        private Book(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
        }

        private Book(int id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }

        public int Id { get; set; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        public int GenreId { get; set; }

        // validation
        public static (Book book, string error) Create(string title, string description, decimal price)
        {
            // Почему не выбрасываем исключение?
            // Чтобы не терять производительность
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_LENGTH_TITLE)
            {
                error = "Title can not be empty or longer than 250 symbols";
            }

            Book book = new Book(title, description, price);

            return (book, error);
        }

        public static (Book book, string error) Create(int id, string title, string description, decimal price)
        {
            var error = string.Empty;
            Book book = new Book(id, title, description, price);

            return (book, error);
        }
    }
}
