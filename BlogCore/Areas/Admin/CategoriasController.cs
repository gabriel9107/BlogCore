using BlogCore.AccesoDatos.Repository.IRepository;
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

        #region Llamadas a las API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _contenedorTrabajo.Categoria.GetAll()});
        }
        #endregion
    }
}
