using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery , List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypesQueryHandler(IMapper _mapper , ILeaveTypeRepository leaveTypeRepository )
    {
        this._mapper = _mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    
    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAllAsync(); // Get From DB (Domain)
        
        var leaveTypeDtos = _mapper.Map<List<LeaveTypeDto>>(leaveTypes); // domain => DTO
        
        return leaveTypeDtos; // (Return DTO)
    }
}