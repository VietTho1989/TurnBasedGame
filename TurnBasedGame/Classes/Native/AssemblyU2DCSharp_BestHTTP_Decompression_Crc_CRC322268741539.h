#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.UInt32[]
struct UInt32U5BU5D_t59386216;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Decompression.Crc.CRC32
struct  CRC32_t2268741539  : public Il2CppObject
{
public:
	// System.UInt32 BestHTTP.Decompression.Crc.CRC32::dwPolynomial
	uint32_t ___dwPolynomial_0;
	// System.Int64 BestHTTP.Decompression.Crc.CRC32::_TotalBytesRead
	int64_t ____TotalBytesRead_1;
	// System.Boolean BestHTTP.Decompression.Crc.CRC32::reverseBits
	bool ___reverseBits_2;
	// System.UInt32[] BestHTTP.Decompression.Crc.CRC32::crc32Table
	UInt32U5BU5D_t59386216* ___crc32Table_3;
	// System.UInt32 BestHTTP.Decompression.Crc.CRC32::_register
	uint32_t ____register_5;

public:
	inline static int32_t get_offset_of_dwPolynomial_0() { return static_cast<int32_t>(offsetof(CRC32_t2268741539, ___dwPolynomial_0)); }
	inline uint32_t get_dwPolynomial_0() const { return ___dwPolynomial_0; }
	inline uint32_t* get_address_of_dwPolynomial_0() { return &___dwPolynomial_0; }
	inline void set_dwPolynomial_0(uint32_t value)
	{
		___dwPolynomial_0 = value;
	}

	inline static int32_t get_offset_of__TotalBytesRead_1() { return static_cast<int32_t>(offsetof(CRC32_t2268741539, ____TotalBytesRead_1)); }
	inline int64_t get__TotalBytesRead_1() const { return ____TotalBytesRead_1; }
	inline int64_t* get_address_of__TotalBytesRead_1() { return &____TotalBytesRead_1; }
	inline void set__TotalBytesRead_1(int64_t value)
	{
		____TotalBytesRead_1 = value;
	}

	inline static int32_t get_offset_of_reverseBits_2() { return static_cast<int32_t>(offsetof(CRC32_t2268741539, ___reverseBits_2)); }
	inline bool get_reverseBits_2() const { return ___reverseBits_2; }
	inline bool* get_address_of_reverseBits_2() { return &___reverseBits_2; }
	inline void set_reverseBits_2(bool value)
	{
		___reverseBits_2 = value;
	}

	inline static int32_t get_offset_of_crc32Table_3() { return static_cast<int32_t>(offsetof(CRC32_t2268741539, ___crc32Table_3)); }
	inline UInt32U5BU5D_t59386216* get_crc32Table_3() const { return ___crc32Table_3; }
	inline UInt32U5BU5D_t59386216** get_address_of_crc32Table_3() { return &___crc32Table_3; }
	inline void set_crc32Table_3(UInt32U5BU5D_t59386216* value)
	{
		___crc32Table_3 = value;
		Il2CppCodeGenWriteBarrier(&___crc32Table_3, value);
	}

	inline static int32_t get_offset_of__register_5() { return static_cast<int32_t>(offsetof(CRC32_t2268741539, ____register_5)); }
	inline uint32_t get__register_5() const { return ____register_5; }
	inline uint32_t* get_address_of__register_5() { return &____register_5; }
	inline void set__register_5(uint32_t value)
	{
		____register_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
