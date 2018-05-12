using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

  void Start() {
    Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = true;
  }

  public void Play() {
    SceneManager.LoadScene(1);
  }

  public void Quit() {
    Debug.Log("Game closed.");
    Application.Quit();
  }

}
