﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BomTool
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class AutoRegisterTypeAttribute : Attribute
    {
        public string Uri { get; set; } = "DotNet";

        public int MajorVersion { get; set; } = 1;

        public int MinorVersion { get; set; } = 0;

        public bool IsSingleton { get; set; } = false;

        public AutoRegisterTypeAttribute()
        {

        }

        public AutoRegisterTypeAttribute(string uri) : this(uri, false)
        {

        }

        public AutoRegisterTypeAttribute(bool isSingleton) : this("DotNet", isSingleton)
        {

        }

        public AutoRegisterTypeAttribute(string uri, bool isSingleton)
        {
            this.Uri = uri;
            this.IsSingleton = isSingleton;
        }

      
    }
}
