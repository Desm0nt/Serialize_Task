using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Serialize_Task
{
    [DataContract]
    [Serializable]
    public class Book
    {
        [DataMember]
        public string Bookname { get; set; }
        [DataMember]
        public string AFirstName { get; set; }
        [DataMember]
        public string ALastName { get; set; }
        [DataMember]
        public int PageCount { get; set; }
        [DataMember]
        public int PublishYear { get; set; }
    }
}
