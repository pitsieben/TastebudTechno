using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PolytopeSolutions.Game {
	public class Exit : MonoBehaviour {
		public InputActionReference exitAction;

        private void Start() {
			if (this.exitAction != null) { 
				this.exitAction.action.Enable();
				this.exitAction.action.canceled += (context) => OnExit();
			}
		}

        public void OnExit(){
			#if !UNITY_EDITOR
			Application.Quit();
			#else
			UnityEditor.EditorApplication.isPlaying = false;
			#endif
		}
	}
}