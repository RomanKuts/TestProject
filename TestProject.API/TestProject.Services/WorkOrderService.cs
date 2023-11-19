using AutoMapper;
using TestProject.DataAccess.Abstraction;
using TestProject.DataAccess.Abstraction.Repositories;
using TestProject.Domain.Dtos;
using TestProject.Domain.Entities;
using TestProject.Services.Abstraction;

namespace TestProject.Services;

public class WorkOrderService : IWorkOrderService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWorkFactory _unitOfWorkFactory;

    public WorkOrderService(
        IMapper mapper,
        IUnitOfWorkFactory unitOfWorkFactory)
    {
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public async Task<List<WorkOrderDto>> GetAllAsync()
    {
        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var workOrderRepository = uow.GetRepository<IWorkOrderRepository>();

            var workOrders = await workOrderRepository.GetAllAsync();

            if (!workOrders.Any())
            {
                for (int i = 0; i < 50; i++)
                {
                    var workOrder = new WorkOrder()
                    {
                        Name = $"Test Work Order - {i + 1}",
                        Visits = new()
                    };

                    for (int j = 0; j < Random.Shared.Next(0, 3); j++)
                    {
                        var visit = new Visit
                        {
                            Name = $"Test visitor - {j + 1}",
                            Parts = new()
                        };

                        for (int k = 0; k < Random.Shared.Next(1, 5); k++)
                        {
                            var part = new Part
                            {
                                Name = $"Test part - {k + 1}",
                                Price = Random.Shared.Next(0, 100),
                                Quantity = Random.Shared.Next(0, 10),
                            };

                            visit.Parts.Add(part);
                        }

                        workOrder.Visits.Add(visit);
                    }

                    workOrders.Add(workOrder);
                }

                workOrderRepository.AddRange(workOrders);
                await uow.SaveChangesAsync();
            }

            return _mapper.Map<List<WorkOrderDto>>(workOrders);
        }
    }

    public async Task CreateAsync(WorkOrderDto workOrderDto)
    {
        ArgumentNullException.ThrowIfNull(workOrderDto);

        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var workOrderRepository = uow.GetRepository<IWorkOrderRepository>();

            var workOrder = _mapper.Map<WorkOrder>(workOrderDto);

            workOrderRepository.Add(workOrder);
            await uow.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(int id, WorkOrderDto workOrderDto)
    {
        ArgumentNullException.ThrowIfNull(workOrderDto);

        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var workOrderRepository = uow.GetRepository<IWorkOrderRepository>();
            var workOrder = await workOrderRepository.GetByIdAsync(id);

            if (workOrder is null)
            {
                throw new ApplicationException();
            }

            _mapper.Map(workOrderDto, workOrder);

            workOrderRepository.Update(workOrder);
            await uow.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var workOrderRepository = uow.GetRepository<IWorkOrderRepository>();
            var workOrder = await workOrderRepository.GetByIdAsync(id);

            if (workOrder is null)
            {
                throw new ApplicationException();
            }

            workOrderRepository.Remove(workOrder);
            await uow.SaveChangesAsync();
        }
    }
}