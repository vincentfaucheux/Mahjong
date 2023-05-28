using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWindow : MonoBehaviour
{
    public EndWindowImage endWindowImage;

    public enum KindWindow
    {
        YouWin,
        YouLoose
    }

    public void UpdateEndWindow(KindWindow kindWindow)
    {
        if (kindWindow == KindWindow.YouLoose)
        {
            endWindowImage.ImageEndWindow( 0);
        }
        else if (kindWindow == KindWindow.YouWin)
        {
            endWindowImage.ImageEndWindow(1);
        }
    }
}
