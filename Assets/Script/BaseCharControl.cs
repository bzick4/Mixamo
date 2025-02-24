
using UnityEngine;

public class BaseCharControl : MonoBehaviour
{
    [SerializeField]
    protected private float _MovementSpeed = 6;

    protected private Vector3 _MovementVector;

    protected private void Update() => _MovementVector = (transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward).normalized;
}
