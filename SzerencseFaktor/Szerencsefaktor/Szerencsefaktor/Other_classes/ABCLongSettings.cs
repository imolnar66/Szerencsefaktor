using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace Szerencsefaktor.Other_classes
{
    class ABCLongSettings
    {
        private int abcLength;
        public int AbcLength
        {
            get => abcLength;
            set
            {
                if (value != 0)
                {
                    abcLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'abcLength' változó értéke nem lehet nulla!");
                }

            }
        }

        public virtual string SaveToJsonFile(ABCLongSettings conf)
        {
            string resultConvertJson = JsonConvert.SerializeObject(conf);
            return resultConvertJson;
        }

        public virtual void ReadFromJsonFile(string fromJson)
        {
            ABCLongSettings conf = JsonConvert.DeserializeObject<ABCLongSettings>(fromJson);
            AbcLength = conf.AbcLength;            
        }

    }
}
