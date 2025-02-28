using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float _Speed, _RunSpeed, _RotSpeed;
    [SerializeField] float _Jump, _Gravity, forwardForce;
    private Vector3 _moveDirect;
    private Rigidbody _hero = null;
    private Weapon _animator;

    private bool isJump, isJumping, isMove;
    private float _currentSpeed;

    private float _vert, _horiz;


    private void Awake()
    {
        _hero = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Weapon>();
        _currentSpeed = _Speed;
        isMove = true;
    }

    private void Update()
    {
        _vert = Input.GetAxis("Vertical");
        _horiz = Input.GetAxis("Horizontal");
        KeyJump();

        if (isMove)
        {
            Walk();
        }
    }


    private void FixedUpdate()
    {

        
        if (isMove && isJumping)
        {
            Jump();
        }
    }

    private void Walk()
    {
    Vector3 inputDirection = new Vector3(_horiz, 0f, _vert);
    inputDirection.Normalize();
   
    Vector3 moveDirection = transform.TransformDirection(inputDirection);

    Vector3 targetVelocity = moveDirection * _currentSpeed;
    
    targetVelocity.y = _hero.velocity.y;

    Vector3 velocityChange = targetVelocity - _hero.velocity;

    _hero.AddForce(velocityChange, ForceMode.VelocityChange);

    _animator.animator.SetFloat("Velocity", _hero.velocity.magnitude);

        // _moveDirect = new Vector3(_horiz * _currentSpeed, _hero.velocity.y, _vert * _currentSpeed);

        // //_hero.velocity = _moveDirect;
        // _animator.animator.SetFloat("Velocity", Mathf.Abs(_vert));

    }

    private void Jump()
    {
        isMove = false;
        _hero.velocity = new Vector3(0f, _Jump, forwardForce);
        Invoke(nameof(EndJump), 5f);
    }

    private void EndJump()
    {
        isMove = true;
    }

    private void KeyJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = false;
            isJumping = true;
            _moveDirect.y = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isJump = true;
            isJumping = false;
        }
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) && isMove || Input.GetKeyDown(KeyCode.RightShift) && !isMove)
        {
            _currentSpeed = _RunSpeed;
            _animator.animator.SetBool("Run", true);
            Debug.Log($"{_currentSpeed}");
        }
        else if (Input.GetKeyUp(KeyCode.RightShift))
        {
            _currentSpeed = _Speed;
            _animator.animator.SetBool("Run", false);
        }
    }

    private void Fall()
    {
        _animator.animator.SetBool("isFall", false);
    }

}
