using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemScript : MonoBehaviour
{
    public ItemInfo itemInfo;
    public bool triggering = false;
    void Start()
    {
        itemInfo = new ItemInfo(gameObject, gameObject.name, gameObject.tag);
        itemInfo.SetItemAmount();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggering)
        {
            triggering = true;
            if (collision.transform.CompareTag("Player"))
            {
                Debug.Log(name.Substring(0, name.IndexOf("(")) + ":" + itemInfo.itemAmount);
                BackendGameData.Instance.GamedataUpdate(itemInfo.itemAmount);
                Destroy(gameObject);
            }
        }
    }


}
