using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebSPAGestionEmpleados.Repository
{
    public class GenericRepository<TContext> : IDisposable where TContext : DbContext, new() 
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
        public int Agregar<T>(T item) where T : class
        {
            model.Set<T>().Add(item);
            return Guardar();
        }
        public int Modificar<T>(T item) where T : class
        {
            model.Entry(item).State = EntityState.Modified;
            return Guardar();
        }
        public int Eliminar<T>(T item) where T : class
        {
            model.Set<T>().Remove(item);
           return Guardar();
        }
        private int Guardar()
        {
            return model.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
