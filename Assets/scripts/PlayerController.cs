using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float JumpF = 400f;							    // strenght of jump
	[Range(0, .3f)] [SerializeField] private float SmoothCriminal = .04f;	    // how smooth is my movement
    readonly float OnGroundR = .2f;                                             // size of overlap to determine if grounded

    [SerializeField] private bool ControlledFall = false;						// is it possible to contoll direction when jumping
    private bool Grounded;                                                      // Whether or not the player is grounded.
    private bool direction = true;                                              // For determining which way the player is currently facing.

    [SerializeField] private LayerMask IsUGround;							        // determining where the ground is
	[SerializeField] private Transform GroundCheck;							    // checkmark for player and ground
	private Rigidbody2D Rigid2d;
	private Vector3 iAmSpeed = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }


	private void Awake()
	{
		Rigid2d = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

	}

	private void FixedUpdate()
	{
        bool wasGrounded = Grounded;
        Grounded = false;

        // use collider to check if ground is in contact with player
        Collider2D[] collider = Physics2D.OverlapCircleAll(GroundCheck.position, OnGroundR, IsUGround);
		for (int i = 0; i < collider.Length; i++)
		{
            //if collider from game object hits colider frm not game object
			if (collider[i].gameObject != gameObject)
			{
                //then is grounded
				Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

    private void Turn()
    {
        // change direction 
        direction = !direction;

        // Multiply the player's x local scale by -1.
        Vector3 scaleMePls = transform.localScale;
        scaleMePls.x *= -1;
        transform.localScale = scaleMePls;
    }


    public void Go(float go, bool jump)
	{
		
		//restrict movement controll
		if (ControlledFall || Grounded)
		{


			// use velocity to move player
			Vector3 targetVelocity = new Vector2(go * 10f, Rigid2d.velocity.y);
			// smooth out the movement
			Rigid2d.velocity = Vector3.SmoothDamp(Rigid2d.velocity, targetVelocity, ref iAmSpeed, SmoothCriminal);

			// if right then turn right
			if (go > 0 && !direction)
			{
				// turn oposite direction
				Turn();
			}
			// if left then left
			else if (go < 0 && direction)
			{
                
                Turn();
			}
		}
		// when player jumps
		if (Grounded && jump)
		{
			// add vertical force
			Grounded = false;
			Rigid2d.AddForce(new Vector2(0f, JumpF));
		}
	}
}
