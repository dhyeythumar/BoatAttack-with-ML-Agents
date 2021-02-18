using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoatAttack;

public class Checkpoint : MonoBehaviour
{
    private LayerMask BoatLayers;

    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        BoatLayers = LayerMask.GetMask("Boat");  // only Boat Layer should be added !!
    }

   	/// <summary>
    /// Add reward to boats if they collide with a Checkpoints. [trigger]
    /// </summary>
 	void OnTriggerEnter(Collider collidingObject)
    {
    	if((BoatLayers.value & (1 << collidingObject.gameObject.layer)) > 0) {

            // TODO :: use the better way to call scripts dynamically !
            try {
                collidingObject.gameObject.GetComponent<BoatAgent>().addCheckpointReward(this.gameObject.name);
            }
            catch {
                collidingObject.gameObject.GetComponent<BoatAgents>().addCheckpointReward(this.gameObject.name);
            }
    	}
    }
}
