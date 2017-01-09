using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebModels.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
   
        ///<summary>
        ///最后修改时间
        /// </summary>
        public DateTime LastDate { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary>

      
        public int webComId { get; set; }

    }
}
