using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PolytopeSolutions.Game {
    public class SwitchScene : MonoBehaviour {
		public void OnSceneSwitch(string _sceneName){
			SceneManager.LoadScene(_sceneName);
		}
	}
}