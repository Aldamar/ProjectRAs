﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CargarImgs : MonoBehaviour {
	//Emmanuel
	public Image objetoImagen;
	public int indice=1;
	public Scrollbar barra;
	public int i = 0;
	public Canvas area;
	public GameObject panelS;
	public RectTransform rectPanel;
	public GameObject ImagenS;
	public RectTransform rectImagen;
	//Emmanuel
	//Alex
	public Image fondo;
	public Image thumb;
	public Texture2D[] thumbs;
	public Image panel;
	
	//Alex
	
	// Use this for initialization
	void Start() {
		thumbs = Resources.LoadAll<Texture2D>("Face2");
		
		Rect rec = new Rect (0, 0, thumbs [0].width, thumbs [0].height);
		Vector2 vec = new Vector2 (0.5f, 0.5f);
		thumb.sprite = Sprite.Create (thumbs [0], rec, vec);
		objetoImagen.sprite = Sprite.Create (thumbs [0], rec, vec);
		
		//Alex
		Image[] images = new Image[thumbs.Length];
		for (int x=1; x<thumbs.Length; x++) {
			//Emmanuel
			rectPanel = panelS.GetComponent<RectTransform> ();
			rectPanel.sizeDelta = new Vector2 (rectPanel.sizeDelta.x+84, rectPanel.sizeDelta.y);
			//Emmanuel
			images[x] = Instantiate(thumb);
			rec = new Rect (0, 0, thumbs [x].width, thumbs [x].height);
			images[x].sprite = Sprite.Create (thumbs [x], rec, vec);
			images[x].transform.position = new Vector2 (thumb.transform.position.x + (66*x), thumb.transform.position.y);
			images[x].transform.SetParent(panel.transform);
			//agregar
			images[x].GetComponent<CambiaImgClick>().ind=x;
		}
	}
	//Alex
	
	// Update is called once per frame
	public void Avanza () {
		if (indice < thumbs.Length-1) {
			fondo.transform.position = new Vector2 (fondo.transform.position.x + 66, fondo.transform.position.y);
			indice++;
		} 
		
		if (indice < thumbs.Length) {
			Rect rec = new Rect (0, 0, thumbs [indice].width, thumbs [indice].height);
			Vector2 vec = new Vector2 (0.5f, 0.5f);
			objetoImagen.sprite = Sprite.Create (thumbs [indice], rec, vec);
		}
		if (indice == thumbs.Length-1) {
			area.GetComponent<CapturarText>().ActivarTexto();
		} 
		
		
		if (i == thumbs.Length / 4) {
			barra.value += 0.25f;
			i = 1;
		}
		i++;
		
		thumb.GetComponent<CambiaImgClick> ().ind = indice;
	}
	
	public void Retrocede() {
		if (indice > 0) {
			fondo.transform.position = new Vector2 (fondo.transform.position.x-66, fondo.transform.position.y);
			indice--;
		}
		if (i == thumbs.Length / 4) {
			barra.value -= 0.25f;
			i = 1;
		}
		i++;
		thumb.GetComponent<CambiaImgClick> ().ind = indice;
		Rect rec = new Rect (0, 0, thumbs [indice].width, thumbs [indice].height);
		Vector2 vec = new Vector2 (0.5f, 0.5f);
		objetoImagen.sprite = Sprite.Create (thumbs [indice], rec, vec); 
		
	}
}
