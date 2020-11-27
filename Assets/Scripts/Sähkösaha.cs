using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sähkösaha : MonoBehaviour
{
    public Canvas Quiz_canvas;//Its your Canvas

    public Button button1;
    public Button button2;
    public Button button3;

    private bool is_pressed = false;

    public Text scores;
    private int score;
    private string score_string;
    //private string updated_scores_string = "Pisteet : " + "0" + "/10";

    private string Sähkösaha_correct_answer = "3";
    public Color correctColor;
    public Color wrongColor;

    // Start is called before the first frame update
    void Start()
    {
        Quiz_canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //scores.text = updated_scores_string;
    }

    void OnMouseDown()
    {
        Debug.Log("Pressed left click.");
        Quiz_canvas.gameObject.SetActive(true);
        button1.GetComponentInChildren<Text>().text = "Ruuvimeisseli";
        button2.GetComponentInChildren<Text>().text = "Ruuvinväännin";
        button3.GetComponentInChildren<Text>().text = "Sähkösaha";

        is_pressed = true;
        button1.onClick.AddListener(delegate { SähkösahaOnClickWithAnwer("1"); });
        button2.onClick.AddListener(delegate { SähkösahaOnClickWithAnwer("2"); });
        button3.onClick.AddListener(delegate { SähkösahaOnClickWithAnwer("3"); });

        ColorBlock cb1 = button1.colors;
        cb1.pressedColor = wrongColor;
        cb1.selectedColor = wrongColor;
        cb1.fadeDuration = 1;
        button1.colors = cb1;

        ColorBlock cb2 = button2.colors;
        cb2.pressedColor = wrongColor;
        cb2.selectedColor = wrongColor;
        cb2.fadeDuration = 1;
        button2.colors = cb2;


        ColorBlock cb3 = button3.colors;
        cb3.pressedColor = correctColor;
        cb3.selectedColor = correctColor;
        cb3.fadeDuration = 1;
        button3.colors = cb3;

        Cursor.lockState = CursorLockMode.None;
    }

    void SähkösahaOnClickWithAnwer(string selected_button)
    {
        Debug.Log("You have clicked the button " + selected_button);
        if (selected_button == Sähkösaha_correct_answer && is_pressed)
        {

            //Debug.Log(scores.text);
            Scores.score = Scores.score + 1;
            is_pressed = false;
            //score_string = Scores.score.ToString();
            //scores.text = "Pisteet : " + score_string + "/10";
            //updated_scores_string = "Pisteet : " + score_string + "/10";

            Debug.Log(scores.text);
            StartCoroutine(WaitAndClosePanel());

        }


    }

    IEnumerator WaitAndClosePanel()
    {
        yield return new WaitForSeconds(2);
        Quiz_canvas.gameObject.SetActive(false);
        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Sähkösaha>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }




}