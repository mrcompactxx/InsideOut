using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    private float startingPos;
    private float lenghtOfSprite;
    [SerializeField]private float amountOfParallax;
    public Camera mainCamera;
    private void Start()
    {
        startingPos = transform.position.x;
        lenghtOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        Vector3 position = mainCamera.transform.position;
        float temp = position.x * (1 - amountOfParallax);
        float distance = position.x * amountOfParallax;

        Vector3 newPosition = new Vector3 (startingPos+distance, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
