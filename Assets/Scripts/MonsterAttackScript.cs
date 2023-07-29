using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackScript : MonoBehaviour
{
    public GameObject player;
    public PlayerHP playerHP;
    public MonsterStat monsterStat;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHP = player.GetComponent<PlayerHP>();
        monsterStat = GetComponentInParent<MonsterStat>();
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("trigger");
    //    if (other.gameObject.tag == "player")
    //    {
    //        Debug.Log("player trigger");
    //        playerHP.OnDamaged(monsterStat.atk);
    //    }
    //}


}
