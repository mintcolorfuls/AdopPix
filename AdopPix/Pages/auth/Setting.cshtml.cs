using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdopPix.Pages.auth
{
    [Authorize]
    public class SettingModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
