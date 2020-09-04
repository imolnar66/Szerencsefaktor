using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Szerencsefaktor.Other_classes;

namespace Szerencsefaktor
{
    class ConfigurationSettings //: ICloneable
    {
        #region fields
        //basic settings
        private string gameName;
        private List<string> drawingTablesNames;
        private List<string> derivedTablesNames;
        private int vibrationTrendLength;
        private string theNameOfTheSavedDataFile;
        private List<string> indicatorNames;
        #endregion

        #region properties        
        //basic settings
        public string GameName { get => gameName; private set => gameName = value; }
        public List<string> DrawingTablesNames { get => drawingTablesNames; set => drawingTablesNames = value; }
        public List<string> DerivedTablesNames { get => derivedTablesNames; set => derivedTablesNames = value; }
        public int VibrationTrendLength 
        {
            get => vibrationTrendLength;
            set
            {
                if ( value != 0)
                {
                    vibrationTrendLength = value;
                }
                else
                {
                    throw new ArgumentException("A 'vibrationTrendLength' változó értéke nem lehet nulla!");
                }
                
            }
        }
        public string TheNameOfTheSavedDataFile
        { 
            get => theNameOfTheSavedDataFile;
            set
            {
                if (value != string.Empty)
                {
                    theNameOfTheSavedDataFile = value;
                }
                else
                {
                    throw new ArgumentException("A 'theNameOfTheSavedDataFile' változó étrtéke nem lehet üres karaktersorozat!");
                }
                
            }
        }
        public List<string> IndicatorNames { get => indicatorNames; set => indicatorNames = value; }             
        #endregion

        public ConfigurationSettings()
        {
            drawingTablesNames = new List<string>();
            derivedTablesNames = new List<string>();
            indicatorNames = new List<string>();           
        }
        public virtual string SaveToJsonFile(ConfigurationSettings conf)
        {
            string resultConvertJson = JsonConvert.SerializeObject(conf);
            return resultConvertJson;
        }

        public virtual void ReadFromJsonFile(string fromJson)
        {
            ConfigurationSettings conf = JsonConvert.DeserializeObject<ConfigurationSettings>(fromJson);                                          
            drawingTablesNames = conf.drawingTablesNames;
            derivedTablesNames = conf.derivedTablesNames;
            vibrationTrendLength = conf.vibrationTrendLength;
            theNameOfTheSavedDataFile = conf.theNameOfTheSavedDataFile;
            indicatorNames = conf.indicatorNames;                        
        }

       
    }
}
