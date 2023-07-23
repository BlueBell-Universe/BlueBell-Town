using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStat : MonoBehaviour
{
    [SerializeField] private float hp = 100;
    public float currentHp;
    [SerializeField] private float atk = 10;
    [SerializeField] private float del;
    [SerializeField] private float exp;

    public GameObject HpBarBackground;
    public Image HpBarFilled;
    public GameObject[] dropItem;
    void Start()
    {
        currentHp = hp;
        HpBarFilled.fillAmount = 1f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collObj = collision.gameObject;
        if (collObj.CompareTag("SkillObj"))
        {
            float hit = collObj.GetComponent<FireObject>().damage;
            Hit(hit);
        }
    }
    public void Hit(float _hit)
    {
        if (!HpBarBackground.activeInHierarchy)
        {
            HpBarBackground.SetActive(true);
        }
        currentHp -= _hit;
        HpBarFilled.fillAmount = currentHp / hp;
        if (currentHp <= 0)
        {
            Dead();
        }
    }


    public void Dead()
    {
        foreach (GameObject _dropItem in dropItem)
        {
            Instantiate(_dropItem,gameObject.transform.position,Quaternion.identity);
        }
        Destroy(gameObject);

    }
}
