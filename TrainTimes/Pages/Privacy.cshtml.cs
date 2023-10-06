using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrainTimes.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        //HW added read property as per SonarQube Issue L8

        public ILogger<PrivacyModel> Logger
        {
            get
            {
                return _logger;
            }
        }

        public void OnGet()
        {
            // HW not used as this page is redundant
        }
    }
}