using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UnitSelection : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public GameObject box;

    Vector2 mousePosition;
    Vector2 startPos;

    Vector2 scaleVector;

    GameObject activeBox;

    //public LayerMask mask;

    public bool selecting;

    public List<GameObject> unitsSelected;
    public void OnBeginDrag(PointerEventData eventData)
    {
        unitsSelected = new List<GameObject>();
        selecting = true;
        startPos = new Vector2();
        mousePosition = new Vector2();

        startPos = Camera.main.ScreenToWorldPoint(eventData.position);
        activeBox = Instantiate(box, startPos, Quaternion.identity);

        Box b = activeBox.GetComponentInChildren<Box>();

        b.selection = this.GetComponent<UnitSelection>();

        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(eventData.position);

        scaleVector =  mousePosition - startPos;

        activeBox.transform.localScale = (Vector3)scaleVector;
        //throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        selecting = false;

        Destroy(activeBox,0.1f);

        Debug.Log("endPos");
        //throw new System.NotImplementedException();
    }


    


}
