namespace Vijuge.Data.Models.DTOs
{
    public class PlayerDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserDTO User { get; set; }

        public bool LoggedIn { get; set; }
        public int Rank { get; set; }
        public long PointsCollected { get; set; }
    }
}
