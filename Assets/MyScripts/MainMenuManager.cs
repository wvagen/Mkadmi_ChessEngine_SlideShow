using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public MS_SlideShow_Canvas slideShowCanvas;
    public Animator myAnim;
    int pageIndex = 0;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.RightArrow)){
            if ((pageIndex < slideShowCanvas.pages.Count - 1))
        {
                pageIndex++;
            }else
            {
                StartCoroutine(Play_Cam_Scene_And_Switch_Next_Scene());
            }
        }

        if ((pageIndex > 0) && (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            pageIndex--;
        }
    }

    IEnumerator Play_Cam_Scene_And_Switch_Next_Scene()
    {
        slideShowCanvas.pages[slideShowCanvas.pages.Count - 1].Set_Active(false);
        myAnim.Play("CamAnim");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
