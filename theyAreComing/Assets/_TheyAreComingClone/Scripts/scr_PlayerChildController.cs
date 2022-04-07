using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class scr_PlayerChildController : MonoBehaviour
{
    public static scr_PlayerChildController Instance;
    float _touchOldPosX, _touchNewPosX, _deltaX;
    float _touchRotY;

    [SerializeField] float horizontalSpeed;
    [SerializeField] float clampX;

    public bool isActive=true;

    void Awake()
    {
            if(Instance==null)
            Instance=this;
            else
            Destroy(Instance);
    }

    void Update()
    {
        if (Input.GetMouseButton(0)&& isActive)
        {
            _touchNewPosX += Input.GetAxis("Mouse X") * -horizontalSpeed * Time.deltaTime;
            _deltaX = _touchNewPosX - _touchOldPosX;
            _touchOldPosX = _touchNewPosX;

            transform.localPosition = new Vector3(transform.localPosition.x+_deltaX, transform.localPosition.y, transform.localPosition.z);
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            _deltaX = 0;
                        
        }

        

        transform.localPosition=new Vector3(
                    Mathf.Clamp(transform.localPosition.x,-0.9f,0.9f)
                    ,transform.localPosition.y
                    ,transform.localPosition.z);

    /*void OnHorizontal(InputValue horizontalInput)
    {
        _xInput=horizontalInput.Get<Vector2>().x;
    }*/

}}
