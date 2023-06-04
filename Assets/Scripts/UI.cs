using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public bool mod002;
    Player player;
    Image panel;
    void Start()
    {
        player = FindObjectOfType<Player>();
        panel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health < player.maxHealth/4)
        {
            var tempColor = panel.color;
            tempColor.a = 1f;
            panel.color = tempColor;
        }
        else if (player.health < player.maxHealth/3)
        {
            var tempColor = panel.color;
            tempColor.a = 0.75f;
            panel.color = tempColor;
        }
        else if (player.health < player.maxHealth/2)
        {
            var tempColor = panel.color;
            tempColor.a = 0.5f;
            panel.color = tempColor;
        }
        else if (player.health < player.maxHealth/1.5)
        {
            var tempColor = panel.color;
            tempColor.a = 0.25f;
            panel.color = tempColor;
        }
        else
        {
            var tempColor = panel.color;
            tempColor.a = 0.0f;
            panel.color = tempColor;
        }
    }
}
