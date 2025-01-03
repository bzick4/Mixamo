using UnityEngine;

public class Jumping : MonoBehaviour
{

  [SerializeField] Transform _point;
private Weapon _animator;
private Controller _controller;
private bool isJump0, isJump1, isJump2, isJump3;


private void Awake()
{
    _animator = GetComponent<Weapon>();
}

private void Update()
{
  PressJump();
}


       private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Jump0"))
            {
              isJump0 = true;     
            }
            if(other.CompareTag("Jump1"))
            {
              isJump1=true;
            }
            if(other.CompareTag("Jump2"))
            {
               isJump2=true;
            }
            if(other.CompareTag("Jump3"))
            {
               isJump3=true;
            }
        
        }

 private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Jump0"))
            {
              isJump0=false;        
            }
            if(other.CompareTag("Jump1"))
            {
              isJump1=false;
              
            }
            if(other.CompareTag("Jump2"))
            {
              isJump2=false;
              
            }
             if(other.CompareTag("Jump3"))
            {
              isJump3=false;
              
            }
        }




private void PressJump()
{
    if(Input.GetKeyDown(KeyCode.F)&& isJump0)
    {
       _animator.animator.SetTrigger("Jump0");
    }
    if(Input.GetKeyDown(KeyCode.F)&& isJump1)
    {
        _animator.animator.SetTrigger("Jump1");
    }
    if(Input.GetKeyDown(KeyCode.F)&& isJump2)
    {
        _animator.animator.SetTrigger("Jump2");
    }
     if(Input.GetKeyDown(KeyCode.F)&& isJump3)
    {
        _animator.animator.SetTrigger("Jump3");
    }
}


}
