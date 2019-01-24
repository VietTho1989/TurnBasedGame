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
// Mono.Security.Uri/UriScheme[]
struct UriSchemeU5BU5D_t409881140;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Mono.Security.Uri
struct  Uri_t1510604476  : public Il2CppObject
{
public:
	// System.Boolean Mono.Security.Uri::isUnixFilePath
	bool ___isUnixFilePath_0;
	// System.String Mono.Security.Uri::source
	String_t* ___source_1;
	// System.String Mono.Security.Uri::scheme
	String_t* ___scheme_2;
	// System.String Mono.Security.Uri::host
	String_t* ___host_3;
	// System.Int32 Mono.Security.Uri::port
	int32_t ___port_4;
	// System.String Mono.Security.Uri::path
	String_t* ___path_5;
	// System.String Mono.Security.Uri::query
	String_t* ___query_6;
	// System.String Mono.Security.Uri::fragment
	String_t* ___fragment_7;
	// System.String Mono.Security.Uri::userinfo
	String_t* ___userinfo_8;
	// System.Boolean Mono.Security.Uri::isUnc
	bool ___isUnc_9;
	// System.Boolean Mono.Security.Uri::isOpaquePart
	bool ___isOpaquePart_10;
	// System.Boolean Mono.Security.Uri::userEscaped
	bool ___userEscaped_11;
	// System.String Mono.Security.Uri::cachedToString
	String_t* ___cachedToString_12;
	// System.String Mono.Security.Uri::cachedLocalPath
	String_t* ___cachedLocalPath_13;
	// System.Int32 Mono.Security.Uri::cachedHashCode
	int32_t ___cachedHashCode_14;
	// System.Boolean Mono.Security.Uri::reduce
	bool ___reduce_15;

public:
	inline static int32_t get_offset_of_isUnixFilePath_0() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___isUnixFilePath_0)); }
	inline bool get_isUnixFilePath_0() const { return ___isUnixFilePath_0; }
	inline bool* get_address_of_isUnixFilePath_0() { return &___isUnixFilePath_0; }
	inline void set_isUnixFilePath_0(bool value)
	{
		___isUnixFilePath_0 = value;
	}

	inline static int32_t get_offset_of_source_1() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___source_1)); }
	inline String_t* get_source_1() const { return ___source_1; }
	inline String_t** get_address_of_source_1() { return &___source_1; }
	inline void set_source_1(String_t* value)
	{
		___source_1 = value;
		Il2CppCodeGenWriteBarrier(&___source_1, value);
	}

	inline static int32_t get_offset_of_scheme_2() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___scheme_2)); }
	inline String_t* get_scheme_2() const { return ___scheme_2; }
	inline String_t** get_address_of_scheme_2() { return &___scheme_2; }
	inline void set_scheme_2(String_t* value)
	{
		___scheme_2 = value;
		Il2CppCodeGenWriteBarrier(&___scheme_2, value);
	}

	inline static int32_t get_offset_of_host_3() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___host_3)); }
	inline String_t* get_host_3() const { return ___host_3; }
	inline String_t** get_address_of_host_3() { return &___host_3; }
	inline void set_host_3(String_t* value)
	{
		___host_3 = value;
		Il2CppCodeGenWriteBarrier(&___host_3, value);
	}

	inline static int32_t get_offset_of_port_4() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___port_4)); }
	inline int32_t get_port_4() const { return ___port_4; }
	inline int32_t* get_address_of_port_4() { return &___port_4; }
	inline void set_port_4(int32_t value)
	{
		___port_4 = value;
	}

	inline static int32_t get_offset_of_path_5() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___path_5)); }
	inline String_t* get_path_5() const { return ___path_5; }
	inline String_t** get_address_of_path_5() { return &___path_5; }
	inline void set_path_5(String_t* value)
	{
		___path_5 = value;
		Il2CppCodeGenWriteBarrier(&___path_5, value);
	}

	inline static int32_t get_offset_of_query_6() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___query_6)); }
	inline String_t* get_query_6() const { return ___query_6; }
	inline String_t** get_address_of_query_6() { return &___query_6; }
	inline void set_query_6(String_t* value)
	{
		___query_6 = value;
		Il2CppCodeGenWriteBarrier(&___query_6, value);
	}

	inline static int32_t get_offset_of_fragment_7() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___fragment_7)); }
	inline String_t* get_fragment_7() const { return ___fragment_7; }
	inline String_t** get_address_of_fragment_7() { return &___fragment_7; }
	inline void set_fragment_7(String_t* value)
	{
		___fragment_7 = value;
		Il2CppCodeGenWriteBarrier(&___fragment_7, value);
	}

	inline static int32_t get_offset_of_userinfo_8() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___userinfo_8)); }
	inline String_t* get_userinfo_8() const { return ___userinfo_8; }
	inline String_t** get_address_of_userinfo_8() { return &___userinfo_8; }
	inline void set_userinfo_8(String_t* value)
	{
		___userinfo_8 = value;
		Il2CppCodeGenWriteBarrier(&___userinfo_8, value);
	}

	inline static int32_t get_offset_of_isUnc_9() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___isUnc_9)); }
	inline bool get_isUnc_9() const { return ___isUnc_9; }
	inline bool* get_address_of_isUnc_9() { return &___isUnc_9; }
	inline void set_isUnc_9(bool value)
	{
		___isUnc_9 = value;
	}

	inline static int32_t get_offset_of_isOpaquePart_10() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___isOpaquePart_10)); }
	inline bool get_isOpaquePart_10() const { return ___isOpaquePart_10; }
	inline bool* get_address_of_isOpaquePart_10() { return &___isOpaquePart_10; }
	inline void set_isOpaquePart_10(bool value)
	{
		___isOpaquePart_10 = value;
	}

	inline static int32_t get_offset_of_userEscaped_11() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___userEscaped_11)); }
	inline bool get_userEscaped_11() const { return ___userEscaped_11; }
	inline bool* get_address_of_userEscaped_11() { return &___userEscaped_11; }
	inline void set_userEscaped_11(bool value)
	{
		___userEscaped_11 = value;
	}

	inline static int32_t get_offset_of_cachedToString_12() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___cachedToString_12)); }
	inline String_t* get_cachedToString_12() const { return ___cachedToString_12; }
	inline String_t** get_address_of_cachedToString_12() { return &___cachedToString_12; }
	inline void set_cachedToString_12(String_t* value)
	{
		___cachedToString_12 = value;
		Il2CppCodeGenWriteBarrier(&___cachedToString_12, value);
	}

	inline static int32_t get_offset_of_cachedLocalPath_13() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___cachedLocalPath_13)); }
	inline String_t* get_cachedLocalPath_13() const { return ___cachedLocalPath_13; }
	inline String_t** get_address_of_cachedLocalPath_13() { return &___cachedLocalPath_13; }
	inline void set_cachedLocalPath_13(String_t* value)
	{
		___cachedLocalPath_13 = value;
		Il2CppCodeGenWriteBarrier(&___cachedLocalPath_13, value);
	}

	inline static int32_t get_offset_of_cachedHashCode_14() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___cachedHashCode_14)); }
	inline int32_t get_cachedHashCode_14() const { return ___cachedHashCode_14; }
	inline int32_t* get_address_of_cachedHashCode_14() { return &___cachedHashCode_14; }
	inline void set_cachedHashCode_14(int32_t value)
	{
		___cachedHashCode_14 = value;
	}

	inline static int32_t get_offset_of_reduce_15() { return static_cast<int32_t>(offsetof(Uri_t1510604476, ___reduce_15)); }
	inline bool get_reduce_15() const { return ___reduce_15; }
	inline bool* get_address_of_reduce_15() { return &___reduce_15; }
	inline void set_reduce_15(bool value)
	{
		___reduce_15 = value;
	}
};

struct Uri_t1510604476_StaticFields
{
public:
	// System.String Mono.Security.Uri::hexUpperChars
	String_t* ___hexUpperChars_16;
	// System.String Mono.Security.Uri::SchemeDelimiter
	String_t* ___SchemeDelimiter_17;
	// System.String Mono.Security.Uri::UriSchemeFile
	String_t* ___UriSchemeFile_18;
	// System.String Mono.Security.Uri::UriSchemeFtp
	String_t* ___UriSchemeFtp_19;
	// System.String Mono.Security.Uri::UriSchemeGopher
	String_t* ___UriSchemeGopher_20;
	// System.String Mono.Security.Uri::UriSchemeHttp
	String_t* ___UriSchemeHttp_21;
	// System.String Mono.Security.Uri::UriSchemeHttps
	String_t* ___UriSchemeHttps_22;
	// System.String Mono.Security.Uri::UriSchemeMailto
	String_t* ___UriSchemeMailto_23;
	// System.String Mono.Security.Uri::UriSchemeNews
	String_t* ___UriSchemeNews_24;
	// System.String Mono.Security.Uri::UriSchemeNntp
	String_t* ___UriSchemeNntp_25;
	// Mono.Security.Uri/UriScheme[] Mono.Security.Uri::schemes
	UriSchemeU5BU5D_t409881140* ___schemes_26;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> Mono.Security.Uri::<>f__switch$map6
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map6_27;

public:
	inline static int32_t get_offset_of_hexUpperChars_16() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___hexUpperChars_16)); }
	inline String_t* get_hexUpperChars_16() const { return ___hexUpperChars_16; }
	inline String_t** get_address_of_hexUpperChars_16() { return &___hexUpperChars_16; }
	inline void set_hexUpperChars_16(String_t* value)
	{
		___hexUpperChars_16 = value;
		Il2CppCodeGenWriteBarrier(&___hexUpperChars_16, value);
	}

	inline static int32_t get_offset_of_SchemeDelimiter_17() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___SchemeDelimiter_17)); }
	inline String_t* get_SchemeDelimiter_17() const { return ___SchemeDelimiter_17; }
	inline String_t** get_address_of_SchemeDelimiter_17() { return &___SchemeDelimiter_17; }
	inline void set_SchemeDelimiter_17(String_t* value)
	{
		___SchemeDelimiter_17 = value;
		Il2CppCodeGenWriteBarrier(&___SchemeDelimiter_17, value);
	}

	inline static int32_t get_offset_of_UriSchemeFile_18() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___UriSchemeFile_18)); }
	inline String_t* get_UriSchemeFile_18() const { return ___UriSchemeFile_18; }
	inline String_t** get_address_of_UriSchemeFile_18() { return &___UriSchemeFile_18; }
	inline void set_UriSchemeFile_18(String_t* value)
	{
		___UriSchemeFile_18 = value;
		Il2CppCodeGenWriteBarrier(&___UriSchemeFile_18, value);
	}

	inline static int32_t get_offset_of_UriSchemeFtp_19() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___UriSchemeFtp_19)); }
	inline String_t* get_UriSchemeFtp_19() const { return ___UriSchemeFtp_19; }
	inline String_t** get_address_of_UriSchemeFtp_19() { return &___UriSchemeFtp_19; }
	inline void set_UriSchemeFtp_19(String_t* value)
	{
		___UriSchemeFtp_19 = value;
		Il2CppCodeGenWriteBarrier(&___UriSchemeFtp_19, value);
	}

	inline static int32_t get_offset_of_UriSchemeGopher_20() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___UriSchemeGopher_20)); }
	inline String_t* get_UriSchemeGopher_20() const { return ___UriSchemeGopher_20; }
	inline String_t** get_address_of_UriSchemeGopher_20() { return &___UriSchemeGopher_20; }
	inline void set_UriSchemeGopher_20(String_t* value)
	{
		___UriSchemeGopher_20 = value;
		Il2CppCodeGenWriteBarrier(&___UriSchemeGopher_20, value);
	}

	inline static int32_t get_offset_of_UriSchemeHttp_21() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___UriSchemeHttp_21)); }
	inline String_t* get_UriSchemeHttp_21() const { return ___UriSchemeHttp_21; }
	inline String_t** get_address_of_UriSchemeHttp_21() { return &___UriSchemeHttp_21; }
	inline void set_UriSchemeHttp_21(String_t* value)
	{
		___UriSchemeHttp_21 = value;
		Il2CppCodeGenWriteBarrier(&___UriSchemeHttp_21, value);
	}

	inline static int32_t get_offset_of_UriSchemeHttps_22() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___UriSchemeHttps_22)); }
	inline String_t* get_UriSchemeHttps_22() const { return ___UriSchemeHttps_22; }
	inline String_t** get_address_of_UriSchemeHttps_22() { return &___UriSchemeHttps_22; }
	inline void set_UriSchemeHttps_22(String_t* value)
	{
		___UriSchemeHttps_22 = value;
		Il2CppCodeGenWriteBarrier(&___UriSchemeHttps_22, value);
	}

	inline static int32_t get_offset_of_UriSchemeMailto_23() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___UriSchemeMailto_23)); }
	inline String_t* get_UriSchemeMailto_23() const { return ___UriSchemeMailto_23; }
	inline String_t** get_address_of_UriSchemeMailto_23() { return &___UriSchemeMailto_23; }
	inline void set_UriSchemeMailto_23(String_t* value)
	{
		___UriSchemeMailto_23 = value;
		Il2CppCodeGenWriteBarrier(&___UriSchemeMailto_23, value);
	}

	inline static int32_t get_offset_of_UriSchemeNews_24() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___UriSchemeNews_24)); }
	inline String_t* get_UriSchemeNews_24() const { return ___UriSchemeNews_24; }
	inline String_t** get_address_of_UriSchemeNews_24() { return &___UriSchemeNews_24; }
	inline void set_UriSchemeNews_24(String_t* value)
	{
		___UriSchemeNews_24 = value;
		Il2CppCodeGenWriteBarrier(&___UriSchemeNews_24, value);
	}

	inline static int32_t get_offset_of_UriSchemeNntp_25() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___UriSchemeNntp_25)); }
	inline String_t* get_UriSchemeNntp_25() const { return ___UriSchemeNntp_25; }
	inline String_t** get_address_of_UriSchemeNntp_25() { return &___UriSchemeNntp_25; }
	inline void set_UriSchemeNntp_25(String_t* value)
	{
		___UriSchemeNntp_25 = value;
		Il2CppCodeGenWriteBarrier(&___UriSchemeNntp_25, value);
	}

	inline static int32_t get_offset_of_schemes_26() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___schemes_26)); }
	inline UriSchemeU5BU5D_t409881140* get_schemes_26() const { return ___schemes_26; }
	inline UriSchemeU5BU5D_t409881140** get_address_of_schemes_26() { return &___schemes_26; }
	inline void set_schemes_26(UriSchemeU5BU5D_t409881140* value)
	{
		___schemes_26 = value;
		Il2CppCodeGenWriteBarrier(&___schemes_26, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map6_27() { return static_cast<int32_t>(offsetof(Uri_t1510604476_StaticFields, ___U3CU3Ef__switchU24map6_27)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map6_27() const { return ___U3CU3Ef__switchU24map6_27; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map6_27() { return &___U3CU3Ef__switchU24map6_27; }
	inline void set_U3CU3Ef__switchU24map6_27(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map6_27 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map6_27, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
