#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)

using System;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;

namespace Org.BouncyCastle.Crypto.Parameters
{
	public class RsaKeyParameters
		: AsymmetricKeyParameter
    {
        private readonly BigInteger modulus;
        private readonly BigInteger exponent;

		public RsaKeyParameters(
            bool		isPrivate,
            BigInteger	modulus,
            BigInteger	exponent)
			: base(isPrivate)
        {
			if (modulus == null)
				throw new ArgumentNullException("modulus");
			if (exponent == null)
				throw new ArgumentNullException("exponent");
			if (modulus.SignValue <= 0)
				throw new ArgumentException("Not a valid RSA modulus", "modulus");
			if (exponent.SignValue <= 0)
				throw new ArgumentException("Not a valid RSA exponent", "exponent");

			this.modulus = modulus;
			this.exponent = exponent;
        }

		public BigInteger Modulus
        {
            get { return modulus; }
        }

		public BigInteger Exponent
        {
            get { return exponent; }
        }

		public override bool Equals(
			object obj)
        {
            RsaKeyParameters kp = obj as RsaKeyParameters;

			if (kp == null)
			{
				return false;
			}

			return kp.IsPrivate == this.IsPrivate
				&& kp.Modulus.Equals(this.modulus)
				&& kp.Exponent.Equals(this.exponent);
        }

		public override int GetHashCode()
        {
            return modulus.GetHashCode() ^ exponent.GetHashCode() ^ IsPrivate.GetHashCode();
        }
    }
}

#endif
