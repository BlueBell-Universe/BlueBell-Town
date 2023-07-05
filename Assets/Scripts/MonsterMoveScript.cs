using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveScript : MonoBehaviour
{
    RaycastHit2D hitBtm, hitFt; //hitBottom, hitFront
    SpriteRenderer spriteRenderer;
    float rayBtmLength = 0.5f;
    float rayFtLength = 0.05f;
    float moveSpeed = 1f;
    float flipX = 1f;
    private void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        Debug.Log("ground : " + CheckGround());
        Debug.Log("front : " + CheckFront());
        if (hitBtm && !hitFt)
        {
            MonsterMove();
        }
        else if ((!hitBtm || hitFt)|| (hitBtm && hitFt))
        {
            flipX *= -1;
            spriteRenderer.flipX =! spriteRenderer.flipX;
        }
        //else if (hitBtm && hitFt)
        //{
        //    flipX *= -1;
        //    spriteRenderer.flipX = !spriteRenderer.flipX;

        //}
    }
    public bool CheckGround()
    {
        Vector2 startRay = new Vector2(transform.position.x + flipX * 0.3f, transform.position.y - 0.25f);
        Debug.DrawRay(startRay, -transform.up * rayBtmLength, Color.red);
        hitBtm = Physics2D.Raycast(startRay, -transform.up, rayBtmLength);
        if (hitBtm)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckFront()
    {
        Vector2 startRay = new Vector2(transform.position.x + flipX * 0.35f, transform.position.y - 0.2f);
        Debug.DrawRay(startRay, transform.right * rayFtLength, Color.red);
        hitFt = Physics2D.Raycast(startRay, transform.right, rayFtLength);
        if (hitFt)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void MonsterMove()
    {
        //¿Ãµø
        transform.position = new Vector2(transform.position.x + flipX * moveSpeed * Time.deltaTime, transform.position.y);
        //µÙ∑π¿Ã
    }
}
