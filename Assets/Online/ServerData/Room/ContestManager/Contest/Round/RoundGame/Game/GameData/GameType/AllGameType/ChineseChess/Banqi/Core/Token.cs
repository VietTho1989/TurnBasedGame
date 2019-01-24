using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class Token
	{

		public enum Type 
		{
			GENERAL, 
			ADVISOR, 
			ELEPHANT,
			CHARIOT, 
			HORSE, 
			CANNON, 
			SOLDIER
		}

		public enum Ecolor
		{
			RED, 
			BLACK,
			None
		}

		public enum Status 
		{
			ACTIVE, 
			INACTIVE
		}

		private Type type;
		private Ecolor color;
		private Status status;
		public bool isFaceUp;

		public Token(Type _type, Ecolor _color) {
			type = _type;
			color = _color;
			status = Status.ACTIVE;
			isFaceUp = false;
		}

		public Type getType() {
			return type;

		}

		public Ecolor getColor() {
			return color;
		}

		public Status getStatus() {
			return status;
		}

		public void setStatus(Status _status) {
			status = _status;
		}

		public void flipToken() {
			isFaceUp = !isFaceUp;
		}

		public string abbreviate() {
			string temp = "";

			if(color == Ecolor.RED) {
				temp += "R";
			}else if(color == Ecolor.BLACK) {
				temp += "B";
			}

			switch (type) {
			case Type.GENERAL:
				temp += "7";
				break;
			case Type.ADVISOR:
				temp += "6";
				break;
			case Type.ELEPHANT:
				temp += "5";
				break;
			case Type.CHARIOT:
				temp += "4";
				break;
			case Type.HORSE:
				temp += "3";
				break;
			case Type.CANNON:
				temp += "2";
				break;
			case Type.SOLDIER:
				temp += "1";
				break;
			default:
				Debug.LogError ("Doesn't have a type");
				break;
			}

			return temp;
		}

		public int value() {
			switch (type) {
			case Type.GENERAL:
				return 7;
			case Type.ADVISOR:
				return 6;
			case Type.ELEPHANT:
				return 5;
			case Type.CHARIOT:
				return 4;
			case Type.HORSE:
				return 3;
			case Type.CANNON:
				return 2;
			case Type.SOLDIER:
				return 1;
			default:
				Debug.LogError ("Doesn't have a type");
				return -1;
			}
		}

		public void printToken() {
			Debug.LogError ("Type: " + type + "\n" + "Color: " + color);
		}

		public void printTokenAdvanced() {
			Debug.LogError ("Type: " + type + "\nColor: " + color + "\nStatus: " + status + "\nisFaceUp: " + isFaceUp);
		}

	}
}