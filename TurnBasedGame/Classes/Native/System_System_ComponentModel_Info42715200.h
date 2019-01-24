#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Type
struct Type_t;
// System.ComponentModel.AttributeCollection
struct AttributeCollection_t1925812292;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.Info
struct  Info_t42715200  : public Il2CppObject
{
public:
	// System.Type System.ComponentModel.Info::_infoType
	Type_t * ____infoType_0;
	// System.ComponentModel.AttributeCollection System.ComponentModel.Info::_attributes
	AttributeCollection_t1925812292 * ____attributes_1;

public:
	inline static int32_t get_offset_of__infoType_0() { return static_cast<int32_t>(offsetof(Info_t42715200, ____infoType_0)); }
	inline Type_t * get__infoType_0() const { return ____infoType_0; }
	inline Type_t ** get_address_of__infoType_0() { return &____infoType_0; }
	inline void set__infoType_0(Type_t * value)
	{
		____infoType_0 = value;
		Il2CppCodeGenWriteBarrier(&____infoType_0, value);
	}

	inline static int32_t get_offset_of__attributes_1() { return static_cast<int32_t>(offsetof(Info_t42715200, ____attributes_1)); }
	inline AttributeCollection_t1925812292 * get__attributes_1() const { return ____attributes_1; }
	inline AttributeCollection_t1925812292 ** get_address_of__attributes_1() { return &____attributes_1; }
	inline void set__attributes_1(AttributeCollection_t1925812292 * value)
	{
		____attributes_1 = value;
		Il2CppCodeGenWriteBarrier(&____attributes_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
