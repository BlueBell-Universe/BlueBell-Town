
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform handle;
    public RectTransform outLine;

    private float deadZone = 0;
    private float handleRange = 1;
    private Vector3 input = Vector3.zero;
    private Canvas canvas;

    public float Horizontal { get { if (input.x > 0) { return 1; } else if (input.x < 0) return -1; else return 0; } }

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        outLine = gameObject.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 radius = outLine.sizeDelta / 2;
        Vector2 clickPosition = eventData.position; // 클릭한 위치
        Vector2 centerPosition = outLine.position; // 아웃라인의 중심 위치
        Vector2 direction = clickPosition - centerPosition; // 클릭한 위치와 아웃라인 중심과의 방향 벡터
        float distance = Mathf.Min(direction.magnitude, radius.x * canvas.scaleFactor); // 클릭한 위치와 아웃라인 중심 사이의 거리를 아웃라인 반지름으로 제한
        input = direction.normalized * (distance / (radius.x * canvas.scaleFactor)); // 입력 값을 방향 벡터의 정규화 값으로 설정
        HandleInput(input.magnitude, input.normalized);
        handle.anchoredPosition = input * radius * handleRange;
    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    Vector2 radius = outLine.sizeDelta / 2;
    //    input = (eventData.position - outLine.anchoredPosition) / (radius * canvas.scaleFactor);
    //    HandleInput(input.magnitude, input.normalized);
    //    handle.anchoredPosition = input * radius * handleRange;
    //}

    private void HandleInput(float magnitude, Vector2 normalised)
    {
        if (magnitude > deadZone)
        {
            if (magnitude > 1)
            {
                input = normalised;
            }
        }
        else
        {
            input = Vector2.zero;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;

    }
}