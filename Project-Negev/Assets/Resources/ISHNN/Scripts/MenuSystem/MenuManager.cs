using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager Instance { get; private set; }

    public enum MenuMode { Main = 0, Player }
    public MenuMode mode;

    //Main
    public MainMenu MainMenuprefab;
    public LoadMenu LoadMenuprefab;
    public NewGameMenu NewGameMenuprefab;

    //Game
    public PlayerMenu PlayerMenuprefab;
    public GearInvenMenu GearInvenMenuprefab;
    public MailListMenu MailListMenuprefab;
    public MailMenu MailMenuprefab;
    public SystemMenu SystemMenuprefab;

    public Stack<Menu> menuStack = new Stack<Menu>();

    private void Awake()
    {
        Instance = this;
        if (mode == MenuMode.Main)
        {
            OpenMenu<MainMenu>();
        }
        else if (mode == MenuMode.Player)
        {
            OpenMenu<PlayerMenu>();
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && menuStack.Count > 0)
        {
            menuStack.Peek().OnBackPressed();
        }
    }

    public void OpenMenu<T>() where T : Menu
    {
        var prefab = Getprefab<T>();
        var instance = Instantiate<Menu>(prefab,transform);

        //top 메뉴를 deactivate한다.
        if (menuStack.Count > 0)
            menuStack.Peek().gameObject.SetActive(false);

        menuStack.Push(instance);
    }

    public void CloseMenu()
    {
        var instance = menuStack.Pop();
        Destroy(instance.gameObject);

        //top 메뉴를 Activate한다.
        if (menuStack.Count > 0)
            menuStack.Peek().gameObject.SetActive(true);
    }

    public T Getprefab<T>() where T : Menu
    {
        //Main
        if (typeof(T) == typeof(MainMenu))
            return MainMenuprefab as T;

        else if (typeof(T) == typeof(LoadMenu))
            return LoadMenuprefab as T;

        else if (typeof(T) == typeof(NewGameMenu))
            return NewGameMenuprefab as T;

        //Game
        else if (typeof(T) == typeof(PlayerMenu))
            return PlayerMenuprefab as T;

        else if (typeof(T) == typeof(GearInvenMenu))
            return GearInvenMenuprefab as T;

        else if (typeof(T) == typeof(MailListMenu))
            return MailListMenuprefab as T;

        else if (typeof(T) == typeof(MailMenu))
            return MailMenuprefab as T;

        else if (typeof(T) == typeof(SystemMenu))
            return SystemMenuprefab as T;

        //타입이 prefab에 없는거면 Excpetion 반환
        throw new MissingReferenceException();
    }
}
