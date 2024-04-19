using FlightFinder.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FlightFinder.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IApiService _apiService;

        public IndexModel(ILogger<IndexModel> logger, IApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        #region Properties

        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input string is required")]
        [Display(Name = "Enter your string: ")]
        public string? Input { get; set; }
        [BindProperty]
        [Display(Name = "Result: ")]
        public string? Output { get; set; }

        #endregion

        public async Task<IActionResult> OnPost()
        {
            if (string.IsNullOrWhiteSpace(Input))
                return Page();

            try
            {
                _logger.LogInformation("Posting input string \"{Input}\" to API...", Input);
                var responseString = await _apiService.GetCount(Input);

                if (!string.IsNullOrWhiteSpace(responseString))
                {
                    Output = responseString;
                }

                _logger.LogInformation("Instances of \"flight\" in input: {Output}", Output);

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError("{error}: {stacktrace}", ex.Message, ex.StackTrace);
                return RedirectToPage("./Error");
            }
        }
    }
}