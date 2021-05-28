using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private static int score = 0;



    public void AddPoints(int howMany)
    {
        score += howMany;
    }

    public void RemovePoints(int howMany)
    {
        score -= howMany;

    }

    public int GetScore()
    {
        return score;
    }
}
