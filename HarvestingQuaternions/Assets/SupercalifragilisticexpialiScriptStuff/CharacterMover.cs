using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float MaxSpeed = 2.0f;
    private Vector3? Destination = null;
    private Vector3? Direction = null;

    private Rigidbody Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Destination != null)
        {

        }
        else if (Direction != null)
        {
            Vector3 vel = Rigidbody.velocity;
            vel.x = 0;
            vel.z = 0;
            Rigidbody.velocity = vel + Direction.Value * MaxSpeed;
        }
        else
        {
            Vector3 vel = Rigidbody.velocity;
            vel.x = 0;
            vel.z = 0;
            Rigidbody.velocity = vel;
        }
    }

    public void SetDestination(Vector3 pos)
    {
        Destination = pos;
        Direction = null;
        RotateToPos(Destination.Value);
    }

    public void SetDirection(Vector3 dir)
    {
        if(Direction != null && Direction.Value == dir)
        {
            return;
        }
        if(dir == Vector3.zero)
        {
            Direction = null;
            return;
        }
        Direction = dir;
        Destination = null;
        Debug.Log(Direction.Value);
        RotateToPos(Direction.Value);
    }

    private void RotateToPos(Vector3 pos)
    {
        float angle = Vector3.SignedAngle(Vector3.forward, pos, Vector3.up);
        transform.rotation = Quaternion.Euler(Vector3.up * angle);
    }

    private Vector2 Vec3AsVec2(Vector3 v3)
    {
        return new Vector2(v3.x, v3.z);
    }
}
