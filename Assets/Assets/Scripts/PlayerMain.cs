using System.Collections;
using System.Collections.Generic;
using UnityEngine ;

public class PlayerMain : MonoBehaviour
{
    private CharacterController2D _controller;
    private float _horizontal;
    private bool _crouch;
    private bool jump = false;
    [SerializeField] private float walkSpeed = 40f;
    
    

    //public float fallMultiplier = 2.5f, lowJumpMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
}
