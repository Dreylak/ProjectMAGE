using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mage : MonoBehaviour {

    public float Cooldown
    {
        get
        {
            return cooldown;
        }

        set
        {
            cooldown = value;
        }
    }

    public Animator animator;

    public GameObject defaultSpell;
    public Transform spellSpawnPoint;

    private GameObject selectedSpell;

    private float spellCooldown;
    //cooldown = 0 to give opportunity to cast first spell immediately
    private float cooldown = 0f;

    //time for cast animation before spell created
    private float castTime;

    //limits the area on the screen where spell can be casted (only above the castle)
    private float areaToCast;

    //mage is singleton to save reference to mage in spell select buttons
    public static Mage Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //get spell cooldown from spell params
        SelectSpell(defaultSpell);
        FindAreaToCast();
    }

    //NEED FIX.... maybe
    void FindAreaToCast()
    {
        areaToCast = -4;
        Debug.Log(areaToCast);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Cooldown <= 0f)
            {
                //get mouse coordinates
                //NEED FIX Dont cast spell if pressed on UI ellement(except healthbars)
                //if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    if (target.y > areaToCast)
                    {
                        animator.SetTrigger("castSpell");

                        //wait for cast animation
                        //implement
                        //StartCoroutine(WaitForAnimation(animator));
                        //Debug.Log("Animation ended");

                        CreateSpell(target);
                        cooldown = spellCooldown;
                    }
                }

            }
        }
     
        if (Cooldown >= 0f)
            Cooldown -= Time.deltaTime;
    }


    //create a spell that will move to the point where was clicked
    void CreateSpell(Vector2 target)
    {
        //rotate spell spawn point in the direction of mouse click
        Vector3 dir = new Vector3(target.x, target.y) - spellSpawnPoint.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        spellSpawnPoint.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        GameObject spellGO = (GameObject)Instantiate(selectedSpell, 
                                                    spellSpawnPoint.position, 
                                                    spellSpawnPoint.rotation);
        Spell spell = spellGO.GetComponent<Spell>();

        if(spell != null)
            spell.SetTarget(target);
    }

    //change spell that will be casted after click
    public void SelectSpell(GameObject spell)
    {
        selectedSpell = spell;
        spellCooldown = selectedSpell.GetComponent<Spell>().cooldown;
    }
}
