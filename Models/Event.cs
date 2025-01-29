using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VideoSmartApi.Models
{
    public class Event
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Session")]
        public Guid SessionId { get; set; }

        public Session Session { get; set; }

        public EventType Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
