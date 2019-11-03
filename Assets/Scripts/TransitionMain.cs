using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionMain : MonoBehaviour
{

    public bool move = true, restart = false;
    public float speed = 1;

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
            if (transform.position.y <= 0 && restart)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            if (transform.position.y < -14)
            {
                transform.position = Vector3.up * 14;
                move = false;
            }
        }
    }

    public void Restart()
    {
        if (!restart)
        {
            move = true;
            restart = true;
            transform.position = Vector3.up * 14;
        }
    }
}
