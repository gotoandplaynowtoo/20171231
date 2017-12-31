using UnityEngine;
using System.Collections;

public class EventListenee : MonoBehaviour {

	void OnEnable () {
		Messenger.AddListener<string> (SampleConstants.ON_EVENT_1, onEventTrigger);
	}

	void onEventTrigger (string str) {
		Debug.Log ("I got something! => " + str);
	}

}
