namespace UniBase.Models
{
    public class MenuItemModel
    {
        public string ItemName { get; set; }
        public List<MenuItemModel> GroupName { get; set; }

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public MenuItemModel(string faculityName, List<MenuItemModel>? groupName)
        {
            ItemName = faculityName;
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            GroupName = groupName;
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.


        }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    }
}
