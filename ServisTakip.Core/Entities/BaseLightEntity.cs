namespace ServisTakip.Core.Entities
{
    public class BaseLightEntity : BaseLightEntity<long> { }
    public class BaseLightEntity<T> : IEntity
    {
        public virtual T Id { get; set; }
    }
}
