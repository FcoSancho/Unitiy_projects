using UnityEngine;

public class Elephant : MonoBehaviour
{

    private bool eleJump = false;
    public Rigidbody elerb;

    void FixedUpdate()
    {
       if (Input.GetKey("e") && eleJump == false) {
            elerb.AddForce(0, 5000000, 0);
            eleJump = true;
        }
        if (!Input.GetKey("e") && eleJump == true) {
            eleJump = false;
        } 
    }
}
