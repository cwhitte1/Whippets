using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeafScript : MonoBehaviour {
    private bool success = false;
    public Text winText;
    public Canvas myCanvas;
    public Canvas loseMessage;
    public Collider2D floor;
    public Text timeText;
    public float targetTime = 10.0f;

    // Use this for initialization
    void Start () {
        winText.text = "";

    }
	
	// Update is called once per frame
	void Update () {
        if (targetTime > 0)
        {
            timeText.text = targetTime.ToString("N4");
        }else
        {
            timeText.text = "0.0000";
        }
        if (success)
        {
            success = true;
            transform.position = new Vector2(0, 10);
            //Destroy(gameObject);
            myCanvas.gameObject.SetActive(true);
        }

        targetTime -= Time.deltaTime;
        Debug.Log(targetTime);
        if (targetTime <= 0.0f && success==false)
        {
            loseMessage.gameObject.SetActive(true);
            DestroyFloor(floor);
        }
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Success"))
        {
            success = true;
        }
    }

    void DestroyFloor(Collider2D other)
    {
        Destroy(other);
    }

}
