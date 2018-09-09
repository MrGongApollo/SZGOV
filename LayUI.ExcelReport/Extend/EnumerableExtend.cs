﻿//描述：IEnumerable接口的扩展方法

using System.Collections.Generic;

namespace LayUI.ExcelReport
{
    public static class EnumerableExtend
    {
        /// <summary>
        /// 判断集合是否为Null或为Empty
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (!source.IsNull())
            {
                using (IEnumerator<TSource> enumerator = source.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
