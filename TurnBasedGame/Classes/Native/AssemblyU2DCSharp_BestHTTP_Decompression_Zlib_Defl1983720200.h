#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_Decompression_Zlib_Comp4151391442.h"
#include "AssemblyU2DCSharp_BestHTTP_Decompression_Zlib_Comp2530143933.h"

// BestHTTP.Decompression.Zlib.DeflateManager/CompressFunc
struct CompressFunc_t4191606113;
// System.String[]
struct StringU5BU5D_t1642385972;
// BestHTTP.Decompression.Zlib.ZlibCodec
struct ZlibCodec_t1899545627;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Int16[]
struct Int16U5BU5D_t3104283263;
// BestHTTP.Decompression.Zlib.DeflateManager/Config
struct Config_t3381668151;
// BestHTTP.Decompression.Zlib.ZTree
struct ZTree_t1042194920;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// System.SByte[]
struct SByteU5BU5D_t3472287392;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Decompression.Zlib.DeflateManager
struct  DeflateManager_t1983720200  : public Il2CppObject
{
public:
	// BestHTTP.Decompression.Zlib.DeflateManager/CompressFunc BestHTTP.Decompression.Zlib.DeflateManager::DeflateFunction
	CompressFunc_t4191606113 * ___DeflateFunction_2;
	// BestHTTP.Decompression.Zlib.ZlibCodec BestHTTP.Decompression.Zlib.DeflateManager::_codec
	ZlibCodec_t1899545627 * ____codec_21;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::status
	int32_t ___status_22;
	// System.Byte[] BestHTTP.Decompression.Zlib.DeflateManager::pending
	ByteU5BU5D_t3397334013* ___pending_23;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::nextPending
	int32_t ___nextPending_24;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::pendingCount
	int32_t ___pendingCount_25;
	// System.SByte BestHTTP.Decompression.Zlib.DeflateManager::data_type
	int8_t ___data_type_26;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::last_flush
	int32_t ___last_flush_27;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::w_size
	int32_t ___w_size_28;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::w_bits
	int32_t ___w_bits_29;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::w_mask
	int32_t ___w_mask_30;
	// System.Byte[] BestHTTP.Decompression.Zlib.DeflateManager::window
	ByteU5BU5D_t3397334013* ___window_31;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::window_size
	int32_t ___window_size_32;
	// System.Int16[] BestHTTP.Decompression.Zlib.DeflateManager::prev
	Int16U5BU5D_t3104283263* ___prev_33;
	// System.Int16[] BestHTTP.Decompression.Zlib.DeflateManager::head
	Int16U5BU5D_t3104283263* ___head_34;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::ins_h
	int32_t ___ins_h_35;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::hash_size
	int32_t ___hash_size_36;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::hash_bits
	int32_t ___hash_bits_37;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::hash_mask
	int32_t ___hash_mask_38;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::hash_shift
	int32_t ___hash_shift_39;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::block_start
	int32_t ___block_start_40;
	// BestHTTP.Decompression.Zlib.DeflateManager/Config BestHTTP.Decompression.Zlib.DeflateManager::config
	Config_t3381668151 * ___config_41;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::match_length
	int32_t ___match_length_42;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::prev_match
	int32_t ___prev_match_43;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::match_available
	int32_t ___match_available_44;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::strstart
	int32_t ___strstart_45;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::match_start
	int32_t ___match_start_46;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::lookahead
	int32_t ___lookahead_47;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::prev_length
	int32_t ___prev_length_48;
	// BestHTTP.Decompression.Zlib.CompressionLevel BestHTTP.Decompression.Zlib.DeflateManager::compressionLevel
	int32_t ___compressionLevel_49;
	// BestHTTP.Decompression.Zlib.CompressionStrategy BestHTTP.Decompression.Zlib.DeflateManager::compressionStrategy
	int32_t ___compressionStrategy_50;
	// System.Int16[] BestHTTP.Decompression.Zlib.DeflateManager::dyn_ltree
	Int16U5BU5D_t3104283263* ___dyn_ltree_51;
	// System.Int16[] BestHTTP.Decompression.Zlib.DeflateManager::dyn_dtree
	Int16U5BU5D_t3104283263* ___dyn_dtree_52;
	// System.Int16[] BestHTTP.Decompression.Zlib.DeflateManager::bl_tree
	Int16U5BU5D_t3104283263* ___bl_tree_53;
	// BestHTTP.Decompression.Zlib.ZTree BestHTTP.Decompression.Zlib.DeflateManager::treeLiterals
	ZTree_t1042194920 * ___treeLiterals_54;
	// BestHTTP.Decompression.Zlib.ZTree BestHTTP.Decompression.Zlib.DeflateManager::treeDistances
	ZTree_t1042194920 * ___treeDistances_55;
	// BestHTTP.Decompression.Zlib.ZTree BestHTTP.Decompression.Zlib.DeflateManager::treeBitLengths
	ZTree_t1042194920 * ___treeBitLengths_56;
	// System.Int16[] BestHTTP.Decompression.Zlib.DeflateManager::bl_count
	Int16U5BU5D_t3104283263* ___bl_count_57;
	// System.Int32[] BestHTTP.Decompression.Zlib.DeflateManager::heap
	Int32U5BU5D_t3030399641* ___heap_58;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::heap_len
	int32_t ___heap_len_59;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::heap_max
	int32_t ___heap_max_60;
	// System.SByte[] BestHTTP.Decompression.Zlib.DeflateManager::depth
	SByteU5BU5D_t3472287392* ___depth_61;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::_lengthOffset
	int32_t ____lengthOffset_62;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::lit_bufsize
	int32_t ___lit_bufsize_63;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::last_lit
	int32_t ___last_lit_64;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::_distanceOffset
	int32_t ____distanceOffset_65;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::opt_len
	int32_t ___opt_len_66;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::static_len
	int32_t ___static_len_67;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::matches
	int32_t ___matches_68;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::last_eob_len
	int32_t ___last_eob_len_69;
	// System.Int16 BestHTTP.Decompression.Zlib.DeflateManager::bi_buf
	int16_t ___bi_buf_70;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::bi_valid
	int32_t ___bi_valid_71;
	// System.Boolean BestHTTP.Decompression.Zlib.DeflateManager::Rfc1950BytesEmitted
	bool ___Rfc1950BytesEmitted_72;
	// System.Boolean BestHTTP.Decompression.Zlib.DeflateManager::_WantRfc1950HeaderBytes
	bool ____WantRfc1950HeaderBytes_73;

public:
	inline static int32_t get_offset_of_DeflateFunction_2() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___DeflateFunction_2)); }
	inline CompressFunc_t4191606113 * get_DeflateFunction_2() const { return ___DeflateFunction_2; }
	inline CompressFunc_t4191606113 ** get_address_of_DeflateFunction_2() { return &___DeflateFunction_2; }
	inline void set_DeflateFunction_2(CompressFunc_t4191606113 * value)
	{
		___DeflateFunction_2 = value;
		Il2CppCodeGenWriteBarrier(&___DeflateFunction_2, value);
	}

	inline static int32_t get_offset_of__codec_21() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ____codec_21)); }
	inline ZlibCodec_t1899545627 * get__codec_21() const { return ____codec_21; }
	inline ZlibCodec_t1899545627 ** get_address_of__codec_21() { return &____codec_21; }
	inline void set__codec_21(ZlibCodec_t1899545627 * value)
	{
		____codec_21 = value;
		Il2CppCodeGenWriteBarrier(&____codec_21, value);
	}

	inline static int32_t get_offset_of_status_22() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___status_22)); }
	inline int32_t get_status_22() const { return ___status_22; }
	inline int32_t* get_address_of_status_22() { return &___status_22; }
	inline void set_status_22(int32_t value)
	{
		___status_22 = value;
	}

	inline static int32_t get_offset_of_pending_23() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___pending_23)); }
	inline ByteU5BU5D_t3397334013* get_pending_23() const { return ___pending_23; }
	inline ByteU5BU5D_t3397334013** get_address_of_pending_23() { return &___pending_23; }
	inline void set_pending_23(ByteU5BU5D_t3397334013* value)
	{
		___pending_23 = value;
		Il2CppCodeGenWriteBarrier(&___pending_23, value);
	}

	inline static int32_t get_offset_of_nextPending_24() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___nextPending_24)); }
	inline int32_t get_nextPending_24() const { return ___nextPending_24; }
	inline int32_t* get_address_of_nextPending_24() { return &___nextPending_24; }
	inline void set_nextPending_24(int32_t value)
	{
		___nextPending_24 = value;
	}

	inline static int32_t get_offset_of_pendingCount_25() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___pendingCount_25)); }
	inline int32_t get_pendingCount_25() const { return ___pendingCount_25; }
	inline int32_t* get_address_of_pendingCount_25() { return &___pendingCount_25; }
	inline void set_pendingCount_25(int32_t value)
	{
		___pendingCount_25 = value;
	}

	inline static int32_t get_offset_of_data_type_26() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___data_type_26)); }
	inline int8_t get_data_type_26() const { return ___data_type_26; }
	inline int8_t* get_address_of_data_type_26() { return &___data_type_26; }
	inline void set_data_type_26(int8_t value)
	{
		___data_type_26 = value;
	}

	inline static int32_t get_offset_of_last_flush_27() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___last_flush_27)); }
	inline int32_t get_last_flush_27() const { return ___last_flush_27; }
	inline int32_t* get_address_of_last_flush_27() { return &___last_flush_27; }
	inline void set_last_flush_27(int32_t value)
	{
		___last_flush_27 = value;
	}

	inline static int32_t get_offset_of_w_size_28() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___w_size_28)); }
	inline int32_t get_w_size_28() const { return ___w_size_28; }
	inline int32_t* get_address_of_w_size_28() { return &___w_size_28; }
	inline void set_w_size_28(int32_t value)
	{
		___w_size_28 = value;
	}

	inline static int32_t get_offset_of_w_bits_29() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___w_bits_29)); }
	inline int32_t get_w_bits_29() const { return ___w_bits_29; }
	inline int32_t* get_address_of_w_bits_29() { return &___w_bits_29; }
	inline void set_w_bits_29(int32_t value)
	{
		___w_bits_29 = value;
	}

	inline static int32_t get_offset_of_w_mask_30() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___w_mask_30)); }
	inline int32_t get_w_mask_30() const { return ___w_mask_30; }
	inline int32_t* get_address_of_w_mask_30() { return &___w_mask_30; }
	inline void set_w_mask_30(int32_t value)
	{
		___w_mask_30 = value;
	}

	inline static int32_t get_offset_of_window_31() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___window_31)); }
	inline ByteU5BU5D_t3397334013* get_window_31() const { return ___window_31; }
	inline ByteU5BU5D_t3397334013** get_address_of_window_31() { return &___window_31; }
	inline void set_window_31(ByteU5BU5D_t3397334013* value)
	{
		___window_31 = value;
		Il2CppCodeGenWriteBarrier(&___window_31, value);
	}

	inline static int32_t get_offset_of_window_size_32() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___window_size_32)); }
	inline int32_t get_window_size_32() const { return ___window_size_32; }
	inline int32_t* get_address_of_window_size_32() { return &___window_size_32; }
	inline void set_window_size_32(int32_t value)
	{
		___window_size_32 = value;
	}

	inline static int32_t get_offset_of_prev_33() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___prev_33)); }
	inline Int16U5BU5D_t3104283263* get_prev_33() const { return ___prev_33; }
	inline Int16U5BU5D_t3104283263** get_address_of_prev_33() { return &___prev_33; }
	inline void set_prev_33(Int16U5BU5D_t3104283263* value)
	{
		___prev_33 = value;
		Il2CppCodeGenWriteBarrier(&___prev_33, value);
	}

	inline static int32_t get_offset_of_head_34() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___head_34)); }
	inline Int16U5BU5D_t3104283263* get_head_34() const { return ___head_34; }
	inline Int16U5BU5D_t3104283263** get_address_of_head_34() { return &___head_34; }
	inline void set_head_34(Int16U5BU5D_t3104283263* value)
	{
		___head_34 = value;
		Il2CppCodeGenWriteBarrier(&___head_34, value);
	}

	inline static int32_t get_offset_of_ins_h_35() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___ins_h_35)); }
	inline int32_t get_ins_h_35() const { return ___ins_h_35; }
	inline int32_t* get_address_of_ins_h_35() { return &___ins_h_35; }
	inline void set_ins_h_35(int32_t value)
	{
		___ins_h_35 = value;
	}

	inline static int32_t get_offset_of_hash_size_36() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___hash_size_36)); }
	inline int32_t get_hash_size_36() const { return ___hash_size_36; }
	inline int32_t* get_address_of_hash_size_36() { return &___hash_size_36; }
	inline void set_hash_size_36(int32_t value)
	{
		___hash_size_36 = value;
	}

	inline static int32_t get_offset_of_hash_bits_37() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___hash_bits_37)); }
	inline int32_t get_hash_bits_37() const { return ___hash_bits_37; }
	inline int32_t* get_address_of_hash_bits_37() { return &___hash_bits_37; }
	inline void set_hash_bits_37(int32_t value)
	{
		___hash_bits_37 = value;
	}

	inline static int32_t get_offset_of_hash_mask_38() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___hash_mask_38)); }
	inline int32_t get_hash_mask_38() const { return ___hash_mask_38; }
	inline int32_t* get_address_of_hash_mask_38() { return &___hash_mask_38; }
	inline void set_hash_mask_38(int32_t value)
	{
		___hash_mask_38 = value;
	}

	inline static int32_t get_offset_of_hash_shift_39() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___hash_shift_39)); }
	inline int32_t get_hash_shift_39() const { return ___hash_shift_39; }
	inline int32_t* get_address_of_hash_shift_39() { return &___hash_shift_39; }
	inline void set_hash_shift_39(int32_t value)
	{
		___hash_shift_39 = value;
	}

	inline static int32_t get_offset_of_block_start_40() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___block_start_40)); }
	inline int32_t get_block_start_40() const { return ___block_start_40; }
	inline int32_t* get_address_of_block_start_40() { return &___block_start_40; }
	inline void set_block_start_40(int32_t value)
	{
		___block_start_40 = value;
	}

	inline static int32_t get_offset_of_config_41() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___config_41)); }
	inline Config_t3381668151 * get_config_41() const { return ___config_41; }
	inline Config_t3381668151 ** get_address_of_config_41() { return &___config_41; }
	inline void set_config_41(Config_t3381668151 * value)
	{
		___config_41 = value;
		Il2CppCodeGenWriteBarrier(&___config_41, value);
	}

	inline static int32_t get_offset_of_match_length_42() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___match_length_42)); }
	inline int32_t get_match_length_42() const { return ___match_length_42; }
	inline int32_t* get_address_of_match_length_42() { return &___match_length_42; }
	inline void set_match_length_42(int32_t value)
	{
		___match_length_42 = value;
	}

	inline static int32_t get_offset_of_prev_match_43() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___prev_match_43)); }
	inline int32_t get_prev_match_43() const { return ___prev_match_43; }
	inline int32_t* get_address_of_prev_match_43() { return &___prev_match_43; }
	inline void set_prev_match_43(int32_t value)
	{
		___prev_match_43 = value;
	}

	inline static int32_t get_offset_of_match_available_44() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___match_available_44)); }
	inline int32_t get_match_available_44() const { return ___match_available_44; }
	inline int32_t* get_address_of_match_available_44() { return &___match_available_44; }
	inline void set_match_available_44(int32_t value)
	{
		___match_available_44 = value;
	}

	inline static int32_t get_offset_of_strstart_45() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___strstart_45)); }
	inline int32_t get_strstart_45() const { return ___strstart_45; }
	inline int32_t* get_address_of_strstart_45() { return &___strstart_45; }
	inline void set_strstart_45(int32_t value)
	{
		___strstart_45 = value;
	}

	inline static int32_t get_offset_of_match_start_46() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___match_start_46)); }
	inline int32_t get_match_start_46() const { return ___match_start_46; }
	inline int32_t* get_address_of_match_start_46() { return &___match_start_46; }
	inline void set_match_start_46(int32_t value)
	{
		___match_start_46 = value;
	}

	inline static int32_t get_offset_of_lookahead_47() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___lookahead_47)); }
	inline int32_t get_lookahead_47() const { return ___lookahead_47; }
	inline int32_t* get_address_of_lookahead_47() { return &___lookahead_47; }
	inline void set_lookahead_47(int32_t value)
	{
		___lookahead_47 = value;
	}

	inline static int32_t get_offset_of_prev_length_48() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___prev_length_48)); }
	inline int32_t get_prev_length_48() const { return ___prev_length_48; }
	inline int32_t* get_address_of_prev_length_48() { return &___prev_length_48; }
	inline void set_prev_length_48(int32_t value)
	{
		___prev_length_48 = value;
	}

	inline static int32_t get_offset_of_compressionLevel_49() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___compressionLevel_49)); }
	inline int32_t get_compressionLevel_49() const { return ___compressionLevel_49; }
	inline int32_t* get_address_of_compressionLevel_49() { return &___compressionLevel_49; }
	inline void set_compressionLevel_49(int32_t value)
	{
		___compressionLevel_49 = value;
	}

	inline static int32_t get_offset_of_compressionStrategy_50() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___compressionStrategy_50)); }
	inline int32_t get_compressionStrategy_50() const { return ___compressionStrategy_50; }
	inline int32_t* get_address_of_compressionStrategy_50() { return &___compressionStrategy_50; }
	inline void set_compressionStrategy_50(int32_t value)
	{
		___compressionStrategy_50 = value;
	}

	inline static int32_t get_offset_of_dyn_ltree_51() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___dyn_ltree_51)); }
	inline Int16U5BU5D_t3104283263* get_dyn_ltree_51() const { return ___dyn_ltree_51; }
	inline Int16U5BU5D_t3104283263** get_address_of_dyn_ltree_51() { return &___dyn_ltree_51; }
	inline void set_dyn_ltree_51(Int16U5BU5D_t3104283263* value)
	{
		___dyn_ltree_51 = value;
		Il2CppCodeGenWriteBarrier(&___dyn_ltree_51, value);
	}

	inline static int32_t get_offset_of_dyn_dtree_52() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___dyn_dtree_52)); }
	inline Int16U5BU5D_t3104283263* get_dyn_dtree_52() const { return ___dyn_dtree_52; }
	inline Int16U5BU5D_t3104283263** get_address_of_dyn_dtree_52() { return &___dyn_dtree_52; }
	inline void set_dyn_dtree_52(Int16U5BU5D_t3104283263* value)
	{
		___dyn_dtree_52 = value;
		Il2CppCodeGenWriteBarrier(&___dyn_dtree_52, value);
	}

	inline static int32_t get_offset_of_bl_tree_53() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___bl_tree_53)); }
	inline Int16U5BU5D_t3104283263* get_bl_tree_53() const { return ___bl_tree_53; }
	inline Int16U5BU5D_t3104283263** get_address_of_bl_tree_53() { return &___bl_tree_53; }
	inline void set_bl_tree_53(Int16U5BU5D_t3104283263* value)
	{
		___bl_tree_53 = value;
		Il2CppCodeGenWriteBarrier(&___bl_tree_53, value);
	}

	inline static int32_t get_offset_of_treeLiterals_54() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___treeLiterals_54)); }
	inline ZTree_t1042194920 * get_treeLiterals_54() const { return ___treeLiterals_54; }
	inline ZTree_t1042194920 ** get_address_of_treeLiterals_54() { return &___treeLiterals_54; }
	inline void set_treeLiterals_54(ZTree_t1042194920 * value)
	{
		___treeLiterals_54 = value;
		Il2CppCodeGenWriteBarrier(&___treeLiterals_54, value);
	}

	inline static int32_t get_offset_of_treeDistances_55() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___treeDistances_55)); }
	inline ZTree_t1042194920 * get_treeDistances_55() const { return ___treeDistances_55; }
	inline ZTree_t1042194920 ** get_address_of_treeDistances_55() { return &___treeDistances_55; }
	inline void set_treeDistances_55(ZTree_t1042194920 * value)
	{
		___treeDistances_55 = value;
		Il2CppCodeGenWriteBarrier(&___treeDistances_55, value);
	}

	inline static int32_t get_offset_of_treeBitLengths_56() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___treeBitLengths_56)); }
	inline ZTree_t1042194920 * get_treeBitLengths_56() const { return ___treeBitLengths_56; }
	inline ZTree_t1042194920 ** get_address_of_treeBitLengths_56() { return &___treeBitLengths_56; }
	inline void set_treeBitLengths_56(ZTree_t1042194920 * value)
	{
		___treeBitLengths_56 = value;
		Il2CppCodeGenWriteBarrier(&___treeBitLengths_56, value);
	}

	inline static int32_t get_offset_of_bl_count_57() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___bl_count_57)); }
	inline Int16U5BU5D_t3104283263* get_bl_count_57() const { return ___bl_count_57; }
	inline Int16U5BU5D_t3104283263** get_address_of_bl_count_57() { return &___bl_count_57; }
	inline void set_bl_count_57(Int16U5BU5D_t3104283263* value)
	{
		___bl_count_57 = value;
		Il2CppCodeGenWriteBarrier(&___bl_count_57, value);
	}

	inline static int32_t get_offset_of_heap_58() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___heap_58)); }
	inline Int32U5BU5D_t3030399641* get_heap_58() const { return ___heap_58; }
	inline Int32U5BU5D_t3030399641** get_address_of_heap_58() { return &___heap_58; }
	inline void set_heap_58(Int32U5BU5D_t3030399641* value)
	{
		___heap_58 = value;
		Il2CppCodeGenWriteBarrier(&___heap_58, value);
	}

	inline static int32_t get_offset_of_heap_len_59() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___heap_len_59)); }
	inline int32_t get_heap_len_59() const { return ___heap_len_59; }
	inline int32_t* get_address_of_heap_len_59() { return &___heap_len_59; }
	inline void set_heap_len_59(int32_t value)
	{
		___heap_len_59 = value;
	}

	inline static int32_t get_offset_of_heap_max_60() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___heap_max_60)); }
	inline int32_t get_heap_max_60() const { return ___heap_max_60; }
	inline int32_t* get_address_of_heap_max_60() { return &___heap_max_60; }
	inline void set_heap_max_60(int32_t value)
	{
		___heap_max_60 = value;
	}

	inline static int32_t get_offset_of_depth_61() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___depth_61)); }
	inline SByteU5BU5D_t3472287392* get_depth_61() const { return ___depth_61; }
	inline SByteU5BU5D_t3472287392** get_address_of_depth_61() { return &___depth_61; }
	inline void set_depth_61(SByteU5BU5D_t3472287392* value)
	{
		___depth_61 = value;
		Il2CppCodeGenWriteBarrier(&___depth_61, value);
	}

	inline static int32_t get_offset_of__lengthOffset_62() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ____lengthOffset_62)); }
	inline int32_t get__lengthOffset_62() const { return ____lengthOffset_62; }
	inline int32_t* get_address_of__lengthOffset_62() { return &____lengthOffset_62; }
	inline void set__lengthOffset_62(int32_t value)
	{
		____lengthOffset_62 = value;
	}

	inline static int32_t get_offset_of_lit_bufsize_63() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___lit_bufsize_63)); }
	inline int32_t get_lit_bufsize_63() const { return ___lit_bufsize_63; }
	inline int32_t* get_address_of_lit_bufsize_63() { return &___lit_bufsize_63; }
	inline void set_lit_bufsize_63(int32_t value)
	{
		___lit_bufsize_63 = value;
	}

	inline static int32_t get_offset_of_last_lit_64() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___last_lit_64)); }
	inline int32_t get_last_lit_64() const { return ___last_lit_64; }
	inline int32_t* get_address_of_last_lit_64() { return &___last_lit_64; }
	inline void set_last_lit_64(int32_t value)
	{
		___last_lit_64 = value;
	}

	inline static int32_t get_offset_of__distanceOffset_65() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ____distanceOffset_65)); }
	inline int32_t get__distanceOffset_65() const { return ____distanceOffset_65; }
	inline int32_t* get_address_of__distanceOffset_65() { return &____distanceOffset_65; }
	inline void set__distanceOffset_65(int32_t value)
	{
		____distanceOffset_65 = value;
	}

	inline static int32_t get_offset_of_opt_len_66() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___opt_len_66)); }
	inline int32_t get_opt_len_66() const { return ___opt_len_66; }
	inline int32_t* get_address_of_opt_len_66() { return &___opt_len_66; }
	inline void set_opt_len_66(int32_t value)
	{
		___opt_len_66 = value;
	}

	inline static int32_t get_offset_of_static_len_67() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___static_len_67)); }
	inline int32_t get_static_len_67() const { return ___static_len_67; }
	inline int32_t* get_address_of_static_len_67() { return &___static_len_67; }
	inline void set_static_len_67(int32_t value)
	{
		___static_len_67 = value;
	}

	inline static int32_t get_offset_of_matches_68() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___matches_68)); }
	inline int32_t get_matches_68() const { return ___matches_68; }
	inline int32_t* get_address_of_matches_68() { return &___matches_68; }
	inline void set_matches_68(int32_t value)
	{
		___matches_68 = value;
	}

	inline static int32_t get_offset_of_last_eob_len_69() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___last_eob_len_69)); }
	inline int32_t get_last_eob_len_69() const { return ___last_eob_len_69; }
	inline int32_t* get_address_of_last_eob_len_69() { return &___last_eob_len_69; }
	inline void set_last_eob_len_69(int32_t value)
	{
		___last_eob_len_69 = value;
	}

	inline static int32_t get_offset_of_bi_buf_70() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___bi_buf_70)); }
	inline int16_t get_bi_buf_70() const { return ___bi_buf_70; }
	inline int16_t* get_address_of_bi_buf_70() { return &___bi_buf_70; }
	inline void set_bi_buf_70(int16_t value)
	{
		___bi_buf_70 = value;
	}

	inline static int32_t get_offset_of_bi_valid_71() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___bi_valid_71)); }
	inline int32_t get_bi_valid_71() const { return ___bi_valid_71; }
	inline int32_t* get_address_of_bi_valid_71() { return &___bi_valid_71; }
	inline void set_bi_valid_71(int32_t value)
	{
		___bi_valid_71 = value;
	}

	inline static int32_t get_offset_of_Rfc1950BytesEmitted_72() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ___Rfc1950BytesEmitted_72)); }
	inline bool get_Rfc1950BytesEmitted_72() const { return ___Rfc1950BytesEmitted_72; }
	inline bool* get_address_of_Rfc1950BytesEmitted_72() { return &___Rfc1950BytesEmitted_72; }
	inline void set_Rfc1950BytesEmitted_72(bool value)
	{
		___Rfc1950BytesEmitted_72 = value;
	}

	inline static int32_t get_offset_of__WantRfc1950HeaderBytes_73() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200, ____WantRfc1950HeaderBytes_73)); }
	inline bool get__WantRfc1950HeaderBytes_73() const { return ____WantRfc1950HeaderBytes_73; }
	inline bool* get_address_of__WantRfc1950HeaderBytes_73() { return &____WantRfc1950HeaderBytes_73; }
	inline void set__WantRfc1950HeaderBytes_73(bool value)
	{
		____WantRfc1950HeaderBytes_73 = value;
	}
};

struct DeflateManager_t1983720200_StaticFields
{
public:
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::MEM_LEVEL_MAX
	int32_t ___MEM_LEVEL_MAX_0;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::MEM_LEVEL_DEFAULT
	int32_t ___MEM_LEVEL_DEFAULT_1;
	// System.String[] BestHTTP.Decompression.Zlib.DeflateManager::_ErrorMessage
	StringU5BU5D_t1642385972* ____ErrorMessage_3;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::PRESET_DICT
	int32_t ___PRESET_DICT_4;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::INIT_STATE
	int32_t ___INIT_STATE_5;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::BUSY_STATE
	int32_t ___BUSY_STATE_6;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::FINISH_STATE
	int32_t ___FINISH_STATE_7;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::Z_DEFLATED
	int32_t ___Z_DEFLATED_8;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::STORED_BLOCK
	int32_t ___STORED_BLOCK_9;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::STATIC_TREES
	int32_t ___STATIC_TREES_10;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::DYN_TREES
	int32_t ___DYN_TREES_11;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::Z_BINARY
	int32_t ___Z_BINARY_12;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::Z_ASCII
	int32_t ___Z_ASCII_13;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::Z_UNKNOWN
	int32_t ___Z_UNKNOWN_14;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::Buf_size
	int32_t ___Buf_size_15;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::MIN_MATCH
	int32_t ___MIN_MATCH_16;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::MAX_MATCH
	int32_t ___MAX_MATCH_17;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::MIN_LOOKAHEAD
	int32_t ___MIN_LOOKAHEAD_18;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::HEAP_SIZE
	int32_t ___HEAP_SIZE_19;
	// System.Int32 BestHTTP.Decompression.Zlib.DeflateManager::END_BLOCK
	int32_t ___END_BLOCK_20;

public:
	inline static int32_t get_offset_of_MEM_LEVEL_MAX_0() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___MEM_LEVEL_MAX_0)); }
	inline int32_t get_MEM_LEVEL_MAX_0() const { return ___MEM_LEVEL_MAX_0; }
	inline int32_t* get_address_of_MEM_LEVEL_MAX_0() { return &___MEM_LEVEL_MAX_0; }
	inline void set_MEM_LEVEL_MAX_0(int32_t value)
	{
		___MEM_LEVEL_MAX_0 = value;
	}

	inline static int32_t get_offset_of_MEM_LEVEL_DEFAULT_1() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___MEM_LEVEL_DEFAULT_1)); }
	inline int32_t get_MEM_LEVEL_DEFAULT_1() const { return ___MEM_LEVEL_DEFAULT_1; }
	inline int32_t* get_address_of_MEM_LEVEL_DEFAULT_1() { return &___MEM_LEVEL_DEFAULT_1; }
	inline void set_MEM_LEVEL_DEFAULT_1(int32_t value)
	{
		___MEM_LEVEL_DEFAULT_1 = value;
	}

	inline static int32_t get_offset_of__ErrorMessage_3() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ____ErrorMessage_3)); }
	inline StringU5BU5D_t1642385972* get__ErrorMessage_3() const { return ____ErrorMessage_3; }
	inline StringU5BU5D_t1642385972** get_address_of__ErrorMessage_3() { return &____ErrorMessage_3; }
	inline void set__ErrorMessage_3(StringU5BU5D_t1642385972* value)
	{
		____ErrorMessage_3 = value;
		Il2CppCodeGenWriteBarrier(&____ErrorMessage_3, value);
	}

	inline static int32_t get_offset_of_PRESET_DICT_4() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___PRESET_DICT_4)); }
	inline int32_t get_PRESET_DICT_4() const { return ___PRESET_DICT_4; }
	inline int32_t* get_address_of_PRESET_DICT_4() { return &___PRESET_DICT_4; }
	inline void set_PRESET_DICT_4(int32_t value)
	{
		___PRESET_DICT_4 = value;
	}

	inline static int32_t get_offset_of_INIT_STATE_5() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___INIT_STATE_5)); }
	inline int32_t get_INIT_STATE_5() const { return ___INIT_STATE_5; }
	inline int32_t* get_address_of_INIT_STATE_5() { return &___INIT_STATE_5; }
	inline void set_INIT_STATE_5(int32_t value)
	{
		___INIT_STATE_5 = value;
	}

	inline static int32_t get_offset_of_BUSY_STATE_6() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___BUSY_STATE_6)); }
	inline int32_t get_BUSY_STATE_6() const { return ___BUSY_STATE_6; }
	inline int32_t* get_address_of_BUSY_STATE_6() { return &___BUSY_STATE_6; }
	inline void set_BUSY_STATE_6(int32_t value)
	{
		___BUSY_STATE_6 = value;
	}

	inline static int32_t get_offset_of_FINISH_STATE_7() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___FINISH_STATE_7)); }
	inline int32_t get_FINISH_STATE_7() const { return ___FINISH_STATE_7; }
	inline int32_t* get_address_of_FINISH_STATE_7() { return &___FINISH_STATE_7; }
	inline void set_FINISH_STATE_7(int32_t value)
	{
		___FINISH_STATE_7 = value;
	}

	inline static int32_t get_offset_of_Z_DEFLATED_8() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___Z_DEFLATED_8)); }
	inline int32_t get_Z_DEFLATED_8() const { return ___Z_DEFLATED_8; }
	inline int32_t* get_address_of_Z_DEFLATED_8() { return &___Z_DEFLATED_8; }
	inline void set_Z_DEFLATED_8(int32_t value)
	{
		___Z_DEFLATED_8 = value;
	}

	inline static int32_t get_offset_of_STORED_BLOCK_9() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___STORED_BLOCK_9)); }
	inline int32_t get_STORED_BLOCK_9() const { return ___STORED_BLOCK_9; }
	inline int32_t* get_address_of_STORED_BLOCK_9() { return &___STORED_BLOCK_9; }
	inline void set_STORED_BLOCK_9(int32_t value)
	{
		___STORED_BLOCK_9 = value;
	}

	inline static int32_t get_offset_of_STATIC_TREES_10() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___STATIC_TREES_10)); }
	inline int32_t get_STATIC_TREES_10() const { return ___STATIC_TREES_10; }
	inline int32_t* get_address_of_STATIC_TREES_10() { return &___STATIC_TREES_10; }
	inline void set_STATIC_TREES_10(int32_t value)
	{
		___STATIC_TREES_10 = value;
	}

	inline static int32_t get_offset_of_DYN_TREES_11() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___DYN_TREES_11)); }
	inline int32_t get_DYN_TREES_11() const { return ___DYN_TREES_11; }
	inline int32_t* get_address_of_DYN_TREES_11() { return &___DYN_TREES_11; }
	inline void set_DYN_TREES_11(int32_t value)
	{
		___DYN_TREES_11 = value;
	}

	inline static int32_t get_offset_of_Z_BINARY_12() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___Z_BINARY_12)); }
	inline int32_t get_Z_BINARY_12() const { return ___Z_BINARY_12; }
	inline int32_t* get_address_of_Z_BINARY_12() { return &___Z_BINARY_12; }
	inline void set_Z_BINARY_12(int32_t value)
	{
		___Z_BINARY_12 = value;
	}

	inline static int32_t get_offset_of_Z_ASCII_13() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___Z_ASCII_13)); }
	inline int32_t get_Z_ASCII_13() const { return ___Z_ASCII_13; }
	inline int32_t* get_address_of_Z_ASCII_13() { return &___Z_ASCII_13; }
	inline void set_Z_ASCII_13(int32_t value)
	{
		___Z_ASCII_13 = value;
	}

	inline static int32_t get_offset_of_Z_UNKNOWN_14() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___Z_UNKNOWN_14)); }
	inline int32_t get_Z_UNKNOWN_14() const { return ___Z_UNKNOWN_14; }
	inline int32_t* get_address_of_Z_UNKNOWN_14() { return &___Z_UNKNOWN_14; }
	inline void set_Z_UNKNOWN_14(int32_t value)
	{
		___Z_UNKNOWN_14 = value;
	}

	inline static int32_t get_offset_of_Buf_size_15() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___Buf_size_15)); }
	inline int32_t get_Buf_size_15() const { return ___Buf_size_15; }
	inline int32_t* get_address_of_Buf_size_15() { return &___Buf_size_15; }
	inline void set_Buf_size_15(int32_t value)
	{
		___Buf_size_15 = value;
	}

	inline static int32_t get_offset_of_MIN_MATCH_16() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___MIN_MATCH_16)); }
	inline int32_t get_MIN_MATCH_16() const { return ___MIN_MATCH_16; }
	inline int32_t* get_address_of_MIN_MATCH_16() { return &___MIN_MATCH_16; }
	inline void set_MIN_MATCH_16(int32_t value)
	{
		___MIN_MATCH_16 = value;
	}

	inline static int32_t get_offset_of_MAX_MATCH_17() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___MAX_MATCH_17)); }
	inline int32_t get_MAX_MATCH_17() const { return ___MAX_MATCH_17; }
	inline int32_t* get_address_of_MAX_MATCH_17() { return &___MAX_MATCH_17; }
	inline void set_MAX_MATCH_17(int32_t value)
	{
		___MAX_MATCH_17 = value;
	}

	inline static int32_t get_offset_of_MIN_LOOKAHEAD_18() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___MIN_LOOKAHEAD_18)); }
	inline int32_t get_MIN_LOOKAHEAD_18() const { return ___MIN_LOOKAHEAD_18; }
	inline int32_t* get_address_of_MIN_LOOKAHEAD_18() { return &___MIN_LOOKAHEAD_18; }
	inline void set_MIN_LOOKAHEAD_18(int32_t value)
	{
		___MIN_LOOKAHEAD_18 = value;
	}

	inline static int32_t get_offset_of_HEAP_SIZE_19() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___HEAP_SIZE_19)); }
	inline int32_t get_HEAP_SIZE_19() const { return ___HEAP_SIZE_19; }
	inline int32_t* get_address_of_HEAP_SIZE_19() { return &___HEAP_SIZE_19; }
	inline void set_HEAP_SIZE_19(int32_t value)
	{
		___HEAP_SIZE_19 = value;
	}

	inline static int32_t get_offset_of_END_BLOCK_20() { return static_cast<int32_t>(offsetof(DeflateManager_t1983720200_StaticFields, ___END_BLOCK_20)); }
	inline int32_t get_END_BLOCK_20() const { return ___END_BLOCK_20; }
	inline int32_t* get_address_of_END_BLOCK_20() { return &___END_BLOCK_20; }
	inline void set_END_BLOCK_20(int32_t value)
	{
		___END_BLOCK_20 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
