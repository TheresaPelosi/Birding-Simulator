using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class DroidFactory : Singleton<DroidFactory> {

	[SerializeField] private Droid[] availableDroids;
	[SerializeField] private float waitTime = 180.0f;
	[SerializeField] private int startingDroids = 5;
	[SerializeField] private float minRange = 5.0f;
	[SerializeField] private float maxRange = 50.0f;

	private List<Droid> liveDroids = new List<Droid>();
	private Droid selectedDroid;
	private Player player;

	public List<Droid> LiveDroids {
		get { return liveDroids; }
	}

	public Droid SelectedDroid {
		get { return selectedDroid; }
	}

	private void Awake() {
		Assert.IsNotNull(availableDroids);
	}

	void Start () {
		player = GameManager.Instance.CurrentPlayer;
		Assert.IsNotNull(player);
		for (int i = 0; i < startingDroids; i++) {
			InstantiateDroid();
		}

		StartCoroutine(GenerateDroids());
	}

	public void DroidWasSelected(Droid droid) {
		selectedDroid = droid;
	}

	private IEnumerator GenerateDroids() {
		while (true) {
			InstantiateDroid();
			yield return new WaitForSeconds(waitTime);
		}
	}

	private void InstantiateDroid() {
		int index = Random.Range(0, availableDroids.Length);
		float x = player.transform.position.x + GenerateRange();
		float z = player.transform.position.z + GenerateRange();
		float y = player.transform.position.y;
        Droid newBird = Instantiate(availableDroids[index], new Vector3(x, y, z), Quaternion.identity);
        newBird.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
        liveDroids.Add(newBird);
	}

	private float GenerateRange() {
		float randomNum = Random.Range(minRange, maxRange);
		bool isPositive = Random.Range(0, 10) < 5;
		return randomNum * (isPositive ? 1 : -1);
	}
}
