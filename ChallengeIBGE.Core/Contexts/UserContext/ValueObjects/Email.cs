using ChallengeIBGE.Core.Contexts.SharedContext.Extensions;
using System.Text.RegularExpressions;

namespace ChallengeIBGE.Core.Contexts.SharedContext.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        protected Email() { }
        public Email(string address)
        {
            if(string.IsNullOrEmpty(address))
                throw new Exception("Invalid Email");

            Address = address.Trim().ToLower();

            if(address.Length == 5)
                throw new Exception("Invalid Email");

            if(!EmailRegex().IsMatch(address))
                throw new Exception("Invalid Email");
        }

        public string Address { get; set; } = string.Empty;
        public string HashAddress => Address.ToBase64();

        public static implicit operator string(Email email) => email.ToString();
        public static implicit operator Email(string address) => new(address);
        public override string ToString() => Address;

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
    }
}