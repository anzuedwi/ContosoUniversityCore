using ContosoUniversityCore.Test.Utility.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

namespace ContosoUniversityCore.Test.Utility.Extensions
{
    //Enum Helper Class Courtesy of Rikin Patel https://csharpsqllearning.blogspot.com/2013/12/get-display-name-of-enum.html
    public static class EnumHelper
    {

        // This extension method is broken out so you can use a similar pattern with 
        // other MetaData elements in the future. This is your base method for each.
        //In short this is generic method to get any type of attribute.
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes.FirstOrDefault();//attributes.Length > 0 ? (T)attributes[0] : null;
        }

        // This method creates a specific call to the above method, requesting the
        // Display MetaData attribute.
        //e.g. [Display(Name = "Sunday")]
        public static string GetDisplayName(this Enum value)
        {
            var attribute = value.GetAttribute<DisplayAttribute>();
            return attribute == null ? value.ToString() : attribute.Name;
        }

        // This method creates a specific call to the above method, requesting the
        // Description MetaData attribute.
        //e.g. [Description("Day of week. Sunday")]
        public static string GetDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
