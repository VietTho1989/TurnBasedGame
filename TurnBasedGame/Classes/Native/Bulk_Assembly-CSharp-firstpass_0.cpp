#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>

#include "class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "mscorlib_System_Array3829468939.h"
#include "AssemblyU2DCSharpU2Dfirstpass_U3CModuleU3E3783534214.h"
#include "AssemblyU2DCSharpU2Dfirstpass_lbz22877250982.h"
#include "mscorlib_System_Void1841601450.h"
#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_String2029220233.h"
#include "mscorlib_System_Int322071877448.h"
#include "mscorlib_System_IntPtr2504060609.h"
#include "mscorlib_System_UInt322149682021.h"
#include "mscorlib_System_Boolean3825574718.h"
#include "mscorlib_System_Byte3683104436.h"
#include "mscorlib_System_Runtime_InteropServices_GCHandle3409268066.h"
#include "mscorlib_System_Runtime_InteropServices_GCHandleTy1970708122.h"
#include "mscorlib_System_BitConverter3195628829.h"

// lbz2
struct lbz2_t2877250982;
// System.Object
struct Il2CppObject;
// System.String
struct String_t;
// System.Byte[]
struct ByteU5BU5D_t3397334013;
// System.Array
struct Il2CppArray;
extern Il2CppClass* lbz2_t2877250982_il2cpp_TypeInfo_var;
extern const uint32_t lbz2_decompressBz2_m3591644420_MetadataUsageId;
extern const uint32_t lbz2_compressBz2_m1834209490_MetadataUsageId;
extern Il2CppClass* BitConverter_t3195628829_il2cpp_TypeInfo_var;
extern Il2CppClass* IntPtr_t_il2cpp_TypeInfo_var;
extern Il2CppClass* Marshal_t785896760_il2cpp_TypeInfo_var;
extern const MethodInfo* Array_Resize_TisByte_t3683104436_m3723494155_MethodInfo_var;
extern const uint32_t lbz2_bz2CompressBuffer_m260638999_MetadataUsageId;
extern Il2CppClass* ByteU5BU5D_t3397334013_il2cpp_TypeInfo_var;
extern const uint32_t lbz2_bz2CompressBuffer_m3253117580_MetadataUsageId;
extern Il2CppClass* String_t_il2cpp_TypeInfo_var;
extern Il2CppClass* Debug_t1368543263_il2cpp_TypeInfo_var;
extern Il2CppCodeGenString* _stringLiteral1593611370;
extern const uint32_t lbz2_bz2DecompressBuffer_m1620965158_MetadataUsageId;
extern const uint32_t lbz2_bz2DecompressBuffer_m408130611_MetadataUsageId;
extern const uint32_t lbz2__cctor_m133986666_MetadataUsageId;

// System.Byte[]
struct ByteU5BU5D_t3397334013  : public Il2CppArray
{
public:
	ALIGN_FIELD (8) uint8_t m_Items[1];

public:
	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};


// System.Void System.Array::Resize<System.Byte>(!!0[]&,System.Int32)
extern "C"  void Array_Resize_TisByte_t3683104436_m3723494155_gshared (Il2CppObject * __this /* static, unused */, ByteU5BU5D_t3397334013** p0, int32_t p1, const MethodInfo* method);

// System.Void System.Object::.ctor()
extern "C"  void Object__ctor_m2551263788 (Il2CppObject * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Int32 lbz2::bz2(System.Int32,System.Int32,System.String,System.String)
extern "C"  int32_t lbz2_bz2_m4110052947 (Il2CppObject * __this /* static, unused */, int32_t ___mode0, int32_t ___levelOfCompression1, String_t* ___inFile2, String_t* ___outFile3, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Runtime.InteropServices.GCHandle System.Runtime.InteropServices.GCHandle::Alloc(System.Object,System.Runtime.InteropServices.GCHandleType)
extern "C"  GCHandle_t3409268066  GCHandle_Alloc_m1063472408 (Il2CppObject * __this /* static, unused */, Il2CppObject * p0, int32_t p1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Byte[] System.BitConverter::GetBytes(System.Int32)
extern "C"  ByteU5BU5D_t3397334013* BitConverter_GetBytes_m1300847478 (Il2CppObject * __this /* static, unused */, int32_t p0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Array::Reverse(System.Array)
extern "C"  void Array_Reverse_m3883292526 (Il2CppObject * __this /* static, unused */, Il2CppArray * p0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.IntPtr System.Runtime.InteropServices.GCHandle::AddrOfPinnedObject()
extern "C"  IntPtr_t GCHandle_AddrOfPinnedObject_m3034420542 (GCHandle_t3409268066 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.IntPtr lbz2::bz2Buff2Buff(System.IntPtr,System.UInt32,System.Int32,System.Int32&)
extern "C"  IntPtr_t lbz2_bz2Buff2Buff_m3675386784 (Il2CppObject * __this /* static, unused */, IntPtr_t ___source0, uint32_t ___sourceLen1, int32_t ___blockSize100k2, int32_t* ___v3, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Boolean System.IntPtr::op_Equality(System.IntPtr,System.IntPtr)
extern "C"  bool IntPtr_op_Equality_m1573482188 (Il2CppObject * __this /* static, unused */, IntPtr_t p0, IntPtr_t p1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Runtime.InteropServices.GCHandle::Free()
extern "C"  void GCHandle_Free_m1639542352 (GCHandle_t3409268066 * __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void lbz2::releaseBuffer(System.IntPtr)
extern "C"  void lbz2_releaseBuffer_m2349721254 (Il2CppObject * __this /* static, unused */, IntPtr_t ___buffer0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void System.Array::Resize<System.Byte>(!!0[]&,System.Int32)
#define Array_Resize_TisByte_t3683104436_m3723494155(__this /* static, unused */, p0, p1, method) ((  void (*) (Il2CppObject * /* static, unused */, ByteU5BU5D_t3397334013**, int32_t, const MethodInfo*))Array_Resize_TisByte_t3683104436_m3723494155_gshared)(__this /* static, unused */, p0, p1, method)
// System.Void System.Runtime.InteropServices.Marshal::Copy(System.IntPtr,System.Byte[],System.Int32,System.Int32)
extern "C"  void Marshal_Copy_m1683535972 (Il2CppObject * __this /* static, unused */, IntPtr_t p0, ByteU5BU5D_t3397334013* p1, int32_t p2, int32_t p3, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Int32 System.BitConverter::ToInt32(System.Byte[],System.Int32)
extern "C"  int32_t BitConverter_ToInt32_m2742027961 (Il2CppObject * __this /* static, unused */, ByteU5BU5D_t3397334013* p0, int32_t p1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Int32 lbz2::bz2DecBuff(System.IntPtr,System.UInt32,System.IntPtr,System.UInt32)
extern "C"  int32_t lbz2_bz2DecBuff_m1125876116 (Il2CppObject * __this /* static, unused */, IntPtr_t ___dest0, uint32_t ___destLen1, IntPtr_t ___source2, uint32_t ___sourceLen3, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.String System.Int32::ToString()
extern "C"  String_t* Int32_ToString_m2960866144 (int32_t* __this, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.String System.String::Concat(System.String,System.String)
extern "C"  String_t* String_Concat_m2596409543 (Il2CppObject * __this /* static, unused */, String_t* p0, String_t* p1, const MethodInfo* method) IL2CPP_METHOD_ATTR;
// System.Void UnityEngine.Debug::Log(System.Object)
extern "C"  void Debug_Log_m920475918 (Il2CppObject * __this /* static, unused */, Il2CppObject * p0, const MethodInfo* method) IL2CPP_METHOD_ATTR;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void lbz2::.ctor()
extern "C"  void lbz2__ctor_m2974700219 (lbz2_t2877250982 * __this, const MethodInfo* method)
{
	{
		Object__ctor_m2551263788(__this, /*hidden argument*/NULL);
		return;
	}
}
extern "C" int32_t DEFAULT_CALL bz2(int32_t, int32_t, char*, char*);
// System.Int32 lbz2::bz2(System.Int32,System.Int32,System.String,System.String)
extern "C"  int32_t lbz2_bz2_m4110052947 (Il2CppObject * __this /* static, unused */, int32_t ___mode0, int32_t ___levelOfCompression1, String_t* ___inFile2, String_t* ___outFile3, const MethodInfo* method)
{
	typedef int32_t (DEFAULT_CALL *PInvokeFunc) (int32_t, int32_t, char*, char*);

	// Marshaling of parameter '___inFile2' to native representation
	char* ____inFile2_marshaled = NULL;
	____inFile2_marshaled = il2cpp_codegen_marshal_string(___inFile2);

	// Marshaling of parameter '___outFile3' to native representation
	char* ____outFile3_marshaled = NULL;
	____outFile3_marshaled = il2cpp_codegen_marshal_string(___outFile3);

	// Native function invocation
	int32_t returnValue = reinterpret_cast<PInvokeFunc>(bz2)(___mode0, ___levelOfCompression1, ____inFile2_marshaled, ____outFile3_marshaled);

	// Marshaling cleanup of parameter '___inFile2' native representation
	il2cpp_codegen_marshal_free(____inFile2_marshaled);
	____inFile2_marshaled = NULL;

	// Marshaling cleanup of parameter '___outFile3' native representation
	il2cpp_codegen_marshal_free(____outFile3_marshaled);
	____outFile3_marshaled = NULL;

	return returnValue;
}
extern "C" void DEFAULT_CALL releaseBuffer(intptr_t);
// System.Void lbz2::releaseBuffer(System.IntPtr)
extern "C"  void lbz2_releaseBuffer_m2349721254 (Il2CppObject * __this /* static, unused */, IntPtr_t ___buffer0, const MethodInfo* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) (intptr_t);

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(releaseBuffer)(reinterpret_cast<intptr_t>((___buffer0).get_m_value_0()));

}
extern "C" intptr_t DEFAULT_CALL bz2Buff2Buff(intptr_t, uint32_t, int32_t, int32_t*);
// System.IntPtr lbz2::bz2Buff2Buff(System.IntPtr,System.UInt32,System.Int32,System.Int32&)
extern "C"  IntPtr_t lbz2_bz2Buff2Buff_m3675386784 (Il2CppObject * __this /* static, unused */, IntPtr_t ___source0, uint32_t ___sourceLen1, int32_t ___blockSize100k2, int32_t* ___v3, const MethodInfo* method)
{
	typedef intptr_t (DEFAULT_CALL *PInvokeFunc) (intptr_t, uint32_t, int32_t, int32_t*);

	// Native function invocation
	intptr_t returnValue = reinterpret_cast<PInvokeFunc>(bz2Buff2Buff)(reinterpret_cast<intptr_t>((___source0).get_m_value_0()), ___sourceLen1, ___blockSize100k2, ___v3);

	// Marshaling of return value back from native representation
	IntPtr_t _returnValue_unmarshaled;
	_returnValue_unmarshaled.set_m_value_0(reinterpret_cast<void*>((intptr_t)(returnValue)));

	return _returnValue_unmarshaled;
}
extern "C" int32_t DEFAULT_CALL bz2DecBuff(intptr_t, uint32_t, intptr_t, uint32_t);
// System.Int32 lbz2::bz2DecBuff(System.IntPtr,System.UInt32,System.IntPtr,System.UInt32)
extern "C"  int32_t lbz2_bz2DecBuff_m1125876116 (Il2CppObject * __this /* static, unused */, IntPtr_t ___dest0, uint32_t ___destLen1, IntPtr_t ___source2, uint32_t ___sourceLen3, const MethodInfo* method)
{
	typedef int32_t (DEFAULT_CALL *PInvokeFunc) (intptr_t, uint32_t, intptr_t, uint32_t);

	// Native function invocation
	int32_t returnValue = reinterpret_cast<PInvokeFunc>(bz2DecBuff)(reinterpret_cast<intptr_t>((___dest0).get_m_value_0()), ___destLen1, reinterpret_cast<intptr_t>((___source2).get_m_value_0()), ___sourceLen3);

	return returnValue;
}
// System.Int32 lbz2::decompressBz2(System.String,System.String)
extern "C"  int32_t lbz2_decompressBz2_m3591644420 (Il2CppObject * __this /* static, unused */, String_t* ___inFile0, String_t* ___outFile1, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (lbz2_decompressBz2_m3591644420_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// return bz2(1, 0, inFile, outFile);
		String_t* L_0 = ___inFile0;
		String_t* L_1 = ___outFile1;
		// return bz2(1, 0, inFile, outFile);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		int32_t L_2 = lbz2_bz2_m4110052947(NULL /*static, unused*/, 1, 0, L_0, L_1, /*hidden argument*/NULL);
		V_0 = L_2;
		goto IL_0010;
	}

IL_0010:
	{
		// }
		int32_t L_3 = V_0;
		return L_3;
	}
}
// System.Int32 lbz2::compressBz2(System.String,System.String,System.Int32)
extern "C"  int32_t lbz2_compressBz2_m1834209490 (Il2CppObject * __this /* static, unused */, String_t* ___inFile0, String_t* ___outFile1, int32_t ___levelOfCompression2, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (lbz2_compressBz2_m1834209490_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// if (levelOfCompression > 9) levelOfCompression = 9;
		int32_t L_0 = ___levelOfCompression2;
		if ((((int32_t)L_0) <= ((int32_t)((int32_t)9))))
		{
			goto IL_000d;
		}
	}
	{
		// if (levelOfCompression > 9) levelOfCompression = 9;
		___levelOfCompression2 = ((int32_t)9);
	}

IL_000d:
	{
		// if (levelOfCompression < 1) levelOfCompression = 1;
		int32_t L_1 = ___levelOfCompression2;
		if ((((int32_t)L_1) >= ((int32_t)1)))
		{
			goto IL_0017;
		}
	}
	{
		// if (levelOfCompression < 1) levelOfCompression = 1;
		___levelOfCompression2 = 1;
	}

IL_0017:
	{
		// return bz2(0, levelOfCompression, inFile, outFile);
		int32_t L_2 = ___levelOfCompression2;
		String_t* L_3 = ___inFile0;
		String_t* L_4 = ___outFile1;
		// return bz2(0, levelOfCompression, inFile, outFile);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		int32_t L_5 = lbz2_bz2_m4110052947(NULL /*static, unused*/, 0, L_2, L_3, L_4, /*hidden argument*/NULL);
		V_0 = L_5;
		goto IL_0026;
	}

IL_0026:
	{
		// }
		int32_t L_6 = V_0;
		return L_6;
	}
}
// System.Boolean lbz2::bz2CompressBuffer(System.Byte[],System.Byte[]&,System.Int32,System.Boolean)
extern "C"  bool lbz2_bz2CompressBuffer_m260638999 (Il2CppObject * __this /* static, unused */, ByteU5BU5D_t3397334013* ___source0, ByteU5BU5D_t3397334013** ___outBuffer1, int32_t ___compressionLevel2, bool ___includeSize3, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (lbz2_bz2CompressBuffer_m260638999_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	GCHandle_t3409268066  V_0;
	memset(&V_0, 0, sizeof(V_0));
	IntPtr_t V_1;
	memset(&V_1, 0, sizeof(V_1));
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	bool V_4 = false;
	int32_t V_5 = 0;
	{
		// GCHandle sbuf = GCHandle.Alloc(source, GCHandleType.Pinned);
		ByteU5BU5D_t3397334013* L_0 = ___source0;
		// GCHandle sbuf = GCHandle.Alloc(source, GCHandleType.Pinned);
		GCHandle_t3409268066  L_1 = GCHandle_Alloc_m1063472408(NULL /*static, unused*/, (Il2CppObject *)(Il2CppObject *)L_0, 3, /*hidden argument*/NULL);
		V_0 = L_1;
		// int siz = 0, hsiz = 0;
		V_2 = 0;
		// int siz = 0, hsiz = 0;
		V_3 = 0;
		// if (includeSize)
		bool L_2 = ___includeSize3;
		if (!L_2)
		{
			goto IL_0038;
		}
	}
	{
		// hsiz = 4;
		V_3 = 4;
		// bsiz = BitConverter.GetBytes(source.Length);
		ByteU5BU5D_t3397334013* L_3 = ___source0;
		NullCheck(L_3);
		// bsiz = BitConverter.GetBytes(source.Length);
		IL2CPP_RUNTIME_CLASS_INIT(BitConverter_t3195628829_il2cpp_TypeInfo_var);
		ByteU5BU5D_t3397334013* L_4 = BitConverter_GetBytes_m1300847478(NULL /*static, unused*/, (((int32_t)((int32_t)(((Il2CppArray *)L_3)->max_length)))), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		((lbz2_t2877250982_StaticFields*)lbz2_t2877250982_il2cpp_TypeInfo_var->static_fields)->set_bsiz_0(L_4);
		// if (!BitConverter.IsLittleEndian) Array.Reverse(bsiz);
		bool L_5 = ((BitConverter_t3195628829_StaticFields*)BitConverter_t3195628829_il2cpp_TypeInfo_var->static_fields)->get_IsLittleEndian_1();
		if (L_5)
		{
			goto IL_0037;
		}
	}
	{
		// if (!BitConverter.IsLittleEndian) Array.Reverse(bsiz);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		ByteU5BU5D_t3397334013* L_6 = ((lbz2_t2877250982_StaticFields*)lbz2_t2877250982_il2cpp_TypeInfo_var->static_fields)->get_bsiz_0();
		// if (!BitConverter.IsLittleEndian) Array.Reverse(bsiz);
		Array_Reverse_m3883292526(NULL /*static, unused*/, (Il2CppArray *)(Il2CppArray *)L_6, /*hidden argument*/NULL);
	}

IL_0037:
	{
	}

IL_0038:
	{
		// ptr = bz2Buff2Buff(sbuf.AddrOfPinnedObject(), (uint)source.Length, compressionLevel, ref siz);
		// ptr = bz2Buff2Buff(sbuf.AddrOfPinnedObject(), (uint)source.Length, compressionLevel, ref siz);
		IntPtr_t L_7 = GCHandle_AddrOfPinnedObject_m3034420542((&V_0), /*hidden argument*/NULL);
		ByteU5BU5D_t3397334013* L_8 = ___source0;
		NullCheck(L_8);
		int32_t L_9 = ___compressionLevel2;
		// ptr = bz2Buff2Buff(sbuf.AddrOfPinnedObject(), (uint)source.Length, compressionLevel, ref siz);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		IntPtr_t L_10 = lbz2_bz2Buff2Buff_m3675386784(NULL /*static, unused*/, L_7, (((int32_t)((int32_t)(((Il2CppArray *)L_8)->max_length)))), L_9, (&V_2), /*hidden argument*/NULL);
		V_1 = L_10;
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return false; }
		int32_t L_11 = V_2;
		if (!L_11)
		{
			goto IL_0061;
		}
	}
	{
		IntPtr_t L_12 = V_1;
		IntPtr_t L_13 = ((IntPtr_t_StaticFields*)IntPtr_t_il2cpp_TypeInfo_var->static_fields)->get_Zero_1();
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return false; }
		bool L_14 = IntPtr_op_Equality_m1573482188(NULL /*static, unused*/, L_12, L_13, /*hidden argument*/NULL);
		if (!L_14)
		{
			goto IL_0077;
		}
	}

IL_0061:
	{
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return false; }
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return false; }
		GCHandle_Free_m1639542352((&V_0), /*hidden argument*/NULL);
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return false; }
		IntPtr_t L_15 = V_1;
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return false; }
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		lbz2_releaseBuffer_m2349721254(NULL /*static, unused*/, L_15, /*hidden argument*/NULL);
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return false; }
		V_4 = (bool)0;
		goto IL_00cc;
	}

IL_0077:
	{
		// System.Array.Resize(ref outBuffer, siz + hsiz);
		ByteU5BU5D_t3397334013** L_16 = ___outBuffer1;
		int32_t L_17 = V_2;
		int32_t L_18 = V_3;
		// System.Array.Resize(ref outBuffer, siz + hsiz);
		Array_Resize_TisByte_t3683104436_m3723494155(NULL /*static, unused*/, L_16, ((int32_t)((int32_t)L_17+(int32_t)L_18)), /*hidden argument*/Array_Resize_TisByte_t3683104436_m3723494155_MethodInfo_var);
		// if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }
		bool L_19 = ___includeSize3;
		if (!L_19)
		{
			goto IL_00ad;
		}
	}
	{
		// if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }
		V_5 = 0;
		goto IL_00a4;
	}

IL_008f:
	{
		// if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }
		ByteU5BU5D_t3397334013** L_20 = ___outBuffer1;
		int32_t L_21 = V_5;
		int32_t L_22 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		ByteU5BU5D_t3397334013* L_23 = ((lbz2_t2877250982_StaticFields*)lbz2_t2877250982_il2cpp_TypeInfo_var->static_fields)->get_bsiz_0();
		int32_t L_24 = V_5;
		NullCheck(L_23);
		int32_t L_25 = L_24;
		uint8_t L_26 = (L_23)->GetAt(static_cast<il2cpp_array_size_t>(L_25));
		NullCheck((*((ByteU5BU5D_t3397334013**)L_20)));
		((*((ByteU5BU5D_t3397334013**)L_20)))->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)((int32_t)L_21+(int32_t)L_22))), (uint8_t)L_26);
		// if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }
		int32_t L_27 = V_5;
		V_5 = ((int32_t)((int32_t)L_27+(int32_t)1));
	}

IL_00a4:
	{
		// if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }
		int32_t L_28 = V_5;
		if ((((int32_t)L_28) < ((int32_t)4)))
		{
			goto IL_008f;
		}
	}
	{
	}

IL_00ad:
	{
		// Marshal.Copy(ptr, outBuffer, 0, siz);
		IntPtr_t L_29 = V_1;
		ByteU5BU5D_t3397334013** L_30 = ___outBuffer1;
		int32_t L_31 = V_2;
		// Marshal.Copy(ptr, outBuffer, 0, siz);
		IL2CPP_RUNTIME_CLASS_INIT(Marshal_t785896760_il2cpp_TypeInfo_var);
		Marshal_Copy_m1683535972(NULL /*static, unused*/, L_29, (*((ByteU5BU5D_t3397334013**)L_30)), 0, L_31, /*hidden argument*/NULL);
		// sbuf.Free();
		// sbuf.Free();
		GCHandle_Free_m1639542352((&V_0), /*hidden argument*/NULL);
		// releaseBuffer(ptr);
		IntPtr_t L_32 = V_1;
		// releaseBuffer(ptr);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		lbz2_releaseBuffer_m2349721254(NULL /*static, unused*/, L_32, /*hidden argument*/NULL);
		// return true;
		V_4 = (bool)1;
		goto IL_00cc;
	}

IL_00cc:
	{
		// }
		bool L_33 = V_4;
		return L_33;
	}
}
// System.Byte[] lbz2::bz2CompressBuffer(System.Byte[],System.Int32,System.Boolean)
extern "C"  ByteU5BU5D_t3397334013* lbz2_bz2CompressBuffer_m3253117580 (Il2CppObject * __this /* static, unused */, ByteU5BU5D_t3397334013* ___source0, int32_t ___compressionLevel1, bool ___includeSize2, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (lbz2_bz2CompressBuffer_m3253117580_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	GCHandle_t3409268066  V_0;
	memset(&V_0, 0, sizeof(V_0));
	IntPtr_t V_1;
	memset(&V_1, 0, sizeof(V_1));
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	ByteU5BU5D_t3397334013* V_4 = NULL;
	ByteU5BU5D_t3397334013* V_5 = NULL;
	int32_t V_6 = 0;
	{
		// GCHandle sbuf = GCHandle.Alloc(source, GCHandleType.Pinned);
		ByteU5BU5D_t3397334013* L_0 = ___source0;
		// GCHandle sbuf = GCHandle.Alloc(source, GCHandleType.Pinned);
		GCHandle_t3409268066  L_1 = GCHandle_Alloc_m1063472408(NULL /*static, unused*/, (Il2CppObject *)(Il2CppObject *)L_0, 3, /*hidden argument*/NULL);
		V_0 = L_1;
		// int siz = 0, hsiz = 0;
		V_2 = 0;
		// int siz = 0, hsiz = 0;
		V_3 = 0;
		// if (includeSize)
		bool L_2 = ___includeSize2;
		if (!L_2)
		{
			goto IL_0038;
		}
	}
	{
		// hsiz = 4;
		V_3 = 4;
		// bsiz = BitConverter.GetBytes(source.Length);
		ByteU5BU5D_t3397334013* L_3 = ___source0;
		NullCheck(L_3);
		// bsiz = BitConverter.GetBytes(source.Length);
		IL2CPP_RUNTIME_CLASS_INIT(BitConverter_t3195628829_il2cpp_TypeInfo_var);
		ByteU5BU5D_t3397334013* L_4 = BitConverter_GetBytes_m1300847478(NULL /*static, unused*/, (((int32_t)((int32_t)(((Il2CppArray *)L_3)->max_length)))), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		((lbz2_t2877250982_StaticFields*)lbz2_t2877250982_il2cpp_TypeInfo_var->static_fields)->set_bsiz_0(L_4);
		// if (!BitConverter.IsLittleEndian) Array.Reverse(bsiz);
		bool L_5 = ((BitConverter_t3195628829_StaticFields*)BitConverter_t3195628829_il2cpp_TypeInfo_var->static_fields)->get_IsLittleEndian_1();
		if (L_5)
		{
			goto IL_0037;
		}
	}
	{
		// if (!BitConverter.IsLittleEndian) Array.Reverse(bsiz);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		ByteU5BU5D_t3397334013* L_6 = ((lbz2_t2877250982_StaticFields*)lbz2_t2877250982_il2cpp_TypeInfo_var->static_fields)->get_bsiz_0();
		// if (!BitConverter.IsLittleEndian) Array.Reverse(bsiz);
		Array_Reverse_m3883292526(NULL /*static, unused*/, (Il2CppArray *)(Il2CppArray *)L_6, /*hidden argument*/NULL);
	}

IL_0037:
	{
	}

IL_0038:
	{
		// ptr = bz2Buff2Buff(sbuf.AddrOfPinnedObject(), (uint)source.Length, compressionLevel, ref siz);
		// ptr = bz2Buff2Buff(sbuf.AddrOfPinnedObject(), (uint)source.Length, compressionLevel, ref siz);
		IntPtr_t L_7 = GCHandle_AddrOfPinnedObject_m3034420542((&V_0), /*hidden argument*/NULL);
		ByteU5BU5D_t3397334013* L_8 = ___source0;
		NullCheck(L_8);
		int32_t L_9 = ___compressionLevel1;
		// ptr = bz2Buff2Buff(sbuf.AddrOfPinnedObject(), (uint)source.Length, compressionLevel, ref siz);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		IntPtr_t L_10 = lbz2_bz2Buff2Buff_m3675386784(NULL /*static, unused*/, L_7, (((int32_t)((int32_t)(((Il2CppArray *)L_8)->max_length)))), L_9, (&V_2), /*hidden argument*/NULL);
		V_1 = L_10;
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return null; }
		int32_t L_11 = V_2;
		if (!L_11)
		{
			goto IL_0061;
		}
	}
	{
		IntPtr_t L_12 = V_1;
		IntPtr_t L_13 = ((IntPtr_t_StaticFields*)IntPtr_t_il2cpp_TypeInfo_var->static_fields)->get_Zero_1();
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return null; }
		bool L_14 = IntPtr_op_Equality_m1573482188(NULL /*static, unused*/, L_12, L_13, /*hidden argument*/NULL);
		if (!L_14)
		{
			goto IL_0077;
		}
	}

IL_0061:
	{
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return null; }
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return null; }
		GCHandle_Free_m1639542352((&V_0), /*hidden argument*/NULL);
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return null; }
		IntPtr_t L_15 = V_1;
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return null; }
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		lbz2_releaseBuffer_m2349721254(NULL /*static, unused*/, L_15, /*hidden argument*/NULL);
		// if (siz == 0 || ptr == IntPtr.Zero) { sbuf.Free(); releaseBuffer(ptr); return null; }
		V_4 = (ByteU5BU5D_t3397334013*)NULL;
		goto IL_00ce;
	}

IL_0077:
	{
		// byte[] outBuffer = new byte[siz + hsiz];
		int32_t L_16 = V_2;
		int32_t L_17 = V_3;
		V_5 = ((ByteU5BU5D_t3397334013*)SZArrayNew(ByteU5BU5D_t3397334013_il2cpp_TypeInfo_var, (uint32_t)((int32_t)((int32_t)L_16+(int32_t)L_17))));
		// if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }
		bool L_18 = ___includeSize2;
		if (!L_18)
		{
			goto IL_00ae;
		}
	}
	{
		// if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }
		V_6 = 0;
		goto IL_00a5;
	}

IL_0090:
	{
		// if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }
		ByteU5BU5D_t3397334013* L_19 = V_5;
		int32_t L_20 = V_6;
		int32_t L_21 = V_2;
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		ByteU5BU5D_t3397334013* L_22 = ((lbz2_t2877250982_StaticFields*)lbz2_t2877250982_il2cpp_TypeInfo_var->static_fields)->get_bsiz_0();
		int32_t L_23 = V_6;
		NullCheck(L_22);
		int32_t L_24 = L_23;
		uint8_t L_25 = (L_22)->GetAt(static_cast<il2cpp_array_size_t>(L_24));
		NullCheck(L_19);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)((int32_t)L_20+(int32_t)L_21))), (uint8_t)L_25);
		// if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }
		int32_t L_26 = V_6;
		V_6 = ((int32_t)((int32_t)L_26+(int32_t)1));
	}

IL_00a5:
	{
		// if (includeSize) { for (int i = 0; i < 4; i++) outBuffer[i + siz] = bsiz[i];  /*Debug.Log(BitConverter.ToInt32(bsiz, 0));*/ }
		int32_t L_27 = V_6;
		if ((((int32_t)L_27) < ((int32_t)4)))
		{
			goto IL_0090;
		}
	}
	{
	}

IL_00ae:
	{
		// Marshal.Copy(ptr, outBuffer, 0, siz);
		IntPtr_t L_28 = V_1;
		ByteU5BU5D_t3397334013* L_29 = V_5;
		int32_t L_30 = V_2;
		// Marshal.Copy(ptr, outBuffer, 0, siz);
		IL2CPP_RUNTIME_CLASS_INIT(Marshal_t785896760_il2cpp_TypeInfo_var);
		Marshal_Copy_m1683535972(NULL /*static, unused*/, L_28, L_29, 0, L_30, /*hidden argument*/NULL);
		// sbuf.Free();
		// sbuf.Free();
		GCHandle_Free_m1639542352((&V_0), /*hidden argument*/NULL);
		// releaseBuffer(ptr);
		IntPtr_t L_31 = V_1;
		// releaseBuffer(ptr);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		lbz2_releaseBuffer_m2349721254(NULL /*static, unused*/, L_31, /*hidden argument*/NULL);
		// return outBuffer;
		ByteU5BU5D_t3397334013* L_32 = V_5;
		V_4 = L_32;
		goto IL_00ce;
	}

IL_00ce:
	{
		// }
		ByteU5BU5D_t3397334013* L_33 = V_4;
		return L_33;
	}
}
// System.Int32 lbz2::bz2DecompressBuffer(System.Byte[],System.Byte[]&,System.Boolean,System.Int32)
extern "C"  int32_t lbz2_bz2DecompressBuffer_m1620965158 (Il2CppObject * __this /* static, unused */, ByteU5BU5D_t3397334013* ___inBuffer0, ByteU5BU5D_t3397334013** ___outBuffer1, bool ___useFooter2, int32_t ___customLength3, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (lbz2_bz2DecompressBuffer_m1620965158_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	GCHandle_t3409268066  V_1;
	memset(&V_1, 0, sizeof(V_1));
	GCHandle_t3409268066  V_2;
	memset(&V_2, 0, sizeof(V_2));
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	{
		// int uncompressedSize = 0;
		V_0 = 0;
		// if (useFooter) uncompressedSize = (int)BitConverter.ToInt32(inBuffer, inBuffer.Length - 4); else uncompressedSize = customLength;
		bool L_0 = ___useFooter2;
		if (!L_0)
		{
			goto IL_001a;
		}
	}
	{
		// if (useFooter) uncompressedSize = (int)BitConverter.ToInt32(inBuffer, inBuffer.Length - 4); else uncompressedSize = customLength;
		ByteU5BU5D_t3397334013* L_1 = ___inBuffer0;
		ByteU5BU5D_t3397334013* L_2 = ___inBuffer0;
		NullCheck(L_2);
		// if (useFooter) uncompressedSize = (int)BitConverter.ToInt32(inBuffer, inBuffer.Length - 4); else uncompressedSize = customLength;
		IL2CPP_RUNTIME_CLASS_INIT(BitConverter_t3195628829_il2cpp_TypeInfo_var);
		int32_t L_3 = BitConverter_ToInt32_m2742027961(NULL /*static, unused*/, L_1, ((int32_t)((int32_t)(((int32_t)((int32_t)(((Il2CppArray *)L_2)->max_length))))-(int32_t)4)), /*hidden argument*/NULL);
		V_0 = L_3;
		goto IL_001c;
	}

IL_001a:
	{
		// if (useFooter) uncompressedSize = (int)BitConverter.ToInt32(inBuffer, inBuffer.Length - 4); else uncompressedSize = customLength;
		int32_t L_4 = ___customLength3;
		V_0 = L_4;
	}

IL_001c:
	{
		// GCHandle cbuf = GCHandle.Alloc(inBuffer, GCHandleType.Pinned);
		ByteU5BU5D_t3397334013* L_5 = ___inBuffer0;
		// GCHandle cbuf = GCHandle.Alloc(inBuffer, GCHandleType.Pinned);
		GCHandle_t3409268066  L_6 = GCHandle_Alloc_m1063472408(NULL /*static, unused*/, (Il2CppObject *)(Il2CppObject *)L_5, 3, /*hidden argument*/NULL);
		V_1 = L_6;
		// System.Array.Resize(ref outBuffer, uncompressedSize);
		ByteU5BU5D_t3397334013** L_7 = ___outBuffer1;
		int32_t L_8 = V_0;
		// System.Array.Resize(ref outBuffer, uncompressedSize);
		Array_Resize_TisByte_t3683104436_m3723494155(NULL /*static, unused*/, L_7, L_8, /*hidden argument*/Array_Resize_TisByte_t3683104436_m3723494155_MethodInfo_var);
		// GCHandle obuf = GCHandle.Alloc(outBuffer, GCHandleType.Pinned);
		ByteU5BU5D_t3397334013** L_9 = ___outBuffer1;
		// GCHandle obuf = GCHandle.Alloc(outBuffer, GCHandleType.Pinned);
		GCHandle_t3409268066  L_10 = GCHandle_Alloc_m1063472408(NULL /*static, unused*/, (Il2CppObject *)(Il2CppObject *)(*((ByteU5BU5D_t3397334013**)L_9)), 3, /*hidden argument*/NULL);
		V_2 = L_10;
		// int res = bz2DecBuff(obuf.AddrOfPinnedObject(), (uint)uncompressedSize, cbuf.AddrOfPinnedObject(), (uint)inBuffer.Length);
		// int res = bz2DecBuff(obuf.AddrOfPinnedObject(), (uint)uncompressedSize, cbuf.AddrOfPinnedObject(), (uint)inBuffer.Length);
		IntPtr_t L_11 = GCHandle_AddrOfPinnedObject_m3034420542((&V_2), /*hidden argument*/NULL);
		int32_t L_12 = V_0;
		// int res = bz2DecBuff(obuf.AddrOfPinnedObject(), (uint)uncompressedSize, cbuf.AddrOfPinnedObject(), (uint)inBuffer.Length);
		IntPtr_t L_13 = GCHandle_AddrOfPinnedObject_m3034420542((&V_1), /*hidden argument*/NULL);
		ByteU5BU5D_t3397334013* L_14 = ___inBuffer0;
		NullCheck(L_14);
		// int res = bz2DecBuff(obuf.AddrOfPinnedObject(), (uint)uncompressedSize, cbuf.AddrOfPinnedObject(), (uint)inBuffer.Length);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		int32_t L_15 = lbz2_bz2DecBuff_m1125876116(NULL /*static, unused*/, L_11, L_12, L_13, (((int32_t)((int32_t)(((Il2CppArray *)L_14)->max_length)))), /*hidden argument*/NULL);
		V_3 = L_15;
		// cbuf.Free();
		// cbuf.Free();
		GCHandle_Free_m1639542352((&V_1), /*hidden argument*/NULL);
		// obuf.Free();
		// obuf.Free();
		GCHandle_Free_m1639542352((&V_2), /*hidden argument*/NULL);
		// if (res != 0) { Debug.Log("ERROR: " + res.ToString()); }
		int32_t L_16 = V_3;
		if (!L_16)
		{
			goto IL_007e;
		}
	}
	{
		// if (res != 0) { Debug.Log("ERROR: " + res.ToString()); }
		// if (res != 0) { Debug.Log("ERROR: " + res.ToString()); }
		String_t* L_17 = Int32_ToString_m2960866144((&V_3), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_18 = String_Concat_m2596409543(NULL /*static, unused*/, _stringLiteral1593611370, L_17, /*hidden argument*/NULL);
		// if (res != 0) { Debug.Log("ERROR: " + res.ToString()); }
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t1368543263_il2cpp_TypeInfo_var);
		Debug_Log_m920475918(NULL /*static, unused*/, L_18, /*hidden argument*/NULL);
	}

IL_007e:
	{
		// return res;
		int32_t L_19 = V_3;
		V_4 = L_19;
		goto IL_0086;
	}

IL_0086:
	{
		// }
		int32_t L_20 = V_4;
		return L_20;
	}
}
// System.Byte[] lbz2::bz2DecompressBuffer(System.Byte[],System.Boolean,System.Int32)
extern "C"  ByteU5BU5D_t3397334013* lbz2_bz2DecompressBuffer_m408130611 (Il2CppObject * __this /* static, unused */, ByteU5BU5D_t3397334013* ___inBuffer0, bool ___useFooter1, int32_t ___customLength2, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (lbz2_bz2DecompressBuffer_m408130611_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	GCHandle_t3409268066  V_1;
	memset(&V_1, 0, sizeof(V_1));
	ByteU5BU5D_t3397334013* V_2 = NULL;
	GCHandle_t3409268066  V_3;
	memset(&V_3, 0, sizeof(V_3));
	int32_t V_4 = 0;
	ByteU5BU5D_t3397334013* V_5 = NULL;
	{
		// int uncompressedSize = 0;
		V_0 = 0;
		// if (useFooter) uncompressedSize = (int)BitConverter.ToInt32(inBuffer, inBuffer.Length - 4); else uncompressedSize = customLength;
		bool L_0 = ___useFooter1;
		if (!L_0)
		{
			goto IL_001a;
		}
	}
	{
		// if (useFooter) uncompressedSize = (int)BitConverter.ToInt32(inBuffer, inBuffer.Length - 4); else uncompressedSize = customLength;
		ByteU5BU5D_t3397334013* L_1 = ___inBuffer0;
		ByteU5BU5D_t3397334013* L_2 = ___inBuffer0;
		NullCheck(L_2);
		// if (useFooter) uncompressedSize = (int)BitConverter.ToInt32(inBuffer, inBuffer.Length - 4); else uncompressedSize = customLength;
		IL2CPP_RUNTIME_CLASS_INIT(BitConverter_t3195628829_il2cpp_TypeInfo_var);
		int32_t L_3 = BitConverter_ToInt32_m2742027961(NULL /*static, unused*/, L_1, ((int32_t)((int32_t)(((int32_t)((int32_t)(((Il2CppArray *)L_2)->max_length))))-(int32_t)4)), /*hidden argument*/NULL);
		V_0 = L_3;
		goto IL_001c;
	}

IL_001a:
	{
		// if (useFooter) uncompressedSize = (int)BitConverter.ToInt32(inBuffer, inBuffer.Length - 4); else uncompressedSize = customLength;
		int32_t L_4 = ___customLength2;
		V_0 = L_4;
	}

IL_001c:
	{
		// GCHandle cbuf = GCHandle.Alloc(inBuffer, GCHandleType.Pinned);
		ByteU5BU5D_t3397334013* L_5 = ___inBuffer0;
		// GCHandle cbuf = GCHandle.Alloc(inBuffer, GCHandleType.Pinned);
		GCHandle_t3409268066  L_6 = GCHandle_Alloc_m1063472408(NULL /*static, unused*/, (Il2CppObject *)(Il2CppObject *)L_5, 3, /*hidden argument*/NULL);
		V_1 = L_6;
		// byte[] outbuffer = new byte[uncompressedSize];
		int32_t L_7 = V_0;
		V_2 = ((ByteU5BU5D_t3397334013*)SZArrayNew(ByteU5BU5D_t3397334013_il2cpp_TypeInfo_var, (uint32_t)L_7));
		// GCHandle obuf = GCHandle.Alloc(outbuffer, GCHandleType.Pinned);
		ByteU5BU5D_t3397334013* L_8 = V_2;
		// GCHandle obuf = GCHandle.Alloc(outbuffer, GCHandleType.Pinned);
		GCHandle_t3409268066  L_9 = GCHandle_Alloc_m1063472408(NULL /*static, unused*/, (Il2CppObject *)(Il2CppObject *)L_8, 3, /*hidden argument*/NULL);
		V_3 = L_9;
		// int res = bz2DecBuff(obuf.AddrOfPinnedObject(), (uint)uncompressedSize, cbuf.AddrOfPinnedObject(), (uint)inBuffer.Length);
		// int res = bz2DecBuff(obuf.AddrOfPinnedObject(), (uint)uncompressedSize, cbuf.AddrOfPinnedObject(), (uint)inBuffer.Length);
		IntPtr_t L_10 = GCHandle_AddrOfPinnedObject_m3034420542((&V_3), /*hidden argument*/NULL);
		int32_t L_11 = V_0;
		// int res = bz2DecBuff(obuf.AddrOfPinnedObject(), (uint)uncompressedSize, cbuf.AddrOfPinnedObject(), (uint)inBuffer.Length);
		IntPtr_t L_12 = GCHandle_AddrOfPinnedObject_m3034420542((&V_1), /*hidden argument*/NULL);
		ByteU5BU5D_t3397334013* L_13 = ___inBuffer0;
		NullCheck(L_13);
		// int res = bz2DecBuff(obuf.AddrOfPinnedObject(), (uint)uncompressedSize, cbuf.AddrOfPinnedObject(), (uint)inBuffer.Length);
		IL2CPP_RUNTIME_CLASS_INIT(lbz2_t2877250982_il2cpp_TypeInfo_var);
		int32_t L_14 = lbz2_bz2DecBuff_m1125876116(NULL /*static, unused*/, L_10, L_11, L_12, (((int32_t)((int32_t)(((Il2CppArray *)L_13)->max_length)))), /*hidden argument*/NULL);
		V_4 = L_14;
		// cbuf.Free();
		// cbuf.Free();
		GCHandle_Free_m1639542352((&V_1), /*hidden argument*/NULL);
		// obuf.Free();
		// obuf.Free();
		GCHandle_Free_m1639542352((&V_3), /*hidden argument*/NULL);
		// if (res != 0) { Debug.Log("ERROR: " + res.ToString()); }
		int32_t L_15 = V_4;
		if (!L_15)
		{
			goto IL_007f;
		}
	}
	{
		// if (res != 0) { Debug.Log("ERROR: " + res.ToString()); }
		// if (res != 0) { Debug.Log("ERROR: " + res.ToString()); }
		String_t* L_16 = Int32_ToString_m2960866144((&V_4), /*hidden argument*/NULL);
		IL2CPP_RUNTIME_CLASS_INIT(String_t_il2cpp_TypeInfo_var);
		String_t* L_17 = String_Concat_m2596409543(NULL /*static, unused*/, _stringLiteral1593611370, L_16, /*hidden argument*/NULL);
		// if (res != 0) { Debug.Log("ERROR: " + res.ToString()); }
		IL2CPP_RUNTIME_CLASS_INIT(Debug_t1368543263_il2cpp_TypeInfo_var);
		Debug_Log_m920475918(NULL /*static, unused*/, L_17, /*hidden argument*/NULL);
	}

IL_007f:
	{
		// return outbuffer;
		ByteU5BU5D_t3397334013* L_18 = V_2;
		V_5 = L_18;
		goto IL_0087;
	}

IL_0087:
	{
		// }
		ByteU5BU5D_t3397334013* L_19 = V_5;
		return L_19;
	}
}
// System.Void lbz2::.cctor()
extern "C"  void lbz2__cctor_m133986666 (Il2CppObject * __this /* static, unused */, const MethodInfo* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (lbz2__cctor_m133986666_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		// internal static byte[] bsiz = new byte[4];
		((lbz2_t2877250982_StaticFields*)lbz2_t2877250982_il2cpp_TypeInfo_var->static_fields)->set_bsiz_0(((ByteU5BU5D_t3397334013*)SZArrayNew(ByteU5BU5D_t3397334013_il2cpp_TypeInfo_var, (uint32_t)4)));
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
