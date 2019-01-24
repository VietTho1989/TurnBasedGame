#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Text_Encoding663144255.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Text.UnicodeEncoding
struct  UnicodeEncoding_t4081757012  : public Encoding_t663144255
{
public:
	// System.Boolean System.Text.UnicodeEncoding::bigEndian
	bool ___bigEndian_29;
	// System.Boolean System.Text.UnicodeEncoding::byteOrderMark
	bool ___byteOrderMark_30;

public:
	inline static int32_t get_offset_of_bigEndian_29() { return static_cast<int32_t>(offsetof(UnicodeEncoding_t4081757012, ___bigEndian_29)); }
	inline bool get_bigEndian_29() const { return ___bigEndian_29; }
	inline bool* get_address_of_bigEndian_29() { return &___bigEndian_29; }
	inline void set_bigEndian_29(bool value)
	{
		___bigEndian_29 = value;
	}

	inline static int32_t get_offset_of_byteOrderMark_30() { return static_cast<int32_t>(offsetof(UnicodeEncoding_t4081757012, ___byteOrderMark_30)); }
	inline bool get_byteOrderMark_30() const { return ___byteOrderMark_30; }
	inline bool* get_address_of_byteOrderMark_30() { return &___byteOrderMark_30; }
	inline void set_byteOrderMark_30(bool value)
	{
		___byteOrderMark_30 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
