using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour {
	private GameObject Player;

	public GameObject LoadingPanel;
	public Slider LoadingBar;
	public Text LoadingText;

	public AudioSource Ambient;

	static public string selectedScene;

	void Start()
    {
		Player = GameObject.FindGameObjectWithTag("Player");
	}

	public void LoadScene (int level) 
	{
		StartCoroutine (LoadSceneAsync (level));

		Debug.Log(SceneManager.GetSceneByBuildIndex(level).name + "SceneLoaded");
		PlayerPrefs.SetInt(SceneManager.GetSceneByBuildIndex(level).name + "SceneLoaded", 1);
	}

	public void LoadScene (string level) 
	{
		StartCoroutine(LoadSceneAsync (level));

		PlayerPrefs.SetInt(level + "SceneLoaded", 1);
	}

	public void LoadSceneNoLoadingbar(int level)
	{
		SceneManager.LoadScene (level);
	}

	public void LoadScelectedScene ()
	{
		StartCoroutine(LoadSceneAsync (selectedScene));
	}

	public void ReloadScene() 
	{
		int scene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (scene);
	}

	public IEnumerator LoadSceneAsync (int SceneID)
	{
		LoadingPanel.SetActive (true);

		AsyncOperation op = SceneManager.LoadSceneAsync (SceneID);

		while (!op.isDone) 
		{
			float Progress = Mathf.Clamp01 (op.progress / 1.0f);
			LoadingBar.value = Progress;
			//LoadingText.text = Progress * 100f + "%";

			// Artificial break for a while
			if(op.progress == 0.9f)
				System.Threading.Thread.Sleep (1000);
			
			yield return null;
		}
	}

	public IEnumerator LoadSceneAsync (string sceneName)
	{
		LoadingPanel.SetActive (true);

		AsyncOperation op = SceneManager.LoadSceneAsync (sceneName);

		while (!op.isDone) 
		{
			float Progress = Mathf.Clamp01 (op.progress / 1.0f);
			LoadingBar.value = Progress;
			//LoadingText.text = Progress * 100f + "%";

			if(op.progress == 0.9f)
				System.Threading.Thread.Sleep (1000);

			yield return null;
		}
	}

	private void OnTriggerEnter2D (Collider2D collider) 
	{
		if (collider.gameObject == Player)
		{
			PlayerPrefs.SetInt ("Money", Player.GetComponent<PlayerStatsBehaviour> ().Money);
			Ambient.Stop ();

			LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void Exit()
	{
		float lastTimeSaved = PlayerPrefs.GetFloat("TimeInGame", 0.0f);
		lastTimeSaved += Time.realtimeSinceStartup;

		PlayerPrefs.SetFloat("TimeInGame", lastTimeSaved);

		PlayerPrefs.Save();

#if UNITY_EDITOR
		Debug.Break();
#else
		Application.Quit();
#endif
	}
}
