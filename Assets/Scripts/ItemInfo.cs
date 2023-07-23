using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo 
{
    public GameObject itemObj;
    public string itemName;
    public string itemCode;
    public string itemType;
    public int itemAmount;
    public ItemInfo(GameObject _itemObj,string _itemName, string _itemCode)
    {
        itemObj = _itemObj;
        itemName = _itemName;
        itemCode = _itemCode; 
    }

    public string checkItemType()
    {
        switch (itemCode.Substring(0, itemCode.IndexOf("_")))
        {
            case "1":
                itemType = "코인";
                break;
            case "2":
                itemType = "퀘스트아이템";
                break;
            case null:
                itemType = "기타 아이템";
                break;
        }
        return itemType;
    }

    public int SetItemAmount()
    {
        itemAmount = Random.Range(1, 10);

        return itemAmount;
    }


}
