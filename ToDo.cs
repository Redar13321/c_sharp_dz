using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class ToDo
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Doing { get; set; }
        public DateTime Date { get; set; }
        public ToDo(string name, string? Description, bool? doing = false, DateTime? date = null)
        {
            this.Name = name;
            this.Description = Description;
            this.Doing = doing ?? false;
            this.Date = date ?? DateTime.Now;
        }

    }
}
