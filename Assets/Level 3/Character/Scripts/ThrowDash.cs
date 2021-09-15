using UnityEngine;

public class ThrowDash : MonoBehaviour
{
    public Char_Controller2 cc;
    public GameObject projectile;
    public GameObject aim_graphic;
    public Transform shotPoint;
    public float launchForce;
    public float projectileLifetime = 0.25f;
    private GameObject Tracker;
    private bool Thrown = false;
    private float Cooldown = 0f;
    private bool Ported;
    public bool Throwable = true;

    void Start()
    {
        Cursor.visible = false;
        aim_graphic.SetActive(false);
    }
    void Update()
    {
        transform.position = cc.transform.position;

        if (Input.GetMouseButtonDown(0) && PauseMenu.GameIsPaused == false && !Thrown && Throwable)
        {
            aim_graphic.SetActive(true);
        }
  
        if(Input.GetMouseButtonUp(0) && PauseMenu.GameIsPaused == false && !Thrown && Throwable)
        {
            aim_graphic.SetActive(false);
            GameObject newProjectile = Instantiate(projectile, shotPoint.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            Tracker = newProjectile;
            Destroy(newProjectile, projectileLifetime);
            Thrown = true;
            Ported = true;
            Cooldown = projectileLifetime;
        }


        if (Cooldown < 0)
        {
            Thrown = false;
        }

        if (Thrown)
        {
            Cooldown -= Time.deltaTime;
            cc.GetComponent<CapsuleCollider2D>().enabled = false;
            cc.GetComponent<CircleCollider2D>().enabled = false;
            cc.GetComponent<SpriteRenderer>().enabled = false;

            if (Tracker != null)
            {
                cc.transform.position = Tracker.transform.position;
            }

            Throwable = false;
        }
        else if (Ported)
        {
            cc.GetComponent<CapsuleCollider2D>().enabled = true;
            cc.GetComponent<CircleCollider2D>().enabled = true;
            cc.GetComponent<SpriteRenderer>().enabled = true;
            cc.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Ported = false;
        }

        if (Tracker != null)
        {
            if (Tracker.GetComponent<DestroyProjectile>().Falling == true)
            {
                Destroy(Tracker);
                Thrown = false;
                Cooldown = 0;
            }
        }
        


    }

    private void FixedUpdate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
