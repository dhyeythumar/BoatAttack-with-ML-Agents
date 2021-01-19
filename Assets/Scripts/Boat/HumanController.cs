using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// This sends input controls to the boat engine if 'Human'
    /// </summary>
    public class HumanController : MonoBehaviour
    {
        private Boat BoatController; // the boat controller

        private float _throttle;
        private float _steering;
        
        void Start() {
        	BoatController = this.GetComponent<Boat>();
        }

        void GetKeyboardInputs()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) {
                _throttle = 1f;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                _throttle = -1f;
            }
            else {
                _throttle = 0f;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                _steering = 1f;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                _steering = -1f;
            }
            else {
                _steering = 0f;
            }

            if (Input.GetKeyDown("r")) {
                ResetBoat();
            }
        }

        private void ResetBoat()
        {
            BoatController.resetPosition();
        }

        void FixedUpdate()
        {
            GetKeyboardInputs();
            BoatController.engine.Accelerate(_throttle);
            BoatController.engine.Turn(_steering);
        }
    }
}
