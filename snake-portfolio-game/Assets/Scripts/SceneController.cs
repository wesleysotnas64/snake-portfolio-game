using TMPro;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public int score;
    public int highScore;

    public TMP_Text textScore;
    public TMP_Text textHighScore;

    private SnakeHead snakeHead;
    private SnakeTail snakeTail;
    private Food food;

    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore");

        textScore.text = $"Score: {score}";
        textHighScore.text = $"High-Score: {highScore}";

        snakeHead = GameObject.Find("SnakeHead").GetComponent<SnakeHead>();
        snakeTail = GameObject.Find("SnakeTail").GetComponent<SnakeTail>();
        food = GameObject.Find("Food").GetComponent<Food>();
    }

    void Update()
    {
        if (snakeHead.live) return;

        if (Input.GetKeyDown(KeyCode.R)) Restart();
    }

    public void Scored()
    {
        score++;
        textScore.text = $"Score: {score}";
    }

    public void GameOver()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void Restart()
    {
        snakeTail.Reset();
        snakeHead.Reset();

        score = 0;

        textScore.text = $"Score: {score}";
        textHighScore.text = $"High-Score: {highScore}";
    }
}
