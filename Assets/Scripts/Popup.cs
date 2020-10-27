using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class MenuOnClick : MonoBehaviour
{

    public Canvas Quiz_canvas;//Its your Canvas

    void OnMouseDown()
    {
        Debug.Log("Pressed left click.");
        Quiz_canvas.gameObject.SetActive(true);
        
    }
}
