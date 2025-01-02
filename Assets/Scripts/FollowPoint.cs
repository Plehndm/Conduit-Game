using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    public Transform point;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = point.position;
        transform.rotation = point.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform .position = point.position;
    }
}
