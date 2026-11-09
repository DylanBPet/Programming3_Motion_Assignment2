using UnityEngine;
using UnityEngine.InputSystem;

public class ForcesTest : MonoBehaviour
{
    public Rigidbody2D playerRB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            worldMousePos.z = 0;

            Vector3 directionToApplyForce = mousePos - transform.position;



            playerRB.AddForce(directionToApplyForce);
        }
    }
}
