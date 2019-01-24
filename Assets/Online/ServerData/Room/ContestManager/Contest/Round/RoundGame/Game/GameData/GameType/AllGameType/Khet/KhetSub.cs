using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class KhetSub : Data
	{

		public const int MaxCount = 30;

		/** uint64_t _hashes[MaxGameLength]*/
		public LP<ulong> _hashes;

		// Move list.
		/** Move _moves[MaxGameLength] = { NoMove }*/
		public LP<uint> _moves;

		// Cache the capture square and location so that it can be restored.
		/** Square _captureSquare[MaxGameLength]*/
		public LP<byte> _captureSquare;

		/** int32_t _captureLocation[MaxGameLength]*/
		public LP<int> _captureLocation;

		// Cache the number of moves since the last capture.
		/** int32_t _movesWithoutCapture[MaxGameLength]*/
		public LP<int> _movesWithoutCapture;

		#region Constructor

		public enum Property
		{
			_hashes,
			_moves,
			_captureSquare,
			_captureLocation,
			_movesWithoutCapture
		}

		public KhetSub() : base()
		{
			this._hashes = new LP<ulong> (this, (byte)Property._hashes);
			this._moves = new LP<uint> (this, (byte)Property._moves);
			this._captureSquare = new LP<byte> (this, (byte)Property._captureSquare);
			this._captureLocation = new LP<int> (this, (byte)Property._captureLocation);
			this._movesWithoutCapture = new LP<int> (this, (byte)Property._movesWithoutCapture);
		}

		#endregion


	}
}