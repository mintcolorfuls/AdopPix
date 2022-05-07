using AdopPix.Models;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QRCoder;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace AdopPix.Pages.auth
{
    public class MFASetupModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly INavbarService navbarService;

        public MFASetupModel(UserManager<User> userManager, INavbarService navbarService)
        {
            this.userManager = userManager;
            this.navbarService = navbarService;
            mFASetupViewModel = new MFASetupViewModel();
        }

        [BindProperty]
        public MFASetupViewModel mFASetupViewModel { get; set; }
        [BindProperty]
        public bool Succeeded { get; set; }

        public async Task OnGetAsync()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            var user = await userManager.FindByNameAsync(User.Identity.Name);
      
            if (user != null)
            {
                var a = user.TwoFactorEnabled;
                if (a)
                {
                    Succeeded = true;
                }
                else
                {
                    await userManager.ResetAuthenticatorKeyAsync(user);
                    var key = await userManager.GetAuthenticatorKeyAsync(user);

                    mFASetupViewModel.Key = key;
                    mFASetupViewModel.QRCodeBytes = GenerateQRCodeByte("AdopPix", key, user.Email);
                }
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid) return Page();

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var resultVerify = await userManager.VerifyTwoFactorTokenAsync(user,
                                                                           userManager.Options.Tokens.AuthenticatorTokenProvider,
                                                                           mFASetupViewModel.SecurityCode);
            if(resultVerify)
            {
                await userManager.SetTwoFactorEnabledAsync(user, true);
                Succeeded = true;
            }
            else
            {
                ViewData["ErrorMessage"] = "Some went wrong with authenticator setup.";
            }
            return Page();
        }
        private byte[] GenerateQRCodeByte(string provider, string key, string userEmail)
        {
            var qrCodeGenerater = new QRCodeGenerator();
            var qrCodeData = qrCodeGenerater.CreateQrCode(
                $"otpauth://totp/{provider}:{userEmail}?secret={key}&issuer={provider}",
                QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);

            return BitmapToByteArray(qrCodeImage);
        }
        private byte[] BitmapToByteArray(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
    public class MFASetupViewModel
    {
        public string Key { get; set; }
        [Required]
        public string SecurityCode { get; set; }
        public byte[] QRCodeBytes { get; set; }
    }
}
