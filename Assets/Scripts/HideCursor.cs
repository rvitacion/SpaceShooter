using UnityEngine;

public class HideCursor : MonoBehaviour {

	void Start () {
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Confined;
	}

  void Update() {
    if(Input.GetKey(KeyCode.Escape)) Application.Quit();
  }
}
