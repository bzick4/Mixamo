using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
   [SerializeField] float _Speed,_RunSpeed, _RotSpeed;
   [SerializeField] float _Jump, _ForwardForce;
   private Vector3 _moveDirect;
   private Weapon _animator;
   private Rigidbody _hero;

   private bool isJump, isJumping, isMove;
   private float _currentSpeed;

   private float _vert,_horiz;


private void Awake()
   {
    _animator =GetComponent <Weapon>();
    _hero = GetComponent<Rigidbody>();
    _currentSpeed = _Speed;
    isMove = true;
   }

private void Update()
   {
     _vert = Input.GetAxis("Vertical");
     _horiz = Input.GetAxis("Horizontal"); 
     Run();
     KeyJump();
   }

private void FixedUpdate()
   {
    if(isMove)
     {
      Walk();
     }
     if(isMove && isJumping)
     {
        Jump();
     }
   }

private void Walk()
   {
    _moveDirect = new Vector3(_horiz, 0, _vert).normalized;
    transform.Translate(_moveDirect * _currentSpeed * Time.fixedDeltaTime);
    if(_vert != 0)
    {
        _animator.animator.SetFloat("Velocity", Mathf.Abs(_vert));
    }
    if(_horiz != 0)
    {
        transform.Rotate(0, _horiz * _RotSpeed * Time.fixedDeltaTime ,0);
    }
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

private void Jump()
{
    isMove = false;
    _hero.velocity = new Vector3(0, _Jump, _ForwardForce);
    Invoke(nameof(EndJump),5f);
}

private void EndJump()
{
    isMove = true;
}

private void KeyJump()
{
    if(Input.GetKeyDown(KeyCode.Space))
    {
        isJump=false;
        isJumping= true;
        _moveDirect.y = 0f;
    }
    if(Input.GetKeyUp(KeyCode.Space))
    {
        isJump =true;
        isJumping =false;
    }
}

private void Fall()
{
    _animator.animator.SetBool("isFall",false);
}

}
