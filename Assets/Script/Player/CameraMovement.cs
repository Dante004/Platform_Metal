using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    GameObject player;
    public Vector3 cameramax;
    public Vector3 cameramin;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Wyszukanie gracza
    }

    private void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10); //atualizacja pozycji kamery do pozycji postaci
        //Ustalenie granic gdzie kamera może podąży
        ChcekPositionCamera();

    }

    private void ChcekPositionCamera()
    {
        if (gameObject.transform.position.x > cameramax.x)
        {
            transform.position = new Vector3(cameramax.x, transform.position.y, -10);
        }
        if (gameObject.transform.position.x < cameramin.x)
        {
            transform.position = new Vector3(cameramin.x, transform.position.y, -10);
        }
        if (gameObject.transform.position.y > cameramax.y)
        {
            transform.position = new Vector3(transform.position.x, cameramax.y, -10);
        }
        if (gameObject.transform.position.y < cameramin.y)
        {
            transform.position = new Vector3(transform.position.x, cameramin.y, -10);
        }
    }

}
