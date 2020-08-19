using System;
using System.Net;
using System.Net.Http;
using System.IO;

namespace DownloadingFileFromWeb
{
    public class FileLetoltesNetrol
    {
        #region Fields
        string fajlnev;
        string localFajlNev;
        int bufferSize;
        byte[] buffer;
        int bytesRead;

        #endregion
        #region Properties
        public string Fajlnev { get => fajlnev; set => fajlnev = value; }
        public int BufferSize { get => bufferSize; private set => bufferSize = value; }
        public byte[] Buffer { get => buffer; private set => buffer = value; }
        public int BytesRead { get => bytesRead; private set => bytesRead = value; }
        public string LocalFajlNev { get => localFajlNev; set => localFajlNev = value; }
        #endregion
        #region Constuctor
        public FileLetoltesNetrol()
        {
            bufferSize = 1024;
            buffer = new byte[BufferSize];
            bytesRead = 0;
        }
        #endregion
        #region other functions and methods
        public bool FajlLetoltese(string HonnanMitToltLe, string HovaMitMent)
        {
            Fajlnev = HonnanMitToltLe;
            LocalFajlNev = HovaMitMent;
            //A LocalFajlNev végéről leveszi a kiterjesztésta névhez hozzáad egy egy egyest majd visszarakja a fájl kiterjesztést és elmenti a fájlt.
            try
            {
                //1.Construct the HTTP get request to send to the web server.
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(Fajlnev);
                httpRequest.Method = WebRequestMethods.Http.Get;

                //2. Send the HTTP request and get the HTTP response from the web server.
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                Stream httpResponSetream = httpResponse.GetResponseStream();

                //3. Save the contents in the HTTP response to a local file.
                //int bufferSize = 1024;
                //byte[] buffer = new byte[bufferSize];
                //int bytesRead = 0;

                FileStream fileStream = File.Create(LocalFajlNev);
                while ((bytesRead = httpResponSetream.Read(buffer, 0, bufferSize)) != 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                };
                fileStream.Close();
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("A http kapcsolat nem jött létre! Hibakód:", ex);
                //0return false;
            }
            return true;
        }

        public long FajlMeretLekerdezes(string eleresiUtvonal)
        {
            try
            {
                //1 connect
                var webRequest = HttpWebRequest.Create(eleresiUtvonal);
                webRequest.Method = "HEAD";
                using (var webResponse = webRequest.GetResponse())
                {
                    var fileSize = webResponse.Headers.Get("Content-Length");
                    //var fileSizeInMegaByte = Math.Round(Convert.ToDouble(fileSize) / 1024.0 / 1024.0, 2);
                    //return fileSizeInMegaByte + " MB";
                    return Convert.ToInt32(fileSize);
                }
            }
            catch (Exception ex)
            {

                throw new HttpRequestException("A http kapcsolat nem jött létre vagy nem létezik a keresett fájl! Hibakód:", ex);
            }

            
        }
        #endregion
        /*
        //1.Construct the HTTP get request to send to the web server.
        //request - kérés,

        HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(textBox1.Text);
        httpRequest.Method = WebRequestMethods.Http.Get;

            //2. Send the HTTP request and get the HTTP response from the web server.
            //response - felelet, válasz
            //stream - folyamat
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        Stream httpResponSetream = httpResponse.GetResponseStream();

        //3. Save the contents in the HTTP response to a local file.
        int bufferSize = 1024;
        byte[] buffer = new byte[bufferSize];
        int bytesRead = 0;
        FileStream fileStream = File.Create("skandi.csv");
            while ((bytesRead = httpResponSetream.Read(buffer, 0, bufferSize)) !=0)
            {
                fileStream.Write(buffer, 0, bytesRead);
            };   
            fileStream.Close();
            */
        public bool LocalFajlLetezike(string utvonafajl)
        {
            if (File.Exists(utvonafajl))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public long LocalFajlMerete(string utvonalfajlnev)
        {
            long meret = new FileInfo(utvonalfajlnev).Length;
            if (meret != 0)
            {
                return meret;
            }
            else
            {
                throw new ArgumentException("A fajl nem létezik, vagy az elérési útvonalat hibásan adta meg!");
            }
        }
    }
}
