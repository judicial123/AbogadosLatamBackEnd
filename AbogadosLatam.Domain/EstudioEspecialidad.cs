using AbogadosLatam.Domain.Common;

namespace AbogadosLatam.Domain
{
    public class EstudioEspecialidad : BaseEntity
    {
        public int EstudioId { get; set; }
        public Estudio Estudio { get; set; }

        public int EspecialidadId { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}