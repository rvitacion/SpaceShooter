using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

  public Transform left;
  public Transform right;
  public Camera cockpitCam;
  private WaitForSeconds shotDuration = new WaitForSeconds(.01f);
  private LineRenderer leftLine;
  private LineRenderer rightLine;
  private AudioSource laserSound;
  public float fireRate;
  private float laserCooldown;
  public GameObject impact;

	void Start() {
    leftLine = left.GetComponent<LineRenderer>();
    rightLine = right.GetComponent<LineRenderer>();
    laserSound = GetComponent<AudioSource>();
  }

	void Update() {
		
    if (Input.GetMouseButton(0) && Time.time > laserCooldown) {
      StartCoroutine(LaserEffect());
      Shoot();
      laserCooldown = Time.time + fireRate;
    }

	}

  void Shoot() {
    leftLine.SetPosition(0, left.position);
    rightLine.SetPosition(0, right.position);
    RaycastHit hit;
    if (Physics.Raycast(cockpitCam.transform.position, cockpitCam.transform.forward, out hit)) {
      leftLine.SetPosition(1, hit.point);
      rightLine.SetPosition(1, hit.point);
      GameObject effect = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
      Destroy(effect, 4f);
      Debug.Log(hit.transform.name);
    }
    else {
      leftLine.SetPosition(1, cockpitCam.transform.position + (cockpitCam.transform.forward * 1000));
      rightLine.SetPosition(1, cockpitCam.transform.position + (cockpitCam.transform.forward * 1000));
    }

  }

  private IEnumerator LaserEffect() {
    laserSound.Play();
    leftLine.enabled = true;
    rightLine.enabled = true;
    yield return shotDuration;
    leftLine.enabled = false;
    rightLine.enabled = false;
  }

}
