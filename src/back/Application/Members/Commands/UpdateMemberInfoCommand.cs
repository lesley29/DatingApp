using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Persistence;
using Application.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Members.Commands
{
    public class UpdateMemberInfoCommand : IRequest
    {
        public UpdateMemberInfoCommand(IAuthenticatedUser authenticatedUser, string? briefDescription, string? lookingFor,
            string? interests, string? city, string? country)
        {
            AuthenticatedUserName = authenticatedUser.Username;
            BriefDescription = briefDescription;
            LookingFor = lookingFor;
            Interests = interests;
            City = city;
            Country = country;
        }

        public string AuthenticatedUserName { get; }

        public string? BriefDescription { get; }

        public string? LookingFor { get; }

        public string? Interests { get; }

        public string? City { get; }

        public string? Country { get; }
    }

    internal class UpdateMemberInfoCommandHandler : AsyncRequestHandler<UpdateMemberInfoCommand>
    {
        private readonly IDatingAppDbContext _dbContext;

        public UpdateMemberInfoCommandHandler(IDatingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task Handle(UpdateMemberInfoCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Name == request.AuthenticatedUserName, cancellationToken);

            if (user == null)
            {
                throw new ResourceNotFoundException();
            }

            user.UpdateInfo(request.BriefDescription, request.LookingFor, request.Interests, request.City, request.Country);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
