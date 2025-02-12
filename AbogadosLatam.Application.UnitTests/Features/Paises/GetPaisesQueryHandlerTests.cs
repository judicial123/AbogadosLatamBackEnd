using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Pais;
using AbogadosLatam.Application.MappingProfiles;
using AbogadosLatam.Application.UnitTests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace AbogadosLatam.Application.UnitTests.Features.Paises;

public class GetPaisesQueryHandlerTests
{
    private readonly Mock<IPaisQueryRepository> _mockRepo;
    private IMapper _mapper;

    public GetPaisesQueryHandlerTests()
    {
        _mockRepo = MockPaisRepository.GetMockPaisRepository();
        
        var mapperConfig = new MapperConfiguration(c => {
            c.AddProfile<PaisProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }
    
    [Fact]
    public async Task GetPaisesTest()
    {
        var handler = new GetPaisesQueryHandler(_mapper, _mockRepo.Object);

        var result = await handler.Handle(new GetPaisesQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<PaisDto>>();
        result.Count.ShouldBe(4);
    }
}