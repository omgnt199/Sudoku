using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoseBlock : MonoBehaviour
{
    private Color colororigin = new Color32(109, 248, 255, 255);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        changeColorrow(new Color32(176, 194, 195, 255));
        changeColorcol(new Color32(176, 194, 195, 255));
        changeColorBox(new Color32(176, 194, 195, 255));
        changeColorSimilarNumber(new Color32(176, 194, 195, 255));
    }
    private void OnMouseOver()
    {


    }
    private void OnMouseExit()
    {
        changeColorrow(colororigin);
        changeColorcol(colororigin);
        changeColorBox(colororigin);
        changeColorSimilarNumber(colororigin);
    }
    void changeColorrow(Color32 color)
    {
        float y = gameObject.transform.position.y;
        for(int x = 1;x <= 9; x++)
        {
            GameObject rowobj = Physics2D.Raycast(new Vector2(x, y), Vector2.right, 0.2f).collider.gameObject;
            Debug.Log(rowobj.name);
            rowobj.GetComponent<SpriteRenderer>().color = color;
        }

    }
    void changeColorcol(Color32 color)
    {
        float x = gameObject.transform.position.x;
        for (int y = 1; y <= 9; y++)
        {
            GameObject rowobj = Physics2D.Raycast(new Vector2(x, y), Vector2.right, 0.2f).collider.gameObject;
            rowobj.GetComponent<SpriteRenderer>().color = color;
        }
    }
    
    void changeColorBox(Color32 color)
    {
        int x = (int)gameObject.transform.position.x;
        int y = (int)gameObject.transform.position.y;
        if (x % 3 == 0) x -= 3;
        if(y % 3 == 0)  y -= 3;
        int x1 = (int)(x / 3) * 3;
        int y1 = (int)(y / 3) * 3;
        for(int i = x1+1; i <= x1+3; i++)
        {
            for(int j = y1+1; j <= y1+3; j++)
            {
                GameObject boxobj = Physics2D.Raycast(new Vector2(i, j), Vector2.right, 0.2f).collider.gameObject;
                boxobj.GetComponent<SpriteRenderer>().color = color;
            }
        }


    }
    void changeColorSimilarNumber(Color32 color)
    {
        int num = 10;
        if(gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text != null) num  = Int32.Parse(gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text);
        int num1 = 0;
        for(int i = 1; i<= 9; i++)
        {
            for(int j = 1; j<= 9; j++)
            {
                GameObject temp = Physics2D.Raycast(new Vector2(i, j), Vector2.right, .5f).collider.gameObject;
                if(temp.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text != null)
                {
                    num1 = Int32.Parse(temp.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text);
                    if (num == num1)
                    {
                        temp.GetComponent<SpriteRenderer>().color = color;
                    }
                }
            }
        }
    }


}
