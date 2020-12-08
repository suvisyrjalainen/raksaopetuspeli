using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;




public class Mouselook : MonoBehaviour
{
    public float mouseSensivity = 500f;
    public float minXAngle = -70f;
    public float maxXAngle = 30f;
   

    public Transform playerBody;

    public float mouseX;
    public float mouseY;
    private float xRotation = 0f;
    //[System.Runtime.InteropServices.DllImport("user32.dll")]
    //public static extern int SetCursorPos(int x, int y);
    
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //SetCursorPos(Screen.width / 1, Screen.height / 1);
    }

    //void SetCursorPositionToCenter()
    //{
        //SetCursorPos(Screen.width / 2, Screen.height / 2);
    //}
    // Update is called once per frame
    void Update()
    {
        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        if (!screenRect.Contains(Input.mousePosition)) {
        return;
            }
        //Cursor.lockState = CursorLockMode.None;

        mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minXAngle, maxXAngle);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
