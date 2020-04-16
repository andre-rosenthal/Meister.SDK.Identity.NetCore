using System;
using System.ComponentModel.DataAnnotations;

namespace Meister.SDK.Identity.NetCore.Models
{
    public class MeisterConnection
    {
        public enum AuthenticationMethods
        {
            Basic,
            SSO,
            OAuth,
            Kerberos,
            SAML2,
            ActiveDirectory
        }
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Uri Gateway { get; set; }
        public string Client { get; set; }
        [Required]
        public string SAPUser { get; set; }
        public byte[] SAPPassword { get; set; }
        [Required]
        public AuthenticationMethods Authentication { get; set; }
    }
}
