
using UnityEngine;

public class Jumping : MonoBehaviour
{

private Weapon _animator;
private CharacterController _controller;
private int _jump=-1;

private void Awake()
{
    _animator = GetComponentInChildren<Weapon>();
}

private void Update()
{
  PressJump();
}

private void OnTriggerEnter(Collider other)
  {
    int randomJump = Random.Range(0,2);

    if(other.CompareTag("Jump0"))
      {
        _jump = randomJump;     
      }
    if(other.CompareTag("Jump2"))
      {
         _jump = 2;
      }
    if(other.CompareTag("Jump3"))
      {
        _jump = 3;
      }    
      Debug.Log($"{_jump}"); 
  }

 private void OnTriggerExit(Collider other)
  {
    if(other.CompareTag("Jump0") || other.CompareTag("Jump2") || other.CompareTag("Jump3"))
      {
        _jump = -1;        
      }
       Debug.Log($"{_jump}"); 
  }

private void PressJump()
{
  if(Input.GetKeyDown(KeyCode.Space))
  {
  switch(_jump)
  {
    case 0 :
        _animator.animator.SetTrigger("Jump0");
    break;
    case 1 :
        _animator.animator.SetTrigger("Jump1");
    break;
    case 2 :
         _animator.animator.SetTrigger("Jump2");
    break;
    case 3 :
         _animator.animator.SetTrigger("Jump3");
    break;

    default:
         //_controller.Move(new Vector3(0,0,0));
    break;
  }
}
}


}
