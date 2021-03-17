using System.ComponentModel.DataAnnotations;

namespace WebApiPhase3Service.InfoModels
{
    public class RemoveAccountInfoModel
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
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 信箱
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Email { get; set; }
    }
}
