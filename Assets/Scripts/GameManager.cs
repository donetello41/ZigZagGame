using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    int score, highScore = 0;
    public Text scoreText, hScoreText;
    public bool isGameStarted = false;
    float elapsedTime = 3;

    public Text text;
    public GameObject button;
	// Use this for initialization
	void Start () {
        highScore = PlayerPrefs.GetInt("HS");
        hScoreText.text = highScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime -= Time.deltaTime;

        if (elapsedTime > 0)
            text.text = ((int)elapsedTime).ToString();
        else
        {
            StartGame();
            Destroy(button);
        }
	}

    private void StartGame()
    {
        isGameStarted = true;

        FindObjectOfType<WallMaker>().CreateWall();
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void MakeScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score >highScore)
        {
            highScore = score;
            hScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HS", highScore);
        }
    }
}
