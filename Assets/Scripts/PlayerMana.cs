using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] private float Mana = 100;
    public Image manaBar;
    public Text manaText;
    public float currentMana;

    private void Awake()
    {
        currentMana = Mana;
        manaText.text = currentMana + "/" + Mana;
    }

    public void UseMana(float mana)
    {
        currentMana -= mana;
        manaText.text = currentMana + "/" + Mana;
        manaBar.fillAmount = currentMana / Mana;
    }
}
