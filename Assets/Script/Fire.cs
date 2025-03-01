using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject _Hero, _FireBall;
    [SerializeField] private ParticleSystem _Fire, _Cirlce;

    private Weapon _animation;


    private void Awake()
    {
        _animation = GetComponentInChildren<Weapon>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            _Fire.Play();
            _Cirlce.Play();

            if(_Hero.activeSelf)
            {
                _animation.animator.SetTrigger("Transform");
               StartCoroutine("TransformToFire",2f);
            }
            else if(_FireBall.activeSelf)
            {
                StartCoroutine("TransformToHero",2f);
            }
        }
    }

    private IEnumerator TransformToHero()
    {
        yield return new WaitForSeconds(1.4f);
        _Hero.SetActive(true);
        _FireBall.SetActive(false);
    }

    private IEnumerator TransformToFire()
    {
        yield return new WaitForSeconds(1.4f);
        _FireBall.SetActive(true);
        _Hero.SetActive(false);
        
    }

}
