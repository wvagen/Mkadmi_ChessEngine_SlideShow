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
        }

    }

    public void Start_Stop_Rotating()
    {
        canRotate = !canRotate;
    }

}
