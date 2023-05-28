using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndWindowImage : MonoBehaviour
{
    public GameObject EndWinImage;

    public Sprite GameOverImg;
    public Sprite WinImg;

    public void ImageEndWindow( int iIndexWindow)
    {
        if (iIndexWindow == 0)
        {
            GetComponent<Image>().sprite = GameOverImg;
            EndWinImage.SetActive(true);
        }
        else if (iIndexWindow == 1)
        {
            GetComponent<Image>().sprite = WinImg;
            EndWinImage.SetActive(true);
        }
        else
        {

        }
    }

}
