using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    private Animator animator;
    public GameObject FireObject;
    public GameObject EnergyBallObject;
    public PlayerMana playerManaScript;


    private void Start()
    {
        playerManaScript = GetComponent<PlayerMana>();
        animator = GetComponent<Animator>();
    }
    public void Skill1()
    {
        Vector3 targetPos;
        if (this.transform.eulerAngles.y > 0)
        {
            targetPos = new Vector3(transform.position.x - 1.0f, transform.position.y + 1.0f, -1.0f);
            Instantiate(FireObject, targetPos, Quaternion.Euler(0, 180, 0));
        }
        else
        {
            targetPos = new Vector3(transform.position.x + 1.0f, transform.position.y + 1.0f, -1.0f);
            Instantiate(FireObject, targetPos, Quaternion.identity);
        }

        if (playerManaScript.currentMana >= 5)
        {
            playerManaScript.UseMana(5);
            animator.SetTrigger("attack");
        }
        else return;
    }

    public void Skill2()
    {
        //Vector3 targetPos;
        //if (this.transform.eulerAngles.y > 0)
        //{
        //    targetPos = new Vector3(transform.position.x - 1.0f, transform.position.y + 0.5f, -1.0f);
        //    Instantiate(EnergyBallObject, targetPos, Quaternion.Euler(0, 180, 0));
        //}
        //else
        //{
        //    targetPos = new Vector3(transform.position.x + 1.0f, transform.position.y + 0.5f, -1.0f);
        //    Instantiate(EnergyBallObject, targetPos, Quaternion.identity);
        //}

        GameObject energyball = Instantiate(EnergyBallObject, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, -1.0f), transform.rotation);

        Rigidbody2D rigid = energyball.GetComponent<Rigidbody2D>();
        rigid.AddForce(transform.right * 10.0f, ForceMode2D.Impulse);
    }
}
