using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zillow.Servises.Servises.File
{
  public  interface IFileServises
    {
        Task<string> SaveFile(IFormFile file, string folderName);
    }
}
