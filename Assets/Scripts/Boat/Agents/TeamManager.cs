using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class ActiveAgents {
    public BoatAgents agentScript;
}

public class TeamManager : MonoBehaviour {

	public List<ActiveAgents> activeAgents = new List<ActiveAgents>();

    /// <summary>
    /// 
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
