using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slab : MonoBehaviour
{

    public List<Color> colors;
    public SpriteRenderer renderer;

    public Sprite OnePointImg;
    public Sprite TwoPointsImg;
    public Sprite ThreePointsImg;
    public Sprite FourPointsImg;
    public Sprite FivePointsImg;

    public uint symbol;
    public bool bErasable;

    void Start()
    {
//        renderer.color = colors[(int)symbol];
        if( symbol == 0 )
        {
            renderer.sprite = OnePointImg;
//            GetComponent<Image>().sprite = OnePointImg;
        }
        else if (symbol == 1)
        {
            renderer.sprite = TwoPointsImg;
//            GetComponent<Image>().sprite = TwoPointsImg;
        }
        else if (symbol == 2)
        {
            renderer.sprite = ThreePointsImg;
//            GetComponent<Image>().sprite = ThreePointsImg;
        }
        else if (symbol == 3)
        {
            renderer.sprite = FourPointsImg;
//            GetComponent<Image>().sprite = FourPointsImg;
        }
        else if (symbol == 4)
        {
            renderer.sprite = FivePointsImg;
//            GetComponent<Image>().sprite = FivePointsImg;
        }
        else
        {
        }
    }

    public bool IsCovered()
    {
        for (int x = -1; x <= 1; x += 2)
        {
            for (int y = -1; y <= 1; y += 2)
            {
                Vector3 point = transform.position + new Vector3(
                    x * 0.90f * transform.localScale.x / 2f,
                    y * 0.90f * transform.localScale.y / 2f,
                    -0.1f
                );
                //                Debug.Log($"Point ({x}, {y}: {point})");
                if (CheckRayCollision(point))
                    return true;
            }
        }
        return false;
    }

    public bool IsErasable()
    {
        return (bErasable == true);
    }

    private bool CheckRayCollision(Vector3 pointCkecked)
    {
        Slab pointedSlab;
        Vector2 mousePos2D = new Vector2(pointCkecked.x, pointCkecked.y);

        RaycastHit2D rayHit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (rayHit.collider != null)
        {
            pointedSlab = rayHit.collider.GetComponent<Slab>();
        }
        else
        {
            pointedSlab = null;
        }
        return (this != pointedSlab);
    }
}
