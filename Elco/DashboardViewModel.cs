public class DashboardViewModel
{
    private static DashboardViewModel instance;

    public string SetName { get; set; }
    public string SetEmail { get; set; }
    public string SetPhotoURL { get; set; }

    private DashboardViewModel() { }

    // Method to get or create the singleton instance
    public static DashboardViewModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DashboardViewModel();
            }
            return instance;
        }
    }
}
