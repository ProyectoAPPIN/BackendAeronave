using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Reflection;
using com.mercaderia.bono.Utilidades.Excepciones;
using System.Globalization;
using com.mercaderia.bono.Entidades.ModeloEntidades;


namespace com.mercaderia.bono.DAL
{
    public abstract partial class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        internal AeronauticaEntities context;
        internal DbSet<TEntity> dbSet;
        protected Repositorio(AeronauticaEntities contextApp)
        {
            if (contextApp != null)
            {
                contextApp.Configuration.LazyLoadingEnabled = false;
                context = contextApp;
                dbSet = contextApp.Set<TEntity>();
            }
            else
            {
                throw new ArgumentNullException("contextApp");
            }

        }


        public virtual IEnumerable<TEntity> List()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public virtual void Actualizar(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

        }

        public virtual void Adicionar(TEntity entity)
        {
            dbSet.Add(entity);

        }

        public virtual void Eliminar(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);

        }

        public virtual int TotalRegistros()
        {
            return dbSet.Count();
        }

        public T[] EjecutarSentenciaSQL<T>(string sentencia)
        {
            return context.Database.SqlQuery<T>(sentencia).ToArray();
        }

        public Object ObtenerValorPorTipo(Object valor, Type tipo)
        {
            if (valor != null && tipo != null)
            {
                string val = valor.ToString();
                if (tipo == typeof(bool))
                {
                    return bool.Parse(val);
                }
                if (tipo == typeof(int) || tipo == typeof(int?))
                {
                    return int.Parse(val, CultureInfo.InvariantCulture);
                }
                if (tipo == typeof(float))
                {
                    return float.Parse(val, CultureInfo.InvariantCulture);
                }
                if (tipo == typeof(long))
                {
                    return long.Parse(val, CultureInfo.InvariantCulture);
                }
                if (tipo == typeof(short))
                {
                    return short.Parse(val, CultureInfo.InvariantCulture);
                }
                if (tipo == typeof(decimal))
                {
                    return decimal.Parse(val, CultureInfo.InvariantCulture);
                }
                if (tipo == typeof(string))
                {
                    return val;
                }   
                if (tipo == typeof(Object))
                {
                    return valor;
                }
                else
                {
                    throw new BaseException("No es posible identificar el tipo del valor: " + valor);
                }
            }
            else
            {
                throw new ArgumentNullException("valor");
            }
        }

    }
}

