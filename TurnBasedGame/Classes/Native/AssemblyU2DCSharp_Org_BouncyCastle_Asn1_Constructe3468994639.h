#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Utilities_IO_Ba1872372563.h"

// Org.BouncyCastle.Asn1.Asn1StreamParser
struct Asn1StreamParser_t3208800844;
// System.IO.Stream
struct Stream_t3255436806;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.ConstructedOctetStream
struct  ConstructedOctetStream_t3468994639  : public BaseInputStream_t1872372563
{
public:
	// Org.BouncyCastle.Asn1.Asn1StreamParser Org.BouncyCastle.Asn1.ConstructedOctetStream::_parser
	Asn1StreamParser_t3208800844 * ____parser_3;
	// System.Boolean Org.BouncyCastle.Asn1.ConstructedOctetStream::_first
	bool ____first_4;
	// System.IO.Stream Org.BouncyCastle.Asn1.ConstructedOctetStream::_currentStream
	Stream_t3255436806 * ____currentStream_5;

public:
	inline static int32_t get_offset_of__parser_3() { return static_cast<int32_t>(offsetof(ConstructedOctetStream_t3468994639, ____parser_3)); }
	inline Asn1StreamParser_t3208800844 * get__parser_3() const { return ____parser_3; }
	inline Asn1StreamParser_t3208800844 ** get_address_of__parser_3() { return &____parser_3; }
	inline void set__parser_3(Asn1StreamParser_t3208800844 * value)
	{
		____parser_3 = value;
		Il2CppCodeGenWriteBarrier(&____parser_3, value);
	}

	inline static int32_t get_offset_of__first_4() { return static_cast<int32_t>(offsetof(ConstructedOctetStream_t3468994639, ____first_4)); }
	inline bool get__first_4() const { return ____first_4; }
	inline bool* get_address_of__first_4() { return &____first_4; }
	inline void set__first_4(bool value)
	{
		____first_4 = value;
	}

	inline static int32_t get_offset_of__currentStream_5() { return static_cast<int32_t>(offsetof(ConstructedOctetStream_t3468994639, ____currentStream_5)); }
	inline Stream_t3255436806 * get__currentStream_5() const { return ____currentStream_5; }
	inline Stream_t3255436806 ** get_address_of__currentStream_5() { return &____currentStream_5; }
	inline void set__currentStream_5(Stream_t3255436806 * value)
	{
		____currentStream_5 = value;
		Il2CppCodeGenWriteBarrier(&____currentStream_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
