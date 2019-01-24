using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class KhetSpriteContainer : MonoBehaviour
	{

		#region instance

		private static KhetSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static KhetSpriteContainer get()
		{
			return instance;
		}

		#endregion

		public Sprite NoPiece;

		#region piece sprite

		public Sprite silverAnubis0;
		public Sprite silverAnubis90;
		public Sprite silverAnubis180;
		public Sprite silverAnubis270;

		public Sprite silverPyramid0;
		public Sprite silverPyramid90;
		public Sprite silverPyramid180;
		public Sprite silverPyramid270;

		public Sprite silverScarab0;
		public Sprite silverScarab90;
		public Sprite silverScarab180;
		public Sprite silverScarab270;

		public Sprite silverPharaoh0;
		public Sprite silverPharaoh90;
		public Sprite silverPharaoh180;
		public Sprite silverPharaoh270;

		public Sprite silverSphinx0;
		public Sprite silverSphinx90;
		public Sprite silverSphinx180;
		public Sprite silverSphinx270;

		public Sprite redAnubis0;
		public Sprite redAnubis90;
		public Sprite redAnubis180;
		public Sprite redAnubis270;

		public Sprite redPyramid0;
		public Sprite redPyramid90;
		public Sprite redPyramid180;
		public Sprite redPyramid270;

		public Sprite redScarab0;
		public Sprite redScarab90;
		public Sprite redScarab180;
		public Sprite redScarab270;

		public Sprite redPharaoh0;
		public Sprite redPharaoh90;
		public Sprite redPharaoh180;
		public Sprite redPharaoh270;

		public Sprite redSphinx0;
		public Sprite redSphinx90;
		public Sprite redSphinx180;
		public Sprite redSphinx270;

		#endregion

		public Sprite GetSprite(Common.Player owner, Common.Piece piece, Common.Orientation orientation)
		{
			switch (owner) {
			case Common.Player.Silver:
				{
					switch (piece) {
					case Common.Piece.None:
						return NoPiece;
					case Common.Piece.Anubis:
						{
							switch (orientation) {
							case Common.Orientation.Up:
								return silverAnubis0;
							case Common.Orientation.Right:
								return silverAnubis90;
							case Common.Orientation.Down:
								return silverAnubis180;
							case Common.Orientation.Left:
								return silverAnubis270;
							default:
								Debug.LogError ("unknown orientation: " + orientation);
								return NoPiece;
							}
						}
					case Common.Piece.Pyramid:
						{
							switch (orientation) {
							case Common.Orientation.Up:
								return silverPyramid0;
							case Common.Orientation.Right:
								return silverPyramid90;
							case Common.Orientation.Down:
								return silverPyramid180;
							case Common.Orientation.Left:
								return silverPyramid270;
							default:
								Debug.LogError ("unknown orientation: " + orientation);
								return NoPiece;
							}
						}
					case Common.Piece.Scarab:
						{
							switch (orientation) {
							case Common.Orientation.Up:
								return silverScarab0;
							case Common.Orientation.Right:
								return silverScarab90;
							case Common.Orientation.Down:
								return silverScarab180;
							case Common.Orientation.Left:
								return silverScarab270;
							default:
								Debug.LogError ("unknown orientation: " + orientation);
								return NoPiece;
							}
						}
					case Common.Piece.Pharaoh:
						{
							switch (orientation) {
							case Common.Orientation.Up:
								return silverPharaoh0;
							case Common.Orientation.Right:
								return silverPharaoh90;
							case Common.Orientation.Down:
								return silverPharaoh180;
							case Common.Orientation.Left:
								return silverPharaoh270;
							default:
								Debug.LogError ("unknown orientation: " + orientation);
								return NoPiece;
							}
						}
					case Common.Piece.Sphinx:
						{
							switch (orientation) {
							case Common.Orientation.Up:
								return silverSphinx0;
							case Common.Orientation.Right:
								return silverSphinx90;
							case Common.Orientation.Down:
								return silverSphinx180;
							case Common.Orientation.Left:
								return silverSphinx270;
							default:
								Debug.LogError ("unknown orientation: " + orientation);
								return NoPiece;
							}
						}
					default:
						Debug.LogError ("piece: " + piece);
						return NoPiece;
					}
				}
			case Common.Player.Red:
				{
					switch (piece) {
					case Common.Piece.None:
						return NoPiece;
					case Common.Piece.Anubis:
						{
							switch (orientation) {
							case Common.Orientation.Up:
								return redAnubis0;
							case Common.Orientation.Right:
								return redAnubis90;
							case Common.Orientation.Down:
								return redAnubis180;
							case Common.Orientation.Left:
								return redAnubis270;
							default:
								Debug.LogError ("unknown orientation: " + orientation);
								return NoPiece;
							}
						}
					case Common.Piece.Pyramid:
						{
							switch (orientation) {
							case Common.Orientation.Up:
								return redPyramid0;
							case Common.Orientation.Right:
								return redPyramid90;
							case Common.Orientation.Down:
								return redPyramid180;
							case Common.Orientation.Left:
								return redPyramid270;
							default:
								Debug.LogError ("unknown orientation: " + orientation);
								return NoPiece;
							}
						}
					case Common.Piece.Scarab:
						{
							switch (orientation) {
							case Common.Orientation.Up:
								return redScarab0;
							case Common.Orientation.Right:
								return redScarab90;
							case Common.Orientation.Down:
								return redScarab180;
							case Common.Orientation.Left:
								return redScarab270;
							default:
								Debug.LogError ("unknown orientation: " + orientation);
								return NoPiece;
							}
						}
					case Common.Piece.Pharaoh:
						{
							switch (orientation) {
							case Common.Orientation.Up:
								return redPharaoh0;
							case Common.Orientation.Right:
								return redPharaoh90;
							case Common.Orientation.Down:
								return redPharaoh180;
							case Common.Orientation.Left:
								return redPharaoh270;
							default:
								Debug.LogError ("unknown orientation: " + orientation);
								return NoPiece;
							}
						}
					case Common.Piece.Sphinx:
						{
							switch (orientation) {
							case Common.Orientation.Up:
								return redSphinx0;
							case Common.Orientation.Right:
								return redSphinx90;
							case Common.Orientation.Down:
								return redSphinx180;
							case Common.Orientation.Left:
								return redSphinx270;
							default:
								Debug.LogError ("unknown orientation: " + orientation);
								return NoPiece;
							}
						}
					default:
						Debug.LogError ("piece: " + piece);
						return NoPiece;
					}
				}
			default:
				Debug.LogError ("unknown owner: " + owner);
				return NoPiece;
			}
		}

	}
}