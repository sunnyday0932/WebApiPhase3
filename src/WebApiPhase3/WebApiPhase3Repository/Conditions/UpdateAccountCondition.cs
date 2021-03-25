using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiPhase3Repository.Conditions
{
    public class UpdateAccountCondition
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Account { get; set; }

        /// <summary>
        /// 電話號碼
        /// </summary>
        [StringLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 信箱
        /// </summary>
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// 異動日期
        /// </summary>
        [Required]
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// 異動者
        /// </summary>
        [Required]
        [StringLength(30)]
        public string ModifyUser { get; set; }
    }
}
