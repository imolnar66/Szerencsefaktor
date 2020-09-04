using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace Szerencsefaktor.Other_classes
{
    class RsiSettings
    {
        private int rsiLength;
        private int rsiTrendLength;
        private List<double> rsiLevels;

        public int RsiLength
        {
            get => rsiLength;
            set
            {
                if (value != 0)
                {
                    rsiLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'rsiLength' változó értéke nem lehet nulla!");
                }

            }
        }
        public int RsiTrendLength
        {
            get => rsiTrendLength;
            set
            {
                if (value != 0)
                {
                    rsiTrendLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'rsiTrendLength' változó értéke nem lehet nulla!");
                }

            }
        }
        public List<double> RsiLevels { get => rsiLevels; set => rsiLevels = value; }

        public RsiSettings()
        {
            rsiLevels = new List<double>();
        }
        public virtual string SaveToJsonFile(RsiSettings conf)
        {
            string resultConvertJson = JsonConvert.SerializeObject(conf);
            return resultConvertJson;
        }

        public virtual void ReadFromJsonFile(string fromJson)
        {
            RsiSettings conf = JsonConvert.DeserializeObject<RsiSettings>(fromJson);          
            rsiLength = conf.rsiLength;
            rsiTrendLength = conf.rsiTrendLength;
            rsiLevels = conf.rsiLevels;           
        }


    }
}
