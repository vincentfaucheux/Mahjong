using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOption : MonoBehaviour
{
    public GameObject panelOption;

    public void ActivatePanelOption()
    {
        panelOption.SetActive(true);
    }

    public void DeactivatePanelOption()
    {
        panelOption.SetActive(false);
    }
}
