using DataLayer;
using System.Web.Mvc;
using ViewModelLayers;

namespace Employee.Controllers
{
    public class MasterController : BaseController
    {
        private readonly IEmployeeRepository _emp;
    
        private readonly EmployeeViewModel _EmployeeviewModel;

        private readonly IEmployeeTaskRepository _emptask;

        private readonly EmployeeTaskViewModel _EmployeeTaskviewModel;
        public MasterController()
        {
            _emp = new EmployeeRepository(new ApplicationDBContext());
            _EmployeeviewModel = new EmployeeViewModel { Repository = _emp };
            _emptask = new EmployeeTaskRepository(new ApplicationDBContext());
            _EmployeeTaskviewModel = new EmployeeTaskViewModel { Repository = _emptask ,EmployeeRepository=_emp};
        }

        #region Employee
        public ActionResult Employee()
        {
            _EmployeeviewModel.LoadEmployees();
            return View(_EmployeeviewModel);
        }

        public ActionResult AddEmployee(string employeeCode)
        {
            if (!string.IsNullOrEmpty(employeeCode))
            {
                _EmployeeviewModel.LoadEmployee(employeeCode);
            }
            else
            {
                _EmployeeviewModel.CreateEmptyEmployee();
            }

            return View(_EmployeeviewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(EmployeeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Repository = _emp;
                bool isUpdate = vm.SaveOrUpdate();
                string status = isUpdate ? "Update" : "Create";
                TempData["Success"] = "Employee "+ status + "d Successfully..!";

                return RedirectToAction(nameof(Employee));
            }

            return View(vm);
        }

        public ActionResult Delete(int employeeid)
        {
            bool isSuccess = _EmployeeviewModel.DeleteEmployee(employeeid);
            string status = isSuccess ? "Delete" : "Not-Delete";
            string msgtype = isSuccess ? "Success" : "Error";
            TempData[msgtype] = "Employee " + status + "d Successfully..!";

            return RedirectToAction(nameof(Employee));
        }
        #endregion
        #region EmployeeTask
        public ActionResult EmployeeTask()
        {
            if (Session["IsAdmin"].ToString() == "True")
            {
                _EmployeeTaskviewModel.LoadEmployeeTasks();
            }
            else
            {
                _EmployeeTaskviewModel.LoadEmployeewiseTask(Session["EmployeeCode"].ToString());
            }

            return View(_EmployeeTaskviewModel);
        }

        public ActionResult AddEmployeeTask(string EmployeeTaskCode)
        {
            if (!string.IsNullOrEmpty(EmployeeTaskCode))
            {

                _EmployeeTaskviewModel.LoadEmployeeTask(EmployeeTaskCode);
            }
            else
            {
                _EmployeeTaskviewModel.CreateEmptyEmployeeTask();
            }

            return View(_EmployeeTaskviewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployeeTask(EmployeeTaskViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Repository = _emptask;
                
                bool isUpdate = vm.SaveOrUpdate();
                string status = isUpdate ? "Update" : "Create";
                TempData["Success"] = "EmployeeTask " + status + "d Successfully..!";

                return RedirectToAction(nameof(EmployeeTask));
            }

            return View(vm);
        }

        public ActionResult DeleteEmployeTask(int EmployeeTaskid)
        {
            bool isSuccess = _EmployeeTaskviewModel.DeleteEmployeeTask(EmployeeTaskid);
            string status = isSuccess ? "Delete" : "Not-Delete";
            string msgtype = isSuccess ? "Success" : "Error";
            TempData[msgtype] = "EmployeeTask " + status + "d Successfully..!";

            return RedirectToAction(nameof(EmployeeTask));
        }
        #endregion


    }
}
