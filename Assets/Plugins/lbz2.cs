using System;
using System.Runtime.InteropServices;
using UnityEngine;

#if NETFX_CORE
    #if UNITY_WSA_10_0
        using System.IO.IsolatedStorage;
        using static System.IO.Directory;
        using static System.IO.File;
        using static System.IO.FileStream;
    #endif
#endif

public class lbz2 {

#if (!UNITY_WEBPLAYER && ! UNITY_WEBGL) || UNITY_EDITOR

    internal static byte[] bsiz = new byte[4];

#if (UNITY_IPHONE || UNITY_IOS) && !UNITY_EDITOR
		[DllImport("__Internal")]
		internal static extern int bz2(int mode, int levelOfCompression, string inFile,  string outFile);

        [DllImport("__Internal")]
        internal static extern void releaseBuffer(IntPtr buffer);

        [DllImport("__Internal")]
		internal static extern IntPtr bz2Buff2Buff(IntPtr source, uint sourceLen, int blockSize100k, ref int v);

        [DllImport("__Internal")]
		internal static extern int bz2DecBuff(IntPtr dest, uint destLen,IntPtr source, uint sourceLen );
#endif

#if UNITY_5_4_OR_NEWER
	#if (UNITY_ANDROID || UNITY_STANDALONE_LINUX) && !UNITY_EDITOR || UNITY_EDITOR_LINUX
		private const string libname = "bz2w";
	#elif UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_WP8_1 || UNITY_WSA || UNITY_METRO
		private const string libname = "libbz2w";
	#endif
#else
	#if (UNITY_ANDROID || UNITY_STANDALONE_LINUX) && !UNITY_EDITOR
		private const string libname = "bz2w";
	#endif
	#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_WP8_1 || UNITY_WSA || UNITY_METRO
		private const string libname = "libbz2w";
	#endif
#endif

#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_WP8_1 || UNITY_WSA || UNITY_METRO || UNITY_ANDROID
		[DllImport(libname, EntryPoint = "bz2"
		#if UNITY_WSA
		, CallingConvention = CallingConvention.Cdecl
		#endif	
		)]
		internal static extern int bz2(int mode, int levelOfCompression, string inFile,  string outFile);

        [DllImport(libname, EntryPoint = "releaseBuffer"
		#if UNITY_WSA
		, CallingConvention = CallingConvention.Cdecl
		#endif	
		)]
        internal static extern void releaseBuffer(IntPtr buffer);

        [DllImport(libname, EntryPoint = "bz2Buff2Buff"
		#if UNITY_WSA
		, CallingConvention = CallingConvention.Cdecl
		#endif	
		)]
		internal static extern IntPtr bz2Buff2Buff(IntPtr source, uint sourceLen, int blockSize100k, ref int v);

        [DllImport(libname, EntryPoint = "bz2DecBuff"
		#if UNITY_WSA
		, CallingConvention = CallingConvention.Cdecl
		#endif	
		)]
		internal static extern int bz2DecBuff(IntPtr dest, uint destLen,IntPtr source, uint sourceLen );
#endif




    //ERROR CODES:
    //	 1 : OK
    //	-1 : Can't write destination file
    // 	-2 : Can't bz2openstream (decompressing)
    //	-3 : Can't read source file
    //	-4 : Can't bz2openstream (compressing)

    //example usage
    //int lz=lbz2.decompressBz2(Application.persistentDataPath+"/myFile.txt.bz2",Application.persistentDataPath+"/myUncompressedFiles/myFile.txt");

    //inFile	: the full path to the compressed file, including the archives name.
    //outFile	: the full path of the file to get decompressed.

    public static int decompressBz2(string inFile, string outFile)
    {
        return bz2(1, 0, inFile, outFile);
    }


    //example usage
    //int lz=lbz2.compressBz2(Application.persistentDataPath+"/myFile.txt",Application.persistentDataPath+"/myUncompressedFiles/myFile.txt.bz2");

    //inFile				: the full path to the archive to get compressed.
    //outFile				: the full path of the resulting compressed file.
    //levelOfCompression	: The compression level (lower = 1 to higher = 9); 

    public static int compressBz2(string inFile, string outFile, int levelOfCompression)
    {
        if (levelOfCompression > 9) levelOfCompression = 9;
        if (levelOfCompression < 1) levelOfCompression = 1;

        return bz2(0, levelOfCompression, inFile, outFile);
    } 




    //A function that compresses a byte buffer in a bz2 stream and writes it into the referenced byte buffer.
    //returns true or false.
    //This function is preferred over the implementation that returns a new compressed byte buffer because
    //of lower memory consumption until the gc.collect kicks in.
	//
	//includeSize: set this to true if you want the function to add a footer to the resulted compressed buffer with the uncompressed size info. (recommended)
	//
    public static bool bz2CompressBuffer(byte[] source,  ref byte[] outBuffer, int compressionLevel, bool includeSize = true)
    {
        GCHandle sbuf = GCHandle.Alloc(source, GCHandleType.Pinned);
        IntPtr ptr;

        int siz = 0, hsiz = 0;

        //if the uncompressed size of the buffer should be included. This is a hack since bz2 lib does not support this.
        if (includeSize)
        {
            hsiz = 4;
            bsiz = BitConverter.GetBytes(source.Length);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bsiz);
        }

        ptr = bz2Buff2Buff(sbuf.AddrOfPinnedObject(), (uint)source.Length, compressionLevel, ref siz);

        if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return false; }

        System.Array.Resize(ref outBuffer, siz + hsiz);

        //add the uncompressed size to the buffer
        if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }

        Marshal.Copy(ptr, outBuffer, 0, siz);

        sbuf.Free();
        releaseBuffer(ptr);

        return true;

    }

    //A function that compresses a byte buffer in a bz2 stream and returns the resulting buffer.
    //If something goes wrong the returned buffer will be null.
    //Prefer the previous implementation.
	//
	//includeSize: set this to true if you want the function to add a footer to the resulted compressed buffer with the uncompressed size info. (recommended)
	//
    public static byte[] bz2CompressBuffer(byte[] source, int compressionLevel, bool includeSize = true)
    {
        GCHandle sbuf = GCHandle.Alloc(source, GCHandleType.Pinned);
        IntPtr ptr;

        int siz = 0, hsiz = 0;

        //if the uncompressed size of the buffer should be included. This is a hack since bz2 lib does not support this.
        if (includeSize)
        {
            hsiz = 4;
            bsiz = BitConverter.GetBytes(source.Length);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bsiz);
        }


        ptr = bz2Buff2Buff(sbuf.AddrOfPinnedObject(), (uint)source.Length, compressionLevel, ref siz);

        if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return null; }

        byte[] outBuffer = new byte[siz + hsiz];

        //add the uncompressed size to the buffer
        if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }

        Marshal.Copy(ptr, outBuffer, 0, siz);

        sbuf.Free();
        releaseBuffer(ptr);

        return outBuffer;
    }

    //ERROR CODE
    //  0 : OK
    // -9 : outbuffer full
    //
    //A function that decompresses a bz2 compressed byte buffer (or a bz2 file that was read into a byte buffer)
    //into a referenced buffer. Returns 0 for ok.
	//
    //useFooter: 	the buffer has size information. Use it.
	//customLength:	use a custom length for the decompression.
	//
    //Prefer this function over the next implementation.
    public static int bz2DecompressBuffer(byte[] inBuffer, ref byte[] outBuffer, bool useFooter = true, int customLength = 0)
    {

        int uncompressedSize = 0;

        //if the hacked in bz2 header will be used to extract the uncompressed size of the buffer. If the buffer does not have a header 
        //provide the known uncompressed size through the customLength integer.
        if (useFooter) uncompressedSize = (int)BitConverter.ToInt32(inBuffer, inBuffer.Length - 4); else uncompressedSize = customLength;

        GCHandle cbuf = GCHandle.Alloc(inBuffer, GCHandleType.Pinned);
        System.Array.Resize(ref outBuffer, uncompressedSize);
        GCHandle obuf = GCHandle.Alloc(outBuffer, GCHandleType.Pinned);

        int res = bz2DecBuff(obuf.AddrOfPinnedObject(), (uint)uncompressedSize, cbuf.AddrOfPinnedObject(), (uint)inBuffer.Length);

        cbuf.Free();
        obuf.Free();

        if (res != 0) { Debug.Log("ERROR: " + res.ToString()); }

        return res;
    }

    //A function that decompresses a bz2 compressed byte buffer (or a bz2 file that was read into a byte buffer)
    //and returns a new byte buffer with the uncompressed data.
	//
    //useFooter: 	the buffer has size information. Use it.
	//customLength:	use a custom length for the decompression.
	//
    //Prefer the previous implementation.
    public static byte[] bz2DecompressBuffer(byte[] inBuffer, bool useFooter = true, int customLength = 0){

        int uncompressedSize = 0;

        //if the hacked in bz2 header will be used to extract the uncompressed size of the buffer. If the buffer does not have a header 
        //provide the known uncompressed size through the customLength integer.
        if (useFooter) uncompressedSize = (int)BitConverter.ToInt32(inBuffer, inBuffer.Length - 4); else uncompressedSize = customLength;

        GCHandle cbuf = GCHandle.Alloc(inBuffer, GCHandleType.Pinned);
        byte[] outbuffer = new byte[uncompressedSize];
        GCHandle obuf = GCHandle.Alloc(outbuffer, GCHandleType.Pinned);

		int res = bz2DecBuff(obuf.AddrOfPinnedObject(), (uint)uncompressedSize, cbuf.AddrOfPinnedObject(), (uint)inBuffer.Length);

        cbuf.Free();
        obuf.Free();

        if (res != 0) { Debug.Log("ERROR: " + res.ToString()); }

        return outbuffer;
    }

#endif	
}
