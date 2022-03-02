using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;

public class GameBehaviour : MonoBehaviour, IManager
{
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    public PlayerBehavior playerBehavoir;
    public float defaultSpeedModifier = 1f;
    public float SpeedBoostModifier = 1.5f;
    private string SpeedBoostText = " ";
    public float defaultjumpModifier = 1f;
    public float JumpBoostModifier = 2f;
    private string JumpBoostText = " ";

    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);
            if (_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 10;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);

            if(_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that's got to hurt.";
            }
        }
    }

    private void Start()
    {
        playerBehavoir = GameObject.Find("Player").GetComponent<PlayerBehavior>();
        Initialize();
    }

    public void Initialize()
    {
        _state = "Manager initialized.";
        _state.FancyDebug();
        Debug.Log(_state);
    }

    public void SpeedBoost()
    {
        playerBehavoir.SpeedModifier = SpeedBoostModifier;
        SpeedBoostText = "Speed Boost Active";
    }

    public void JumpBoost()
    {
        playerBehavoir.JumpModifier = JumpBoostModifier;
        JumpBoostText = "Jump Boost Active";
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);
        GUI.Box(new Rect(20, 80, 150, 25), SpeedBoostText);
        GUI.Box(new Rect(20, 110, 150, 25), JumpBoostText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                Utilities.RestartLevel(0);
            }
        }
        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 -50, 200, 100), "You lose..."))
            {
                Utilities.RestartLevel();
            }
        }
    }
}
