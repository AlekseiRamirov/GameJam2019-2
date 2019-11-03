using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionMain : MonoBehaviour
{

    bool move = true;
    float mode = 0;
    public float speed = 1;
    string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position += Vector3.down * speed; 
            if (transform.position.y <= 0)
                switch(mode)
                {
                    case 1: SceneManager.LoadScene(SceneManager.GetActiveScene().name); break;
                    case 2: SceneManager.LoadScene(nextScene); break;
                }
                
            if (transform.position.y < -14)
            {
                transform.position = Vector3.up * 14;
                move = false;
            }
        }
    }

    public void Restart()
    {
        if (mode != 1)
        {
            move = true;
            mode = 1;
            transform.position = Vector3.up * 14;
        }
    }
    public void Win(string nextScene)
    {
        if (mode != 2)
        {
            this.nextScene = nextScene;
            move = true;
            mode = 2;
            transform.position = Vector3.up * 14;
        }
    }

}
