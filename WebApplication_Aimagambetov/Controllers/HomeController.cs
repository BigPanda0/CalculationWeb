using MathLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication_Aimagambetov.Models;
using WebApplication_Aimagambetov.Models.ViewModels;

namespace WebApplication_Aimagambetov.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyDbContext db;

        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            db = context;

        }

        [HttpGet]
        public IActionResult Index(CalculationViewModel calculationViewModel, int id)
        {

            return View(calculationViewModel);
        }
        [HttpPost]
        public IActionResult Index(CalculationViewModel calculationViewModel)
        {
            return View(calculationViewModel);
        }
        [HttpPost]
        public IActionResult Calculation(CalculationViewModel calculationViewModel)
        {
            Calculation calculation = new Calculation
            {
                H0 = calculationViewModel.H0,
                t_nachMat = calculationViewModel.t_nachMat,
                T_nachTemp = calculationViewModel.T_nachTemp,
                Wg = calculationViewModel.Wg,
                Gm = calculationViewModel.Gm,
                Cg = calculationViewModel.Cg,
                Cm = calculationViewModel.Cm,
                aV = calculationViewModel.aV,
                D = calculationViewModel.D
            };

            calculationViewModel.m = calculation.m();
            calculationViewModel.ns = calculation.ns;
            calculationViewModel.Y0 = calculation.Y0();
            calculationViewModel.Ys = calculation.GetYs();
            calculationViewModel.ExpYs = calculation.GetExpYs();
            calculationViewModel.MexpYs = calculation.GetMexpYs();
            calculationViewModel.Vs = calculation.GetVs();
            calculationViewModel.Os = calculation.GetOs();
            calculationViewModel.tNachs = calculation.Getts();
            calculationViewModel.Ts = calculation.GetTs();
            calculationViewModel.Raz = calculation.GetRaz();
            return View(calculationViewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculation()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult SaveCalculate(CalculationViewModel calculationViewModel)
        {
            if (calculationViewModel.Name == null)
                calculationViewModel.Name = "Нет названия";
            db.CalculationDatas.Add(new CalculationData
            {
                Name = calculationViewModel.Name,
                H0 = calculationViewModel.H0,
                t_nachMat = calculationViewModel.t_nachMat,
                T_nachTemp = calculationViewModel.T_nachTemp,
                Wg = calculationViewModel.Wg,
                Gm = calculationViewModel.Gm,
                Cg = calculationViewModel.Cg,
                Cm = calculationViewModel.Cm,
                aV = calculationViewModel.aV,
                D = calculationViewModel.D,
                UserId = db.Users.FirstOrDefault(x => x.Login == User.Identity.Name).Id
            });
            db.SaveChanges();

            Calculation calculation = new Calculation
            {
                H0 = calculationViewModel.H0,
                t_nachMat = calculationViewModel.t_nachMat,
                T_nachTemp = calculationViewModel.T_nachTemp,
                Wg = calculationViewModel.Wg,
                Gm = calculationViewModel.Gm,
                Cg = calculationViewModel.Cg,
                Cm = calculationViewModel.Cm,
                aV = calculationViewModel.aV,
                D = calculationViewModel.D
            };

            calculationViewModel.m = calculation.m();
            calculationViewModel.Y0 = calculation.Y0();
            calculationViewModel.Ys = calculation.GetYs();
            calculationViewModel.ExpYs = calculation.GetExpYs();
            calculationViewModel.MexpYs = calculation.GetMexpYs();
            calculationViewModel.Vs = calculation.GetVs();
            calculationViewModel.Os = calculation.GetOs();
            calculationViewModel.tNachs = calculation.Getts();
            calculationViewModel.Ts = calculation.GetTs();
            calculationViewModel.Raz = calculation.GetRaz();
            calculationViewModel.ns = calculation.ns;

            return View("Calculation", calculationViewModel);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Calculations()
        {
            var calculationViewModels = new List<CalculationViewModel>();
            foreach (var item in db.CalculationDatas)
            {
                if (item.UserId == db.Users.FirstOrDefault(x => x.Login == User.Identity.Name).Id)
                {
                    calculationViewModels.Add(new CalculationViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        H0 = item.H0,
                        t_nachMat = item.t_nachMat,
                        T_nachTemp = item.T_nachTemp,
                        Wg = item.Wg,
                        Gm = item.Gm,
                        Cg = item.Cg,
                        Cm = item.Cm,
                        aV = item.aV,
                        D = item.D

                    });
                }
            }
            return View(calculationViewModels);
        }

        [HttpGet]
        public IActionResult DeleteCalculate(CalculationViewModel viewModel)
        {
            db.CalculationDatas.Remove(new CalculationData { Id = viewModel.Id });
            db.SaveChanges();

            var calculationViewModels = new List<CalculationViewModel>();
            foreach (var item in db.CalculationDatas)
            {
                if (item.UserId == db.Users.FirstOrDefault(x => x.Login == User.Identity.Name).Id)
                {
                    calculationViewModels.Add(new CalculationViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        H0 = item.H0,
                        t_nachMat = item.t_nachMat,
                        T_nachTemp = item.T_nachTemp,
                        Wg = item.Wg,
                        Gm = item.Gm,
                        Cg = item.Cg,
                        Cm = item.Cm,
                        aV = item.aV,
                        D = item.D

                    });
                }
            }

            return View("Calculations", calculationViewModels);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}