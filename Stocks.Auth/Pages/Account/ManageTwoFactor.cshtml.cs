using System.Threading.Tasks;
using Stocks.Auth.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Stocks.Auth.UI.Account
{
    public class ManageTwoFactorModel : PageModel
    {
        private const string AuthenicatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}";

        private readonly UserManager<StocksUser> _userManager;
        private readonly SignInManager<StocksUser> _signInManager;
        private readonly ILogger<ManageTwoFactorModel> _logger;

        public ManageTwoFactorModel(
            UserManager<StocksUser> userManager,
            SignInManager<StocksUser> signInManager,
            ILogger<ManageTwoFactorModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public bool HasAuthenticator { get; set; }

        public int RecoveryCodesLeft { get; set; }

        [BindProperty] public bool IsTwoFactorEnabled { get; set; }

        public bool IsMachineRemembered { get; set; }

        [TempData] public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            HasAuthenticator = await _userManager.GetAuthenticatorKeyAsync(user) != null;
            IsTwoFactorEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
            IsMachineRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(user);
            RecoveryCodesLeft = await _userManager.CountRecoveryCodesAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await _signInManager.ForgetTwoFactorClientAsync();
            StatusMessage =
                "The current browser has been forgotten. When you login again from this browser you will be prompted for your 2fa code.";
            return RedirectToPage();
        }
    }
}