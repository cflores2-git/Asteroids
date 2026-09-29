using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score=0;
    public AsteroidSpawner asteroidSpawner;
    public int difficultyScore = 5;
    private bool difficultyIncreased = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddPoint()
    {
        score++;
        scoreText.text = "Score: " + score;

        if (score>=difficultyScore && !difficultyIncreased)
        {
            difficultyIncreased = true;
            asteroidSpawner.IncreasedDifficulty();
        }
    }
}
