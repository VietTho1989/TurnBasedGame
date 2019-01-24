using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace GameUtils
{
	public class Utils 
	{
		#region Byte array
		
		public static string FormatBytes(byte[] bytes)
		{
			string value = "";
			foreach (var byt in bytes) {
				// value += string.Format ("{0:X2} ", byt);
				value+=byt+" ";
			}

			return value;
		}

		public static bool CompareTwoArrays(byte[] array1, byte[] array2)
		{
			if (array1.Length != array2.Length) return false;
			return !array1.Where((t, i) => t != array2[i]).Any();
		}

		#endregion

		public static string trimString(string source){
			string result = Regex.Replace (source, @"^\s*$[\r\n]*", string.Empty, RegexOptions.Multiline);
			return result;
		}

		public static string getListInt(int[,] list){
			if (list == null) {
				return "null";
			}
			StringBuilder builder = new StringBuilder ();
			builder.Append ("List: " + list.Length + ": [");
			for (int x = 0; x < list.GetLength(0); x++) {
				for (int y = 0; y < list.GetLength (1); y++) {
					builder.Append (" " + list [x, y]);
				}
				builder.AppendLine ();
			}
			builder.Append ("]");
			return builder.ToString ();
		}

		public static string getListInt(int[] list){
			if (list == null) {
				return "null";
			}
			StringBuilder builder = new StringBuilder ();
			builder.Append ("List: " + list.Length + ": [");
			for (int i = 0; i < list.Length; i++) {
				builder.Append ("" + list [i] + "");
				if (i != list.Length - 1) {
					builder.Append (", ");
				}
			}
			builder.Append ("]");
			return builder.ToString ();
		}

		public static string getListString(string[] list){
			if (list == null) {
				return "null";
			}
			StringBuilder builder = new StringBuilder ();
			builder.Append ("List: " + list.Length + ": [");
			for (int i = 0; i < list.Length; i++) {
				builder.Append ("(" + list [i] + ")");
				if (i != list.Length - 1) {
					builder.Append (", ");
				}
			}
			builder.Append ("]");
			return builder.ToString ();
		}

		public static string getListString<T>(List<T> list){
			if (list == null) {
				return "null";
			}
			StringBuilder builder = new StringBuilder ();
			builder.Append ("List " + typeof(T) + ": " + list.Count + ": [");
			for (int i = 0; i < list.Count; i++) {
				builder.Append (list [i]);
				if (i != list.Count - 1) {
					builder.Append (", ");
				}
			}
			builder.Append ("]");
			return builder.ToString ();
		}
	}
}