using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForce = 7f;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector2 _moveVector;
    private bool _faceRight = true;
    private bool _isGrounded;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovePlayer();
        Reflect();
        Jump();               
    }

    private void MovePlayer()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = (new Vector2(_moveVector.x * _moveSpeed, _rigidbody2D.velocity.y));
        _animator.SetFloat(AnimatorPlayerController.Params.MoveX, Mathf.Abs(_moveVector.x));
    }

    private void Reflect()
    {
        if (_moveVector.x > 0 && !_faceRight || _moveVector.x < 0 && _faceRight)
        {
            transform.localScale *= new Vector2(-1, 1);
            _faceRight = !_faceRight;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&_isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        }
        _animator.SetBool(AnimatorPlayerController.Params.IsGround, _isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var ground = collision.gameObject.GetComponent<Ground>();

        if (ground)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var ground = collision.gameObject.GetComponent<Ground>();

        if (ground)
        {
            _isGrounded = false;
        }
    }
}
