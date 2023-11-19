using AutoMapper;
using TestProject.DataAccess.Abstraction.Repositories;
using TestProject.DataAccess.Abstraction;
using TestProject.Domain.Dtos;
using TestProject.Domain.Entities;
using TestProject.Services.Abstraction;

namespace TestProject.Services;

public class PartService : IPartService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWorkFactory _unitOfWorkFactory;

    public PartService(
        IMapper mapper,
        IUnitOfWorkFactory unitOfWorkFactory)
    {
        _mapper = mapper;
        _unitOfWorkFactory = unitOfWorkFactory;
    }

    public async Task<List<PartDto>> GetAllAsync()
    {
        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var partRepository = uow.GetRepository<IPartRepository>();

            var parts = await partRepository.GetAllAsync();

            return _mapper.Map<List<PartDto>>(parts);
        }
    }

    public async Task CreateAsync(PartDto partDto)
    {
        ArgumentNullException.ThrowIfNull(partDto);

        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var partRepository = uow.GetRepository<IPartRepository>();

            var part = _mapper.Map<Part>(partDto);

            partRepository.Add(part);
            await uow.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(int id, PartDto partDto)
    {
        ArgumentNullException.ThrowIfNull(partDto);

        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var partRepository = uow.GetRepository<IPartRepository>();
            var part = await partRepository.GetByIdAsync(id);

            if (part is null)
            {
                throw new ApplicationException();
            }

            _mapper.Map(partDto, part);

            partRepository.Update(part);
            await uow.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
        {
            var partRepository = uow.GetRepository<IPartRepository>();
            var part = await partRepository.GetByIdAsync(id);

            if (part is null)
            {
                throw new ApplicationException();
            }

            partRepository.Remove(part);
            await uow.SaveChangesAsync();
        }
    }
}