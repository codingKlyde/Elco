public class AccountViewModel
{
    private static AccountViewModel instance;

    public string SetUID { get; set; }
    public string SetName { get; set; }
    public string SetEmail { get; set; }
    public string SetPhoneNumber { get; set; }
    public string SetPhotoURL { get; set; }
    public long SetCreationTimestamp { get; set; }

    private AccountViewModel() { }

    // Method to get or create the singleton instance
    public static AccountViewModel Instance
    {
        get
        {
            if (instance == null)
                instance = new AccountViewModel();
            return instance;
        }
    }
}
