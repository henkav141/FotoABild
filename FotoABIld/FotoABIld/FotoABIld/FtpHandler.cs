using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;

namespace FotoABIld
{
    public static class FtpHandler
    {
        public static void Ftp(string file)
        {
            
            //// Get the object used to communicate with the server.
            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("A-Bild@155.4.33.113/home/FotoabildAppTest");
            //request.Method = WebRequestMethods.Ftp.UploadFile;

            //request.Credentials = new NetworkCredential("A-Bild", "Pontus1");

            //// Copy the contents of the file to the request stream.
            //StreamReader sourceStream = new StreamReader(file);
            //byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            //sourceStream.Close();
            //request.ContentLength = fileContents.Length;

            
            //Stream requestStream = request.GetRequestStream();
            //requestStream.Write(fileContents, 0, fileContents.Length);
            //requestStream.Close();

            //FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            //Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

            //response.Close();

            string ftpHost = "xxxx";

            string ftpUser = "A-Bild";

            string ftpPassword = "Pontus1";

            string ftpfullpath = "ftp://A-Bild@155.4.33.113:21/home/FotoabildAppTest";

            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);

            //userid and password for the ftp server  
            ftp.UsePassive = false;
            ftp.Credentials = new NetworkCredential(ftpUser, ftpPassword);

            ftp.KeepAlive = false;
            ftp.UseBinary = true;
            ftp.Method = WebRequestMethods.Ftp.UploadFile;

            FileStream fs = File.OpenRead(file);

            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);

            fs.Close();

            Stream ftpstream = ftp.GetRequestStream();
            ftpstream.Write(buffer, 0, buffer.Length);
            ftpstream.Close();
            ftpstream.Flush();

            //  fs.Flush();

        }
    }
    }

