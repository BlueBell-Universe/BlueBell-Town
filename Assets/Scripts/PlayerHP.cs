using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float HP = 100;
    [SerializeField] public Image hpBar;
    private float currentHP;

    private void Awake()
    {
        currentHP = HP;
    }

    public void OnDamaged(float damage)
    {
        currentHP -= damage;
        hpBar.fillAmount = currentHP / HP;
        if(currentHP <= 0)
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        Destroy(gameObject);
        // 부활 선택창 표시
    }
}
