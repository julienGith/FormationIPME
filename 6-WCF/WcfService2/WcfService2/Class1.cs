using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService2
{
    [DataContract]
    public class Class1
    {
        [DataMember]
        public string Name { get; set; }
    }
}