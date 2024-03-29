﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess //Namespace, class ve interface'lere rahat ulasabilmek icin kulanilir.
{
    //Core katmani diger katmanlardan referans almaz.
    //Generic Constraint (Generic kisit)
    //class: referans tip olabilir demektir.
    //IEntity demek IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new(): new'lenebilir olmali demektir.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //Odevi degistir.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
