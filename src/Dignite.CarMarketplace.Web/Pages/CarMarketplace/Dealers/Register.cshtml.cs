using Dignite.CarMarketplace.BlobStoring;
using Dignite.CarMarketplace.DealerPlatform.Dealers;
using Dignite.CarMarketplace.Dealers;
using Dignite.FileExplorer.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Content;

namespace Dignite.CarMarketplace.Web.Pages.Dealers
{
    public class RegisterModel : CarMarketplacePageModel
    {
        private readonly IDealerPlatformAppService _dealerAppService;
        private readonly IFileDescriptorAppService _fileDescriptorAppService;

        public RegisterModel(IDealerPlatformAppService dealerAppService, IFileDescriptorAppService fileDescriptorAppService)
        {
            _dealerAppService = dealerAppService;
            _fileDescriptorAppService = fileDescriptorAppService;
        }

        [BindProperty]
        public DealerCreateDto DealerCreateInput { get; set; }= new DealerCreateDto();

        [BindProperty]
        [Required]
        public IFormFile CoverPic { get; set; }

        public DealerDto CurrentDealer { get; set; }

        public virtual async Task<ActionResult> OnGetAsync()
        {
            CurrentDealer = await _dealerAppService.FindByCurrentUserAsync();

            if (CurrentDealer!=null && CurrentDealer.AuthenticationStatus == AuthenticationStatus.Approved)
            {
                //跳转到二手车商平台，该平台使用angular开发
                return Redirect("/dealer-platform");
            }
            else
                return Page();
        }

        public virtual async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var dealer = await _dealerAppService.CreateAsync(DealerCreateInput);

            using (var stream = new MemoryStream(CoverPic.GetAllBytes()))
            {
                await _fileDescriptorAppService.CreateAsync(
                    new CreateFileInput()
                    {
                        ContainerName = BlobContainerConsts.DealerCoverContainerName,
                        File = new RemoteStreamContent(
                                                    stream,
                                                    CoverPic.FileName,
                                                    CoverPic.ContentType
                                                    )
                    });
            }

            return RedirectToPage("Register");
        }
    }
}
