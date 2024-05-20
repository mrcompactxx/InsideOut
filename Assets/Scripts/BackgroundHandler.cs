using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    private float startingPos;
    private float lenghtOfSpriteX;
    [SerializeField]private float amountOfParallax;
    public Camera mainCamera;
    private void Start()
    {
        startingPos = transform.position.x;
        lenghtOfSpriteX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        Vector3 position = mainCamera.transform.position;
        float tempX = position.x * (1 - amountOfParallax);
        float horizontalDistance = position.x * amountOfParallax;

        Vector3 newPosition = new Vector3(startingPos + horizontalDistance, transform.position.y, transform.position.z);
        transform.position = newPosition;

        if (tempX > startingPos + lenghtOfSpriteX)
        {
            startingPos += lenghtOfSpriteX;
        }
        else if (tempX < startingPos - lenghtOfSpriteX)
        {
            startingPos -= lenghtOfSpriteX;
        }
   

    }
}
