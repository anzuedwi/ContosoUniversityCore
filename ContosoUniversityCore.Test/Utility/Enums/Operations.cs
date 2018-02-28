using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContosoUniversityCore.Test.Utility.Enums
{
    public enum Operations
    {
        [Display(Name ="+")]
        Add,

        [Display(Name = "-")]
        Subtract,

        [Display(Name = "*")]
        Multiply,

        [Display(Name = "/")]
        Divide,

        [Display(Name = "%")]
        Modulus
    }
}
