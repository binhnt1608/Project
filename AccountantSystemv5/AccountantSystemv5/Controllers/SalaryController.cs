using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountantSystemv5.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountantSystemv5.Controllers
{
    public class SalaryController : Controller
    {
        private readonly AccountantSystemv5Context _context;
        public SalaryController(AccountantSystemv5Context context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var query = from c in _context.Employee
                        join d in _context.LaborAcquisition on c.EmployeeID equals d.EmployeeID
                        select new Salary
                        {
                            Employee = c,
                            LaborAcquisition = d,
                            //EmployeeID = c.EmployeeID,
                            //TimeCardID = d.TimeCardID,
                            //LAPayPeriodEnded = d.LAPayPeriodEnded,
                            //EmPayRate = c.EmPayRate,
                            //LARegularTime = d.LARegularTime,
                            //LAOvertime = d.LAOvertime,
                            FWT = ((c.EmPayRate * d.LARegularTime) + (c.EmPayRate * (decimal)1.5 * d.LAOvertime)) * (c.Withholding.FWTRate / (decimal)1000),
                            RegularPay = c.EmPayRate * d.LARegularTime,
                            OverTimePay = c.EmPayRate * (decimal)1.5 * d.LAOvertime,
                            GrossPay = (c.EmPayRate * d.LARegularTime) + (c.EmPayRate * (decimal)1.5 * d.LAOvertime),
                            GrossLessExemption = ((c.EmPayRate * d.LARegularTime) + (c.EmPayRate * (decimal)1.5 * d.LAOvertime)) - c.Exemptions.ExemptionAmount,
                            FICA = ((c.EmPayRate * d.LARegularTime) + (c.EmPayRate * (decimal)1.5 * d.LAOvertime)) * (decimal)0.062,
                            Medicare = ((c.EmPayRate * d.LARegularTime) + (c.EmPayRate * (decimal)1.5 * d.LAOvertime)) * (decimal)0.0145,
                            NetPay = ((c.EmPayRate * d.LARegularTime) + (c.EmPayRate * (decimal)1.5 * d.LAOvertime)) 
                                        - (((c.EmPayRate * d.LARegularTime) + (c.EmPayRate * (decimal)1.5 * d.LAOvertime)) * (decimal)0.062) 
                                        -(((c.EmPayRate * d.LARegularTime) + (c.EmPayRate * (decimal)1.5 * d.LAOvertime)) * (decimal)0.0145)
                                        -(((c.EmPayRate * d.LARegularTime) + (c.EmPayRate * (decimal)1.5 * d.LAOvertime)) * (c.Withholding.FWTRate / (decimal)1000))
                        };
            
           // ViewBag.query = query;
            return View(query);
        }
      
    }
}

