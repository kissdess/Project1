using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        // Managers.UI.ShowPopupUI<UI>("UI");
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
        gameObject.GetOrAddComponent<CursorController>();

        // GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "Player");
        // Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);
        //Managers.Game.Spawn(Define.WorldObject.Monster, "Monster");
        //GameObject go = new GameObject { name = "SpawningPool" };
        //SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
        //pool.SetKeepMonsterCount(5);
    }

    public override void Clear()
    {

    }




}
