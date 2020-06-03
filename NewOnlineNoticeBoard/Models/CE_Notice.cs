using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewOnlineNoticeBoard.Models
{
    public class CE_Notice
    {
        [Key]
        public int NoticeId { get; set; }
        public string TitleOfNotice { get; set; }
        public string NoticeType { get; set; }
        public DateTime date { get; set; }
        public string FileName { get; set; }
    }
}