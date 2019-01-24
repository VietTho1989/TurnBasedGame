#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_System_ComponentModel_PropertyDescriptor4250402154.h"

// System.Reflection.PropertyInfo
struct PropertyInfo_t;
// System.Type
struct Type_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ComponentModel.ReflectionPropertyDescriptor
struct  ReflectionPropertyDescriptor_t2570125387  : public PropertyDescriptor_t4250402154
{
public:
	// System.Reflection.PropertyInfo System.ComponentModel.ReflectionPropertyDescriptor::_member
	PropertyInfo_t * ____member_3;
	// System.Type System.ComponentModel.ReflectionPropertyDescriptor::_componentType
	Type_t * ____componentType_4;
	// System.Type System.ComponentModel.ReflectionPropertyDescriptor::_propertyType
	Type_t * ____propertyType_5;

public:
	inline static int32_t get_offset_of__member_3() { return static_cast<int32_t>(offsetof(ReflectionPropertyDescriptor_t2570125387, ____member_3)); }
	inline PropertyInfo_t * get__member_3() const { return ____member_3; }
	inline PropertyInfo_t ** get_address_of__member_3() { return &____member_3; }
	inline void set__member_3(PropertyInfo_t * value)
	{
		____member_3 = value;
		Il2CppCodeGenWriteBarrier(&____member_3, value);
	}

	inline static int32_t get_offset_of__componentType_4() { return static_cast<int32_t>(offsetof(ReflectionPropertyDescriptor_t2570125387, ____componentType_4)); }
	inline Type_t * get__componentType_4() const { return ____componentType_4; }
	inline Type_t ** get_address_of__componentType_4() { return &____componentType_4; }
	inline void set__componentType_4(Type_t * value)
	{
		____componentType_4 = value;
		Il2CppCodeGenWriteBarrier(&____componentType_4, value);
	}

	inline static int32_t get_offset_of__propertyType_5() { return static_cast<int32_t>(offsetof(ReflectionPropertyDescriptor_t2570125387, ____propertyType_5)); }
	inline Type_t * get__propertyType_5() const { return ____propertyType_5; }
	inline Type_t ** get_address_of__propertyType_5() { return &____propertyType_5; }
	inline void set__propertyType_5(Type_t * value)
	{
		____propertyType_5 = value;
		Il2CppCodeGenWriteBarrier(&____propertyType_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
