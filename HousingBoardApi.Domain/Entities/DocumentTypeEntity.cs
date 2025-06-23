namespace HousingBoardApi.Domain.Entities;

public class DocumentTypeEntity : BaseEntity
{
    public DocumentTypeEntity()
    {
    }

    public string Type { get; set; }
    //public ICollection<DocumentEntity>? Documents { get; set; }
}