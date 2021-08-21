using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterMover Mover;
    // Start is called before the first frame update
    void Start()
    {
        Mover = GetComponent<CharacterMover>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            dir.x = Input.GetAxisRaw("Horizontal");
        }
        if(Input.GetAxisRaw("Vertical") != 0)
        {
            dir.z = Input.GetAxisRaw("Vertical");
        }

        Mover.SetDirection(dir.normalized);
    }
}
