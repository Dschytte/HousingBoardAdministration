namespace BookingSystemApi.Domain.Entities;

public class BookingEntity : BaseEntity
{
    //EF purpose only
    public BookingEntity()
    {
    }
    public void Edit(DateTime startdate, DateTime endtime)
    {

        StartDate = startdate;
        EndDate = endtime;

    }

    public BookingEntity(List<ResourceEntity> resources, DateTime startDate, DateTime endDate)
    {

        Resources = resources;
        StartDate = startDate;
        EndDate = endDate;
    }
    public ResidentEntity BookingOwner { get; set; }
    public List<ResourceEntity> Resources { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
