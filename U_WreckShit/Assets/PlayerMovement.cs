using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{

    
    [SerializeField]
    private float movementSpeed = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

    }

    private void FixedUpdate()
    {
        


        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset MoveDelta
        Vector3 moveDelta = new Vector3(x, y, 0);

        //Swap spirte direction, whether you're going right or left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //Make this thing move !
        transform.Translate(moveDelta * Time.deltaTime * movementSpeed);
    }
}
