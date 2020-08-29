using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopOnline.Northwind.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class BaseAdminController : Controller
    {
    }
}
