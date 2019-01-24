#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.String
struct String_t;
// Org.BouncyCastle.Utilities.Zlib.Deflate
struct Deflate_t77159307;
// Org.BouncyCastle.Utilities.Zlib.Inflate
struct Inflate_t807188643;
// Org.BouncyCastle.Utilities.Zlib.Adler32
struct Adler32_t2375507285;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.Zlib.ZStream
struct  ZStream_t708755204  : public Il2CppObject
{
public:
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.ZStream::next_in
	ByteU5BU5D_t3397334013* ___next_in_17;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.ZStream::next_in_index
	int32_t ___next_in_index_18;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.ZStream::avail_in
	int32_t ___avail_in_19;
	// System.Int64 Org.BouncyCastle.Utilities.Zlib.ZStream::total_in
	int64_t ___total_in_20;
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.ZStream::next_out
	ByteU5BU5D_t3397334013* ___next_out_21;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.ZStream::next_out_index
	int32_t ___next_out_index_22;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.ZStream::avail_out
	int32_t ___avail_out_23;
	// System.Int64 Org.BouncyCastle.Utilities.Zlib.ZStream::total_out
	int64_t ___total_out_24;
	// System.String Org.BouncyCastle.Utilities.Zlib.ZStream::msg
	String_t* ___msg_25;
	// Org.BouncyCastle.Utilities.Zlib.Deflate Org.BouncyCastle.Utilities.Zlib.ZStream::dstate
	Deflate_t77159307 * ___dstate_26;
	// Org.BouncyCastle.Utilities.Zlib.Inflate Org.BouncyCastle.Utilities.Zlib.ZStream::istate
	Inflate_t807188643 * ___istate_27;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.ZStream::data_type
	int32_t ___data_type_28;
	// System.Int64 Org.BouncyCastle.Utilities.Zlib.ZStream::adler
	int64_t ___adler_29;
	// Org.BouncyCastle.Utilities.Zlib.Adler32 Org.BouncyCastle.Utilities.Zlib.ZStream::_adler
	Adler32_t2375507285 * ____adler_30;

public:
	inline static int32_t get_offset_of_next_in_17() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___next_in_17)); }
	inline ByteU5BU5D_t3397334013* get_next_in_17() const { return ___next_in_17; }
	inline ByteU5BU5D_t3397334013** get_address_of_next_in_17() { return &___next_in_17; }
	inline void set_next_in_17(ByteU5BU5D_t3397334013* value)
	{
		___next_in_17 = value;
		Il2CppCodeGenWriteBarrier(&___next_in_17, value);
	}

	inline static int32_t get_offset_of_next_in_index_18() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___next_in_index_18)); }
	inline int32_t get_next_in_index_18() const { return ___next_in_index_18; }
	inline int32_t* get_address_of_next_in_index_18() { return &___next_in_index_18; }
	inline void set_next_in_index_18(int32_t value)
	{
		___next_in_index_18 = value;
	}

	inline static int32_t get_offset_of_avail_in_19() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___avail_in_19)); }
	inline int32_t get_avail_in_19() const { return ___avail_in_19; }
	inline int32_t* get_address_of_avail_in_19() { return &___avail_in_19; }
	inline void set_avail_in_19(int32_t value)
	{
		___avail_in_19 = value;
	}

	inline static int32_t get_offset_of_total_in_20() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___total_in_20)); }
	inline int64_t get_total_in_20() const { return ___total_in_20; }
	inline int64_t* get_address_of_total_in_20() { return &___total_in_20; }
	inline void set_total_in_20(int64_t value)
	{
		___total_in_20 = value;
	}

	inline static int32_t get_offset_of_next_out_21() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___next_out_21)); }
	inline ByteU5BU5D_t3397334013* get_next_out_21() const { return ___next_out_21; }
	inline ByteU5BU5D_t3397334013** get_address_of_next_out_21() { return &___next_out_21; }
	inline void set_next_out_21(ByteU5BU5D_t3397334013* value)
	{
		___next_out_21 = value;
		Il2CppCodeGenWriteBarrier(&___next_out_21, value);
	}

	inline static int32_t get_offset_of_next_out_index_22() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___next_out_index_22)); }
	inline int32_t get_next_out_index_22() const { return ___next_out_index_22; }
	inline int32_t* get_address_of_next_out_index_22() { return &___next_out_index_22; }
	inline void set_next_out_index_22(int32_t value)
	{
		___next_out_index_22 = value;
	}

	inline static int32_t get_offset_of_avail_out_23() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___avail_out_23)); }
	inline int32_t get_avail_out_23() const { return ___avail_out_23; }
	inline int32_t* get_address_of_avail_out_23() { return &___avail_out_23; }
	inline void set_avail_out_23(int32_t value)
	{
		___avail_out_23 = value;
	}

	inline static int32_t get_offset_of_total_out_24() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___total_out_24)); }
	inline int64_t get_total_out_24() const { return ___total_out_24; }
	inline int64_t* get_address_of_total_out_24() { return &___total_out_24; }
	inline void set_total_out_24(int64_t value)
	{
		___total_out_24 = value;
	}

	inline static int32_t get_offset_of_msg_25() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___msg_25)); }
	inline String_t* get_msg_25() const { return ___msg_25; }
	inline String_t** get_address_of_msg_25() { return &___msg_25; }
	inline void set_msg_25(String_t* value)
	{
		___msg_25 = value;
		Il2CppCodeGenWriteBarrier(&___msg_25, value);
	}

	inline static int32_t get_offset_of_dstate_26() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___dstate_26)); }
	inline Deflate_t77159307 * get_dstate_26() const { return ___dstate_26; }
	inline Deflate_t77159307 ** get_address_of_dstate_26() { return &___dstate_26; }
	inline void set_dstate_26(Deflate_t77159307 * value)
	{
		___dstate_26 = value;
		Il2CppCodeGenWriteBarrier(&___dstate_26, value);
	}

	inline static int32_t get_offset_of_istate_27() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___istate_27)); }
	inline Inflate_t807188643 * get_istate_27() const { return ___istate_27; }
	inline Inflate_t807188643 ** get_address_of_istate_27() { return &___istate_27; }
	inline void set_istate_27(Inflate_t807188643 * value)
	{
		___istate_27 = value;
		Il2CppCodeGenWriteBarrier(&___istate_27, value);
	}

	inline static int32_t get_offset_of_data_type_28() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___data_type_28)); }
	inline int32_t get_data_type_28() const { return ___data_type_28; }
	inline int32_t* get_address_of_data_type_28() { return &___data_type_28; }
	inline void set_data_type_28(int32_t value)
	{
		___data_type_28 = value;
	}

	inline static int32_t get_offset_of_adler_29() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ___adler_29)); }
	inline int64_t get_adler_29() const { return ___adler_29; }
	inline int64_t* get_address_of_adler_29() { return &___adler_29; }
	inline void set_adler_29(int64_t value)
	{
		___adler_29 = value;
	}

	inline static int32_t get_offset_of__adler_30() { return static_cast<int32_t>(offsetof(ZStream_t708755204, ____adler_30)); }
	inline Adler32_t2375507285 * get__adler_30() const { return ____adler_30; }
	inline Adler32_t2375507285 ** get_address_of__adler_30() { return &____adler_30; }
	inline void set__adler_30(Adler32_t2375507285 * value)
	{
		____adler_30 = value;
		Il2CppCodeGenWriteBarrier(&____adler_30, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
