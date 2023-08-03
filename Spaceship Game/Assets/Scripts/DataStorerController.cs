using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorerController : MonoBehaviour
{
    public int highScore; //Might need to be a float?
    public int previousScore;//Might also need to be a float?

    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void UpdatePreviousScore(int currentScore)
    {
        previousScore = currentScore;
    }

    public void UpdateHighScore()
    {
        if(previousScore > highScore)
        {
            highScore = previousScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void ClearHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
