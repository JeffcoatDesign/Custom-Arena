using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItemBehavior : MonoBehaviour
{
    public GameBehaviour gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);

            Debug.Log("Speed Boost Collected");

            gameManager.speedBoost();
            gameManager.Items += 1;
        }
    }
}
