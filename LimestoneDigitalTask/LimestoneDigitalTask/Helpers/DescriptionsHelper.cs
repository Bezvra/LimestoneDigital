using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using LimestoneDigitalTask.Attributes;

namespace LimestoneDigitalTask.Helpers
{
    public static class DescriptionsHelper
    {
        public static string GetLocalizedDescription(this Enum @enum)
        {
            if (@enum == null)
                return null;

            string description = @enum.ToString();

            FieldInfo fieldInfo = @enum.GetType().GetField(description);
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(LocalizedDescriptionAttribute), false);

            if (attributes.Any())
                return attributes[0].Description;

            return description;
        }
    }
}