using UnityEngine;

public class Destroyable : MonoBehaviour {

  public float health = 80.0f;

  public void TakeDamage(float amount) {
    health -= amount;
  }
	
	public void Kill () {
		Destroy(gameObject);
	}
}
