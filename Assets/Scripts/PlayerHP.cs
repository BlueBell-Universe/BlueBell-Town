using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float HP = 100;
    [SerializeField] public Image hpBar;
    [SerializeField] public Text hpText;
    private Animator animator;
    private float currentHP;

    public MonsterStat monsterStat;
    public bool isColliding = false;
    public bool isInv = false;
    public SpriteRenderer[] sprites;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHP = HP;
        hpText.text = currentHP + "/" + HP;
        monsterStat = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterStat>();
        sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }
    public void OnDamaged(float damage)
    {
        currentHP -= damage;
        hpText.text = currentHP + "/" + HP;
        hpBar.fillAmount = currentHP / HP;
        if (currentHP <= 0)
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        animator.SetTrigger("die");
        Application.Quit();
        // 부활 선택창 표시
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MonsterAttack") && !isInv)
        {
            if (isColliding)
            {
                return;
            }
            isColliding = true;
            OnDamaged(monsterStat.atk);
            isInv = true;
            StartCoroutine(Reset());
            StartCoroutine(OnInv());
        }
    }
    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }
    IEnumerator OnInv()
    {
        StartCoroutine(OnColorChange());
        yield return new WaitForSeconds(1f);
        isInv = false;
    }
    IEnumerator OnColorChange()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = new Color(1, 1, 1, 0.5f);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = new Color(1, 1, 1, 1);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = new Color(1, 1, 1, 0.5f);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = new Color(1, 1, 1, 1);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = new Color(1, 1, 1, 0.5f);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = new Color(1, 1, 1, 1);
        }
    }
}
