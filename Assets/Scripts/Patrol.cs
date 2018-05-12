    using UnityEngine;
    using UnityEngine.AI;

    public class Patrol : MonoBehaviour {

        public Transform[] points;
        private int destPoint;
        private NavMeshAgent agent;
        private Vector3 destination;
        public float speed;


        void Start () {
            destPoint = 0;
        }

        void Update () {
          destination = points[destPoint].position;
          Vector3 targetDir = destination - transform.position;
          transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetDir, 6.5f * Time.deltaTime, 0.0f));
          transform.position = Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
          if(Vector3.Distance(transform.position, destination) == 0) destPoint = (destPoint + 1) % points.Length;
        }
    }