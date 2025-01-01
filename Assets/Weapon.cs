using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _Knife, _Sword;

    public Animator animator {get; set;}

    private bool _isKnife, _isSword;



private void  Update() 
{
 Attack();
 ChangeWeapon();   
}



private void Awake()
    {
        animator = GetComponent<Animator>();
    }


private void ChangeWeapon()
{
    if(Input.GetKeyDown(KeyCode.Alpha1))
    {
      _Knife.SetActive(false);
      _Sword.SetActive(true);
      _isSword=true;
      _isKnife=false;
    }
    
    if(Input.GetKeyDown(KeyCode.Alpha2))
   {
      _Knife.SetActive(true);
      _Sword.SetActive(false);
      _isSword=false;
      _isKnife=true;
   }
}

public void IdleAnim()
    {
        animator.SetBool("isIdle",true);
    }

private void Attack()
{
    if(Input.GetKeyDown(KeyCode.Mouse0))
    {
        if(_isKnife)
        {
         animator.SetTrigger("AttackKnife");
         StartCoroutine(StopAnimationAttack(2.68f));
        }
        if(_isSword)
        {
         animator.SetTrigger("AttackSword");
         StartCoroutine(StopAnimationAttack(1.52f));
        }
    }
}
    private IEnumerator StopAnimationAttack(float deley)
    {
        yield return new WaitForSeconds(deley);
        animator?.SetTrigger("Idle");
    }




}



