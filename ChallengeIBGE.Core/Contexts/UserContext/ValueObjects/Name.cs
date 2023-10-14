using ChallengeIBGE.Core.Contexts.SharedContext.ValueObjects;

namespace ChallengeIBGE.Core.Contexts.UserContext.ValueObjects
{
    public class Name : ValueObject
    {
        protected Name() { }
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get;  set; } = string.Empty;
        public string LastName { get;  set; } = string.Empty;

        public override string ToString() => $"{FirstName} {LastName}"; 
    }
}