using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator { get; set; }
    private ChangeWeapon _changeWeapon;



    private void Update()
    {
        Attack();

    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        _changeWeapon = GetComponent<ChangeWeapon>();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            switch (_changeWeapon._currentWeaponIndex)
            {
                case 0:
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
    }
    private IEnumerator StopAnimationAttack(float deley)
    {
        yield return new WaitForSeconds(deley);
        animator?.SetTrigger("Idle");
    }




}



