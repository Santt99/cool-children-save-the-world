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
        scoreText.text = gameController.GetScore().ToString();
    }
}
