using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.IRepositories;

namespace TutorialEcommerce.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly EfDbContext Context;

        public Repository(EfDbContext context)
        {
            Context = context;
        }

        private DbSet<TEntity> Entity { get { return Context.Set<TEntity>(); } }

        public void Add(TEntity obj)
        {
            obj.DtInclusao = DateTime.Now;
            Entity.Add(obj);
        }

        public void AddAll(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Add(entity);
        }

        public void DeleteAll(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Delete(entity);
        }

        public void Delete(TEntity obj)
        {
            Entity.Remove(obj);
        }

        public void Delete(int id)
        {
            Entity.Remove(Get(id));
        }

        public TEntity Get(int id)
        {
            return Entity.Find(id);
        }

        public TEntity First()
        {
            return Entity.FirstOrDefault();
        }

        public IQueryable<TEntity> Get()
        {
            return Entity;
        }

        public void Update(TEntity obj)
        {
            obj.DtAlteracao = DateTime.Now;
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void AddOrUpdate(TEntity obj)
        {
            if (obj.Id > 0)
                Update(obj);
            else
                Add(obj);
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}