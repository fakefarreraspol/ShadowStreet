using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool mod2;
    public int enemyCount;

    public static int score;

    // void Awake()
    // {
    //     DontDestroyOnLoad(score);
    // }
    void Start()
    {
        enemyCount = 0;
        // if (!mod2) enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (!mod2)
        {
            
            if (enemyCount <= 0)
            {
                SceneManager.LoadScene("WinScene");
            }

        }

    }

    public void AddPoints(int points)
    {
        score += points;
    }
    public int GetPoints()
    {
        return score;
    }
    public void ResetPoints()
    {
        score = 0;
    }
}
