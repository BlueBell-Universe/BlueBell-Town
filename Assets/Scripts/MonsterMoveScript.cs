using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveScript : MonoBehaviour
{
    [Header("Move")]
    RaycastHit2D hitBtm, hitFt; //hitBottom, hitFront
    SpriteRenderer spriteRenderer;
    float rayBtmLength = 0.5f;
    float rayFtLength = 0.05f;
    float moveSpeed = 1f;
    float flipX = 1f;

    [Header("Attack")]
    MonsterAttackScript monsterAttackScript;
    RaycastHit2D hitPlayer;
    public float rayPlayerLength = 0.5f;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        monsterAttackScript = GetComponent<MonsterAttackScript>();
    }
    private void Update()
    {
        Debug.Log("ground : " + CheckGround());
        Debug.Log("front : " + CheckFront());
        if (CheckGround() && !CheckFront())
        {
            MonsterMove();
        }
        else if ((!CheckGround() || CheckFront())|| (CheckGround() && CheckFront()))
        {
            flipX *= -1;
            spriteRenderer.flipX =! spriteRenderer.flipX;
        }
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

    public void CheckPlayer()
    {
        Vector2 startRay = new Vector2(transform.position.x + flipX * 0.3f, transform.position.y - 0.25f);
        Debug.DrawRay(startRay, -transform.up * rayPlayerLength, Color.red);
        hitPlayer = Physics2D.Raycast(startRay, -transform.up, rayPlayerLength);
        if (hitPlayer.transform.CompareTag("Player"))
        {
            //follow player

        }
    }

}
