using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopModels.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public string OpenId { get; set; }
        /// <summary>
        /// 收件人姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 详细收货地址（目前仅限与榆林学院）
        /// </summary>
        public string DetailAddress { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 是否默认地址
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
