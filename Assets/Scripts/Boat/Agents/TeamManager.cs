using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.Serialization;
using Cinemachine;

[System.Serializable]
public class ActiveAgents {
    public BoatAgents agentScript;
    public CinemachineVirtualCamera agentCam;
    public int checkpoint;
}

public class TeamManager : MonoBehaviour {

	public List<ActiveAgents> activeAgents = new List<ActiveAgents>();

	void Start () {
		activeAgents[0].agentCam.enabled = true; // enabling first cam only
	}

	/// <summary>
    /// Boat Agent Camera Manager (Activate the cam only for boat at 1st position)
    /// </summary>
	private void FixedUpdate() {

		int maxCheckpoint = -1, index = 0;
		for (int i = 0; i < activeAgents.Count; i++) {

			activeAgents[i].agentCam.enabled = false;

			if(maxCheckpoint < activeAgents[i].checkpoint) {
				index = i;
				maxCheckpoint = activeAgents[i].checkpoint;
			}
		}
		activeAgents[index].agentCam.enabled = true;
	}

    /// <summary>
    /// Add reward to the winning (one which touches the end checkpoint first) boat team.
    /// </summary>
	public void startNewEpisode(BoatAgents.Team winningTeam) {
		
		foreach (var agent in activeAgents) {
            if (agent.agentScript.team == winningTeam)
                agent.agentScript.AddReward(1.0f);
            else
                agent.agentScript.AddReward(-1.0f);

            agent.agentScript.EndEpisode();  // all agents need to be reset
        }
	}
}
