#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Asn1.Asn1Sequence
struct Asn1Sequence_t54253652;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.Asn1Sequence/Asn1SequenceParserImpl
struct  Asn1SequenceParserImpl_t2695581227  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Asn1.Asn1Sequence Org.BouncyCastle.Asn1.Asn1Sequence/Asn1SequenceParserImpl::outer
	Asn1Sequence_t54253652 * ___outer_0;
	// System.Int32 Org.BouncyCastle.Asn1.Asn1Sequence/Asn1SequenceParserImpl::max
	int32_t ___max_1;
	// System.Int32 Org.BouncyCastle.Asn1.Asn1Sequence/Asn1SequenceParserImpl::index
	int32_t ___index_2;

public:
	inline static int32_t get_offset_of_outer_0() { return static_cast<int32_t>(offsetof(Asn1SequenceParserImpl_t2695581227, ___outer_0)); }
	inline Asn1Sequence_t54253652 * get_outer_0() const { return ___outer_0; }
	inline Asn1Sequence_t54253652 ** get_address_of_outer_0() { return &___outer_0; }
	inline void set_outer_0(Asn1Sequence_t54253652 * value)
	{
		___outer_0 = value;
		Il2CppCodeGenWriteBarrier(&___outer_0, value);
	}

	inline static int32_t get_offset_of_max_1() { return static_cast<int32_t>(offsetof(Asn1SequenceParserImpl_t2695581227, ___max_1)); }
	inline int32_t get_max_1() const { return ___max_1; }
	inline int32_t* get_address_of_max_1() { return &___max_1; }
	inline void set_max_1(int32_t value)
	{
		___max_1 = value;
	}

	inline static int32_t get_offset_of_index_2() { return static_cast<int32_t>(offsetof(Asn1SequenceParserImpl_t2695581227, ___index_2)); }
	inline int32_t get_index_2() const { return ___index_2; }
	inline int32_t* get_address_of_index_2() { return &___index_2; }
	inline void set_index_2(int32_t value)
	{
		___index_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
