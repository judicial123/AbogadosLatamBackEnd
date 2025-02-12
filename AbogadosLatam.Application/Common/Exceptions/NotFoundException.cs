namespace AbogadosLatam.Application.MappingProfiles.Exceptions;

public class NotFoundException: Exception
{
    public NotFoundException(string name, object key):base($"The entity with {name} or {key} was not found.")
    {
        
    }
}