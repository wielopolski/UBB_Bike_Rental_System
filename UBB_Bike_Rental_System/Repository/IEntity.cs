namespace UBB_Bike_Rental_System.Repository;

public interface IEntity<T>
{
    public T Id { get; set; }
}
