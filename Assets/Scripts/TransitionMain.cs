using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionMain : MonoBehaviour
{

    bool move = true;
    float mode = 0;
    string nextScene;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("TransitionIdle"))
            switch(mode)
            {
                case 1: SceneManager.LoadScene(SceneManager.GetActiveScene().name); break;
                case 2: SceneManager.LoadScene(nextScene); break;
            }
    }

    public void Restart()
    {
        if (mode != 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            move = true;
            mode = 1;
            animator.SetTrigger("End");
        }
    }
    public void Win(string nextScene)
    {
        if (mode != 2)
        {
            GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            this.nextScene = nextScene;
            move = true;
            mode = 2;
            animator.SetTrigger("End");
        }
    }

}
