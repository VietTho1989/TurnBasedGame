#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Tls.TlsProtocol
struct TlsProtocol_t2348540693;
// System.IO.Stream
struct Stream_t3255436806;
// Org.BouncyCastle.Crypto.Tls.TlsCompression
struct TlsCompression_t3250792153;
// Org.BouncyCastle.Crypto.Tls.TlsCipher
struct TlsCipher_t927308168;
// System.IO.MemoryStream
struct MemoryStream_t743994179;
// Org.BouncyCastle.Crypto.Tls.TlsHandshakeHash
struct TlsHandshakeHash_t1728544356;
// Org.BouncyCastle.Crypto.Tls.ProtocolVersion
struct ProtocolVersion_t3273908466;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.RecordStream
struct  RecordStream_t911577901  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.Tls.TlsProtocol Org.BouncyCastle.Crypto.Tls.RecordStream::mHandler
	TlsProtocol_t2348540693 * ___mHandler_1;
	// System.IO.Stream Org.BouncyCastle.Crypto.Tls.RecordStream::mInput
	Stream_t3255436806 * ___mInput_2;
	// System.IO.Stream Org.BouncyCastle.Crypto.Tls.RecordStream::mOutput
	Stream_t3255436806 * ___mOutput_3;
	// Org.BouncyCastle.Crypto.Tls.TlsCompression Org.BouncyCastle.Crypto.Tls.RecordStream::mPendingCompression
	Il2CppObject * ___mPendingCompression_4;
	// Org.BouncyCastle.Crypto.Tls.TlsCompression Org.BouncyCastle.Crypto.Tls.RecordStream::mReadCompression
	Il2CppObject * ___mReadCompression_5;
	// Org.BouncyCastle.Crypto.Tls.TlsCompression Org.BouncyCastle.Crypto.Tls.RecordStream::mWriteCompression
	Il2CppObject * ___mWriteCompression_6;
	// Org.BouncyCastle.Crypto.Tls.TlsCipher Org.BouncyCastle.Crypto.Tls.RecordStream::mPendingCipher
	Il2CppObject * ___mPendingCipher_7;
	// Org.BouncyCastle.Crypto.Tls.TlsCipher Org.BouncyCastle.Crypto.Tls.RecordStream::mReadCipher
	Il2CppObject * ___mReadCipher_8;
	// Org.BouncyCastle.Crypto.Tls.TlsCipher Org.BouncyCastle.Crypto.Tls.RecordStream::mWriteCipher
	Il2CppObject * ___mWriteCipher_9;
	// System.Int64 Org.BouncyCastle.Crypto.Tls.RecordStream::mReadSeqNo
	int64_t ___mReadSeqNo_10;
	// System.Int64 Org.BouncyCastle.Crypto.Tls.RecordStream::mWriteSeqNo
	int64_t ___mWriteSeqNo_11;
	// System.IO.MemoryStream Org.BouncyCastle.Crypto.Tls.RecordStream::mBuffer
	MemoryStream_t743994179 * ___mBuffer_12;
	// Org.BouncyCastle.Crypto.Tls.TlsHandshakeHash Org.BouncyCastle.Crypto.Tls.RecordStream::mHandshakeHash
	Il2CppObject * ___mHandshakeHash_13;
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.RecordStream::mReadVersion
	ProtocolVersion_t3273908466 * ___mReadVersion_14;
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.RecordStream::mWriteVersion
	ProtocolVersion_t3273908466 * ___mWriteVersion_15;
	// System.Boolean Org.BouncyCastle.Crypto.Tls.RecordStream::mRestrictReadVersion
	bool ___mRestrictReadVersion_16;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.RecordStream::mPlaintextLimit
	int32_t ___mPlaintextLimit_17;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.RecordStream::mCompressedLimit
	int32_t ___mCompressedLimit_18;
	// System.Int32 Org.BouncyCastle.Crypto.Tls.RecordStream::mCiphertextLimit
	int32_t ___mCiphertextLimit_19;

public:
	inline static int32_t get_offset_of_mHandler_1() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mHandler_1)); }
	inline TlsProtocol_t2348540693 * get_mHandler_1() const { return ___mHandler_1; }
	inline TlsProtocol_t2348540693 ** get_address_of_mHandler_1() { return &___mHandler_1; }
	inline void set_mHandler_1(TlsProtocol_t2348540693 * value)
	{
		___mHandler_1 = value;
		Il2CppCodeGenWriteBarrier(&___mHandler_1, value);
	}

	inline static int32_t get_offset_of_mInput_2() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mInput_2)); }
	inline Stream_t3255436806 * get_mInput_2() const { return ___mInput_2; }
	inline Stream_t3255436806 ** get_address_of_mInput_2() { return &___mInput_2; }
	inline void set_mInput_2(Stream_t3255436806 * value)
	{
		___mInput_2 = value;
		Il2CppCodeGenWriteBarrier(&___mInput_2, value);
	}

	inline static int32_t get_offset_of_mOutput_3() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mOutput_3)); }
	inline Stream_t3255436806 * get_mOutput_3() const { return ___mOutput_3; }
	inline Stream_t3255436806 ** get_address_of_mOutput_3() { return &___mOutput_3; }
	inline void set_mOutput_3(Stream_t3255436806 * value)
	{
		___mOutput_3 = value;
		Il2CppCodeGenWriteBarrier(&___mOutput_3, value);
	}

	inline static int32_t get_offset_of_mPendingCompression_4() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mPendingCompression_4)); }
	inline Il2CppObject * get_mPendingCompression_4() const { return ___mPendingCompression_4; }
	inline Il2CppObject ** get_address_of_mPendingCompression_4() { return &___mPendingCompression_4; }
	inline void set_mPendingCompression_4(Il2CppObject * value)
	{
		___mPendingCompression_4 = value;
		Il2CppCodeGenWriteBarrier(&___mPendingCompression_4, value);
	}

	inline static int32_t get_offset_of_mReadCompression_5() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mReadCompression_5)); }
	inline Il2CppObject * get_mReadCompression_5() const { return ___mReadCompression_5; }
	inline Il2CppObject ** get_address_of_mReadCompression_5() { return &___mReadCompression_5; }
	inline void set_mReadCompression_5(Il2CppObject * value)
	{
		___mReadCompression_5 = value;
		Il2CppCodeGenWriteBarrier(&___mReadCompression_5, value);
	}

	inline static int32_t get_offset_of_mWriteCompression_6() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mWriteCompression_6)); }
	inline Il2CppObject * get_mWriteCompression_6() const { return ___mWriteCompression_6; }
	inline Il2CppObject ** get_address_of_mWriteCompression_6() { return &___mWriteCompression_6; }
	inline void set_mWriteCompression_6(Il2CppObject * value)
	{
		___mWriteCompression_6 = value;
		Il2CppCodeGenWriteBarrier(&___mWriteCompression_6, value);
	}

	inline static int32_t get_offset_of_mPendingCipher_7() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mPendingCipher_7)); }
	inline Il2CppObject * get_mPendingCipher_7() const { return ___mPendingCipher_7; }
	inline Il2CppObject ** get_address_of_mPendingCipher_7() { return &___mPendingCipher_7; }
	inline void set_mPendingCipher_7(Il2CppObject * value)
	{
		___mPendingCipher_7 = value;
		Il2CppCodeGenWriteBarrier(&___mPendingCipher_7, value);
	}

	inline static int32_t get_offset_of_mReadCipher_8() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mReadCipher_8)); }
	inline Il2CppObject * get_mReadCipher_8() const { return ___mReadCipher_8; }
	inline Il2CppObject ** get_address_of_mReadCipher_8() { return &___mReadCipher_8; }
	inline void set_mReadCipher_8(Il2CppObject * value)
	{
		___mReadCipher_8 = value;
		Il2CppCodeGenWriteBarrier(&___mReadCipher_8, value);
	}

	inline static int32_t get_offset_of_mWriteCipher_9() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mWriteCipher_9)); }
	inline Il2CppObject * get_mWriteCipher_9() const { return ___mWriteCipher_9; }
	inline Il2CppObject ** get_address_of_mWriteCipher_9() { return &___mWriteCipher_9; }
	inline void set_mWriteCipher_9(Il2CppObject * value)
	{
		___mWriteCipher_9 = value;
		Il2CppCodeGenWriteBarrier(&___mWriteCipher_9, value);
	}

	inline static int32_t get_offset_of_mReadSeqNo_10() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mReadSeqNo_10)); }
	inline int64_t get_mReadSeqNo_10() const { return ___mReadSeqNo_10; }
	inline int64_t* get_address_of_mReadSeqNo_10() { return &___mReadSeqNo_10; }
	inline void set_mReadSeqNo_10(int64_t value)
	{
		___mReadSeqNo_10 = value;
	}

	inline static int32_t get_offset_of_mWriteSeqNo_11() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mWriteSeqNo_11)); }
	inline int64_t get_mWriteSeqNo_11() const { return ___mWriteSeqNo_11; }
	inline int64_t* get_address_of_mWriteSeqNo_11() { return &___mWriteSeqNo_11; }
	inline void set_mWriteSeqNo_11(int64_t value)
	{
		___mWriteSeqNo_11 = value;
	}

	inline static int32_t get_offset_of_mBuffer_12() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mBuffer_12)); }
	inline MemoryStream_t743994179 * get_mBuffer_12() const { return ___mBuffer_12; }
	inline MemoryStream_t743994179 ** get_address_of_mBuffer_12() { return &___mBuffer_12; }
	inline void set_mBuffer_12(MemoryStream_t743994179 * value)
	{
		___mBuffer_12 = value;
		Il2CppCodeGenWriteBarrier(&___mBuffer_12, value);
	}

	inline static int32_t get_offset_of_mHandshakeHash_13() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mHandshakeHash_13)); }
	inline Il2CppObject * get_mHandshakeHash_13() const { return ___mHandshakeHash_13; }
	inline Il2CppObject ** get_address_of_mHandshakeHash_13() { return &___mHandshakeHash_13; }
	inline void set_mHandshakeHash_13(Il2CppObject * value)
	{
		___mHandshakeHash_13 = value;
		Il2CppCodeGenWriteBarrier(&___mHandshakeHash_13, value);
	}

	inline static int32_t get_offset_of_mReadVersion_14() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mReadVersion_14)); }
	inline ProtocolVersion_t3273908466 * get_mReadVersion_14() const { return ___mReadVersion_14; }
	inline ProtocolVersion_t3273908466 ** get_address_of_mReadVersion_14() { return &___mReadVersion_14; }
	inline void set_mReadVersion_14(ProtocolVersion_t3273908466 * value)
	{
		___mReadVersion_14 = value;
		Il2CppCodeGenWriteBarrier(&___mReadVersion_14, value);
	}

	inline static int32_t get_offset_of_mWriteVersion_15() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mWriteVersion_15)); }
	inline ProtocolVersion_t3273908466 * get_mWriteVersion_15() const { return ___mWriteVersion_15; }
	inline ProtocolVersion_t3273908466 ** get_address_of_mWriteVersion_15() { return &___mWriteVersion_15; }
	inline void set_mWriteVersion_15(ProtocolVersion_t3273908466 * value)
	{
		___mWriteVersion_15 = value;
		Il2CppCodeGenWriteBarrier(&___mWriteVersion_15, value);
	}

	inline static int32_t get_offset_of_mRestrictReadVersion_16() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mRestrictReadVersion_16)); }
	inline bool get_mRestrictReadVersion_16() const { return ___mRestrictReadVersion_16; }
	inline bool* get_address_of_mRestrictReadVersion_16() { return &___mRestrictReadVersion_16; }
	inline void set_mRestrictReadVersion_16(bool value)
	{
		___mRestrictReadVersion_16 = value;
	}

	inline static int32_t get_offset_of_mPlaintextLimit_17() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mPlaintextLimit_17)); }
	inline int32_t get_mPlaintextLimit_17() const { return ___mPlaintextLimit_17; }
	inline int32_t* get_address_of_mPlaintextLimit_17() { return &___mPlaintextLimit_17; }
	inline void set_mPlaintextLimit_17(int32_t value)
	{
		___mPlaintextLimit_17 = value;
	}

	inline static int32_t get_offset_of_mCompressedLimit_18() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mCompressedLimit_18)); }
	inline int32_t get_mCompressedLimit_18() const { return ___mCompressedLimit_18; }
	inline int32_t* get_address_of_mCompressedLimit_18() { return &___mCompressedLimit_18; }
	inline void set_mCompressedLimit_18(int32_t value)
	{
		___mCompressedLimit_18 = value;
	}

	inline static int32_t get_offset_of_mCiphertextLimit_19() { return static_cast<int32_t>(offsetof(RecordStream_t911577901, ___mCiphertextLimit_19)); }
	inline int32_t get_mCiphertextLimit_19() const { return ___mCiphertextLimit_19; }
	inline int32_t* get_address_of_mCiphertextLimit_19() { return &___mCiphertextLimit_19; }
	inline void set_mCiphertextLimit_19(int32_t value)
	{
		___mCiphertextLimit_19 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
