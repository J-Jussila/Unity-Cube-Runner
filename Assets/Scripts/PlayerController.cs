using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float jumpForce;
    bool canJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            //jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
     }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump= false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If colliding with Obstacle reload scene
        if(other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
