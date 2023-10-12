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

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
    }
}