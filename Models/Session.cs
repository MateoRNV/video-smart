using System.ComponentModel.DataAnnotations;

namespace VideoSmartApi.Models
{
    public class Session
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
