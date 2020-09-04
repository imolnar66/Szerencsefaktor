using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Szerencsefaktor.Other_classes
{
    class TrixSettings
    {
        private int trixSLength;
        private int trixLLength;

        public int TrixSLength
        {
            get => trixSLength;
            set
            {
                if (value != 0)
                {
                    trixSLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'trixSLength' változó értéke nem lehet nulla!");
                }

            }
        }
        public int TrixLLength
        {
            get => trixLLength;
            set
            {
                if (value != 0)
                {
                    trixLLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'trixLLength' változó értéke nem lehet nulla!");
                }

            }
        }

        public virtual string SaveToJsonFile(TrixSettings trix)
        {
            string resultConvertJson = JsonConvert.SerializeObject(trix);
            return resultConvertJson;
        }

        public virtual void ReadFromJsonFile(string fromJson)
        {
            TrixSettings conf = JsonConvert.DeserializeObject<TrixSettings>(fromJson);
            trixSLength = conf.trixSLength;
            trixLLength = conf.trixLLength;
            
        }
    }
}
