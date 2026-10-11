
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectLauncher : MonoBehaviour
{
    public float launchForce = 5f;
    public Vector3 launchDirection = Vector3.forward;

    private Rigidbody rb;
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && rb != null)
        {
            rb.AddForce(
                launchDirection.normalized * launchForce,
                ForceMode.Impulse
            );
        }

        if (Keyboard.current.rKey.wasPressedThisFrame && rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = startPosition;
            transform.rotation = startRotation;
        }
    }
}