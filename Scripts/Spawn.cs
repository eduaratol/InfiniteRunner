using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
	public Transform[] spawnPositions;
    public GameObject[] spawnObjects;

    private void Start () 
	{
		StartCoroutine ("SpawnCount");
	}

    private void Update () 
	{
		transform.Translate (0, 0, Controller.velocity * Time.deltaTime);
		
		if (Controller.life == 0)
		{
			StopCoroutine("SpawnCount");
		}
	}

	private void SpawnObject()
	{
        int randomObject = Random.Range(0, spawnObjects.Length);
        int randomPosition = Random.Range (0, spawnPositions.Length);
        Instantiate(spawnObjects[randomObject], spawnPositions[randomPosition].position, Quaternion.identity);
	}

    private IEnumerator SpawnCount()
	{
        SpawnObject();
        Controller.velocity += 0.01f;
		if (Controller.score > 20 && Controller.score <= 40)
        {
			yield return new WaitForSeconds (0.8f);
		}
        else if (Controller.score > 40 && Controller.score <= 60)
        {
			yield return new WaitForSeconds (0.6f);
		}
        else if (Controller.score > 60 && Controller.score <= 100)
        {
			yield return new WaitForSeconds (0.2f);
		}
        else if (Controller.score > 100 && Controller.score <= 200)
        {
			yield return new WaitForSeconds (0.2f);
		}
        else if (Controller.score > 200)
        {
			yield return new WaitForSeconds (0.2f);
		}
        else
        {
			yield return new WaitForSeconds (1);
		}
        StartCoroutine("SpawnCount");
    }
}