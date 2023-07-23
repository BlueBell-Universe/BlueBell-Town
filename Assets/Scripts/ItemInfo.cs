using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo 
{
    public GameObject itemObj;
    public string itemName;
    public string itemCode;
    public string itemType;
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
                itemType = "����";
                break;
            case "2":
                itemType = "����Ʈ������";
                break;
            case null:
                itemType = "��Ÿ ������";
                break;
        }
        return itemType;
    }


}