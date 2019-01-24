#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_FullSerializer_fsConverter466758137.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.Internal.fsForwardConverter
struct  fsForwardConverter_t3272928430  : public fsConverter_t466758137
{
public:
	// System.String FullSerializer.Internal.fsForwardConverter::_memberName
	String_t* ____memberName_2;

public:
	inline static int32_t get_offset_of__memberName_2() { return static_cast<int32_t>(offsetof(fsForwardConverter_t3272928430, ____memberName_2)); }
	inline String_t* get__memberName_2() const { return ____memberName_2; }
	inline String_t** get_address_of__memberName_2() { return &____memberName_2; }
	inline void set__memberName_2(String_t* value)
	{
		____memberName_2 = value;
		Il2CppCodeGenWriteBarrier(&____memberName_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
