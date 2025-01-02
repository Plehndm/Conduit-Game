using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBehavior : MonoBehaviour
{
    [SerializeField] private float DespawnDelay = 5f;

    void Awake()
    {
        Object.Destroy(this.gameObject, DespawnDelay);
    }
}
