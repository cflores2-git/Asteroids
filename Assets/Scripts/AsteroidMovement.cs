using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Vector2 direction = new Vector2(1f,1f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  (Vector3)direction.normalized * moveSpeed * Time.deltaTime;
    }
}
