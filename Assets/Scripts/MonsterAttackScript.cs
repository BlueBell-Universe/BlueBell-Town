using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackScript : MonoBehaviour
{
    public GameObject monsterAttack;

    public void SetAttackTrue()
    {
        monsterAttack.SetActive(true);
    }
    public void SetAttackFalse()
    {
        monsterAttack.SetActive(false);
    }
    public IEnumerator Attack()
    {
        yield return new WaitUntil(() => Timer(0.5f));
        monsterAttack.SetActive(false);

    }
    public bool Timer(float timerSet)
    {
        float timer = 0;
        while (timer < timerSet)
        {
            timer += Time.deltaTime;
        }
        return true;
    }


}
