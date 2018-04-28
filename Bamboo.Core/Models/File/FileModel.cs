using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bamboo.Core.Models.File
{
    public class AddFileModel
    {
        public string FileName { get; set; }

        public string FileExtension => Path.GetExtension(FileName);

        public string ContentBase64 { get; set; }

        public string FileUrl { get; set; }
    }

    public class EditFileModel : AddFileModel
    {
        public int Id { get; set; }
    }

    public class FileModel : EditFileModel { }
}
