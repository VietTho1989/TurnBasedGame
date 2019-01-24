using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MineSweeper
{
	public class Neb : Data
	{

		public LP<Point> interior;

		public LP<Point> fringe;

		public LP<Point> boundary;

		#region Constructor

		public enum Property
		{
			interior,
			fringe,
			boundary
		}

		public Neb() : base()
		{
			this.interior = new LP<Point> (this, (byte)Property.interior);
			this.fringe = new LP<Point> (this, (byte)Property.fringe);
			this.boundary = new LP<Point> (this, (byte)Property.boundary);
		}

		public bool isLoadFull()
		{
			bool ret = true;
			{
				// dataIdentity
				if (ret) {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is NebIdentity) {
							NebIdentity nebIdentity = dataIdentity as NebIdentity;
							if (nebIdentity.interior != this.interior.vs.Count ||
							   nebIdentity.fringe != this.fringe.vs.Count ||
							   nebIdentity.boundary != this.boundary.vs.Count) {
								Debug.LogError ("neb not load full data");
								ret = false;
							}
						} else {
							Debug.LogError ("why not nebIdentity");
						}
					}
				}
			}
			return ret;
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(Neb neb)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						// interior
						{
							writer.Write (neb.interior.vs.Count);
							for (int i = 0; i < neb.interior.vs.Count; i++) {
								writer.Write (Point.convertToBytes (neb.interior.vs [i]));
							}
						}
						// fringe
						{
							writer.Write (neb.fringe.vs.Count);
							for (int i = 0; i < neb.fringe.vs.Count; i++) {
								writer.Write (Point.convertToBytes (neb.fringe.vs [i]));
							}
						}
						// boundary
						{
							writer.Write (neb.boundary.vs.Count);
							for (int i = 0; i < neb.boundary.vs.Count; i++) {
								writer.Write (Point.convertToBytes (neb.boundary.vs [i]));
							}
						}
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Neb neb, byte[] byteArray, int start)
		{
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					{
						// interior
						neb.interior.clear ();
						int interiorCount = 0;
						{
							int size = sizeof(int);
							if (count + size <= byteArray.Length) {
								interiorCount = BitConverter.ToInt32 (byteArray, count);
								count += size;
							} else {
								Debug.LogError ("array not enough length: interiorCount: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
						}
						// parse
						{
							// get list
							List<Point> points = new List<Point> ();
							for (int i = 0; i < interiorCount; i++) {
								Point point = new Point ();
								int pointByteLength = Point.parse (point, byteArray, count);
								if (pointByteLength > 0) {
									points.Add (point);
									count += pointByteLength;
								} else {
									Debug.LogError ("cannot parse");
									break;
								}
							}
							// add to neb
							for (int i = 0; i < points.Count; i++) {
								Point point = points [i];
								{
									point.uid = neb.interior.makeId ();
								}
								neb.interior.add (point);
							}
						}
					}
					break;
				case 1:
					{
						// fringe
						neb.fringe.clear ();
						int fringeCount = 0;
						{
							int size = sizeof(int);
							if (count + size <= byteArray.Length) {
								fringeCount = BitConverter.ToInt32 (byteArray, count);
								count += size;
							} else {
								Debug.LogError ("array not enough length: fringeCount: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
						}
						// parse
						{
							// get list
							List<Point> points = new List<Point> ();
							for (int i = 0; i < fringeCount; i++) {
								Point point = new Point ();
								int pointByteLength = Point.parse (point, byteArray, count);
								if (pointByteLength > 0) {
									points.Add (point);
									count += pointByteLength;
								} else {
									Debug.LogError ("cannot parse");
									break;
								}
							}
							// add to neb
							for (int i = 0; i < points.Count; i++) {
								Point point = points [i];
								{
									point.uid = neb.fringe.makeId ();
								}
								neb.fringe.add (point);
							}
						}
					}
					break;
				case 2:
					{
						// boundary
						neb.boundary.clear ();
						int boundaryCount = 0;
						{
							int size = sizeof(int);
							if (count + size <= byteArray.Length) {
								boundaryCount = BitConverter.ToInt32 (byteArray, count);
								count += size;
							} else {
								Debug.LogError ("array not enough length: boundaryCount: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
						}
						// parse
						{
							// get list
							List<Point> points = new List<Point> ();
							for (int i = 0; i < boundaryCount; i++) {
								Point point = new Point ();
								int pointByteLength = Point.parse (point, byteArray, count);
								if (pointByteLength > 0) {
									points.Add (point);
									count += pointByteLength;
								} else {
									Debug.LogError ("cannot parse");
									break;
								}
							}
							// add to neb
							for (int i = 0; i < points.Count; i++) {
								Point point = points [i];
								{
									point.uid = neb.boundary.makeId ();
								}
								neb.boundary.add (point);
							}
						}
					}
					break;
				default:
					// Debug.LogError ("unknown index: " + index);
					alreadyPassAll = true;
					break;
				}
				index++;
				if (!isParseCorrect) {
					Debug.LogError ("not parse correct");
					break;
				}
				if (alreadyPassAll) {
					break;
				}
			}
			// return
			if (!isParseCorrect) {
				Debug.LogError ("parse fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.LogError ("parse success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

	}
}