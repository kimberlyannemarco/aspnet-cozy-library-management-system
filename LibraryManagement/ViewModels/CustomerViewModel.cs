// CustomerViewModel.cs
namespace LibraryManagement.ViewModels
{
    public class CustomerViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BranchName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string AcctOpenDate{ get; set; }
    }
}
