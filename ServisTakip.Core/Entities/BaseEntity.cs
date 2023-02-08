namespace ServisTakip.Core.Entities
{
    public class BaseEntity : BaseEntity<long> { }
    public class BaseEntity<T> : IEntity
    {
        public virtual T Id { get; set; }
        public virtual string RecordUsername { get; set; }
        public virtual DateTime RecordDate { get; set; }
        public virtual string UpdateUsername { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual string Ip { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
