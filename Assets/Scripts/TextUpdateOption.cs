using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdateOption : MonoBehaviour
{
    public TextMeshProUGUI textCmpOption;

    public void ShowText(string text)
    {
        textCmpOption.text = text;
        textCmpOption.gameObject.SetActive(true);
    }

    public void RemoveText()
    {
        textCmpOption.gameObject.SetActive(false);
    }
}
