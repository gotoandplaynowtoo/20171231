using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

namespace RandomVector.Navigation {
	public class NavigationBuilder : INavigationBuilder {

		UNavigation navigation = new UNavigation();

		public INavigationBuilder SetScene (string name) {
			navigation.Scene = name;
			return this;
		}

		public INavigationBuilder SetTransition (TransitionSequence transitionSequence) {
			navigation.Transition = transitionSequence;
			return this;
		}

		public UNavigation Build () {
			return navigation;
		}

		public UNavigation Play () {
			//Play Animation Here
			//Return the instance as well

			Sequence sequence = DOTween.Sequence ();

			if (!navigation.Transition.gameObject.activeSelf)
				navigation.Transition.gameObject.SetActive (true);

			Image imageFade;
			float duration;

			for (int i = 0; i < navigation.Transition.transitionSequence.Count; i++) {
				imageFade = navigation.Transition.transitionSequence [i].fadeObject;
				duration = navigation.Transition.transitionSequence [i].Duration;

				Debug.Log ("Adding: " + imageFade.name + " with duration: " + duration + " to sequence.");

				sequence.Append (navigation.Transition.transitionSequence [i].fadeObject.DOFade (1f, duration));
			}

			sequence.OnComplete (() => {
				Application.LoadLevel(navigation.Scene);
			});

			Debug.Log ("Playing Transition.");

			return navigation;
		}

	}
}
