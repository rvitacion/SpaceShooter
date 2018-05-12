using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Update is called once per frame
    void Update () {

        //translation
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 800.0f;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * 800.0f;
        float z = Input.GetAxis("Thrust") * Time.deltaTime * 1000.0f;
        transform.Translate(x, y, z);

        //rotation
        if(!Input.GetMouseButton(1)) {
          float pitch = Input.GetAxis("Pitch") * Time.deltaTime * 10.0f;
          float yaw = Input.GetAxis("Yaw") * Time.deltaTime * 10.0f;
          float roll = Input.GetAxis("Roll") * Time.deltaTime * 160.0f;
          transform.Rotate(pitch, yaw, -roll);
        }

    }

}