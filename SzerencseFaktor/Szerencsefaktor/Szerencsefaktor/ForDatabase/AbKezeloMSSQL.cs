using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Szerencsefaktor.ForDatabase
{
    static class AbKezeloMSSQL
    {
        private static SqlConnection connection;
        private static SqlCommand command;
        static AbKezeloMSSQL()
        {
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SzerencseFaktor"].ConnectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new AbException("A csatlakozás sikertelen volt!", ex);
            }

        }
        public static void DisconnectFromDatabase()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {

                throw new AbException("A kapcsolat bontása sikertelen!", ex);
            }
        }
        public static bool DoesTheTableExist(string tablaNeve)
        {
            string strCheckTable = string.Format("IF OBJECT_ID('{0}', 'U') IS NOT NULL SELECT 'true' ELSE SELECT 'false'", tablaNeve);
            SqlCommand command = new SqlCommand(strCheckTable, connection);
            command.CommandType = System.Data.CommandType.Text;
            return Convert.ToBoolean(command.ExecuteScalar());
        }
        public static int CreatingDataTable(string tableCode)
        {
            string[] tableCodeString = tableCode.Split(' ');
            int response = 0;
            try
            {
                if (!AbKezeloMSSQL.DoesTheTableExist(tableCodeString[2]))
                {
                    command = new SqlCommand(tableCode, connection);
                    response = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw new AbException("A táblák létrehozása sikertelen!", ex);
            }
            return response;
        }
        //Uploading the Base index table 
        public static void UploadingAPlayedIndexDataTable(string[] aRow)
        {
            string sqlCommandString = "INSERT INTO [megjatszottIndex] VALUES(@iszam, @fszam, @kombszam, @aljatek)";
            try
            {
                command = new SqlCommand(sqlCommandString, connection);
                command.Parameters.AddWithValue("@iszam", aRow[0]);
                command.Parameters.AddWithValue("@fszam", Convert.ToByte(aRow[1]));
                command.Parameters.AddWithValue("@kombszam", Convert.ToByte(aRow[2]));
                command.Parameters.AddWithValue("@aljatek", Convert.ToInt32(aRow[3]));
            }
            catch (Exception ex)
            {

                throw new AbException("Hiba az adatfelvitel közben!", ex);
            }
        }
        public static void UploadingAResultIndexTable(string[] aRow)
        {
            string sqlCommandString = "INSERT INTO [talalatiIndex] VALUES(@isz, @fix, @komb, @tal1, @tal2, @tal3, @tal4)";
            try
            {
                command = new SqlCommand(sqlCommandString, connection);
                command.Parameters.AddWithValue("@isz", aRow[0]);
                command.Parameters.AddWithValue("@fix", Convert.ToByte(aRow[1]));
                command.Parameters.AddWithValue("@komb", Convert.ToByte(aRow[2]));
                command.Parameters.AddWithValue("@tal1", Convert.ToInt32(aRow[3]));
                command.Parameters.AddWithValue("@tal2", Convert.ToInt32(aRow[4]));
                command.Parameters.AddWithValue("@tal3", Convert.ToInt32(aRow[5]));
                command.Parameters.AddWithValue("@tal4", Convert.ToInt32(aRow[6]));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new AbException("A találati indextábla feltöltése sikertelen!", ex);
            }
        }
        //Uploading the Keno index tables
        public static void UploadingPlayedKenoIndexTable(string[] aRow)
        {
            string sqlCommandString = "INSERT INTO [magjatszottIndex] VALUES(@isz, @jatekTipus, @jelolesekSzama, @szammezokSzama, @alapDbSzorzo1, @alapDbSzorzo2, @alapDbSzorzo3, @alapDbSzorzo4, @alapDbSzorzo5)";
            try
            {
                command = new SqlCommand(sqlCommandString, connection);
                command.Parameters.AddWithValue("@isz", Convert.ToInt32(aRow[0]));
                command.Parameters.AddWithValue("@jatekTipus", aRow[1]);
                command.Parameters.AddWithValue("@jelolesekSzama", Convert.ToByte(aRow[2]));
                command.Parameters.AddWithValue("@szammezokSzama", Convert.ToInt32(aRow[3]));
                command.Parameters.AddWithValue("@alapDbSzorzo1", Convert.ToInt32(aRow[4]));
                command.Parameters.AddWithValue("@alapDbSzorzo2", Convert.ToInt32(aRow[5]));
                command.Parameters.AddWithValue("@alapDbSzorzo3", Convert.ToInt32(aRow[6]));
                command.Parameters.AddWithValue("@alapDbSzorzo4", Convert.ToInt32(aRow[7]));
                command.Parameters.AddWithValue("@alapDbSzorzo5", Convert.ToInt32(aRow[8]));
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void UploadingKenoOddsIndexTable(string[] aRow)
        {
            string sqlCommanString = "INSERT INTO [nyeremenySzorzo] VALUES(@isz, @talSzam, @nyHa1X, @nyHa2X, @nyHa3X, @nyHa4X, @nyHa5X)";
            try
            {
                command = new SqlCommand(sqlCommanString, connection);
                command.Parameters.AddWithValue("@isz", Convert.ToInt32(aRow[0]));
                command.Parameters.AddWithValue("@talSzam", Convert.ToByte(aRow[1]));
                command.Parameters.AddWithValue("@nyHa1X", Convert.ToInt32(aRow[2]));
                command.Parameters.AddWithValue("@nyHa2X", Convert.ToInt32(aRow[3]));
                command.Parameters.AddWithValue("@nyHa3X", Convert.ToInt32(aRow[4]));
                command.Parameters.AddWithValue("@nyHa4X", Convert.ToInt32(aRow[5]));
                command.Parameters.AddWithValue("@nyHa5X", Convert.ToInt32(aRow[6]));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new AbException("A Kenó 'nyeremenySzorzo' tábla feltöltése nem sikerült!", ex);
            }
        }
        public static void UploadingKenoWinningFieldMultiplierTable(string[] aRow)
        {
            string sqlCommandString = "INSERT INTO [nyertesMezoSzorzo] VALUES(" +
                "@jTipus, ";
            for (int i = 10; i >= 1; i--)
            {
                sqlCommandString += "@nyMsz" + i.ToString();
                if (i > 1)
                {
                    sqlCommandString += ",";
                }
                else
                {
                    sqlCommandString += ")";
                }
            }

            string[] fieldsNames = sqlCommandString.Split(',');
            int x = 1;
            try
            {
                command = new SqlCommand(sqlCommandString, connection);
                command.Parameters.AddWithValue("@jTipus", aRow[0]);
                for (int i = 10; i > 1; i--)
                {
                    command.Parameters.AddWithValue("@nyMsz" + i.ToString(), aRow[x]);
                    x++;
                }
            }
            catch (Exception ex)
            {
                throw new AbException("A Kenó 'nyertesMezoSzorzo' tábla feltöltése nem sikerült!", ex);
            }
        }
        public static void UploadingNumberOfWinningNumberFieldsIntheWinningClass(string[] aRow)
        {
            int x = 1;
            string sqlCommandString = "INSERET INTO [nyeroOsztalybaEsoNyertesSzammezokSzama] VALUES(" +
                "@iSzam," +
                "@jTipus," +
                "@talSzam,";
            for (int i = 10; i > 1; i--)
            {
                sqlCommandString += "@nyMSz" + i.ToString();
                if (i > 1)
                {
                    sqlCommandString += ", ";
                }
                else
                {
                    sqlCommandString += ")";
                }
            }
            try
            {
                command = new SqlCommand(sqlCommandString, connection);
                command.Parameters.AddWithValue("@iSzam", Convert.ToInt32(aRow[0]));
                command.Parameters.AddWithValue("jTipus", aRow[1]);
                command.Parameters.AddWithValue("@talSzam", Convert.ToInt32(aRow[2]));
                for (int i = 10; i >= 1; i--)
                {
                    command.Parameters.AddWithValue("@nyMSz" + i.ToString(), Convert.ToInt32(aRow[x]));
                    x++;
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new AbException("A Kenó 'nyeroOsztalybaEsoNyertesSzammezokSzama' tábla feltöltése nem sikerült!", ex); ;
            }
        }

    }
}
