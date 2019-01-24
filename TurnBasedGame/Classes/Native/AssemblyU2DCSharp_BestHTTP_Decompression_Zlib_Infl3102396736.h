#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_Decompression_Zlib_Infl2519418742.h"

// BestHTTP.Decompression.Zlib.ZlibCodec
struct ZlibCodec_t1899545627;
// BestHTTP.Decompression.Zlib.InflateBlocks
struct InflateBlocks_t3437229943;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Decompression.Zlib.InflateManager
struct  InflateManager_t3102396736  : public Il2CppObject
{
public:
	// BestHTTP.Decompression.Zlib.InflateManager/InflateManagerMode BestHTTP.Decompression.Zlib.InflateManager::mode
	int32_t ___mode_2;
	// BestHTTP.Decompression.Zlib.ZlibCodec BestHTTP.Decompression.Zlib.InflateManager::_codec
	ZlibCodec_t1899545627 * ____codec_3;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateManager::method
	int32_t ___method_4;
	// System.UInt32 BestHTTP.Decompression.Zlib.InflateManager::computedCheck
	uint32_t ___computedCheck_5;
	// System.UInt32 BestHTTP.Decompression.Zlib.InflateManager::expectedCheck
	uint32_t ___expectedCheck_6;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateManager::marker
	int32_t ___marker_7;
	// System.Boolean BestHTTP.Decompression.Zlib.InflateManager::_handleRfc1950HeaderBytes
	bool ____handleRfc1950HeaderBytes_8;
	// System.Int32 BestHTTP.Decompression.Zlib.InflateManager::wbits
	int32_t ___wbits_9;
	// BestHTTP.Decompression.Zlib.InflateBlocks BestHTTP.Decompression.Zlib.InflateManager::blocks
	InflateBlocks_t3437229943 * ___blocks_10;

public:
	inline static int32_t get_offset_of_mode_2() { return static_cast<int32_t>(offsetof(InflateManager_t3102396736, ___mode_2)); }
	inline int32_t get_mode_2() const { return ___mode_2; }
	inline int32_t* get_address_of_mode_2() { return &___mode_2; }
	inline void set_mode_2(int32_t value)
	{
		___mode_2 = value;
	}

	inline static int32_t get_offset_of__codec_3() { return static_cast<int32_t>(offsetof(InflateManager_t3102396736, ____codec_3)); }
	inline ZlibCodec_t1899545627 * get__codec_3() const { return ____codec_3; }
	inline ZlibCodec_t1899545627 ** get_address_of__codec_3() { return &____codec_3; }
	inline void set__codec_3(ZlibCodec_t1899545627 * value)
	{
		____codec_3 = value;
		Il2CppCodeGenWriteBarrier(&____codec_3, value);
	}

	inline static int32_t get_offset_of_method_4() { return static_cast<int32_t>(offsetof(InflateManager_t3102396736, ___method_4)); }
	inline int32_t get_method_4() const { return ___method_4; }
	inline int32_t* get_address_of_method_4() { return &___method_4; }
	inline void set_method_4(int32_t value)
	{
		___method_4 = value;
	}

	inline static int32_t get_offset_of_computedCheck_5() { return static_cast<int32_t>(offsetof(InflateManager_t3102396736, ___computedCheck_5)); }
	inline uint32_t get_computedCheck_5() const { return ___computedCheck_5; }
	inline uint32_t* get_address_of_computedCheck_5() { return &___computedCheck_5; }
	inline void set_computedCheck_5(uint32_t value)
	{
		___computedCheck_5 = value;
	}

	inline static int32_t get_offset_of_expectedCheck_6() { return static_cast<int32_t>(offsetof(InflateManager_t3102396736, ___expectedCheck_6)); }
	inline uint32_t get_expectedCheck_6() const { return ___expectedCheck_6; }
	inline uint32_t* get_address_of_expectedCheck_6() { return &___expectedCheck_6; }
	inline void set_expectedCheck_6(uint32_t value)
	{
		___expectedCheck_6 = value;
	}

	inline static int32_t get_offset_of_marker_7() { return static_cast<int32_t>(offsetof(InflateManager_t3102396736, ___marker_7)); }
	inline int32_t get_marker_7() const { return ___marker_7; }
	inline int32_t* get_address_of_marker_7() { return &___marker_7; }
	inline void set_marker_7(int32_t value)
	{
		___marker_7 = value;
	}

	inline static int32_t get_offset_of__handleRfc1950HeaderBytes_8() { return static_cast<int32_t>(offsetof(InflateManager_t3102396736, ____handleRfc1950HeaderBytes_8)); }
	inline bool get__handleRfc1950HeaderBytes_8() const { return ____handleRfc1950HeaderBytes_8; }
	inline bool* get_address_of__handleRfc1950HeaderBytes_8() { return &____handleRfc1950HeaderBytes_8; }
	inline void set__handleRfc1950HeaderBytes_8(bool value)
	{
		____handleRfc1950HeaderBytes_8 = value;
	}

	inline static int32_t get_offset_of_wbits_9() { return static_cast<int32_t>(offsetof(InflateManager_t3102396736, ___wbits_9)); }
	inline int32_t get_wbits_9() const { return ___wbits_9; }
	inline int32_t* get_address_of_wbits_9() { return &___wbits_9; }
	inline void set_wbits_9(int32_t value)
	{
		___wbits_9 = value;
	}

	inline static int32_t get_offset_of_blocks_10() { return static_cast<int32_t>(offsetof(InflateManager_t3102396736, ___blocks_10)); }
	inline InflateBlocks_t3437229943 * get_blocks_10() const { return ___blocks_10; }
	inline InflateBlocks_t3437229943 ** get_address_of_blocks_10() { return &___blocks_10; }
	inline void set_blocks_10(InflateBlocks_t3437229943 * value)
	{
		___blocks_10 = value;
		Il2CppCodeGenWriteBarrier(&___blocks_10, value);
	}
};

struct InflateManager_t3102396736_StaticFields
{
public:
	// System.Byte[] BestHTTP.Decompression.Zlib.InflateManager::mark
	ByteU5BU5D_t3397334013* ___mark_11;

public:
	inline static int32_t get_offset_of_mark_11() { return static_cast<int32_t>(offsetof(InflateManager_t3102396736_StaticFields, ___mark_11)); }
	inline ByteU5BU5D_t3397334013* get_mark_11() const { return ___mark_11; }
	inline ByteU5BU5D_t3397334013** get_address_of_mark_11() { return &___mark_11; }
	inline void set_mark_11(ByteU5BU5D_t3397334013* value)
	{
		___mark_11 = value;
		Il2CppCodeGenWriteBarrier(&___mark_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
