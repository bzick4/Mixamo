using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jumping : MonoBehaviour
{
private Weapon _animator;
private bool isJump1=true;


private void Awake()
{
    _animator = GetComponent<Weapon>();
}


       private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Jump1"))
            {
                if(isJump1)
                {
                  _animator.animator.SetTrigger("Jump1");
                }
                PressJump();
            }
        
        }

private void PressJump()
{
    if(Input.GetKeyDown(KeyCode.Space))
    {
      isJump1 = false;
    }
}


}
