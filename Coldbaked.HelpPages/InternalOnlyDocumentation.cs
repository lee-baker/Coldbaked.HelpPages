using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coldbaked.HelpPages
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class InternalOnlyDocumentationAttribute : Attribute
    {      
    }
}