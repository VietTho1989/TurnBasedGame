#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_DateTime693205669.h"

// System.String
struct String_t;
// System.Uri
struct Uri_t19570940;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.Char[]
struct CharU5BU5D_t1328083999;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.Cookie
struct  Cookie_t3154017544  : public Il2CppObject
{
public:
	// System.String System.Net.Cookie::comment
	String_t* ___comment_0;
	// System.Uri System.Net.Cookie::commentUri
	Uri_t19570940 * ___commentUri_1;
	// System.Boolean System.Net.Cookie::discard
	bool ___discard_2;
	// System.String System.Net.Cookie::domain
	String_t* ___domain_3;
	// System.DateTime System.Net.Cookie::expires
	DateTime_t693205669  ___expires_4;
	// System.Boolean System.Net.Cookie::httpOnly
	bool ___httpOnly_5;
	// System.String System.Net.Cookie::name
	String_t* ___name_6;
	// System.String System.Net.Cookie::path
	String_t* ___path_7;
	// System.String System.Net.Cookie::port
	String_t* ___port_8;
	// System.Int32[] System.Net.Cookie::ports
	Int32U5BU5D_t3030399641* ___ports_9;
	// System.Boolean System.Net.Cookie::secure
	bool ___secure_10;
	// System.DateTime System.Net.Cookie::timestamp
	DateTime_t693205669  ___timestamp_11;
	// System.String System.Net.Cookie::val
	String_t* ___val_12;
	// System.Int32 System.Net.Cookie::version
	int32_t ___version_13;
	// System.Boolean System.Net.Cookie::exact_domain
	bool ___exact_domain_17;

public:
	inline static int32_t get_offset_of_comment_0() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___comment_0)); }
	inline String_t* get_comment_0() const { return ___comment_0; }
	inline String_t** get_address_of_comment_0() { return &___comment_0; }
	inline void set_comment_0(String_t* value)
	{
		___comment_0 = value;
		Il2CppCodeGenWriteBarrier(&___comment_0, value);
	}

	inline static int32_t get_offset_of_commentUri_1() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___commentUri_1)); }
	inline Uri_t19570940 * get_commentUri_1() const { return ___commentUri_1; }
	inline Uri_t19570940 ** get_address_of_commentUri_1() { return &___commentUri_1; }
	inline void set_commentUri_1(Uri_t19570940 * value)
	{
		___commentUri_1 = value;
		Il2CppCodeGenWriteBarrier(&___commentUri_1, value);
	}

	inline static int32_t get_offset_of_discard_2() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___discard_2)); }
	inline bool get_discard_2() const { return ___discard_2; }
	inline bool* get_address_of_discard_2() { return &___discard_2; }
	inline void set_discard_2(bool value)
	{
		___discard_2 = value;
	}

	inline static int32_t get_offset_of_domain_3() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___domain_3)); }
	inline String_t* get_domain_3() const { return ___domain_3; }
	inline String_t** get_address_of_domain_3() { return &___domain_3; }
	inline void set_domain_3(String_t* value)
	{
		___domain_3 = value;
		Il2CppCodeGenWriteBarrier(&___domain_3, value);
	}

	inline static int32_t get_offset_of_expires_4() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___expires_4)); }
	inline DateTime_t693205669  get_expires_4() const { return ___expires_4; }
	inline DateTime_t693205669 * get_address_of_expires_4() { return &___expires_4; }
	inline void set_expires_4(DateTime_t693205669  value)
	{
		___expires_4 = value;
	}

	inline static int32_t get_offset_of_httpOnly_5() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___httpOnly_5)); }
	inline bool get_httpOnly_5() const { return ___httpOnly_5; }
	inline bool* get_address_of_httpOnly_5() { return &___httpOnly_5; }
	inline void set_httpOnly_5(bool value)
	{
		___httpOnly_5 = value;
	}

	inline static int32_t get_offset_of_name_6() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___name_6)); }
	inline String_t* get_name_6() const { return ___name_6; }
	inline String_t** get_address_of_name_6() { return &___name_6; }
	inline void set_name_6(String_t* value)
	{
		___name_6 = value;
		Il2CppCodeGenWriteBarrier(&___name_6, value);
	}

	inline static int32_t get_offset_of_path_7() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___path_7)); }
	inline String_t* get_path_7() const { return ___path_7; }
	inline String_t** get_address_of_path_7() { return &___path_7; }
	inline void set_path_7(String_t* value)
	{
		___path_7 = value;
		Il2CppCodeGenWriteBarrier(&___path_7, value);
	}

	inline static int32_t get_offset_of_port_8() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___port_8)); }
	inline String_t* get_port_8() const { return ___port_8; }
	inline String_t** get_address_of_port_8() { return &___port_8; }
	inline void set_port_8(String_t* value)
	{
		___port_8 = value;
		Il2CppCodeGenWriteBarrier(&___port_8, value);
	}

	inline static int32_t get_offset_of_ports_9() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___ports_9)); }
	inline Int32U5BU5D_t3030399641* get_ports_9() const { return ___ports_9; }
	inline Int32U5BU5D_t3030399641** get_address_of_ports_9() { return &___ports_9; }
	inline void set_ports_9(Int32U5BU5D_t3030399641* value)
	{
		___ports_9 = value;
		Il2CppCodeGenWriteBarrier(&___ports_9, value);
	}

	inline static int32_t get_offset_of_secure_10() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___secure_10)); }
	inline bool get_secure_10() const { return ___secure_10; }
	inline bool* get_address_of_secure_10() { return &___secure_10; }
	inline void set_secure_10(bool value)
	{
		___secure_10 = value;
	}

	inline static int32_t get_offset_of_timestamp_11() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___timestamp_11)); }
	inline DateTime_t693205669  get_timestamp_11() const { return ___timestamp_11; }
	inline DateTime_t693205669 * get_address_of_timestamp_11() { return &___timestamp_11; }
	inline void set_timestamp_11(DateTime_t693205669  value)
	{
		___timestamp_11 = value;
	}

	inline static int32_t get_offset_of_val_12() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___val_12)); }
	inline String_t* get_val_12() const { return ___val_12; }
	inline String_t** get_address_of_val_12() { return &___val_12; }
	inline void set_val_12(String_t* value)
	{
		___val_12 = value;
		Il2CppCodeGenWriteBarrier(&___val_12, value);
	}

	inline static int32_t get_offset_of_version_13() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___version_13)); }
	inline int32_t get_version_13() const { return ___version_13; }
	inline int32_t* get_address_of_version_13() { return &___version_13; }
	inline void set_version_13(int32_t value)
	{
		___version_13 = value;
	}

	inline static int32_t get_offset_of_exact_domain_17() { return static_cast<int32_t>(offsetof(Cookie_t3154017544, ___exact_domain_17)); }
	inline bool get_exact_domain_17() const { return ___exact_domain_17; }
	inline bool* get_address_of_exact_domain_17() { return &___exact_domain_17; }
	inline void set_exact_domain_17(bool value)
	{
		___exact_domain_17 = value;
	}
};

struct Cookie_t3154017544_StaticFields
{
public:
	// System.Char[] System.Net.Cookie::reservedCharsName
	CharU5BU5D_t1328083999* ___reservedCharsName_14;
	// System.Char[] System.Net.Cookie::portSeparators
	CharU5BU5D_t1328083999* ___portSeparators_15;
	// System.String System.Net.Cookie::tspecials
	String_t* ___tspecials_16;

public:
	inline static int32_t get_offset_of_reservedCharsName_14() { return static_cast<int32_t>(offsetof(Cookie_t3154017544_StaticFields, ___reservedCharsName_14)); }
	inline CharU5BU5D_t1328083999* get_reservedCharsName_14() const { return ___reservedCharsName_14; }
	inline CharU5BU5D_t1328083999** get_address_of_reservedCharsName_14() { return &___reservedCharsName_14; }
	inline void set_reservedCharsName_14(CharU5BU5D_t1328083999* value)
	{
		___reservedCharsName_14 = value;
		Il2CppCodeGenWriteBarrier(&___reservedCharsName_14, value);
	}

	inline static int32_t get_offset_of_portSeparators_15() { return static_cast<int32_t>(offsetof(Cookie_t3154017544_StaticFields, ___portSeparators_15)); }
	inline CharU5BU5D_t1328083999* get_portSeparators_15() const { return ___portSeparators_15; }
	inline CharU5BU5D_t1328083999** get_address_of_portSeparators_15() { return &___portSeparators_15; }
	inline void set_portSeparators_15(CharU5BU5D_t1328083999* value)
	{
		___portSeparators_15 = value;
		Il2CppCodeGenWriteBarrier(&___portSeparators_15, value);
	}

	inline static int32_t get_offset_of_tspecials_16() { return static_cast<int32_t>(offsetof(Cookie_t3154017544_StaticFields, ___tspecials_16)); }
	inline String_t* get_tspecials_16() const { return ___tspecials_16; }
	inline String_t** get_address_of_tspecials_16() { return &___tspecials_16; }
	inline void set_tspecials_16(String_t* value)
	{
		___tspecials_16 = value;
		Il2CppCodeGenWriteBarrier(&___tspecials_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
