namespace CORE.Entities.Abstarct
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public interface IEntity
    {
    }
}