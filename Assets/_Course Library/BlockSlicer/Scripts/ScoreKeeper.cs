using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public TMP_Text scoreBoard;
    public TMP_Text livesLeftBoard;

    int score = 0;
    int pointsPerHit = 10;

    int livesLeft = 5;

    public BlockSlicerGameLogic gameLogic;

    private void Start()
    {
        livesLeftBoard.text = livesLeft.ToString();
    }
    public void IncreaseScore()
    {
        score += pointsPerHit;
        scoreBoard.text = score.ToString();
    }
    public void DecreaseLives()
    {
        livesLeft--;
        if(livesLeft <= 0)
        {
            gameLogic.GameOver();
        }
        livesLeftBoard.text = livesLeft.ToString();
    }
}
