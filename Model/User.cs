namespace Model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // 'Admin' or 'Cashier'
        public bool IsActive { get; set; }
    }
}