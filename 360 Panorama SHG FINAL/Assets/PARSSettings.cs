using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PARSSettings : ScriptableObject {

	public string fireBaseURL;

	public int dangerZoneTime;

	public bool T_forcedTimeNavigationEnabled;
	public bool T_selfNavigationEnabled;
	public int T_roundForcedTimeLimit;
	public int T_roundsTotalCount;
	public bool T_expandingSummaryTextBoxEnabled;

	public bool A_forcedTimeNavigationEnabled;
	public bool A_selfNavigationEnabled;
	public int A_roundForcedTimeLimit;
	public int A_roundsTotalCount;
}