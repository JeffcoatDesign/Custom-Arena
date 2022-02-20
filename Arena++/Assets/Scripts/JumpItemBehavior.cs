using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpItemBehavior : MonoBehaviour
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

            Debug.Log("Jump Boost Collected");
            gameManager.JumpBoost();
            gameManager.Items += 1;
        }
    }
}
