using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szerencsefaktor.Other_classes
{
    class OwnList : List<byte>
    {
        public new void Add(byte item)
        {
            if (!this.Contains(item))
            {
                base.Add(item);
            }
            else
            {
                throw new ArgumentException($"A(z) {item} érték már szerepel a listában!");
            }
        }
    }
}
