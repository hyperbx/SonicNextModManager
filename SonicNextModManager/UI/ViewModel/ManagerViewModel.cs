namespace SonicNextModManager.UI.ViewModel
{
    /// <summary>
    /// View model for Manager.xaml
    /// </summary>
    public class ManagerViewModel
    {
        public Database Database { get; set; } = new();

        public void InvokeDatabaseContentUpdate()
            => Database = new Database();

        public void InvokeDatabaseActiveContentUpdate()
            => Database.Load();
    }
}
