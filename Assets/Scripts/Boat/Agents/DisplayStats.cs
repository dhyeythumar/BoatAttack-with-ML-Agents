using Unity.MLAgents;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public BoatAgent _boatAgent;

	private string m_episodeCount;
	private string m_totalStepCount;
    private string test;

    GUIStyle guiStyle = new GUIStyle();
    GUIStyle bgStyle = new GUIStyle();
    void OnGUI()
    {
        guiStyle.fontSize = 20;
        guiStyle.normal.textColor = Color.white;
        bgStyle.normal.background = getTexture(new Color(0.0f, 0.0f, 0.0f, 0.5f));
        GUI.BeginGroup(new Rect(x:0, y:0, width:300, height:250), bgStyle);
            GUI.BeginGroup(new Rect(20, 20, 300, 120), "Academy Stats", guiStyle);
                GUI.Label(new Rect(0, 25, 250, 25), "| Episode Count: " + m_episodeCount, guiStyle);
                GUI.Label(new Rect(0, 50, 250, 25), "| Step Count: " + test, guiStyle);
                GUI.Label(new Rect(0, 75, 250, 25), "| Total Steps: " + m_totalStepCount, guiStyle);
                GUI.Label(new Rect(0, 100, 250, 25), "-------------------------------------", guiStyle);
            GUI.EndGroup();
            GUI.BeginGroup(new Rect(x:20, y:150, width:300, height:75), "Boat Stats", guiStyle);
                GUI.Label(new Rect(0, 25, 250, 25), "| Speed: " + _boatAgent.speed, guiStyle);
                GUI.Label(new Rect(0, 50, 250, 25), "| Reward: " + _boatAgent.GetCumulativeReward().ToString("0.##"), guiStyle);
            GUI.EndGroup();
        GUI.EndGroup();
    }

    private Texture2D getTexture(Color col)
    {
        Texture2D result = new Texture2D(1, 1);
        result.SetPixel(0, 0, col);
        result.Apply();
        return result;
    }

    static string minifyInt(int num)
    {
        if (num >= 1000000000)
            return (num / 1000000000D).ToString("0.###") + " B";
        if (num >= 100000000)
            return (num / 1000000).ToString("#,0") + " M";
        if (num >= 1000000)
            return (num / 1000000D).ToString("0.###") + " M";
        if (num >= 100000)
            return (num / 1000).ToString("#,0") + " K";
        if (num >= 1000)
            return (num / 1000D).ToString("0.###") + " K";
        return num.ToString("#,0");
    }

    private void Update()
    {
        m_episodeCount = minifyInt(Academy.Instance.EpisodeCount);
        // TODO: For now this doesn't matches with the cmd's Step count.
        m_totalStepCount = minifyInt(Academy.Instance.TotalStepCount);

        // The current step count (within the current episode).
        // Debug.Log(Academy.Instance.StepCount);
        test = minifyInt(Academy.Instance.StepCount);
    }
}
