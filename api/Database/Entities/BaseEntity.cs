using System.ComponentModel.DataAnnotations;

namespace api.Database.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}
