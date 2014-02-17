using UnityEngine;
using System.Collections;

public class WaveCount : MonoBehaviour {

    public UILabel WaveCountLabel;
    public UILabel EnemyCountLabel;
    Spawner spawner;

	// Use this for initialization
	void Start () {
        spawner = GetComponent<Spawner>();

        if (spawner == null)
            throw new MissingComponentException("Requires Spawner Component. Not found");

        spawner.WaveSpawned += WaveSpawned;
        spawner.EnemyCountDecreased += EnemyCountDecreased;
        
        // EnemyCountLabel.text = spawner.enemyCountIncrement.ToString();
	}

    void WaveSpawned(int waveCount, int enemyCount)
    {
        WaveCountLabel.text = waveCount.ToString();
        EnemyCountLabel.text = enemyCount.ToString();
    }

    private void EnemyCountDecreased(int enemyCount)
    {
        EnemyCountLabel.text = enemyCount.ToString();
    }
}
