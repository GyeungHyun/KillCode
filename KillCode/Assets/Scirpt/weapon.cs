using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class weapon : ScriptableObject
{
    public int id;
    public int prefabId;
    public int Level;
    public float damage;
    public int count;
    public float speed;
    public GameObject Prefab;
}

