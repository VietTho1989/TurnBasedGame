#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.X509.PemParser
struct PemParser_t1487846991;
// Org.BouncyCastle.Asn1.Asn1Set
struct Asn1Set_t2420705913;
// System.IO.Stream
struct Stream_t3255436806;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.X509.X509CrlParser
struct  X509CrlParser_t447353842  : public Il2CppObject
{
public:
	// System.Boolean Org.BouncyCastle.X509.X509CrlParser::lazyAsn1
	bool ___lazyAsn1_1;
	// Org.BouncyCastle.Asn1.Asn1Set Org.BouncyCastle.X509.X509CrlParser::sCrlData
	Asn1Set_t2420705913 * ___sCrlData_2;
	// System.Int32 Org.BouncyCastle.X509.X509CrlParser::sCrlDataObjectCount
	int32_t ___sCrlDataObjectCount_3;
	// System.IO.Stream Org.BouncyCastle.X509.X509CrlParser::currentCrlStream
	Stream_t3255436806 * ___currentCrlStream_4;

public:
	inline static int32_t get_offset_of_lazyAsn1_1() { return static_cast<int32_t>(offsetof(X509CrlParser_t447353842, ___lazyAsn1_1)); }
	inline bool get_lazyAsn1_1() const { return ___lazyAsn1_1; }
	inline bool* get_address_of_lazyAsn1_1() { return &___lazyAsn1_1; }
	inline void set_lazyAsn1_1(bool value)
	{
		___lazyAsn1_1 = value;
	}

	inline static int32_t get_offset_of_sCrlData_2() { return static_cast<int32_t>(offsetof(X509CrlParser_t447353842, ___sCrlData_2)); }
	inline Asn1Set_t2420705913 * get_sCrlData_2() const { return ___sCrlData_2; }
	inline Asn1Set_t2420705913 ** get_address_of_sCrlData_2() { return &___sCrlData_2; }
	inline void set_sCrlData_2(Asn1Set_t2420705913 * value)
	{
		___sCrlData_2 = value;
		Il2CppCodeGenWriteBarrier(&___sCrlData_2, value);
	}

	inline static int32_t get_offset_of_sCrlDataObjectCount_3() { return static_cast<int32_t>(offsetof(X509CrlParser_t447353842, ___sCrlDataObjectCount_3)); }
	inline int32_t get_sCrlDataObjectCount_3() const { return ___sCrlDataObjectCount_3; }
	inline int32_t* get_address_of_sCrlDataObjectCount_3() { return &___sCrlDataObjectCount_3; }
	inline void set_sCrlDataObjectCount_3(int32_t value)
	{
		___sCrlDataObjectCount_3 = value;
	}

	inline static int32_t get_offset_of_currentCrlStream_4() { return static_cast<int32_t>(offsetof(X509CrlParser_t447353842, ___currentCrlStream_4)); }
	inline Stream_t3255436806 * get_currentCrlStream_4() const { return ___currentCrlStream_4; }
	inline Stream_t3255436806 ** get_address_of_currentCrlStream_4() { return &___currentCrlStream_4; }
	inline void set_currentCrlStream_4(Stream_t3255436806 * value)
	{
		___currentCrlStream_4 = value;
		Il2CppCodeGenWriteBarrier(&___currentCrlStream_4, value);
	}
};

struct X509CrlParser_t447353842_StaticFields
{
public:
	// Org.BouncyCastle.X509.PemParser Org.BouncyCastle.X509.X509CrlParser::PemCrlParser
	PemParser_t1487846991 * ___PemCrlParser_0;

public:
	inline static int32_t get_offset_of_PemCrlParser_0() { return static_cast<int32_t>(offsetof(X509CrlParser_t447353842_StaticFields, ___PemCrlParser_0)); }
	inline PemParser_t1487846991 * get_PemCrlParser_0() const { return ___PemCrlParser_0; }
	inline PemParser_t1487846991 ** get_address_of_PemCrlParser_0() { return &___PemCrlParser_0; }
	inline void set_PemCrlParser_0(PemParser_t1487846991 * value)
	{
		___PemCrlParser_0 = value;
		Il2CppCodeGenWriteBarrier(&___PemCrlParser_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
