using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Update is called once per frame
    void Update () {

        //translation
        float x = Input.GetAxis("Lateral") * Time.deltaTime * 100.0f;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * 100.0f;
        float z = Input.GetAxis("Thrust") * Time.deltaTime * 120.0f;
        transform.Translate(x, y, z);

        //rotation
        if(!Input.GetMouseButton(1)) {
          float pitch = Input.GetAxis("Pitch") * Time.deltaTime * 15.0f;
          float yaw = Input.GetAxis("Yaw") * Time.deltaTime * 60.0f;
          float roll = Input.GetAxis("Roll") * Time.deltaTime * 15.0f;
          transform.Rotate(pitch, yaw, -roll);
        }

    }

}