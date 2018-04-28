using Bamboo.Util.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Bamboo.Core.Constants;

namespace Bamboo.Util
{
    public static class FileHelper
    {
        public static IFormFile ConvertBase64ToIFormFile(string base64Content)
        {
            FormFile formFile = null;

            if (!string.IsNullOrWhiteSpace(base64Content))
            {
                var base64 = base64Content.Split(',');
                var byteArray = Convert.FromBase64String(base64[base64.Length - 1]);

                Stream stream = new MemoryStream(byteArray);

                formFile = new FormFile(stream, 0, stream.Length, Guid.NewGuid().ToString("N"), Guid.NewGuid().ToString("N"));
            }

            return formFile;
        }

        public static Task SaveFile(string base64,ref string fileName, string path)
        {
            //  Check filePath
            path = Const.EnvironmentDerectory + path;
            if (!Directory.Exists(path))
                throw new BambooException(Core.Constants.ErrorCode.PathInvalid);

            var extension = Path.GetExtension(fileName);
            fileName = Guid.NewGuid() + extension;

            var pathSave = Path.Combine(path, fileName);

            var bytes = Convert.FromBase64String(base64);
            using (var file = new FileStream(pathSave, FileMode.Create))
            {
                file.Write(bytes, 0, bytes.Length);
                file.Flush();
            }


            return Task.CompletedTask;
        }
    }
}
