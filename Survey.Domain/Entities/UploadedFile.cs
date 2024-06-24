using Microsoft.VisualBasic.FileIO;
using Survey.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class UploadedFile : Entity
    {
        public string Name { get; set; } = string.Empty;
        public long Size { get; set; }
        public string Url { get; set; } = string.Empty;
        public FileType FileType { get; set; }

        //Foreign Key
        public int MemberId { get; set; }

        //Nav Properties
        public Member? Member { get; set; }
    }
}
