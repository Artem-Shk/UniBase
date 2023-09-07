namespace UniBase.Models
{
    public class MenuItemModel
    {
        public string FaculityName { get; set; }
        public List<string> GroupName { get; set; }
      
        public MenuItemModel(string faculityName, List<string> groupName) {
            FaculityName = faculityName;
            GroupName = groupName;


        }
    }
}
