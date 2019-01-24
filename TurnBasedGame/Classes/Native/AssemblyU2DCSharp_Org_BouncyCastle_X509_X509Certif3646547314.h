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

// Org.BouncyCastle.X509.X509CertificateParser
struct  X509CertificateParser_t3646547314  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Asn1.Asn1Set Org.BouncyCastle.X509.X509CertificateParser::sData
	Asn1Set_t2420705913 * ___sData_1;
	// System.Int32 Org.BouncyCastle.X509.X509CertificateParser::sDataObjectCount
	int32_t ___sDataObjectCount_2;
	// System.IO.Stream Org.BouncyCastle.X509.X509CertificateParser::currentStream
	Stream_t3255436806 * ___currentStream_3;

public:
	inline static int32_t get_offset_of_sData_1() { return static_cast<int32_t>(offsetof(X509CertificateParser_t3646547314, ___sData_1)); }
	inline Asn1Set_t2420705913 * get_sData_1() const { return ___sData_1; }
	inline Asn1Set_t2420705913 ** get_address_of_sData_1() { return &___sData_1; }
	inline void set_sData_1(Asn1Set_t2420705913 * value)
	{
		___sData_1 = value;
		Il2CppCodeGenWriteBarrier(&___sData_1, value);
	}

	inline static int32_t get_offset_of_sDataObjectCount_2() { return static_cast<int32_t>(offsetof(X509CertificateParser_t3646547314, ___sDataObjectCount_2)); }
	inline int32_t get_sDataObjectCount_2() const { return ___sDataObjectCount_2; }
	inline int32_t* get_address_of_sDataObjectCount_2() { return &___sDataObjectCount_2; }
	inline void set_sDataObjectCount_2(int32_t value)
	{
		___sDataObjectCount_2 = value;
	}

	inline static int32_t get_offset_of_currentStream_3() { return static_cast<int32_t>(offsetof(X509CertificateParser_t3646547314, ___currentStream_3)); }
	inline Stream_t3255436806 * get_currentStream_3() const { return ___currentStream_3; }
	inline Stream_t3255436806 ** get_address_of_currentStream_3() { return &___currentStream_3; }
	inline void set_currentStream_3(Stream_t3255436806 * value)
	{
		___currentStream_3 = value;
		Il2CppCodeGenWriteBarrier(&___currentStream_3, value);
	}
};

struct X509CertificateParser_t3646547314_StaticFields
{
public:
	// Org.BouncyCastle.X509.PemParser Org.BouncyCastle.X509.X509CertificateParser::PemCertParser
	PemParser_t1487846991 * ___PemCertParser_0;

public:
	inline static int32_t get_offset_of_PemCertParser_0() { return static_cast<int32_t>(offsetof(X509CertificateParser_t3646547314_StaticFields, ___PemCertParser_0)); }
	inline PemParser_t1487846991 * get_PemCertParser_0() const { return ___PemCertParser_0; }
	inline PemParser_t1487846991 ** get_address_of_PemCertParser_0() { return &___PemCertParser_0; }
	inline void set_PemCertParser_0(PemParser_t1487846991 * value)
	{
		___PemCertParser_0 = value;
		Il2CppCodeGenWriteBarrier(&___PemCertParser_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
