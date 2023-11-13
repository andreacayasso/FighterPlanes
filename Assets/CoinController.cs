using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float lifetime = 120f;
    public int scoreValue = 1;

    void Start()
    {

   	 	float randomX = Random.Range(-5f, 5f); // Adjust the range based on your screen size
    	float randomY = Random.Range(-3f, 3f);


		transform.position = new Vector2(randomX, randomY);


   	     // Destroy the coin after a couple of minutes
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player picked up the coin
        if (other.CompareTag("Player"))
        {
            // Update the score and destroy the coin
            GameManager.instance.EarnScore(1);
            Destroy(gameObject);
        }
    }

}
