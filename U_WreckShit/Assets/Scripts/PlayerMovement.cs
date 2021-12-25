using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{

    
    [SerializeField]
    private float movementSpeed = 1.0f;
    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;



    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
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

        // Make sure we can move in this direction, by casting a box there first, if the box returns null we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime * movementSpeed), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null)
        {
            //Make this thing move !
            transform.Translate(0, moveDelta.y * Time.deltaTime * movementSpeed, 0);
        }

        // Make sure we can move in this direction, by casting a box there first, if the box returns null we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime * movementSpeed), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Make this thing move !
            transform.Translate(moveDelta.x * Time.deltaTime * movementSpeed, 0, 0);
        }
    }
}
