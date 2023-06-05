using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
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
    public async void ToGameScene01()
    {
        scrs.ResetPoints();
        var scene = SceneManager.LoadSceneAsync("TestScene");
        do
        {
            await Task.Delay(200);
        } while (scene.progress < 0.9f);
        scene.allowSceneActivation = true;
    }
    public async void ToGameScene02()
    {

        scrs.ResetPoints();
        var scene = SceneManager.LoadSceneAsync("TestScene02");
        scene.allowSceneActivation = false;

        do
        {
            await Task.Delay(200);
        } while (scene.progress < 0.9f);
        scene.allowSceneActivation = true;
    }
    public async void ToGameMode02()
    {
        scrs.ResetPoints();
        var scene = SceneManager.LoadSceneAsync("Mode02");
        do
        {
            await Task.Delay(200);
        } while (scene.progress < 0.9f);
        scene.allowSceneActivation = true;
    }

}
