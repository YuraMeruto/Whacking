using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class SendScore : MonoBehaviour
{
    public void Start()
    {
        //ログイン処理実行
        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    //ログイン成功
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        UpdateUserName();
    }

    //ログイン失敗
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    /// <summary>
    /// ユーザ名を更新する
    /// </summary>
    public void UpdateUserName()
    {
        //ユーザ名を指定して、UpdateUserTitleDisplayNameRequestのインスタンスを生成
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = "hoge"
        };

        //ユーザ名の更新
        Debug.Log($"ユーザ名の更新開始");
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnUpdateUserNameSuccess, OnUpdateUserNameFailure);
    }

    //ユーザ名の更新成功
    private void OnUpdateUserNameSuccess(UpdateUserTitleDisplayNameResult result)
    {
        //result.DisplayNameに更新した後のユーザ名が入ってる
        Debug.Log($"ユーザ名の更新が成功しました : {result.DisplayName}");
    }

    //ユーザ名の更新失敗
    private void OnUpdateUserNameFailure(PlayFabError error)
    {
        Debug.LogError($"ユーザ名の更新に失敗しました\n{error.GenerateErrorReport()}");
    }

    private void GetRanking()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "JumpCount", // 統計情報名を指定します。
            StartPosition = 0, // 何位以降のランキングを取得するか指定します。
            MaxResultsCount = 100 // ランキングデータを何件取得するか指定します。最大が100です。
        };

        PlayFabClientAPI.GetLeaderboard(request, OnSuccess, OnError);

        void OnSuccess(GetLeaderboardResult leaderboardResult)
        {
            // 実際は良い感じのランキングを表示するコードにします。
            foreach (var item in leaderboardResult.Leaderboard)
            {
                // Positionは順位です。0から始まるので+1して表示しています。
                Debug.Log($"{item.Position + 1}位: {item.DisplayName} - {item.StatValue}回");
            }
        }

        void OnError(PlayFabError error)
        {
            Debug.Log($"{error.Error}");
        }
    }
}
