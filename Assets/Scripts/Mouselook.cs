using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;




public class Mouselook : MonoBehaviour
{
    public float mouseSensivity = 800f;
    public float minXAngle = -70f;
    public float maxXAngle = 90f;

    public Transform playerBody;

    public float mouseX;
    public float mouseY;
    private float xRotation = 0f;
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    int xPos = 0, yPos = 0;
    // Start is called before the first frame update
    void Start()
    {

        SetCursorPos(xPos, yPos);
        //Cursor.lockState = CursorLockMode.Locked;  

    }

    // Update is called once per frame
    void Update()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minXAngle, maxXAngle);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        SetCursorPos(xPos, yPos);

    }
}
