using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;
    private Vector2 moveInput;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject leftBound;
    public GameObject rightBound;
    public GameObject upperBound;
    public GameObject lowerBound;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f, -moveInput.x*rotateSpeed*Time.deltaTime);
        if (moveInput.y>0f){
            transform.position += transform.up * moveSpeed * moveInput.y * Time.deltaTime; 
        }
        Vector3 position = transform.position;
        if (transform.position.x > rightBound.transform.position.x)
        {
            position.x = leftBound.transform.position.x;
        }
        else if  (transform.position.x < leftBound.transform.position.x)
        {
            position.x = rightBound.transform.position.x;
        }
        if (transform.position.y > upperBound.transform.position.y)
        {
            position.y = lowerBound.transform.position.y;
        }
        else if  (transform.position.y < lowerBound.transform.position.y)
        {
            position.y = upperBound.transform.position.y;
        }
        transform.position = position;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (value.isPressed){
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Asteroid"))
        {
            transform.position = startPosition;
            transform.rotation = Quaternion.identity;
        }
    }
}