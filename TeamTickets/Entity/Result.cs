using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTickets.Entity
{
    public class Result<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
        public T Data { get; set; }
        public void addErr(string msg)
        {
            this.Success = false;
            this.Message = msg;
        }
    }
}
