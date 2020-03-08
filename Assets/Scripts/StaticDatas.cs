using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDatas : MonoBehaviour
{
    static StaticDatas instance = new StaticDatas();
    public static StaticDatas Instance { get { return instance; } }
    List<int> random_enemy_list = new List<int>();
    bool is_game_play = true;
    PlayFabAPI play_fab_api;

    UpdateManager update_manager = new UpdateManager();
    BoxManager box_manager = new BoxManager();
    TimeManager time_manger = new TimeManager();
    EnemyManager enemy_manager = new EnemyManager();
    UIManager ui_manager = new UIManager();
    SEManager se_manager = new SEManager();
    BgmManager bgm_manager = new BgmManager();
    GameObject destroy_effect_object;

    public bool IsGamePlay { get { return is_game_play; } set { is_game_play = value; } }
    public List<int> RandomEnemyList { get { return random_enemy_list; } set { random_enemy_list = value; } }
    public TimeManager TimeManger { get { return time_manger; } }
    public UpdateManager UpdateManager { get { return update_manager; } }
    public BoxManager BoxManager { get { return box_manager; } }
    public EnemyManager EnemyManager { get { return enemy_manager; } }
    public UIManager UIManger { get { return ui_manager; } }
    public SEManager SeManager { get { return se_manager; } }
    public BgmManager BgmManager { get { return bgm_manager; } }
    public GameObject EffectObject { get { if (destroy_effect_object == null) { destroy_effect_object = Resources.Load<GameObject>(ResourcesObject.DESTROY_EFFECT); } return destroy_effect_object; }}
    public PlayFabAPI PlayFabAPI
    {
        get
        {
            Debug.Log(play_fab_api);
            if (play_fab_api == null)
            {
                play_fab_api = new GameObject("PlayFabAPI").AddComponent<PlayFabAPI>();
                DontDestroyOnLoad(play_fab_api);
                play_fab_api.Ini(true);
            }
            return play_fab_api;
        }
    }

    public void Ini()
    {
        update_manager = new GameObject().AddComponent<UpdateManager>();
        box_manager.Ini();
        ui_manager.Ini();
        se_manager.Ini();
        bgm_manager.Ini();
        bgm_manager.BgmPlay(BgmManager.Status.Game);
        IsGamePlay = true;
        var api = StaticDatas.Instance.PlayFabAPI;
    }
}
