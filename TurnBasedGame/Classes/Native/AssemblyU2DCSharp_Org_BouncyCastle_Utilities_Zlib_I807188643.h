#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Int64[]
struct Int64U5BU5D_t717125112;
// Org.BouncyCastle.Utilities.Zlib.InfBlocks
struct InfBlocks_t706751929;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.Zlib.Inflate
struct  Inflate_t807188643  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Inflate::mode
	int32_t ___mode_31;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Inflate::method
	int32_t ___method_32;
	// System.Int64[] Org.BouncyCastle.Utilities.Zlib.Inflate::was
	Int64U5BU5D_t717125112* ___was_33;
	// System.Int64 Org.BouncyCastle.Utilities.Zlib.Inflate::need
	int64_t ___need_34;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Inflate::marker
	int32_t ___marker_35;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Inflate::nowrap
	int32_t ___nowrap_36;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.Inflate::wbits
	int32_t ___wbits_37;
	// Org.BouncyCastle.Utilities.Zlib.InfBlocks Org.BouncyCastle.Utilities.Zlib.Inflate::blocks
	InfBlocks_t706751929 * ___blocks_38;

public:
	inline static int32_t get_offset_of_mode_31() { return static_cast<int32_t>(offsetof(Inflate_t807188643, ___mode_31)); }
	inline int32_t get_mode_31() const { return ___mode_31; }
	inline int32_t* get_address_of_mode_31() { return &___mode_31; }
	inline void set_mode_31(int32_t value)
	{
		___mode_31 = value;
	}

	inline static int32_t get_offset_of_method_32() { return static_cast<int32_t>(offsetof(Inflate_t807188643, ___method_32)); }
	inline int32_t get_method_32() const { return ___method_32; }
	inline int32_t* get_address_of_method_32() { return &___method_32; }
	inline void set_method_32(int32_t value)
	{
		___method_32 = value;
	}

	inline static int32_t get_offset_of_was_33() { return static_cast<int32_t>(offsetof(Inflate_t807188643, ___was_33)); }
	inline Int64U5BU5D_t717125112* get_was_33() const { return ___was_33; }
	inline Int64U5BU5D_t717125112** get_address_of_was_33() { return &___was_33; }
	inline void set_was_33(Int64U5BU5D_t717125112* value)
	{
		___was_33 = value;
		Il2CppCodeGenWriteBarrier(&___was_33, value);
	}

	inline static int32_t get_offset_of_need_34() { return static_cast<int32_t>(offsetof(Inflate_t807188643, ___need_34)); }
	inline int64_t get_need_34() const { return ___need_34; }
	inline int64_t* get_address_of_need_34() { return &___need_34; }
	inline void set_need_34(int64_t value)
	{
		___need_34 = value;
	}

	inline static int32_t get_offset_of_marker_35() { return static_cast<int32_t>(offsetof(Inflate_t807188643, ___marker_35)); }
	inline int32_t get_marker_35() const { return ___marker_35; }
	inline int32_t* get_address_of_marker_35() { return &___marker_35; }
	inline void set_marker_35(int32_t value)
	{
		___marker_35 = value;
	}

	inline static int32_t get_offset_of_nowrap_36() { return static_cast<int32_t>(offsetof(Inflate_t807188643, ___nowrap_36)); }
	inline int32_t get_nowrap_36() const { return ___nowrap_36; }
	inline int32_t* get_address_of_nowrap_36() { return &___nowrap_36; }
	inline void set_nowrap_36(int32_t value)
	{
		___nowrap_36 = value;
	}

	inline static int32_t get_offset_of_wbits_37() { return static_cast<int32_t>(offsetof(Inflate_t807188643, ___wbits_37)); }
	inline int32_t get_wbits_37() const { return ___wbits_37; }
	inline int32_t* get_address_of_wbits_37() { return &___wbits_37; }
	inline void set_wbits_37(int32_t value)
	{
		___wbits_37 = value;
	}

	inline static int32_t get_offset_of_blocks_38() { return static_cast<int32_t>(offsetof(Inflate_t807188643, ___blocks_38)); }
	inline InfBlocks_t706751929 * get_blocks_38() const { return ___blocks_38; }
	inline InfBlocks_t706751929 ** get_address_of_blocks_38() { return &___blocks_38; }
	inline void set_blocks_38(InfBlocks_t706751929 * value)
	{
		___blocks_38 = value;
		Il2CppCodeGenWriteBarrier(&___blocks_38, value);
	}
};

struct Inflate_t807188643_StaticFields
{
public:
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.Inflate::mark
	ByteU5BU5D_t3397334013* ___mark_39;

public:
	inline static int32_t get_offset_of_mark_39() { return static_cast<int32_t>(offsetof(Inflate_t807188643_StaticFields, ___mark_39)); }
	inline ByteU5BU5D_t3397334013* get_mark_39() const { return ___mark_39; }
	inline ByteU5BU5D_t3397334013** get_address_of_mark_39() { return &___mark_39; }
	inline void set_mark_39(ByteU5BU5D_t3397334013* value)
	{
		___mark_39 = value;
		Il2CppCodeGenWriteBarrier(&___mark_39, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
