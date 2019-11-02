using System.Collections;
using System.Collections.Generic;
using UnityEngine ;
using UnityEngine.InputSystem;

public class PlayerMain : MonoBehaviour
{
    private CharacterController2D _controller;
    private float _horizontal;
    private bool _crouch = false;
    private bool _jump = false;
    [SerializeField] private float _walkSpeed = 40f;


    void OnHorizontal(InputValue value)
    {
        _horizontal = value.Get<float>();
        Debug.Log("hor" + _horizontal);
    }

    void OnJump()
    {
        _jump = true;
    }

    void OnCrouch(InputValue value)
    {
        _crouch = (int)value.Get<float>() != 0;
        Debug.Log("crouch" + (int)value.Get<float>());

    }
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // Move our character
        _controller.Move(_horizontal * Time.fixedDeltaTime * _walkSpeed, _crouch, _jump);
        _jump = false;
    }
}
