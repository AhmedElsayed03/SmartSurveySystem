using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class Member : Entity
    {
        //public string FirstName { get; set; } = string.Empty; // Already Exists in Identity
        //public string LastName { get; set; } = string.Empty; // Already Exists in Identity
        public int Age { get; set; }
        public string Location { get; set; } = string.Empty;

        //public string Email { get; set; } = string.Empty; // Already Exists in Identity
        //public string UserName { get; set; } = string.Empty; // Already Exists in Identity
        //public string Password { get; set; } = string.Empty // Already Exists in Identity (Password Hash)

        public int UserId { get; set; } //Foreign Key from the Identity Table

        //Nav Property
        public IEnumerable<MemberSurvey> MemberSurveys { get; set; } = new List<MemberSurvey>();
        public IEnumerable<Submission> Submissions { get; set; } = new List<Submission>();
        public IEnumerable<FileUpload> Files { get; set; } = new List<FileUpload>();
    }
}
