using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxCalculator.Models;
using Newtonsoft.Json;

namespace TaxCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private static readonly int BasicSalary = 1490;
        private static readonly int ReducePersonal = 11000;
        private static readonly int DepenentInPerson = 4400;

        [BindProperty]
        public TaxModel? Tax { get; set; }
        public int? SalaryBeforeTax { get; set; }
        public int? SalaryAfterTax { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int? salaryBeforeTax, int? salaryAfterTax)
        {
            if (salaryBeforeTax != null)
            {
                SalaryBeforeTax = salaryBeforeTax;
            }
            if (salaryAfterTax != null)
            {
                SalaryAfterTax = salaryAfterTax;
            }
            if (TempData["TaxModel"] != null)
            {
                Tax = JsonConvert.DeserializeObject<TaxModel>(TempData["TaxModel"].ToString());
            }
        }
        public IActionResult OnPost(TaxModel model)
        {
            try
            {
                model = Tax;
                if (model?.SalaryInsurance == null) model.SalaryInsurance = SalaryInsuranceType.OfficalSalary;
                if (model?.Area == null) model.Area = AreaType.I;
                TempData["SalaryBeforeTax"] = 10000;
                TempData["SalaryAfterTax"] = 29000;
                TempData["TaxModel"] = JsonConvert.SerializeObject(model);
                return RedirectToPage(new { salaryBeforeTax = TempData["SalaryBeforeTax"] , salaryAfterTax = TempData["SalaryAfterTax"] });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}