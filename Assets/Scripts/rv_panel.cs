using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class rv_panel : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Text scores;
    private int score;
    private string score_string;
    private string updated_scores_string = "Pisteet : " + "0" + "/10";

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(delegate { TaskOnClickWithAnwer("1"); });
        button2.onClick.AddListener(delegate { TaskOnClickWithAnwer("2"); });
        button3.onClick.AddListener(delegate { TaskOnClickWithAnwer("3"); });
    }

    // Update is called once per frame
    void Update()
    {
        scores.text = updated_scores_string;
    }

    void TaskOnClickWithAnwer(string selected_button)
    {
        Debug.Log("You have clicked the button " + selected_button);
        if(selected_button == "1")
        {
            Debug.Log(scores.text);
            Scores.score = Scores.score + 1;
            score_string = Scores.score.ToString();
            scores.text = "Pisteet : " + score_string + "/10";
            updated_scores_string = "Pisteet : " + score_string + "/10";

            Debug.Log(scores.text);
        }
    }

}
