using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTask.ServiceProvider.Models
{
    public class ProfileData
    {
        public string MailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AvatarSasUrl { get; set; }
        public List<string> Roles { get; set; }
    }
}
