using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [Header("Set Dynamically")]
    static public int score = 1000;

    // Awake is called when creating an instance
    void Awake()
    {
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = score.ToString();
        if (score != PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
        }
        // Обновить HighScore в PlayerPrefs, если необходимо
        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
