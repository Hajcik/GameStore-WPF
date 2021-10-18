using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore_WPF.Models
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
