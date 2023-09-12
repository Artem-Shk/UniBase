namespace UniBase.Models
{
    public class MenuItemModel
    {
        public string ItemName { get; set; }
        public List<MenuItemModel> child { get; set; }
        public List<MenuItemModel> CourseNumber { get; set; }
      
        public MenuItemModel(string ?faculityName, List<MenuItemModel> ?groupName) {
            ItemName = faculityName;
            child = groupName;
        }
    }
}
