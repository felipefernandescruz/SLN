using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;
using Resenha.Model;

namespace Authentication.Model
{

    [Table("tbl_User_Login")]
    public class UserLogin
    {
        [Key]
        [Column("cd_user_login_id")]
        public int userLoginId { get; set; }

        [MaxLength(20)]
        [Column("ds_username")]
        public string userName { get; set; }

        [DataType(DataType.Password), MaxLengthAttribute(16)]
        [Column("ds_password")]
        [Required]
        public string password { get; set; }

        [DataType(DataType.Password), MaxLengthAttribute(16)]
        [NotMapped]
        [Required]
        public string confirmPassword { get; set; }

        [Column("cd_origin_access")]
        public int originAccess { get; set; }

        public virtual OriginAccess origin { get; set; }
    }

    [Table("tbl_User")]
    public class User
    {
        [Key]
        [Column("cd_user_id")]
        public int userId { get; set; }

        [Column("cd_facebook")]
        public int idFacebook { get; set; }

        [MaxLength(15)]
        [Column("ds_first_name")]
        [Required]
        public string firstName { get; set; }

        [MaxLength(15)]
        [Column("ds_last_name")]
        [Required]
        public string lastName { get; set; }

        [DataType(DataType.EmailAddress), MaxLength(32)]
        [Column("ds_email")]
        [Required]
        public string email { get; set; }

        [DataType(DataType.DateTime)]
        [Column("dt_cadastro")]
        public DateTime dtRegister { get; set; }

        [Column("cd_user_Login")]
        public int userLoginId { get; set; }

        public virtual UserLogin userLogin { get; set; }

    }

    [Table("tbl_Origin_Access")]
    public class OriginAccess
    {
        [Key]
        [Column("cd_origin_access")]
        public int originAccessID { get; set; }

        [Column("ds_origin")]
        public string originAccess { get; set; }

    }
}
