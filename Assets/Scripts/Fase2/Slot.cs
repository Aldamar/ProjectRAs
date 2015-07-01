﻿using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;

using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler {
	public Image lienzo;
	public Image panel;
	
	#region IDropHandler implementation
	
	public void OnDrop (PointerEventData eventData)
	{
		if (DragHandeler.itemBeingDragged == null) {
		}
		else
		if (DragHandeler.startParent != panel.transform) {
			DragHandeler.itemBeingDragged.transform.SetParent (transform);
			DragHandeler.itemBeingDragged.transform.position = Input.mousePosition;
		} else {
			GameObject tmp = Instantiate(DragHandeler.itemBeingDragged);
			tmp.transform.position = DragHandeler.startPosition;
			tmp.transform.SetParent(DragHandeler.startParent);
			tmp.transform.GetComponent<CanvasGroup>().blocksRaycasts = true;

			DragHandeler.itemBeingDragged.transform.SetParent (transform);
			DragHandeler.itemBeingDragged.transform.position = Input.mousePosition;
		}
	}
	
	#endregion
}