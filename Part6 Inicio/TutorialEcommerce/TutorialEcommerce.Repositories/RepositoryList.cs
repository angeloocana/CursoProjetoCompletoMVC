using System;
using System.Collections.Generic;
using System.Linq;
using TutorialEcommerce.Domain.Entities;
using TutorialEcommerce.Domain.IRepositories;

namespace TutorialEcommerce.Repositories
{
    public class RepositoryList<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly List<TEntity> _list;
        public bool Commited;

        public RepositoryList(List<TEntity> list)
        {
            _list = list;
            Commited = false;
        }

        public void Add(TEntity obj)
        {
            obj.DtInclusao = DateTime.Now;
            _list.Add(obj);
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
            _list.Remove(obj);
        }

        public void Delete(int id)
        {
            _list.Remove(Get(id));
        }

        public TEntity Get(int id)
        {
            return _list.FirstOrDefault(x=>x.Id == id);
        }

        public TEntity First()
        {
            return _list.FirstOrDefault();
        }

        public IQueryable<TEntity> Get()
        {
            return _list.AsQueryable();
        }

        public void Update(TEntity obj)
        {
            obj.DtAlteracao = DateTime.Now;
            _list[_list.IndexOf(Get(obj.Id))] = obj;
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
            Commited = true;
        }
    }
}