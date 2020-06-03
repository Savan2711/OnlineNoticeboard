using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewOnlineNoticeBoard.Models
{
    public class TypeOfNotice
    {
        [Key]
        [Column(Order = 0)]
        public string NoticeType { get; set; }
        [Key]
        [Column(Order = 1)]
        public string Department { get; set; }
    }
}