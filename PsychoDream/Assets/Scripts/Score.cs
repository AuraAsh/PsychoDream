using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;


public class Score : MonoBehaviour
{
    public static Score instance;
    public Text text;
    int score;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int theScore)
    {
        score += 1;
        text.text = "?! = " + score.ToString();

        if (score >= 3)
        {
            Debug.Log("Finish Game!");
            StartCoroutine(FinishGame());
        }
    }

    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Final");
        Analytics.CustomEvent("Win");
    }

    /*void Update()
    {
        {
            scoreText.GetComponent <Text>().text = "?! = " + theScore;
        }

        if (theScore >= 3)
        {
            Debug.Log("Finish Game!");
            StartCoroutine(FinishGame());
        }
    }

    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Final");
    }*/
}
