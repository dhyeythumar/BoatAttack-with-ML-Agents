using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// This is an overall controller for a boat
    /// </summary>
    public class Boat : MonoBehaviour
    {
        public Engine engine;
        // public Transform initialPos;

        void Start()
        {
            TryGetComponent(out engine.RB);
            resetPosition();
        }

        // private void Update() {}
        // private void FixedUpdate() {}
        // private void LateUpdate() {}

        public void resetPosition()
        {
            // this.transform.forward = initialPos.forward;
            // this.transform.right = initialPos.right;
            // this.transform.rotation = initialPos.rotation;
            // engine.RB.position = initialPos.position;
            // engine.RB.rotation = initialPos.rotation;
            engine.RB.velocity = Vector3.zero;
            engine.RB.angularVelocity = Vector3.zero;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Boundary"))
            	Debug.Log("Boundary reached !!");
        }

        public void displayCheckpointName(string checkpointName) {
        	Debug.Log("Reached { " + checkpointName + " } !!");
        }
    }
}
