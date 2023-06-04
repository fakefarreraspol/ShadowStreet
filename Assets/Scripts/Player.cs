using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) SceneManager.LoadScene("LoseScene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemyBullet")
        {
            health -= 20;
        }

    }
}
