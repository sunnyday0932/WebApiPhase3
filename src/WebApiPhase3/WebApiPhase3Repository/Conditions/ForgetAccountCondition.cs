using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiPhase3Repository.Conditions
{
    public class ForgetAccountCondition
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Account { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// 異動日期
        /// </summary>
        [Required]
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// 異動者
        /// </summary>
        [Required]
        [StringLength(30)]
        public string ModifyUser { get; set; }
    }
}
