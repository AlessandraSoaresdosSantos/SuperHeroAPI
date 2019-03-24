using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.EntityFramework
{
    public class UnityOfWork : IDisposable
    {
        #region Privates
        private SuperHeroAPIContext _baseContext = null;
        private bool _disposed = false;
        private IAuditEventRepository _auditEventRepository;
        private IProtectionAreaRepository _protectionAreaRepository;
        private IRoleRepository _roleRepository;
        private ISuperHeroRepository _superHeroRepository;
        private ISuperPowerRepository _superPowerRepository;
        private IUsersRepository _usersRepository;
        #endregion

        #region Props
        public IAuditEventRepository AuditEventRepository
        {
            get
            {
                this._auditEventRepository = this._auditEventRepository ?? new AuditEventRepository(_baseContext);

                return this._auditEventRepository;
            }
        }
        public IProtectionAreaRepository ProtectionAreaRepository
        {
            get
            {
                this._protectionAreaRepository = this._protectionAreaRepository ?? new ProtectionAreaRepository(_baseContext);

                return this._protectionAreaRepository;
            }
        }
        public IRoleRepository RoleRepository
        {
            get
            {
                this._roleRepository = this._roleRepository ?? new RoleRepository(_baseContext);

                return this._roleRepository;
            }
        }
        public ISuperHeroRepository SuperHeroRepository
        {
            get
            {
                this._superHeroRepository = this._superHeroRepository ?? new SuperHeroRepository(_baseContext);

                return this._superHeroRepository;
            }
        }
        public ISuperPowerRepository SuperPowerRepository
        {
            get
            {
                this._superPowerRepository = this._superPowerRepository ?? new SuperPowerRepository(_baseContext);

                return this._superPowerRepository;
            }
        }
        public IUsersRepository UsersRepository
        {
            get
            {
                this._usersRepository = this._usersRepository ?? new UsersRepository(_baseContext);

                return this._usersRepository;
            }
        }
        public UnityOfWork(SuperHeroAPIContext baseContext)
        {
            this._baseContext = baseContext;
        }
        public int SaveAllChanges()
        {
            return this._baseContext.SaveChanges();
        }
        public IRepositoryBase<T> GetRepo<T>() where T : class
        {
            return (IRepositoryBase<T>)this.GetType().GetProperties().SingleOrDefault(p => p.Name.Equals($"{typeof(T).Name}Repository")).GetValue(this, null);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
                if (disposing)
                    this._baseContext.Dispose();

            this._disposed = true;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}