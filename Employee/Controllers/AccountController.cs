using DataLayer;
using System.Web.Mvc;
using ViewModelLayers;

namespace Employee.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmployeeRepository _emp;
        private readonly EmployeeViewModel _EmployeeviewModel;

        public AccountController()
        {
            _emp = new EmployeeRepository(new ApplicationDBContext());
            _EmployeeviewModel = new EmployeeViewModel { Repository = _emp };
        }

        #region Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(EmployeeViewModel _vm)
        {
            if (ModelState.IsValid)
            {
                _vm.Repository = _emp;
                var user = _vm.CheckUserLogin(_vm.EmployeeLogin.EmployeeCode, _vm.EmployeeLogin.Password);

                if (user != null)
                {
                    TempData["Success"] = "Login Successfully...!";
                    Session["UserId"] = user.EmployeeId;
                    Session["EmployeeCode"] = user.EmployeeCode;
                    Session["IsAdmin"] = user.EmployeeId==1;

                    return RedirectToAction("EmployeeTask", "Master");
                }
                else
                {
                    TempData["Error"] = "Login Failed";
                }
            }

            return View();
        }
        #endregion

        #region Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction(nameof(Login));
        }
        #endregion
    }
}