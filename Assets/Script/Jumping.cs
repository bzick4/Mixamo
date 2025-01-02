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
              
            }
            if(other.CompareTag("Jump2"))
            {
              
            }
            if(other.CompareTag("Jump3"))
            {
              
            }
        }

 private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Jump0"))
            {
              isJump0 = false;
             
              _animator.animator.ResetTrigger("Jump0");
            }
            if(other.CompareTag("Jump1"))
            {
              
            }
            if(other.CompareTag("Jump2"))
            {
              
            }
            if(other.CompareTag("Jump3"))
            {
              
            }
        }




private void PressJump()
{
    if(Input.GetKeyDown(KeyCode.Space))
    {
      if(isJump0)
      {
        _animator.animator.SetTrigger("Jump0");
      }
    }
}


}
