using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using BackEnd;


public class UserData
{
    public int level = 1;
    public int gold = 0;
    public float atk = 3.5f;
    public string info = string.Empty;
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public List<string> equipment = new List<string>();

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"level : {level}");
        result.AppendLine($"gold : {gold}");
        result.AppendLine($"atk : {atk}");
        result.AppendLine($"info : {info}");

        result.AppendLine($"inventory");
        foreach(var itemKey in inventory.Keys)
        {
            result.AppendLine($"| {itemKey} : {inventory[itemKey]}��");
        }

        result.AppendLine($"equipment");
        foreach(var equip in equipment)
        {
            result.AppendLine($"| {equip}");
        }
        return result.ToString();
    }
}

public class BackendGameData
{
    private static BackendGameData _instance = null;

    public static BackendGameData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendGameData();
            }

            return _instance;
        }
    }

    public static UserData userData;

    private string gameDataRowInDate = string.Empty;


    // �������� ����
    public void GameDataInsert()
    {
        if(userData == null)
        {
            userData = new UserData();
        }

        Debug.Log("�����͸� �ʱ�ȭ�մϴ�.");
        userData.level = 1;
        userData.gold = 100;
        userData.atk = 3.5f;
        userData.info = "ģ�ߴ� ������ ȯ���Դϴ�.";

        userData.equipment.Add("�߽� �������� ����");
        userData.equipment.Add("�߽� �������� ��");
        userData.equipment.Add("�߽� �������� �Ź�");

        userData.inventory.Add("����Ʈ ��ǰ1",1);
        userData.inventory.Add("����Ʈ ��ǰ2",1);
        userData.inventory.Add("����Ʈ ��ǰ3",1);

        Debug.Log("�ڳ� ������Ʈ ��Ͽ� �ش� �����͵��� �߰��մϴ�.");
        Param param = new Param();
        param.Add("level", userData.level);
        param.Add("gold", userData.gold);
        param.Add("atk", userData.atk);
        param.Add("info", userData.info);
        param.Add("equipment", userData.equipment);
        param.Add("inventory", userData.inventory);

        Debug.Log("�������� ������ ������ ��û�մϴ�.");
        var bro = Backend.GameData.Insert("USER_DATA", param);

        if(bro.IsSuccess())
        {
            Debug.Log("�������� ������ ���Կ� �����߽��ϴ�.");

            gameDataRowInDate = bro.GetInDate();
        }
        else
        {
            Debug.LogError("�������� ������ ���Կ� �����߽��ϴ�." + bro);
        }
    }

    public void GameDataGet()
    {
        Debug.Log("���� ���� ��ȸ �Լ��� ȣ���մϴ�.");
        var bro = Backend.GameData.GetMyData("USER_DATA", new Where());
        if (bro.IsSuccess())
        {
            Debug.Log("���� ���� ��ȸ�� �����߽��ϴ�. : " + bro);


            LitJson.JsonData gameDataJson = bro.FlattenRows(); // Json���� ���ϵ� �����͸� �޾ƿɴϴ�.

            // �޾ƿ� �������� ������ 0�̶�� �����Ͱ� �������� �ʴ� ���Դϴ�.
            if (gameDataJson.Count <= 0)
            {
                Debug.LogWarning("�����Ͱ� �������� �ʽ��ϴ�.");
            }
            else
            {
                gameDataRowInDate = gameDataJson[0]["inDate"].ToString(); //�ҷ��� ���������� �������Դϴ�.

                userData = new UserData();

                userData.level = int.Parse(gameDataJson[0]["level"].ToString());
                userData.gold = int.Parse(gameDataJson[0]["gold"].ToString());
                userData.atk = float.Parse(gameDataJson[0]["atk"].ToString());
                userData.info = gameDataJson[0]["info"].ToString();

                foreach (string itemKey in gameDataJson[0]["inventory"].Keys)
                {
                    userData.inventory.Add(itemKey, int.Parse(gameDataJson[0]["inventory"][itemKey].ToString()));
                }

                foreach (LitJson.JsonData equip in gameDataJson[0]["equipment"])
                {
                    userData.equipment.Add(equip.ToString());
                }

                Debug.Log(userData.ToString());
            }
        }
        else
        {
            Debug.LogError("���� ���� ��ȸ�� �����߽��ϴ�. : " + bro);
        }
    }

    public void LevelUp()
    {
        userData.level += 1;
        userData.atk += 3.5f;
        Debug.Log("������!\n" + userData);
    }

    public void GamedataUpdate()
    {
        if(userData == null)
        {
            Debug.LogError("�������� �ٿ�ްų� ���� ������ �����Ͱ� �������� �ʽ��ϴ�. Insert Ȥ�� Get�� ���� �����͸� �������ּ���.");
            return;
        }

        Param param = new Param();
        param.Add("level", userData.level);
        param.Add("gold", userData.gold);
        param.Add("atk", userData.atk);
        param.Add("info", userData.info);
        param.Add("equipment", userData.equipment);
        param.Add("inventory", userData.inventory);

        BackendReturnObject bro = null;

        if(string.IsNullOrEmpty(gameDataRowInDate))
        {
            Debug.Log("�� ���� �ֽ� �������� ������ ������ ��û�մϴ�.");
            bro = Backend.GameData.Update("USER_DATA", new Where(), param);
        }
        else
        {
            Debug.Log($"{gameDataRowInDate}�� �������� ������ ������ ��û�մϴ�.");

            bro = Backend.GameData.UpdateV2("USER_DATA", gameDataRowInDate, Backend.UserInDate, param);
        }

        if(bro.IsSuccess())
        {
            Debug.Log("�������� ������ ������ �����߽��ϴ�. : " + bro);
        }
        else
        {
            Debug.LogError("�������� ������ ������ �����߽��ϴ�. : " + bro);
        }
    }
}