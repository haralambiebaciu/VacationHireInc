using Application.Abstractions.Messaging;

namespace Application.User.Queries.GetUserById
{
    public class GetUserQuery : IQuery<UserResponse>
    {
        public Guid Id { get; set; }
    }
}
