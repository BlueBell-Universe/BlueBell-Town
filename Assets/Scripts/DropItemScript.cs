using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemScript : MonoBehaviour
{
    public ItemInfo itemInfo;
    void Start()
    {
        itemInfo = new ItemInfo(gameObject, gameObject.name, gameObject.tag);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("플레이어가 " + itemInfo.checkItemType() + "종류의 아이템 " + name.Substring(0,name.IndexOf("("))+"을/를 획득했습니다.");
            Destroy(gameObject);
        }
    }

}
