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

   public bool isMove{get;set;}
   private bool isJump, isJumping;
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
    //Walk();
    Run();
    KeyJump();
   }

private void FixedUpdate()
   {
    Jump();
    Walk();
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
   //_char.SimpleMove(_moveDirect);
    _char.Move(_moveDirect*Time.fixedDeltaTime);
    }

private void Jump()
{
_horiz = Input.GetAxis("Horizontal"); 
_vert = Input.GetAxis("Vertical");

if(_char.isGrounded)
{
    _animator.animator.SetBool("isFall",false);
    _moveDirect = new Vector3(_horiz, 0.0f, _vert)*_Speed;
    if(isJumping)
    {
        _animator.animator.SetBool("isJump",true);
    _moveDirect.y += _Jump;

    } 
}
else
    {
        _moveDirect.y -=_Gravity * Time.fixedDeltaTime;
        if(_moveDirect.y<0.2f)
        {
            _animator.animator.SetBool("isJump",false);
           _animator.animator.SetBool("isFall",true);
          // Invoke("Fall",1.5f);
        }
        
    }
   _char.Move(_moveDirect*Time.fixedDeltaTime);
}

private void KeyJump()
{
    if(Input.GetKey(KeyCode.Space)&& isJump)
    {
        // _animator.animator.SetBool("isJump",true);
        isJump=false;  
        isJumping=true; 
    }
    else if(Input.GetKeyUp(KeyCode.Space)&& !isJump)
    {
        //  _animator.animator.SetBool("isJump",false);
        isJump=true;
        isJumping=false;
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

private void Fall()
{
    _animator.animator.SetBool("isFall",false);
}

}
