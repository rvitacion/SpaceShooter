using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 7;
    private Rigidbody rb;

    #region MonoBehaviour API

    private void start()
    {
        rb = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 300.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb.AddForce(movement * speed);
    }

    #endregion
}