using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOptionWin : MonoBehaviour
{
    public PanelOption panelOption;
    public TextUpdateOption textUpdateOption;

    public void ShowDisplayOption(string text)
    {
        panelOption.ActivatePanelOption();
        textUpdateOption.ShowText(text);
    }

    public void RemoveDisplayOption()
    {
        panelOption.DeactivatePanelOption();
        textUpdateOption.RemoveText();
    }
}
