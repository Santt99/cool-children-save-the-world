using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ManController : MonoBehaviour
{
    public float moveVelocity;
    public Vector2 limitY;
    public GameObject trash;

    public float pitch;
    public float rate;
    private bool keepMovingUp = true;

    private bool keepAlive = true;
    // Start is called before the first frame update
    private GameController gameController;
    void Start()
    {
        gameController = new GameController();
    }



    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.y < limitY.x)
        {
            keepAlive = false;
        }
        else if (this.transform.position.y > limitY.y)
        {

            keepMovingUp = false;
            SpawnTrash();
        }

        if (keepMovingUp)
        {
            if (this.gameObject != null)
            {
                this.transform.Translate(new Vector3(0, Time.deltaTime * moveVelocity, 0), Camera.main.transform);
            }

        }
        else
        {
            if (this.gameObject != null)
            {
                this.transform.Translate(new Vector3(0, Time.deltaTime * moveVelocity * -1, 0), Camera.main.transform);
            }
        }
        if (!keepAlive)
        {
            Destroy(this.gameObject);
        }


    }

    private void SpawnTrash()
    {


        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
        Vector3 randomPosition = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, 0);
        Instantiate(trash, randomPosition, randomRotation);

    }

}
