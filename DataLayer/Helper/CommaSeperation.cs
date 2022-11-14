using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public class CommaSeperation
{
    public string listresult = "";

    public string addcomma(List<string> stuff)
    {
        string s = "";
        foreach (string i in stuff)
        {
            s += i;
            s += ',';
        }
        return s;
    }

    public string listboxreturn(ListBox chk)
    {
        List<string> selectedValues = new List<string>();

        foreach (ListItem li in chk.Items)
        {
            if (li.Selected)
            {
                selectedValues.Add(li.Value);
            }
        }
        string speciality = addcomma(selectedValues);

        int index = speciality.LastIndexOf(',');
        if (index > 0)
        {
            listresult = speciality.Remove(index, 1);
        }
        else
        {
            listresult = "";
        }

        return listresult;
    }

    public string chcklistreturn(CheckBoxList chk)
    {
        List<string> selectedValues = new List<string>();

        foreach (ListItem li in chk.Items)
        {
            if (li.Selected)
            {
                selectedValues.Add(li.Value);
            }
        }
        string speciality = addcomma(selectedValues);

        int index = speciality.LastIndexOf(',');
        if (index > 0)
        {
            listresult = speciality.Remove(index, 1);
        }
        else
        {
            listresult = "";
        }

        return listresult;
    }

    public void removecomma(CheckBoxList chk, string value)
    {
        foreach (ListItem item in chk.Items)
        {
            item.Selected = value.Split(',').Contains(item.Value);
        }
    }
}