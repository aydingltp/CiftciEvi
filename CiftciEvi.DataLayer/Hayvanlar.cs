﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiftciEvi.DataLayer
{
    public class Hayvanlar
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public string Cins { get; set; }
        public int TopluSatis { get; set; }
        public Kategori Kategori { get; set; }
    }
}