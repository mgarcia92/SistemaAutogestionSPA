using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebSPAGestionEmpleados.Repository
{
    public class GenericRepository<TContext> where TContext : DbContext, new()
    {
        public TContext model = null;

        public GenericRepository(TContext contexto)
        {
            model = contexto;
        }
        public List<T> Listado<T>() where T : class
        {
            return model.Set<T>().ToList();
        }
        public T Obtener<T>(int id) where T : class
        {
            return model.Set<T>().Find(id);
        }
        public void Agregar<T>(T item) where T : class
        {
            model.Set<T>().Add(item);
            Guardar();
        }
        public void Modificar<T>(T item) where T : class
        {
            model.Entry(item).State = EntityState.Modified;
            Guardar();
        }
        public void Eliminar<T>(T item) where T : class
        {
            model.Set<T>().Remove(item);
            Guardar();
        }
        private void Guardar()
        {
            model.SaveChanges();
        }
    }
}
