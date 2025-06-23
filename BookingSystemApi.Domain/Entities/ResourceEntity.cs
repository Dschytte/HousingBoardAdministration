using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystemApi.Domain.Entities;

public class ResourceEntity : BaseEntity
{
    //EF purpose only
    public ResourceEntity() { }
    public ResourceEntity(string description, string specification, decimal price)
    {
        //Check pre-condition

        //Logic

        //Post-condition

        this.Description = description;
        this.Specification = specification;
        this.Price = price;
    }

    public List<BookingEntity>? Bookings { get; set; }
    public string Description { get; set; }
    public string Specification { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public void Edit(string description, string specification, decimal price, byte[] RowVersion)
    {
        this.Description = description;
        this.Specification = specification;
        this.Price = price;
        this.RowVersion = RowVersion;
    }

}
