#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)

using System;

namespace Org.BouncyCastle.Crypto.Tls
{
    public abstract class NameType
    {
        /*
         * RFC 3546 3.1.
         */
        public const byte host_name = 0;
    }
}

#endif
