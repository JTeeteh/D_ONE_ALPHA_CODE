using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Change this line

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject PlayerCamera;
    public SpriteRenderer sr;
    public TextMeshProUGUI PlayerNameText; // Change this line

    public bool IsGrounded = false;
    public float MoveSpeed;
    public float JumpForce;

    private void Awake()
    {
        if (photonView.isMine)
        {
            PlayerCamera.SetActive(true);
            //photonView.RPC("UpdatePlayerNameText", PhotonTargets.AllBuffered, "YourPlayerNameHere");
            PlayerNameText.text = PhotonNetwork.playerName;

        }
        else
        {
            PlayerNameText.text = photonView.owner.name;
            PlayerNameText.color = Color.cyan;
        }
    }

    private void Update()
    {
        if (photonView.isMine)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        transform.position += move * MoveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A))
        {
            photonView.RPC("FlipTrue", PhotonTargets.AllBuffered);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            photonView.RPC("FlipFalse", PhotonTargets.AllBuffered);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }

    [PunRPC]
    private void FlipTrue()
    {
        sr.flipX = true;
    }

    [PunRPC]
    private void FlipFalse()
    {
        sr.flipX = false;
    }

    [PunRPC]
    private void UpdatePlayerNameText(string playerName)
    {
        PlayerNameText.text = playerName;
    }
}
