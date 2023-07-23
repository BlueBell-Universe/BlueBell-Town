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
    RaycastHit2D hitPlayerFront, hitPlayerIn;
    public float rayPlayerLength = 1f;
    public float rayInLength = 0.6f;
    public GameObject monsterAttack;

    [Header("check Player")]
    [SerializeField] private bool move;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        monsterAttackScript = GetComponent<MonsterAttackScript>();
    }
    private void Update()
    {
        CheckPlayerIn();

        if (move == true)
        {
            if (!CheckPlayerFront() && CheckPlayerBack())
            {
                flipX *= -1;
            }
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
        if (hitFt&&!hitFt.transform.CompareTag("Player"))
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
        Vector2 frontRay;
        if (flipX == -1)
        {
            frontRay = new Vector2(transform.position.x -2.3f, transform.position.y + -0.1f);
        }
        else
        {
            frontRay = new Vector2(transform.position.x + 0.3f, transform.position.y + -0.1f);
        }
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
        Vector2 backRay;
        if (flipX == -1)
        {
            backRay = new Vector2(transform.position.x + 2.3f, transform.position.y + -0.1f);

        }
        else
        {
            backRay = new Vector2(transform.position.x -0.3f, transform.position.y + -0.1f);
        }
        Debug.DrawRay(backRay, -transform.right * rayPlayerLength, Color.white);
        hitPlayerIn = Physics2D.Raycast(backRay, -transform.right, rayPlayerLength);
        if (hitPlayerIn)
        {
            if (hitPlayerIn.transform.CompareTag("Player"))
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
    public bool CheckPlayerIn()
    {
        Vector2 inRay = new Vector2(transform.position.x - 0.3f, transform.position.y - 0.1f);
        Debug.DrawRay(inRay, transform.right * rayInLength, Color.red);
        hitPlayerIn = Physics2D.Raycast(inRay, transform.right, rayInLength);
        if (hitPlayerIn)
        {
            if (hitPlayerIn.transform.CompareTag("Player"))
            {
                //follow player
                move = false;
                SetAttackTrue();
                return true;
            }
            else
            {
                move = true;
                return false;
            }
        }
        else
        {
            move = true;
            return false;
        }
    }


    public void SetAttackTrue()
    {
        monsterAttack.SetActive(true);
        Invoke("SetAttackFalse", 1f);
    }
    public void SetAttackFalse()
    {
        monsterAttack.SetActive(false);
        Invoke("SetAttackTrue",1f);
    }
    //public void FollowPlayer(float flipX)
    //{
    //    transform.position = new Vector2(transform.position.x + flipX * moveSpeed * Time.deltaTime, transform.position.y);

    //}

}
