	.arch	armv7-a
	.syntax unified
	.eabi_attribute 67, "2.09"	@ Tag_conformance
	.eabi_attribute 6, 10	@ Tag_CPU_arch
	.eabi_attribute 7, 65	@ Tag_CPU_arch_profile
	.eabi_attribute 8, 1	@ Tag_ARM_ISA_use
	.eabi_attribute 9, 2	@ Tag_THUMB_ISA_use
	.fpu	vfpv3-d16
	.eabi_attribute 34, 1	@ Tag_CPU_unaligned_access
	.eabi_attribute 15, 1	@ Tag_ABI_PCS_RW_data
	.eabi_attribute 16, 1	@ Tag_ABI_PCS_RO_data
	.eabi_attribute 17, 2	@ Tag_ABI_PCS_GOT_use
	.eabi_attribute 20, 2	@ Tag_ABI_FP_denormal
	.eabi_attribute 21, 0	@ Tag_ABI_FP_exceptions
	.eabi_attribute 23, 3	@ Tag_ABI_FP_number_model
	.eabi_attribute 24, 1	@ Tag_ABI_align_needed
	.eabi_attribute 25, 1	@ Tag_ABI_align_preserved
	.eabi_attribute 38, 1	@ Tag_ABI_FP_16bit_format
	.eabi_attribute 18, 4	@ Tag_ABI_PCS_wchar_t
	.eabi_attribute 26, 2	@ Tag_ABI_enum_size
	.eabi_attribute 14, 0	@ Tag_ABI_PCS_R9_use
	.file	"compressed_assemblies.armeabi-v7a.armeabi-v7a.s"
	.include	"compressed_assemblies.armeabi-v7a-data.inc"

	.section	.data.compressed_assembly_descriptors,"aw",%progbits
	.type	.L.compressed_assembly_descriptors, %object
	.p2align	2
.L.compressed_assembly_descriptors:
	/* 0: Acr.Support.Android.dll */
	/* uncompressed_file_size */
	.long	5120
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_0

	/* 1: Acr.UserDialogs.Interface.dll */
	/* uncompressed_file_size */
	.long	41472
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_1

	/* 2: Acr.UserDialogs.dll */
	/* uncompressed_file_size */
	.long	40448
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_2

	/* 3: AndHUD.dll */
	/* uncompressed_file_size */
	.long	22016
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_3

	/* 4: FormsViewGroup.dll */
	/* uncompressed_file_size */
	.long	14336
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_4

	/* 5: Java.Interop.dll */
	/* uncompressed_file_size */
	.long	164352
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_5

	/* 6: Mono.Android.dll */
	/* uncompressed_file_size */
	.long	1891840
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_6

	/* 7: Mono.Security.dll */
	/* uncompressed_file_size */
	.long	121856
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_7

	/* 8: SATCARGO.dll */
	/* uncompressed_file_size */
	.long	369664
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_8

	/* 9: Splat.dll */
	/* uncompressed_file_size */
	.long	43008
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_9

	/* 10: System.Core.dll */
	/* uncompressed_file_size */
	.long	328704
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_10

	/* 11: System.Drawing.Common.dll */
	/* uncompressed_file_size */
	.long	40448
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_11

	/* 12: System.Net.Http.dll */
	/* uncompressed_file_size */
	.long	212480
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_12

	/* 13: System.Numerics.dll */
	/* uncompressed_file_size */
	.long	25600
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_13

	/* 14: System.Runtime.Serialization.dll */
	/* uncompressed_file_size */
	.long	400384
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_14

	/* 15: System.ServiceModel.Internals.dll */
	/* uncompressed_file_size */
	.long	55808
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_15

	/* 16: System.Xml.dll */
	/* uncompressed_file_size */
	.long	888832
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_16

	/* 17: System.dll */
	/* uncompressed_file_size */
	.long	759296
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_17

	/* 18: Xamarin.Android.Arch.Core.Common.dll */
	/* uncompressed_file_size */
	.long	5120
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_18

	/* 19: Xamarin.Android.Arch.Lifecycle.Common.dll */
	/* uncompressed_file_size */
	.long	14848
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_19

	/* 20: Xamarin.Android.Arch.Lifecycle.Runtime.dll */
	/* uncompressed_file_size */
	.long	5120
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_20

	/* 21: Xamarin.Android.Support.Animated.Vector.Drawable.dll */
	/* uncompressed_file_size */
	.long	6144
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_21

	/* 22: Xamarin.Android.Support.Annotations.dll */
	/* uncompressed_file_size */
	.long	5632
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_22

	/* 23: Xamarin.Android.Support.Compat.dll */
	/* uncompressed_file_size */
	.long	364544
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_23

	/* 24: Xamarin.Android.Support.Core.UI.dll */
	/* uncompressed_file_size */
	.long	123392
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_24

	/* 25: Xamarin.Android.Support.Core.Utils.dll */
	/* uncompressed_file_size */
	.long	32768
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_25

	/* 26: Xamarin.Android.Support.CustomTabs.dll */
	/* uncompressed_file_size */
	.long	8704
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_26

	/* 27: Xamarin.Android.Support.Design.dll */
	/* uncompressed_file_size */
	.long	178176
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_27

	/* 28: Xamarin.Android.Support.Fragment.dll */
	/* uncompressed_file_size */
	.long	161792
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_28

	/* 29: Xamarin.Android.Support.Media.Compat.dll */
	/* uncompressed_file_size */
	.long	6656
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_29

	/* 30: Xamarin.Android.Support.Transition.dll */
	/* uncompressed_file_size */
	.long	10752
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_30

	/* 31: Xamarin.Android.Support.Vector.Drawable.dll */
	/* uncompressed_file_size */
	.long	5120
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_31

	/* 32: Xamarin.Android.Support.v4.dll */
	/* uncompressed_file_size */
	.long	9728
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_32

	/* 33: Xamarin.Android.Support.v7.AppCompat.dll */
	/* uncompressed_file_size */
	.long	434176
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_33

	/* 34: Xamarin.Android.Support.v7.CardView.dll */
	/* uncompressed_file_size */
	.long	16384
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_34

	/* 35: Xamarin.Android.Support.v7.GridLayout.dll */
	/* uncompressed_file_size */
	.long	5632
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_35

	/* 36: Xamarin.Android.Support.v7.RecyclerView.dll */
	/* uncompressed_file_size */
	.long	377344
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_36

	/* 37: Xamarin.Forms.BehaviorValidationPack.dll */
	/* uncompressed_file_size */
	.long	13824
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_37

	/* 38: Xamarin.Forms.Core.dll */
	/* uncompressed_file_size */
	.long	971776
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_38

	/* 39: Xamarin.Forms.Platform.Android.dll */
	/* uncompressed_file_size */
	.long	679936
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_39

	/* 40: Xamarin.Forms.Platform.dll */
	/* uncompressed_file_size */
	.long	19072
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_40

	/* 41: Xamarin.Forms.Xaml.dll */
	/* uncompressed_file_size */
	.long	100352
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_41

	/* 42: mscorlib.dll */
	/* uncompressed_file_size */
	.long	2043904
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.long	compressed_assembly_data_42

	.size	.L.compressed_assembly_descriptors, 516
	.section	.data.compressed_assemblies,"aw",%progbits
	.type	compressed_assemblies, %object
	.p2align	2
	.global	compressed_assemblies
compressed_assemblies:
	/* count */
	.long	43
	/* descriptors */
	.long	.L.compressed_assembly_descriptors
	.size	compressed_assemblies, 8