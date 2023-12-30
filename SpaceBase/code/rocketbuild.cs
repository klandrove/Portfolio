using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.UI;


public class rocketbuild : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 initialPosition;
    public GameObject CorrectPieces;
    public GameObject[] correctpos;
    public int totalcorrectpos = 0;

    public bool correct = false;
    
    
    private void Start()
    {   
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initialPosition = rectTransform.anchoredPosition;
        totalcorrectpos = CorrectPieces.transform.childCount;
        correctpos = new GameObject[totalcorrectpos];
        for (int i = 0; i < correctpos.Length; i++){
            correctpos[i] = CorrectPieces.transform.GetChild(i).gameObject;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Implement any logic for when the puzzle piece is clicked.
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!correct){
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!correct){
            canvasGroup.blocksRaycasts = true;
        }
        SnapToGrid();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!correct){
            rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
        }
    }

    private void SnapToGrid()
    {
        Vector2 correctPosition = correctpos[int.Parse(gameObject.name)].GetComponent<RectTransform>().anchoredPosition;
        Vector2 currentPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;


        if(Math.Abs(currentPosition.x - correctPosition.x) <= 40 && Math.Abs(currentPosition.y - correctPosition.y) <= 40 ){
            Image imageComponent = gameObject.GetComponent<Image>();
            Color32 clear = new Color32(0,0,0,0);
            correctpos[int.Parse(gameObject.name)].SetActive(true);
            imageComponent.color = clear;
            correct = true;
        }
    }
    public bool getIsCorrect(){
        return correct;
    }
}
