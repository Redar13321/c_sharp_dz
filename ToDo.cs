using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9
{
    public class ToDo
    {
        public string Name { get => _name; }
        public string? Description { get => _description; }
        public DateOnly Date { get => _date; }
        public ToDo(string name, string? Description, DateOnly? date = null)
        {
            this._name = name;
            this._description = Description;
            this._date = date ?? DateOnly.FromDateTime(DateTime.Now);
        }

        string _name;
        string? _description;
        DateOnly _date;
    }
}
