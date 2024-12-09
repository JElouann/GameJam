using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction;

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("sdihfiusd");
        _direction = new Vector3(context.ReadValue<Vector2>().x, 0 , context.ReadValue<Vector2>().y);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);
    }
}