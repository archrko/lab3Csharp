using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class HelpMagazine:IComparer<Edition>
    {
        public virtual int Compare(Edition x, Edition y) => x.countInfoEdit.CompareTo(y.countInfoEdit);
    }
}
