using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class Token
	{

        #region type

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

        private static readonly TxtLanguage txtGeneral = new TxtLanguage("General");
        private static readonly TxtLanguage txtAdvisor = new TxtLanguage("Advisor");
        private static readonly TxtLanguage txtElephant = new TxtLanguage("Elephant");
        private static readonly TxtLanguage txtChariot = new TxtLanguage("Chariot");
        private static readonly TxtLanguage txtHorse = new TxtLanguage("Horse");
        private static readonly TxtLanguage txtCannon = new TxtLanguage("Cannon");
        private static readonly TxtLanguage txtSoldier = new TxtLanguage("Soldier");

        public static List<string> GetTxtType()
        {
            List<string> ret = new List<string>();
            {
                ret.Add(txtGeneral.get());
                ret.Add(txtAdvisor.get());
                ret.Add(txtElephant.get());
                ret.Add(txtChariot.get());
                ret.Add(txtHorse.get());
                ret.Add(txtCannon.get());
                ret.Add(txtSoldier.get());
            }
            return ret;
        }

        #endregion

        #region color

        public enum Ecolor
		{
			RED, 
			BLACK,
			None
		}

        private static readonly TxtLanguage txtRed = new TxtLanguage("Red");
        private static readonly TxtLanguage txtBlack = new TxtLanguage("Black");
        private static readonly TxtLanguage txtNone = new TxtLanguage("None");

        public static List<string> GetTxtColor()
        {
            List<string> ret = new List<string>();
            {
                ret.Add(txtRed.get());
                ret.Add(txtBlack.get());
                ret.Add(txtNone.get());
            }
            return ret;
        }

        #endregion

        #region static

        static Token()
        {
            // type
            {
                txtGeneral.add(Language.Type.vi, "Tướng");
                txtAdvisor.add(Language.Type.vi, "Sĩ");
                txtElephant.add(Language.Type.vi, "Tượng");
                txtChariot.add(Language.Type.vi, "Xe");
                txtHorse.add(Language.Type.vi, "Mã");
                txtCannon.add(Language.Type.vi, "Pháo");
                txtSoldier.add(Language.Type.vi, "Tốt");
            }
            // color
            {
                txtRed.add(Language.Type.vi, "Đỏ");
                txtBlack.add(Language.Type.vi, "Đen");
                txtNone.add(Language.Type.vi, "Trống");
            }
        }

        #endregion

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