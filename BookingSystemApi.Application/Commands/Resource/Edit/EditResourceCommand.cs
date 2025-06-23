using System.ComponentModel.DataAnnotations;

namespace BookingSystemApi.Application.Commands.Resource.Edit
{
    public class EditResourceCommand : IRequest
    {
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public decimal Price { get; set; }

    }
}
