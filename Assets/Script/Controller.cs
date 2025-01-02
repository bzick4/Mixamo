using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
   [SerializeField] float _Speed,_RunSpeed, _RotSpeed;
   [SerializeField] float _Jump, _Gravity;
   private Vector3 _moveDirect;
   private CharacterController _char=null;
   private Weapon _animator;

   private bool isMove, isJump;
   private float _currentSpeed;

   private float _vert,_horiz;


private void Awake()
   {
    _char= GetComponent<CharacterController>();
    _animator =GetComponent<Weapon>();
    _currentSpeed = _Speed;
   }

private void Update()
   {
    Walk();
    Run();
    KeyJump();
   }

private void FixedUpdate()
   {
    Jump();
   }

private void Walk()
   {
     _vert = Input.GetAxis("Vertical");
     _horiz = Input.GetAxis("Horizontal"); 

     if(_vert!=0)
    {
        isMove = true;
        _moveDirect = transform.forward*_currentSpeed*_vert;
        _animator.animator.SetFloat("Velocity", Mathf.Abs(_vert));
    }
    else if(_vert<0.0f)
    {
        isMove = !isMove;
        
        _moveDirect=-transform.forward *_currentSpeed;
    }
    else
    {
        _moveDirect = Vector3.zero;
    }

    transform.Rotate(new Vector3(0.0f, _horiz* _RotSpeed, 0.0f));
   // _char.SimpleMove(_moveDirect);
    }

private void Jump()
{
_horiz = Input.GetAxis("Horizontal"); 
_vert = Input.GetAxis("Vertical");

if(_char.isGrounded)
{
    _moveDirect = new Vector3(_horiz, 0.0f, _vert)*_Speed;
    if(isJump)
    {
    _moveDirect.y += _Jump;
    _animator.animator.SetBool("isFlip",isJump);
    //isJump= false;
    }
    else
    {
        //_animator.animator.SetBool("isFlip",false);
    }
} 
else
    {
        _moveDirect.y -=_Gravity * Time.fixedDeltaTime;
        if(_moveDirect.y<0)
        {
            //_animator.animator.SetBool("Fall",true);
        }
    }
    _char.Move(_moveDirect*Time.fixedDeltaTime);
}

private void KeyJump()
{
    if(Input.GetKey(KeyCode.Space)&& _char.isGrounded)
    {
        isJump=true;
    }
    else if(Input.GetKeyUp(KeyCode.Space)&&!_char.isGrounded)
    {
        isJump=false;
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


}
