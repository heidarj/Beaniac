namespace Beaniac.Shared.Models
{
    public interface IDisplayItem
    {
        public Guid? Id { get; }
        public ICollection<string>? ImageUrl { get; }
        public string Name { get; }
    }
}