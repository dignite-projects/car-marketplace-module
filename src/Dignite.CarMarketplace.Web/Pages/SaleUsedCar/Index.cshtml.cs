using Dignite.CarMarketplace.Public.Cars;
using Dignite.CarMarketplace.Public.UsedCars;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Dignite.CarMarketplace.Web.Pages.SaleUsedCar
{
    public class IndexModel : CarMarketplacePageModel
    {
        private readonly ISaleUsedCarAppService _saleCarAppService;
        private readonly IBrandAppService _brandAppService;

        public IndexModel(ISaleUsedCarAppService saleCarAppService,IBrandAppService brandAppService)
        {
            _saleCarAppService = saleCarAppService;
            _brandAppService = brandAppService;
        }

        [BindProperty]
        public SaleCarCreateViewModel SaleCar { get; set; } = new SaleCarCreateViewModel();

        [BindProperty( SupportsGet = true)]
        public bool IsCompleted { get; set; }

        public IReadOnlyList<BrandDto> AllBrands { get; set; }

        public virtual async Task<ActionResult> OnGetAsync()
        {
            AllBrands = (await _brandAppService.GetListAsync()).Items;
            return Page();
        }

        public virtual async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                AllBrands = (await _brandAppService.GetListAsync()).Items;
                IsCompleted = false;
                return Page();
            }

            var saleCar = await _saleCarAppService.CreateAsync(SaleCar);

            return RedirectToPage("/SaleUsedCar/Index", new {IsCompleted=true });
        }
    }

    public class SaleCarCreateViewModel : SaleCarCreateDto
    {
        public SaleCarCreateViewModel()
        {
            base.RegistrationDate = DateTime.Now;
        }

        [Required]
        public Guid BrandId { get; set; }
    }
}
