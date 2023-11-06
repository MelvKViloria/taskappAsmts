using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyChanged;
using System.Linq;
using System.Text;
using System;

namespace TaskApp.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class MyTask
    {
        public string TColor { get; set; }
        public string TName { get; set; }
        public bool Done { get; set; }
        public int CategoryId { get; set; }
    }
}
