using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP11_CursosWeb.Models;

namespace TP11_CursosWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Especialidad> ListadoEspecialidades = BD.ListarEspecialidades();
            ViewBag.ListadoEspecialidades = ListadoEspecialidades;
            List<Curso> ListadoCursos = BD.ListarCursos(-1);
            ViewBag.ListadoCursos = ListadoCursos;
            return View("Index");
        }
        public IActionResult MostrarCursosxEspecialidad(int IdEspecialidad) {
            List<Curso> ListadoCursos = BD.ListarCursos(IdEspecialidad);
            ViewBag.ListadoCursos = ListadoCursos;
            List<Curso> ListadoCursosxEspecialidad = BD.ListarCursos(IdEspecialidad);
            ViewBag.ListadoCursosxEspecialidad = ListadoCursosxEspecialidad;
            List<Especialidad> ListadoEspecialidades = BD.ListarEspecialidades();
            ViewBag.ListadoEspecialidades = ListadoEspecialidades;
            return View("Index");
            }
        public IActionResult VerCurso(int IdCurso) {
            List<Especialidad> ListadoEspecialidades = BD.ListarEspecialidades();
            ViewBag.ListadoEspecialidades = ListadoEspecialidades;
            ViewData["IdCurso"] = IdCurso;
            Curso UnCurso = BD.ConsultaCurso(IdCurso);
            ViewBag.Likes = UnCurso.MeGusta;
            ViewBag.Dislikes = UnCurso.NoMeGusta;
            ViewBag.NombreCurso = UnCurso.Nombre;
            ViewBag.Imagen = UnCurso.Imagen;
            ViewBag.Url = UnCurso.UrlCurso;
            return View("DetalleCurso");
        }
        public IActionResult Calificar(int IdCurso, bool Gusta) {
            List<Especialidad> ListadoEspecialidades = BD.ListarEspecialidades();
            ViewBag.ListadoEspecialidades = ListadoEspecialidades;
            BD.CalificarCurso(IdCurso, Gusta);
            ViewData["IdCurso"] = IdCurso;
            Curso UnCurso = BD.ConsultaCurso(IdCurso);
            ViewBag.Likes = UnCurso.MeGusta;
            ViewBag.Dislikes = UnCurso.NoMeGusta;
            ViewBag.NombreCurso = UnCurso.Nombre;
            ViewBag.Imagen = UnCurso.Imagen;
            ViewBag.Url = UnCurso.UrlCurso;
            return View ("DetalleCurso");
        }
        public IActionResult AgregarCurso() {
            List<Especialidad> ListadoEspecialidades = BD.ListarEspecialidades();
            ViewBag.ListadoEspecialidades = ListadoEspecialidades;
            return View ("AgregarCurso");
        }
        [HttpPost] public IActionResult GuardarCurso (int IdCurso, string Nombre, int IdEspecialidad, string Descripcion, string Imagen, string UrlCurso) {
            int MeGusta = 0;
            int NoMeGusta = 0;
            Curso UnCurso = new Curso(IdCurso, Nombre, IdEspecialidad, Descripcion, Imagen, UrlCurso, MeGusta, NoMeGusta);
            BD.AgregarCurso(UnCurso);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
