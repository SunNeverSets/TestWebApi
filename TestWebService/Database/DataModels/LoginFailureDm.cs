using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebService.Database.DataModels
{
    [Table("table_login", Schema = "login")]
    [PrimaryKey(nameof(Id))]
    public class LoginFailureDm
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("userName")]
        public string UserName { get; set; }

        [Column("failureCount")]
        public int FailureCount { get; set; }
    }
}