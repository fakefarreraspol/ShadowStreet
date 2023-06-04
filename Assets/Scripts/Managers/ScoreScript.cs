using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool mod2;
    public int enemyCount;

    void Start()
    {
        enemyCount = 0;
        // if (!mod2) enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mod2)
        {
            enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
            if (enemyCount <= 0)
            {
                SceneManager.LoadScene("WinScene");
            }

        }

    }
}
