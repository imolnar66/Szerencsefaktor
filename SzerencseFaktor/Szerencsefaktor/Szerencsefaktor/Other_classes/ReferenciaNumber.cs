using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace Szerencsefaktor.Other_classes
{
    class ReferenciaNumber
    {
        private int minusNLength;
        public int MinusNLength
        {
            get => minusNLength;
            set
            {
                if (value != 0)
                {
                    minusNLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'minusLength' változó értéke nem lehet nulla!");
                }

            }
        }

        public virtual string SaveToJsonFile(int minusNLength)
        {
            string resultConvertJson = JsonConvert.SerializeObject(minusNLength);
            return resultConvertJson;
        }

        public virtual void ReadFromJsonFile(string fromJson)
        {
            int nLength = JsonConvert.DeserializeObject<int>(fromJson);
            this.minusNLength = nLength;

        }
    }
}
