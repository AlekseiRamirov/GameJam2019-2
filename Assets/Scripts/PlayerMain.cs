using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMain : MonoBehaviour
{
    private CharacterController2D _controller;
    private float _horizontal;
    private bool _crouch = false;
    private bool _jump = false;
    private Transform player;
    [SerializeField] private bool active = true;
    [SerializeField] private bool magic = true;
    [SerializeField] private float _walkSpeed = 40f;
    [SerializeField] private GameObject selec;
    public TransitionMain transition;
    private Animator animator;

    private static AudioSource sndWin;


    void OnHorizontal(InputValue value)
    {
        _horizontal = value.Get<float>();
    }

    void OnJump()
    {
        if (active)
        {
            _jump = true;

        }
    }
    void OnChange()
    {
        active = !active;
    }
    // Start is called before the first frame update
    void Start()
    {
        sndWin = GetComponent<AudioSource>();
        _controller = GetComponent<CharacterController2D>();
        player = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        selec.SetActive(active);
        if (transform.position.y < -10 || transform.position.y > 7)
            Restart();
    }

    void FixedUpdate()
    {
        if (active)
        {
            animator.SetFloat("Speed", Mathf.Abs(_horizontal * Time.fixedDeltaTime * _walkSpeed));
            // Move our character
            _controller.Move(_horizontal * Time.fixedDeltaTime * _walkSpeed, _crouch, _jump);
            _jump = false;
        }
    }

    public static void Restart()
    {
        GameObject.Find("Transition").GetComponent<TransitionMain>().Restart();
    }
    public static void Win(string nextScene)
    {
        //sndWin.Play(0);
        GameObject.Find("Transition").GetComponent<TransitionMain>().Win(nextScene);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            player.transform.parent = collision.transform;
            animator.SetBool("Jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            player.transform.parent = null;
            animator.SetBool("Jump", true);
        }
    }
    void OnPaint()
    {
        if (magic && active)
        {
            animator.SetBool("Magic", true);
        }
    }
    public void NoPaint()
    {
        animator.SetBool("Magic", false);
    }

}
