using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewOnlineNoticeBoard.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}