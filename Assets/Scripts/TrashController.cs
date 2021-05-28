using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{

    public float moveVelocity;
    private bool keepMoving = true;
    // Start is called before the first frame update
    private GameController gameController = new GameController();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (keepMoving)
        {
            if (this.gameObject != null)
            {
                this.transform.Translate(new Vector3(0, Time.deltaTime * moveVelocity * -1, 0), Camera.main.transform);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name.Equals("Sand"))
        {

            keepMoving = false;
        }


    }

    private void OnMouseDown()
    {
        gameController.AddPoints(1);
        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }

    }

}
