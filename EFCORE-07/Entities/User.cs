﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE_07.Entities
{
    //[Table("tblUsers")]
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
