using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice7
{
    public interface IObserver
    {
        string Name { get; set; }
        Task UpdateAsync(string name, double price);
    }
}
