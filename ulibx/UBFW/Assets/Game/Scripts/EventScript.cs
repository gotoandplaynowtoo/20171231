using UnityEngine;
using System.Collections;

public class EventScript : MonoBehaviour {
	
	void Start () {
	
	}

	public void SampleBroadcast () {
		Messenger.Broadcast<string> (SampleConstants.ON_EVENT_1, "iyot kaau yeah.");
	}
}
