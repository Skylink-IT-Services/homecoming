using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homecoming.api.Abstraction
{
    public interface IFileUpload<T>
    {
        public string UploadFile(IFormFile file);
        public bool MultiFileUpload(T objectFile);
    }
}
