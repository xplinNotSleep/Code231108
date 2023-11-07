using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPT.BusinessService
{
    public class PagingData<T> where T: class
    {
        public int RecordCount { get; set; }
        
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        /// <summary>
        /// 加个问号代表属性值可以为null
        /// </summary>
        public List<T>? DataList { get; set; }

        public string? SearchString { get; set; }

    }
}
