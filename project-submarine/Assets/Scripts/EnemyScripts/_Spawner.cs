using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _Spawner : MonoBehaviour {

	[SerializeField]
	private Wave[] waves;
	[SerializeField]
	private EnemyAI enemy;

	private GameObject[] gos;

	public static int _waveNumber = 1;
	public static bool _nextWaveBool;


	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingToSpawn;
	int enemiesRemainingAlive;
	float nextSpawnTime;


	void Start() {
		NextWave ();
	

	}

	void Update() {
		

		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
		{
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

			EnemyAI spawnedEnemy = Instantiate(enemy, transform.position, Quaternion.identity) as EnemyAI;
			gos = GameObject.FindGameObjectsWithTag("Enemy");
		}
	}

	public void OnEnemyDeath() {
		enemiesRemainingAlive--;
		Debug.Log ("Nextwave3");


		gos = GameObject.FindGameObjectsWithTag("Enemy");
		Debug.Log ("Enemies" +gos.Length);
		if (gos.Length == 1)
		{
			UIController._nextWaveBool = true;
			Invoke ("TimeDelay", 5f);
		}

	}
	void TimeDelay()
	{
		//NextWaveBool = true;
		NextWave ();
	}

	public void NextWave()
	{
		Debug.Log ("Nextwave");
		currentWaveNumber++;
		_waveNumber = currentWaveNumber;
		UIController._nextWaveBool = false;

		if (currentWaveNumber - 1 < waves.Length)
		{
			Debug.Log ("Nextwave2");
			currentWave = waves [currentWaveNumber - 1];
			enemiesRemainingToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemainingToSpawn;

		}
	}

	[System.Serializable]
	public class Wave {
		public int enemyCount ;
		public float timeBetweenSpawns;
	}

}
