using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 뒤끝 SDK namespace 추가
using BackEnd;

public class BackendLogin : MonoBehaviour
{
    private Text ID_Text, PW_Text;
    private Text SignUpID_Text, SignUpPW_Text, SignUpVerifyPW_Text;

    private static BackendLogin _instance = null;


    #region MonoBehaviour
    private void Awake()
    {
        ID_Text = GameObject.Find("ID_text").GetComponent<Text>();
        PW_Text = GameObject.Find("PW_text").GetComponent<Text>();
    }

    public void PanelActived()
    {
        SignUpID_Text = GameObject.Find("SignUpID_text").GetComponent<Text>();
        SignUpPW_Text = GameObject.Find("SignUpPW_text").GetComponent<Text>();
        SignUpVerifyPW_Text = GameObject.Find("SignUpPWVerify_text").GetComponent<Text>();
    }

    #endregion

    #region Backend
    public static BackendLogin Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendLogin();
            }

            return _instance;
        }
    }

    public void CustomSignUp(/*string id, string pw*/) // Step 2. 회원가입 구현하기 로직
    {
        Debug.Log("회원가입을 요청합니다.");

        if (SignUpPW_Text.text != SignUpVerifyPW_Text.text)
        {
            Debug.Log("패스워드 확인!\n" + "회원가입에 실패했습니다.");
        }

        var bro = Backend.BMember.CustomSignUp(SignUpID_Text.text, SignUpPW_Text.text);

        if (bro.IsSuccess())
        {
            Debug.Log("회원가입에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("회원가입에 실패했습니다. : " + bro);
        }
    }

    public void CustomLogin(/*string id, string pw*/) // Step 3. 로그인 구현하기 로직
    {
        Debug.Log("로그인을 요청합니다.");

        var bro = Backend.BMember.CustomLogin(ID_Text.text, PW_Text.text);

        if (bro.IsSuccess())
        {
            Debug.Log("로그인이 성공했습니다. : " + bro);
            SceneManager.LoadScene("JiHunScene");
        }
        else
        {
            Debug.LogError("로그인이 실패했습니다. : " + bro);
        }
    }

    public void UpdateNickname(string nickname) // Step 4. 닉네임 변경 구현하기 로직
    {
        Debug.Log("닉네임 변경을 요청합니다.");

        var bro = Backend.BMember.UpdateNickname(nickname);

        if (bro.IsSuccess())
        {
            Debug.Log("닉네임 변경에 성공했습니다 : " + bro);
        }
        else
        {
            Debug.LogError("닉네임 변경에 실패했습니다 : " + bro);
        }
    }
    #endregion
}