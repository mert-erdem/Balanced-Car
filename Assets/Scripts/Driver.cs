using System;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public static Action actionGameOver;

    //game over
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
            actionGameOver?.Invoke();
    }
}
