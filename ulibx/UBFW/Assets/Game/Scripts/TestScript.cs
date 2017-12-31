using UnityEngine;
using System.Collections;

using RandomVector.Navigation;

public class TestScript : MonoBehaviour {

	public TransitionSequence seq;
	 
	void Start () {
	}

	/**
	 * Navigation Showcase
	 * Scene: {string} the target scene to navigate onto.
	 * Transition: {TransitionSequence} pass the trasition object containing the scene target and the transition sequence.
	 * Build () - gets you a reference of the navigation object.
	 * Play () - automatically plays the transition and navigates to the target scene after the transition.
	 */
	public void ShowcaseTransition () {
		UNavigation navigation = new NavigationBuilder ()
			.SetScene (seq.TargetScene) //target scene name
			.SetTransition (seq) //The transition game object with the script TransitionSequence Attached.
			.Play(); //or .Build();
		
	}

}
