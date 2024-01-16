﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE_07.Entities
{
    //[Table("tblComments")]
    public class Comment
    {
        //[Column("CommentId")] --- first way --
        public int Id { get; set; }
        public int TweetId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }

        public DateTime createdAt { get; set; }
    }
}
