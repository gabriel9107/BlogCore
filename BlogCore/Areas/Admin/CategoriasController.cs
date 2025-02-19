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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.Get(id);
            if (categoria == null)
            {
                return NotFound();  
            }

            return View(categoria); 
        }

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
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

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Categoria.Get(id); 
            if(objFromDb == null)
            {
                return Json(new { sucess = false, message = "Error borrando categoria" }); 
            }

            _contenedorTrabajo.Categoria.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { sucess = true, message = "Categoria borrada Correctamente" });



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
