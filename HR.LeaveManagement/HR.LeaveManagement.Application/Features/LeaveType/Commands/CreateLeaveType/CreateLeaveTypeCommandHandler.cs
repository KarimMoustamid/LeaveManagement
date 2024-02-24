using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data

            // convert to domain entity object
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request); // request => Domain.LeaveType 

            // add to database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);// Domain.LeaveType => DB  

            // return record id
            return leaveTypeToCreate.Id;
        }
    }
}
