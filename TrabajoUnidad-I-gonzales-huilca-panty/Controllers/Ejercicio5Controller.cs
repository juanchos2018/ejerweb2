using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoUnidad_I_gonzales_huilca_panty.Models;

namespace TrabajoUnidad_I_gonzales_huilca_panty.Controllers
{
    public class Ejercicio5Controller : Controller
    {
        // GET: Ejercicio5
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Visualizar(ClsEjercicio5 ObjEjercicio5)
        {
            double TasaInteres = (ObjEjercicio5.TasaInteres / 100);
            int NPeriodos = ObjEjercicio5.CantidadMes;
            double Prestamo = ObjEjercicio5.prestamo;

            int p = NPeriodos * -1;
            double b = (1 + TasaInteres);
            double A = (1 - Math.Pow(b, p)) / TasaInteres;

            double CuotaFija = Prestamo / A;
            ObjEjercicio5.CuotaFija = Math.Round(Convert.ToDouble(CuotaFija), 2);
            //ObjEjercicio5.CuotaFija = CuotaFija;

            return View(ObjEjercicio5);
        }
    }
}