using UnityEngine;

public class Jumping : MonoBehaviour
{
private Weapon _animator;
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
              Debug.Log($"{isJump0}");
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
              
            }
        }

 private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Jump0"))
            {
              isJump0=false;
              _animator.animator.SetBool("isJump0",false);
            }
            if(other.CompareTag("Jump1"))
            {
              isJump1=false;
              _animator.animator.SetBool("isJump1",false);
            }
            if(other.CompareTag("Jump2"))
            {
              isJump2=false;
              _animator.animator.SetBool("isJump2",false);
            }
            if(other.CompareTag("Jump3"))
            {
              
            }
        }




private void PressJump()
{
    if(Input.GetKeyDown(KeyCode.F)&& isJump0)
    {
        _animator.animator.SetBool("isJump0",true);
    }
    if(Input.GetKeyDown(KeyCode.F)&& isJump1)
    {
        _animator.animator.SetBool("isJump1",true);
    }
    if(Input.GetKeyDown(KeyCode.F)&& isJump2)
    {
        _animator.animator.SetBool("isJump2",true);
    }
}


}
