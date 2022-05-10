using Ardalis.Specification;

namespace MyFinances.Core.Aggregates.Specifications
{
    public class FindByLoginAndPasswordSpec : Specification<User>, ISingleResultSpecification
    {
        public FindByLoginAndPasswordSpec(string username, string password)
        {
            Query.
                Where(user => user.Username == username
                && user.Password == password);
        }
    }
}
