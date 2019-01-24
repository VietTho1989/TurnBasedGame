#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.String
struct String_t;
// UnityEngine.WWW
struct WWW_t2919945039;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// bz2Test
struct  bz2Test_t485841798  : public MonoBehaviour_t1158329972
{
public:
	// System.Int32 bz2Test::bzres
	int32_t ___bzres_2;
	// System.Int32 bz2Test::bzres2
	int32_t ___bzres2_3;
	// System.Single bz2Test::t1
	float ___t1_4;
	// System.Single bz2Test::t
	float ___t_5;
	// System.Single bz2Test::t2
	float ___t2_6;
	// System.String bz2Test::myFile
	String_t* ___myFile_7;
	// UnityEngine.WWW bz2Test::www
	WWW_t2919945039 * ___www_8;
	// System.String bz2Test::ppath
	String_t* ___ppath_9;
	// System.Boolean bz2Test::compressionStarted
	bool ___compressionStarted_10;
	// System.Boolean bz2Test::downloadDone
	bool ___downloadDone_11;
	// System.Byte[] bz2Test::bt
	ByteU5BU5D_t3397334013* ___bt_12;
	// System.Byte[] bz2Test::reusableBuffer
	ByteU5BU5D_t3397334013* ___reusableBuffer_13;
	// System.Byte[] bz2Test::reusableBuffer2
	ByteU5BU5D_t3397334013* ___reusableBuffer2_14;
	// System.Boolean bz2Test::pass1
	bool ___pass1_15;
	// System.Boolean bz2Test::pass2
	bool ___pass2_16;

public:
	inline static int32_t get_offset_of_bzres_2() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___bzres_2)); }
	inline int32_t get_bzres_2() const { return ___bzres_2; }
	inline int32_t* get_address_of_bzres_2() { return &___bzres_2; }
	inline void set_bzres_2(int32_t value)
	{
		___bzres_2 = value;
	}

	inline static int32_t get_offset_of_bzres2_3() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___bzres2_3)); }
	inline int32_t get_bzres2_3() const { return ___bzres2_3; }
	inline int32_t* get_address_of_bzres2_3() { return &___bzres2_3; }
	inline void set_bzres2_3(int32_t value)
	{
		___bzres2_3 = value;
	}

	inline static int32_t get_offset_of_t1_4() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___t1_4)); }
	inline float get_t1_4() const { return ___t1_4; }
	inline float* get_address_of_t1_4() { return &___t1_4; }
	inline void set_t1_4(float value)
	{
		___t1_4 = value;
	}

	inline static int32_t get_offset_of_t_5() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___t_5)); }
	inline float get_t_5() const { return ___t_5; }
	inline float* get_address_of_t_5() { return &___t_5; }
	inline void set_t_5(float value)
	{
		___t_5 = value;
	}

	inline static int32_t get_offset_of_t2_6() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___t2_6)); }
	inline float get_t2_6() const { return ___t2_6; }
	inline float* get_address_of_t2_6() { return &___t2_6; }
	inline void set_t2_6(float value)
	{
		___t2_6 = value;
	}

	inline static int32_t get_offset_of_myFile_7() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___myFile_7)); }
	inline String_t* get_myFile_7() const { return ___myFile_7; }
	inline String_t** get_address_of_myFile_7() { return &___myFile_7; }
	inline void set_myFile_7(String_t* value)
	{
		___myFile_7 = value;
		Il2CppCodeGenWriteBarrier(&___myFile_7, value);
	}

	inline static int32_t get_offset_of_www_8() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___www_8)); }
	inline WWW_t2919945039 * get_www_8() const { return ___www_8; }
	inline WWW_t2919945039 ** get_address_of_www_8() { return &___www_8; }
	inline void set_www_8(WWW_t2919945039 * value)
	{
		___www_8 = value;
		Il2CppCodeGenWriteBarrier(&___www_8, value);
	}

	inline static int32_t get_offset_of_ppath_9() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___ppath_9)); }
	inline String_t* get_ppath_9() const { return ___ppath_9; }
	inline String_t** get_address_of_ppath_9() { return &___ppath_9; }
	inline void set_ppath_9(String_t* value)
	{
		___ppath_9 = value;
		Il2CppCodeGenWriteBarrier(&___ppath_9, value);
	}

	inline static int32_t get_offset_of_compressionStarted_10() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___compressionStarted_10)); }
	inline bool get_compressionStarted_10() const { return ___compressionStarted_10; }
	inline bool* get_address_of_compressionStarted_10() { return &___compressionStarted_10; }
	inline void set_compressionStarted_10(bool value)
	{
		___compressionStarted_10 = value;
	}

	inline static int32_t get_offset_of_downloadDone_11() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___downloadDone_11)); }
	inline bool get_downloadDone_11() const { return ___downloadDone_11; }
	inline bool* get_address_of_downloadDone_11() { return &___downloadDone_11; }
	inline void set_downloadDone_11(bool value)
	{
		___downloadDone_11 = value;
	}

	inline static int32_t get_offset_of_bt_12() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___bt_12)); }
	inline ByteU5BU5D_t3397334013* get_bt_12() const { return ___bt_12; }
	inline ByteU5BU5D_t3397334013** get_address_of_bt_12() { return &___bt_12; }
	inline void set_bt_12(ByteU5BU5D_t3397334013* value)
	{
		___bt_12 = value;
		Il2CppCodeGenWriteBarrier(&___bt_12, value);
	}

	inline static int32_t get_offset_of_reusableBuffer_13() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___reusableBuffer_13)); }
	inline ByteU5BU5D_t3397334013* get_reusableBuffer_13() const { return ___reusableBuffer_13; }
	inline ByteU5BU5D_t3397334013** get_address_of_reusableBuffer_13() { return &___reusableBuffer_13; }
	inline void set_reusableBuffer_13(ByteU5BU5D_t3397334013* value)
	{
		___reusableBuffer_13 = value;
		Il2CppCodeGenWriteBarrier(&___reusableBuffer_13, value);
	}

	inline static int32_t get_offset_of_reusableBuffer2_14() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___reusableBuffer2_14)); }
	inline ByteU5BU5D_t3397334013* get_reusableBuffer2_14() const { return ___reusableBuffer2_14; }
	inline ByteU5BU5D_t3397334013** get_address_of_reusableBuffer2_14() { return &___reusableBuffer2_14; }
	inline void set_reusableBuffer2_14(ByteU5BU5D_t3397334013* value)
	{
		___reusableBuffer2_14 = value;
		Il2CppCodeGenWriteBarrier(&___reusableBuffer2_14, value);
	}

	inline static int32_t get_offset_of_pass1_15() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___pass1_15)); }
	inline bool get_pass1_15() const { return ___pass1_15; }
	inline bool* get_address_of_pass1_15() { return &___pass1_15; }
	inline void set_pass1_15(bool value)
	{
		___pass1_15 = value;
	}

	inline static int32_t get_offset_of_pass2_16() { return static_cast<int32_t>(offsetof(bz2Test_t485841798, ___pass2_16)); }
	inline bool get_pass2_16() const { return ___pass2_16; }
	inline bool* get_address_of_pass2_16() { return &___pass2_16; }
	inline void set_pass2_16(bool value)
	{
		___pass2_16 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
