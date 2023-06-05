using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    private ScoreScript scrs;
    void Start()
    {
        scrs = FindObjectOfType<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToGameScene01()
    {
        scrs.ResetPoints();
        SceneManager.LoadScene("TestScene");
    }
    public void ToGameScene02()
    {
        scrs.ResetPoints();
        SceneManager.LoadScene("TestScene02");
    }
    public void ToGameMode02()
    {
        scrs.ResetPoints();
        SceneManager.LoadScene("Mode02");
    }
    
}
