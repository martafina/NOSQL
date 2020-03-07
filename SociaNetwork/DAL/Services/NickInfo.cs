using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    [DataContract]
    public class NickInfo
    {
        [DataMember]
        public string Nickname { get; set; }

        public NickInfo()
        {

        }
        public NickInfo(string NickName)
        {
            this.Nickname = NickName;
        }
    }
}
