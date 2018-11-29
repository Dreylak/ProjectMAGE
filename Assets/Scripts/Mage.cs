using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mage : MonoBehaviour {

    public Animator animator;

    public GameObject defaultSpell;
    public Transform spellSpawnPoint;

    private GameObject selectedSpell;
    public GameObject SelectedSpell { get; set; }

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
        SelectedSpell = defaultSpell;
        FindAreaToCast();
    }

    //NEED FIX.... maybe
    void FindAreaToCast()
    {
        areaToCast = -4;
        Debug.Log(areaToCast);
    }

    private bool IsMouseOverUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);

        for(int i = 0; i < raycastResultList.Count; i++)
        {
            if(raycastResultList[i].gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                return true;
            }
        }
  
        return false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            if (cooldown <= 0f)
            {
                //get mouse coordinates
                Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (target.y > areaToCast)
                {
                    animator.SetTrigger("castSpell");

                    CreateSpell(target);
                    cooldown = SelectedSpell.GetComponent<Spell>().stats.cooldown;
                }
            }
        }

        if (cooldown >= 0f)
            cooldown -= Time.deltaTime;
    }


    //create a spell that will move to the point where was clicked
    void CreateSpell(Vector2 target)
    {
        //rotate spell spawn point in the direction of mouse click
        Vector3 dir = new Vector3(target.x, target.y) - spellSpawnPoint.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        spellSpawnPoint.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        GameObject spellGO = (GameObject)Instantiate(SelectedSpell, 
                                                    spellSpawnPoint.position, 
                                                    spellSpawnPoint.rotation);
        Spell spell = spellGO.GetComponent<Spell>();

        if(spell != null)
            spell.SetTarget(target);
    }

}
