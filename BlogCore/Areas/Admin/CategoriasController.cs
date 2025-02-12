using BlogCore.AccesoDatos.Repository.IRepository;
using BlogCore.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CategoriasController(IContenedorTrabajo contenedortrabao)
        {
            _contenedorTrabajo = contenedortrabao;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Add(categoria);
                _contenedorTrabajo.Save(); 
                return RedirectToAction(nameof(Index)); 
            }
            return View(categoria);
        }
        #region Llamadas a las API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _contenedorTrabajo.Categoria.GetAll()});
        }
        #endregion
    }
}
