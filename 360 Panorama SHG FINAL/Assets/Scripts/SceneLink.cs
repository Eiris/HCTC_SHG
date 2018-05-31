using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLink : MonoBehaviour {

	public void ChangeToScene (string sceneToChangeTo) {
		print("CHANGING!");
		SceneManager.LoadScene (sceneToChangeTo);
	}

    public void doExitGame() {
        Application.Quit();
    }
}
