using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    public GameObject leftBound;
    public GameObject rightBound;
    public GameObject upperBound;
    public GameObject lowerBound;
    public float spawnInterval = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 1f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAsteroid()
    {
        float left = leftBound.transform.position.x;
        float right = rightBound.transform.position.x;
        float top = upperBound.transform.position.y;
        float  bottom = lowerBound.transform.position.y;

        int edge = Random.Range(0,4);
        Vector2 spawnPosition;
        if (edge==0)
        {
            spawnPosition = new Vector2(left, Random.Range(bottom,top));
        }
        else if (edge==1)
        {
            spawnPosition = new Vector2(right, Random.Range(bottom,top));
        }
        else if (edge==2)
        {
            spawnPosition = new Vector2(Random.Range(left, right), top);
        }
        else
        {
            spawnPosition = new Vector2(Random.Range(left, right),bottom);
        }

        int choice = Random.Range(0, asteroidPrefabs.Length);
        GameObject asteroid = Instantiate(asteroidPrefabs[choice], spawnPosition, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));

        Vector2 towardMiddle = -spawnPosition.normalized;
        asteroid.GetComponent<AsteroidMovement>().direction = towardMiddle + Random.insideUnitCircle*0.5f;
    }
}
