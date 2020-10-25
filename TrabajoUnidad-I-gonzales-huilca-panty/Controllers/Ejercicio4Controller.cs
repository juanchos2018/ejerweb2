using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoUnidad_I_gonzales_huilca_panty.Models;

namespace TrabajoUnidad_I_gonzales_huilca_panty.Controllers
{
    public class Ejercicio4Controller : Controller
    {
        // GET: Ejercicio4
        public static List<ClsEjercicio4> ListaNumeros = new List<ClsEjercicio4>();
        public static List<int> numeros = new List<int>();

        public ActionResult Index()
        {
            return View(ListaNumeros);

        }
        public ActionResult Envios()
        {
            string boton = Request["boton"];
            if (boton.Equals("Generar"))
            {
                ListaNumeros.Clear();
                numeros.Clear();

                //    var numeros = new List<int>();
                int numero = int.Parse(Request["txtnumero"]);
                int contador = 1;
                Random rd = new Random();
                for (int i = 0; i < numero; i++)
                {
                    ClsEjercicio4 o = new ClsEjercicio4();
                    o.Id = contador;
                    o.Numero = rd.Next(1, 600);
                    contador++;
                    numeros.Add(o.Numero);
                    ListaNumeros.Add(o);

                }

            }
            if (boton.Equals("Limpiar"))
            {
                ListaNumeros.Clear();
                numeros.Clear();

            }

            if (boton.Equals("Salir"))
            {
                return View("Index", ListaNumeros);

            }
            return View("Index", ListaNumeros);
        }

        public PartialViewResult Mayor()
        {
            int mayor = numeros.Max();
            ViewBag.Cantidad = mayor;

            return PartialView("_vistamayor");
        }
        public PartialViewResult Menor()
        {
            int menor = numeros.Min();
            ViewBag.Cantidad = menor;

            return PartialView("_vistamayor");
        }
        public PartialViewResult Suma()
        {
            int suma = numeros.Sum();
            ViewBag.Cantidad = suma;

            return PartialView("_vistamayor");
        }
        public PartialViewResult Promedio()
        {
            int cantidad = ListaNumeros.Count;
            int suma = numeros.Sum();
            int promedio = suma / cantidad;
            ViewBag.Cantidad = promedio;

            return PartialView("_vistamayor");
        }
    }
}