using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    #region Contents
    GameManager _game = new GameManager();

    public static GameManager Game { get { return Instance._game; } }
    #endregion

    #region Core    
    InputManager _input = new InputManager();
    SoundManager _sound = new SoundManager();
    ResourceManager _resource = new ResourceManager();
    SceneManagerEx _scene = new SceneManagerEx();
    UIManager _ui = new UIManager();
    PoolManager _pool = new PoolManager();
    DataManager _data = new DataManager();

    public static InputManager Input { get { return Instance._input; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static DataManager Data { get { return Instance._data; } }


    #endregion

    void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            s_instance._sound.Init();
            s_instance._pool.Init();
            s_instance._data.Init();

        }

    }

    public static void Clear()
    {
        Pool.Clear();
        Sound.Clear();
        Input.Clear();
        UI.Clear();
        Scene.Clear();
    }
}
