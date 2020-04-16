﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BomTool.Models
{
    public class ExcelData
    {
        public string Reference { get; set; }

        public string Code { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public List<string> Lines { get; set; } = new List<string>();
    }
}
