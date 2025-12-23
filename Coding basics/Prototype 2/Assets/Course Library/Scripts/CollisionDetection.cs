using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private GameObject animal;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Animal"))
        //{
        //    Destroy(gameObject);
        //    Destroy(other.gameObject);
        //}
        if (other.gameObject.CompareTag("Animal"))
        {
            Destroy(gameObject);
            animal = other.gameObject;
            animal.GetComponent<AnimalHunger>().Feed(20f);
        }
    }
}
