using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // config paramaters
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoplayEnabled;

    //state var
    [SerializeField] int currentScore = 0;
    


    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock; 
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoplayEnabled()
    {
        return isAutoplayEnabled;
    }
}
