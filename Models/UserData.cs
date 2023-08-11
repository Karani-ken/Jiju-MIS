using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jiju_MIS.Models
{
    public enum Role
    {
        admin = 1,
        user = 2
    }
    public class UserData
    {     
       
       
            public int Id { get; set; }
            public string userName { get; set; }
            public string password { get; set; }
            public Role Role { get; set; }
        
    }
}
