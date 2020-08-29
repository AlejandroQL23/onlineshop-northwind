using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Northwind.MvcWebUI.StringInfos;

namespace ShopOnline.Northwind.MvcWebUI.Areas.Admin.Controllers
{
    [Area(Role.ADMIN)]
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = Role.ADMIN)]
    public class BaseAdminController : Controller
    {
    }
}
