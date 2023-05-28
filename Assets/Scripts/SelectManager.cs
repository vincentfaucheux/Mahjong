using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{

    private Slab selectedSlab;
    public SlabInstanciator slabInstanciator;
    public EndWindow canvasEndWindow;
    public ButtonOption ButtonOption;
    public DisplayOptionWin displayOptionWin;

    private bool bGameOver;

    public void SelectSlab(Slab slab)
    {
        selectedSlab = slab;
    }

    private void Start()
    {
        bGameOver = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //close option window
            displayOptionWin.RemoveDisplayOption();

            //Check end of game
            if (bGameOver == true)
            {
                //Reload the program
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            //Check if option window must be displayed
            else if( ButtonOption.IsOptionButtonClicked() == true)
            {
                ButtonOption.CancelButtonClicked();
                displayOptionWin.ShowDisplayOption("Option");
            }

            else
            {
                //Program is in progress
                Slab pointedSlab = GetClickSlab();
                if (pointedSlab == null)
                {
                    selectedSlab = null;
                }
                else
                {
                    Debug.Log("Slab erasable x=" + pointedSlab.transform.position.x.ToString()
                        + " ,y=" + pointedSlab.transform.position.y.ToString()
                        + " ,z=" + pointedSlab.transform.position.z.ToString()
                        + " ,erasabble " + pointedSlab.bErasable.ToString());

                    if (pointedSlab.IsCovered())
                    {
                        selectedSlab = null;
                    }
                    else if (pointedSlab.IsErasable() == false)
                    {
                        selectedSlab = null;
                    }
                    else if (pointedSlab == selectedSlab)
                    {
                        selectedSlab = null;
                    }
                    else if (selectedSlab == null)
                    {
                        selectedSlab = pointedSlab;
                    }
                    else if (pointedSlab.symbol != selectedSlab.symbol)
                    {
                        selectedSlab = pointedSlab;
                    }
                    else
                    {
                        Slab slab = pointedSlab.gameObject.GetComponent<Slab>();
                        slabInstanciator.UpdateErasableSlab(slab);
                        slabInstanciator.instantiatedSlabs.Remove(slab);
                        slab = selectedSlab.gameObject.GetComponent<Slab>();
                        slabInstanciator.UpdateErasableSlab(slab);
                        slabInstanciator.instantiatedSlabs.Remove(slab);
                        Destroy(pointedSlab.gameObject);
                        Destroy(selectedSlab.gameObject);
                        Debug.Log("Nb tiles = " + slabInstanciator.instantiatedSlabs.Count.ToString());
                    }
                }

                //Check if the game is over
                if (slabInstanciator.instantiatedSlabs.Count > 0)
                {
                    //remaining slabs
                    if (GameOver() == true)
                    {
                        bGameOver = true;
                        Debug.Log("Game over, Game lost");
                        canvasEndWindow.UpdateEndWindow( EndWindow.KindWindow.YouLoose);
                    }
                }
                else
                {
                    //all the slabs removed
                    bGameOver = true;
                    Debug.Log("Game over, You win");
                    canvasEndWindow.UpdateEndWindow(EndWindow.KindWindow.YouWin);
                }
            }
        }
    }

    private Slab GetClickSlab()
    {
        Slab pointedSlab;
        //        Debug.Log("Click", gameObject);
        Vector3 clickpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(clickpos.x, clickpos.y);

        RaycastHit2D rayHit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (rayHit.collider != null)
        {
            pointedSlab = rayHit.collider.GetComponent<Slab>();
        }
        else
        {
            pointedSlab = null;
        }

        return (pointedSlab);
    }

    private bool GameOver()
    {
        bool bRet = true;
        List<uint> listFreeColour = new List<uint>();
        int iLoop = 0;
        while ((bRet == true) &&
            (iLoop < slabInstanciator.instantiatedSlabs.Count))
        {
            if (slabInstanciator.instantiatedSlabs[iLoop].IsCovered() == false)
            {
                if (listFreeColour.Contains(slabInstanciator.instantiatedSlabs[iLoop].symbol) == true)
                {
                    bRet = false;
                }
                else
                {
                    listFreeColour.Add(slabInstanciator.instantiatedSlabs[iLoop].symbol);
                }
            }

            iLoop++;
        }

        return (bRet);
    }
}
