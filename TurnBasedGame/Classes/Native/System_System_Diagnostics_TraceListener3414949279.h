#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_MarshalByRefObject1285298191.h"
#include "System_System_Diagnostics_TraceOptions4183547961.h"

// System.Collections.Specialized.StringDictionary
struct StringDictionary_t1070889667;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Diagnostics.TraceListener
struct  TraceListener_t3414949279  : public MarshalByRefObject_t1285298191
{
public:
	// System.Int32 System.Diagnostics.TraceListener::indentLevel
	int32_t ___indentLevel_1;
	// System.Int32 System.Diagnostics.TraceListener::indentSize
	int32_t ___indentSize_2;
	// System.Collections.Specialized.StringDictionary System.Diagnostics.TraceListener::attributes
	StringDictionary_t1070889667 * ___attributes_3;
	// System.Diagnostics.TraceOptions System.Diagnostics.TraceListener::options
	int32_t ___options_4;
	// System.String System.Diagnostics.TraceListener::name
	String_t* ___name_5;
	// System.Boolean System.Diagnostics.TraceListener::needIndent
	bool ___needIndent_6;

public:
	inline static int32_t get_offset_of_indentLevel_1() { return static_cast<int32_t>(offsetof(TraceListener_t3414949279, ___indentLevel_1)); }
	inline int32_t get_indentLevel_1() const { return ___indentLevel_1; }
	inline int32_t* get_address_of_indentLevel_1() { return &___indentLevel_1; }
	inline void set_indentLevel_1(int32_t value)
	{
		___indentLevel_1 = value;
	}

	inline static int32_t get_offset_of_indentSize_2() { return static_cast<int32_t>(offsetof(TraceListener_t3414949279, ___indentSize_2)); }
	inline int32_t get_indentSize_2() const { return ___indentSize_2; }
	inline int32_t* get_address_of_indentSize_2() { return &___indentSize_2; }
	inline void set_indentSize_2(int32_t value)
	{
		___indentSize_2 = value;
	}

	inline static int32_t get_offset_of_attributes_3() { return static_cast<int32_t>(offsetof(TraceListener_t3414949279, ___attributes_3)); }
	inline StringDictionary_t1070889667 * get_attributes_3() const { return ___attributes_3; }
	inline StringDictionary_t1070889667 ** get_address_of_attributes_3() { return &___attributes_3; }
	inline void set_attributes_3(StringDictionary_t1070889667 * value)
	{
		___attributes_3 = value;
		Il2CppCodeGenWriteBarrier(&___attributes_3, value);
	}

	inline static int32_t get_offset_of_options_4() { return static_cast<int32_t>(offsetof(TraceListener_t3414949279, ___options_4)); }
	inline int32_t get_options_4() const { return ___options_4; }
	inline int32_t* get_address_of_options_4() { return &___options_4; }
	inline void set_options_4(int32_t value)
	{
		___options_4 = value;
	}

	inline static int32_t get_offset_of_name_5() { return static_cast<int32_t>(offsetof(TraceListener_t3414949279, ___name_5)); }
	inline String_t* get_name_5() const { return ___name_5; }
	inline String_t** get_address_of_name_5() { return &___name_5; }
	inline void set_name_5(String_t* value)
	{
		___name_5 = value;
		Il2CppCodeGenWriteBarrier(&___name_5, value);
	}

	inline static int32_t get_offset_of_needIndent_6() { return static_cast<int32_t>(offsetof(TraceListener_t3414949279, ___needIndent_6)); }
	inline bool get_needIndent_6() const { return ___needIndent_6; }
	inline bool* get_address_of_needIndent_6() { return &___needIndent_6; }
	inline void set_needIndent_6(bool value)
	{
		___needIndent_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
