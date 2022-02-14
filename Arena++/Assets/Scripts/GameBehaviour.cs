using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showWinScreen = false;

    public PlayerBehavior playerBehavoir;
    public float defaultSpeedModifier = 1f;
    public float speedBoostModifier = 1.5f;
    private string speedBoostText = " ";
    public float defaultjumpModifier = 1f;
    public float jumpBoostModifier = 2f;
    private string jumpBoostText = " ";

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
        }
    }

    private void Start()
    {
        playerBehavoir = GameObject.Find("Player").GetComponent<PlayerBehavior>();
    }

    public void speedBoost()
    {
        playerBehavoir.speedModifier = speedBoostModifier;
        speedBoostText = "Speed Boost Active";
    }

    public void jumpBoost()
    {
        playerBehavoir.jumpModifier = jumpBoostModifier;
        jumpBoostText = "Jump Boost Active";
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);
        GUI.Box(new Rect(20, 80, 150, 25), speedBoostText);
        GUI.Box(new Rect(20, 110, 150, 25), jumpBoostText);
        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
    }
}
