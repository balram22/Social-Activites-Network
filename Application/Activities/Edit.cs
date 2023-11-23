using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Persistence;

namespace Application;

public class Edit
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
        public Activity Activity { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(request.Id);
            request.Activity.Id = request.Id;

            _mapper.Map(request.Activity, activity);
            
            await _context.SaveChangesAsync();
        }
    }
}
