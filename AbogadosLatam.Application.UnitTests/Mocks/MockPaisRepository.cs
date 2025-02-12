using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Domain;
using Moq;

namespace AbogadosLatam.Application.UnitTests.Mocks;

public class MockPaisRepository
{
    public static Mock<IPaisQueryRepository> GetMockPaisRepository()
    {

        var paises = new List<Pais>
        {
            new Pais
            {
                Id = 1,
                Nombre = "Ecuador"
            },
            new Pais
            {
                Id = 2,
                Nombre = "Colombia"
            },
            new Pais
            {
                Id = 3,
                Nombre = "Venezuela"
            }
        };

        var mockRepo = new Mock<IPaisQueryRepository>();
        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(paises);
        
        /*mockRepo.Setup(r => r.CreateAsync(It.IsAny<Pais>()))
            .Returns((Pais pais) =>
            {
                paises.Add(pais);
                return Task.CompletedTask;
            });
        
        // Invocamos CreateAsync durante la configuración inicial del mock
        mockRepo.Object.CreateAsync(new Pais
        {
            Id = 4,
            Nombre = "Chile"
        }).Wait(); */
        
        return mockRepo;
    }
}