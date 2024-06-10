using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class FileUpload : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;

        //Foreign Key
        public int MemberId { get; set; }

        //Nav Properties
        public Member? Member { get; set; }
    }
}
