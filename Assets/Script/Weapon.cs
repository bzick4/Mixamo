using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator {get; set;}
    private ChangeWeapon _changeWeapon;
    private bool _isKnife, _isSword;

private int yyy;
   

private void  Update() 
{
 Attack();
  Change();
}

private void Awake()
    {
        animator = GetComponent<Animator>();
        _changeWeapon = GetComponent<ChangeWeapon>();
    }

public void IdleAnim()
    {
        animator.SetBool("isIdle",true);
    }

    private void Change()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           switch (yyy)
           {
            case 0: 
                _isKnife=true;
                break;
            case 1:
                _isSword=true;
                break;
            default:
                break;
           }
        }
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



