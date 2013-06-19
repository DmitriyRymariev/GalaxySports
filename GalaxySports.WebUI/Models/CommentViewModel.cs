﻿using GalaxySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalaxySports.WebUI.Models
{
    public class CommentViewModel
    {
        public int CommentID { get; set; }

        public int ProductID { get; set; }

        public User User { get; set; }

        public string CommentText { get; set; }

        public DateTime Time { get; set; }
    }
}