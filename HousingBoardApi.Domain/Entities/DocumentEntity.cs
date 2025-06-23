using System.ComponentModel.DataAnnotations;

namespace HousingBoardApi.Domain.Entities;

public class DocumentEntity : BaseEntity
{
    public DocumentEntity()
    {
    }

    public DocumentEntity(string title, DocumentTypeEntity documentType, byte[] documentFile, DateTime uploadDate, BoardMemberEntity documentOwner)
    {
        Title = title;
        DocumentType = documentType;
        DocumentFile = documentFile;
        UploadDate = uploadDate;
        //Meeting = meeting;
        DocumentOwner = documentOwner;
    }

    public string Title { get; set; }
    public DocumentTypeEntity DocumentType { get; set; }
    public byte[] DocumentFile { get; set; }
    public DateTime UploadDate { get; set; }
    [Required]
    public MeetingEntity? Meeting { get; set; }
    [Required]
    public BoardMemberEntity? DocumentOwner { get; set; }

    public void Edit(string title, byte[] rowVersion)
    {
        this.Title = title;
        this.RowVersion = rowVersion;
    }
}