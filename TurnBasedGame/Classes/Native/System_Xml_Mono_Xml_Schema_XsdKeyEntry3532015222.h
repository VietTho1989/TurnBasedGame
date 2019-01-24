#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Mono.Xml.Schema.XsdKeyEntryFieldCollection
struct XsdKeyEntryFieldCollection_t2946985218;
// Mono.Xml.Schema.XsdKeyTable
struct XsdKeyTable_t2980902100;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Xml.Schema.XsdKeyEntry
struct  XsdKeyEntry_t3532015222  : public Il2CppObject
{
public:
	// System.Int32 Mono.Xml.Schema.XsdKeyEntry::StartDepth
	int32_t ___StartDepth_0;
	// System.Int32 Mono.Xml.Schema.XsdKeyEntry::SelectorLineNumber
	int32_t ___SelectorLineNumber_1;
	// System.Int32 Mono.Xml.Schema.XsdKeyEntry::SelectorLinePosition
	int32_t ___SelectorLinePosition_2;
	// System.Boolean Mono.Xml.Schema.XsdKeyEntry::SelectorHasLineInfo
	bool ___SelectorHasLineInfo_3;
	// Mono.Xml.Schema.XsdKeyEntryFieldCollection Mono.Xml.Schema.XsdKeyEntry::KeyFields
	XsdKeyEntryFieldCollection_t2946985218 * ___KeyFields_4;
	// System.Boolean Mono.Xml.Schema.XsdKeyEntry::KeyRefFound
	bool ___KeyRefFound_5;
	// Mono.Xml.Schema.XsdKeyTable Mono.Xml.Schema.XsdKeyEntry::OwnerSequence
	XsdKeyTable_t2980902100 * ___OwnerSequence_6;
	// System.Boolean Mono.Xml.Schema.XsdKeyEntry::keyFound
	bool ___keyFound_7;

public:
	inline static int32_t get_offset_of_StartDepth_0() { return static_cast<int32_t>(offsetof(XsdKeyEntry_t3532015222, ___StartDepth_0)); }
	inline int32_t get_StartDepth_0() const { return ___StartDepth_0; }
	inline int32_t* get_address_of_StartDepth_0() { return &___StartDepth_0; }
	inline void set_StartDepth_0(int32_t value)
	{
		___StartDepth_0 = value;
	}

	inline static int32_t get_offset_of_SelectorLineNumber_1() { return static_cast<int32_t>(offsetof(XsdKeyEntry_t3532015222, ___SelectorLineNumber_1)); }
	inline int32_t get_SelectorLineNumber_1() const { return ___SelectorLineNumber_1; }
	inline int32_t* get_address_of_SelectorLineNumber_1() { return &___SelectorLineNumber_1; }
	inline void set_SelectorLineNumber_1(int32_t value)
	{
		___SelectorLineNumber_1 = value;
	}

	inline static int32_t get_offset_of_SelectorLinePosition_2() { return static_cast<int32_t>(offsetof(XsdKeyEntry_t3532015222, ___SelectorLinePosition_2)); }
	inline int32_t get_SelectorLinePosition_2() const { return ___SelectorLinePosition_2; }
	inline int32_t* get_address_of_SelectorLinePosition_2() { return &___SelectorLinePosition_2; }
	inline void set_SelectorLinePosition_2(int32_t value)
	{
		___SelectorLinePosition_2 = value;
	}

	inline static int32_t get_offset_of_SelectorHasLineInfo_3() { return static_cast<int32_t>(offsetof(XsdKeyEntry_t3532015222, ___SelectorHasLineInfo_3)); }
	inline bool get_SelectorHasLineInfo_3() const { return ___SelectorHasLineInfo_3; }
	inline bool* get_address_of_SelectorHasLineInfo_3() { return &___SelectorHasLineInfo_3; }
	inline void set_SelectorHasLineInfo_3(bool value)
	{
		___SelectorHasLineInfo_3 = value;
	}

	inline static int32_t get_offset_of_KeyFields_4() { return static_cast<int32_t>(offsetof(XsdKeyEntry_t3532015222, ___KeyFields_4)); }
	inline XsdKeyEntryFieldCollection_t2946985218 * get_KeyFields_4() const { return ___KeyFields_4; }
	inline XsdKeyEntryFieldCollection_t2946985218 ** get_address_of_KeyFields_4() { return &___KeyFields_4; }
	inline void set_KeyFields_4(XsdKeyEntryFieldCollection_t2946985218 * value)
	{
		___KeyFields_4 = value;
		Il2CppCodeGenWriteBarrier(&___KeyFields_4, value);
	}

	inline static int32_t get_offset_of_KeyRefFound_5() { return static_cast<int32_t>(offsetof(XsdKeyEntry_t3532015222, ___KeyRefFound_5)); }
	inline bool get_KeyRefFound_5() const { return ___KeyRefFound_5; }
	inline bool* get_address_of_KeyRefFound_5() { return &___KeyRefFound_5; }
	inline void set_KeyRefFound_5(bool value)
	{
		___KeyRefFound_5 = value;
	}

	inline static int32_t get_offset_of_OwnerSequence_6() { return static_cast<int32_t>(offsetof(XsdKeyEntry_t3532015222, ___OwnerSequence_6)); }
	inline XsdKeyTable_t2980902100 * get_OwnerSequence_6() const { return ___OwnerSequence_6; }
	inline XsdKeyTable_t2980902100 ** get_address_of_OwnerSequence_6() { return &___OwnerSequence_6; }
	inline void set_OwnerSequence_6(XsdKeyTable_t2980902100 * value)
	{
		___OwnerSequence_6 = value;
		Il2CppCodeGenWriteBarrier(&___OwnerSequence_6, value);
	}

	inline static int32_t get_offset_of_keyFound_7() { return static_cast<int32_t>(offsetof(XsdKeyEntry_t3532015222, ___keyFound_7)); }
	inline bool get_keyFound_7() const { return ___keyFound_7; }
	inline bool* get_address_of_keyFound_7() { return &___keyFound_7; }
	inline void set_keyFound_7(bool value)
	{
		___keyFound_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
