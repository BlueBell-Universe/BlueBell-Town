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
    RaycastHit2D hitPlayerFront, hitPlayerBack;
    public float rayPlayerLength = 0.5f;
    [SerializeField] private float x_f;
    [SerializeField] private float y_f;
    [SerializeField] public float x_b;
    [SerializeField] private float y_b;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        monsterAttackScript = GetComponent<MonsterAttackScript>();
    }
    private void Update()
    {
        if (CheckPlayerFront())
        {
            MonsterMove();
        }
        else if (CheckPlayerBack())
        {
            flipX *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        else
        {
            if (CheckGround() && !CheckFront())
            {
                MonsterMove();
            }
            else if ((!CheckGround() || CheckFront()) || (CheckGround() && CheckFront()))
            {
                flipX *= -1;
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
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

    public bool CheckPlayerFront()
    {
        Vector2 frontRay = new Vector2(transform.position.x + flipX * 0.4f, transform.position.y + -0.1f);
        Debug.DrawRay(frontRay, transform.right * rayPlayerLength, Color.blue);
        hitPlayerFront = Physics2D.Raycast(frontRay, transform.right, rayPlayerLength);
        if (hitPlayerFront)
        {
            if (hitPlayerFront.transform.CompareTag("Player"))
            {
                return true;
            }
            else return false;
        }
        else
        {
            return false;
        }
    }
    public bool CheckPlayerBack()
    {
        Vector2 backRay = new Vector2(transform.position.x + flipX * -0.4f, transform.position.y + -0.1f);
        Debug.DrawRay(backRay, -transform.right * rayPlayerLength, Color.blue);
        hitPlayerBack = Physics2D.Raycast(backRay, -transform.right, rayPlayerLength);
        if (hitPlayerBack)
        {
            if (hitPlayerBack.transform.CompareTag("Player"))
            {
                //follow player

                return true;
            }
            else return false;
        }
        else
        {
            return false;
        }
    }

    public void FollowPlayer(float flipX)
    {
        transform.position = new Vector2(transform.position.x + flipX * moveSpeed * Time.deltaTime, transform.position.y);

    }

}
