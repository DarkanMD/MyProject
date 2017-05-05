﻿using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using NHibernate.Hql.Ast.ANTLR.Tree;

namespace MyProject.Repository
{
    class UserRepository  :Repository<User>
    {
        public object[] GetUserWithMaxOrders()
        {
            User user = null;
            Order order = null; 
            //return _session.QueryOver<User>()
            //    .JoinQueryOver<Order>(x=>x.Orders)
            //    .SelectList(list => list
            //        .SelectGroup(x=>x.Id)
            //        .SelectCount(x=>x.Orders)
            //        )
            //       .OrderBy(Projections.RowCount()).Desc
            //       .Take(1)
            //    .SingleOrDefault<object[]>();

            return _session.QueryOver(()=>user)
                .JoinAlias(()=>user.Orders, ()=>order)
                .SelectList(list => list
                    .SelectGroup(()=>user.Id)
                    .SelectCount(()=>order.Id)
                )
            //    .Where()
                .OrderBy(Projections.RowCount()).Desc
                .Take(1)
                .SingleOrDefault<object[]>();

        }

        public IList<User> GetUsersWithOrders()
        {
            return _session.QueryOver<Order>()
                .JoinQueryOver(x=>x.User)
                .TransformUsing(Transformers.DistinctRootEntity)
                .List<User>();
        }

        //public void Save(User user)
        //{
        //    using (ITransaction transaction = _session.BeginTransaction())
        //    {
        //        _session.SaveOrUpdate(user);
        //        transaction.Commit();
        //    }
        //    }

        public IList<User> GetAllUsers()
        {
            return _session.QueryOver<User>()
                .List<User>();
        }



    }
}
