using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 Offset;
    [SerializeField]
    Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Offset = Player.position - transform.position;
        Offset.x = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position - Offset;
    }
}
