using AutoMapper;
using TestProject.DataAccess.Abstraction.Repositories;
using TestProject.DataAccess.Abstraction;
using TestProject.Domain.Dtos;
using TestProject.Domain.Entities;
using TestProject.Services.Abstraction;

namespace TestProject.Services;

public class VisitService : IVisitService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWorkFactory _unitOfWorkFactory;

    public VisitService(
        IMapper mapper,
        IUnitOfWorkFactory unitOfWorkFactory)
    {
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public async Task<List<VisitDto>> GetAllAsync()
    {
        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var visitRepository = uow.GetRepository<IVisitRepository>();

            var visits = await visitRepository.GetAllAsync();

            return _mapper.Map<List<VisitDto>>(visits);
        }
    }

    public async Task CreateAsync(VisitDto visitDto)
    {
        ArgumentNullException.ThrowIfNull(visitDto);

        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var visitRepository = uow.GetRepository<IVisitRepository>();

            var visit = _mapper.Map<Visit>(visitDto);

            visitRepository.Add(visit);
            await uow.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(int id, VisitDto visitDto)
    {
        ArgumentNullException.ThrowIfNull(visitDto);

        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var visitRepository = uow.GetRepository<IVisitRepository>();
            var visit = await visitRepository.GetByIdAsync(id);

            if (visit is null)
            {
                throw new ApplicationException();
            }

            _mapper.Map(visitDto, visit);

            visitRepository.Update(visit);
            await uow.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var visitRepository = uow.GetRepository<IVisitRepository>();
            var visit = await visitRepository.GetByIdAsync(id);

            if (visit is null)
            {
                throw new ApplicationException();
            }

            visitRepository.Remove(visit);
            await uow.SaveChangesAsync();
        }
    }
}