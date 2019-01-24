#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_System_Net_ChunkStream_State4001596355.h"

// System.Net.WebHeaderCollection
struct WebHeaderCollection_t3028142837;
// System.Text.StringBuilder
struct StringBuilder_t1221177846;
// System.Collections.ArrayList
struct ArrayList_t4252133567;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.ChunkStream
struct  ChunkStream_t91719323  : public Il2CppObject
{
public:
	// System.Net.WebHeaderCollection System.Net.ChunkStream::headers
	WebHeaderCollection_t3028142837 * ___headers_0;
	// System.Int32 System.Net.ChunkStream::chunkSize
	int32_t ___chunkSize_1;
	// System.Int32 System.Net.ChunkStream::chunkRead
	int32_t ___chunkRead_2;
	// System.Net.ChunkStream/State System.Net.ChunkStream::state
	int32_t ___state_3;
	// System.Text.StringBuilder System.Net.ChunkStream::saved
	StringBuilder_t1221177846 * ___saved_4;
	// System.Boolean System.Net.ChunkStream::sawCR
	bool ___sawCR_5;
	// System.Boolean System.Net.ChunkStream::gotit
	bool ___gotit_6;
	// System.Int32 System.Net.ChunkStream::trailerState
	int32_t ___trailerState_7;
	// System.Collections.ArrayList System.Net.ChunkStream::chunks
	ArrayList_t4252133567 * ___chunks_8;

public:
	inline static int32_t get_offset_of_headers_0() { return static_cast<int32_t>(offsetof(ChunkStream_t91719323, ___headers_0)); }
	inline WebHeaderCollection_t3028142837 * get_headers_0() const { return ___headers_0; }
	inline WebHeaderCollection_t3028142837 ** get_address_of_headers_0() { return &___headers_0; }
	inline void set_headers_0(WebHeaderCollection_t3028142837 * value)
	{
		___headers_0 = value;
		Il2CppCodeGenWriteBarrier(&___headers_0, value);
	}

	inline static int32_t get_offset_of_chunkSize_1() { return static_cast<int32_t>(offsetof(ChunkStream_t91719323, ___chunkSize_1)); }
	inline int32_t get_chunkSize_1() const { return ___chunkSize_1; }
	inline int32_t* get_address_of_chunkSize_1() { return &___chunkSize_1; }
	inline void set_chunkSize_1(int32_t value)
	{
		___chunkSize_1 = value;
	}

	inline static int32_t get_offset_of_chunkRead_2() { return static_cast<int32_t>(offsetof(ChunkStream_t91719323, ___chunkRead_2)); }
	inline int32_t get_chunkRead_2() const { return ___chunkRead_2; }
	inline int32_t* get_address_of_chunkRead_2() { return &___chunkRead_2; }
	inline void set_chunkRead_2(int32_t value)
	{
		___chunkRead_2 = value;
	}

	inline static int32_t get_offset_of_state_3() { return static_cast<int32_t>(offsetof(ChunkStream_t91719323, ___state_3)); }
	inline int32_t get_state_3() const { return ___state_3; }
	inline int32_t* get_address_of_state_3() { return &___state_3; }
	inline void set_state_3(int32_t value)
	{
		___state_3 = value;
	}

	inline static int32_t get_offset_of_saved_4() { return static_cast<int32_t>(offsetof(ChunkStream_t91719323, ___saved_4)); }
	inline StringBuilder_t1221177846 * get_saved_4() const { return ___saved_4; }
	inline StringBuilder_t1221177846 ** get_address_of_saved_4() { return &___saved_4; }
	inline void set_saved_4(StringBuilder_t1221177846 * value)
	{
		___saved_4 = value;
		Il2CppCodeGenWriteBarrier(&___saved_4, value);
	}

	inline static int32_t get_offset_of_sawCR_5() { return static_cast<int32_t>(offsetof(ChunkStream_t91719323, ___sawCR_5)); }
	inline bool get_sawCR_5() const { return ___sawCR_5; }
	inline bool* get_address_of_sawCR_5() { return &___sawCR_5; }
	inline void set_sawCR_5(bool value)
	{
		___sawCR_5 = value;
	}

	inline static int32_t get_offset_of_gotit_6() { return static_cast<int32_t>(offsetof(ChunkStream_t91719323, ___gotit_6)); }
	inline bool get_gotit_6() const { return ___gotit_6; }
	inline bool* get_address_of_gotit_6() { return &___gotit_6; }
	inline void set_gotit_6(bool value)
	{
		___gotit_6 = value;
	}

	inline static int32_t get_offset_of_trailerState_7() { return static_cast<int32_t>(offsetof(ChunkStream_t91719323, ___trailerState_7)); }
	inline int32_t get_trailerState_7() const { return ___trailerState_7; }
	inline int32_t* get_address_of_trailerState_7() { return &___trailerState_7; }
	inline void set_trailerState_7(int32_t value)
	{
		___trailerState_7 = value;
	}

	inline static int32_t get_offset_of_chunks_8() { return static_cast<int32_t>(offsetof(ChunkStream_t91719323, ___chunks_8)); }
	inline ArrayList_t4252133567 * get_chunks_8() const { return ___chunks_8; }
	inline ArrayList_t4252133567 ** get_address_of_chunks_8() { return &___chunks_8; }
	inline void set_chunks_8(ArrayList_t4252133567 * value)
	{
		___chunks_8 = value;
		Il2CppCodeGenWriteBarrier(&___chunks_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
