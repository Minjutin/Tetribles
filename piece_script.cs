using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piece_script : MonoBehaviour
{
    //this bool tells us if the piece is currently playable.
    private bool playable = true;

    //normal speed we use in this game;
    float speed = 0.4f;

    //if this bool is true when our piece isn't playable anymore, the player lose the game. 
    bool possibleEnd = false;
    
    //These two bools tells us if the player can move left or right or if there is a collision.
    bool collisionLeft = false;
    bool collisionRight = false;

    //This bool enables our piece's falling features. Otherwise it won't move along the y-axis.
    bool falling = true;

    AudioSource audioData;

    //When piece appears make it fall and also movable.
    void Start()
    {

        StartCoroutine(MovePieceDown());
        StartCoroutine(MovePlayerInput());
        StartCoroutine(SidePieceKiller());
    }

    
    //in update the piece can be rotated.
    void Update()
    {
        if (playable)
        {
            if (Input.GetKeyDown("up"))
            {
                transform.Rotate(0f, 0f, -90f, Space.World);
                foreach (Transform child in transform)
                {
                    child.transform.Rotate(0f, 0f, 90f, Space.World);
                }
                if (collisionRight)
                {
                    transform.position += new Vector3(-0.5f, 0, 0);
                }
                if (collisionLeft)
                {
                    transform.position += new Vector3(0.5f, 0, 0);
                }
            }
        }
    } 

    //Make the piece fall dowb.
    IEnumerator MovePieceDown()
    {
        while (falling)
        {            
            transform.position += new Vector3(0, -0.5f, 0);
            //Check if player is holding down down key.
            if (Input.GetKey("down"))
            {
                yield return new WaitForSeconds(speed*0.25f);
            }
            else
            {
               yield return new WaitForSeconds(speed);
            }
        }
    }

    //Make the piece movable by player input.
    IEnumerator MovePlayerInput()
    {
        while (playable)
        {

            //When player uses left or right arrow move the piece horizontally.
            if (Input.GetKey("right") && collisionRight == false)
            {
                transform.position += new Vector3(0.5f, 0, 0);
            }
            else if (Input.GetKey("left") && collisionLeft == false)
            {
                transform.position += new Vector3(-0.5f, 0, 0);
            }       

            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator SidePieceKiller()
    {
        yield return new WaitForSeconds(9f);
        if (falling)
        {
            falling = false;
            playable = false;
            GameObject.Find("Piece_Spawner").GetComponent<spawn_piece>().grounded = true;
        }
    }
        //When the piece collides run this IEnumerator.
        IEnumerator PieceKiller()
    {
        falling = false;
        //if player isn't touching the roof create a new playable piece by using spawn_piece code.
        if (possibleEnd == false)
        {
            GameObject.Find("Piece_Spawner").GetComponent<spawn_piece>().grounded = true;
        }
        //otherwise stop the game.
        else
        {
            GameObject.Find("Piece_Spawner").GetComponent<spawn_piece>().gameOn = false;
        }

        //deactive the player but do it in a way that they can still move the old piece horizontally.
        yield return new WaitForSeconds(0.08f);
        playable = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //If piece collides with something else than our grid then kill the piece, but only once.
        ////If piece is already killed we check it by checking if variable falling is false.
        if(other.gameObject.tag != "Square" && falling)
        {
            //play a voice.
            audioData = GameObject.Find("Piece_Spawner").GetComponent<AudioSource>();
            audioData.Play(0);

            StartCoroutine(PieceKiller());
        }
        
    }

    //Check if piece is fine
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Finish")
        {
            possibleEnd = true;
        }
        
        //Let us check if our piece is touching a wall.
        if (other.tag == "wall" && transform.position.x < 0)
        {
            collisionLeft = true;
        }
        
        if (other.tag == "wall" && transform.position.x >= 0)
        {
            collisionRight = true;
        }
    }

    //Only deactivate bools that were activated when trigger stay happened.
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            possibleEnd = false;
        }
        if (other.tag == "wall" && transform.position.x < 0)
        {
            collisionLeft = false;
        }
        if (other.tag == "wall" && transform.position.x >= 0)
        {
            collisionRight = false;
        }
    }


}
