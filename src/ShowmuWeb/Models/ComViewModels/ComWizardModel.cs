using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShowmuWeb.Models.ComViewModels
{
    public class ComWizardModel
    {
       
        [Required]
        [StringLength(50)]
        [Display(Name = "公司或连锁名")]
        public string ComName { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>

        [Display(Name = "地址")]
        public string DetailAddress { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name = "联系电话")]
        public string Tel { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [Display(Name = "联系人")]
        public string Name { get; set; }

        /// <summary>
        /// 联系人证件号
        /// </summary>
        [Display(Name = "联系人身份证号")]
        public string Pid { get; set; }
    }
}
