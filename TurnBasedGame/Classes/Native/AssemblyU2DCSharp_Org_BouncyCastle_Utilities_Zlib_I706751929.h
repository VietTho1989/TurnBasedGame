#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Int32[]
struct Int32U5BU5D_t3030399641;
// Org.BouncyCastle.Utilities.Zlib.InfCodes
struct InfCodes_t2579876053;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Object
struct Il2CppObject;
// Org.BouncyCastle.Utilities.Zlib.InfTree
struct InfTree_t3604104823;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Utilities.Zlib.InfBlocks
struct  InfBlocks_t706751929  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.InfBlocks::mode
	int32_t ___mode_22;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.InfBlocks::left
	int32_t ___left_23;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.InfBlocks::table
	int32_t ___table_24;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.InfBlocks::index
	int32_t ___index_25;
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.InfBlocks::blens
	Int32U5BU5D_t3030399641* ___blens_26;
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.InfBlocks::bb
	Int32U5BU5D_t3030399641* ___bb_27;
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.InfBlocks::tb
	Int32U5BU5D_t3030399641* ___tb_28;
	// Org.BouncyCastle.Utilities.Zlib.InfCodes Org.BouncyCastle.Utilities.Zlib.InfBlocks::codes
	InfCodes_t2579876053 * ___codes_29;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.InfBlocks::last
	int32_t ___last_30;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.InfBlocks::bitk
	int32_t ___bitk_31;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.InfBlocks::bitb
	int32_t ___bitb_32;
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.InfBlocks::hufts
	Int32U5BU5D_t3030399641* ___hufts_33;
	// System.Byte[] Org.BouncyCastle.Utilities.Zlib.InfBlocks::window
	ByteU5BU5D_t3397334013* ___window_34;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.InfBlocks::end
	int32_t ___end_35;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.InfBlocks::read
	int32_t ___read_36;
	// System.Int32 Org.BouncyCastle.Utilities.Zlib.InfBlocks::write
	int32_t ___write_37;
	// System.Object Org.BouncyCastle.Utilities.Zlib.InfBlocks::checkfn
	Il2CppObject * ___checkfn_38;
	// System.Int64 Org.BouncyCastle.Utilities.Zlib.InfBlocks::check
	int64_t ___check_39;
	// Org.BouncyCastle.Utilities.Zlib.InfTree Org.BouncyCastle.Utilities.Zlib.InfBlocks::inftree
	InfTree_t3604104823 * ___inftree_40;

public:
	inline static int32_t get_offset_of_mode_22() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___mode_22)); }
	inline int32_t get_mode_22() const { return ___mode_22; }
	inline int32_t* get_address_of_mode_22() { return &___mode_22; }
	inline void set_mode_22(int32_t value)
	{
		___mode_22 = value;
	}

	inline static int32_t get_offset_of_left_23() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___left_23)); }
	inline int32_t get_left_23() const { return ___left_23; }
	inline int32_t* get_address_of_left_23() { return &___left_23; }
	inline void set_left_23(int32_t value)
	{
		___left_23 = value;
	}

	inline static int32_t get_offset_of_table_24() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___table_24)); }
	inline int32_t get_table_24() const { return ___table_24; }
	inline int32_t* get_address_of_table_24() { return &___table_24; }
	inline void set_table_24(int32_t value)
	{
		___table_24 = value;
	}

	inline static int32_t get_offset_of_index_25() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___index_25)); }
	inline int32_t get_index_25() const { return ___index_25; }
	inline int32_t* get_address_of_index_25() { return &___index_25; }
	inline void set_index_25(int32_t value)
	{
		___index_25 = value;
	}

	inline static int32_t get_offset_of_blens_26() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___blens_26)); }
	inline Int32U5BU5D_t3030399641* get_blens_26() const { return ___blens_26; }
	inline Int32U5BU5D_t3030399641** get_address_of_blens_26() { return &___blens_26; }
	inline void set_blens_26(Int32U5BU5D_t3030399641* value)
	{
		___blens_26 = value;
		Il2CppCodeGenWriteBarrier(&___blens_26, value);
	}

	inline static int32_t get_offset_of_bb_27() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___bb_27)); }
	inline Int32U5BU5D_t3030399641* get_bb_27() const { return ___bb_27; }
	inline Int32U5BU5D_t3030399641** get_address_of_bb_27() { return &___bb_27; }
	inline void set_bb_27(Int32U5BU5D_t3030399641* value)
	{
		___bb_27 = value;
		Il2CppCodeGenWriteBarrier(&___bb_27, value);
	}

	inline static int32_t get_offset_of_tb_28() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___tb_28)); }
	inline Int32U5BU5D_t3030399641* get_tb_28() const { return ___tb_28; }
	inline Int32U5BU5D_t3030399641** get_address_of_tb_28() { return &___tb_28; }
	inline void set_tb_28(Int32U5BU5D_t3030399641* value)
	{
		___tb_28 = value;
		Il2CppCodeGenWriteBarrier(&___tb_28, value);
	}

	inline static int32_t get_offset_of_codes_29() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___codes_29)); }
	inline InfCodes_t2579876053 * get_codes_29() const { return ___codes_29; }
	inline InfCodes_t2579876053 ** get_address_of_codes_29() { return &___codes_29; }
	inline void set_codes_29(InfCodes_t2579876053 * value)
	{
		___codes_29 = value;
		Il2CppCodeGenWriteBarrier(&___codes_29, value);
	}

	inline static int32_t get_offset_of_last_30() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___last_30)); }
	inline int32_t get_last_30() const { return ___last_30; }
	inline int32_t* get_address_of_last_30() { return &___last_30; }
	inline void set_last_30(int32_t value)
	{
		___last_30 = value;
	}

	inline static int32_t get_offset_of_bitk_31() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___bitk_31)); }
	inline int32_t get_bitk_31() const { return ___bitk_31; }
	inline int32_t* get_address_of_bitk_31() { return &___bitk_31; }
	inline void set_bitk_31(int32_t value)
	{
		___bitk_31 = value;
	}

	inline static int32_t get_offset_of_bitb_32() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___bitb_32)); }
	inline int32_t get_bitb_32() const { return ___bitb_32; }
	inline int32_t* get_address_of_bitb_32() { return &___bitb_32; }
	inline void set_bitb_32(int32_t value)
	{
		___bitb_32 = value;
	}

	inline static int32_t get_offset_of_hufts_33() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___hufts_33)); }
	inline Int32U5BU5D_t3030399641* get_hufts_33() const { return ___hufts_33; }
	inline Int32U5BU5D_t3030399641** get_address_of_hufts_33() { return &___hufts_33; }
	inline void set_hufts_33(Int32U5BU5D_t3030399641* value)
	{
		___hufts_33 = value;
		Il2CppCodeGenWriteBarrier(&___hufts_33, value);
	}

	inline static int32_t get_offset_of_window_34() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___window_34)); }
	inline ByteU5BU5D_t3397334013* get_window_34() const { return ___window_34; }
	inline ByteU5BU5D_t3397334013** get_address_of_window_34() { return &___window_34; }
	inline void set_window_34(ByteU5BU5D_t3397334013* value)
	{
		___window_34 = value;
		Il2CppCodeGenWriteBarrier(&___window_34, value);
	}

	inline static int32_t get_offset_of_end_35() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___end_35)); }
	inline int32_t get_end_35() const { return ___end_35; }
	inline int32_t* get_address_of_end_35() { return &___end_35; }
	inline void set_end_35(int32_t value)
	{
		___end_35 = value;
	}

	inline static int32_t get_offset_of_read_36() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___read_36)); }
	inline int32_t get_read_36() const { return ___read_36; }
	inline int32_t* get_address_of_read_36() { return &___read_36; }
	inline void set_read_36(int32_t value)
	{
		___read_36 = value;
	}

	inline static int32_t get_offset_of_write_37() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___write_37)); }
	inline int32_t get_write_37() const { return ___write_37; }
	inline int32_t* get_address_of_write_37() { return &___write_37; }
	inline void set_write_37(int32_t value)
	{
		___write_37 = value;
	}

	inline static int32_t get_offset_of_checkfn_38() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___checkfn_38)); }
	inline Il2CppObject * get_checkfn_38() const { return ___checkfn_38; }
	inline Il2CppObject ** get_address_of_checkfn_38() { return &___checkfn_38; }
	inline void set_checkfn_38(Il2CppObject * value)
	{
		___checkfn_38 = value;
		Il2CppCodeGenWriteBarrier(&___checkfn_38, value);
	}

	inline static int32_t get_offset_of_check_39() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___check_39)); }
	inline int64_t get_check_39() const { return ___check_39; }
	inline int64_t* get_address_of_check_39() { return &___check_39; }
	inline void set_check_39(int64_t value)
	{
		___check_39 = value;
	}

	inline static int32_t get_offset_of_inftree_40() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929, ___inftree_40)); }
	inline InfTree_t3604104823 * get_inftree_40() const { return ___inftree_40; }
	inline InfTree_t3604104823 ** get_address_of_inftree_40() { return &___inftree_40; }
	inline void set_inftree_40(InfTree_t3604104823 * value)
	{
		___inftree_40 = value;
		Il2CppCodeGenWriteBarrier(&___inftree_40, value);
	}
};

struct InfBlocks_t706751929_StaticFields
{
public:
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.InfBlocks::inflate_mask
	Int32U5BU5D_t3030399641* ___inflate_mask_1;
	// System.Int32[] Org.BouncyCastle.Utilities.Zlib.InfBlocks::border
	Int32U5BU5D_t3030399641* ___border_2;

public:
	inline static int32_t get_offset_of_inflate_mask_1() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929_StaticFields, ___inflate_mask_1)); }
	inline Int32U5BU5D_t3030399641* get_inflate_mask_1() const { return ___inflate_mask_1; }
	inline Int32U5BU5D_t3030399641** get_address_of_inflate_mask_1() { return &___inflate_mask_1; }
	inline void set_inflate_mask_1(Int32U5BU5D_t3030399641* value)
	{
		___inflate_mask_1 = value;
		Il2CppCodeGenWriteBarrier(&___inflate_mask_1, value);
	}

	inline static int32_t get_offset_of_border_2() { return static_cast<int32_t>(offsetof(InfBlocks_t706751929_StaticFields, ___border_2)); }
	inline Int32U5BU5D_t3030399641* get_border_2() const { return ___border_2; }
	inline Int32U5BU5D_t3030399641** get_address_of_border_2() { return &___border_2; }
	inline void set_border_2(Int32U5BU5D_t3030399641* value)
	{
		___border_2 = value;
		Il2CppCodeGenWriteBarrier(&___border_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
