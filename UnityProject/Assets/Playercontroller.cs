using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [Header("速度")]
    [Range(8, 100)]
    public float speed = 8;
    [Header("跳躍")]
    [Range(8, 100)]
    public int jump = 8;
    Rigidbody r3d;
    [Header("接觸")]
    public bool isGround;

    // Use this for initialization
    void Start()
    {
        r3d = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGround = true;
        Debug.Log("touch" + collision.gameObject);
    }

    private void Walk()
    {
        r3d.AddForce(new Vector3(speed * Input.GetAxis("Horizontal"), 0,0));
        r3d.AddForce(new Vector3( 0, 0, speed * Input.GetAxis("Vertical")));

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r3d.AddForce(new Vector3(0, jump,0));
        }

    }
}
