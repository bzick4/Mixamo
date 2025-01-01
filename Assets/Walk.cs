    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
   [Header("Movement vars")] 
    [SerializeField] private float _JumpForce;
    [SerializeField] private float _Speed, _RotSpeed=360f;
    [SerializeField] private float _RunSpeed;
    [SerializeField] private Transform _CameraTransform;

    [Header("Settings")]
    [SerializeField] private Transform _GroundColliderTransform;
    [SerializeField] private LayerMask _GroundMask;
    [SerializeField] private float _JumpOffset;

    private float _currentSpeed;
    private float _vert, _horiz;
    private bool isMove;
    private bool isJumped;
    private bool isGrounded = false;

    private Weapon _animator;
    private Rigidbody _heroRb;
    private Vector3 _input;

 
 private void Awake()
 {
    _animator =GetComponent<Weapon>();
    _heroRb = GetComponent<Rigidbody>();
    _currentSpeed = _Speed;
 }

private void Update() 
{
    Run();
    KeyJump();
}

private void FixedUpdate() 
{
    WalkHero();
    //CheckGround();
    Jump();
}
 
public void WalkHero()
    {
        isMove= true;
         _vert = Input.GetAxis("Vertical");
         _horiz = Input.GetAxis("Horizontal"); 

         Vector3 move = transform.forward * _vert * _currentSpeed * Time.fixedDeltaTime;
         _heroRb.MovePosition(_heroRb.position + move);

         if(_vert !=0)
         {
            _animator.animator.SetBool("Walk", true);
            Debug.Log($"{_currentSpeed}");
         }
         else
         {
            _animator.animator.SetBool("Walk", false);
         }

         Quaternion turnRotation = Quaternion.Euler(0f, _horiz*_RotSpeed * Time.fixedDeltaTime, 0f);
         _heroRb.MoveRotation(_heroRb.rotation*turnRotation);  
    }

private void Run()
{
    if(Input.GetKeyDown(KeyCode.RightShift)&&isMove || Input.GetKeyDown(KeyCode.RightShift)&&!isMove)
    {
        _currentSpeed = _RunSpeed;
        _animator.animator.SetBool("Run", true);
        Debug.Log($"{_currentSpeed}");
    }
    else if(Input.GetKeyUp(KeyCode.RightShift))
    {
       _currentSpeed = _Speed;
       _animator.animator.SetBool("Run", false);
    }
}

private void OnCollisionEnter(Collision other)
    {
        if(other.contacts[0].normal.y>0.2f)
        {
            isGrounded=true;
        }
    }

 private void Jump()
    {
        if (isJumped=true && isGrounded)
        { 
            _heroRb.AddForce(Vector3.up * _JumpForce, ForceMode.Impulse);
            _animator.animator.SetBool("Jump", true);
            _animator.animator.SetBool("Run", false);
            
            isJumped = false;
            Debug.Log("jump");
        }
        else if (!isGrounded && _heroRb.velocity.z<0)
        {
            //_animator.animator.SetBool("isFall", true);
            _animator.animator.SetBool("Jump", false);
            _animator.animator.SetTrigger("Idle");
            
            Debug.Log("fall");
        }
    }

   private void KeyJump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //&& isGrounded)
        {
            isJumped = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && !isGrounded)
        {
            isJumped = false;;
        }
    }



}
