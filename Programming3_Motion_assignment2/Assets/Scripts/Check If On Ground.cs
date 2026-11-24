using System.Collections;
using UnityEngine;

public class CheckIfOnGround : MonoBehaviour
{
    public PlayerVisuals visualsScript;
    public BoxCollider2D feetBoxCollider;
    public PlayerController controllerScript;

    public float coyoteTime;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopAllCoroutines();
        visualsScript.touchingGround = true;
        Debug.Log("touched ground");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        controllerScript.StartCoroutine(CoyoteTimeCheck());
        Debug.Log("left ground");
    }

    public IEnumerator CoyoteTimeCheck()
    {
        Debug.Log("checking Time");
        yield return new WaitForSeconds(coyoteTime);
        visualsScript.touchingGround = false;

    }
}
