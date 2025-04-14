using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    public abstract class CurrencyAPI
    {
        public abstract string[] GetDollar();
        public abstract string[] GetEuro();
    }
}
