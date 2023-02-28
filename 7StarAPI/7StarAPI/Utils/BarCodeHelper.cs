using SevenStarDtos.DTOs;
using SevenStarFramework.Services.Interfaces;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;

namespace SevenStar.Utils
{
    public class BarCodeHelper : ControllerBase
  { 
      Byte[] b;
     public async  Task<string> BarCode(IWebHostEnvironment webHostEnvironment,string QRId ,string myfile,string location, string ConcatLocation)
     { 
      string uniqueFileName = null;
      string returnPath = ""; 
      var path = Path.Combine(webHostEnvironment.ContentRootPath, location);
      uniqueFileName = Guid.NewGuid().ToString() + "_" + myfile;
      if ((Directory.Exists(path)) == false)
      {
        DirectoryInfo di = Directory.CreateDirectory(path);
      }
      path = string.Concat("/" + location+"/", uniqueFileName);  
      Zen.Barcode.Code128BarcodeDraw brcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
      MemoryStream ms = new MemoryStream();
      brcode.Draw(QRId, 100).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
      ms.ToArray();
      Image image; 
      var file = File(ms.ToArray(), "image/jpeg", path).FileContents;
      image = Bitmap.FromStream(ms);
      path = Path.Combine(webHostEnvironment.ContentRootPath, location, uniqueFileName);
      FileStream file1 = new FileStream(path, FileMode.Create, FileAccess.Write);
      ms.WriteTo(file1);
      file1.Close();
      ms.Close(); 
      returnPath = $"{ConcatLocation}/{uniqueFileName}"; 
      return (returnPath);
    }

  }
}
