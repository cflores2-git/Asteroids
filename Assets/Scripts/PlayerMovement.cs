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
    public GameManager gameManager;
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
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = halfHeight * camera.aspect;
        Vector3 center = camera.transform.position;
        Vector3 position = transform.position;

        if (position.x>center.x+halfWidth)
        {
            position.x = center.x - halfWidth;
        }
        else if (position.x<center.x-halfWidth)
        {
            position.x = center.x + halfWidth;
        }
        if (position.y>center.y+halfHeight)
        {
            position.y = center.y - halfHeight;
        }
        else if (position.y<center.y-halfHeight)
        {
            position.y = center.y + halfHeight;
        }
        transform.position = position;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(value.isPressed){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        bullet.GetComponent<BulletBehavior>().gameManager = gameManager;
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