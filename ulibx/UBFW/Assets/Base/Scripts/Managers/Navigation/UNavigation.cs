using UnityEngine;

namespace RandomVector.Navigation {
	public class UNavigation {

		public string Scene { get; set; }
		public TransitionSequence Transition { get; set; }

		public UNavigation () {
			//Default Constructor
		}

		public void ShowInfo () {
			Debug.Log (Scene + " : " + Transition.ToString ());
		}
	}
}
