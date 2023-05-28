using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOption : MonoBehaviour
{
    public Button buttonOption;
    public DisplayOptionWin displayOptionWin;

    private bool buOptionCkicked;

    private void Start()
    {
        Button btn = buttonOption.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        buOptionCkicked = false;
    }

    void TaskOnClick()
    {
        Debug.Log("Click on button option");
        buOptionCkicked=true;
    }

    public void CancelButtonClicked()
    {
        buOptionCkicked = false;
    }

    public bool IsOptionButtonClicked()
    {
        return (buOptionCkicked == true);
    }
}
