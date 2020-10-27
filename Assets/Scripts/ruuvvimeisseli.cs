using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruuvvimeisseli : MonoBehaviour
{
    public Canvas Quiz_canvas;//Its your Canvas

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Pressed left click.");
        Quiz_canvas.gameObject.SetActive(true);

    }
}
