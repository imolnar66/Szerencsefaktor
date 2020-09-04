using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace Szerencsefaktor.Other_classes
{
    class JsonFileManagement
    {
        public virtual string SaveToJsonFile(ConfigurationSettings conf)
        {
            string resultConvertJson = JsonConvert.SerializeObject(conf);
            return resultConvertJson;
        }

        public virtual void ReadFromJsonFile(string fromJson)
        {
            ConfigurationSettings conf = JsonConvert.DeserializeObject<ConfigurationSettings>(fromJson);
            gameName = conf.gameName;
            smallestNumber = conf.smallestNumber;
            largestNumber = conf.largestNumber;
            howManyCanIPlay = conf.howManyCanIPlay;
            homePage = conf.homePage;
            fromWhat = conf.fromWhat;
            whereWhat = conf.whereWhat;
            constantValueOfVibrationY = conf.constantValueOfVibrationY;
            vibrationYConstantDivisibleBy = conf.vibrationYConstantDivisibleBy;
            vibrationYConstantDivisor = conf.vibrationYConstantDivisor;
            minusNLength = conf.minusNLength;
            trixSLength = conf.trixSLength;
            trixLLength = conf.trixLLength;
            shortEma = conf.shortEma;
            longEma = conf.longEma;
            drawingTablesNames = conf.drawingTablesNames;
            derivedTablesNames = conf.derivedTablesNames;
            vibrationTrendLength = conf.vibrationTrendLength;
            theNameOfTheSavedDataFile = conf.theNameOfTheSavedDataFile;
            indicatorNames = conf.indicatorNames;
            rsiLength = conf.rsiLength;
            rsiTrendLength = conf.rsiTrendLength;
            rsiLevels = conf.rsiLevels;
            abcLength = conf.abcLength;
        }
    }
}
