using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Zillow.Servises.Servises.File
{
  public class FileServises: IFileServises
    {
        private readonly IWebHostEnvironment _evn;
        public FileServises(IWebHostEnvironment evn)
        {
            _evn = evn;
        }
    public async Task<string> SaveFile(IFormFile file,string folderName)
        {
            string fileName = null;
            if (file!=null &&file.Length>0)
            {
                var uploads = Path.Combine(_evn.WebRootPath, folderName);
                fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                await using var fileStrem = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                await file.CopyToAsync(fileStrem);
            }
            return fileName;
        }
    }
}
