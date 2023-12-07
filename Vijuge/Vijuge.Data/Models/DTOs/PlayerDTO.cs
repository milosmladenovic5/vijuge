namespace Vijuge.Data.Models.DTOs
{
    public class PlayerDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserDTO User { get; set; }

        public bool LoggedIn { get; set; }
        public bool Playing { get; set; }
        public int Rank { get; set; }
        public double PointsCollected { get; set; }  
    }
}
