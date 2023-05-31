using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ToGameScene01);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToGameScene01()
    {
        SceneManager.LoadScene("TestScene");
    }
}
