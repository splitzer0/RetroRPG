using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class camerafollow : MonoBehaviour
{
    public static camerafollow instance;

    public Vector2 PeekAdjustRaw;
    public Vector2 PeekAdjust;
    public float PeekMod;
    public Vector3 NewPos;
    public Transform Player;
    public float LerpTime;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        transform.position = new Vector3(Player.position.x, Player.position.y, -15f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PeekAdjust);
        Debug.Log(NewPos);

        NewPos = new Vector3(Player.position.x + PeekAdjust.x, Player.position.y + PeekAdjust.y, -15f);
    }


    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, NewPos, LerpTime * Time.deltaTime);
    }

    
    public void peekCamera(InputAction.CallbackContext context)
    {

        if (MenuManager.instance.menuOpen == false)
        {
            PeekAdjustRaw = context.ReadValue<Vector2>();
            Vector2 PeekAdjustRawdata = PeekAdjustRaw;
            if (PeekAdjustRawdata.x != 0 && PeekAdjustRawdata.y != 0)
            {
                PeekAdjustRawdata.x = 0;
            }

            PeekAdjust = PeekAdjustRawdata * PeekMod;
        }

    }
    
}
