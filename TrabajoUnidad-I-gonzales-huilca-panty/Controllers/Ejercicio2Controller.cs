using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoUnidad_I_gonzales_huilca_panty.Models;

namespace TrabajoUnidad_I_gonzales_huilca_panty.Controllers
{
    public class Ejercicio2Controller : Controller
    {
        // GET: Ejercicio2}

        public static List<Productos1> lista3 = new List<Productos1>();
        public static List<Productos2> lista4 = new List<Productos2>();
        //    public static List<string> lista5 = new List<string>();
        ClsProductosViewModel userViewModel = new ClsProductosViewModel();


        public ActionResult Index()
        {
            ClsProductosViewModel userViewMo = new ClsProductosViewModel();

            // lista3.Clear();
            return View(userViewMo);
        }
        public ActionResult Envios()
        {
            string estado = Request["btnform"];

            if (estado.Equals("Enviar"))
            {
                string dato = Request["txt1"];

                if (dato == "")
                {
                    ViewBag.Mensaje = "No ingreso Dato";
                    ViewBag.Estilo = "alert alert-danger";

                    //  Response.Write('<div class="alert alert - danger" role="alert"><b>No ingreso dato </b> <br /> </div>');
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);

                }
                foreach (Productos1 item in lista3)
                {
                    if (item.nombre_producto_1.Equals(dato))
                    {
                        ViewBag.Mensaje = "YA EXISTE ESTE REGISTRO";
                        ViewBag.Estilo = "alert alert-danger";

                        //  Response.Write('<div class="alert alert - danger" role="alert"><b>No ingreso dato </b> <br /> </div>');
                        userViewModel.Productos1 = lista3;
                        userViewModel.Productos2 = lista4;
                        return View("Index", userViewModel);
                    }
                }
                Productos1 o = new Productos1();
                o.nombre_producto_1 = dato;
                lista3.Add(o);
                ViewBag.Mensaje = "Agregado";
                ViewBag.Estilo = "alert alert-success";
                userViewModel.Productos1 = lista3;
                userViewModel.Productos2 = lista4;


            }

            if (estado.Equals("PASAR_UNO"))
            {
                Productos2 o1 = new Productos2();
                string data_pasado = Request["txtdato"];
                string lista = Request["txttipolista"];

                if (lista.Equals("lista2"))
                {
                    ViewBag.Mensaje = "No Te pasesde listo We";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);

                }

                if (data_pasado == "")
                {
                    ViewBag.Mensaje = "No Elijio un  producto";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);
                }

                o1.nombre_producto_2 = data_pasado;
                int i = 0;
                foreach (Productos1 item in lista3)
                {
                    if (item.nombre_producto_1.Equals(data_pasado))
                    {

                        lista3.RemoveAt(i);
                        break;
                    }
                    i++;
                }

                lista4.Add(o1);
                userViewModel.Productos2 = lista4;
                userViewModel.Productos1 = lista3;

                ViewBag.Mensaje = "Paso a otra lista";
                ViewBag.Estilo = "alert alert-success";

            }

            if (estado.Equals("Retirar_Uno"))
            {
                Productos1 o1 = new Productos1();
                string data_pasado = Request["txtdato"];
                string lista = Request["txttipolista"];

                if (lista.Equals("lista1"))
                {
                    ViewBag.Mensaje = "No Te pasesde listo We";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);

                }
                if (data_pasado == "")
                {
                    ViewBag.Mensaje = "No Elijio un  producto";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);
                }
                o1.nombre_producto_1 = data_pasado;
                int i = 0;
                foreach (Productos2 item in lista4)
                {
                    if (item.nombre_producto_2.Equals(data_pasado))
                    {

                        lista4.RemoveAt(i);
                        break;
                    }
                    i++;
                }

                lista3.Add(o1);
                userViewModel.Productos2 = lista4;
                userViewModel.Productos1 = lista3;
                ViewBag.Mensaje = "Paso a otra lista";
                ViewBag.Estilo = "alert alert-success";
            }


            if (estado.Equals("Pasar_Todos"))
            {
                int cantidad;
                cantidad = lista3.Count;

                string lista = Request["txttipolista"];

                if (lista.Equals("lista2"))
                {
                    ViewBag.Mensaje = "No Te pasesde listo We";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);

                }


                if (cantidad == 0)
                {
                    ViewBag.Mensaje = "No Hay Registro en esta lita";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);
                }

                foreach (Productos1 item in lista3)
                {
                    Productos2 p = new Productos2();
                    p.nombre_producto_2 = item.nombre_producto_1;
                    lista4.Add(p);

                }
                lista3.Clear();
                userViewModel.Productos2 = lista4;
                userViewModel.Productos1 = lista3;

                ViewBag.Mensaje = "Paso a otra lista";
                ViewBag.Estilo = "alert alert-success";

            }

            if (estado.Equals("Retirar_Todos"))
            {
                int cantidad;
                cantidad = lista4.Count;
                string lista = Request["txttipolista"];

                if (lista.Equals("lista2"))
                {
                    ViewBag.Mensaje = "No Te pasesde listo We";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);

                }
                if (cantidad == 0)
                {
                    ViewBag.Mensaje = "No Hay Registro en esta lita";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);
                }

                foreach (Productos2 item in lista4)
                {
                    Productos1 p = new Productos1();
                    p.nombre_producto_1 = item.nombre_producto_2;
                    //  Productos1 p = new Productos1();
                    //p.nombre_producto_1 = item.nombre_producto_1;
                    lista3.Add(p);

                }
                lista4.Clear();
                userViewModel.Productos2 = lista4;
                userViewModel.Productos1 = lista3;

                ViewBag.Mensaje = "Paso a otra lista";
                ViewBag.Estilo = "alert alert-success";

            }

            if (estado.Equals("Pasar_Seleccionados"))
            {
                string dato = Request["txtseleccionados"].Trim(',');
                if (dato == "")
                {
                    ViewBag.Mensaje = "No Elijio nada";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);
                }


                string lista = Request["txttipolista"];

                if (lista.Equals("lista2"))
                {
                    ViewBag.Mensaje = "No Te pasesde listo We";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);

                }

                string[] array = Request["txtseleccionados"].Trim(',').Split(',');
                string[] arrayB = array.Distinct().ToArray();


                int ia = 0;
                for (int i = 0; i < arrayB.Length; i++)
                {
                    Productos2 t = new Productos2();
                    t.nombre_producto_2 = arrayB[i].Trim();
                    lista4.Add(t);
                    foreach (Productos1 item in lista3)
                    {
                        if (item.nombre_producto_1.Equals(arrayB[i]))
                        {
                            //lista3.RemoveAt(ia);
                            lista3.Remove(item);
                            break;
                        }
                        ia++;
                    }
                }
                array = null;
                arrayB = null;
                ViewBag.Mensaje = "Paso a otra lista";
                ViewBag.Estilo = "alert alert-success";


                userViewModel.Productos2 = lista4;
                userViewModel.Productos1 = lista3;

            }


            if (estado.Equals("Retirar_Selecionados"))
            {
                string dato = Request["txtseleccionados"].Trim(',');
                if (dato == "")
                {
                    ViewBag.Mensaje = "No Elijio un  producto";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);
                }
                string lista = Request["txttipolista"];

                if (lista.Equals("lista1"))
                {
                    ViewBag.Mensaje = "No Te pasesde listo We";
                    ViewBag.Estilo = "alert alert-danger";
                    userViewModel.Productos1 = lista3;
                    userViewModel.Productos2 = lista4;
                    return View("Index", userViewModel);

                }
                string[] array = Request["txtseleccionados"].Trim(',').Split(',');
                string[] arrayB = array.Distinct().ToArray();
                int ia = 0;
                for (int i = 0; i < arrayB.Length; i++)
                {
                    Productos1 t = new Productos1();
                    t.nombre_producto_1 = arrayB[i];
                    lista3.Add(t);

                    foreach (Productos2 item in lista4)
                    {
                        if (item.nombre_producto_2.Equals(arrayB[i])) //eRRRO AQUI WE
                        {
                            //lista4.RemoveAt(ia);
                            lista4.Remove(item);
                            break;
                        }
                        ia++;
                    }
                }
                array = null;
                arrayB = null;
                ViewBag.Mensaje = "Paso a otra lista";
                ViewBag.Estilo = "alert alert-success";

                userViewModel.Productos2 = lista4;
                userViewModel.Productos1 = lista3;

            }

            if (estado.Equals("Limpiar"))
            {
                lista3.Clear();
                lista4.Clear();
                userViewModel.Productos2 = lista4;
                userViewModel.Productos1 = lista3;

            }

            return View("Index", userViewModel);
        }
    }
}