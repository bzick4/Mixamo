using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator {get; set;}
    private ChangeWeapon _changeWeapon;


private int yyy;
   

private void  Update() 
{
 Attack();

}

private void Awake()
    {
        animator = GetComponent<Animator>();
        _changeWeapon = GetComponent<ChangeWeapon>();
    }    

private void Attack()
{
    if(Input.GetKeyDown(KeyCode.Mouse0))
    {
switch(_changeWeapon._currentWeaponIndex)
{
    case 0 :
    animator.SetTrigger("AttackKnife");
         StartCoroutine(StopAnimationAttack(2.68f));
         break;
         case 1:
         animator.SetTrigger("AttackSword");
         StartCoroutine(StopAnimationAttack(1.52f));
         break;
         default:
         break;

}
    }


    // if(Input.GetKeyDown(KeyCode.Mouse0))
    // {
    //     if(_changeWeapon._currentWeaponIndex==0)
    //     {
    //      animator.SetTrigger("AttackKnife");
    //      StartCoroutine(StopAnimationAttack(2.68f));
    //     }
    //     if(_changeWeapon._currentWeaponIndex==1)
    //     {
    //      animator.SetTrigger("AttackSword");
    //      StartCoroutine(StopAnimationAttack(1.52f));
    //     }
    // }
}
    private IEnumerator StopAnimationAttack(float deley)
    {
        yield return new WaitForSeconds(deley);
        animator?.SetTrigger("Idle");
    }




}



