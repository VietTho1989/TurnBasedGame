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
// System.Int16[]
struct Int16U5BU5D_t3104283263;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.UInt32[]
struct UInt32U5BU5D_t59386216;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Engines.DesEngine
struct  DesEngine_t1307100856  : public Il2CppObject
{
public:
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.DesEngine::workingKey
	Int32U5BU5D_t3030399641* ___workingKey_1;

public:
	inline static int32_t get_offset_of_workingKey_1() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856, ___workingKey_1)); }
	inline Int32U5BU5D_t3030399641* get_workingKey_1() const { return ___workingKey_1; }
	inline Int32U5BU5D_t3030399641** get_address_of_workingKey_1() { return &___workingKey_1; }
	inline void set_workingKey_1(Int32U5BU5D_t3030399641* value)
	{
		___workingKey_1 = value;
		Il2CppCodeGenWriteBarrier(&___workingKey_1, value);
	}
};

struct DesEngine_t1307100856_StaticFields
{
public:
	// System.Int16[] Org.BouncyCastle.Crypto.Engines.DesEngine::bytebit
	Int16U5BU5D_t3104283263* ___bytebit_2;
	// System.Int32[] Org.BouncyCastle.Crypto.Engines.DesEngine::bigbyte
	Int32U5BU5D_t3030399641* ___bigbyte_3;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.DesEngine::pc1
	ByteU5BU5D_t3397334013* ___pc1_4;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.DesEngine::totrot
	ByteU5BU5D_t3397334013* ___totrot_5;
	// System.Byte[] Org.BouncyCastle.Crypto.Engines.DesEngine::pc2
	ByteU5BU5D_t3397334013* ___pc2_6;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.DesEngine::SP1
	UInt32U5BU5D_t59386216* ___SP1_7;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.DesEngine::SP2
	UInt32U5BU5D_t59386216* ___SP2_8;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.DesEngine::SP3
	UInt32U5BU5D_t59386216* ___SP3_9;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.DesEngine::SP4
	UInt32U5BU5D_t59386216* ___SP4_10;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.DesEngine::SP5
	UInt32U5BU5D_t59386216* ___SP5_11;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.DesEngine::SP6
	UInt32U5BU5D_t59386216* ___SP6_12;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.DesEngine::SP7
	UInt32U5BU5D_t59386216* ___SP7_13;
	// System.UInt32[] Org.BouncyCastle.Crypto.Engines.DesEngine::SP8
	UInt32U5BU5D_t59386216* ___SP8_14;

public:
	inline static int32_t get_offset_of_bytebit_2() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___bytebit_2)); }
	inline Int16U5BU5D_t3104283263* get_bytebit_2() const { return ___bytebit_2; }
	inline Int16U5BU5D_t3104283263** get_address_of_bytebit_2() { return &___bytebit_2; }
	inline void set_bytebit_2(Int16U5BU5D_t3104283263* value)
	{
		___bytebit_2 = value;
		Il2CppCodeGenWriteBarrier(&___bytebit_2, value);
	}

	inline static int32_t get_offset_of_bigbyte_3() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___bigbyte_3)); }
	inline Int32U5BU5D_t3030399641* get_bigbyte_3() const { return ___bigbyte_3; }
	inline Int32U5BU5D_t3030399641** get_address_of_bigbyte_3() { return &___bigbyte_3; }
	inline void set_bigbyte_3(Int32U5BU5D_t3030399641* value)
	{
		___bigbyte_3 = value;
		Il2CppCodeGenWriteBarrier(&___bigbyte_3, value);
	}

	inline static int32_t get_offset_of_pc1_4() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___pc1_4)); }
	inline ByteU5BU5D_t3397334013* get_pc1_4() const { return ___pc1_4; }
	inline ByteU5BU5D_t3397334013** get_address_of_pc1_4() { return &___pc1_4; }
	inline void set_pc1_4(ByteU5BU5D_t3397334013* value)
	{
		___pc1_4 = value;
		Il2CppCodeGenWriteBarrier(&___pc1_4, value);
	}

	inline static int32_t get_offset_of_totrot_5() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___totrot_5)); }
	inline ByteU5BU5D_t3397334013* get_totrot_5() const { return ___totrot_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_totrot_5() { return &___totrot_5; }
	inline void set_totrot_5(ByteU5BU5D_t3397334013* value)
	{
		___totrot_5 = value;
		Il2CppCodeGenWriteBarrier(&___totrot_5, value);
	}

	inline static int32_t get_offset_of_pc2_6() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___pc2_6)); }
	inline ByteU5BU5D_t3397334013* get_pc2_6() const { return ___pc2_6; }
	inline ByteU5BU5D_t3397334013** get_address_of_pc2_6() { return &___pc2_6; }
	inline void set_pc2_6(ByteU5BU5D_t3397334013* value)
	{
		___pc2_6 = value;
		Il2CppCodeGenWriteBarrier(&___pc2_6, value);
	}

	inline static int32_t get_offset_of_SP1_7() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___SP1_7)); }
	inline UInt32U5BU5D_t59386216* get_SP1_7() const { return ___SP1_7; }
	inline UInt32U5BU5D_t59386216** get_address_of_SP1_7() { return &___SP1_7; }
	inline void set_SP1_7(UInt32U5BU5D_t59386216* value)
	{
		___SP1_7 = value;
		Il2CppCodeGenWriteBarrier(&___SP1_7, value);
	}

	inline static int32_t get_offset_of_SP2_8() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___SP2_8)); }
	inline UInt32U5BU5D_t59386216* get_SP2_8() const { return ___SP2_8; }
	inline UInt32U5BU5D_t59386216** get_address_of_SP2_8() { return &___SP2_8; }
	inline void set_SP2_8(UInt32U5BU5D_t59386216* value)
	{
		___SP2_8 = value;
		Il2CppCodeGenWriteBarrier(&___SP2_8, value);
	}

	inline static int32_t get_offset_of_SP3_9() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___SP3_9)); }
	inline UInt32U5BU5D_t59386216* get_SP3_9() const { return ___SP3_9; }
	inline UInt32U5BU5D_t59386216** get_address_of_SP3_9() { return &___SP3_9; }
	inline void set_SP3_9(UInt32U5BU5D_t59386216* value)
	{
		___SP3_9 = value;
		Il2CppCodeGenWriteBarrier(&___SP3_9, value);
	}

	inline static int32_t get_offset_of_SP4_10() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___SP4_10)); }
	inline UInt32U5BU5D_t59386216* get_SP4_10() const { return ___SP4_10; }
	inline UInt32U5BU5D_t59386216** get_address_of_SP4_10() { return &___SP4_10; }
	inline void set_SP4_10(UInt32U5BU5D_t59386216* value)
	{
		___SP4_10 = value;
		Il2CppCodeGenWriteBarrier(&___SP4_10, value);
	}

	inline static int32_t get_offset_of_SP5_11() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___SP5_11)); }
	inline UInt32U5BU5D_t59386216* get_SP5_11() const { return ___SP5_11; }
	inline UInt32U5BU5D_t59386216** get_address_of_SP5_11() { return &___SP5_11; }
	inline void set_SP5_11(UInt32U5BU5D_t59386216* value)
	{
		___SP5_11 = value;
		Il2CppCodeGenWriteBarrier(&___SP5_11, value);
	}

	inline static int32_t get_offset_of_SP6_12() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___SP6_12)); }
	inline UInt32U5BU5D_t59386216* get_SP6_12() const { return ___SP6_12; }
	inline UInt32U5BU5D_t59386216** get_address_of_SP6_12() { return &___SP6_12; }
	inline void set_SP6_12(UInt32U5BU5D_t59386216* value)
	{
		___SP6_12 = value;
		Il2CppCodeGenWriteBarrier(&___SP6_12, value);
	}

	inline static int32_t get_offset_of_SP7_13() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___SP7_13)); }
	inline UInt32U5BU5D_t59386216* get_SP7_13() const { return ___SP7_13; }
	inline UInt32U5BU5D_t59386216** get_address_of_SP7_13() { return &___SP7_13; }
	inline void set_SP7_13(UInt32U5BU5D_t59386216* value)
	{
		___SP7_13 = value;
		Il2CppCodeGenWriteBarrier(&___SP7_13, value);
	}

	inline static int32_t get_offset_of_SP8_14() { return static_cast<int32_t>(offsetof(DesEngine_t1307100856_StaticFields, ___SP8_14)); }
	inline UInt32U5BU5D_t59386216* get_SP8_14() const { return ___SP8_14; }
	inline UInt32U5BU5D_t59386216** get_address_of_SP8_14() { return &___SP8_14; }
	inline void set_SP8_14(UInt32U5BU5D_t59386216* value)
	{
		___SP8_14 = value;
		Il2CppCodeGenWriteBarrier(&___SP8_14, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
