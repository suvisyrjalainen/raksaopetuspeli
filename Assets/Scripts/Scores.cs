﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scores : MonoBehaviour
{
    Text txt;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        //txt.text = "Pisteet : " + score + "/10";
        Debug.Log(txt.text);
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Pisteet : " + score + "/10";

    }
}
