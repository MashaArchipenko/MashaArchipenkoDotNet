using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Lab1.Models
{
    public enum FileFormat
    {
        [Description("json")]
        Json,
        [Description("xls")]
        Excel,
    }
}
