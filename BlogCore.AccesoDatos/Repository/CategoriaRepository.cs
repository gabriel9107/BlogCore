using BlogCore.AccesoDatos.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db; 
        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Categoria categoria)
        {
            var objDedeDb = _db.Categorias.FirstOrDefault(s => s.Id == categoria.Id);
            objDedeDb.Nombre = categoria.Nombre;
            objDedeDb.Orden = categoria.Orden;  

            _db.SaveChanges();

        }
    }
}
