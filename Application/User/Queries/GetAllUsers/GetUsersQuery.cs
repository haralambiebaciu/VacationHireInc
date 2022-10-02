using Application.Abstractions.Messaging;

namespace Application.User.Queries.GetAllUsers
{
    public class GetUsersQuery : IQuery<IEnumerable<UserResponse>>
    {
    }
}
