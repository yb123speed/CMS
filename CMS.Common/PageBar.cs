using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    public class PageBar
    {
        /// <summary>
        /// 产生数字页码
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageCount">总页数</param>
        /// <returns></returns>
        public static string GetPageBar(int pageIndex,int pageCount)
        {
            if (pageCount == 1)
            {
                return string.Empty;
            }
            int start = pageIndex - 5;//页码起始位置  要求显示10个页码
            start = start < 1 ? 1 : start;
            int end = start + 9;
            if (end > pageCount)
            {
                end = pageCount;
                start = pageCount - 9;//确保显示10个页码
                if (start < 1)
                {
                    start = 1;//实在没有10个，就从1开始全部显示
                }
            }
            StringBuilder sb=new StringBuilder();
            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    sb.Append(i);
                }
                else
                {
                    sb.Append(string.Format("<a href='?pageIndex={0}'>{0}</a>",i));
                }
            }
            return sb.ToString();
        }

    }
}
