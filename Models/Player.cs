namespace VideoSmartApi.Models
{
    public class Player
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public bool? IsTracked { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
