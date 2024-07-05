using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrnetScene { get { return Object.FindFirstObjectByType<BaseScene>(); } }


    public void LoadScene(Define.Scene type)
    {
        Managers.Clear();
        SceneManager.LoadScene(GetSceneName(type));

    }

    string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        return name;
    }

    public void Clear()
    {
        CurrnetScene.Clear();
    }

}
