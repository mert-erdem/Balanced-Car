using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{
    Rigidbody2D physics;

    [SerializeField] private WheelJoint2D _wheelBack, _wheelFront;
    [Range(0, 5000)] public int speed;

    private float _horizontalMovement;
    public static float fuel=100; 
    private bool gameOver=false;

    private void Awake() => Driver.actionGameOver += GameOver;

    void Start()
    {        
        physics = transform.GetComponent<Rigidbody2D>();

        _wheelFront.useMotor = false;
    }

    void Update()
    {
        if(!gameOver)
        {
            _horizontalMovement = -Input.GetAxisRaw("Horizontal") * speed;

            if (Input.GetKey(KeyCode.Space))
                HandBreak();
        }       
    }

    private void FixedUpdate() => Movement();

    private void Movement()
    {
        if (_horizontalMovement == 0 || fuel<=0 || gameOver)
            _wheelBack.useMotor = false;       
        else
        {
            _wheelBack.useMotor = true;

            var motor = new JointMotor2D { motorSpeed = _horizontalMovement, maxMotorTorque = _wheelBack.motor.maxMotorTorque };
            _wheelBack.motor = motor;

            fuel -= 0.1f;
        }
    }

    private void HandBreak() => physics.velocity = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gascan")
        {
            fuel = 100;
            Destroy(collision.gameObject);
        }                  
    }

    private void GameOver() => gameOver = true;
}
