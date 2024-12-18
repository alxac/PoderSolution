using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public abstract class BaseEntity
    {
        private Guid _id;

        [Key]
        public Guid Id
        {
            get { return _id == Guid.Empty ? _id = Guid.NewGuid() : _id; }
            set { _id = value == Guid.Empty ? Guid.NewGuid() : value; }
        }

        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value ?? DateTime.UtcNow; }
        }
        public DateTime? UpdatedAt { get; set; }
    }
}
