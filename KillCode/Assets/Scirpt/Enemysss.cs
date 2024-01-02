using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemysss : ScriptableObject
{
    public enum EnemyType {Range, Melee}

    public EnemyType enemytype;
    public float Damage;
    public float Speed;
    public int vaule;
    public GameObject prefabs;
}
