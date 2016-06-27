using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _Spawner : MonoBehaviour {

	public Wave[] waves;
	public EnemyAI enemy;
	private GameObject[] gos;
	public static int WaveNumber = 1;
	public static bool NextWaveBool;


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
			//spawnedEnemy.OnDeath += OnEnemyDeath;
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
			UIController.NextWaveBool = true;
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
		WaveNumber = currentWaveNumber;
		UIController.NextWaveBool = false;

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
