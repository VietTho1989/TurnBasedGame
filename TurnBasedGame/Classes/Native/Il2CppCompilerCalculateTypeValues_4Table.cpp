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
#include "mscorlib_System_IO_MonoIOStat1621921065.h"
#include "mscorlib_System_IO_Path41728875.h"
#include "mscorlib_System_IO_PathTooLongException2469314706.h"
#include "mscorlib_System_IO_SearchPattern1107849040.h"
#include "mscorlib_System_IO_SeekOrigin2475945306.h"
#include "mscorlib_System_IO_Stream3255436806.h"
#include "mscorlib_System_IO_NullStream322566869.h"
#include "mscorlib_System_IO_StreamAsyncResult458551667.h"
#include "mscorlib_System_IO_StreamReader2360341767.h"
#include "mscorlib_System_IO_StreamReader_NullStreamReader1178646293.h"
#include "mscorlib_System_IO_StreamWriter3858580635.h"
#include "mscorlib_System_IO_StringReader1480123486.h"
#include "mscorlib_System_IO_StringWriter4139609088.h"
#include "mscorlib_System_IO_TextReader1561828458.h"
#include "mscorlib_System_IO_TextReader_NullTextReader516142577.h"
#include "mscorlib_System_IO_SynchronizedReader498788541.h"
#include "mscorlib_System_IO_TextWriter4027217640.h"
#include "mscorlib_System_IO_TextWriter_NullTextWriter1732518121.h"
#include "mscorlib_System_IO_SynchronizedWriter1348457089.h"
#include "mscorlib_System_IO_UnexceptionalStreamReader683371910.h"
#include "mscorlib_System_IO_UnexceptionalStreamWriter1485343520.h"
#include "mscorlib_System_IO_UnmanagedMemoryStream822875729.h"
#include "mscorlib_System_Reflection_AmbiguousMatchException1406414556.h"
#include "mscorlib_System_Reflection_Assembly4268412390.h"
#include "mscorlib_System_Reflection_Assembly_ResolveEventHo1761494505.h"
#include "mscorlib_System_Reflection_AssemblyCompanyAttribut2851673381.h"
#include "mscorlib_System_Reflection_AssemblyConfigurationAt1678917172.h"
#include "mscorlib_System_Reflection_AssemblyCopyrightAttribu177123295.h"
#include "mscorlib_System_Reflection_AssemblyDefaultAliasAtt1774139159.h"
#include "mscorlib_System_Reflection_AssemblyDelaySignAttrib2705758496.h"
#include "mscorlib_System_Reflection_AssemblyDescriptionAttr1018387888.h"
#include "mscorlib_System_Reflection_AssemblyFileVersionAttr2897687916.h"
#include "mscorlib_System_Reflection_AssemblyInformationalVe3037389657.h"
#include "mscorlib_System_Reflection_AssemblyKeyFileAttribute605245443.h"
#include "mscorlib_System_Reflection_AssemblyName894705941.h"
#include "mscorlib_System_Reflection_AssemblyNameFlags1794031440.h"
#include "mscorlib_System_Reflection_AssemblyProductAttribut1523443169.h"
#include "mscorlib_System_Reflection_AssemblyTitleAttribute92945912.h"
#include "mscorlib_System_Reflection_AssemblyTrademarkAttrib3740556705.h"
#include "mscorlib_System_Reflection_Binder3404612058.h"
#include "mscorlib_System_Reflection_Binder_Default3956931304.h"
#include "mscorlib_System_Reflection_BindingFlags1082350898.h"
#include "mscorlib_System_Reflection_CallingConventions1097349142.h"
#include "mscorlib_System_Reflection_ConstructorInfo2851816542.h"
#include "mscorlib_System_Reflection_CustomAttributeData3093286891.h"
#include "mscorlib_System_Reflection_CustomAttributeNamedArgum94157543.h"
#include "mscorlib_System_Reflection_CustomAttributeTypedArg1498197914.h"
#include "mscorlib_System_Reflection_EventAttributes2989788983.h"
#include "mscorlib_System_Reflection_EventInfo4258285342.h"
#include "mscorlib_System_Reflection_EventInfo_AddEventAdapt1766862959.h"
#include "mscorlib_System_Reflection_FieldAttributes1122705193.h"
#include "mscorlib_System_Reflection_FieldInfo255040150.h"
#include "mscorlib_System_Reflection_LocalVariableInfo1749284021.h"
#include "mscorlib_System_Reflection_MemberInfoSerialization2799051170.h"
#include "mscorlib_System_Reflection_MemberTypes3343038963.h"
#include "mscorlib_System_Reflection_MethodAttributes790385034.h"
#include "mscorlib_System_Reflection_MethodBase904190842.h"
#include "mscorlib_System_Reflection_MethodImplAttributes1541361196.h"
#include "mscorlib_System_Reflection_MethodInfo3330546337.h"
#include "mscorlib_System_Reflection_Missing1033855606.h"
#include "mscorlib_System_Reflection_Module4282841206.h"
#include "mscorlib_System_Reflection_MonoGenericMethod1068099169.h"
#include "mscorlib_System_Reflection_MonoGenericCMethod2923423538.h"
#include "mscorlib_System_Reflection_MonoEventInfo2190036573.h"
#include "mscorlib_System_Reflection_MonoEvent2188687691.h"
#include "mscorlib_System_Reflection_MonoField3600053525.h"
#include "mscorlib_System_Reflection_MonoMethodInfo3646562144.h"
#include "mscorlib_System_Reflection_MonoMethod116053496.h"
#include "mscorlib_System_Reflection_MonoCMethod611352247.h"
#include "mscorlib_System_Reflection_MonoPropertyInfo486106184.h"
#include "mscorlib_System_Reflection_PInfo957350482.h"
#include "mscorlib_System_Reflection_MonoProperty2242413552.h"
#include "mscorlib_System_Reflection_MonoProperty_GetterAdap1423755509.h"
#include "mscorlib_System_Reflection_ParameterAttributes1266705348.h"
#include "mscorlib_System_Reflection_ParameterInfo2249040075.h"
#include "mscorlib_System_Reflection_ParameterModifier1820634920.h"
#include "mscorlib_System_Reflection_Pointer937075087.h"
#include "mscorlib_System_Reflection_ProcessorArchitecture1620065459.h"
#include "mscorlib_System_Reflection_PropertyAttributes883448530.h"
#include "mscorlib_System_Reflection_PropertyInfo2253729065.h"
#include "mscorlib_System_Reflection_ResourceAttributes2389678029.h"
#include "mscorlib_System_Reflection_StrongNameKeyPair4090869089.h"
#include "mscorlib_System_Reflection_TargetException1572104820.h"
#include "mscorlib_System_Reflection_TargetInvocationExcepti4098620458.h"
#include "mscorlib_System_Reflection_TargetParameterCountExc1554451430.h"
#include "mscorlib_System_Reflection_TypeAttributes2229518203.h"
#include "mscorlib_System_Reflection_TypeDelegator1357031879.h"
#include "mscorlib_System_Reflection_Emit_RefEmitPermissionS2708608433.h"
#include "mscorlib_System_Reflection_Emit_MonoResource3127387157.h"
#include "mscorlib_System_Reflection_Emit_AssemblyBuilder1646117627.h"
#include "mscorlib_System_Reflection_Emit_AssemblyBuilderAcc1210911821.h"
#include "mscorlib_System_Reflection_Emit_ConstructorBuilder700974433.h"
#include "mscorlib_System_Reflection_Emit_DerivedType1016359113.h"
#include "mscorlib_System_Reflection_Emit_ByRefType1587086384.h"
#include "mscorlib_System_Reflection_Emit_DynamicMethod3307743052.h"
#include "mscorlib_System_Reflection_Emit_DynamicMethod_Anon4101997074.h"
#include "mscorlib_System_Reflection_Emit_DynamicMethodTokenG435001088.h"
#include "mscorlib_System_Reflection_Emit_EnumBuilder2808714468.h"







#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize400 = { sizeof (MonoIOStat_t1621921065)+ sizeof (Il2CppObject), sizeof(MonoIOStat_t1621921065_marshaled_pinvoke), 0, 0 };
extern const int32_t g_FieldOffsetTable400[6] = 
{
	MonoIOStat_t1621921065::get_offset_of_Name_0() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoIOStat_t1621921065::get_offset_of_Attributes_1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoIOStat_t1621921065::get_offset_of_Length_2() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoIOStat_t1621921065::get_offset_of_CreationTime_3() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoIOStat_t1621921065::get_offset_of_LastAccessTime_4() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoIOStat_t1621921065::get_offset_of_LastWriteTime_5() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize401 = { sizeof (Path_t41728875), -1, sizeof(Path_t41728875_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable401[8] = 
{
	Path_t41728875_StaticFields::get_offset_of_InvalidPathChars_0(),
	Path_t41728875_StaticFields::get_offset_of_AltDirectorySeparatorChar_1(),
	Path_t41728875_StaticFields::get_offset_of_DirectorySeparatorChar_2(),
	Path_t41728875_StaticFields::get_offset_of_PathSeparator_3(),
	Path_t41728875_StaticFields::get_offset_of_DirectorySeparatorStr_4(),
	Path_t41728875_StaticFields::get_offset_of_VolumeSeparatorChar_5(),
	Path_t41728875_StaticFields::get_offset_of_PathSeparatorChars_6(),
	Path_t41728875_StaticFields::get_offset_of_dirEqualsVolume_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize402 = { sizeof (PathTooLongException_t2469314706), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize403 = { sizeof (SearchPattern_t1107849040), -1, sizeof(SearchPattern_t1107849040_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable403[2] = 
{
	SearchPattern_t1107849040_StaticFields::get_offset_of_WildcardChars_0(),
	SearchPattern_t1107849040_StaticFields::get_offset_of_InvalidChars_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize404 = { sizeof (SeekOrigin_t2475945306)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable404[4] = 
{
	SeekOrigin_t2475945306::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize405 = { sizeof (Stream_t3255436806), -1, sizeof(Stream_t3255436806_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable405[1] = 
{
	Stream_t3255436806_StaticFields::get_offset_of_Null_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize406 = { sizeof (NullStream_t322566869), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize407 = { sizeof (StreamAsyncResult_t458551667), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable407[6] = 
{
	StreamAsyncResult_t458551667::get_offset_of_state_0(),
	StreamAsyncResult_t458551667::get_offset_of_completed_1(),
	StreamAsyncResult_t458551667::get_offset_of_done_2(),
	StreamAsyncResult_t458551667::get_offset_of_exc_3(),
	StreamAsyncResult_t458551667::get_offset_of_nbytes_4(),
	StreamAsyncResult_t458551667::get_offset_of_wh_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize408 = { sizeof (StreamReader_t2360341767), -1, sizeof(StreamReader_t2360341767_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable408[13] = 
{
	StreamReader_t2360341767::get_offset_of_input_buffer_2(),
	StreamReader_t2360341767::get_offset_of_decoded_buffer_3(),
	StreamReader_t2360341767::get_offset_of_decoded_count_4(),
	StreamReader_t2360341767::get_offset_of_pos_5(),
	StreamReader_t2360341767::get_offset_of_buffer_size_6(),
	StreamReader_t2360341767::get_offset_of_do_checks_7(),
	StreamReader_t2360341767::get_offset_of_encoding_8(),
	StreamReader_t2360341767::get_offset_of_decoder_9(),
	StreamReader_t2360341767::get_offset_of_base_stream_10(),
	StreamReader_t2360341767::get_offset_of_mayBlock_11(),
	StreamReader_t2360341767::get_offset_of_line_builder_12(),
	StreamReader_t2360341767_StaticFields::get_offset_of_Null_13(),
	StreamReader_t2360341767::get_offset_of_foundCR_14(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize409 = { sizeof (NullStreamReader_t1178646293), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize410 = { sizeof (StreamWriter_t3858580635), -1, sizeof(StreamWriter_t3858580635_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable410[10] = 
{
	StreamWriter_t3858580635::get_offset_of_internalEncoding_4(),
	StreamWriter_t3858580635::get_offset_of_internalStream_5(),
	StreamWriter_t3858580635::get_offset_of_iflush_6(),
	StreamWriter_t3858580635::get_offset_of_byte_buf_7(),
	StreamWriter_t3858580635::get_offset_of_byte_pos_8(),
	StreamWriter_t3858580635::get_offset_of_decode_buf_9(),
	StreamWriter_t3858580635::get_offset_of_decode_pos_10(),
	StreamWriter_t3858580635::get_offset_of_DisposedAlready_11(),
	StreamWriter_t3858580635::get_offset_of_preamble_done_12(),
	StreamWriter_t3858580635_StaticFields::get_offset_of_Null_13(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize411 = { sizeof (StringReader_t1480123486), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable411[3] = 
{
	StringReader_t1480123486::get_offset_of_source_2(),
	StringReader_t1480123486::get_offset_of_nextChar_3(),
	StringReader_t1480123486::get_offset_of_sourceLength_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize412 = { sizeof (StringWriter_t4139609088), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable412[2] = 
{
	StringWriter_t4139609088::get_offset_of_internalString_4(),
	StringWriter_t4139609088::get_offset_of_disposed_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize413 = { sizeof (TextReader_t1561828458), -1, sizeof(TextReader_t1561828458_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable413[1] = 
{
	TextReader_t1561828458_StaticFields::get_offset_of_Null_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize414 = { sizeof (NullTextReader_t516142577), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize415 = { sizeof (SynchronizedReader_t498788541), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable415[1] = 
{
	SynchronizedReader_t498788541::get_offset_of_reader_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize416 = { sizeof (TextWriter_t4027217640), -1, sizeof(TextWriter_t4027217640_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable416[3] = 
{
	TextWriter_t4027217640::get_offset_of_CoreNewLine_1(),
	TextWriter_t4027217640::get_offset_of_internalFormatProvider_2(),
	TextWriter_t4027217640_StaticFields::get_offset_of_Null_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize417 = { sizeof (NullTextWriter_t1732518121), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize418 = { sizeof (SynchronizedWriter_t1348457089), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable418[2] = 
{
	SynchronizedWriter_t1348457089::get_offset_of_writer_4(),
	SynchronizedWriter_t1348457089::get_offset_of_neverClose_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize419 = { sizeof (UnexceptionalStreamReader_t683371910), -1, sizeof(UnexceptionalStreamReader_t683371910_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable419[2] = 
{
	UnexceptionalStreamReader_t683371910_StaticFields::get_offset_of_newline_15(),
	UnexceptionalStreamReader_t683371910_StaticFields::get_offset_of_newlineChar_16(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize420 = { sizeof (UnexceptionalStreamWriter_t1485343520), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize421 = { sizeof (UnmanagedMemoryStream_t822875729), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable421[8] = 
{
	UnmanagedMemoryStream_t822875729::get_offset_of_length_2(),
	UnmanagedMemoryStream_t822875729::get_offset_of_closed_3(),
	UnmanagedMemoryStream_t822875729::get_offset_of_capacity_4(),
	UnmanagedMemoryStream_t822875729::get_offset_of_fileaccess_5(),
	UnmanagedMemoryStream_t822875729::get_offset_of_initial_pointer_6(),
	UnmanagedMemoryStream_t822875729::get_offset_of_initial_position_7(),
	UnmanagedMemoryStream_t822875729::get_offset_of_current_position_8(),
	UnmanagedMemoryStream_t822875729::get_offset_of_Closed_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize422 = { sizeof (AmbiguousMatchException_t1406414556), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize423 = { sizeof (Assembly_t4268412390), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable423[10] = 
{
	Assembly_t4268412390::get_offset_of__mono_assembly_0(),
	Assembly_t4268412390::get_offset_of_resolve_event_holder_1(),
	Assembly_t4268412390::get_offset_of__evidence_2(),
	Assembly_t4268412390::get_offset_of__minimum_3(),
	Assembly_t4268412390::get_offset_of__optional_4(),
	Assembly_t4268412390::get_offset_of__refuse_5(),
	Assembly_t4268412390::get_offset_of__granted_6(),
	Assembly_t4268412390::get_offset_of__denied_7(),
	Assembly_t4268412390::get_offset_of_fromByteArray_8(),
	Assembly_t4268412390::get_offset_of_assemblyName_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize424 = { sizeof (ResolveEventHolder_t1761494505), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable424[1] = 
{
	ResolveEventHolder_t1761494505::get_offset_of_ModuleResolve_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize425 = { sizeof (AssemblyCompanyAttribute_t2851673381), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable425[1] = 
{
	AssemblyCompanyAttribute_t2851673381::get_offset_of_name_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize426 = { sizeof (AssemblyConfigurationAttribute_t1678917172), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable426[1] = 
{
	AssemblyConfigurationAttribute_t1678917172::get_offset_of_name_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize427 = { sizeof (AssemblyCopyrightAttribute_t177123295), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable427[1] = 
{
	AssemblyCopyrightAttribute_t177123295::get_offset_of_name_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize428 = { sizeof (AssemblyDefaultAliasAttribute_t1774139159), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable428[1] = 
{
	AssemblyDefaultAliasAttribute_t1774139159::get_offset_of_name_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize429 = { sizeof (AssemblyDelaySignAttribute_t2705758496), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable429[1] = 
{
	AssemblyDelaySignAttribute_t2705758496::get_offset_of_delay_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize430 = { sizeof (AssemblyDescriptionAttribute_t1018387888), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable430[1] = 
{
	AssemblyDescriptionAttribute_t1018387888::get_offset_of_name_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize431 = { sizeof (AssemblyFileVersionAttribute_t2897687916), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable431[1] = 
{
	AssemblyFileVersionAttribute_t2897687916::get_offset_of_name_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize432 = { sizeof (AssemblyInformationalVersionAttribute_t3037389657), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable432[1] = 
{
	AssemblyInformationalVersionAttribute_t3037389657::get_offset_of_name_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize433 = { sizeof (AssemblyKeyFileAttribute_t605245443), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable433[1] = 
{
	AssemblyKeyFileAttribute_t605245443::get_offset_of_name_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize434 = { sizeof (AssemblyName_t894705941), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable434[15] = 
{
	AssemblyName_t894705941::get_offset_of_name_0(),
	AssemblyName_t894705941::get_offset_of_codebase_1(),
	AssemblyName_t894705941::get_offset_of_major_2(),
	AssemblyName_t894705941::get_offset_of_minor_3(),
	AssemblyName_t894705941::get_offset_of_build_4(),
	AssemblyName_t894705941::get_offset_of_revision_5(),
	AssemblyName_t894705941::get_offset_of_cultureinfo_6(),
	AssemblyName_t894705941::get_offset_of_flags_7(),
	AssemblyName_t894705941::get_offset_of_hashalg_8(),
	AssemblyName_t894705941::get_offset_of_keypair_9(),
	AssemblyName_t894705941::get_offset_of_publicKey_10(),
	AssemblyName_t894705941::get_offset_of_keyToken_11(),
	AssemblyName_t894705941::get_offset_of_versioncompat_12(),
	AssemblyName_t894705941::get_offset_of_version_13(),
	AssemblyName_t894705941::get_offset_of_processor_architecture_14(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize435 = { sizeof (AssemblyNameFlags_t1794031440)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable435[6] = 
{
	AssemblyNameFlags_t1794031440::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize436 = { sizeof (AssemblyProductAttribute_t1523443169), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable436[1] = 
{
	AssemblyProductAttribute_t1523443169::get_offset_of_name_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize437 = { sizeof (AssemblyTitleAttribute_t92945912), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable437[1] = 
{
	AssemblyTitleAttribute_t92945912::get_offset_of_name_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize438 = { sizeof (AssemblyTrademarkAttribute_t3740556705), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable438[1] = 
{
	AssemblyTrademarkAttribute_t3740556705::get_offset_of_name_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize439 = { sizeof (Binder_t3404612058), -1, sizeof(Binder_t3404612058_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable439[1] = 
{
	Binder_t3404612058_StaticFields::get_offset_of_default_binder_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize440 = { sizeof (Default_t3956931304), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize441 = { sizeof (BindingFlags_t1082350898)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable441[21] = 
{
	BindingFlags_t1082350898::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize442 = { sizeof (CallingConventions_t1097349142)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable442[6] = 
{
	CallingConventions_t1097349142::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize443 = { sizeof (ConstructorInfo_t2851816542), -1, sizeof(ConstructorInfo_t2851816542_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable443[2] = 
{
	ConstructorInfo_t2851816542_StaticFields::get_offset_of_ConstructorName_0(),
	ConstructorInfo_t2851816542_StaticFields::get_offset_of_TypeConstructorName_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize444 = { sizeof (CustomAttributeData_t3093286891), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable444[3] = 
{
	CustomAttributeData_t3093286891::get_offset_of_ctorInfo_0(),
	CustomAttributeData_t3093286891::get_offset_of_ctorArgs_1(),
	CustomAttributeData_t3093286891::get_offset_of_namedArgs_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize445 = { sizeof (CustomAttributeNamedArgument_t94157543)+ sizeof (Il2CppObject), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable445[2] = 
{
	CustomAttributeNamedArgument_t94157543::get_offset_of_typedArgument_0() + static_cast<int32_t>(sizeof(Il2CppObject)),
	CustomAttributeNamedArgument_t94157543::get_offset_of_memberInfo_1() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize446 = { sizeof (CustomAttributeTypedArgument_t1498197914)+ sizeof (Il2CppObject), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable446[2] = 
{
	CustomAttributeTypedArgument_t1498197914::get_offset_of_argumentType_0() + static_cast<int32_t>(sizeof(Il2CppObject)),
	CustomAttributeTypedArgument_t1498197914::get_offset_of_value_1() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize447 = { sizeof (EventAttributes_t2989788983)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable447[5] = 
{
	EventAttributes_t2989788983::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize448 = { sizeof (EventInfo_t), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable448[1] = 
{
	EventInfo_t::get_offset_of_cached_add_event_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize449 = { sizeof (AddEventAdapter_t1766862959), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize450 = { sizeof (FieldAttributes_t1122705193)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable450[20] = 
{
	FieldAttributes_t1122705193::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize451 = { sizeof (FieldInfo_t), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize452 = { sizeof (LocalVariableInfo_t1749284021), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable452[3] = 
{
	LocalVariableInfo_t1749284021::get_offset_of_type_0(),
	LocalVariableInfo_t1749284021::get_offset_of_is_pinned_1(),
	LocalVariableInfo_t1749284021::get_offset_of_position_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize453 = { sizeof (MemberInfoSerializationHolder_t2799051170), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable453[5] = 
{
	MemberInfoSerializationHolder_t2799051170::get_offset_of__memberName_0(),
	MemberInfoSerializationHolder_t2799051170::get_offset_of__memberSignature_1(),
	MemberInfoSerializationHolder_t2799051170::get_offset_of__memberType_2(),
	MemberInfoSerializationHolder_t2799051170::get_offset_of__reflectedType_3(),
	MemberInfoSerializationHolder_t2799051170::get_offset_of__genericArguments_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize454 = { sizeof (MemberTypes_t3343038963)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable454[10] = 
{
	MemberTypes_t3343038963::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize455 = { sizeof (MethodAttributes_t790385034)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable455[25] = 
{
	MethodAttributes_t790385034::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize456 = { sizeof (MethodBase_t904190842), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize457 = { sizeof (MethodImplAttributes_t1541361196)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable457[15] = 
{
	MethodImplAttributes_t1541361196::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize458 = { sizeof (MethodInfo_t), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize459 = { sizeof (Missing_t1033855606), -1, sizeof(Missing_t1033855606_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable459[1] = 
{
	Missing_t1033855606_StaticFields::get_offset_of_Value_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize460 = { sizeof (Module_t4282841206), -1, sizeof(Module_t4282841206_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable460[10] = 
{
	0,
	Module_t4282841206_StaticFields::get_offset_of_FilterTypeName_1(),
	Module_t4282841206_StaticFields::get_offset_of_FilterTypeNameIgnoreCase_2(),
	Module_t4282841206::get_offset_of__impl_3(),
	Module_t4282841206::get_offset_of_assembly_4(),
	Module_t4282841206::get_offset_of_fqname_5(),
	Module_t4282841206::get_offset_of_name_6(),
	Module_t4282841206::get_offset_of_scopename_7(),
	Module_t4282841206::get_offset_of_is_resource_8(),
	Module_t4282841206::get_offset_of_token_9(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize461 = { sizeof (MonoGenericMethod_t), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize462 = { sizeof (MonoGenericCMethod_t2923423538), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize463 = { sizeof (MonoEventInfo_t2190036573)+ sizeof (Il2CppObject), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable463[8] = 
{
	MonoEventInfo_t2190036573::get_offset_of_declaring_type_0() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoEventInfo_t2190036573::get_offset_of_reflected_type_1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoEventInfo_t2190036573::get_offset_of_name_2() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoEventInfo_t2190036573::get_offset_of_add_method_3() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoEventInfo_t2190036573::get_offset_of_remove_method_4() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoEventInfo_t2190036573::get_offset_of_raise_method_5() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoEventInfo_t2190036573::get_offset_of_attrs_6() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoEventInfo_t2190036573::get_offset_of_other_methods_7() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize464 = { sizeof (MonoEvent_t), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable464[2] = 
{
	MonoEvent_t::get_offset_of_klass_1(),
	MonoEvent_t::get_offset_of_handle_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize465 = { sizeof (MonoField_t), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable465[5] = 
{
	MonoField_t::get_offset_of_klass_0(),
	MonoField_t::get_offset_of_fhandle_1(),
	MonoField_t::get_offset_of_name_2(),
	MonoField_t::get_offset_of_type_3(),
	MonoField_t::get_offset_of_attrs_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize466 = { sizeof (MonoMethodInfo_t3646562144)+ sizeof (Il2CppObject), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable466[5] = 
{
	MonoMethodInfo_t3646562144::get_offset_of_parent_0() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoMethodInfo_t3646562144::get_offset_of_ret_1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoMethodInfo_t3646562144::get_offset_of_attrs_2() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoMethodInfo_t3646562144::get_offset_of_iattrs_3() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoMethodInfo_t3646562144::get_offset_of_callconv_4() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize467 = { sizeof (MonoMethod_t), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable467[3] = 
{
	MonoMethod_t::get_offset_of_mhandle_0(),
	MonoMethod_t::get_offset_of_name_1(),
	MonoMethod_t::get_offset_of_reftype_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize468 = { sizeof (MonoCMethod_t611352247), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable468[3] = 
{
	MonoCMethod_t611352247::get_offset_of_mhandle_2(),
	MonoCMethod_t611352247::get_offset_of_name_3(),
	MonoCMethod_t611352247::get_offset_of_reftype_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize469 = { sizeof (MonoPropertyInfo_t486106184)+ sizeof (Il2CppObject), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable469[5] = 
{
	MonoPropertyInfo_t486106184::get_offset_of_parent_0() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoPropertyInfo_t486106184::get_offset_of_name_1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoPropertyInfo_t486106184::get_offset_of_get_method_2() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoPropertyInfo_t486106184::get_offset_of_set_method_3() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoPropertyInfo_t486106184::get_offset_of_attrs_4() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize470 = { sizeof (PInfo_t957350482)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable470[7] = 
{
	PInfo_t957350482::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize471 = { sizeof (MonoProperty_t), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable471[5] = 
{
	MonoProperty_t::get_offset_of_klass_0(),
	MonoProperty_t::get_offset_of_prop_1(),
	MonoProperty_t::get_offset_of_info_2(),
	MonoProperty_t::get_offset_of_cached_3(),
	MonoProperty_t::get_offset_of_cached_getter_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize472 = { sizeof (GetterAdapter_t1423755509), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize473 = { 0, 0, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize474 = { 0, 0, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize475 = { sizeof (ParameterAttributes_t1266705348)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable475[12] = 
{
	ParameterAttributes_t1266705348::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize476 = { sizeof (ParameterInfo_t2249040075), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable476[7] = 
{
	ParameterInfo_t2249040075::get_offset_of_ClassImpl_0(),
	ParameterInfo_t2249040075::get_offset_of_DefaultValueImpl_1(),
	ParameterInfo_t2249040075::get_offset_of_MemberImpl_2(),
	ParameterInfo_t2249040075::get_offset_of_NameImpl_3(),
	ParameterInfo_t2249040075::get_offset_of_PositionImpl_4(),
	ParameterInfo_t2249040075::get_offset_of_AttrsImpl_5(),
	ParameterInfo_t2249040075::get_offset_of_marshalAs_6(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize477 = { sizeof (ParameterModifier_t1820634920)+ sizeof (Il2CppObject), sizeof(ParameterModifier_t1820634920_marshaled_pinvoke), 0, 0 };
extern const int32_t g_FieldOffsetTable477[1] = 
{
	ParameterModifier_t1820634920::get_offset_of__byref_0() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize478 = { sizeof (Pointer_t937075087), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable478[2] = 
{
	Pointer_t937075087::get_offset_of_data_0(),
	Pointer_t937075087::get_offset_of_type_1(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize479 = { sizeof (ProcessorArchitecture_t1620065459)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable479[6] = 
{
	ProcessorArchitecture_t1620065459::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize480 = { sizeof (PropertyAttributes_t883448530)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable480[9] = 
{
	PropertyAttributes_t883448530::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize481 = { sizeof (PropertyInfo_t), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize482 = { sizeof (ResourceAttributes_t2389678029)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable482[3] = 
{
	ResourceAttributes_t2389678029::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize483 = { sizeof (StrongNameKeyPair_t4090869089), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable483[5] = 
{
	StrongNameKeyPair_t4090869089::get_offset_of__publicKey_0(),
	StrongNameKeyPair_t4090869089::get_offset_of__keyPairContainer_1(),
	StrongNameKeyPair_t4090869089::get_offset_of__keyPairExported_2(),
	StrongNameKeyPair_t4090869089::get_offset_of__keyPairArray_3(),
	StrongNameKeyPair_t4090869089::get_offset_of__rsa_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize484 = { sizeof (TargetException_t1572104820), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize485 = { sizeof (TargetInvocationException_t4098620458), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize486 = { sizeof (TargetParameterCountException_t1554451430), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize487 = { sizeof (TypeAttributes_t2229518203)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable487[32] = 
{
	TypeAttributes_t2229518203::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize488 = { sizeof (TypeDelegator_t1357031879), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable488[1] = 
{
	TypeDelegator_t1357031879::get_offset_of_typeImpl_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize489 = { sizeof (RefEmitPermissionSet_t2708608433)+ sizeof (Il2CppObject), sizeof(RefEmitPermissionSet_t2708608433_marshaled_pinvoke), 0, 0 };
extern const int32_t g_FieldOffsetTable489[2] = 
{
	RefEmitPermissionSet_t2708608433::get_offset_of_action_0() + static_cast<int32_t>(sizeof(Il2CppObject)),
	RefEmitPermissionSet_t2708608433::get_offset_of_pset_1() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize490 = { sizeof (MonoResource_t3127387157)+ sizeof (Il2CppObject), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable490[6] = 
{
	MonoResource_t3127387157::get_offset_of_data_0() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoResource_t3127387157::get_offset_of_name_1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoResource_t3127387157::get_offset_of_filename_2() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoResource_t3127387157::get_offset_of_attrs_3() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoResource_t3127387157::get_offset_of_offset_4() + static_cast<int32_t>(sizeof(Il2CppObject)),
	MonoResource_t3127387157::get_offset_of_stream_5() + static_cast<int32_t>(sizeof(Il2CppObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize491 = { sizeof (AssemblyBuilder_t1646117627), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable491[25] = 
{
	AssemblyBuilder_t1646117627::get_offset_of_modules_10(),
	AssemblyBuilder_t1646117627::get_offset_of_name_11(),
	AssemblyBuilder_t1646117627::get_offset_of_dir_12(),
	AssemblyBuilder_t1646117627::get_offset_of_resources_13(),
	AssemblyBuilder_t1646117627::get_offset_of_version_14(),
	AssemblyBuilder_t1646117627::get_offset_of_culture_15(),
	AssemblyBuilder_t1646117627::get_offset_of_flags_16(),
	AssemblyBuilder_t1646117627::get_offset_of_pekind_17(),
	AssemblyBuilder_t1646117627::get_offset_of_access_18(),
	AssemblyBuilder_t1646117627::get_offset_of_loaded_modules_19(),
	AssemblyBuilder_t1646117627::get_offset_of_permissions_minimum_20(),
	AssemblyBuilder_t1646117627::get_offset_of_permissions_optional_21(),
	AssemblyBuilder_t1646117627::get_offset_of_permissions_refused_22(),
	AssemblyBuilder_t1646117627::get_offset_of_corlib_internal_23(),
	AssemblyBuilder_t1646117627::get_offset_of_pktoken_24(),
	AssemblyBuilder_t1646117627::get_offset_of_corlib_object_type_25(),
	AssemblyBuilder_t1646117627::get_offset_of_corlib_value_type_26(),
	AssemblyBuilder_t1646117627::get_offset_of_corlib_enum_type_27(),
	AssemblyBuilder_t1646117627::get_offset_of_corlib_void_type_28(),
	AssemblyBuilder_t1646117627::get_offset_of_created_29(),
	AssemblyBuilder_t1646117627::get_offset_of_is_module_only_30(),
	AssemblyBuilder_t1646117627::get_offset_of_sn_31(),
	AssemblyBuilder_t1646117627::get_offset_of_is_compiler_context_32(),
	AssemblyBuilder_t1646117627::get_offset_of_versioninfo_culture_33(),
	AssemblyBuilder_t1646117627::get_offset_of_manifest_module_34(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize492 = { sizeof (AssemblyBuilderAccess_t1210911821)+ sizeof (Il2CppObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable492[5] = 
{
	AssemblyBuilderAccess_t1210911821::get_offset_of_value___1() + static_cast<int32_t>(sizeof(Il2CppObject)),
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize493 = { sizeof (ConstructorBuilder_t700974433), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable493[11] = 
{
	ConstructorBuilder_t700974433::get_offset_of_ilgen_2(),
	ConstructorBuilder_t700974433::get_offset_of_parameters_3(),
	ConstructorBuilder_t700974433::get_offset_of_attrs_4(),
	ConstructorBuilder_t700974433::get_offset_of_iattrs_5(),
	ConstructorBuilder_t700974433::get_offset_of_table_idx_6(),
	ConstructorBuilder_t700974433::get_offset_of_call_conv_7(),
	ConstructorBuilder_t700974433::get_offset_of_type_8(),
	ConstructorBuilder_t700974433::get_offset_of_pinfo_9(),
	ConstructorBuilder_t700974433::get_offset_of_init_locals_10(),
	ConstructorBuilder_t700974433::get_offset_of_paramModReq_11(),
	ConstructorBuilder_t700974433::get_offset_of_paramModOpt_12(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize494 = { sizeof (DerivedType_t1016359113), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable494[1] = 
{
	DerivedType_t1016359113::get_offset_of_elementType_8(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize495 = { sizeof (ByRefType_t1587086384), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize496 = { sizeof (DynamicMethod_t3307743052), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable496[17] = 
{
	DynamicMethod_t3307743052::get_offset_of_mhandle_0(),
	DynamicMethod_t3307743052::get_offset_of_name_1(),
	DynamicMethod_t3307743052::get_offset_of_returnType_2(),
	DynamicMethod_t3307743052::get_offset_of_parameters_3(),
	DynamicMethod_t3307743052::get_offset_of_attributes_4(),
	DynamicMethod_t3307743052::get_offset_of_callingConvention_5(),
	DynamicMethod_t3307743052::get_offset_of_module_6(),
	DynamicMethod_t3307743052::get_offset_of_skipVisibility_7(),
	DynamicMethod_t3307743052::get_offset_of_init_locals_8(),
	DynamicMethod_t3307743052::get_offset_of_ilgen_9(),
	DynamicMethod_t3307743052::get_offset_of_nrefs_10(),
	DynamicMethod_t3307743052::get_offset_of_refs_11(),
	DynamicMethod_t3307743052::get_offset_of_owner_12(),
	DynamicMethod_t3307743052::get_offset_of_deleg_13(),
	DynamicMethod_t3307743052::get_offset_of_method_14(),
	DynamicMethod_t3307743052::get_offset_of_pinfo_15(),
	DynamicMethod_t3307743052::get_offset_of_creating_16(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize497 = { sizeof (AnonHostModuleHolder_t4101997074), -1, sizeof(AnonHostModuleHolder_t4101997074_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable497[1] = 
{
	AnonHostModuleHolder_t4101997074_StaticFields::get_offset_of_anon_host_module_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize498 = { sizeof (DynamicMethodTokenGenerator_t435001088), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable498[1] = 
{
	DynamicMethodTokenGenerator_t435001088::get_offset_of_m_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize499 = { sizeof (EnumBuilder_t2808714468), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable499[2] = 
{
	EnumBuilder_t2808714468::get_offset_of__tb_8(),
	EnumBuilder_t2808714468::get_offset_of__underlyingType_9(),
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
