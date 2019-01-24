#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Uri
struct Uri_t19570940;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.UriBuilder
struct  UriBuilder_t2016461725  : public Il2CppObject
{
public:
	// System.String System.UriBuilder::scheme
	String_t* ___scheme_0;
	// System.String System.UriBuilder::host
	String_t* ___host_1;
	// System.Int32 System.UriBuilder::port
	int32_t ___port_2;
	// System.String System.UriBuilder::path
	String_t* ___path_3;
	// System.String System.UriBuilder::query
	String_t* ___query_4;
	// System.String System.UriBuilder::fragment
	String_t* ___fragment_5;
	// System.String System.UriBuilder::username
	String_t* ___username_6;
	// System.String System.UriBuilder::password
	String_t* ___password_7;
	// System.Uri System.UriBuilder::uri
	Uri_t19570940 * ___uri_8;
	// System.Boolean System.UriBuilder::modified
	bool ___modified_9;

public:
	inline static int32_t get_offset_of_scheme_0() { return static_cast<int32_t>(offsetof(UriBuilder_t2016461725, ___scheme_0)); }
	inline String_t* get_scheme_0() const { return ___scheme_0; }
	inline String_t** get_address_of_scheme_0() { return &___scheme_0; }
	inline void set_scheme_0(String_t* value)
	{
		___scheme_0 = value;
		Il2CppCodeGenWriteBarrier(&___scheme_0, value);
	}

	inline static int32_t get_offset_of_host_1() { return static_cast<int32_t>(offsetof(UriBuilder_t2016461725, ___host_1)); }
	inline String_t* get_host_1() const { return ___host_1; }
	inline String_t** get_address_of_host_1() { return &___host_1; }
	inline void set_host_1(String_t* value)
	{
		___host_1 = value;
		Il2CppCodeGenWriteBarrier(&___host_1, value);
	}

	inline static int32_t get_offset_of_port_2() { return static_cast<int32_t>(offsetof(UriBuilder_t2016461725, ___port_2)); }
	inline int32_t get_port_2() const { return ___port_2; }
	inline int32_t* get_address_of_port_2() { return &___port_2; }
	inline void set_port_2(int32_t value)
	{
		___port_2 = value;
	}

	inline static int32_t get_offset_of_path_3() { return static_cast<int32_t>(offsetof(UriBuilder_t2016461725, ___path_3)); }
	inline String_t* get_path_3() const { return ___path_3; }
	inline String_t** get_address_of_path_3() { return &___path_3; }
	inline void set_path_3(String_t* value)
	{
		___path_3 = value;
		Il2CppCodeGenWriteBarrier(&___path_3, value);
	}

	inline static int32_t get_offset_of_query_4() { return static_cast<int32_t>(offsetof(UriBuilder_t2016461725, ___query_4)); }
	inline String_t* get_query_4() const { return ___query_4; }
	inline String_t** get_address_of_query_4() { return &___query_4; }
	inline void set_query_4(String_t* value)
	{
		___query_4 = value;
		Il2CppCodeGenWriteBarrier(&___query_4, value);
	}

	inline static int32_t get_offset_of_fragment_5() { return static_cast<int32_t>(offsetof(UriBuilder_t2016461725, ___fragment_5)); }
	inline String_t* get_fragment_5() const { return ___fragment_5; }
	inline String_t** get_address_of_fragment_5() { return &___fragment_5; }
	inline void set_fragment_5(String_t* value)
	{
		___fragment_5 = value;
		Il2CppCodeGenWriteBarrier(&___fragment_5, value);
	}

	inline static int32_t get_offset_of_username_6() { return static_cast<int32_t>(offsetof(UriBuilder_t2016461725, ___username_6)); }
	inline String_t* get_username_6() const { return ___username_6; }
	inline String_t** get_address_of_username_6() { return &___username_6; }
	inline void set_username_6(String_t* value)
	{
		___username_6 = value;
		Il2CppCodeGenWriteBarrier(&___username_6, value);
	}

	inline static int32_t get_offset_of_password_7() { return static_cast<int32_t>(offsetof(UriBuilder_t2016461725, ___password_7)); }
	inline String_t* get_password_7() const { return ___password_7; }
	inline String_t** get_address_of_password_7() { return &___password_7; }
	inline void set_password_7(String_t* value)
	{
		___password_7 = value;
		Il2CppCodeGenWriteBarrier(&___password_7, value);
	}

	inline static int32_t get_offset_of_uri_8() { return static_cast<int32_t>(offsetof(UriBuilder_t2016461725, ___uri_8)); }
	inline Uri_t19570940 * get_uri_8() const { return ___uri_8; }
	inline Uri_t19570940 ** get_address_of_uri_8() { return &___uri_8; }
	inline void set_uri_8(Uri_t19570940 * value)
	{
		___uri_8 = value;
		Il2CppCodeGenWriteBarrier(&___uri_8, value);
	}

	inline static int32_t get_offset_of_modified_9() { return static_cast<int32_t>(offsetof(UriBuilder_t2016461725, ___modified_9)); }
	inline bool get_modified_9() const { return ___modified_9; }
	inline bool* get_address_of_modified_9() { return &___modified_9; }
	inline void set_modified_9(bool value)
	{
		___modified_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
