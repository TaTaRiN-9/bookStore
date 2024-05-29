namespace TestWebApi.DataAccess.Entities
{
    // модель корзины в магазине
    public class BasketEntity
    {
        public int Id { get; set; }
        public string EmailUser { get; set; } = null!;
        public string ListBook { get; set; } = null!;
    }
}
