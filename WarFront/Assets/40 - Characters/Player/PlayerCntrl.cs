using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private InputSystem inputSystem;
    [SerializeField] private GameObject crossHairPreFab;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private GameObject testBulletPreFab;
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private GameObject targetPointPreFab;

    private GameObject crossHair;

    private CharacterController charCntrl;

    private Camera mainCamera;

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        charCntrl = GetComponent<CharacterController>();
        mainCamera = Camera.main;
        crossHair = Instantiate(crossHairPreFab);
    }

    // Update is called once per frame
    void Update()
    {
        InputDirective command = inputSystem.ReadMovement();

        Vector2 mouse = inputSystem.ReadMousePosition();
        
        if(inputSystem.IsLeftMouseButtonPressed())
        {
            ShootWeapon(mouse);
        }

        PlayerMovement(command, Time.deltaTime);
    }

    public void OnFire()
    {
        GameObject bullet = Instantiate(testBulletPreFab, muzzlePoint.position, Quaternion.identity);
        TestBulletCntrl cntrl = bullet.GetComponent<TestBulletCntrl>();
        cntrl.AddForce(50.0f);
    }

    private void ShootWeapon(Vector2 mouse)
    {
        Ray ray = mainCamera.ScreenPointToRay(mouse);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10000f))
        {
            GameObject target = Instantiate(targetPointPreFab, hit.point, Quaternion.identity);

            GameObject bullet = Instantiate(testBulletPreFab, muzzlePoint.position, Quaternion.identity);
            bullet.transform.forward = (hit.point - muzzlePoint.position).normalized;
            TestBulletCntrl cntrl = bullet.GetComponent<TestBulletCntrl>();
            cntrl.AddForce(500.0f);
        }
    }

    private void PlayerMovement(InputDirective command, float dt)
    {
        switch(command)
        {
            case InputDirective.INPUT_STILL:
                break;
            case InputDirective.INPUT_LEFT:
                charCntrl.Move(gameObject.transform.right * -gameData.playerSpeed * dt);
                break;
            case InputDirective.INPUT_RIGHT:
                charCntrl.Move(gameObject.transform.right * gameData.playerSpeed * dt);
                break;
        }
    }

    private void OnEnable()
    {
        InputSystem.OnFire += OnFire;
    }

    private void OnDisable()
    {
        InputSystem.OnFire -= OnFire;
    }
}
