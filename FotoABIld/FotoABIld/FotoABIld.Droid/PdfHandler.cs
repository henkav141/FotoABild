using System;
using System.IO;
using Android.Graphics.Pdf;
using Android.Views;

namespace FotoABIld.Droid
{
    public class PdfHandler
    {
        //Creates a PDFdocument out of a Receipt View to save to the externalstoragedirectory
        public void CreateDocument(View v)
        {
            var pdfDoc = new PdfDocument();

            PdfDocument.PageInfo pageinfo = new PdfDocument.PageInfo.Builder(v.MeasuredWidth, v.MeasuredHeight, 1).Create();
            
            var page = pdfDoc.StartPage(pageinfo);
            
            v.Draw(page.Canvas);

            pdfDoc.FinishPage(page);
            
            var path = Android.OS.Environment.ExternalStorageDirectory + "/test.pdf";

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