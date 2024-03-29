﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboTinic.Context.UtilContext
{
    public static class Utils
    {
        public static void InsertOrUpdate<T>(this DbContext context, T model) where T: class
        {

            EntityEntry<T> entry = context.Entry(model);
            IKey primaryKey = entry.Metadata.FindPrimaryKey();

            if (primaryKey != null)
            {
                object[] keys = primaryKey.Properties.Select(x => x.FieldInfo.GetValue(model)).ToArray();

                T result = context.Find<T>(keys);

                if (result == null)
                {
                    context.Add(model);
                }
                else
                {

                    context.Entry(result).State = EntityState.Detached;
                    context.Update(model);
                }
            }
         }
    }
}
