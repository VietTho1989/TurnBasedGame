//
//  ListItemLabel.cs
//
//  Author:
//       Tomaz Saraiva <tomaz.saraiva@gmail.com>
//
//  Copyright (c) 2017 Tomaz Saraiva
using UnityEngine;
using System.Collections;
using AddComponent;
using UnityEngine.UI;

public class ListItemCountry : ListItemBase
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private Text _label;

	[SerializeField]
	private Text _labelCode;


	private Sprite _sprite;


	public void SetLabel(string text)
	{
		_label.text = text;
	}

	public void SetCode(string text)
	{
		_labelCode.text = text;

		if(_sprite != null)
		{
			Resources.UnloadAsset (_sprite.texture);
		}

		_sprite = Resources.Load<Sprite> ("flags/" + text.ToLower ());

		_image.sprite = _sprite;
	}

	public void Select(bool selected)
	{
		_label.color = selected ? Color.green : Color.black;
	}
}