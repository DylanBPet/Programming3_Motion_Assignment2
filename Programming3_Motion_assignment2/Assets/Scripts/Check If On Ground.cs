using UnityEngine;

public class CheckIfOnGround : MonoBehaviour
{
    public PlayerVisuals controllerScript;
    public BoxCollider2D feetBoxCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        controllerScript.touchingGround = true;
        Debug.Log("touched ground");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        controllerScript.touchingGround = false;
        Debug.Log("left ground");
    }
}
