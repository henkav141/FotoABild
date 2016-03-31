using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Pdf;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using File = Java.IO.File;

namespace FotoABIld.Droid
{
    public class PdfCreator
    {
        public void CreateDocument(View v)
        {
            var pdfDoc = new PdfDocument();

            PdfDocument.PageInfo pageinfo = new PdfDocument.PageInfo.Builder(v.MeasuredWidth, v.MeasuredHeight, 1).Create();
            
            var page = pdfDoc.StartPage(pageinfo);
            
            v.Draw(page.Canvas);

            pdfDoc.FinishPage(page);
            
            var path = Android.OS.Environment.ExternalStorageDirectory + "/hej.pdf";

            try
            {

                var outputstream = new FileStream(path,FileMode.Create,FileAccess.Write,FileShare.Write);
                pdfDoc.WriteTo(outputstream);
                pdfDoc.Close();
                outputstream.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Problem with creating pdf");
            }


        }
    }
}