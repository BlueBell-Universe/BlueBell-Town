using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks; // [변경] async 기능을 이용하기 위해서는 해당 namepsace가 필요합니다.

// 뒤끝 SDK namespace 추가
using BackEnd;

public class BackendManager : MonoBehaviour
{
    public InputField input;

    void Start()
    {
        var bro = Backend.Initialize(true); // 뒤끝 초기화

        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success
        }
        else
        {
            Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생 
        }
        Test();
        DontDestroyOnLoad(this);
    }

    public void GetGoogleHash()
    {
        string googlehash = Backend.Utils.GetGoogleHash();
        Debug.Log("Hash");
        if(!string.IsNullOrEmpty(googlehash))
        {
            Debug.Log(googlehash);
            if(input != null)
            {
                input.text = googlehash;
            }
        }
    }

    // =======================================================
    // [추가] 동기 함수를 비동기에서 호출하게 해주는 함수(유니티 UI 접근 불가)
    // =======================================================
    async void Test()
    {
        // [추가] 뒤끝 회원가입 함수
        //await Task.Run(() => {
        //    BackendLogin.Instance.CustomSignUp("user1", "1234");
        //    Debug.Log("테스트를 종료합니다.");
        //});

        // [추가] 뒤끝 회원가입 함수
        //await Task.Run(() => {
        //    BackendLogin.Instance.CustomLogin("user1", "1234"); 
        //    Debug.Log("테스트를 종료합니다.");
        //});

        // [추가] 닉네임 변겅
        //await Task.Run(() =>
        //{
        //    BackendLogin.Instance.CustomLogin("user1", "1234"); // [추가] 뒤끝 로그인
        //});

        // [추가] 데이터 삽입함수
        //await Task.Run(() =>
        //{
        //    BackendLogin.Instance.CustomLogin("user1","1234");
        //    BackendGameData.Instance.GameDataInsert();
        //    Debug.Log("테스트 종료");
        //});

        // [추가] 데이터 불러오기 함수
        //await Task.Run(() =>
        //{
        //    BackendLogin.Instance.CustomLogin("user1", "1234");
        //    BackendGameData.Instance.GameDataInsert();
        //    BackendGameData.Instance.GameDataGet();
        //    Debug.Log("테스트 종료");
        //});

        // [추가] 데이터 변경 및 덮어쓰기 함수
        await Task.Run(() =>
        {
            BackendLogin.Instance.CustomLogin("user1", "1234");

            BackendGameData.Instance.GameDataGet();
            
            if(BackendGameData.userData == null)
            {
                BackendGameData.Instance.GameDataInsert();
            }

            BackendGameData.Instance.LevelUp();
            BackendGameData.Instance.GamedataUpdate();

            Debug.Log("테스트 종료");
        });

    }
}