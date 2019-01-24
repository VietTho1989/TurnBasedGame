#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.Common
struct  Common_t1176717011  : public Il2CppObject
{
public:

public:
};

struct Common_t1176717011_StaticFields
{
public:
	// System.Int32[] Xiangqi.Common::cnPieceTypes
	Int32U5BU5D_t3030399641* ___cnPieceTypes_5;
	// System.String Xiangqi.Common::cszPieceBytes
	String_t* ___cszPieceBytes_6;

public:
	inline static int32_t get_offset_of_cnPieceTypes_5() { return static_cast<int32_t>(offsetof(Common_t1176717011_StaticFields, ___cnPieceTypes_5)); }
	inline Int32U5BU5D_t3030399641* get_cnPieceTypes_5() const { return ___cnPieceTypes_5; }
	inline Int32U5BU5D_t3030399641** get_address_of_cnPieceTypes_5() { return &___cnPieceTypes_5; }
	inline void set_cnPieceTypes_5(Int32U5BU5D_t3030399641* value)
	{
		___cnPieceTypes_5 = value;
		Il2CppCodeGenWriteBarrier(&___cnPieceTypes_5, value);
	}

	inline static int32_t get_offset_of_cszPieceBytes_6() { return static_cast<int32_t>(offsetof(Common_t1176717011_StaticFields, ___cszPieceBytes_6)); }
	inline String_t* get_cszPieceBytes_6() const { return ___cszPieceBytes_6; }
	inline String_t** get_address_of_cszPieceBytes_6() { return &___cszPieceBytes_6; }
	inline void set_cszPieceBytes_6(String_t* value)
	{
		___cszPieceBytes_6 = value;
		Il2CppCodeGenWriteBarrier(&___cszPieceBytes_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
