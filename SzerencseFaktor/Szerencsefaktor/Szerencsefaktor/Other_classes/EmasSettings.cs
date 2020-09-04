using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace Szerencsefaktor.Other_classes
{
    class EmasSettings
    {      
        private int shortEma;
        private int longEma;
        public int ShortEma
        {
            get => shortEma;
            set
            {
                if (value != 0)
                {
                    shortEma = value;
                }
                else
                {
                    throw new ArgumentException("A 'shortEma' változó értéke nem lehet nulla! ");
                }

            }
        }
        public int LongEma
        {
            get => longEma;
            set
            {
                if (value != 0)
                {
                    longEma = value;
                }
                else
                {
                    throw new ArgumentException("A 'longEma' változó értéke nem lehet nulla!");
                }

            }
        }
        public virtual string SaveToJsonFile(EmasSettings conf)
        {
            string resultConvertJson = JsonConvert.SerializeObject(conf);
            return resultConvertJson;
        }

        public virtual void ReadFromJsonFile(string fromJson)
        {
            EmasSettings conf = JsonConvert.DeserializeObject<EmasSettings>(fromJson);
            shortEma = conf.shortEma;
            longEma = conf.longEma;           
        }

    }
}
