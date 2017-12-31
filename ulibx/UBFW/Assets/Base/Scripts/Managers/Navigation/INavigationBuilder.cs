using UnityEngine;

namespace RandomVector.Navigation {
	public interface INavigationBuilder {
		INavigationBuilder SetScene(string name);
		INavigationBuilder SetTransition(TransitionSequence transitionSequence);

		UNavigation Build ();		//just build the instance
		UNavigation Play ();		//play the transition and return the instance
	}
}
