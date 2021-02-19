using System.Collections;
using UnityEngine;

public class PieceController : MonoBehaviour
{

    [SerializeField] private LayerMask slotLayer;
    public PieceStatesEnum pieceStatesEnum;
    public Vector2 originalPosition;
    private Camera _camera;

    private void Awake()
    {
        pieceStatesEnum = PieceStatesEnum.Free;
        _camera = Camera.main;
        originalPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (pieceStatesEnum == PieceStatesEnum.Free)
        {
            pieceStatesEnum = PieceStatesEnum.Following;
        }
    }

    private bool CanIPlaceThisPieceHere()
    {
        foreach (Transform piece in transform)
        {
            Collider2D slot = Physics2D.OverlapCircle(piece.transform.position, 0.5f, slotLayer);
            if (slot == null)
            {
                Debug.Log("Can't place here!");
                return false;
            }
            KanoodleSlot kanoodleSlot = slot.GetComponent<KanoodleSlot>();
            if (kanoodleSlot.slotStatesEnum != SlotStatesEnum.Snapped)
            {
                continue;
            }
            else
            {
                Debug.Log("Can't place here!");
                return false;
            }
        }
        return true;
    }

    private void OnMouseUp()
    {
        if (pieceStatesEnum == PieceStatesEnum.Snapped)
        {
            return;
        }

        if (CanIPlaceThisPieceHere())
        {
            pieceStatesEnum = PieceStatesEnum.Snapped;
            int count = 0;
            KanoodleSlot kanoodle = FindObjectOfType<KanoodleSlot>();
            kanoodle.UpdateSlots();
            foreach (Transform piece in transform)
            {
                count++;
                Collider2D[] slots = Physics2D.OverlapCircleAll(piece.transform.position, piece.GetComponent<CircleCollider2D>().radius, slotLayer);
                print(slots.Length);
                foreach (Collider2D slot in slots)
                {
                    print(slot != null);
                    Transform slotTr = slot.transform;
                    KanoodleSlot kanoodleSlot = slot.GetComponent<KanoodleSlot>();
                    kanoodleSlot.slotStatesEnum = SlotStatesEnum.Snapped;
                    piece.transform.position = slotTr.transform.position;
                    kanoodle = kanoodleSlot;
                }
            }
            print(count);
            Debug.Log("The piece is well placed!");
            return;
        }
        else
        {
            pieceStatesEnum = PieceStatesEnum.Free;
            transform.position = originalPosition;
        }
    }

    private void Update()
    {
        if (pieceStatesEnum == PieceStatesEnum.Following)
        {
            Vector3 worldPosition = new Vector3(_camera.ScreenToWorldPoint(Input.mousePosition).x, _camera.ScreenToWorldPoint(Input.mousePosition).y, 0f);
            transform.position = worldPosition;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Rotate(new Vector3(0, 0, 90));
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Rotate(new Vector3(0, 0, -90));
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }


}