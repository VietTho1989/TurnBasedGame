#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_IO_Stream3255436806.h"

// System.IO.Stream[]
struct StreamU5BU5D_t3762221859;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.StreamList
struct  StreamList_t3066109018  : public Stream_t3255436806
{
public:
	// System.IO.Stream[] BestHTTP.StreamList::Streams
	StreamU5BU5D_t3762221859* ___Streams_2;
	// System.Int32 BestHTTP.StreamList::CurrentIdx
	int32_t ___CurrentIdx_3;

public:
	inline static int32_t get_offset_of_Streams_2() { return static_cast<int32_t>(offsetof(StreamList_t3066109018, ___Streams_2)); }
	inline StreamU5BU5D_t3762221859* get_Streams_2() const { return ___Streams_2; }
	inline StreamU5BU5D_t3762221859** get_address_of_Streams_2() { return &___Streams_2; }
	inline void set_Streams_2(StreamU5BU5D_t3762221859* value)
	{
		___Streams_2 = value;
		Il2CppCodeGenWriteBarrier(&___Streams_2, value);
	}

	inline static int32_t get_offset_of_CurrentIdx_3() { return static_cast<int32_t>(offsetof(StreamList_t3066109018, ___CurrentIdx_3)); }
	inline int32_t get_CurrentIdx_3() const { return ___CurrentIdx_3; }
	inline int32_t* get_address_of_CurrentIdx_3() { return &___CurrentIdx_3; }
	inline void set_CurrentIdx_3(int32_t value)
	{
		___CurrentIdx_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
