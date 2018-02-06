using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour {

    int health = 5;
    public float speed;
    public float obstackleRage = 0.5f; //zmiena ustalacjąca przy jakim dystansie ma obiekt zmienić kierunek
    public float minY;
    public float maxY;
    public float maxX;
    public float minX;

    void Update()
    {
        CheckLife();
        RandomMove();
    }

    void CheckLife()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    } //metoda spradza czy obiekt ma jeszcze jakieś punkty zdrowia

    void Damage(int damage)
    {
        health -= damage;
    } //Metoda ktora zmniejsza poziom zdrowia


    void RandomMove()//losowe poruszanie się z wykorzystaniem Raycastingu
    {
        transform.Translate(speed * Time.deltaTime, 0, 0); //Poruszanie się obiektu
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right); //Wykrywanie innych obiektów 
        if (hit.collider != null && hit.transform.gameObject.tag != "Water")
        { 
            if (hit.distance < obstackleRage)
            {
                RandomRotate();
            }
        }
        if(transform.position.y>maxY)
        {
            transform.Rotate(0, 0, 180);
        }
        if(transform.position.y<minY)
        {
            transform.Rotate(0, 0, 180);
        }
        if(transform.position.x>maxX)
        {
            transform.Rotate(0, 0, 180);
        }
        if(transform.position.x<minX)
        {
            transform.Rotate(0, 0, 180);
        }
    } 

    private void RandomRotate() //Zmiana rotacji obektu na losowy
    {
        float angle = Random.Range(-100, 100);
        transform.Rotate(0, 0, angle);
    } 
}
