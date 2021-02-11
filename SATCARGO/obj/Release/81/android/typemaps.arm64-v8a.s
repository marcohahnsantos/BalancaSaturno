	.arch	armv8-a
	.file	"typemaps.arm64-v8a.s"

/* map_module_count: START */
	.section	.rodata.map_module_count,"a",@progbits
	.type	map_module_count, @object
	.p2align	2
	.global	map_module_count
map_module_count:
	.size	map_module_count, 4
	.word	16
/* map_module_count: END */

/* java_type_count: START */
	.section	.rodata.java_type_count,"a",@progbits
	.type	java_type_count, @object
	.p2align	2
	.global	java_type_count
java_type_count:
	.size	java_type_count, 4
	.word	903
/* java_type_count: END */

/* java_name_width: START */
	.section	.rodata.java_name_width,"a",@progbits
	.type	java_name_width, @object
	.p2align	2
	.global	java_name_width
java_name_width:
	.size	java_name_width, 4
	.word	102
/* java_name_width: END */

	.include	"typemaps.shared.inc"
	.include	"typemaps.arm64-v8a-managed.inc"

/* Managed to Java map: START */
	.section	.data.rel.map_modules,"aw",@progbits
	.type	map_modules, @object
	.p2align	3
	.global	map_modules
map_modules:
	/* module_uuid: 6bf5980e-0480-4359-9a72-9bf385bac98f */
	.byte	0x0e, 0x98, 0xf5, 0x6b, 0x80, 0x04, 0x59, 0x43, 0x9a, 0x72, 0x9b, 0xf3, 0x85, 0xba, 0xc9, 0x8f
	/* entry_count */
	.word	18
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module0_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Acr.UserDialogs */
	.xword	.L.map_aname.0
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 2c286211-82e5-403e-888c-75d196f0fa02 */
	.byte	0x11, 0x62, 0x28, 0x2c, 0xe5, 0x82, 0x3e, 0x40, 0x88, 0x8c, 0x75, 0xd1, 0x96, 0xf0, 0xfa, 0x02
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module1_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.Android.Support.v7.CardView */
	.xword	.L.map_aname.1
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: aebdb213-571f-4588-82a8-594c4938e808 */
	.byte	0x13, 0xb2, 0xbd, 0xae, 0x1f, 0x57, 0x88, 0x45, 0x82, 0xa8, 0x59, 0x4c, 0x49, 0x38, 0xe8, 0x08
	/* entry_count */
	.word	2
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module2_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: AndHUD */
	.xword	.L.map_aname.2
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: e90c7416-8002-46f4-8c39-26a6d5335eca */
	.byte	0x16, 0x74, 0x0c, 0xe9, 0x02, 0x80, 0xf4, 0x46, 0x8c, 0x39, 0x26, 0xa6, 0xd5, 0x33, 0x5e, 0xca
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module3_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Acr.Support.Android */
	.xword	.L.map_aname.3
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 9862d416-8b47-4abf-836b-6967192e7760 */
	.byte	0x16, 0xd4, 0x62, 0x98, 0x47, 0x8b, 0xbf, 0x4a, 0x83, 0x6b, 0x69, 0x67, 0x19, 0x2e, 0x77, 0x60
	/* entry_count */
	.word	4
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module4_managed_to_java
	/* duplicate_map */
	.xword	module4_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Arch.Lifecycle.Common */
	.xword	.L.map_aname.4
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: d9853c2c-1489-42be-8bdf-724f4c5b257d */
	.byte	0x2c, 0x3c, 0x85, 0xd9, 0x89, 0x14, 0xbe, 0x42, 0x8b, 0xdf, 0x72, 0x4f, 0x4c, 0x5b, 0x25, 0x7d
	/* entry_count */
	.word	5
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module5_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.Android.Support.Core.Utils */
	.xword	.L.map_aname.5
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 05c5863b-ec7f-4cf8-b6f2-a9ac0e426bd5 */
	.byte	0x3b, 0x86, 0xc5, 0x05, 0x7f, 0xec, 0xf8, 0x4c, 0xb6, 0xf2, 0xa9, 0xac, 0x0e, 0x42, 0x6b, 0xd5
	/* entry_count */
	.word	31
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module6_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: SATCARGO */
	.xword	.L.map_aname.6
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 1a24b752-15b4-4723-ba3a-31bd4fef0529 */
	.byte	0x52, 0xb7, 0x24, 0x1a, 0xb4, 0x15, 0x23, 0x47, 0xba, 0x3a, 0x31, 0xbd, 0x4f, 0xef, 0x05, 0x29
	/* entry_count */
	.word	13
	/* duplicate_count */
	.word	5
	/* map */
	.xword	module7_managed_to_java
	/* duplicate_map */
	.xword	module7_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Fragment */
	.xword	.L.map_aname.7
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: f1606b76-442e-4b04-a631-2a84197abe35 */
	.byte	0x76, 0x6b, 0x60, 0xf1, 0x2e, 0x44, 0x04, 0x4b, 0xa6, 0x31, 0x2a, 0x84, 0x19, 0x7a, 0xbe, 0x35
	/* entry_count */
	.word	2
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module8_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: FormsViewGroup */
	.xword	.L.map_aname.8
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 19933279-476e-4283-ae86-b97b38dc70fe */
	.byte	0x79, 0x32, 0x93, 0x19, 0x6e, 0x47, 0x83, 0x42, 0xae, 0x86, 0xb9, 0x7b, 0x38, 0xdc, 0x70, 0xfe
	/* entry_count */
	.word	19
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module9_managed_to_java
	/* duplicate_map */
	.xword	module9_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Core.UI */
	.xword	.L.map_aname.9
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: d7ec4a8c-bad8-4f85-b927-21f259537ed8 */
	.byte	0x8c, 0x4a, 0xec, 0xd7, 0xd8, 0xba, 0x85, 0x4f, 0xb9, 0x27, 0x21, 0xf2, 0x59, 0x53, 0x7e, 0xd8
	/* entry_count */
	.word	48
	/* duplicate_count */
	.word	4
	/* map */
	.xword	module10_managed_to_java
	/* duplicate_map */
	.xword	module10_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.v7.AppCompat */
	.xword	.L.map_aname.10
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 281b8b8e-3bd9-4d99-a3aa-df28d48e42ae */
	.byte	0x8e, 0x8b, 0x1b, 0x28, 0xd9, 0x3b, 0x99, 0x4d, 0xa3, 0xaa, 0xdf, 0x28, 0xd4, 0x8e, 0x42, 0xae
	/* entry_count */
	.word	459
	/* duplicate_count */
	.word	75
	/* map */
	.xword	module11_managed_to_java
	/* duplicate_map */
	.xword	module11_managed_to_java_duplicates
	/* assembly_name: Mono.Android */
	.xword	.L.map_aname.11
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 026092ae-2dbf-4c22-81b4-9e945aff7e78 */
	.byte	0xae, 0x92, 0x60, 0x02, 0xbf, 0x2d, 0x22, 0x4c, 0x81, 0xb4, 0x9e, 0x94, 0x5a, 0xff, 0x7e, 0x78
	/* entry_count */
	.word	185
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module12_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.Forms.Platform.Android */
	.xword	.L.map_aname.12
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 8b45e6e8-ffc3-489f-b875-76bb1ab67823 */
	.byte	0xe8, 0xe6, 0x45, 0x8b, 0xc3, 0xff, 0x9f, 0x48, 0xb8, 0x75, 0x76, 0xbb, 0x1a, 0xb6, 0x78, 0x23
	/* entry_count */
	.word	44
	/* duplicate_count */
	.word	2
	/* map */
	.xword	module13_managed_to_java
	/* duplicate_map */
	.xword	module13_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Compat */
	.xword	.L.map_aname.13
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 20f786ea-82fa-4453-9d1f-b38e595c6d74 */
	.byte	0xea, 0x86, 0xf7, 0x20, 0xfa, 0x82, 0x53, 0x44, 0x9d, 0x1f, 0xb3, 0x8e, 0x59, 0x5c, 0x6d, 0x74
	/* entry_count */
	.word	29
	/* duplicate_count */
	.word	4
	/* map */
	.xword	module14_managed_to_java
	/* duplicate_map */
	.xword	module14_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Design */
	.xword	.L.map_aname.14
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: a7dcb8ef-99c8-472b-a7cc-dee847e2a2f7 */
	.byte	0xef, 0xb8, 0xdc, 0xa7, 0xc8, 0x99, 0x2b, 0x47, 0xa7, 0xcc, 0xde, 0xe8, 0x47, 0xe2, 0xa2, 0xf7
	/* entry_count */
	.word	42
	/* duplicate_count */
	.word	14
	/* map */
	.xword	module15_managed_to_java
	/* duplicate_map */
	.xword	module15_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.v7.RecyclerView */
	.xword	.L.map_aname.15
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	.size	map_modules, 1152
/* Managed to Java map: END */

/* Java to managed map: START */
	.section	.rodata.map_java,"a",@progbits
	.type	map_java, @object
	.p2align	2
	.global	map_java
map_java:
	/* #0 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555113
	/* java_name */
	.ascii	"android/animation/Animator"
	.zero	76

	/* #1 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555115
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorListener"
	.zero	59

	/* #2 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555117
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorPauseListener"
	.zero	54

	/* #3 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555127
	/* java_name */
	.ascii	"android/animation/AnimatorListenerAdapter"
	.zero	61

	/* #4 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555130
	/* java_name */
	.ascii	"android/animation/TimeInterpolator"
	.zero	68

	/* #5 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555119
	/* java_name */
	.ascii	"android/animation/ValueAnimator"
	.zero	71

	/* #6 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555121
	/* java_name */
	.ascii	"android/animation/ValueAnimator$AnimatorUpdateListener"
	.zero	48

	/* #7 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555132
	/* java_name */
	.ascii	"android/app/ActionBar"
	.zero	81

	/* #8 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555134
	/* java_name */
	.ascii	"android/app/ActionBar$Tab"
	.zero	77

	/* #9 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555137
	/* java_name */
	.ascii	"android/app/ActionBar$TabListener"
	.zero	69

	/* #10 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555139
	/* java_name */
	.ascii	"android/app/Activity"
	.zero	82

	/* #11 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555140
	/* java_name */
	.ascii	"android/app/AlertDialog"
	.zero	79

	/* #12 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555141
	/* java_name */
	.ascii	"android/app/AlertDialog$Builder"
	.zero	71

	/* #13 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555142
	/* java_name */
	.ascii	"android/app/Application"
	.zero	79

	/* #14 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555144
	/* java_name */
	.ascii	"android/app/Application$ActivityLifecycleCallbacks"
	.zero	52

	/* #15 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555145
	/* java_name */
	.ascii	"android/app/DatePickerDialog"
	.zero	74

	/* #16 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555148
	/* java_name */
	.ascii	"android/app/DatePickerDialog$OnDateSetListener"
	.zero	56

	/* #17 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555150
	/* java_name */
	.ascii	"android/app/Dialog"
	.zero	84

	/* #18 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555169
	/* java_name */
	.ascii	"android/app/DialogFragment"
	.zero	76

	/* #19 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555170
	/* java_name */
	.ascii	"android/app/Fragment"
	.zero	82

	/* #20 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555159
	/* java_name */
	.ascii	"android/app/FragmentManager"
	.zero	75

	/* #21 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555172
	/* java_name */
	.ascii	"android/app/FragmentTransaction"
	.zero	71

	/* #22 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555174
	/* java_name */
	.ascii	"android/app/PendingIntent"
	.zero	77

	/* #23 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555163
	/* java_name */
	.ascii	"android/app/TimePickerDialog"
	.zero	74

	/* #24 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555165
	/* java_name */
	.ascii	"android/app/TimePickerDialog$OnTimeSetListener"
	.zero	56

	/* #25 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/arch/lifecycle/Lifecycle"
	.zero	70

	/* #26 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"android/arch/lifecycle/Lifecycle$State"
	.zero	64

	/* #27 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"android/arch/lifecycle/LifecycleObserver"
	.zero	62

	/* #28 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"android/arch/lifecycle/LifecycleOwner"
	.zero	65

	/* #29 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555107
	/* java_name */
	.ascii	"android/bluetooth/BluetoothAdapter"
	.zero	68

	/* #30 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555108
	/* java_name */
	.ascii	"android/bluetooth/BluetoothDevice"
	.zero	69

	/* #31 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555109
	/* java_name */
	.ascii	"android/bluetooth/BluetoothServerSocket"
	.zero	63

	/* #32 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555110
	/* java_name */
	.ascii	"android/bluetooth/BluetoothSocket"
	.zero	69

	/* #33 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555180
	/* java_name */
	.ascii	"android/content/BroadcastReceiver"
	.zero	69

	/* #34 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555182
	/* java_name */
	.ascii	"android/content/ClipData"
	.zero	78

	/* #35 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555189
	/* java_name */
	.ascii	"android/content/ComponentCallbacks"
	.zero	68

	/* #36 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555191
	/* java_name */
	.ascii	"android/content/ComponentCallbacks2"
	.zero	67

	/* #37 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555183
	/* java_name */
	.ascii	"android/content/ComponentName"
	.zero	73

	/* #38 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555184
	/* java_name */
	.ascii	"android/content/ContentResolver"
	.zero	71

	/* #39 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555177
	/* java_name */
	.ascii	"android/content/Context"
	.zero	79

	/* #40 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555187
	/* java_name */
	.ascii	"android/content/ContextWrapper"
	.zero	72

	/* #41 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555213
	/* java_name */
	.ascii	"android/content/DialogInterface"
	.zero	71

	/* #42 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555193
	/* java_name */
	.ascii	"android/content/DialogInterface$OnCancelListener"
	.zero	54

	/* #43 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555196
	/* java_name */
	.ascii	"android/content/DialogInterface$OnClickListener"
	.zero	55

	/* #44 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555200
	/* java_name */
	.ascii	"android/content/DialogInterface$OnDismissListener"
	.zero	53

	/* #45 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555203
	/* java_name */
	.ascii	"android/content/DialogInterface$OnKeyListener"
	.zero	57

	/* #46 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555207
	/* java_name */
	.ascii	"android/content/DialogInterface$OnMultiChoiceClickListener"
	.zero	44

	/* #47 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555210
	/* java_name */
	.ascii	"android/content/DialogInterface$OnShowListener"
	.zero	56

	/* #48 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555178
	/* java_name */
	.ascii	"android/content/Intent"
	.zero	80

	/* #49 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555214
	/* java_name */
	.ascii	"android/content/IntentFilter"
	.zero	74

	/* #50 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555215
	/* java_name */
	.ascii	"android/content/IntentSender"
	.zero	74

	/* #51 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555217
	/* java_name */
	.ascii	"android/content/pm/ApplicationInfo"
	.zero	68

	/* #52 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555220
	/* java_name */
	.ascii	"android/content/pm/PackageItemInfo"
	.zero	68

	/* #53 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555221
	/* java_name */
	.ascii	"android/content/pm/PackageManager"
	.zero	69

	/* #54 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555226
	/* java_name */
	.ascii	"android/content/res/AssetManager"
	.zero	70

	/* #55 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555227
	/* java_name */
	.ascii	"android/content/res/ColorStateList"
	.zero	68

	/* #56 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555228
	/* java_name */
	.ascii	"android/content/res/Configuration"
	.zero	69

	/* #57 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555231
	/* java_name */
	.ascii	"android/content/res/Resources"
	.zero	73

	/* #58 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555232
	/* java_name */
	.ascii	"android/content/res/Resources$Theme"
	.zero	67

	/* #59 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555233
	/* java_name */
	.ascii	"android/content/res/TypedArray"
	.zero	72

	/* #60 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555229
	/* java_name */
	.ascii	"android/content/res/XmlResourceParser"
	.zero	65

	/* #61 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554621
	/* java_name */
	.ascii	"android/database/CharArrayBuffer"
	.zero	70

	/* #62 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554622
	/* java_name */
	.ascii	"android/database/ContentObserver"
	.zero	70

	/* #63 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554628
	/* java_name */
	.ascii	"android/database/Cursor"
	.zero	79

	/* #64 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554624
	/* java_name */
	.ascii	"android/database/DataSetObserver"
	.zero	70

	/* #65 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554629
	/* java_name */
	.ascii	"android/database/SQLException"
	.zero	73

	/* #66 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554632
	/* java_name */
	.ascii	"android/database/sqlite/SQLiteClosable"
	.zero	64

	/* #67 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554631
	/* java_name */
	.ascii	"android/database/sqlite/SQLiteCursorDriver"
	.zero	60

	/* #68 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554634
	/* java_name */
	.ascii	"android/database/sqlite/SQLiteDatabase"
	.zero	64

	/* #69 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554636
	/* java_name */
	.ascii	"android/database/sqlite/SQLiteDatabase$CursorFactory"
	.zero	50

	/* #70 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554637
	/* java_name */
	.ascii	"android/database/sqlite/SQLiteException"
	.zero	63

	/* #71 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554638
	/* java_name */
	.ascii	"android/database/sqlite/SQLiteProgram"
	.zero	65

	/* #72 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554640
	/* java_name */
	.ascii	"android/database/sqlite/SQLiteQuery"
	.zero	67

	/* #73 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555046
	/* java_name */
	.ascii	"android/graphics/Bitmap"
	.zero	79

	/* #74 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555047
	/* java_name */
	.ascii	"android/graphics/Bitmap$CompressFormat"
	.zero	64

	/* #75 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555048
	/* java_name */
	.ascii	"android/graphics/Bitmap$Config"
	.zero	72

	/* #76 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555052
	/* java_name */
	.ascii	"android/graphics/BitmapFactory"
	.zero	72

	/* #77 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555053
	/* java_name */
	.ascii	"android/graphics/BitmapFactory$Options"
	.zero	64

	/* #78 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555049
	/* java_name */
	.ascii	"android/graphics/Canvas"
	.zero	79

	/* #79 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555059
	/* java_name */
	.ascii	"android/graphics/ColorFilter"
	.zero	74

	/* #80 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555061
	/* java_name */
	.ascii	"android/graphics/Matrix"
	.zero	79

	/* #81 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555062
	/* java_name */
	.ascii	"android/graphics/Paint"
	.zero	80

	/* #82 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555063
	/* java_name */
	.ascii	"android/graphics/Paint$Align"
	.zero	74

	/* #83 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555064
	/* java_name */
	.ascii	"android/graphics/Paint$FontMetricsInt"
	.zero	65

	/* #84 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555065
	/* java_name */
	.ascii	"android/graphics/Paint$Style"
	.zero	74

	/* #85 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555067
	/* java_name */
	.ascii	"android/graphics/Path"
	.zero	81

	/* #86 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555068
	/* java_name */
	.ascii	"android/graphics/Path$Direction"
	.zero	71

	/* #87 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555069
	/* java_name */
	.ascii	"android/graphics/Point"
	.zero	80

	/* #88 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555070
	/* java_name */
	.ascii	"android/graphics/PointF"
	.zero	79

	/* #89 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555071
	/* java_name */
	.ascii	"android/graphics/PorterDuff"
	.zero	75

	/* #90 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555072
	/* java_name */
	.ascii	"android/graphics/PorterDuff$Mode"
	.zero	70

	/* #91 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555073
	/* java_name */
	.ascii	"android/graphics/PorterDuffXfermode"
	.zero	67

	/* #92 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555074
	/* java_name */
	.ascii	"android/graphics/Rect"
	.zero	81

	/* #93 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555075
	/* java_name */
	.ascii	"android/graphics/RectF"
	.zero	80

	/* #94 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555076
	/* java_name */
	.ascii	"android/graphics/Shader"
	.zero	79

	/* #95 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555077
	/* java_name */
	.ascii	"android/graphics/Typeface"
	.zero	77

	/* #96 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555079
	/* java_name */
	.ascii	"android/graphics/Xfermode"
	.zero	77

	/* #97 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555094
	/* java_name */
	.ascii	"android/graphics/drawable/Animatable"
	.zero	66

	/* #98 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555098
	/* java_name */
	.ascii	"android/graphics/drawable/Animatable2"
	.zero	65

	/* #99 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555095
	/* java_name */
	.ascii	"android/graphics/drawable/Animatable2$AnimationCallback"
	.zero	47

	/* #100 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555087
	/* java_name */
	.ascii	"android/graphics/drawable/AnimatedVectorDrawable"
	.zero	54

	/* #101 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555088
	/* java_name */
	.ascii	"android/graphics/drawable/AnimationDrawable"
	.zero	59

	/* #102 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555089
	/* java_name */
	.ascii	"android/graphics/drawable/BitmapDrawable"
	.zero	62

	/* #103 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555090
	/* java_name */
	.ascii	"android/graphics/drawable/ColorDrawable"
	.zero	63

	/* #104 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555080
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable"
	.zero	68

	/* #105 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555082
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable$Callback"
	.zero	59

	/* #106 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555083
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable$ConstantState"
	.zero	54

	/* #107 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555085
	/* java_name */
	.ascii	"android/graphics/drawable/DrawableContainer"
	.zero	59

	/* #108 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555092
	/* java_name */
	.ascii	"android/graphics/drawable/GradientDrawable"
	.zero	60

	/* #109 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555086
	/* java_name */
	.ascii	"android/graphics/drawable/LayerDrawable"
	.zero	63

	/* #110 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555099
	/* java_name */
	.ascii	"android/graphics/drawable/RippleDrawable"
	.zero	62

	/* #111 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555100
	/* java_name */
	.ascii	"android/graphics/drawable/ShapeDrawable"
	.zero	63

	/* #112 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555102
	/* java_name */
	.ascii	"android/graphics/drawable/StateListDrawable"
	.zero	59

	/* #113 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555103
	/* java_name */
	.ascii	"android/graphics/drawable/shapes/OvalShape"
	.zero	60

	/* #114 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555104
	/* java_name */
	.ascii	"android/graphics/drawable/shapes/RectShape"
	.zero	60

	/* #115 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555105
	/* java_name */
	.ascii	"android/graphics/drawable/shapes/Shape"
	.zero	64

	/* #116 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555043
	/* java_name */
	.ascii	"android/net/Uri"
	.zero	87

	/* #117 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555015
	/* java_name */
	.ascii	"android/opengl/GLSurfaceView"
	.zero	74

	/* #118 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555017
	/* java_name */
	.ascii	"android/opengl/GLSurfaceView$Renderer"
	.zero	65

	/* #119 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555022
	/* java_name */
	.ascii	"android/os/BaseBundle"
	.zero	81

	/* #120 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555023
	/* java_name */
	.ascii	"android/os/Build"
	.zero	86

	/* #121 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555024
	/* java_name */
	.ascii	"android/os/Build$VERSION"
	.zero	78

	/* #122 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555026
	/* java_name */
	.ascii	"android/os/Bundle"
	.zero	85

	/* #123 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555027
	/* java_name */
	.ascii	"android/os/Environment"
	.zero	80

	/* #124 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555019
	/* java_name */
	.ascii	"android/os/Handler"
	.zero	84

	/* #125 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555031
	/* java_name */
	.ascii	"android/os/IBinder"
	.zero	84

	/* #126 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555029
	/* java_name */
	.ascii	"android/os/IBinder$DeathRecipient"
	.zero	69

	/* #127 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555033
	/* java_name */
	.ascii	"android/os/IInterface"
	.zero	81

	/* #128 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555038
	/* java_name */
	.ascii	"android/os/Looper"
	.zero	85

	/* #129 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555020
	/* java_name */
	.ascii	"android/os/Message"
	.zero	84

	/* #130 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555039
	/* java_name */
	.ascii	"android/os/Parcel"
	.zero	85

	/* #131 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555041
	/* java_name */
	.ascii	"android/os/ParcelUuid"
	.zero	81

	/* #132 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555037
	/* java_name */
	.ascii	"android/os/Parcelable"
	.zero	81

	/* #133 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555035
	/* java_name */
	.ascii	"android/os/Parcelable$Creator"
	.zero	73

	/* #134 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555021
	/* java_name */
	.ascii	"android/os/PowerManager"
	.zero	79

	/* #135 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554617
	/* java_name */
	.ascii	"android/provider/Settings"
	.zero	77

	/* #136 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554618
	/* java_name */
	.ascii	"android/provider/Settings$Global"
	.zero	70

	/* #137 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554619
	/* java_name */
	.ascii	"android/provider/Settings$NameValueTable"
	.zero	62

	/* #138 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554620
	/* java_name */
	.ascii	"android/provider/Settings$System"
	.zero	70

	/* #139 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555279
	/* java_name */
	.ascii	"android/runtime/JavaProxyThrowable"
	.zero	68

	/* #140 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555305
	/* java_name */
	.ascii	"android/runtime/XmlReaderPullParser"
	.zero	67

	/* #141 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554488
	/* java_name */
	.ascii	"android/support/design/internal/BottomNavigationItemView"
	.zero	46

	/* #142 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554489
	/* java_name */
	.ascii	"android/support/design/internal/BottomNavigationMenuView"
	.zero	46

	/* #143 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554490
	/* java_name */
	.ascii	"android/support/design/internal/BottomNavigationPresenter"
	.zero	45

	/* #144 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/design/widget/AppBarLayout"
	.zero	60

	/* #145 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"android/support/design/widget/AppBarLayout$LayoutParams"
	.zero	47

	/* #146 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"android/support/design/widget/AppBarLayout$OnOffsetChangedListener"
	.zero	36

	/* #147 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"android/support/design/widget/AppBarLayout$ScrollingViewBehavior"
	.zero	38

	/* #148 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554465
	/* java_name */
	.ascii	"android/support/design/widget/BaseTransientBottomBar"
	.zero	50

	/* #149 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554466
	/* java_name */
	.ascii	"android/support/design/widget/BaseTransientBottomBar$BaseCallback"
	.zero	37

	/* #150 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554469
	/* java_name */
	.ascii	"android/support/design/widget/BaseTransientBottomBar$ContentViewCallback"
	.zero	30

	/* #151 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554471
	/* java_name */
	.ascii	"android/support/design/widget/BottomNavigationView"
	.zero	52

	/* #152 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"android/support/design/widget/BottomNavigationView$OnNavigationItemReselectedListener"
	.zero	17

	/* #153 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554477
	/* java_name */
	.ascii	"android/support/design/widget/BottomNavigationView$OnNavigationItemSelectedListener"
	.zero	19

	/* #154 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554484
	/* java_name */
	.ascii	"android/support/design/widget/BottomSheetDialog"
	.zero	55

	/* #155 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"android/support/design/widget/CoordinatorLayout"
	.zero	55

	/* #156 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554448
	/* java_name */
	.ascii	"android/support/design/widget/CoordinatorLayout$Behavior"
	.zero	46

	/* #157 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"android/support/design/widget/CoordinatorLayout$LayoutParams"
	.zero	42

	/* #158 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554485
	/* java_name */
	.ascii	"android/support/design/widget/HeaderScrollingViewBehavior"
	.zero	45

	/* #159 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"android/support/design/widget/Snackbar"
	.zero	64

	/* #160 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554446
	/* java_name */
	.ascii	"android/support/design/widget/Snackbar$Callback"
	.zero	55

	/* #161 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"android/support/design/widget/Snackbar_SnackbarActionClickImplementor"
	.zero	33

	/* #162 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554451
	/* java_name */
	.ascii	"android/support/design/widget/TabLayout"
	.zero	63

	/* #163 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"android/support/design/widget/TabLayout$OnTabSelectedListener"
	.zero	41

	/* #164 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554458
	/* java_name */
	.ascii	"android/support/design/widget/TabLayout$Tab"
	.zero	59

	/* #165 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554487
	/* java_name */
	.ascii	"android/support/design/widget/ViewOffsetBehavior"
	.zero	54

	/* #166 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v4/app/ActionBarDrawerToggle"
	.zero	58

	/* #167 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554497
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat"
	.zero	65

	/* #168 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554499
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$OnRequestPermissionsResultCallback"
	.zero	30

	/* #169 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554501
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$PermissionCompatDelegate"
	.zero	40

	/* #170 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554503
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$RequestPermissionsRequestCodeValidator"
	.zero	26

	/* #171 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"android/support/v4/app/DialogFragment"
	.zero	65

	/* #172 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"android/support/v4/app/Fragment"
	.zero	71

	/* #173 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"android/support/v4/app/Fragment$SavedState"
	.zero	60

	/* #174 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v4/app/FragmentActivity"
	.zero	63

	/* #175 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager"
	.zero	64

	/* #176 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$BackStackEntry"
	.zero	49

	/* #177 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$FragmentLifecycleCallbacks"
	.zero	37

	/* #178 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$OnBackStackChangedListener"
	.zero	37

	/* #179 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"android/support/v4/app/FragmentPagerAdapter"
	.zero	59

	/* #180 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554452
	/* java_name */
	.ascii	"android/support/v4/app/FragmentTransaction"
	.zero	60

	/* #181 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554454
	/* java_name */
	.ascii	"android/support/v4/app/LoaderManager"
	.zero	66

	/* #182 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554456
	/* java_name */
	.ascii	"android/support/v4/app/LoaderManager$LoaderCallbacks"
	.zero	50

	/* #183 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554504
	/* java_name */
	.ascii	"android/support/v4/app/SharedElementCallback"
	.zero	58

	/* #184 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554506
	/* java_name */
	.ascii	"android/support/v4/app/SharedElementCallback$OnSharedElementsReadyListener"
	.zero	28

	/* #185 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"android/support/v4/app/TaskStackBuilder"
	.zero	63

	/* #186 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"android/support/v4/app/TaskStackBuilder$SupportParentable"
	.zero	45

	/* #187 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554496
	/* java_name */
	.ascii	"android/support/v4/content/ContextCompat"
	.zero	62

	/* #188 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v4/content/Loader"
	.zero	69

	/* #189 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"android/support/v4/content/Loader$OnLoadCanceledListener"
	.zero	46

	/* #190 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"android/support/v4/content/Loader$OnLoadCompleteListener"
	.zero	46

	/* #191 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554495
	/* java_name */
	.ascii	"android/support/v4/graphics/drawable/DrawableCompat"
	.zero	51

	/* #192 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554492
	/* java_name */
	.ascii	"android/support/v4/internal/view/SupportMenu"
	.zero	58

	/* #193 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554494
	/* java_name */
	.ascii	"android/support/v4/internal/view/SupportMenuItem"
	.zero	54

	/* #194 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554443
	/* java_name */
	.ascii	"android/support/v4/view/AccessibilityDelegateCompat"
	.zero	51

	/* #195 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider"
	.zero	64

	/* #196 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554446
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider$SubUiVisibilityListener"
	.zero	40

	/* #197 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider$VisibilityListener"
	.zero	45

	/* #198 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554476
	/* java_name */
	.ascii	"android/support/v4/view/MenuItemCompat"
	.zero	64

	/* #199 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554478
	/* java_name */
	.ascii	"android/support/v4/view/MenuItemCompat$OnActionExpandListener"
	.zero	41

	/* #200 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"android/support/v4/view/NestedScrollingChild"
	.zero	58

	/* #201 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554461
	/* java_name */
	.ascii	"android/support/v4/view/NestedScrollingChild2"
	.zero	57

	/* #202 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554463
	/* java_name */
	.ascii	"android/support/v4/view/NestedScrollingParent"
	.zero	57

	/* #203 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554465
	/* java_name */
	.ascii	"android/support/v4/view/NestedScrollingParent2"
	.zero	56

	/* #204 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"android/support/v4/view/OnApplyWindowInsetsListener"
	.zero	51

	/* #205 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"android/support/v4/view/PagerAdapter"
	.zero	66

	/* #206 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554479
	/* java_name */
	.ascii	"android/support/v4/view/PointerIconCompat"
	.zero	61

	/* #207 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554480
	/* java_name */
	.ascii	"android/support/v4/view/ScaleGestureDetectorCompat"
	.zero	52

	/* #208 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554469
	/* java_name */
	.ascii	"android/support/v4/view/ScrollingView"
	.zero	65

	/* #209 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554471
	/* java_name */
	.ascii	"android/support/v4/view/TintableBackgroundView"
	.zero	56

	/* #210 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554481
	/* java_name */
	.ascii	"android/support/v4/view/ViewCompat"
	.zero	68

	/* #211 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"android/support/v4/view/ViewPager"
	.zero	69

	/* #212 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"android/support/v4/view/ViewPager$OnAdapterChangeListener"
	.zero	45

	/* #213 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"android/support/v4/view/ViewPager$OnPageChangeListener"
	.zero	48

	/* #214 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"android/support/v4/view/ViewPager$PageTransformer"
	.zero	53

	/* #215 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554482
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorCompat"
	.zero	52

	/* #216 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorListener"
	.zero	50

	/* #217 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorUpdateListener"
	.zero	44

	/* #218 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554483
	/* java_name */
	.ascii	"android/support/v4/view/WindowInsetsCompat"
	.zero	60

	/* #219 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554484
	/* java_name */
	.ascii	"android/support/v4/view/accessibility/AccessibilityNodeInfoCompat"
	.zero	37

	/* #220 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554485
	/* java_name */
	.ascii	"android/support/v4/view/accessibility/AccessibilityNodeInfoCompat$AccessibilityActionCompat"
	.zero	11

	/* #221 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554486
	/* java_name */
	.ascii	"android/support/v4/view/accessibility/AccessibilityNodeInfoCompat$CollectionInfoCompat"
	.zero	16

	/* #222 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554487
	/* java_name */
	.ascii	"android/support/v4/view/accessibility/AccessibilityNodeInfoCompat$CollectionItemInfoCompat"
	.zero	12

	/* #223 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554488
	/* java_name */
	.ascii	"android/support/v4/view/accessibility/AccessibilityNodeInfoCompat$RangeInfoCompat"
	.zero	21

	/* #224 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554489
	/* java_name */
	.ascii	"android/support/v4/view/accessibility/AccessibilityNodeProviderCompat"
	.zero	33

	/* #225 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554490
	/* java_name */
	.ascii	"android/support/v4/view/accessibility/AccessibilityWindowInfoCompat"
	.zero	35

	/* #226 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"android/support/v4/widget/AutoSizeableTextView"
	.zero	56

	/* #227 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v4/widget/CompoundButtonCompat"
	.zero	56

	/* #228 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"android/support/v4/widget/DrawerLayout"
	.zero	64

	/* #229 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554469
	/* java_name */
	.ascii	"android/support/v4/widget/DrawerLayout$DrawerListener"
	.zero	49

	/* #230 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"android/support/v4/widget/DrawerLayout$LayoutParams"
	.zero	51

	/* #231 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554484
	/* java_name */
	.ascii	"android/support/v4/widget/NestedScrollView"
	.zero	60

	/* #232 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554486
	/* java_name */
	.ascii	"android/support/v4/widget/NestedScrollView$OnScrollChangeListener"
	.zero	37

	/* #233 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"android/support/v4/widget/SwipeRefreshLayout"
	.zero	58

	/* #234 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554461
	/* java_name */
	.ascii	"android/support/v4/widget/SwipeRefreshLayout$OnChildScrollUpCallback"
	.zero	34

	/* #235 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554463
	/* java_name */
	.ascii	"android/support/v4/widget/SwipeRefreshLayout$OnRefreshListener"
	.zero	40

	/* #236 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"android/support/v4/widget/TextViewCompat"
	.zero	62

	/* #237 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"android/support/v4/widget/TintableCompoundButton"
	.zero	54

	/* #238 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"android/support/v4/widget/TintableImageSourceView"
	.zero	53

	/* #239 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554481
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar"
	.zero	70

	/* #240 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554482
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$LayoutParams"
	.zero	57

	/* #241 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554484
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$OnMenuVisibilityListener"
	.zero	45

	/* #242 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554488
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$OnNavigationListener"
	.zero	49

	/* #243 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554489
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$Tab"
	.zero	66

	/* #244 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554492
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$TabListener"
	.zero	58

	/* #245 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554496
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle"
	.zero	58

	/* #246 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554498
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle$Delegate"
	.zero	49

	/* #247 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554500
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle$DelegateProvider"
	.zero	41

	/* #248 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554476
	/* java_name */
	.ascii	"android/support/v7/app/AlertDialog"
	.zero	68

	/* #249 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554477
	/* java_name */
	.ascii	"android/support/v7/app/AlertDialog$Builder"
	.zero	60

	/* #250 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554479
	/* java_name */
	.ascii	"android/support/v7/app/AlertDialog_IDialogInterfaceOnCancelListenerImplementor"
	.zero	24

	/* #251 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554478
	/* java_name */
	.ascii	"android/support/v7/app/AlertDialog_IDialogInterfaceOnClickListenerImplementor"
	.zero	25

	/* #252 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554480
	/* java_name */
	.ascii	"android/support/v7/app/AlertDialog_IDialogInterfaceOnMultiChoiceClickListenerImplementor"
	.zero	14

	/* #253 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554501
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatActivity"
	.zero	62

	/* #254 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554507
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatCallback"
	.zero	62

	/* #255 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554502
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatDelegate"
	.zero	62

	/* #256 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554504
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatDialog"
	.zero	64

	/* #257 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554505
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatDialogFragment"
	.zero	56

	/* #258 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"android/support/v7/content/res/AppCompatResources"
	.zero	53

	/* #259 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v7/graphics/drawable/DrawableWrapper"
	.zero	50

	/* #260 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"android/support/v7/graphics/drawable/DrawerArrowDrawable"
	.zero	46

	/* #261 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"android/support/v7/view/ActionMode"
	.zero	68

	/* #262 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"android/support/v7/view/ActionMode$Callback"
	.zero	59

	/* #263 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuBuilder"
	.zero	62

	/* #264 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554452
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuBuilder$Callback"
	.zero	53

	/* #265 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuItemImpl"
	.zero	61

	/* #266 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuPresenter"
	.zero	60

	/* #267 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554443
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuPresenter$Callback"
	.zero	51

	/* #268 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554449
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuView"
	.zero	65

	/* #269 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuView$ItemView"
	.zero	56

	/* #270 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554454
	/* java_name */
	.ascii	"android/support/v7/view/menu/SubMenuBuilder"
	.zero	59

	/* #271 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554465
	/* java_name */
	.ascii	"android/support/v7/widget/AppCompatAutoCompleteTextView"
	.zero	47

	/* #272 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554466
	/* java_name */
	.ascii	"android/support/v7/widget/AppCompatButton"
	.zero	61

	/* #273 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"android/support/v7/widget/AppCompatCheckBox"
	.zero	59

	/* #274 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"android/support/v7/widget/AppCompatEditText"
	.zero	59

	/* #275 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554469
	/* java_name */
	.ascii	"android/support/v7/widget/AppCompatImageButton"
	.zero	56

	/* #276 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v7/widget/CardView"
	.zero	68

	/* #277 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554471
	/* java_name */
	.ascii	"android/support/v7/widget/DecorToolbar"
	.zero	64

	/* #278 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554498
	/* java_name */
	.ascii	"android/support/v7/widget/GridLayoutManager"
	.zero	59

	/* #279 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554499
	/* java_name */
	.ascii	"android/support/v7/widget/GridLayoutManager$LayoutParams"
	.zero	46

	/* #280 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554500
	/* java_name */
	.ascii	"android/support/v7/widget/GridLayoutManager$SpanSizeLookup"
	.zero	44

	/* #281 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554472
	/* java_name */
	.ascii	"android/support/v7/widget/LinearLayoutCompat"
	.zero	58

	/* #282 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554502
	/* java_name */
	.ascii	"android/support/v7/widget/LinearLayoutManager"
	.zero	57

	/* #283 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554503
	/* java_name */
	.ascii	"android/support/v7/widget/LinearSmoothScroller"
	.zero	56

	/* #284 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554504
	/* java_name */
	.ascii	"android/support/v7/widget/LinearSnapHelper"
	.zero	60

	/* #285 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554505
	/* java_name */
	.ascii	"android/support/v7/widget/OrientationHelper"
	.zero	59

	/* #286 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554507
	/* java_name */
	.ascii	"android/support/v7/widget/PagerSnapHelper"
	.zero	61

	/* #287 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView"
	.zero	64

	/* #288 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$Adapter"
	.zero	56

	/* #289 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$AdapterDataObserver"
	.zero	44

	/* #290 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$ChildDrawingOrderCallback"
	.zero	38

	/* #291 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$ItemAnimator"
	.zero	51

	/* #292 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$ItemAnimator$ItemAnimatorFinishedListener"
	.zero	22

	/* #293 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554448
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$ItemAnimator$ItemHolderInfo"
	.zero	36

	/* #294 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$ItemDecoration"
	.zero	49

	/* #295 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554452
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$LayoutManager"
	.zero	50

	/* #296 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554454
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$LayoutManager$LayoutPrefetchRegistry"
	.zero	27

	/* #297 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554455
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$LayoutManager$Properties"
	.zero	39

	/* #298 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$LayoutParams"
	.zero	51

	/* #299 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$OnChildAttachStateChangeListener"
	.zero	31

	/* #300 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554463
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$OnFlingListener"
	.zero	48

	/* #301 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554466
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$OnItemTouchListener"
	.zero	44

	/* #302 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$OnScrollListener"
	.zero	47

	/* #303 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554470
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$RecycledViewPool"
	.zero	47

	/* #304 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554471
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$Recycler"
	.zero	55

	/* #305 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$RecyclerListener"
	.zero	47

	/* #306 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554476
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$SmoothScroller"
	.zero	49

	/* #307 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554477
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$SmoothScroller$Action"
	.zero	42

	/* #308 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554479
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$SmoothScroller$ScrollVectorProvider"
	.zero	28

	/* #309 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554481
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$State"
	.zero	58

	/* #310 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554482
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$ViewCacheExtension"
	.zero	45

	/* #311 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554484
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerView$ViewHolder"
	.zero	53

	/* #312 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554508
	/* java_name */
	.ascii	"android/support/v7/widget/RecyclerViewAccessibilityDelegate"
	.zero	43

	/* #313 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"android/support/v7/widget/ScrollingTabContainerView"
	.zero	51

	/* #314 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554474
	/* java_name */
	.ascii	"android/support/v7/widget/ScrollingTabContainerView$VisibilityAnimListener"
	.zero	28

	/* #315 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554509
	/* java_name */
	.ascii	"android/support/v7/widget/SnapHelper"
	.zero	66

	/* #316 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"android/support/v7/widget/SwitchCompat"
	.zero	64

	/* #317 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554455
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar"
	.zero	69

	/* #318 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554458
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar$LayoutParams"
	.zero	56

	/* #319 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554460
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar$OnMenuItemClickListener"
	.zero	45

	/* #320 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554456
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar_NavigationOnClickEventDispatcher"
	.zero	36

	/* #321 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554513
	/* java_name */
	.ascii	"android/support/v7/widget/helper/ItemTouchHelper"
	.zero	54

	/* #322 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554514
	/* java_name */
	.ascii	"android/support/v7/widget/helper/ItemTouchHelper$Callback"
	.zero	45

	/* #323 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554517
	/* java_name */
	.ascii	"android/support/v7/widget/helper/ItemTouchHelper$ViewDropHandler"
	.zero	38

	/* #324 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554512
	/* java_name */
	.ascii	"android/support/v7/widget/helper/ItemTouchUIUtil"
	.zero	54

	/* #325 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554947
	/* java_name */
	.ascii	"android/text/Editable"
	.zero	81

	/* #326 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554950
	/* java_name */
	.ascii	"android/text/GetChars"
	.zero	81

	/* #327 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554945
	/* java_name */
	.ascii	"android/text/Html"
	.zero	85

	/* #328 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554954
	/* java_name */
	.ascii	"android/text/InputFilter"
	.zero	78

	/* #329 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554952
	/* java_name */
	.ascii	"android/text/InputFilter$LengthFilter"
	.zero	65

	/* #330 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554968
	/* java_name */
	.ascii	"android/text/Layout"
	.zero	83

	/* #331 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554956
	/* java_name */
	.ascii	"android/text/NoCopySpan"
	.zero	79

	/* #332 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554959
	/* java_name */
	.ascii	"android/text/ParcelableSpan"
	.zero	75

	/* #333 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554961
	/* java_name */
	.ascii	"android/text/Spannable"
	.zero	80

	/* #334 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554970
	/* java_name */
	.ascii	"android/text/SpannableString"
	.zero	74

	/* #335 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554972
	/* java_name */
	.ascii	"android/text/SpannableStringBuilder"
	.zero	67

	/* #336 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554974
	/* java_name */
	.ascii	"android/text/SpannableStringInternal"
	.zero	66

	/* #337 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554964
	/* java_name */
	.ascii	"android/text/Spanned"
	.zero	82

	/* #338 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554977
	/* java_name */
	.ascii	"android/text/TextPaint"
	.zero	80

	/* #339 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554978
	/* java_name */
	.ascii	"android/text/TextUtils"
	.zero	80

	/* #340 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554979
	/* java_name */
	.ascii	"android/text/TextUtils$TruncateAt"
	.zero	69

	/* #341 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554967
	/* java_name */
	.ascii	"android/text/TextWatcher"
	.zero	78

	/* #342 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555014
	/* java_name */
	.ascii	"android/text/format/DateFormat"
	.zero	72

	/* #343 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555002
	/* java_name */
	.ascii	"android/text/method/BaseKeyListener"
	.zero	67

	/* #344 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555004
	/* java_name */
	.ascii	"android/text/method/DigitsKeyListener"
	.zero	65

	/* #345 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555006
	/* java_name */
	.ascii	"android/text/method/KeyListener"
	.zero	71

	/* #346 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555009
	/* java_name */
	.ascii	"android/text/method/MetaKeyKeyListener"
	.zero	64

	/* #347 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555011
	/* java_name */
	.ascii	"android/text/method/NumberKeyListener"
	.zero	65

	/* #348 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555013
	/* java_name */
	.ascii	"android/text/method/PasswordTransformationMethod"
	.zero	54

	/* #349 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555008
	/* java_name */
	.ascii	"android/text/method/TransformationMethod"
	.zero	62

	/* #350 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554980
	/* java_name */
	.ascii	"android/text/style/BackgroundColorSpan"
	.zero	64

	/* #351 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554981
	/* java_name */
	.ascii	"android/text/style/CharacterStyle"
	.zero	69

	/* #352 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554983
	/* java_name */
	.ascii	"android/text/style/DynamicDrawableSpan"
	.zero	64

	/* #353 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554985
	/* java_name */
	.ascii	"android/text/style/ForegroundColorSpan"
	.zero	64

	/* #354 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554988
	/* java_name */
	.ascii	"android/text/style/ImageSpan"
	.zero	74

	/* #355 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554987
	/* java_name */
	.ascii	"android/text/style/LineHeightSpan"
	.zero	69

	/* #356 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554997
	/* java_name */
	.ascii	"android/text/style/MetricAffectingSpan"
	.zero	64

	/* #357 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554990
	/* java_name */
	.ascii	"android/text/style/ParagraphStyle"
	.zero	69

	/* #358 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554999
	/* java_name */
	.ascii	"android/text/style/ReplacementSpan"
	.zero	68

	/* #359 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554992
	/* java_name */
	.ascii	"android/text/style/UpdateAppearance"
	.zero	67

	/* #360 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554994
	/* java_name */
	.ascii	"android/text/style/UpdateLayout"
	.zero	71

	/* #361 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554996
	/* java_name */
	.ascii	"android/text/style/WrapTogetherSpan"
	.zero	67

	/* #362 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554936
	/* java_name */
	.ascii	"android/util/AttributeSet"
	.zero	77

	/* #363 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554934
	/* java_name */
	.ascii	"android/util/DisplayMetrics"
	.zero	75

	/* #364 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554932
	/* java_name */
	.ascii	"android/util/Log"
	.zero	86

	/* #365 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554937
	/* java_name */
	.ascii	"android/util/LruCache"
	.zero	81

	/* #366 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554938
	/* java_name */
	.ascii	"android/util/SparseArray"
	.zero	78

	/* #367 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554939
	/* java_name */
	.ascii	"android/util/StateSet"
	.zero	81

	/* #368 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554940
	/* java_name */
	.ascii	"android/util/TypedValue"
	.zero	79

	/* #369 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554814
	/* java_name */
	.ascii	"android/view/ActionMode"
	.zero	79

	/* #370 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554816
	/* java_name */
	.ascii	"android/view/ActionMode$Callback"
	.zero	70

	/* #371 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554819
	/* java_name */
	.ascii	"android/view/ActionProvider"
	.zero	75

	/* #372 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554834
	/* java_name */
	.ascii	"android/view/CollapsibleActionView"
	.zero	68

	/* #373 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554838
	/* java_name */
	.ascii	"android/view/ContextMenu"
	.zero	78

	/* #374 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554836
	/* java_name */
	.ascii	"android/view/ContextMenu$ContextMenuInfo"
	.zero	62

	/* #375 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554822
	/* java_name */
	.ascii	"android/view/ContextThemeWrapper"
	.zero	70

	/* #376 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554824
	/* java_name */
	.ascii	"android/view/Display"
	.zero	82

	/* #377 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554827
	/* java_name */
	.ascii	"android/view/GestureDetector"
	.zero	74

	/* #378 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554829
	/* java_name */
	.ascii	"android/view/GestureDetector$OnDoubleTapListener"
	.zero	54

	/* #379 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554831
	/* java_name */
	.ascii	"android/view/GestureDetector$OnGestureListener"
	.zero	56

	/* #380 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554850
	/* java_name */
	.ascii	"android/view/InputEvent"
	.zero	79

	/* #381 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554793
	/* java_name */
	.ascii	"android/view/KeyEvent"
	.zero	81

	/* #382 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554795
	/* java_name */
	.ascii	"android/view/KeyEvent$Callback"
	.zero	72

	/* #383 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554796
	/* java_name */
	.ascii	"android/view/LayoutInflater"
	.zero	75

	/* #384 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554798
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory"
	.zero	67

	/* #385 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554800
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory2"
	.zero	66

	/* #386 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554841
	/* java_name */
	.ascii	"android/view/Menu"
	.zero	85

	/* #387 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554874
	/* java_name */
	.ascii	"android/view/MenuInflater"
	.zero	77

	/* #388 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554848
	/* java_name */
	.ascii	"android/view/MenuItem"
	.zero	81

	/* #389 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554843
	/* java_name */
	.ascii	"android/view/MenuItem$OnActionExpandListener"
	.zero	58

	/* #390 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554845
	/* java_name */
	.ascii	"android/view/MenuItem$OnMenuItemClickListener"
	.zero	57

	/* #391 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554801
	/* java_name */
	.ascii	"android/view/MotionEvent"
	.zero	78

	/* #392 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554879
	/* java_name */
	.ascii	"android/view/ScaleGestureDetector"
	.zero	69

	/* #393 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554881
	/* java_name */
	.ascii	"android/view/ScaleGestureDetector$OnScaleGestureListener"
	.zero	46

	/* #394 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554882
	/* java_name */
	.ascii	"android/view/ScaleGestureDetector$SimpleOnScaleGestureListener"
	.zero	40

	/* #395 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554884
	/* java_name */
	.ascii	"android/view/SearchEvent"
	.zero	78

	/* #396 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554853
	/* java_name */
	.ascii	"android/view/SubMenu"
	.zero	82

	/* #397 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554887
	/* java_name */
	.ascii	"android/view/Surface"
	.zero	82

	/* #398 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554859
	/* java_name */
	.ascii	"android/view/SurfaceHolder"
	.zero	76

	/* #399 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554855
	/* java_name */
	.ascii	"android/view/SurfaceHolder$Callback"
	.zero	67

	/* #400 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554857
	/* java_name */
	.ascii	"android/view/SurfaceHolder$Callback2"
	.zero	66

	/* #401 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554889
	/* java_name */
	.ascii	"android/view/SurfaceView"
	.zero	78

	/* #402 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554749
	/* java_name */
	.ascii	"android/view/View"
	.zero	85

	/* #403 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554750
	/* java_name */
	.ascii	"android/view/View$AccessibilityDelegate"
	.zero	63

	/* #404 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554751
	/* java_name */
	.ascii	"android/view/View$DragShadowBuilder"
	.zero	67

	/* #405 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554752
	/* java_name */
	.ascii	"android/view/View$MeasureSpec"
	.zero	73

	/* #406 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554754
	/* java_name */
	.ascii	"android/view/View$OnAttachStateChangeListener"
	.zero	57

	/* #407 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554759
	/* java_name */
	.ascii	"android/view/View$OnClickListener"
	.zero	69

	/* #408 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554762
	/* java_name */
	.ascii	"android/view/View$OnCreateContextMenuListener"
	.zero	57

	/* #409 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554764
	/* java_name */
	.ascii	"android/view/View$OnFocusChangeListener"
	.zero	63

	/* #410 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554766
	/* java_name */
	.ascii	"android/view/View$OnKeyListener"
	.zero	71

	/* #411 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554770
	/* java_name */
	.ascii	"android/view/View$OnLayoutChangeListener"
	.zero	62

	/* #412 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554774
	/* java_name */
	.ascii	"android/view/View$OnScrollChangeListener"
	.zero	62

	/* #413 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554778
	/* java_name */
	.ascii	"android/view/View$OnTouchListener"
	.zero	69

	/* #414 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554892
	/* java_name */
	.ascii	"android/view/ViewConfiguration"
	.zero	72

	/* #415 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554894
	/* java_name */
	.ascii	"android/view/ViewGroup"
	.zero	80

	/* #416 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554895
	/* java_name */
	.ascii	"android/view/ViewGroup$LayoutParams"
	.zero	67

	/* #417 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554896
	/* java_name */
	.ascii	"android/view/ViewGroup$MarginLayoutParams"
	.zero	61

	/* #418 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554898
	/* java_name */
	.ascii	"android/view/ViewGroup$OnHierarchyChangeListener"
	.zero	54

	/* #419 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554861
	/* java_name */
	.ascii	"android/view/ViewManager"
	.zero	78

	/* #420 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554863
	/* java_name */
	.ascii	"android/view/ViewParent"
	.zero	79

	/* #421 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554900
	/* java_name */
	.ascii	"android/view/ViewPropertyAnimator"
	.zero	69

	/* #422 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554802
	/* java_name */
	.ascii	"android/view/ViewTreeObserver"
	.zero	73

	/* #423 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554804
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnGlobalFocusChangeListener"
	.zero	45

	/* #424 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554806
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnGlobalLayoutListener"
	.zero	50

	/* #425 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554808
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnPreDrawListener"
	.zero	55

	/* #426 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554810
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnTouchModeChangeListener"
	.zero	47

	/* #427 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554811
	/* java_name */
	.ascii	"android/view/Window"
	.zero	83

	/* #428 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554813
	/* java_name */
	.ascii	"android/view/Window$Callback"
	.zero	74

	/* #429 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554904
	/* java_name */
	.ascii	"android/view/WindowInsets"
	.zero	77

	/* #430 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554866
	/* java_name */
	.ascii	"android/view/WindowManager"
	.zero	76

	/* #431 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554864
	/* java_name */
	.ascii	"android/view/WindowManager$LayoutParams"
	.zero	63

	/* #432 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554923
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEvent"
	.zero	57

	/* #433 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554931
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEventSource"
	.zero	51

	/* #434 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554924
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityManager"
	.zero	55

	/* #435 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554925
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityNodeInfo"
	.zero	54

	/* #436 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554926
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityRecord"
	.zero	56

	/* #437 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554906
	/* java_name */
	.ascii	"android/view/animation/AccelerateInterpolator"
	.zero	57

	/* #438 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554907
	/* java_name */
	.ascii	"android/view/animation/Animation"
	.zero	70

	/* #439 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554909
	/* java_name */
	.ascii	"android/view/animation/Animation$AnimationListener"
	.zero	52

	/* #440 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554911
	/* java_name */
	.ascii	"android/view/animation/AnimationSet"
	.zero	67

	/* #441 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554912
	/* java_name */
	.ascii	"android/view/animation/AnimationUtils"
	.zero	65

	/* #442 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554913
	/* java_name */
	.ascii	"android/view/animation/BaseInterpolator"
	.zero	63

	/* #443 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554915
	/* java_name */
	.ascii	"android/view/animation/DecelerateInterpolator"
	.zero	57

	/* #444 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554917
	/* java_name */
	.ascii	"android/view/animation/Interpolator"
	.zero	67

	/* #445 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554918
	/* java_name */
	.ascii	"android/view/animation/LinearInterpolator"
	.zero	61

	/* #446 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554919
	/* java_name */
	.ascii	"android/view/inputmethod/InputMethodManager"
	.zero	59

	/* #447 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554604
	/* java_name */
	.ascii	"android/webkit/ValueCallback"
	.zero	74

	/* #448 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554608
	/* java_name */
	.ascii	"android/webkit/WebChromeClient"
	.zero	72

	/* #449 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554609
	/* java_name */
	.ascii	"android/webkit/WebChromeClient$FileChooserParams"
	.zero	54

	/* #450 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554611
	/* java_name */
	.ascii	"android/webkit/WebResourceError"
	.zero	71

	/* #451 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554606
	/* java_name */
	.ascii	"android/webkit/WebResourceRequest"
	.zero	69

	/* #452 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554613
	/* java_name */
	.ascii	"android/webkit/WebSettings"
	.zero	76

	/* #453 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554615
	/* java_name */
	.ascii	"android/webkit/WebView"
	.zero	80

	/* #454 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554616
	/* java_name */
	.ascii	"android/webkit/WebViewClient"
	.zero	74

	/* #455 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554641
	/* java_name */
	.ascii	"android/widget/AbsListView"
	.zero	76

	/* #456 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554643
	/* java_name */
	.ascii	"android/widget/AbsListView$OnScrollListener"
	.zero	59

	/* #457 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554681
	/* java_name */
	.ascii	"android/widget/AbsSeekBar"
	.zero	77

	/* #458 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554683
	/* java_name */
	.ascii	"android/widget/AbsSpinner"
	.zero	77

	/* #459 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554679
	/* java_name */
	.ascii	"android/widget/AbsoluteLayout"
	.zero	73

	/* #460 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554680
	/* java_name */
	.ascii	"android/widget/AbsoluteLayout$LayoutParams"
	.zero	60

	/* #461 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554708
	/* java_name */
	.ascii	"android/widget/Adapter"
	.zero	80

	/* #462 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554650
	/* java_name */
	.ascii	"android/widget/AdapterView"
	.zero	76

	/* #463 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554652
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemClickListener"
	.zero	56

	/* #464 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554656
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemLongClickListener"
	.zero	52

	/* #465 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554658
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemSelectedListener"
	.zero	53

	/* #466 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/widget/ArrayAdapter"
	.zero	75

	/* #467 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554668
	/* java_name */
	.ascii	"android/widget/AutoCompleteTextView"
	.zero	67

	/* #468 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/widget/BaseAdapter"
	.zero	76

	/* #469 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554690
	/* java_name */
	.ascii	"android/widget/Button"
	.zero	81

	/* #470 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554691
	/* java_name */
	.ascii	"android/widget/CheckBox"
	.zero	79

	/* #471 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554710
	/* java_name */
	.ascii	"android/widget/Checkable"
	.zero	78

	/* #472 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554693
	/* java_name */
	.ascii	"android/widget/CompoundButton"
	.zero	73

	/* #473 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554695
	/* java_name */
	.ascii	"android/widget/CompoundButton$OnCheckedChangeListener"
	.zero	49

	/* #474 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554672
	/* java_name */
	.ascii	"android/widget/DatePicker"
	.zero	77

	/* #475 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554674
	/* java_name */
	.ascii	"android/widget/DatePicker$OnDateChangedListener"
	.zero	55

	/* #476 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554697
	/* java_name */
	.ascii	"android/widget/DigitalClock"
	.zero	75

	/* #477 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554698
	/* java_name */
	.ascii	"android/widget/EditText"
	.zero	79

	/* #478 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554699
	/* java_name */
	.ascii	"android/widget/Filter"
	.zero	81

	/* #479 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554701
	/* java_name */
	.ascii	"android/widget/Filter$FilterListener"
	.zero	66

	/* #480 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554702
	/* java_name */
	.ascii	"android/widget/Filter$FilterResults"
	.zero	67

	/* #481 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554712
	/* java_name */
	.ascii	"android/widget/Filterable"
	.zero	77

	/* #482 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554704
	/* java_name */
	.ascii	"android/widget/FrameLayout"
	.zero	76

	/* #483 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554705
	/* java_name */
	.ascii	"android/widget/FrameLayout$LayoutParams"
	.zero	63

	/* #484 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554706
	/* java_name */
	.ascii	"android/widget/HorizontalScrollView"
	.zero	67

	/* #485 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554715
	/* java_name */
	.ascii	"android/widget/ImageButton"
	.zero	76

	/* #486 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554716
	/* java_name */
	.ascii	"android/widget/ImageView"
	.zero	78

	/* #487 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554717
	/* java_name */
	.ascii	"android/widget/ImageView$ScaleType"
	.zero	68

	/* #488 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554725
	/* java_name */
	.ascii	"android/widget/LinearLayout"
	.zero	75

	/* #489 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554726
	/* java_name */
	.ascii	"android/widget/LinearLayout$LayoutParams"
	.zero	62

	/* #490 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554714
	/* java_name */
	.ascii	"android/widget/ListAdapter"
	.zero	76

	/* #491 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554727
	/* java_name */
	.ascii	"android/widget/ListView"
	.zero	79

	/* #492 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554728
	/* java_name */
	.ascii	"android/widget/NumberPicker"
	.zero	75

	/* #493 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554730
	/* java_name */
	.ascii	"android/widget/ProgressBar"
	.zero	76

	/* #494 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554731
	/* java_name */
	.ascii	"android/widget/RadioButton"
	.zero	76

	/* #495 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554732
	/* java_name */
	.ascii	"android/widget/RelativeLayout"
	.zero	73

	/* #496 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554733
	/* java_name */
	.ascii	"android/widget/RelativeLayout$LayoutParams"
	.zero	60

	/* #497 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554735
	/* java_name */
	.ascii	"android/widget/ScrollView"
	.zero	77

	/* #498 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554736
	/* java_name */
	.ascii	"android/widget/SearchView"
	.zero	77

	/* #499 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554738
	/* java_name */
	.ascii	"android/widget/SearchView$OnQueryTextListener"
	.zero	57

	/* #500 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554719
	/* java_name */
	.ascii	"android/widget/SectionIndexer"
	.zero	73

	/* #501 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554739
	/* java_name */
	.ascii	"android/widget/SeekBar"
	.zero	80

	/* #502 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554741
	/* java_name */
	.ascii	"android/widget/SeekBar$OnSeekBarChangeListener"
	.zero	56

	/* #503 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554742
	/* java_name */
	.ascii	"android/widget/Spinner"
	.zero	80

	/* #504 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554721
	/* java_name */
	.ascii	"android/widget/SpinnerAdapter"
	.zero	73

	/* #505 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554743
	/* java_name */
	.ascii	"android/widget/Switch"
	.zero	81

	/* #506 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554675
	/* java_name */
	.ascii	"android/widget/TextView"
	.zero	79

	/* #507 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554676
	/* java_name */
	.ascii	"android/widget/TextView$BufferType"
	.zero	68

	/* #508 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554678
	/* java_name */
	.ascii	"android/widget/TextView$OnEditorActionListener"
	.zero	56

	/* #509 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554723
	/* java_name */
	.ascii	"android/widget/ThemedSpinnerAdapter"
	.zero	67

	/* #510 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554744
	/* java_name */
	.ascii	"android/widget/TimePicker"
	.zero	77

	/* #511 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554746
	/* java_name */
	.ascii	"android/widget/TimePicker$OnTimeChangedListener"
	.zero	55

	/* #512 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554747
	/* java_name */
	.ascii	"android/widget/Toast"
	.zero	82

	/* #513 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"com/xamarin/forms/platform/android/FormsViewGroup"
	.zero	53

	/* #514 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"com/xamarin/formsviewgroup/BuildConfig"
	.zero	64

	/* #515 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"crc641133ce11fb4af280/Mask"
	.zero	76

	/* #516 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc6414252951f3f66c67/RecyclerViewScrollListener_2"
	.zero	52

	/* #517 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554462
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActCadastroPesagem1"
	.zero	61

	/* #518 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554463
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActCadastroPesagem1_1"
	.zero	59

	/* #519 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554464
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActCadastroPesagem2"
	.zero	61

	/* #520 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554465
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActCadastroPesagem3"
	.zero	61

	/* #521 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554466
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActCadastroPesagem4"
	.zero	61

	/* #522 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActCadastroPesagem5"
	.zero	61

	/* #523 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActCadastroPesagem6"
	.zero	61

	/* #524 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554469
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActCadastroVeiculos"
	.zero	61

	/* #525 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554470
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActCalibracao"
	.zero	67

	/* #526 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554471
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActConfigura4Plataformas"
	.zero	56

	/* #527 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554474
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActConfiguraComunicacao"
	.zero	57

	/* #528 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActConfiguraPrinter"
	.zero	61

	/* #529 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554472
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActConfiguracaoEmpresa"
	.zero	58

	/* #530 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActConfiguracaoSistema"
	.zero	58

	/* #531 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554476
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActConsultaPesagens"
	.zero	61

	/* #532 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554477
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActProdutos"
	.zero	69

	/* #533 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554460
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActSenhaCalibracao"
	.zero	62

	/* #534 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554461
	/* java_name */
	.ascii	"crc642c7c3d794f307ce5/ActcadastroClientes"
	.zero	61

	/* #535 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554613
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/AHorizontalScrollView"
	.zero	59

	/* #536 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554751
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ActionSheetRenderer"
	.zero	61

	/* #537 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554752
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ActivityIndicatorRenderer"
	.zero	55

	/* #538 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554545
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/AndroidActivity"
	.zero	65

	/* #539 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554547
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/BaseCellView"
	.zero	68

	/* #540 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554629
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/BorderDrawable"
	.zero	66

	/* #541 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554753
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/BoxRenderer"
	.zero	69

	/* #542 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554630
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ButtonRenderer"
	.zero	66

	/* #543 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554631
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ButtonRenderer_ButtonClickListener"
	.zero	46

	/* #544 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554633
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ButtonRenderer_ButtonTouchListener"
	.zero	46

	/* #545 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554785
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CarouselPageAdapter"
	.zero	61

	/* #546 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554754
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CarouselPageRenderer"
	.zero	60

	/* #547 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554465
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CarouselSpacingItemDecoration"
	.zero	51

	/* #548 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554466
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CarouselViewRenderer"
	.zero	60

	/* #549 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554522
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CellAdapter"
	.zero	69

	/* #550 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554551
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CellRenderer_RendererHolder"
	.zero	53

	/* #551 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CenterSnapHelper"
	.zero	64

	/* #552 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554867
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CheckBoxDesignerRenderer"
	.zero	56

	/* #553 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554866
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CheckBoxRenderer"
	.zero	64

	/* #554 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554460
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CheckBoxRendererBase"
	.zero	60

	/* #555 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554581
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CircularProgress"
	.zero	64

	/* #556 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554635
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CollectionViewRenderer"
	.zero	58

	/* #557 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554628
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ColorChangeRevealDrawable"
	.zero	55

	/* #558 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554636
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ConditionalFocusLayout"
	.zero	58

	/* #559 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554637
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ContainerView"
	.zero	67

	/* #560 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554638
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/CustomFrameLayout"
	.zero	63

	/* #561 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/DataChangeObserver"
	.zero	62

	/* #562 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554757
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/DatePickerRenderer"
	.zero	62

	/* #563 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/DatePickerRendererBase_1"
	.zero	56

	/* #564 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554484
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EdgeSnapHelper"
	.zero	66

	/* #565 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554646
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EditorEditText"
	.zero	66

	/* #566 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554758
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EditorRenderer"
	.zero	66

	/* #567 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EditorRendererBase_1"
	.zero	60

	/* #568 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554479
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EmptyViewAdapter"
	.zero	64

	/* #569 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554481
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EndSingleSnapHelper"
	.zero	61

	/* #570 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554485
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EndSnapHelper"
	.zero	67

	/* #571 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554579
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EntryAccessibilityDelegate"
	.zero	54

	/* #572 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554524
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EntryCellEditText"
	.zero	63

	/* #573 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554525
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EntryCellView"
	.zero	67

	/* #574 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554645
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EntryEditText"
	.zero	67

	/* #575 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554760
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EntryRenderer"
	.zero	67

	/* #576 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/EntryRendererBase_1"
	.zero	61

	/* #577 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554650
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormattedStringExtensions_FontSpan"
	.zero	46

	/* #578 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554652
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormattedStringExtensions_LineHeightSpan"
	.zero	40

	/* #579 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554651
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormattedStringExtensions_TextDecorationSpan"
	.zero	36

	/* #580 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554616
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormsAnimationDrawable"
	.zero	58

	/* #581 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554533
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormsAppCompatActivity"
	.zero	58

	/* #582 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554542
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormsApplicationActivity"
	.zero	56

	/* #583 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554641
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormsEditText"
	.zero	67

	/* #584 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554642
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormsEditTextBase"
	.zero	63

	/* #585 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554653
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormsImageView"
	.zero	66

	/* #586 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554831
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormsSeekBar"
	.zero	68

	/* #587 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554654
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormsTextView"
	.zero	67

	/* #588 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554655
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormsWebChromeClient"
	.zero	60

	/* #589 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554585
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FormsWebViewClient"
	.zero	62

	/* #590 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554763
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FrameRenderer"
	.zero	67

	/* #591 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554764
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/FrameRenderer_FrameDrawable"
	.zero	53

	/* #592 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554657
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/GenericAnimatorListener"
	.zero	57

	/* #593 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554539
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/GenericGlobalLayoutListener"
	.zero	53

	/* #594 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554733
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/GenericMenuClickListener"
	.zero	56

	/* #595 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554541
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/GestureManager_TapAndPanGestureDetector"
	.zero	41

	/* #596 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/GridLayoutSpanSizeLookup"
	.zero	56

	/* #597 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/GroupableItemsViewAdapter_2"
	.zero	53

	/* #598 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/GroupableItemsViewRenderer_3"
	.zero	52

	/* #599 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554835
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/GroupedListViewAdapter"
	.zero	58

	/* #600 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554538
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ImageButtonRenderer"
	.zero	61

	/* #601 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554569
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ImageCache_CacheEntry"
	.zero	59

	/* #602 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554570
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ImageCache_FormsLruCache"
	.zero	56

	/* #603 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554766
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ImageRenderer"
	.zero	67

	/* #604 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/IndicatorViewRenderer"
	.zero	59

	/* #605 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554588
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/InnerGestureListener"
	.zero	60

	/* #606 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554589
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/InnerScaleListener"
	.zero	62

	/* #607 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554488
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ItemContentView"
	.zero	65

	/* #608 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ItemsViewAdapter_2"
	.zero	62

	/* #609 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ItemsViewRenderer_3"
	.zero	61

	/* #610 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554771
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/LabelRenderer"
	.zero	67

	/* #611 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554772
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ListViewAdapter"
	.zero	65

	/* #612 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554774
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ListViewRenderer"
	.zero	64

	/* #613 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554775
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ListViewRenderer_Container"
	.zero	54

	/* #614 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554777
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ListViewRenderer_ListViewScrollDetector"
	.zero	41

	/* #615 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554776
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ListViewRenderer_SwipeRefreshLayoutWithFixedNestedScrolling"
	.zero	21

	/* #616 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554676
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/LocalizedDigitsKeyListener"
	.zero	54

	/* #617 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554677
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/MasterDetailContainer"
	.zero	59

	/* #618 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554779
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/MasterDetailRenderer"
	.zero	60

	/* #619 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554594
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/NativeViewWrapperRenderer"
	.zero	55

	/* #620 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554781
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/NavigationRenderer"
	.zero	62

	/* #621 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554476
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/NongreedySnapHelper"
	.zero	61

	/* #622 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ObjectJavaBox_1"
	.zero	65

	/* #623 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554827
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/OpenGLViewRenderer"
	.zero	62

	/* #624 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554828
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/OpenGLViewRenderer_Renderer"
	.zero	53

	/* #625 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554679
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/PageContainer"
	.zero	67

	/* #626 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554518
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/PageExtensions_EmbeddedFragment"
	.zero	49

	/* #627 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554520
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/PageExtensions_EmbeddedSupportFragment"
	.zero	42

	/* #628 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554786
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/PageRenderer"
	.zero	68

	/* #629 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554583
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/PickerEditText"
	.zero	66

	/* #630 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554578
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/PickerManager_PickerListener"
	.zero	52

	/* #631 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554821
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/PickerRenderer"
	.zero	66

	/* #632 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554749
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/PlatformRenderer"
	.zero	64

	/* #633 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554739
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/Platform_DefaultRenderer"
	.zero	56

	/* #634 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554493
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/PositionalSmoothScroller"
	.zero	56

	/* #635 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554612
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/PowerSaveModeBroadcastReceiver"
	.zero	50

	/* #636 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554788
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ProgressBarRenderer"
	.zero	61

	/* #637 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554868
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/RefreshViewRenderer"
	.zero	61

	/* #638 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554495
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ScrollHelper"
	.zero	68

	/* #639 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554698
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ScrollLayoutManager"
	.zero	61

	/* #640 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554680
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ScrollViewContainer"
	.zero	61

	/* #641 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554789
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ScrollViewRenderer"
	.zero	62

	/* #642 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554793
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SearchBarRenderer"
	.zero	63

	/* #643 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SelectableItemsViewAdapter_2"
	.zero	52

	/* #644 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SelectableItemsViewRenderer_3"
	.zero	51

	/* #645 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554499
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SelectableViewHolder"
	.zero	60

	/* #646 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554689
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellContentFragment"
	.zero	60

	/* #647 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554690
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellFlyoutRecyclerAdapter"
	.zero	54

	/* #648 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554693
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellFlyoutRecyclerAdapter_ElementViewHolder"
	.zero	36

	/* #649 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554691
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellFlyoutRecyclerAdapter_LinearLayoutWithFocus"
	.zero	32

	/* #650 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554694
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellFlyoutRenderer"
	.zero	61

	/* #651 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554695
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellFlyoutTemplatedContentRenderer"
	.zero	45

	/* #652 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554696
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellFlyoutTemplatedContentRenderer_HeaderContainer"
	.zero	29

	/* #653 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554699
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellFragmentPagerAdapter"
	.zero	55

	/* #654 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554683
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellItemRenderer"
	.zero	63

	/* #655 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554700
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellItemRendererBase"
	.zero	59

	/* #656 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554702
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellPageContainer"
	.zero	62

	/* #657 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554704
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellRenderer_SplitDrawable"
	.zero	53

	/* #658 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554706
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellSearchView"
	.zero	65

	/* #659 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554710
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellSearchViewAdapter"
	.zero	58

	/* #660 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554711
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellSearchViewAdapter_CustomFilter"
	.zero	45

	/* #661 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554712
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellSearchViewAdapter_ObjectWrapper"
	.zero	44

	/* #662 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554707
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellSearchView_ClipDrawableWrapper"
	.zero	45

	/* #663 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554719
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellSectionRenderer"
	.zero	60

	/* #664 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554715
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellToolbarTracker"
	.zero	61

	/* #665 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554716
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ShellToolbarTracker_FlyoutIconDrawerDrawable"
	.zero	36

	/* #666 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554477
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SimpleViewHolder"
	.zero	64

	/* #667 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554478
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SingleSnapHelper"
	.zero	64

	/* #668 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554500
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SizedItemContentView"
	.zero	60

	/* #669 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554794
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SliderRenderer"
	.zero	66

	/* #670 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554502
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SpacingItemDecoration"
	.zero	59

	/* #671 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554503
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/StartSingleSnapHelper"
	.zero	59

	/* #672 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554504
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/StartSnapHelper"
	.zero	65

	/* #673 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554795
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/StepperRenderer"
	.zero	65

	/* #674 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554865
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/StepperRendererManager_StepperListener"
	.zero	42

	/* #675 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/StructuredItemsViewAdapter_2"
	.zero	52

	/* #676 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/StructuredItemsViewRenderer_3"
	.zero	51

	/* #677 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554869
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SwipeViewRenderer"
	.zero	63

	/* #678 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554527
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SwitchCellView"
	.zero	66

	/* #679 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554796
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/SwitchRenderer"
	.zero	66

	/* #680 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554797
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/TabbedRenderer"
	.zero	66

	/* #681 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554798
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/TableViewModelRenderer"
	.zero	58

	/* #682 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554799
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/TableViewRenderer"
	.zero	63

	/* #683 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554507
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/TemplatedItemViewHolder"
	.zero	57

	/* #684 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554556
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/TextCellRenderer_TextCellView"
	.zero	51

	/* #685 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554508
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/TextViewHolder"
	.zero	66

	/* #686 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554801
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/TimePickerRenderer"
	.zero	62

	/* #687 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/TimePickerRendererBase_1"
	.zero	56

	/* #688 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554558
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ViewCellRenderer_ViewCellContainer"
	.zero	46

	/* #689 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554559
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ViewCellRenderer_ViewCellContainer_LongPressGestureListener"
	.zero	21

	/* #690 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554736
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ViewRenderer"
	.zero	68

	/* #691 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/ViewRenderer_2"
	.zero	66

	/* #692 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/VisualElementRenderer_1"
	.zero	57

	/* #693 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554820
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/VisualElementTracker_AttachTracker"
	.zero	46

	/* #694 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554802
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/WebViewRenderer"
	.zero	65

	/* #695 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554803
	/* java_name */
	.ascii	"crc643f46942d9dd1fff9/WebViewRenderer_JavascriptResult"
	.zero	48

	/* #696 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554451
	/* java_name */
	.ascii	"crc644c27c206e6fc934c/DatePickerFragment"
	.zero	62

	/* #697 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"crc6457e461602e32e680/ProgressWheel"
	.zero	67

	/* #698 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"crc6457e461602e32e680/ProgressWheel_SpinHandler"
	.zero	55

	/* #699 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554434
	/* java_name */
	.ascii	"crc645ede615f08c1b496/ActionSheetListAdapter"
	.zero	58

	/* #700 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554899
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/ButtonRenderer"
	.zero	66

	/* #701 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554921
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/CarouselPageRenderer"
	.zero	60

	/* #702 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/FormsFragmentPagerAdapter_1"
	.zero	53

	/* #703 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554888
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/FormsViewPager"
	.zero	66

	/* #704 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554889
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/FragmentContainer"
	.zero	63

	/* #705 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554886
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/FrameRenderer"
	.zero	67

	/* #706 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554891
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/MasterDetailContainer"
	.zero	59

	/* #707 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554900
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/MasterDetailPageRenderer"
	.zero	56

	/* #708 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554902
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/NavigationPageRenderer"
	.zero	58

	/* #709 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554903
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/NavigationPageRenderer_ClickListener"
	.zero	44

	/* #710 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554904
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/NavigationPageRenderer_Container"
	.zero	48

	/* #711 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554905
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/NavigationPageRenderer_DrawerMultiplexedListener"
	.zero	32

	/* #712 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554919
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/PickerRenderer"
	.zero	66

	/* #713 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/PickerRendererBase_1"
	.zero	60

	/* #714 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554893
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/Platform_ModalContainer"
	.zero	57

	/* #715 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554887
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/ShellFragmentContainer"
	.zero	58

	/* #716 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554912
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/SwitchRenderer"
	.zero	66

	/* #717 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554913
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/TabbedPageRenderer"
	.zero	62

	/* #718 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc64720bb2db43a66fe9/ViewRenderer_2"
	.zero	66

	/* #719 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	33554434
	/* java_name */
	.ascii	"crc6497e07730ab66e74c/ActivityLifecycleCallbacks"
	.zero	54

	/* #720 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"crc64a27926b520577544/ActPrincipal"
	.zero	68

	/* #721 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"crc64a27926b520577544/BluetoothChatFragment"
	.zero	59

	/* #722 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554485
	/* java_name */
	.ascii	"crc64a27926b520577544/BluetoothChatFragment_ChatHandler"
	.zero	47

	/* #723 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554484
	/* java_name */
	.ascii	"crc64a27926b520577544/BluetoothChatFragment_WriteListener"
	.zero	45

	/* #724 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554486
	/* java_name */
	.ascii	"crc64a27926b520577544/BluetoothChatService_AcceptThread"
	.zero	47

	/* #725 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554487
	/* java_name */
	.ascii	"crc64a27926b520577544/BluetoothChatService_ConnectThread"
	.zero	46

	/* #726 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554488
	/* java_name */
	.ascii	"crc64a27926b520577544/BluetoothChatService_ConnectedThread"
	.zero	44

	/* #727 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"crc64a27926b520577544/MainActivity"
	.zero	68

	/* #728 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"crc64adadc29e9900caaa/DeviceListActivity"
	.zero	62

	/* #729 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554481
	/* java_name */
	.ascii	"crc64adadc29e9900caaa/DeviceListActivity_DeviceDiscoveredReceiver"
	.zero	37

	/* #730 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/AbstractAppCompatDialogFragment_1"
	.zero	47

	/* #731 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/AbstractDialogFragment_1"
	.zero	56

	/* #732 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554458
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/ActionSheetAppCompatDialogFragment"
	.zero	46

	/* #733 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/ActionSheetDialogFragment"
	.zero	55

	/* #734 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554460
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/AlertAppCompatDialogFragment"
	.zero	52

	/* #735 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/AlertDialogFragment"
	.zero	61

	/* #736 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554461
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/BottomSheetDialogFragment"
	.zero	55

	/* #737 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554464
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/ConfirmAppCompatDialogFragment"
	.zero	50

	/* #738 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554463
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/ConfirmDialogFragment"
	.zero	59

	/* #739 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/DateAppCompatDialogFragment"
	.zero	53

	/* #740 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/DateDialogFragment"
	.zero	62

	/* #741 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554471
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/LoginAppCompatDialogFragment"
	.zero	52

	/* #742 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554470
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/LoginDialogFragment"
	.zero	61

	/* #743 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/PromptAppCompatDialogFragment"
	.zero	51

	/* #744 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554472
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/PromptDialogFragment"
	.zero	60

	/* #745 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554466
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/TimeAppCompatDialogFragment"
	.zero	53

	/* #746 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554465
	/* java_name */
	.ascii	"crc64b76f6e8b2d8c8db1/TimeDialogFragment"
	.zero	62

	/* #747 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554873
	/* java_name */
	.ascii	"crc64ee486da937c010f4/ButtonRenderer"
	.zero	66

	/* #748 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554876
	/* java_name */
	.ascii	"crc64ee486da937c010f4/FrameRenderer"
	.zero	67

	/* #749 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554884
	/* java_name */
	.ascii	"crc64ee486da937c010f4/ImageRenderer"
	.zero	67

	/* #750 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554882
	/* java_name */
	.ascii	"crc64ee486da937c010f4/LabelRenderer"
	.zero	67

	/* #751 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"crc64ff6e8f0c0de886a1/DiscoverableModeReceiver"
	.zero	56

	/* #752 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555441
	/* java_name */
	.ascii	"java/io/Closeable"
	.zero	85

	/* #753 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555437
	/* java_name */
	.ascii	"java/io/File"
	.zero	90

	/* #754 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555438
	/* java_name */
	.ascii	"java/io/FileDescriptor"
	.zero	80

	/* #755 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555439
	/* java_name */
	.ascii	"java/io/FileInputStream"
	.zero	79

	/* #756 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555443
	/* java_name */
	.ascii	"java/io/Flushable"
	.zero	85

	/* #757 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555446
	/* java_name */
	.ascii	"java/io/IOException"
	.zero	83

	/* #758 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555444
	/* java_name */
	.ascii	"java/io/InputStream"
	.zero	83

	/* #759 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555449
	/* java_name */
	.ascii	"java/io/OutputStream"
	.zero	82

	/* #760 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555451
	/* java_name */
	.ascii	"java/io/PrintWriter"
	.zero	83

	/* #761 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555452
	/* java_name */
	.ascii	"java/io/Reader"
	.zero	88

	/* #762 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555448
	/* java_name */
	.ascii	"java/io/Serializable"
	.zero	82

	/* #763 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555454
	/* java_name */
	.ascii	"java/io/StringWriter"
	.zero	82

	/* #764 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555455
	/* java_name */
	.ascii	"java/io/Writer"
	.zero	88

	/* #765 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555385
	/* java_name */
	.ascii	"java/lang/AbstractMethodError"
	.zero	73

	/* #766 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555393
	/* java_name */
	.ascii	"java/lang/Appendable"
	.zero	82

	/* #767 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555395
	/* java_name */
	.ascii	"java/lang/AutoCloseable"
	.zero	79

	/* #768 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555365
	/* java_name */
	.ascii	"java/lang/Boolean"
	.zero	85

	/* #769 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555366
	/* java_name */
	.ascii	"java/lang/Byte"
	.zero	88

	/* #770 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555396
	/* java_name */
	.ascii	"java/lang/CharSequence"
	.zero	80

	/* #771 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555367
	/* java_name */
	.ascii	"java/lang/Character"
	.zero	83

	/* #772 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555368
	/* java_name */
	.ascii	"java/lang/Class"
	.zero	87

	/* #773 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555386
	/* java_name */
	.ascii	"java/lang/ClassCastException"
	.zero	74

	/* #774 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555387
	/* java_name */
	.ascii	"java/lang/ClassLoader"
	.zero	81

	/* #775 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555369
	/* java_name */
	.ascii	"java/lang/ClassNotFoundException"
	.zero	70

	/* #776 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555399
	/* java_name */
	.ascii	"java/lang/Cloneable"
	.zero	83

	/* #777 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555401
	/* java_name */
	.ascii	"java/lang/Comparable"
	.zero	82

	/* #778 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555370
	/* java_name */
	.ascii	"java/lang/Double"
	.zero	86

	/* #779 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555389
	/* java_name */
	.ascii	"java/lang/Enum"
	.zero	88

	/* #780 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555391
	/* java_name */
	.ascii	"java/lang/Error"
	.zero	87

	/* #781 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555371
	/* java_name */
	.ascii	"java/lang/Exception"
	.zero	83

	/* #782 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555372
	/* java_name */
	.ascii	"java/lang/Float"
	.zero	87

	/* #783 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555404
	/* java_name */
	.ascii	"java/lang/IllegalArgumentException"
	.zero	68

	/* #784 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555405
	/* java_name */
	.ascii	"java/lang/IllegalStateException"
	.zero	71

	/* #785 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555406
	/* java_name */
	.ascii	"java/lang/IncompatibleClassChangeError"
	.zero	64

	/* #786 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555407
	/* java_name */
	.ascii	"java/lang/IndexOutOfBoundsException"
	.zero	67

	/* #787 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555374
	/* java_name */
	.ascii	"java/lang/Integer"
	.zero	85

	/* #788 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555403
	/* java_name */
	.ascii	"java/lang/Iterable"
	.zero	84

	/* #789 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555412
	/* java_name */
	.ascii	"java/lang/LinkageError"
	.zero	80

	/* #790 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555375
	/* java_name */
	.ascii	"java/lang/Long"
	.zero	88

	/* #791 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555413
	/* java_name */
	.ascii	"java/lang/NoClassDefFoundError"
	.zero	72

	/* #792 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555414
	/* java_name */
	.ascii	"java/lang/NullPointerException"
	.zero	72

	/* #793 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555415
	/* java_name */
	.ascii	"java/lang/Number"
	.zero	86

	/* #794 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555376
	/* java_name */
	.ascii	"java/lang/Object"
	.zero	86

	/* #795 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555409
	/* java_name */
	.ascii	"java/lang/Readable"
	.zero	84

	/* #796 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555417
	/* java_name */
	.ascii	"java/lang/ReflectiveOperationException"
	.zero	64

	/* #797 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555411
	/* java_name */
	.ascii	"java/lang/Runnable"
	.zero	84

	/* #798 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555418
	/* java_name */
	.ascii	"java/lang/Runtime"
	.zero	85

	/* #799 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555378
	/* java_name */
	.ascii	"java/lang/RuntimeException"
	.zero	76

	/* #800 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555379
	/* java_name */
	.ascii	"java/lang/Short"
	.zero	87

	/* #801 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555380
	/* java_name */
	.ascii	"java/lang/String"
	.zero	86

	/* #802 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555382
	/* java_name */
	.ascii	"java/lang/Thread"
	.zero	86

	/* #803 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555384
	/* java_name */
	.ascii	"java/lang/Throwable"
	.zero	83

	/* #804 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555419
	/* java_name */
	.ascii	"java/lang/UnsupportedOperationException"
	.zero	63

	/* #805 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555421
	/* java_name */
	.ascii	"java/lang/annotation/Annotation"
	.zero	71

	/* #806 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555422
	/* java_name */
	.ascii	"java/lang/reflect/AccessibleObject"
	.zero	68

	/* #807 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555427
	/* java_name */
	.ascii	"java/lang/reflect/AnnotatedElement"
	.zero	68

	/* #808 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555423
	/* java_name */
	.ascii	"java/lang/reflect/Executable"
	.zero	74

	/* #809 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555425
	/* java_name */
	.ascii	"java/lang/reflect/Field"
	.zero	79

	/* #810 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555429
	/* java_name */
	.ascii	"java/lang/reflect/GenericDeclaration"
	.zero	66

	/* #811 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555431
	/* java_name */
	.ascii	"java/lang/reflect/Member"
	.zero	78

	/* #812 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555436
	/* java_name */
	.ascii	"java/lang/reflect/Method"
	.zero	78

	/* #813 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555433
	/* java_name */
	.ascii	"java/lang/reflect/Type"
	.zero	80

	/* #814 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555435
	/* java_name */
	.ascii	"java/lang/reflect/TypeVariable"
	.zero	72

	/* #815 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555312
	/* java_name */
	.ascii	"java/net/InetSocketAddress"
	.zero	76

	/* #816 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555313
	/* java_name */
	.ascii	"java/net/Proxy"
	.zero	88

	/* #817 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555314
	/* java_name */
	.ascii	"java/net/ProxySelector"
	.zero	80

	/* #818 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555316
	/* java_name */
	.ascii	"java/net/SocketAddress"
	.zero	80

	/* #819 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555318
	/* java_name */
	.ascii	"java/net/URI"
	.zero	90

	/* #820 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555334
	/* java_name */
	.ascii	"java/nio/Buffer"
	.zero	87

	/* #821 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555338
	/* java_name */
	.ascii	"java/nio/ByteBuffer"
	.zero	83

	/* #822 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555335
	/* java_name */
	.ascii	"java/nio/CharBuffer"
	.zero	83

	/* #823 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555341
	/* java_name */
	.ascii	"java/nio/FloatBuffer"
	.zero	82

	/* #824 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555343
	/* java_name */
	.ascii	"java/nio/IntBuffer"
	.zero	84

	/* #825 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555348
	/* java_name */
	.ascii	"java/nio/channels/ByteChannel"
	.zero	73

	/* #826 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555350
	/* java_name */
	.ascii	"java/nio/channels/Channel"
	.zero	77

	/* #827 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555345
	/* java_name */
	.ascii	"java/nio/channels/FileChannel"
	.zero	73

	/* #828 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555352
	/* java_name */
	.ascii	"java/nio/channels/GatheringByteChannel"
	.zero	64

	/* #829 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555354
	/* java_name */
	.ascii	"java/nio/channels/InterruptibleChannel"
	.zero	64

	/* #830 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555356
	/* java_name */
	.ascii	"java/nio/channels/ReadableByteChannel"
	.zero	65

	/* #831 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555358
	/* java_name */
	.ascii	"java/nio/channels/ScatteringByteChannel"
	.zero	63

	/* #832 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555360
	/* java_name */
	.ascii	"java/nio/channels/SeekableByteChannel"
	.zero	65

	/* #833 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555362
	/* java_name */
	.ascii	"java/nio/channels/WritableByteChannel"
	.zero	65

	/* #834 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555363
	/* java_name */
	.ascii	"java/nio/channels/spi/AbstractInterruptibleChannel"
	.zero	52

	/* #835 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555322
	/* java_name */
	.ascii	"java/security/KeyStore"
	.zero	80

	/* #836 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555324
	/* java_name */
	.ascii	"java/security/KeyStore$LoadStoreParameter"
	.zero	61

	/* #837 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555326
	/* java_name */
	.ascii	"java/security/KeyStore$ProtectionParameter"
	.zero	60

	/* #838 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555327
	/* java_name */
	.ascii	"java/security/cert/Certificate"
	.zero	72

	/* #839 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555329
	/* java_name */
	.ascii	"java/security/cert/CertificateFactory"
	.zero	65

	/* #840 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555332
	/* java_name */
	.ascii	"java/security/cert/X509Certificate"
	.zero	68

	/* #841 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555331
	/* java_name */
	.ascii	"java/security/cert/X509Extension"
	.zero	70

	/* #842 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555306
	/* java_name */
	.ascii	"java/text/DecimalFormat"
	.zero	79

	/* #843 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555307
	/* java_name */
	.ascii	"java/text/DecimalFormatSymbols"
	.zero	72

	/* #844 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555310
	/* java_name */
	.ascii	"java/text/Format"
	.zero	86

	/* #845 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555308
	/* java_name */
	.ascii	"java/text/NumberFormat"
	.zero	80

	/* #846 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555271
	/* java_name */
	.ascii	"java/util/ArrayList"
	.zero	83

	/* #847 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555260
	/* java_name */
	.ascii	"java/util/Collection"
	.zero	82

	/* #848 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555262
	/* java_name */
	.ascii	"java/util/HashMap"
	.zero	85

	/* #849 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555280
	/* java_name */
	.ascii	"java/util/HashSet"
	.zero	85

	/* #850 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555320
	/* java_name */
	.ascii	"java/util/Iterator"
	.zero	84

	/* #851 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555321
	/* java_name */
	.ascii	"java/util/UUID"
	.zero	88

	/* #852 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554598
	/* java_name */
	.ascii	"javax/microedition/khronos/egl/EGLConfig"
	.zero	62

	/* #853 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554595
	/* java_name */
	.ascii	"javax/microedition/khronos/opengles/GL"
	.zero	64

	/* #854 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554597
	/* java_name */
	.ascii	"javax/microedition/khronos/opengles/GL10"
	.zero	62

	/* #855 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554590
	/* java_name */
	.ascii	"javax/net/ssl/TrustManager"
	.zero	76

	/* #856 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554593
	/* java_name */
	.ascii	"javax/net/ssl/TrustManagerFactory"
	.zero	69

	/* #857 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554592
	/* java_name */
	.ascii	"javax/net/ssl/X509TrustManager"
	.zero	72

	/* #858 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555478
	/* java_name */
	.ascii	"mono/android/TypeManager"
	.zero	78

	/* #859 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555118
	/* java_name */
	.ascii	"mono/android/animation/AnimatorEventDispatcher"
	.zero	56

	/* #860 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555123
	/* java_name */
	.ascii	"mono/android/animation/ValueAnimator_AnimatorUpdateListenerImplementor"
	.zero	32

	/* #861 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555149
	/* java_name */
	.ascii	"mono/android/app/DatePickerDialog_OnDateSetListenerImplementor"
	.zero	40

	/* #862 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555138
	/* java_name */
	.ascii	"mono/android/app/TabEventDispatcher"
	.zero	67

	/* #863 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555194
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnCancelListenerImplementor"
	.zero	38

	/* #864 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555198
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnClickListenerImplementor"
	.zero	39

	/* #865 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555201
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnDismissListenerImplementor"
	.zero	37

	/* #866 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555205
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnKeyListenerImplementor"
	.zero	41

	/* #867 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555211
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnShowListenerImplementor"
	.zero	40

	/* #868 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555256
	/* java_name */
	.ascii	"mono/android/runtime/InputStreamAdapter"
	.zero	63

	/* #869 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"mono/android/runtime/JavaArray"
	.zero	72

	/* #870 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555277
	/* java_name */
	.ascii	"mono/android/runtime/JavaObject"
	.zero	71

	/* #871 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555295
	/* java_name */
	.ascii	"mono/android/runtime/OutputStreamAdapter"
	.zero	62

	/* #872 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"mono/android/support/design/widget/AppBarLayout_OnOffsetChangedListenerImplementor"
	.zero	20

	/* #873 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"mono/android/support/design/widget/BottomNavigationView_OnNavigationItemReselectedListenerImplementor"
	.zero	1

	/* #874 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554479
	/* java_name */
	.ascii	"mono/android/support/design/widget/BottomNavigationView_OnNavigationItemSelectedListenerImplementor"
	.zero	3

	/* #875 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"mono/android/support/design/widget/TabLayout_OnTabSelectedListenerImplementor"
	.zero	25

	/* #876 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554446
	/* java_name */
	.ascii	"mono/android/support/v4/app/FragmentManager_OnBackStackChangedListenerImplementor"
	.zero	21

	/* #877 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554448
	/* java_name */
	.ascii	"mono/android/support/v4/view/ActionProvider_SubUiVisibilityListenerImplementor"
	.zero	24

	/* #878 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554452
	/* java_name */
	.ascii	"mono/android/support/v4/view/ActionProvider_VisibilityListenerImplementor"
	.zero	29

	/* #879 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"mono/android/support/v4/view/ViewPager_OnAdapterChangeListenerImplementor"
	.zero	29

	/* #880 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554448
	/* java_name */
	.ascii	"mono/android/support/v4/view/ViewPager_OnPageChangeListenerImplementor"
	.zero	32

	/* #881 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554474
	/* java_name */
	.ascii	"mono/android/support/v4/widget/DrawerLayout_DrawerListenerImplementor"
	.zero	33

	/* #882 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554488
	/* java_name */
	.ascii	"mono/android/support/v4/widget/NestedScrollView_OnScrollChangeListenerImplementor"
	.zero	21

	/* #883 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554464
	/* java_name */
	.ascii	"mono/android/support/v4/widget/SwipeRefreshLayout_OnRefreshListenerImplementor"
	.zero	24

	/* #884 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554486
	/* java_name */
	.ascii	"mono/android/support/v7/app/ActionBar_OnMenuVisibilityListenerImplementor"
	.zero	29

	/* #885 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554462
	/* java_name */
	.ascii	"mono/android/support/v7/widget/RecyclerView_OnChildAttachStateChangeListenerImplementor"
	.zero	15

	/* #886 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"mono/android/support/v7/widget/RecyclerView_OnItemTouchListenerImplementor"
	.zero	28

	/* #887 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"mono/android/support/v7/widget/RecyclerView_RecyclerListenerImplementor"
	.zero	31

	/* #888 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554462
	/* java_name */
	.ascii	"mono/android/support/v7/widget/Toolbar_OnMenuItemClickListenerImplementor"
	.zero	29

	/* #889 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554943
	/* java_name */
	.ascii	"mono/android/text/TextWatcherImplementor"
	.zero	62

	/* #890 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554757
	/* java_name */
	.ascii	"mono/android/view/View_OnAttachStateChangeListenerImplementor"
	.zero	41

	/* #891 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554760
	/* java_name */
	.ascii	"mono/android/view/View_OnClickListenerImplementor"
	.zero	53

	/* #892 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554768
	/* java_name */
	.ascii	"mono/android/view/View_OnKeyListenerImplementor"
	.zero	55

	/* #893 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554772
	/* java_name */
	.ascii	"mono/android/view/View_OnLayoutChangeListenerImplementor"
	.zero	46

	/* #894 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554776
	/* java_name */
	.ascii	"mono/android/view/View_OnScrollChangeListenerImplementor"
	.zero	46

	/* #895 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554780
	/* java_name */
	.ascii	"mono/android/view/View_OnTouchListenerImplementor"
	.zero	53

	/* #896 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554646
	/* java_name */
	.ascii	"mono/android/widget/AbsListView_OnScrollListenerImplementor"
	.zero	43

	/* #897 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554654
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemClickListenerImplementor"
	.zero	40

	/* #898 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554661
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemSelectedListenerImplementor"
	.zero	37

	/* #899 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555377
	/* java_name */
	.ascii	"mono/java/lang/Runnable"
	.zero	79

	/* #900 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33555383
	/* java_name */
	.ascii	"mono/java/lang/RunnableImplementor"
	.zero	68

	/* #901 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554586
	/* java_name */
	.ascii	"org/xmlpull/v1/XmlPullParser"
	.zero	74

	/* #902 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554587
	/* java_name */
	.ascii	"org/xmlpull/v1/XmlPullParserException"
	.zero	65

	.size	map_java, 99330
/* Java to managed map: END */

