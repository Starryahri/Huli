using UnityEngine;

public class Throw2 : MonoBehaviour
{
    public Char_Controller2 cc;
    public GameObject projectile;
    public GameObject aim_graphic;
    public Transform shotPoint;
    public GameObject Targetting;
    public float launchForce;
    public float projectileLifetime = 3f;
    private float CurrentCharge = 0.2f;
    private float Cooldown = 0f;
    private bool ButtonPressed = false;
    private bool Armed = false;
    public bool ChargedShot = true;

    void Start()
    {
        //Cursor.visible = false;
        aim_graphic.SetActive(false);
        Cooldown = 0f;
    }
    void Update()
    {
        transform.position = cc.transform.position;

        if (Cooldown > 0)
        {
            Cooldown -= Time.deltaTime;
        }


        //Charge up the lifespan
        if (ChargedShot)
        {
            if (Input.GetMouseButton(0) && PauseMenu.GameIsPaused == false)
            {
                if (CurrentCharge < projectileLifetime)
                {
                    CurrentCharge += Time.deltaTime * 3;
                }
                if (CurrentCharge > projectileLifetime)
                {
                    CurrentCharge = projectileLifetime;
                }
            }
        }
        else
        {
            CurrentCharge = projectileLifetime;
        }


        if (Input.GetMouseButtonDown(0) && PauseMenu.GameIsPaused == false)
        {
            CurrentCharge = 0.2f;
            ButtonPressed = true;
            Armed = true;
        }
        if (Input.GetMouseButtonUp(0) && PauseMenu.GameIsPaused == false)
        {
            ButtonPressed = false;
        }

        if (ButtonPressed && Armed && Cooldown <= 0)
        {
            aim_graphic.SetActive(true);
        }
  
        if(!ButtonPressed && Armed && Cooldown <= 0)
        {
            Cooldown = 0.5f;
            cc.Throw();
            aim_graphic.SetActive(false);
            GameObject newProjectile = Instantiate(projectile, shotPoint.position, Targetting.transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().velocity = Targetting.transform.right * launchForce;
            Destroy(newProjectile, CurrentCharge);
            Armed = false;
        }

    }

    private void FixedUpdate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(Targetting.transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Targetting.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
