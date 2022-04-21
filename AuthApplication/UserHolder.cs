using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApplication
{
    [Serializable]
    public class UserHolder
    {
        private user? _userObj;
        public user UserObj { get => _userObj; set => _userObj = value; }
    }
}
