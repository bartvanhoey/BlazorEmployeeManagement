namespace EmployeeManagement.Client.Pages.DropDownListInDataFilter;

public class DropDownListItem
{
    public DropDownListItem(string text, string value)
    {
        Text = text;
        Value = value;
    }

    public string Text { get; set; }
    public string Value { get; set; }
}