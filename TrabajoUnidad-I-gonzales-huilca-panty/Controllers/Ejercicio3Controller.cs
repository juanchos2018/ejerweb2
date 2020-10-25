using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoUnidad_I_gonzales_huilca_panty.Models;

namespace TrabajoUnidad_I_gonzales_huilca_panty.Controllers
{
    public class Ejercicio3Controller : Controller
    {
        // GET: Ejercicio3
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Visualizar(ClsEjercicio3 objEjercicio3)
        {
            List<ClsEjercicio3> objListaKeys = new List<ClsEjercicio3>();
            try
            {
                List<string> objLista = new List<string>();
                List<string> objListaClave = new List<string>();
               
                string[] words = objEjercicio3.texto.Split();


                string[] wordskeys = objEjercicio3.palabra.Split();

                char[] charsToTrim = { ',', ';', ' ', '.' };
                foreach (string word in words)
                {
                    objLista.Add(word.TrimEnd(charsToTrim));
                }

                char[] charsToTrimClave = { ',', ';', ' ', '.' };
                foreach (string wordclaves in wordskeys)
                {
                    objListaClave.Add(wordclaves.TrimEnd(charsToTrimClave));
                }


                for (int i = 0; i < objListaClave.Count; i++)
                {

                    ClsEjercicio3 objEjercicio2 = new ClsEjercicio3();
                    for (int j = 0; j < objLista.Count; j++)
                    {

                        if (objListaClave[i].Equals(objLista[j]))
                        {
                            objEjercicio2.palabraClave = objListaClave[i].ToString();
                            objEjercicio2.contador += 1;
                        }
                    }

                    objListaKeys.Add(objEjercicio2);
                }
            }
            catch (Exception e)
            {

            }
            

           return View(objListaKeys);

        }
    }
}