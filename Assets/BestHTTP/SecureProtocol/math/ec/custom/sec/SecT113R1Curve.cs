#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)

using System;

using Org.BouncyCastle.Utilities.Encoders;

namespace Org.BouncyCastle.Math.EC.Custom.Sec
{
    internal class SecT113R1Curve
        : AbstractF2mCurve
    {
        private const int SecT113R1_DEFAULT_COORDS = COORD_LAMBDA_PROJECTIVE;

        protected readonly SecT113R1Point m_infinity;

        public SecT113R1Curve()
            : base(113, 9, 0, 0)
        {
            this.m_infinity = new SecT113R1Point(this, null, null);

            this.m_a = FromBigInteger(new BigInteger(1, Hex.Decode("003088250CA6E7C7FE649CE85820F7")));
            this.m_b = FromBigInteger(new BigInteger(1, Hex.Decode("00E8BEE4D3E2260744188BE0E9C723")));
            this.m_order = new BigInteger(1, Hex.Decode("0100000000000000D9CCEC8A39E56F"));
            this.m_cofactor = BigInteger.Two;

            this.m_coord = SecT113R1_DEFAULT_COORDS;
        }

        protected override ECCurve CloneCurve()
        {
            return new SecT113R1Curve();
        }

        public override bool SupportsCoordinateSystem(int coord)
        {
            switch (coord)
            {
            case COORD_LAMBDA_PROJECTIVE:
                return true;
            default:
                return false;
            }
        }

        public override ECPoint Infinity
        {
            get { return m_infinity; }
        }

        public override int FieldSize
        {
            get { return 113; }
        }

        public override ECFieldElement FromBigInteger(BigInteger x)
        {
            return new SecT113FieldElement(x);
        }

        protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y, bool withCompression)
        {
            return new SecT113R1Point(this, x, y, withCompression);
        }

        protected internal override ECPoint CreateRawPoint(ECFieldElement x, ECFieldElement y, ECFieldElement[] zs, bool withCompression)
        {
            return new SecT113R1Point(this, x, y, zs, withCompression);
        }

       public override bool IsKoblitz
        {
            get { return false; }
        }

        /**
         * Decompresses a compressed point P = (xp, yp) (X9.62 s 4.2.2).
         * 
         * @param yTilde
         *            ~yp, an indication bit for the decompression of yp.
         * @param X1
         *            The field element xp.
         * @return the decompressed point.
         */
        protected override ECPoint DecompressPoint(int yTilde, BigInteger X1)
        {
            ECFieldElement x = FromBigInteger(X1), y = null;
            if (x.IsZero)
            {
                y = B.Sqrt();
            }
            else
            {
                ECFieldElement beta = x.Square().Invert().Multiply(B).Add(A).Add(x);
                ECFieldElement z = SolveQuadraticEquation(beta);
                if (z != null)
                {
                    if (z.TestBitZero() != (yTilde == 1))
                    {
                        z = z.AddOne();
                    }

                    switch (this.CoordinateSystem)
                    {
                    case COORD_LAMBDA_AFFINE:
                    case COORD_LAMBDA_PROJECTIVE:
                    {
                        y = z.Add(x);
                        break;
                    }
                    default:
                    {
                        y = z.Multiply(x);
                        break;
                    }
                    }
                }
            }

            if (y == null)
                throw new ArgumentException("Invalid point compression");

            return this.CreateRawPoint(x, y, true);
        }

        /**
         * Solves a quadratic equation <code>z<sup>2</sup> + z = beta</code>(X9.62
         * D.1.6) The other solution is <code>z + 1</code>.
         * 
         * @param beta
         *            The value to solve the quadratic equation for.
         * @return the solution for <code>z<sup>2</sup> + z = beta</code> or
         *         <code>null</code> if no solution exists.
         */
        private ECFieldElement SolveQuadraticEquation(ECFieldElement beta)
        {
            if (beta.IsZero)
                return beta;

            ECFieldElement zeroElement = FromBigInteger(BigInteger.Zero);

            ECFieldElement z = null;
            ECFieldElement gamma = null;

            Random rand = new Random();
            do
            {
                ECFieldElement t = FromBigInteger(new BigInteger(113, rand));
                z = zeroElement;
                ECFieldElement w = beta;
                for (int i = 1; i < 113; i++)
                {
                    ECFieldElement w2 = w.Square();
                    z = z.Square().Add(w2.Multiply(t));
                    w = w2.Add(beta);
                }
                if (!w.IsZero)
                    return null;
                gamma = z.Square().Add(z);
            }
            while (gamma.IsZero);

            return z;
        }

        public virtual int M
        {
            get { return 113; }
        }

        public virtual bool IsTrinomial
        {
            get { return true; }
        }

        public virtual int K1
        {
            get { return 9; }
        }

        public virtual int K2
        {
            get { return 0; }
        }

        public virtual int K3
        {
            get { return 0; }
        }
    }
}

#endif
