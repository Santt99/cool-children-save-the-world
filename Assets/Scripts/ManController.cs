using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextSpeech;


public class ManController : MonoBehaviour
{
    public float moveVelocity;
    public Vector2 limitY;
    public GameObject trash;

    public float pitch;
    public float rate;

    public Text txtLocale;
    public Text txtPitch;
    public Text txtRate;

    private bool keepMovingUp = true;

    private bool keepAlive = true;
    // Start is called before the first frame update
    private GameController gameController = new GameController();
    void Start()
    {
        Setting("en-US");
        SpeechToText.instance.onResultCallback = OnResultSpeech;
        StartRecording();
    }

    public void Setting(string code)
    {
        TextToSpeech.instance.Setting(code, pitch, rate);
        SpeechToText.instance.Setting(code);
    }
    public void StartRecording()
    {
#if UNITY_EDITOR
#else
        SpeechToText.instance.StartRecording("Speak any");
#endif
    }

    public void StopRecording()
    {
#if UNITY_EDITOR
        OnResultSpeech("Not support in editor.");
#else
        SpeechToText.instance.StopRecording();
#endif

    }
    void OnResultSpeech(string _data)
    {
        if (_data == "No")
        {
            keepMovingUp = false;
        }

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
            StopRecording();
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
