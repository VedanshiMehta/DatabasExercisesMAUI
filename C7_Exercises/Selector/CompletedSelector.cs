using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises.Selector
{
    public class CompletedSelector : DataTemplateSelector
    {
        public DataTemplate ActivityCompleted { get; set; }
        public DataTemplate ActivityNotCompleted { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var acitvity = (ActivityTabel)item;
            return (acitvity.IsCompleted) ? ActivityCompleted : ActivityNotCompleted;
        }
    }
}
