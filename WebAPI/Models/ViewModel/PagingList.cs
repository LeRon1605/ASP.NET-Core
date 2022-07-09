using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.ViewModel
{
    public class PagingList<T> where T: class
    {
        public int page { get; set; }
        public int totalPage { get; set; }
        public List<T> data { get; set; }
    }
}
