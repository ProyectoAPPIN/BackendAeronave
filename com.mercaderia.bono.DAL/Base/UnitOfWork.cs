using com.mercaderia.bono.Entidades.ModeloEntidades;
using System;

namespace com.mercaderia.bono.DAL
{
    public class UnitOfWork : IDisposable
    {
        private AeronauticaEntities context = new AeronauticaEntities();
        
        private TipoDocumentoRepositorio tipoDocumentoRepositorio;
        private UsuarioRepositorio usuarioRepositorio;


        public TipoDocumentoRepositorio TipoDocumentoRepositorio
        {
            get
            {
                if (this.tipoDocumentoRepositorio == null)
                    this.tipoDocumentoRepositorio = new TipoDocumentoRepositorio(context);
                return tipoDocumentoRepositorio;
            }
        }

        public UsuarioRepositorio UsuarioRepositorio
        {
            get
            {
                if (this.usuarioRepositorio == null)
                    this.usuarioRepositorio = new UsuarioRepositorio(context);
                return usuarioRepositorio;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
