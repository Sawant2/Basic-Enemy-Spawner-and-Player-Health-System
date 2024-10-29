using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    public EnemyType enemyType;
    [SerializeField]private int destroyScore = 10;
    public event Action OnEnemyDestroyed;
    
    private float speed;
    private float health;
    private float loss;

    private void Start()
    {
        if (enemyType != null)
        {
            speed = enemyType.speed;
            health = enemyType.health;
            loss = enemyType.loss;
        }
    }
    
    // public void SetSpeed(float newSpeed)
    // {
    //     speed = newSpeed;
    // }

    private void Update()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            OnEnemyDestroyed?.Invoke();
            if (player != null)
            {
                player.UpdateHealth(-loss);
            }
            UpdateScore.Instance.AddScore(destroyScore);
            Destroy(gameObject);
            Debug.Log("Player destroyed");
        }
    }
}