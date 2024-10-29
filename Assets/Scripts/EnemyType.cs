using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Type", menuName = "Enemy/EnemyType")]
public class EnemyType : ScriptableObject
{
    public string enemyName;
    public float health;
    public float speed;
    public float loss;
    
}
