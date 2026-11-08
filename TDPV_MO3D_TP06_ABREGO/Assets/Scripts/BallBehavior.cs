using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool isCharging = false;
    private float barSpeed = 2f;
    private float pushForce = 0.1f;
    private bool chargingUp = true;
    private bool shooted = false;
    private Vector3 initialPosition;

    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private StrengthBarBehavior forceBarBehavior;

    private InputAction moveAction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;

        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void OnEnable()
    {
        GameEvents.OnRestart += Restart;
        GameEvents.OnStartCharging += StartCharging;
        GameEvents.OnShoot += Shoot;
    }

    private void OnDisable()
    {
        GameEvents.OnRestart -= Restart;
        GameEvents.OnStartCharging -= StartCharging;
        GameEvents.OnShoot -= Shoot;
    }

    private void Update()
    {
        float dirX = moveAction.ReadValue<Vector2>().x;
        rb.linearVelocity = new Vector3(dirX * moveSpeed, rb.linearVelocity.y, 0f);

        if (!shooted)
        {
            if (isCharging)
            {
                if (chargingUp) pushForce += barSpeed * Time.deltaTime; else pushForce -= barSpeed * Time.deltaTime;

                if (pushForce > 1f || pushForce < 0.05f)
                    chargingUp = !chargingUp;

                pushForce = Mathf.Clamp(pushForce, 0.05f, 1f);

                forceBarBehavior.UpdateBarSpriteScale(pushForce);
            }
        }
        else
        {
            rb.AddForce(new Vector3(0, 0, pushForce * 1000));
        }

        if (transform.position.y < -10) GameEvents.TriggerRestart();
    }

    private void StartCharging()
    {
        isCharging = true;
    }
    private void Shoot()
    {
        isCharging = false;
        shooted = true;
    }

    private void Restart()
    {
        transform.position = initialPosition;
        isCharging = shooted = false;
    }

}