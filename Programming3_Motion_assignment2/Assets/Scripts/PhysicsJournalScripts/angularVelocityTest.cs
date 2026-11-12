using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class angularVelocityTest : MonoBehaviour
{
    public Rigidbody2D rb;
    public float spinSpeed;
    public float slowDownSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Vector3 closestPoint = rb.ClosestPoint(transform.up);

            Debug.Log(closestPoint);
        }

        if (Keyboard.current.aKey.isPressed)
        {
            rb.angularVelocity = spinSpeed;


        }
        else if (Keyboard.current.dKey.isPressed)
        {
            rb.angularVelocity = spinSpeed * -1;

        }
        else
        {
            rb.angularDamping = slowDownSpeed;
        }
    }

    void FixedUpdate()
    {
        

        


    }
}
