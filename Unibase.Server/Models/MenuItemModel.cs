namespace UniBase.Models
{
    public class MenuItemModel
    {
        public string ItemName { get; set; }
        public List<MenuItemModel> GroupName { get; set; }

        public MenuItemModel(string faculityName, List<MenuItemModel>? groupName)
        {
            ItemName = faculityName;
            GroupName = groupName;


        }
    }
}
