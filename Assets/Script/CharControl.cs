
using UnityEngine;

public class CharControl : BaseCharControl
{
    private CharacterController _characterController;

    private void Start() => _characterController = GetComponent<CharacterController>();

    private new void Update()
    {
        base.Update();
        _characterController.Move(_MovementVector * _MovementSpeed * Time.deltaTime);
    }
}
