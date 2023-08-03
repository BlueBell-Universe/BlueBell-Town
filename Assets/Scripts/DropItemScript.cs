using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemScript : MonoBehaviour
{
    public ItemInfo itemInfo;
    void Start()
    {
        itemInfo = new ItemInfo(gameObject, gameObject.name, gameObject.tag);
        itemInfo.SetItemAmount();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log(name.Substring(0,name.IndexOf("(")) + ":" + itemInfo.itemAmount);
            BackendGameData.Instance.GamedataUpdate(itemInfo.itemAmount);
            Destroy(gameObject);
        }
    }

}
