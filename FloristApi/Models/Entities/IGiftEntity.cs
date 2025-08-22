namespace FloristApi.Models.Entities
{
    public interface IGiftEntity
    {
        int Id { get; set; }
        string Name { get; set; }
        string ImageUrl { get; set; }
        int Price { get; set; }
    }
}
