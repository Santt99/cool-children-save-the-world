using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreTextController : MonoBehaviour
{
    private Text scoreText;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = new GameController();
        scoreText = this.transform.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string newText = gameController.GetScore().ToString();
        if (scoreText.text != newText)
        {
            StartCoroutine(ChangeFontColor(newText));


        }

    }

    IEnumerator ChangeFontColor(string newText)
    {
        scoreText.color = Color.green;
        scoreText.text = newText;
        yield return new WaitForSecondsRealtime(0.20f);
        scoreText.color = Color.white;

    }
}
