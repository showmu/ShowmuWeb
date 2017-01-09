using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebModels.Models
{
    /// <summary>
    /// 店名，属于主用户（公司管理员），公司
    /// </summary>
    public class Web_Com
    {
        ///<summary>
        ///公司ID
        ///</summary>
        [Key]
        [Required]
        public int ComId { get; set; }

        ///<summary>
        ///公司ID
        ///</summary>
        [Required]
        [StringLength(50)]
        [Display(Name = "公司名称")]
        public string ComName { get; set; }


        /// <summary>
        /// 公司余额
        /// </summary>
        [Display(Name = "公司余额")]
       
        public decimal Money { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        [Display(Name = "数据库名")]
    
        public string  DbName { get; set; }
        /// <summary>
        /// 数据库版本
        /// </summary>
        [Display(Name = "数据库版本")]
    
        public int DbVer { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailAddress { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 联系人证件号
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// 建立时间
        /// </summary>
        public DateTime  InDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime EditDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual ApplicationUser CreateUser { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public virtual ApplicationUser EditUser { get; set; }

       

    }
}
