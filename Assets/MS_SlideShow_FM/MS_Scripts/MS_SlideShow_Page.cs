using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MS_SlideShow_Page : MonoBehaviour
{
    public Text pageNumberTxt;


    public void Set_Me(int myPageIndex, Color myTxtColor)
    {
        if (pageNumberTxt != null)
        {
            pageNumberTxt.text = myPageIndex.ToString();
        }

        foreach(Text txt in GetComponentsInChildren<Text>())
        {
            txt.color = myTxtColor;
        }
    }

    public void Set_Active(bool isShowing)
    {
        gameObject.SetActive(isShowing);
    }

}
