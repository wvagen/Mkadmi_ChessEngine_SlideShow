using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateChess : MonoBehaviour
{
    public Animator myAnim;

    public float rotSpeed;
    public bool canRotate = true;

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Start_Stop_Rotating();
            myAnim.SetBool("IsReturningToIdle", true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Pawn_Tutorial",-1,0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Rook_Tutorial", -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Bishop_Tutorial", -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Knight_Tutorial", -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Queen_Tutorial", -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("King_Tutorial", -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Check_Position", -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Check_Mate_Position", -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Stale_Mate", -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Chess_SlideShow_Scene_1");
        }
    }

    public void Start_Stop_Rotating()
    {
        canRotate = !canRotate;
    }

}
