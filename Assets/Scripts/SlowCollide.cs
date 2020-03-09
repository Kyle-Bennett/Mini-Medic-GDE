using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCollide : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerMovement>().speed = 1;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<PlayerMovement>().speed = 4;
    }
}
