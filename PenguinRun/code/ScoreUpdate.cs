using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public FishCount fishCollector;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + fishCollector.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + fishCollector.score.ToString();   
    }
}
