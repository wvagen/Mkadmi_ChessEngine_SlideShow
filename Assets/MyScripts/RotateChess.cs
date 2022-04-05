using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            myAnim.Play("Pawn_Tutorial");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Rook_Tutorial");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Bishop_Tutorial");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Knight_Tutorial");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("Queen_Tutorial");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            myAnim.SetBool("IsReturningToIdle", false);
            myAnim.Play("King_Tutorial");
        }

    }

    public void Start_Stop_Rotating()
    {
        canRotate = !canRotate;
    }

}
