using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimationState
{
    HorizontalRun,
    UpRun,
    DownRun,
    HorizontalIdle,
    DownIdle,
    TopIdle,
    DemonChange,
}
public enum Direction
{
    Up,
    Down,
    Left,
    Right,
}
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode m_OriginalUpKey;
    [SerializeField] private KeyCode m_OriginalDownKey;
    [SerializeField] private KeyCode m_OriginalLeftKey;
    [SerializeField] private KeyCode m_OriginalRightKey;
    [SerializeField] private Rigidbody2D m_RigidBody;
    [SerializeField] private Transform m_PlayerTransform;
    [SerializeField] private BoxCollider2D m_BoxCollider;
    [SerializeField] private float m_PlayerSpeed;
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private GameObject Swirl;
    private KeyCode m_UpKey;
    private KeyCode m_DownKey;
    private KeyCode m_LeftKey;
    private KeyCode m_RightKey;

    private float m_SwitcheRoo;
    private bool m_RecentSwitch;
    private float m_SwitchTimer = 3;
    private float m_ControlTimer = 30;

    private Collision2D m_Col;
    private int m_JustWorkPlz;
    private float swirltimer = 1;
    private int startswrirl;
    private int m_Key1;
    private int m_Key2;
    private int m_Key3;
    private int m_Key4;

    int PotentionalKeys = 1;
    public AnimationState m_AnimationState;
    public Direction m_Direction;
    private Animator m_Animator;
    private float DemonChangeTimer = 0.3f;
    void Start()
    {
        m_RigidBody.GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Animator = GetComponent<Animator>();
        m_UpKey = m_OriginalUpKey;
        m_DownKey = m_OriginalDownKey;
        m_LeftKey = m_OriginalLeftKey;
        m_RightKey = m_OriginalRightKey;
        
    }

    public void SetDirection(Direction direction)
    {
        m_Direction = direction;
    }
    public void SetAnimation(AnimationState animatestation)
    {
        m_AnimationState = animatestation;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "TestPlayer" && m_JustWorkPlz == 0 && m_RecentSwitch == false && m_PlayerTransform.tag == "Possesed" && m_SwitcheRoo >= 2)
        {
            m_Col = col;
            m_JustWorkPlz = 1;
            m_SwitcheRoo = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (m_JustWorkPlz == 1 && m_RecentSwitch == false)
        {
            m_PlayerTransform.tag = "TestPlayer";
            m_Col.gameObject.tag = "Possesed";
            m_JustWorkPlz = 0;
        }
        if (m_SwitcheRoo == 0)
        {
            m_SwitcheRoo = 1;
        }
        if (m_PlayerTransform.tag == "Possesed" && m_SwitcheRoo == 1)
        {
            m_RecentSwitch = true;
        }
        if (m_PlayerTransform.tag == "Possesed")
        {
            
            transform.localScale = new Vector3(2.5f, 2.5f, 1.0f);
        }
        else if (m_PlayerTransform.tag == "TestPlayer")
        {
            DemonChangeTimer = 0.3f;
            transform.localScale = new Vector3(2, 2, 1);
            m_RecentSwitch = false;
        }
        if (m_PlayerTransform.tag == "Possesed")
        {
            m_Animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("DAnimation1");
        }
        else if (m_PlayerTransform.name == "Player1" && m_PlayerTransform.tag == "TestPlayer")
        {
            m_Animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("CAnimation1");
        }
        else if (m_PlayerTransform.name == "Player2" && m_PlayerTransform.tag == "TestPlayer")
        {
            m_Animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("CAnimation2");
        }
        else if (m_PlayerTransform.name == "Player3" && m_PlayerTransform.tag == "TestPlayer")
        {
            m_Animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("CAnimation3");
        }
        else if (m_PlayerTransform.name == "Player4" && m_PlayerTransform.tag == "TestPlayer")
        {
            m_Animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("CAnimation4");
        }
        if (m_RecentSwitch == false)
        {
            m_RigidBody.velocity = Vector3.zero;
            m_RigidBody.angularVelocity = 0;

            if(m_PlayerTransform.tag == "Possesed")
            {

                if (Input.GetKey(m_OriginalUpKey))
                {
                    m_RigidBody.AddForce(Vector2.up * m_PlayerSpeed * Time.deltaTime, ForceMode2D.Force);
                }
                else if (Input.GetKey(m_OriginalLeftKey))
                {
                    m_RigidBody.AddForce(Vector2.left * m_PlayerSpeed * Time.deltaTime, ForceMode2D.Force);
                }
                else if (Input.GetKey(m_OriginalDownKey))
                {
                    m_RigidBody.AddForce(Vector2.down * m_PlayerSpeed * Time.deltaTime, ForceMode2D.Force);
                }
                else if (Input.GetKey(m_OriginalRightKey))
                {
                    m_RigidBody.AddForce(Vector2.right * m_PlayerSpeed * Time.deltaTime, ForceMode2D.Force);
                }
            }
            else
            {
                if (Input.GetKey(m_UpKey))
                {
                    m_RigidBody.AddForce(Vector2.up * m_PlayerSpeed * Time.deltaTime, ForceMode2D.Force);
                }
                else if (Input.GetKey(m_LeftKey))
                {
                    m_RigidBody.AddForce(Vector2.left * m_PlayerSpeed * Time.deltaTime, ForceMode2D.Force);
                }
                else if (Input.GetKey(m_DownKey))
                {
                    m_RigidBody.AddForce(Vector2.down * m_PlayerSpeed * Time.deltaTime, ForceMode2D.Force);
                }
                else if (Input.GetKey(m_RightKey))
                {
                    m_RigidBody.AddForce(Vector2.right * m_PlayerSpeed * Time.deltaTime, ForceMode2D.Force);
                }
            }
            // moving depending on the keyinput
            

            ///
            if (Input.GetKey(m_UpKey))
            {
                SetAnimation(AnimationState.UpRun);
                SetDirection(Direction.Up);
            }
            else if (Input.GetKey(m_LeftKey))
            {
                if (m_PlayerTransform.tag == "Possesed")
                {
                    m_SpriteRenderer.flipX = true;
                }
                else
                {
                    m_SpriteRenderer.flipX = false;
                }
                SetAnimation(AnimationState.HorizontalRun);
                SetDirection(Direction.Left);
            }
            else if (Input.GetKey(m_DownKey))
            {
                SetAnimation(AnimationState.DownRun);
                SetDirection(Direction.Down);
            }
            else if (Input.GetKey(m_RightKey))
            {
                if (m_PlayerTransform.tag == "Possesed")
                {
                    m_SpriteRenderer.flipX = false;
                }
                else
                {
                    m_SpriteRenderer.flipX = true;
                }
                SetAnimation(AnimationState.HorizontalRun);
                SetDirection(Direction.Right);
            }

            if(!Input.GetKey(m_UpKey)&&!Input.GetKey(m_LeftKey) && !Input.GetKey(m_RightKey) && !Input.GetKey(m_DownKey))
            {
                if(m_Direction == Direction.Up)
                {
                    SetAnimation(AnimationState.TopIdle);
                }
                if (m_Direction == Direction.Left)
                {
                    SetAnimation(AnimationState.HorizontalIdle);
                }
                if (m_Direction == Direction.Down)
                {
                    SetAnimation(AnimationState.DownIdle);
                }
                if (m_Direction == Direction.Right)
                {
                    SetAnimation(AnimationState.HorizontalIdle);
                }
            }


            /*
            if (m_RigidBody.velocity.magnitude < .01)
            {
                m_RigidBody.velocity = Vector3.zero;
                m_RigidBody.angularVelocity =  0;
            }*/

        }
        else if (m_RecentSwitch == true && m_PlayerTransform.tag == "Possesed")
        {
            DemonChangeTimer -= Time.deltaTime;
            if(DemonChangeTimer >= 0)
            {
                SetAnimation(AnimationState.DemonChange);
            }
            else
            {
                SetAnimation(AnimationState.DownIdle);
            }
            
            m_RigidBody.velocity = Vector3.zero;
            m_RigidBody.angularVelocity = 0;
            m_SwitchTimer -= Time.deltaTime;
            if (m_SwitchTimer <= 0)
            {
                m_RecentSwitch = false;
                m_SwitcheRoo = 2;
                m_SwitchTimer = 3;
            }
        }
        else
        {
            
            m_RecentSwitch = false;
        }
        m_ControlTimer -= Time.deltaTime;
        if (m_ControlTimer <= 0)
        {
            Swirl.SetActive(true);
            RandomizeButtons();
            m_ControlTimer = 30;
            startswrirl = 1;
        }
        if(startswrirl == 1)
        {
            swirltimer -= Time.deltaTime;
            if (swirltimer <= 0)
            {
                Swirl.SetActive(false);
                swirltimer = 1;
                startswrirl = 0;
            }
        }
      
        
        m_Animator.SetInteger("State", (int)m_AnimationState);
    }
    private void RandomizeButtons()
    {
        PotentionalKeys = Random.Range(1, 4);
            if (PotentionalKeys == 1)
            {
                m_UpKey = m_OriginalUpKey;
                m_DownKey = m_OriginalDownKey;
                m_LeftKey = m_OriginalLeftKey;
                m_RightKey = m_OriginalRightKey;
            }
            else if (PotentionalKeys == 2)
            {
                m_UpKey = m_OriginalDownKey;
                m_DownKey = m_OriginalUpKey;
                m_LeftKey = m_OriginalRightKey;
                m_RightKey = m_OriginalLeftKey;
            }
            else if (PotentionalKeys == 3)
            {
                m_UpKey = m_OriginalLeftKey;
                m_DownKey = m_OriginalUpKey;
                m_LeftKey = m_OriginalDownKey;
                m_RightKey = m_OriginalRightKey;
            }
            else if (PotentionalKeys == 4)
            {
                m_UpKey = m_OriginalRightKey;
                m_DownKey = m_OriginalLeftKey;
                m_LeftKey = m_OriginalDownKey;
                m_RightKey = m_OriginalUpKey;
            }
    }
}
