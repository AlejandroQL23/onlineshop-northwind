using Microsoft.AspNetCore.Mvc;
using ShopOnline.Northwind.MvcWebUI.Models;
using System.Threading.Tasks;

namespace ShopOnline.Northwind.MvcWebUI.ViewComponents
{
    public class UserSummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userDetailsViewModel = new UserDetailsViewModel
            {
                UserName = HttpContext.User.Identity.Name
            };

            return await Task.Run(() => View(userDetailsViewModel));
        }
    }
}
