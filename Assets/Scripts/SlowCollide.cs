using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCollide : MonoBehaviour
{
    public GameVariables variablesScript;
    private void Start()
    {
        variablesScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameVariables>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            variablesScript.playerSpeed *= 0.5f;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            variablesScript.playerSpeed /= 0.5f;
        }
    }
}
