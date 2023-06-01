using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardNum : MonoBehaviour
{
    public GameObject fillnum;
    private int num = 1;
    // Start is called before the first frame update

    private void OnMouseOver()
    {
        
    }
    void Start()
    {
        for(int y = 7; y >= 3; y -= 2)
        {
            for(int x = 12; x <= 16; x+=2)
            { 
                GameObject gobj = Instantiate(fillnum, new Vector3(x, y),Quaternion.identity);
                gobj.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = num.ToString();
                num++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
