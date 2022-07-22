using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    // A prefab is a game object we can reuse lots of times
    // we remove it from the hieracy and make a Prefab folder
    // inside of Assets
    [SerializeField] GameObject prefab;
    // prefab is a template from which you can make new Prefab instances
    bool _gameOver = false; 


    public void SpawnObject()
    {

        // instansiate( template of the new obj, the vector which it should appear at, Quaternion.identity - identifies with the parent axis
        Instantiate(prefab, new Vector3(Random.Range(-8,8), 8f, 0f), Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // this is an automatic method build into unity
        // collision will have tjhe input to whatever object its attached to
        // collides with, so in this case if prefab hits player, collision = player
        // and if prefab hits the ground collision = ground.
        if(collision.gameObject.tag == "Player" && !_gameOver)
        {
            // put in new object
            SpawnObject();
            // destroy last - in this scope the game object is a prefab
            Destroy(gameObject); 

        } else if(collision.gameObject.tag == "Ground")
        {
            _gameOver = true;
            Debug.Log("GAME OVER! UNLUCKY!");
        }
    }

}
