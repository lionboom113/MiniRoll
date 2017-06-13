using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    /// <summary>
    /// <para>ユーザー権限を表すEntity.</para>
    /// </summary>
    public class Role
    {
        /// <summary>
        /// <para>ID</para>
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// <para>アクセス可能なController名.</para>
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// <para>アクセス可能なAction名.</para>
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// <para>書き込み可能かどうか.</para>
        /// </summary>
        public bool IsWritable { get; set; }
    }
}
