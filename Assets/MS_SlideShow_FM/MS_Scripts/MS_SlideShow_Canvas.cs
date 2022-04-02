using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MS_SlideShow_Canvas : MonoBehaviour
{

    private List<MS_SlideShow_Page> pages;
    private MS_SlideShow_Page currentPage;

    public Transform camTransform;
    public float translateSpeed;

    int currentPageIndex = 0;

    const float MOVE_TRANSLATE_VALUE = 1;

    Vector3 vectorOfIndex;

    bool canClick = true;
    void Start()
    {
        Init();
        Set_Pages();
        Pages_Behaviour_Config();
    }

    void Init()
    {
        pages = new List<MS_SlideShow_Page>();
        currentPageIndex = 0;
        vectorOfIndex = Vector3.one;
        vectorOfIndex.y = 0;
    }

    void Set_Pages()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<MS_SlideShow_Page>() != null)
            {
                pages.Add(transform.GetChild(i).GetComponent<MS_SlideShow_Page>());
            }
        }
    }

    void Pages_Behaviour_Config()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].Set_Active(false);
            pages[i].Set_Me(i + 1);
        }
        if (pages.Count > 0)
        {
            currentPage = pages[0];
            currentPage.Set_Active(true);
        }
    }

    void Update()
    {
        Page_Switch();
    }

    void Page_Switch()
    {
        if ((currentPageIndex < pages.Count - 1) && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.RightArrow)) && canClick)
        {
            StartCoroutine(Switch_Page(true));
        }

        if ((currentPageIndex > 0) && (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftArrow)) && canClick)
        {
            StartCoroutine(Switch_Page(false));
        }
    }

    IEnumerator Switch_Page(bool isGoingNext)
    {
        currentPage.Set_Active(false);
        canClick = false;

        if (isGoingNext)
        {
            currentPageIndex++;
            if (vectorOfIndex.x == 0)
            {
                if (vectorOfIndex.x == 1)
                {
                    vectorOfIndex.x = -1;
                    vectorOfIndex.z = 0;
                }
                else
                {
                    vectorOfIndex.x = 1;
                    vectorOfIndex.z = 0;
                }
            }
            else
            {
                if (vectorOfIndex.z == 1)
                {
                    vectorOfIndex.z = -1;
                    vectorOfIndex.x = 0;
                }
                else
                {
                    vectorOfIndex.z = 1;
                    vectorOfIndex.x = 0;
                }
            }
        }
        else
        {
            currentPageIndex--;

        }
        Vector3 targetPos = camTransform.position + vectorOfIndex * MOVE_TRANSLATE_VALUE;

        while (Vector2.Distance(camTransform.position, targetPos) > 0.01f)
        {
            camTransform.position = Vector3.MoveTowards(camTransform.position, targetPos, Time.deltaTime * translateSpeed);
            yield return new WaitForEndOfFrame();
        }

        currentPage = pages[currentPageIndex];
        currentPage.Set_Active(true);
        canClick = true;
    }
}
