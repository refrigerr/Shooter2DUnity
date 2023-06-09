using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _obstacleLayer;
    private Animator _animator;
    private Rigidbody2D _playerRB;
    private BoxCollider2D _boxCollider2D;
    private bool _facesRight = true;
    private void Awake()
    {
        //references for rigidbody and animator
        _playerRB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }


    private void Update(){

        if(AWindow.GameIsPaused)
            return;

        if(Input.GetButtonDown("Jump") && isGrounded()){
            Jump();
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRB.velocity = new Vector2(horizontalInput * speed, _playerRB.velocity.y);
      
        //flips player when moving left/right
        FilpPlayer();

        

        //set animator parameter
        _animator.SetBool("Run", horizontalInput != 0);
        _animator.SetBool("Grounded", isGrounded());
        _animator.SetFloat("yVelocity", _playerRB.velocity.y);
    }

    private void Jump()
    {
        _playerRB.velocity = new Vector2(_playerRB.velocity.x, _jumpForce);
        _animator.SetTrigger("Jump");
    
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center,_boxCollider2D.bounds.size, 0 , Vector2.down, 0.1f, _obstacleLayer);
        return raycastHit2D.collider != null;
    }
    public bool FacesRight()
    {
        return _facesRight;
    }
    private void FilpPlayer(){
        if(_playerRB.velocity.x > 0f && !_facesRight){
            Flip();
        }
        else if(_playerRB.velocity.x < 0f && _facesRight)
        {
            Flip();
        }
        else if (_playerRB.velocity.x == 0)
        {
            if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= _playerRB.transform.position.x && !_facesRight)
            {
                Flip();
            }
            else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < _playerRB.transform.position.x && _facesRight)
            {
                Flip();
            }
        }
    }

    private void Flip(){
        Vector3 currentScale = this.transform.localScale;
        currentScale.x *= -1;
        this.transform.localScale = currentScale;
        _facesRight = !_facesRight;
    }
}
