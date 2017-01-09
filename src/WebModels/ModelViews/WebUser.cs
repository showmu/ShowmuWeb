using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebModels.ModelViews
{
    public class WebUser
    {

        ///<summary>
        ///用户ID
        ///</summary>
     

        public string   Id { get; set; }
        public string userName { get; set; }
        public string roleName { get; set; }

        public string phoneNumber { get; set; }
        public string eMail { get; set; }

    }
}
