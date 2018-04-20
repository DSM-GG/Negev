using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager Instance { get; private set; }

    public enum MenuMode { Main = 0, Player }
    public MenuMode mode;

    //Main
    public MainMenu MainMenuPrefeb;
    public LoadMenu LoadMenuPrefeb;
    public NewGameMenu NewGameMenuPrefeb;

    //Game
    public PlayerMenu PlayerMenuPrefeb;
    public SystemMenu SystemMenuPrefeb;

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
        var prefeb = GetPreFeb<T>();
        var instance = Instantiate<Menu>(prefeb,transform);

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

    public T GetPreFeb<T>() where T : Menu
    {
        //Main
        if (typeof(T) == typeof(MainMenu))
            return MainMenuPrefeb as T;

        if (typeof(T) == typeof(LoadMenu))
            return LoadMenuPrefeb as T;

        if(typeof(T) == typeof(NewGameMenu))
            return NewGameMenuPrefeb as T;

        //Game
        if (typeof(T) == typeof(PlayerMenu))
            return PlayerMenuPrefeb as T;

        if (typeof(T) == typeof(SystemMenu))
            return SystemMenuPrefeb as T;

        //타입이 prefeb에 없는거면 Excpetion 반환
        throw new MissingReferenceException();
    }
}
