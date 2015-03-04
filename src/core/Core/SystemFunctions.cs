﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ToText.Core
{
    public static class SystemFunctions
    {
        public static IReadOnlyCollection<T> Cons<T>(this T item, IEnumerable<T> items)
        {
            var list = new List<T> {item};
            list.AddRange(items);
            return list;
        }

        public static IReadOnlyCollection<T> Rest<T>(this IEnumerable<T> items)
        {
            return items.Skip(1).ToList();
        }

        public static IReadOnlyCollection<TResult> Map<T, TResult>(this IEnumerable<T> items, Func<T, TResult> func)
        {
            return items.Select(func).ToList();
        }

        public static IReadOnlyCollection<T> Map<T>(this IEnumerable<T> items, Action<T> action)
        {
            List<T> itemList = items.ToList();
            foreach (T item in itemList)
            {
                action(item);
            }
            return itemList;
        }
    }
}