using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting.Document
{
    [Authorize(Policy = "IsAdminOrBoardMemberPolicy")]
    public class DownloadModel : PageModel
    {
        private readonly IBffClient _bffClient;

        public DownloadModel(IBffClient bffClient)
        {
            _bffClient = bffClient;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var document = await _bffClient.GetDocumentAsync(id);
            byte[] newByte = Convert.FromBase64String(document.DocumentFile);
            if (document == null || document.DocumentFile == null || document.DocumentFile.Length == 0)
            {
                return NotFound(); // Filen blev ikke fundet eller er tom
            }

            return File(newByte, "application/octet-stream", document.Title + ".pdf");
        }
    }
}
