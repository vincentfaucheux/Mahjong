using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public struct SlabState
{
    public Vector3 position;
    public int symbol;
    public bool bErasable;
}

public class SlabInstanciator : MonoBehaviour
{
    public List<SlabState> slabList;
    public GameObject prefab;

    public List<Slab> instantiatedSlabs = new List<Slab>();

    // Start is called before the first frame update
    void Start()
    {
        int iNbSlab = slabList.Count;
        int iNbFamily = iNbSlab / 4;
        List<int> ListNbTilesPerFamily = new List<int>();
        System.Random rnd = new System.Random();
        uint uiRamdomVal;
        uint uiMask;

        for (int iLoop = 0; iLoop < iNbFamily; iLoop++)
        {
            ListNbTilesPerFamily.Add(4);
        }
        for (int iLoop = (iNbFamily * 4); iLoop < iNbSlab; iLoop++)
        {
            ListNbTilesPerFamily[iLoop % 4] += 1;
        }
        uiMask = 1;
        while (uiMask < (iNbFamily - 1))
        {
            uiMask = (uiMask << 1) + 1;
        }

        foreach (SlabState state in slabList)
        {
            GameObject slabGameObject = Instantiate(prefab, state.position, Quaternion.identity, transform);
            Slab slab = slabGameObject.GetComponent<Slab>();
            do
            {
                uiRamdomVal = (uint)rnd.Next(iNbFamily) & uiMask;
            } while (
                (uiRamdomVal > (iNbFamily - 1)) ||
                (ListNbTilesPerFamily[(int)uiRamdomVal] == 0)
                );
            //            Debug.Log("Ramdom value = " + uiRamdomVal.ToString());
            slab.symbol = uiRamdomVal;
            slab.bErasable = state.bErasable;
            ListNbTilesPerFamily[(int)uiRamdomVal] -= 1;
            instantiatedSlabs.Add(slab);
        }
        Debug.Log("Nb tiles = " + instantiatedSlabs.Count.ToString());
    }

    public void UpdateErasableSlab(Slab srcSlab)
    {
        Vector3 vect3Origin = srcSlab.transform.position;
        for (int x = -1; x <= 1; x += 2)
        {
            Vector3 vect3Build = vect3Origin + new Vector3(
                x * transform.localScale.x ,
                0 ,
                0
            );
            //check in the list
            int iLoop = 0;
            while(iLoop < instantiatedSlabs.Count)
            {
                Vector3 vect3Test = instantiatedSlabs[ iLoop].transform.position;
                if((Math.Abs(vect3Build.x - vect3Test.x) < 0.1f) &&
                    (Math.Abs(vect3Build.y - vect3Test.y) < 0.1f) &&
                    (Math.Abs(vect3Build.z - vect3Test.z) < 0.1f))
                {
                    //found
                    instantiatedSlabs[iLoop].bErasable = true;
                    Debug.Log("Slab erasable x=" + instantiatedSlabs[iLoop].transform.position.x.ToString()
                        + " ,y=" + instantiatedSlabs[iLoop].transform.position.y.ToString()
                        + " ,z=" + instantiatedSlabs[iLoop].transform.position.z.ToString());
                }

                //next element
                iLoop++;

            }
        }
        for (int y = -1; y <= 1; y += 2)
        {
            Vector3 vect3Build = vect3Origin + new Vector3(
                0,
                y * transform.localScale.y,
                0
            );
            //check in the list
            int iLoop = 0;
            while (iLoop < instantiatedSlabs.Count)
            {
                Vector3 vect3Test = instantiatedSlabs[iLoop].transform.position;
                if ((Math.Abs(vect3Build.x - vect3Test.x) < 0.1f) &&
                    (Math.Abs(vect3Build.y - vect3Test.y) < 0.1f) &&
                    (Math.Abs(vect3Build.z - vect3Test.z) < 0.1f))
                {
                    //found
                    instantiatedSlabs[iLoop].bErasable = true;
                    Debug.Log("Slab erasable x=" + instantiatedSlabs[iLoop].transform.position.x.ToString()
                        + " ,y=" + instantiatedSlabs[iLoop].transform.position.y.ToString()
                        + " ,z=" + instantiatedSlabs[iLoop].transform.position.z.ToString());
                }

                //next element
                iLoop++;

            }
        }
    }
}
