#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.IDigest
struct IDigest_t1344033143;
// Org.BouncyCastle.Utilities.IMemoable
struct IMemoable_t4132004587;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Macs.HMac
struct  HMac_t2564819335  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Crypto.IDigest Org.BouncyCastle.Crypto.Macs.HMac::digest
	Il2CppObject * ___digest_2;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.HMac::digestSize
	int32_t ___digestSize_3;
	// System.Int32 Org.BouncyCastle.Crypto.Macs.HMac::blockLength
	int32_t ___blockLength_4;
	// Org.BouncyCastle.Utilities.IMemoable Org.BouncyCastle.Crypto.Macs.HMac::ipadState
	Il2CppObject * ___ipadState_5;
	// Org.BouncyCastle.Utilities.IMemoable Org.BouncyCastle.Crypto.Macs.HMac::opadState
	Il2CppObject * ___opadState_6;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.HMac::inputPad
	ByteU5BU5D_t3397334013* ___inputPad_7;
	// System.Byte[] Org.BouncyCastle.Crypto.Macs.HMac::outputBuf
	ByteU5BU5D_t3397334013* ___outputBuf_8;

public:
	inline static int32_t get_offset_of_digest_2() { return static_cast<int32_t>(offsetof(HMac_t2564819335, ___digest_2)); }
	inline Il2CppObject * get_digest_2() const { return ___digest_2; }
	inline Il2CppObject ** get_address_of_digest_2() { return &___digest_2; }
	inline void set_digest_2(Il2CppObject * value)
	{
		___digest_2 = value;
		Il2CppCodeGenWriteBarrier(&___digest_2, value);
	}

	inline static int32_t get_offset_of_digestSize_3() { return static_cast<int32_t>(offsetof(HMac_t2564819335, ___digestSize_3)); }
	inline int32_t get_digestSize_3() const { return ___digestSize_3; }
	inline int32_t* get_address_of_digestSize_3() { return &___digestSize_3; }
	inline void set_digestSize_3(int32_t value)
	{
		___digestSize_3 = value;
	}

	inline static int32_t get_offset_of_blockLength_4() { return static_cast<int32_t>(offsetof(HMac_t2564819335, ___blockLength_4)); }
	inline int32_t get_blockLength_4() const { return ___blockLength_4; }
	inline int32_t* get_address_of_blockLength_4() { return &___blockLength_4; }
	inline void set_blockLength_4(int32_t value)
	{
		___blockLength_4 = value;
	}

	inline static int32_t get_offset_of_ipadState_5() { return static_cast<int32_t>(offsetof(HMac_t2564819335, ___ipadState_5)); }
	inline Il2CppObject * get_ipadState_5() const { return ___ipadState_5; }
	inline Il2CppObject ** get_address_of_ipadState_5() { return &___ipadState_5; }
	inline void set_ipadState_5(Il2CppObject * value)
	{
		___ipadState_5 = value;
		Il2CppCodeGenWriteBarrier(&___ipadState_5, value);
	}

	inline static int32_t get_offset_of_opadState_6() { return static_cast<int32_t>(offsetof(HMac_t2564819335, ___opadState_6)); }
	inline Il2CppObject * get_opadState_6() const { return ___opadState_6; }
	inline Il2CppObject ** get_address_of_opadState_6() { return &___opadState_6; }
	inline void set_opadState_6(Il2CppObject * value)
	{
		___opadState_6 = value;
		Il2CppCodeGenWriteBarrier(&___opadState_6, value);
	}

	inline static int32_t get_offset_of_inputPad_7() { return static_cast<int32_t>(offsetof(HMac_t2564819335, ___inputPad_7)); }
	inline ByteU5BU5D_t3397334013* get_inputPad_7() const { return ___inputPad_7; }
	inline ByteU5BU5D_t3397334013** get_address_of_inputPad_7() { return &___inputPad_7; }
	inline void set_inputPad_7(ByteU5BU5D_t3397334013* value)
	{
		___inputPad_7 = value;
		Il2CppCodeGenWriteBarrier(&___inputPad_7, value);
	}

	inline static int32_t get_offset_of_outputBuf_8() { return static_cast<int32_t>(offsetof(HMac_t2564819335, ___outputBuf_8)); }
	inline ByteU5BU5D_t3397334013* get_outputBuf_8() const { return ___outputBuf_8; }
	inline ByteU5BU5D_t3397334013** get_address_of_outputBuf_8() { return &___outputBuf_8; }
	inline void set_outputBuf_8(ByteU5BU5D_t3397334013* value)
	{
		___outputBuf_8 = value;
		Il2CppCodeGenWriteBarrier(&___outputBuf_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
