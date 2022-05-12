using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    //Public variables
    public float speed = 10;

    //Private variables
    private Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = new Vector2(-speed, 0);
    }
}
