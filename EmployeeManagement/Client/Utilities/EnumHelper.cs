using EmployeeManagement.Client.Pages.DropDownListInDataFilter;
using static System.Enum;
using static System.String;

namespace EmployeeManagement.Client.Utilities;

public static class EnumHelper
{
    public static List<DropDownListItem> ConvertEnumToDropDownSource<T>(string initialText, string initialValue)
    {
        var dropDownListItems = new List<DropDownListItem>();
        var values = GetValues(typeof(T)).Cast<T>().ToList();
        
        if (!IsNullOrEmpty(initialValue) || !IsNullOrEmpty(initialText)) dropDownListItems.Add(new DropDownListItem(initialText, initialValue));

        for (var i = 0; i < GetNames(typeof(T)).Length; i++) 
            dropDownListItems.Add(new DropDownListItem( GetNames(typeof(T))[i], values[i]?.ToString() ?? Empty));

        return dropDownListItems;

    }
}