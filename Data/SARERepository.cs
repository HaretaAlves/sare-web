using Interfaces;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace Data
{
    public class SARERepository<T> : IRepository<T> where T : class
    {
        protected DbContext _dbContext { get; set; }

        protected DbSet<T> _dbSet { get; set; }

        public SARERepository(DbContext dbContext)
        {
            try
            {
                if(dbContext == null)
                {
                    throw new ArgumentNullException("dbContext");
                }
                this._dbContext = dbContext;
                this._dbSet = _dbContext.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual IQueryable<T> List()
        {
            try
            {
                return this._dbSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual T GetById(int id)
        {
            try
            {
                return this._dbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual T Insert(T entity)
        {
            try
            {
                T entityReturned = null;

                DbEntityEntry dbEntityEntry = this._dbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Detached)
                {
                    dbEntityEntry.State = EntityState.Added;
                }
                else
                {
                    entityReturned = this._dbSet.Add(entity);
                }

                return entityReturned;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                DbEntityEntry dbEntityEntry = this._dbContext.Entry(entity);

                if (dbEntityEntry.State == EntityState.Detached)
                {
                    this._dbSet.Attach(entity);
                }

                dbEntityEntry.State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Delete(int id)
        {
            try
            {
                var entity = this.GetById(id);

                if (entity != null)
                {
                    this.delete(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void delete(T entity)
        {
            try
            {
                DbEntityEntry dbEntityEntry = this._dbContext.Entry(entity);
                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    this._dbSet.Attach(entity);
                    this._dbSet.Remove(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
