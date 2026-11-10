using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingBoxcast : MonoBehaviour
{
    public Vector2 boxOrigin;
    public Vector2 boxSize;
    public float boxAngle;
    public float boxMaxDistance;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 direction = (Vector2)worldMousePos - boxOrigin;

            RaycastHit2D hasBeenHit = Physics2D.BoxCast(boxOrigin, boxSize, boxAngle, direction, boxMaxDistance);

            Debug.Log(hasBeenHit.collider);
            Debug.Log(hasBeenHit.distance);
        }
    }

   
}
