using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szerencsefaktor.Other_classes;

namespace Szerencsefaktor.ForDatabase
{
    class CreateDataTablesfromJson
    {
        GameFeatures chooseGame;
       // private const string sqlTableFirstString = "CREATE TABLE";
        private Dictionary<string, string> sqlTablaStrings;
        private List<string> baseTableStrings;
        private List<string> baseTableNames;
        private string sqlSep;
        public CreateDataTablesfromJson(GameFeatures game)
        {
            sqlTablaStrings = new Dictionary<string, string>();
            baseTableStrings = new List<string>();
            chooseGame = game;
            sqlTablaStrings = chooseGame.TableDatas;
            sqlSep = chooseGame.SqlSeparator;
        }
        public void CreateBaseTableString()
        {
            foreach (KeyValuePair<string, string> item in sqlTablaStrings)
            {
                string[] sqlStringArray = item.Value.Split(',');
                
                //first item
                string sqlStringLine = $"CREATE TABLE {item.Key} ( id INT NOT NULL IDENTITY(1,1) PRIMARY KEY";
                //additional items 
                foreach (string sqlStringElement in sqlStringArray)
                {
                    sqlStringLine += sqlStringElement;
                    //Ha az adott elem nem a tömb utolsó eleme, akkor hozzáad egy vesszőt
                    if (sqlStringElement  != sqlStringArray.Last())
                    {
                        sqlStringLine += ",";
                    }
                    //last item
                    // ha az elem nem az első, akkor mindegyikhez hozzáadja az idegen kulcs hivatkozást,
                    //első elemnél csak zárójelet tesz a sor végére
                    if (item.Key != sqlTablaStrings.First().Key)
                    {
                        sqlStringLine += $"FOREIGN KEY (id) REFERENCES {sqlTablaStrings.First().Key}(id)";
                    }
                    else
                    {
                        sqlStringLine += ")";
                    }
                    //Listához ad
                    baseTableStrings.Add(sqlStringLine);
                }                
            }
            string tableName = chooseGame.TableDatas.ElementAt(0).Key;
           
            CreateSzadatokTablaString(tableName, "id",chooseGame.VibrationYConstantDivisor);
        }
        /*szadatok tábla létrehozása átadott értékek alapján*/
        private void CreateSzadatokTablaString(string foreignKeyTableName, string foreignKeyDatFieldName, int numberOfDatafields)
        {
            string sqlStringLine = "CREATE TABLE szadatok(id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,";
            for (int i = 1; i <= numberOfDatafields; i++)
            {
                sqlStringLine += "sz" + i.ToString() + "INT,";               
            }
            sqlStringLine += $"FOREIGN KEY (id) REFERENCES {foreignKeyTableName}({foreignKeyDatFieldName}))";
            baseTableStrings.Add(sqlStringLine);
        }


    }
}