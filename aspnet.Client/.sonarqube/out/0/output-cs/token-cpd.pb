��
k/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Controllers/CustomerController.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Controllers '
{ 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
CustomerController #
:$ %

Controller& 0
{ 
private 
string 
apiUrl 
= 
$str  8
;8 9
private 
string 
loginController &
=' (
$str) 0
;0 1
private 
string !
apiCustomerController ,
=- .
$str/ 9
;9 :
private 
string %
apiProfessionalController 0
=1 2
$str3 A
;A B
private 
string $
apiAppointmentController /
=0 1
$str2 ?
;? @
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
IActionResult 
GetUser $
($ %
)% &
{ 	
LoginViewModel 
model  
=! "
new# &
LoginViewModel' 5
(5 6
)6 7
;7 8
model 
. 
Error 
= 
$str 
; 
return 
View 
( 
$str #
,# $
model% *
)* +
;+ ,
} 	
[!! 	
HttpPost!!	 
(!! 
$str!! 
)!! 
]!! 
public"" 
async"" 
Task"" 
<"" 
IActionResult"" '
>""' (
	FormLogin"") 2
(""2 3
LoginViewModel""3 A
model""B G
)""G H
{## 	
var&& 
json&& 
=&& 
JsonConvert&& 
.&& 
SerializeObject&& .
(&&. /
model&&/ 4
)&&4 5
;&&5 6
StringContent'' 
content'' 
='' 
new''  #
StringContent''$ 1
(''1 2
json''2 6
.''6 7
ToString''7 ?
(''? @
)''@ A
)''A B
;''B C
HttpClientHandler** 
clientHandler** '
=**( )
new*** -
HttpClientHandler**. ?
(**? @
)**@ A
;**A B
clientHandler++ 
.++ 5
)ServerCertificateCustomValidationCallback++ ?
=++@ A
(++B C
sender++C I
,++I J
cert++K O
,++O P
chain++Q V
,++V W
sslPolicyErrors++X g
)++g h
=>++i k
{++l m
return++n t
true++u y
;++y z
}++{ |
;++| }

HttpClient.. 
client.. 
=.. 
new.. 

HttpClient..  *
(..* +
clientHandler..+ 8
)..8 9
;..9 :
var11 
response11 
=11 
await11 
client11 #
.11# $
	PostAsync11$ -
(11- .
apiUrl11. 4
+114 5
loginController115 D
+11D E
$str11E L
,11L M
content11N U
)11U V
;11V W
	UserModel77 
user77 
=77 
JsonConvert77 $
.77$ %
DeserializeObject77% 6
<776 7
	UserModel777 @
>77@ A
(77A B
await77B G
response77H P
.77P Q
Content77Q X
.77X Y
ReadAsStringAsync77Y j
(77j k
)77k l
)77l m
;77m n
if:: 

(::
 
user:: 
.:: 
Username:: 
!=:: 
null::  
)::  !
{;; 	
if<< 
(<< 
user<< 
.<< 
Type<< 
==<< 
$str<< &
)<<& '
{<<' (
return== 
View== 
(== 
$str== &
,==& '
user==( ,
)==, -
;==- .
}>> 
else>> 
{>> 
return?? 
View?? 
(?? 
$str?? D
,??D E
user??F J
)??J K
;??K L
}@@ 
}AA 	
LoginViewModelEE 

modelLoginEE !
=EE" #
newEE$ '
LoginViewModelEE( 6
(EE6 7
)EE7 8
;EE8 9

modelLoginFF 
.FF 
ErrorFF 
=FF 
$strFF 3
;FF3 4
returnGG 
ViewGG 
(GG 
$strGG 
,GG  

modelLoginGG! +
)GG+ ,
;GG, -
}II 	
[KK 	
HttpPostKK	 
(KK 
$strKK 
)KK 
]KK 
publicLL 
IActionResultLL 

SelectUserLL '
(LL' (
	UserModelLL( 1
customerLL2 :
)LL: ;
{MM 	
returnNN 
ViewNN 
(NN 
$strNN &
,NN& '
customerNN( 0
)NN0 1
;NN1 2
}OO 	
[QQ 	
HttpGetQQ	 
(QQ 
$strQQ /
)QQ/ 0
]QQ0 1
publicRR 
asyncRR 
TaskRR 
<RR 
IActionResultRR '
>RR' ("
SearchForProfessionalsRR) ?
(RR? @
stringRR@ F
idRRG I
)RRI J
{SS 	
HttpClientHandlerVV 
clientHandlerVV +
=VV, -
newVV. 1
HttpClientHandlerVV2 C
(VVC D
)VVD E
;VVE F
clientHandlerWW 
.WW 5
)ServerCertificateCustomValidationCallbackWW C
=WWD E
(WWF G
senderWWG M
,WWM N
certWWO S
,WWS T
chainWWU Z
,WWZ [
sslPolicyErrorsWW\ k
)WWk l
=>WWm o
{WWp q
returnWWr x
trueWWy }
;WW} ~
}	WW �
;
WW� �

HttpClientZZ 
clientZZ 
=ZZ 
newZZ  #

HttpClientZZ$ .
(ZZ. /
clientHandlerZZ/ <
)ZZ< =
;ZZ= >
var]] 
response]] 
=]] 
await]]  
client]]! '
.]]' (
GetAsync]]( 0
(]]0 1
apiUrl]]1 7
+]]7 8!
apiCustomerController]]8 M
+]]M N
$str]]N b
+]]b c
id]]c e
)]]e f
;]]f g
CustomerModel__ 
customer__ "
=__# $
JsonConvert__% 0
.__0 1
DeserializeObject__1 B
<__B C
CustomerModel__C P
>__P Q
(__Q R
await__R W
response__X `
.__` a
Content__a h
.__h i
ReadAsStringAsync__i z
(__z {
)__{ |
)__| }
;__} ~
returnaa 
Viewaa 
(aa 
$straa .
,aa. /
customeraa0 8
)aa8 9
;aa9 :
}bb 	
[dd 	
HttpGetdd	 
(dd 
$strdd  
)dd  !
]dd! "
publicee 
asyncee 
Taskee 
<ee 
IActionResultee '
>ee' (
AppointmentHistoryee) ;
(ee; <
stringee< B
ideeC E
)eeE F
{ff 	
HttpClientHandlergg 
clientHandlergg +
=gg, -
newgg. 1
HttpClientHandlergg2 C
(ggC D
)ggD E
;ggE F
clientHandlerhh 
.hh 5
)ServerCertificateCustomValidationCallbackhh C
=hhD E
(hhF G
senderhhG M
,hhM N
certhhO S
,hhS T
chainhhU Z
,hhZ [
sslPolicyErrorshh\ k
)hhk l
=>hhm o
{hhp q
returnhhr x
truehhy }
;hh} ~
}	hh �
;
hh� �

HttpClientii 
clientii 
=ii 
newii  #

HttpClientii$ .
(ii. /
clientHandlerii/ <
)ii< =
;ii= >
varjj 
responsejj 
=jj 
awaitjj  
clientjj! '
.jj' (
GetAsyncjj( 0
(jj0 1
apiUrljj1 7
+jj7 8$
apiAppointmentControllerjj8 P
+jjP Q
$strjjQ j
+jjj k
idjjk m
)jjm n
;jjn o
varkk 
appointmentskk 
=kk 
JsonConvertkk *
.kk* +
DeserializeObjectkk+ <
<kk< =
Listkk= A
<kkA B
AppointmentModelkkB R
>kkR S
>kkS T
(kkT U
awaitkkU Z
responsekk[ c
.kkc d
Contentkkd k
.kkk l
ReadAsStringAsynckkl }
(kk} ~
)kk~ 
)	kk �
;
kk� � 
AppointmentViewModelll  
appointmentll! ,
=ll- .
newll/ 2 
AppointmentViewModelll3 G
(llG H
)llH I
;llI J
appointmentmm 
.mm 
Appointmentsmm $
=mm% &
appointmentsmm' 3
;mm3 4
appointmentnn 
.nn 
CustomerUsernamenn (
=nn) *
idnn+ -
;nn- .
returnoo 
Viewoo 
(oo 
$stroo %
,oo% &
appointmentoo& 1
)oo1 2
;oo2 3
}pp 	
[rr 	
HttpGetrr	 
(rr 
$strrr ,
)rr, -
]rr- .
publicss 
asyncss 
Taskss 
<ss 
IActionResultss '
>ss' (
CurrentAppointmentsss) <
(ss< =
stringss= C
idssD F
)ssF G
{tt 	
HttpClientHandleruu 
clientHandleruu +
=uu, -
newuu. 1
HttpClientHandleruu2 C
(uuC D
)uuD E
;uuE F
clientHandlervv 
.vv 5
)ServerCertificateCustomValidationCallbackvv C
=vvD E
(vvF G
sendervvG M
,vvM N
certvvO S
,vvS T
chainvvU Z
,vvZ [
sslPolicyErrorsvv\ k
)vvk l
=>vvm o
{vvp q
returnvvr x
truevvy }
;vv} ~
}	vv �
;
vv� �

HttpClientww 
clientww 
=ww 
newww  #

HttpClientww$ .
(ww. /
clientHandlerww/ <
)ww< =
;ww= >
varxx 
responsexx 
=xx 
awaitxx  
clientxx! '
.xx' (
GetAsyncxx( 0
(xx0 1
apiUrlxx1 7
+xx7 8$
apiAppointmentControllerxx8 P
+xxP Q
$strxxQ j
+xxj k
idxxk m
)xxm n
;xxn o
varyy 
appointmentsyy 
=yy 
JsonConvertyy *
.yy* +
DeserializeObjectyy+ <
<yy< =
Listyy= A
<yyA B
AppointmentModelyyB R
>yyR S
>yyS T
(yyT U
awaityyU Z
responseyy[ c
.yyc d
Contentyyd k
.yyk l
ReadAsStringAsyncyyl }
(yy} ~
)yy~ 
)	yy �
;
yy� � 
AppointmentViewModelzz  
appointmentzz! ,
=zz- .
newzz/ 2 
AppointmentViewModelzz3 G
(zzG H
)zzH I
;zzI J
appointment{{ 
.{{ 
Appointments{{ $
={{% &
appointments{{' 3
;{{3 4
appointment|| 
.|| 
CustomerUsername|| (
=||) *
id||+ -
;||- .
return}} 
View}} 
(}} 
$str}} ,
,}}, -
appointment}}. 9
)}}9 :
;}}: ;
}~~ 	
[
�� 	
HttpGet
��	 
(
�� 
$str
�� ,
)
��, -
]
��- .
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' (!
PendingAppointments
��) <
(
��< =
string
��= C
id
��D F
)
��F G
{
�� 	
HttpClientHandler
�� 
clientHandler
�� +
=
��, -
new
��. 1
HttpClientHandler
��2 C
(
��C D
)
��D E
;
��E F
clientHandler
�� 
.
�� 7
)ServerCertificateCustomValidationCallback
�� C
=
��D E
(
��F G
sender
��G M
,
��M N
cert
��O S
,
��S T
chain
��U Z
,
��Z [
sslPolicyErrors
��\ k
)
��k l
=>
��m o
{
��p q
return
��r x
true
��y }
;
��} ~
}�� �
;��� �

HttpClient
�� 
client
�� 
=
�� 
new
��  #

HttpClient
��$ .
(
��. /
clientHandler
��/ <
)
��< =
;
��= >
var
�� 
response
�� 
=
�� 
await
��  
client
��! '
.
��' (
GetAsync
��( 0
(
��0 1
apiUrl
��1 7
+
��7 8&
apiAppointmentController
��8 P
+
��P Q
$str
��Q i
+
��i j
id
��j l
)
��l m
;
��m n
var
�� 
appointments
�� 
=
�� 
JsonConvert
�� *
.
��* +
DeserializeObject
��+ <
<
��< =
List
��= A
<
��A B
AppointmentModel
��B R
>
��R S
>
��S T
(
��T U
await
��U Z
response
��[ c
.
��c d
Content
��d k
.
��k l
ReadAsStringAsync
��l }
(
��} ~
)
��~ 
)�� �
;��� �"
AppointmentViewModel
��  
appointment
��! ,
=
��- .
new
��/ 2"
AppointmentViewModel
��3 G
(
��G H
)
��H I
;
��I J
appointment
�� 
.
�� 
Appointments
�� $
=
��% &
appointments
��' 3
;
��3 4
appointment
�� 
.
�� 
CustomerUsername
�� (
=
��) *
id
��+ -
;
��- .
return
�� 
View
�� 
(
�� 
$str
�� -
,
��- .
appointment
��/ :
)
��: ;
;
��; <
}
�� 	
[
�� 	
HttpGet
��	 
(
�� 
$str
�� #
)
��# $
]
��$ %
public
�� 
IActionResult
�� 
Home
�� !
(
��! "
string
��" (
username
��) 1
)
��1 2
{
�� 	
var
�� 
CustomerViewModel
�� !
=
��" #
new
��$ '
	UserModel
��( 1
(
��1 2
)
��2 3
;
��3 4
CustomerViewModel
�� 
.
�� 
Username
�� &
=
��' (
username
��) 1
;
��1 2
return
�� 
View
�� 
(
�� 
$str
�� "
,
��" #
CustomerViewModel
��$ 5
)
��5 6
;
��6 7
}
�� 	
[
�� 	
HttpPost
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' ("
DisplayProfessionals
��) =
(
��= >
CustomerViewModel
��> O
model
��P U
)
��U V
{
�� 	
HttpClientHandler
�� 
clientHandler
�� +
=
��, -
new
��. 1
HttpClientHandler
��2 C
(
��C D
)
��D E
;
��E F
clientHandler
�� 
.
�� 7
)ServerCertificateCustomValidationCallback
�� C
=
��D E
(
��F G
sender
��G M
,
��M N
cert
��O S
,
��S T
chain
��U Z
,
��Z [
sslPolicyErrors
��\ k
)
��k l
=>
��m o
{
��p q
return
��r x
true
��y }
;
��} ~
}�� �
;��� �

HttpClient
�� 
client
�� 
=
�� 
new
��  #

HttpClient
��$ .
(
��. /
clientHandler
��/ <
)
��< =
;
��= >
var
�� 
response
�� 
=
�� 
await
��  
client
��! '
.
��' (
GetAsync
��( 0
(
��0 1
apiUrl
��1 7
+
��7 8'
apiProfessionalController
��8 Q
+
��Q R
$str
��R l
+
��l m
model
��m r
.
��r s
SearchParam
��s ~
+
��~ 
$str�� �
+��� �
model��� �
.��� �'
ProfessionalSearchValue��� �
)��� �
;��� �
model
�� 
.
�� !
ListOfProfessionals
�� %
=
��& '
JsonConvert
��( 3
.
��3 4
DeserializeObject
��4 E
<
��E F
IEnumerable
��F Q
<
��Q R
ProfessionalModel
��R c
>
��c d
>
��d e
(
��e f
await
��f k
response
��l t
.
��t u
Content
��u |
.
��| } 
ReadAsStringAsync��} �
(��� �
)��� �
)��� �
;��� �
return
�� 
View
�� 
(
�� 
$str
�� .
,
��. /
model
��0 5
)
��5 6
;
��6 7
}
�� 	
[
�� 	
HttpPost
��	 
(
�� 
$str
�� #
)
��# $
]
��$ %
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' (
SetAppointment
��) 7
(
��7 8"
AppointmentViewModel
��8 L
model
��M R
)
��R S
{
�� 	
Console
�� 
.
�� 
	WriteLine
�� 
(
�� 
$str
�� 2
+
��2 3
model
��3 8
.
��8 9
CustomerUsername
��9 I
)
��I J
;
��J K
HttpClientHandler
�� '
professionalclientHandler
�� 7
=
��8 9
new
��: =
HttpClientHandler
��> O
(
��O P
)
��P Q
;
��Q R'
professionalclientHandler
�� %
.
��% &7
)ServerCertificateCustomValidationCallback
��& O
=
��P Q
(
��R S
sender
��S Y
,
��Y Z
cert
��[ _
,
��_ `
chain
��a f
,
��f g
sslPolicyErrors
��h w
)
��w x
=>
��y {
{
��| }
return��~ �
true��� �
;��� �
}��� �
;��� �

HttpClient
��  
professionalclient
�� )
=
��* +
new
��, /

HttpClient
��0 :
(
��: ;'
professionalclientHandler
��; T
)
��T U
;
��U V
var
�� "
professionalresponse
�� $
=
��% &
await
��' , 
professionalclient
��- ?
.
��? @
GetAsync
��@ H
(
��H I
apiUrl
��I O
+
��O P'
apiProfessionalController
��P i
+
��i j
$str
��j ~
+
��~ 
model�� �
.��� �$
ProfessionalUsername��� �
)��� �
;��� �
ProfessionalModel
�� 
professional
�� *
=
��+ ,
JsonConvert
��- 8
.
��8 9
DeserializeObject
��9 J
<
��J K
ProfessionalModel
��K \
>
��\ ]
(
��] ^
await
��^ c"
professionalresponse
��d x
.
��x y
Content��y �
.��� �!
ReadAsStringAsync��� �
(��� �
)��� �
)��� �
;��� �
AppointmentModel
�� 
appointment
�� (
=
��) *
new
��+ .
AppointmentModel
��/ ?
(
��? @
)
��@ A
;
��A B
string
�� 
format
�� 
=
�� 
$str
�� 0
;
��0 1
CultureInfo
�� 
provider
��  
=
��! "
CultureInfo
��# .
.
��. /
InvariantCulture
��/ ?
;
��? @
try
�� 
{
�� 
DateTime
�� 
	startTime
�� "
=
��# $
DateTime
��% -
.
��- .

ParseExact
��. 8
(
��8 9
model
��9 >
.
��> ?
	StartTime
��? H
.
��H I
Trim
��I M
(
��M N
)
��N O
,
��O P
format
��Q W
,
��W X
provider
��Y a
)
��a b
;
��b c
appointment
�� 
.
�� 
Time
��  
=
��! "
new
��# &
	TimeModel
��' 0
(
��0 1
)
��1 2
;
��2 3
appointment
�� 
.
�� 
Time
��  
.
��  !
Start
��! &
=
��' (
	startTime
��) 2
;
��2 3
appointment
�� 
.
�� 
Time
��  
.
��  !
End
��! $
=
��% &
	startTime
��' 0
.
��0 1
AddHours
��1 9
(
��9 :
professional
��: F
.
��F G&
AppointmentLengthInHours
��G _
)
��_ `
;
��` a
}
�� 
catch
�� 
(
�� 
FormatException
�� "
)
��" #
{
�� 
}
�� 
appointment
�� 
.
�� 

IsFufilled
�� "
=
��# $
false
��% *
;
��* +
appointment
�� 
.
�� 
Professional
�� $
=
��$ %
professional
��& 2
;
��2 3
appointment
�� 
.
�� 
EntityID
��  
=
��  !
DateTime
��" *
.
��* +
Now
��+ .
.
��. /
Ticks
��/ 4
;
��4 5
var
�� 
json
�� 
=
�� 
JsonConvert
�� "
.
��" #
SerializeObject
��# 2
(
��2 3
appointment
��3 >
.
��> ?
Time
��? C
)
��C D
;
��D E
StringContent
�� 
content
�� !
=
��" #
new
��$ '
StringContent
��( 5
(
��5 6
json
��6 :
.
��: ;
ToString
��; C
(
��C D
)
��D E
)
��E F
;
��F G
HttpClientHandler
�� 
clientHandler
�� +
=
��, -
new
��. 1
HttpClientHandler
��2 C
(
��C D
)
��D E
;
��E F
clientHandler
�� 
.
�� 7
)ServerCertificateCustomValidationCallback
�� C
=
��D E
(
��F G
sender
��G M
,
��M N
cert
��O S
,
��S T
chain
��U Z
,
��Z [
sslPolicyErrors
��\ k
)
��k l
=>
��m o
{
��p q
return
��r x
true
��y }
;
��} ~
}�� �
;��� �

HttpClient
�� 
client
�� 
=
�� 
new
��  #

HttpClient
��$ .
(
��. /
clientHandler
��/ <
)
��< =
;
��= >
var
�� 
response
�� 
=
�� 
await
��  
client
��! '
.
��' (
	PostAsync
��( 1
(
��1 2
apiUrl
��2 8
+
��8 9
$str
��9 F
+
��F G
$str
��G O
+
��O P
model
��P U
.
��U V
CustomerUsername
��V f
+
��f g
$str
��g j
+
��j k
model
��k p
.
��p q#
ProfessionalUsername��q �
,��� �
content��� �
)��� �
;��� �
CustomerViewModel
�� 
customerView
�� *
=
��+ ,
new
��- 0
CustomerViewModel
��1 B
(
��B C
)
��C D
;
��D E
customerView
�� 
.
�� 
Username
�� !
=
��" #
model
��$ )
.
��) *
CustomerUsername
��* :
;
��: ;"
AppointmentViewModel
��  
appointmentModel
��! 1
=
��1 2
new
��3 6"
AppointmentViewModel
��7 K
(
��K L
)
��L M
;
��M N
appointmentModel
�� 
.
�� "
ProfessionalUsername
�� 1
=
��2 3
model
��4 9
.
��9 :"
ProfessionalUsername
��: N
;
��N O
appointmentModel
�� 
.
�� 
CustomerUsername
�� -
=
��. /
model
��0 5
.
��5 6
CustomerUsername
��6 F
;
��F G
return
�� 
View
�� 
(
�� 
$str
�� /
,
��/ 0
appointmentModel
��0 @
)
��@ A
;
��A B
}
�� 	
[
�� 	
HttpGet
��	 
(
�� 
$str
�� $
)
��$ %
]
��% &
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' (
ViewProfessional
��) 9
(
��9 :
CustomerViewModel
��: K
model
��L Q
)
��Q R
{
�� 	
HttpClientHandler
�� 
clientHandler
�� +
=
��, -
new
��. 1
HttpClientHandler
��2 C
(
��C D
)
��D E
;
��E F
clientHandler
�� 
.
�� 7
)ServerCertificateCustomValidationCallback
�� C
=
��D E
(
��F G
sender
��G M
,
��M N
cert
��O S
,
��S T
chain
��U Z
,
��Z [
sslPolicyErrors
��\ k
)
��k l
=>
��m o
{
��p q
return
��r x
true
��y }
;
��} ~
}�� �
;��� �

HttpClient
�� 
client
�� 
=
�� 
new
��  #

HttpClient
��$ .
(
��. /
clientHandler
��/ <
)
��< =
;
��= >
var
�� 
response
�� 
=
�� 
await
��  
client
��! '
.
��' (
GetAsync
��( 0
(
��0 1
apiUrl
��1 7
+
��7 8'
apiProfessionalController
��8 Q
+
��Q R
$str
��R f
+
��f g
model
��g l
.
��l m,
SearchedProfessionalsUsername��m �
)��� �
;��� �
var
�� 
professional
�� 
=
�� 
JsonConvert
�� *
.
��* +
DeserializeObject
��+ <
<
��< =
ProfessionalModel
��= N
>
��N O
(
��O P
await
��P U
response
��V ^
.
��^ _
Content
��_ f
.
��f g
ReadAsStringAsync
��g x
(
��x y
)
��y z
)
��z {
;
��{ |
model
�� 
.
�� 
Professional
�� 
=
��  
professional
��! -
;
��- .
return
�� 
View
�� 
(
�� 
$str
�� .
,
��. /
model
��0 5
)
��5 6
;
��6 7
}
�� 	
[
�� 	
HttpGet
��	 
(
�� 
$str
�� 6
)
��6 7
]
��7 8
public
�� 
IActionResult
�� 
CreateAppointment
�� .
(
��. /
CustomerViewModel
��/ @
model
��A F
)
��F G
{
�� 	"
AppointmentViewModel
��  
appointmentModel
��! 1
=
��1 2
new
��3 6"
AppointmentViewModel
��7 K
(
��K L
)
��L M
;
��M N
appointmentModel
�� 
.
�� "
ProfessionalUsername
�� 1
=
��2 3
model
��4 9
.
��9 :+
SearchedProfessionalsUsername
��: W
;
��W X
appointmentModel
�� 
.
�� 
CustomerUsername
�� -
=
��. /
model
��0 5
.
��5 6
Username
��6 >
;
��> ?
appointmentModel
�� 
.
�� &
AppointmentLengthInHours
�� 5
=
��6 7
model
��8 =
.
��= >&
AppointmentLengthInHours
��> V
;
��V W
appointmentModel
�� 
.
�� 

HourlyRate
�� '
=
��( )
model
��* /
.
��/ 0

HourlyRate
��0 :
;
��: ;
return
�� 
View
�� 
(
�� 
$str
�� +
,
��+ ,
appointmentModel
��- =
)
��= >
;
��> ?
}
�� 	
[
��	 

HttpGet
��
 
(
�� 
$str
�� ,
)
��, -
]
��- .
public
��	 
IActionResult
�� %
AccountCreationCustomer
�� 5
(
��5 6
)
��6 7
{
��	 
&
AccountCreationViewModel
�� %
accountModel
��& 2
=
��3 4
new
��5 8&
AccountCreationViewModel
��9 Q
(
��Q R
)
��R S
;
��S T
return
�� 
View
�� 
(
�� 
$str
�� *
,
��* +
accountModel
��, 8
)
��8 9
;
��9 :
}
��	 

[
��	 

HttpGet
��
 
(
�� 
$str
�� 0
)
��0 1
]
��1 2
public
��	 
IActionResult
�� )
AccountCreationProfessional
�� 9
(
��9 :
)
��: ;
{
��	 

ProfessionalModel
�� 
accountModel
�� +
=
��, -
new
��. 1
ProfessionalModel
��2 C
(
��C D
)
��D E
;
��E F
return
�� 
View
�� 
(
�� 
$str
�� 6
,
��6 7
accountModel
��8 D
)
��D E
;
��E F
}
��	 

[
��	 

HttpPost
��
 
(
�� 
$str
�� #
)
��# $
]
��$ %
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' (
CreateAccount
��) 6
(
��6 7&
AccountCreationViewModel
��7 O
model
��P U
)
��U V
{
�� 	
CustomerModel
�� 
customer
�� "
=
��# $
new
��% (
CustomerModel
��) 6
(
��6 7
)
��7 8
{
��8 9
Username
��9 A
=
��B C
model
��D I
.
��I J
username
��J R
,
��R S
Password
��T \
=
��] ^
model
��_ d
.
��d e
password
��e m
,
��m n
	FirstName
��n w
=
��x y
model
��z 
.�� �
	firstname��� �
,��� �
LastName��� �
=��� �
model��� �
.��� �
lastname��� �
,��� �
Gender��� �
=��� �
model��� �
.��� �
gender��� �
,��� �
PhoneNumber��� �
=��� �
model��� �
.��� �
phonenumber��� �
,��� �
EmailAddress��� �
=��� �
model��� �
.��� �
emailaddress��� �
}��� �
;��� �
var
�� 
json
�� 
=
�� 
JsonConvert
�� "
.
��" #
SerializeObject
��# 2
(
��2 3
model
��3 8
)
��8 9
;
��9 :
StringContent
�� 
content
�� !
=
��" #
new
��$ '
StringContent
��( 5
(
��5 6
json
��6 :
.
��: ;
ToString
��; C
(
��C D
)
��D E
)
��E F
;
��F G
HttpClientHandler
�� 
clientHandler
�� +
=
��, -
new
��. 1
HttpClientHandler
��2 C
(
��C D
)
��D E
;
��E F
clientHandler
�� 
.
�� 7
)ServerCertificateCustomValidationCallback
�� C
=
��D E
(
��F G
sender
��G M
,
��M N
cert
��O S
,
��S T
chain
��U Z
,
��Z [
sslPolicyErrors
��\ k
)
��k l
=>
��m o
{
��p q
return
��r x
true
��y }
;
��} ~
}�� �
;��� �

HttpClient
�� 
client
�� 
=
�� 
new
��  #

HttpClient
��$ .
(
��. /
clientHandler
��/ <
)
��< =
;
��= >
var
�� 
response
�� 
=
�� 
await
��  
client
��! '
.
��' (
	PostAsync
��( 1
(
��1 2
apiUrl
��2 8
+
��8 9
loginController
��9 H
+
��H I
$str
��I _
,
��_ `
content
��a h
)
��h i
;
��i j
LoginViewModel
�� 
	modelForm
�� $
=
��% &
new
��' *
LoginViewModel
��+ 9
(
��9 :
)
��: ;
;
��; <
if
�� 
(
�� 
response
�� 
.
�� !
IsSuccessStatusCode
�� +
)
��+ ,
{
�� 
return
�� 
View
�� 
(
�� 
$str
�� '
,
��' (
	modelForm
��) 2
)
��3 4
;
��4 5
}
�� 
	modelForm
�� 
.
�� 
Error
�� 
=
�� 
$str
�� 9
;
��9 :
return
�� 
View
�� 
(
�� 
$str
�� #
,
��# $
	modelForm
��% .
)
��. /
;
��/ 0
}
�� 	
[
�� 	
HttpPost
��	 
(
�� 
$str
�� .
)
��. /
]
��/ 0
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' ('
CreateAccountProfessional
��) B
(
��B C
ProfessionalModel
��C T
model
��U Z
)
��Z [
{
�� 	
model
�� 
.
�� 
MemberSince
�� 
=
�� 
DateTime
��  (
.
��( )
Now
��) ,
;
��, -
model
�� 
.
�� 
Rating
�� 
=
�� 
$num
�� 
;
�� 
var
�� 
json
�� 
=
�� 
JsonConvert
�� "
.
��" #
SerializeObject
��# 2
(
��2 3
model
��3 8
)
��8 9
;
��9 :
StringContent
�� 
content
�� !
=
��" #
new
��$ '
StringContent
��( 5
(
��5 6
json
��6 :
.
��: ;
ToString
��; C
(
��C D
)
��D E
)
��E F
;
��F G
HttpClientHandler
�� 
clientHandler
�� +
=
��, -
new
��. 1
HttpClientHandler
��2 C
(
��C D
)
��D E
;
��E F
clientHandler
�� 
.
�� 7
)ServerCertificateCustomValidationCallback
�� C
=
��D E
(
��F G
sender
��G M
,
��M N
cert
��O S
,
��S T
chain
��U Z
,
��Z [
sslPolicyErrors
��\ k
)
��k l
=>
��m o
{
��p q
return
��r x
true
��y }
;
��} ~
}�� �
;��� �

HttpClient
�� 
client
�� 
=
�� 
new
��  #

HttpClient
��$ .
(
��. /
clientHandler
��/ <
)
��< =
;
��= >
var
�� 
response
�� 
=
�� 
await
��  
client
��! '
.
��' (
	PostAsync
��( 1
(
��1 2
apiUrl
��2 8
+
��8 9
loginController
��9 H
+
��H I
$str
��I e
,
��e f
content
��g n
)
��n o
;
��o p
LoginViewModel
�� 
	modelForm
�� $
=
��% &
new
��' *
LoginViewModel
��+ 9
(
��9 :
)
��: ;
;
��; <
if
�� 
(
�� 
response
�� 
.
�� !
IsSuccessStatusCode
�� +
)
��+ ,
{
�� 
return
�� 
View
�� 
(
�� 
$str
�� '
,
��' (
	modelForm
��) 2
)
��3 4
;
��4 5
}
�� 
	modelForm
�� 
.
�� 
Error
�� 
=
�� 
$str
�� 9
;
��9 :
return
�� 
View
�� 
(
�� 
$str
�� #
,
��# $
	modelForm
��% .
)
��. /
;
��/ 0
}
�� 	
}
�� 
}�� �
g/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Controllers/HomeController.cs
	namespace

 	

RevAppoint


 
.

 
Client

 
.

 
Controllers

 '
{ 
public 

class 
HomeController 
:  !

Controller" ,
{ 
private 
readonly 
ILogger  
<  !
HomeController! /
>/ 0
_logger1 8
;8 9
public 
HomeController 
( 
ILogger %
<% &
HomeController& 4
>4 5
logger6 <
)< =
{ 	
_logger 
= 
logger 
; 
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
public 
IActionResult 
Privacy $
($ %
)% &
{ 	
return 
View 
( 
) 
; 
} 	
[ 	
ResponseCache	 
( 
Duration 
=  !
$num" #
,# $
Location% -
=. /!
ResponseCacheLocation0 E
.E F
NoneF J
,J K
NoStoreL S
=T U
trueV Z
)Z [
][ \
public   
IActionResult   
Error   "
(  " #
)  # $
{!! 	
return"" 
View"" 
("" 
new"" 
ErrorViewModel"" *
{""+ ,
	RequestId""- 6
=""7 8
Activity""9 A
.""A B
Current""B I
?""I J
.""J K
Id""K M
??""N P
HttpContext""Q \
.""\ ]
TraceIdentifier""] l
}""m n
)""n o
;""o p
}## 	
}$$ 
}%% ��
o/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Controllers/ProfessionalController.cs
	namespace

 	

RevAppoint


 
.

 
Client

 
.

 
Controllers

 '
{ 
[ 
Route 

(
 
$str 
) 
] 
public 

class "
ProfessionalController '
:( )

Controller* 4
{ 
private 
string 
apiUrl 
= 
$str  8
;8 9
private 
string %
apiProfessionalController 0
=1 2
$str3 A
;A B
private 
string $
apiAppointmentController /
=0 1
$str2 ?
;? @
[ 	
HttpGet	 
( 
$str 1
)1 2
]2 3
public 
async 
Task 
< 
IActionResult '
>' (
ProfessionalHome) 9
(9 :!
ProfessionalViewModel: O
modelP U
)U V
{ 	
HttpClientHandler 
clientHandler +
=, -
new. 1
HttpClientHandler2 C
(C D
)D E
;E F
clientHandler 
. 5
)ServerCertificateCustomValidationCallback C
=D E
(F G
senderG M
,M N
certO S
,S T
chainU Z
,Z [
sslPolicyErrors\ k
)k l
=>m o
{p q
returnr x
truey }
;} ~
}	 �
;
� �

HttpClient 
client 
= 
new  #

HttpClient$ .
(. /
clientHandler/ <
)< =
;= >
var 
response 
= 
await  
client! '
.' (
GetAsync( 0
(0 1
apiUrl1 7
+7 8%
apiProfessionalController8 Q
+Q R
$strR j
+j k
modelk p
.p q
Usernameq y
)y z
;z {
var 
	userModel 
= 
JsonConvert '
.' (
DeserializeObject( 9
<9 :
	UserModel: C
>C D
(D E
awaitE J
responseK S
.S T
ContentT [
.[ \
ReadAsStringAsync\ m
(m n
)n o
)o p
;p q
return 
View 
( 
$str *
,* +
	userModel, 5
)5 6
;6 7
} 	
[	 

HttpGet
 
( 
$str 6
)6 7
]7 8
public 
async 
Task 
< 
IActionResult '
>' (
SetAvailability) 8
(8 9
string9 ?
id@ B
)B C
{   	!
ProfessionalViewModel!!	 
model!! $
=!!% &
new!!' *!
ProfessionalViewModel!!+ @
(!!@ A
)!!A B
;!!B C
model""	 
."" 
Username"" 
="" 
id"" 
;"" 
return##	 
View## 
(## 
$str## &
,##& '
model##( -
)##- .
;##. /
}%% 	
['' 	
HttpGet''	 
('' 
$str'' 1
)''1 2
]''2 3
public(( 
async(( 
Task(( 
<(( 
IActionResult(( '
>((' (
ViewProfile(() 4
(((4 5
string((5 ;
id((< >
)((> ?
{)) 	
HttpClientHandler** 
clientHandler** +
=**, -
new**. 1
HttpClientHandler**2 C
(**C D
)**D E
;**E F
clientHandler++ 
.++ 5
)ServerCertificateCustomValidationCallback++ C
=++D E
(++F G
sender++G M
,++M N
cert++O S
,++S T
chain++U Z
,++Z [
sslPolicyErrors++\ k
)++k l
=>++m o
{++p q
return++r x
true++y }
;++} ~
}	++ �
;
++� �

HttpClient,, 
client,, 
=,, 
new,,  #

HttpClient,,$ .
(,,. /
clientHandler,,/ <
),,< =
;,,= >
var-- 
response-- 
=-- 
await--  
client--! '
.--' (
GetAsync--( 0
(--0 1
apiUrl--1 7
+--7 8%
apiProfessionalController--8 Q
+--Q R
$str--R f
+--f g
id--g i
)--i j
;--j k
var.. 
professional.. 
=.. 
JsonConvert.. *
...* +
DeserializeObject..+ <
<..< =
ProfessionalModel..= N
>..N O
(..O P
await..P U
response..V ^
...^ _
Content.._ f
...f g
ReadAsStringAsync..g x
(..x y
)..y z
)..z {
;..{ |!
ProfessionalViewModel// !
professionalView//" 2
=//3 4
new//5 8!
ProfessionalViewModel//9 N
(//N O
)//O P
;//P Q
professionalView00 
.00 
Professional00 )
=00* +
professional00, 8
;008 9
professionalView11 
.11 
Username11 %
=11& '
id11( *
;11* +
return22 
View22 
(22 
$str22 1
,221 2
professionalView222 B
)22B C
;22C D
}44 	
[66 	
HttpGet66	 
(66 
$str66 8
)668 9
]669 :
public77 
async77 
Task77 
<77 
IActionResult77 '
>77' (
AppointmentHistory77) ;
(77; <
string77< B
id77C E
)77E F
{88 	
HttpClientHandler99 
clientHandler99 +
=99, -
new99. 1
HttpClientHandler992 C
(99C D
)99D E
;99E F
clientHandler:: 
.:: 5
)ServerCertificateCustomValidationCallback:: C
=::D E
(::F G
sender::G M
,::M N
cert::O S
,::S T
chain::U Z
,::Z [
sslPolicyErrors::\ k
)::k l
=>::m o
{::p q
return::r x
true::y }
;::} ~
}	:: �
;
::� �

HttpClient;; 
client;; 
=;; 
new;;  #

HttpClient;;$ .
(;;. /
clientHandler;;/ <
);;< =
;;;= >
var<< 
response<< 
=<< 
await<<  
client<<! '
.<<' (
GetAsync<<( 0
(<<0 1
apiUrl<<1 7
+<<7 8$
apiAppointmentController<<8 P
+<<P Q
$str<<Q m
+<<m n
id<<n p
)<<p q
;<<q r
var== 
appointments== 
=== 
JsonConvert== *
.==* +
DeserializeObject==+ <
<==< =
List=== A
<==A B
AppointmentModel==B R
>==R S
>==S T
(==T U
await==U Z
response==[ c
.==c d
Content==d k
.==k l
ReadAsStringAsync==l }
(==} ~
)==~ 
)	== �
;
==� � 
AppointmentViewModel>>  
appointment>>! ,
=>>- .
new>>/ 2 
AppointmentViewModel>>3 G
(>>G H
)>>H I
;>>I J
appointment?? 
.?? 
Appointments?? $
=??% &
appointments??' 3
;??3 4
appointment@@ 
.@@  
ProfessionalUsername@@ ,
=@@- .
id@@/ 1
;@@1 2
returnAA 
ViewAA 
(AA 
$strAA ,
,AA, -
appointmentAA. 9
)AA9 :
;AA: ;
}BB 	
[DD 	
HttpPostDD	 
(DD 
$strDD ?
)DD? @
]DD@ A
publicEE 
asyncEE 
TaskEE 
<EE 
IActionResultEE '
>EE' ( 
EditAccountInfoAsyncEE) =
(EE= >
stringEE> D
idEEE G
,EEG H!
ProfessionalViewModelEEI ^
modelEE_ d
)EEd e
{FF 	!
ProfessionalViewModelGG !
newModelGG" *
=GG+ ,
newGG- 0!
ProfessionalViewModelGG1 F
(GGF G
)GGG H
;GGH I
ProfessionalModelHH 
newProfHH %
=HH& '
newHH( +
ProfessionalModelHH, =
(HH= >
)HH> ?
;HH? @
newProfII 
.II 
TitleII 
=II 
modelII !
.II! "
ProfessionalII" .
.II. /
TitleII/ 4
;II4 5
newProfJJ 
.JJ 
LocationJJ 
=JJ 
modelJJ $
.JJ$ %
ProfessionalJJ% 1
.JJ1 2
LocationJJ2 :
;JJ: ;
newProfKK 
.KK $
AppointmentLengthInHoursKK ,
=KK- .
modelKK/ 4
.KK4 5
ProfessionalKK5 A
.KKA B$
AppointmentLengthInHoursKKB Z
;KKZ [
newProfLL 
.LL 

HourlyRateLL 
=LL  
modelLL! &
.LL& '
ProfessionalLL' 3
.LL3 4

HourlyRateLL4 >
;LL> ?
newProfMM 
.MM 
LanguageMM 
=MM 
modelMM $
.MM$ %
ProfessionalMM% 1
.MM1 2
LanguageMM2 :
;MM: ;
newProfNN 
.NN 
BioNN 
=NN 
modelNN 
.NN  
ProfessionalNN  ,
.NN, -
BioNN- 0
;NN0 1
newProfOO 
.OO 
UsernameOO 
=OO 
idOO !
;OO! "
newModelQQ 
.QQ 
ProfessionalQQ !
=QQ" #
newProfQQ$ +
;QQ+ ,
newModelRR 
.RR 
ProfessionalRR !
.RR! "
RatingRR" (
=RR) *
modelRR+ 0
.RR0 1
ProfessionalRR1 =
.RR= >
RatingRR> D
;RRD E
newModelSS 
.SS 
UsernameSS 
=SS 
idSS  "
;SS" #
HttpClientHandlerUU 
clientHandlerUU +
=UU, -
newUU. 1
HttpClientHandlerUU2 C
(UUC D
)UUD E
;UUE F
varVV 
jsonVV 
=VV 
JsonConvertVV "
.VV" #
SerializeObjectVV# 2
(VV2 3
newProfVV3 :
)VV: ;
;VV; <
StringContentWW 
contentWW !
=WW" #
newWW$ '
StringContentWW( 5
(WW5 6
jsonWW6 :
.WW: ;
ToStringWW; C
(WWC D
)WWD E
)WWE F
;WWF G
ConsoleXX 
.XX 
	WriteLineXX 
(XX 
jsonXX "
)XX" #
;XX# $
clientHandlerYY 
.YY 5
)ServerCertificateCustomValidationCallbackYY C
=YYD E
(YYF G
senderYYG M
,YYM N
certYYO S
,YYS T
chainYYU Z
,YYZ [
sslPolicyErrorsYY\ k
)YYk l
=>YYm o
{YYp q
returnYYr x
trueYYy }
;YY} ~
}	YY �
;
YY� �

HttpClientZZ 
clientZZ 
=ZZ 
newZZ  #

HttpClientZZ$ .
(ZZ. /
clientHandlerZZ/ <
)ZZ< =
;ZZ= >
var[[ 
response[[ 
=[[ 
await[[  
client[[! '
.[[' (
PutAsync[[( 0
([[0 1
apiUrl[[1 7
+[[7 8%
apiProfessionalController[[8 Q
+[[Q R
$str[[R g
,[[g h
content[[h o
)[[o p
;[[p q
return]] 
View]] 
(]] 
$str]] 1
,]]1 2
newModel]]3 ;
)]]; <
;]]< =
}^^ 	
[`` 	
HttpGet``	 
(`` 
$str`` 9
)``9 :
]``: ;
publicaa 
asyncaa 
Taskaa 
<aa 
IActionResultaa '
>aa' (
PendingAppointmentsaa) <
(aa< =
stringaa= C
idaaD F
)aaF G
{bb 	
HttpClientHandlercc 
clientHandlercc +
=cc, -
newcc. 1
HttpClientHandlercc2 C
(ccC D
)ccD E
;ccE F
clientHandlerdd 
.dd 5
)ServerCertificateCustomValidationCallbackdd C
=ddD E
(ddF G
senderddG M
,ddM N
certddO S
,ddS T
chainddU Z
,ddZ [
sslPolicyErrorsdd\ k
)ddk l
=>ddm o
{ddp q
returnddr x
trueddy }
;dd} ~
}	dd �
;
dd� �

HttpClientee 
clientee 
=ee 
newee  #

HttpClientee$ .
(ee. /
clientHandleree/ <
)ee< =
;ee= >
varff 
responseff 
=ff 
awaitff  
clientff! '
.ff' (
GetAsyncff( 0
(ff0 1
apiUrlff1 7
+ff7 8$
apiAppointmentControllerff8 P
+ffP Q
$strffQ l
+ffl m
idffm o
)ffo p
;ffp q
vargg 
appointmentsgg 
=gg 
JsonConvertgg *
.gg* +
DeserializeObjectgg+ <
<gg< =
Listgg= A
<ggA B
AppointmentModelggB R
>ggR S
>ggS T
(ggT U
awaitggU Z
responsegg[ c
.ggc d
Contentggd k
.ggk l
ReadAsStringAsyncggl }
(gg} ~
)gg~ 
)	gg �
;
gg� � 
AppointmentViewModelhh  
appointmenthh! ,
=hh- .
newhh/ 2 
AppointmentViewModelhh3 G
(hhG H
)hhH I
;hhI J
appointmentii 
.ii 
Appointmentsii $
=ii% &
appointmentsii' 3
;ii3 4
appointmentjj 
.jj  
ProfessionalUsernamejj ,
=jj- .
idjj/ 1
;jj1 2
returnkk 
Viewkk 
(kk 
$strkk -
,kk- .
appointmentkk/ :
)kk: ;
;kk; <
}ll 	
[nn 	
HttpGetnn	 
(nn 
$strnn 9
)nn9 :
]nn: ;
publicoo 
asyncoo 
Taskoo 
<oo 
IActionResultoo '
>oo' (
CurrentAppointmentsoo) <
(oo< =
stringoo= C
idooD F
)ooF G
{pp 	
HttpClientHandlerqq 
clientHandlerqq +
=qq, -
newqq. 1
HttpClientHandlerqq2 C
(qqC D
)qqD E
;qqE F
clientHandlerrr 
.rr 5
)ServerCertificateCustomValidationCallbackrr C
=rrD E
(rrF G
senderrrG M
,rrM N
certrrO S
,rrS T
chainrrU Z
,rrZ [
sslPolicyErrorsrr\ k
)rrk l
=>rrm o
{rrp q
returnrrr x
truerry }
;rr} ~
}	rr �
;
rr� �

HttpClientss 
clientss 
=ss 
newss  #

HttpClientss$ .
(ss. /
clientHandlerss/ <
)ss< =
;ss= >
vartt 
responsett 
=tt 
awaittt  
clienttt! '
.tt' (
GetAsynctt( 0
(tt0 1
apiUrltt1 7
+tt7 8$
apiAppointmentControllertt8 P
+ttP Q
$strttQ m
+ttm n
idttn p
)ttp q
;ttq r
varuu 
appointmentsuu 
=uu 
JsonConvertuu *
.uu* +
DeserializeObjectuu+ <
<uu< =
Listuu= A
<uuA B
AppointmentModeluuB R
>uuR S
>uuS T
(uuT U
awaituuU Z
responseuu[ c
.uuc d
Contentuud k
.uuk l
ReadAsStringAsyncuul }
(uu} ~
)uu~ 
)	uu �
;
uu� � 
AppointmentViewModelvv  
appointmentvv! ,
=vv- .
newvv/ 2 
AppointmentViewModelvv3 G
(vvG H
)vvH I
;vvI J
appointmentww 
.ww 
Appointmentsww $
=ww% &
appointmentsww' 3
;ww3 4
appointmentxx 
.xx  
ProfessionalUsernamexx ,
=xx- .
idxx/ 1
;xx1 2
returnyy 
Viewyy 
(yy 
$stryy -
,yy- .
appointmentyy/ :
)yy: ;
;yy; <
}{{ 	
[|| 	
Route||	 
(|| 
$str|| 
)|| 
]|| 
[}} 	
HttpPost}}	 
]}} 
public~~ 
async~~ 
Task~~ 
<~~ 
IActionResult~~ '
>~~' (
CompleteAppointment~~) <
(~~< = 
AppointmentViewModel~~= Q
model~~R W
)~~W X
{ 	
HttpClientHandler
�� 
clientHandler
�� +
=
��, -
new
��. 1
HttpClientHandler
��2 C
(
��C D
)
��D E
;
��E F
clientHandler
�� 
.
�� 7
)ServerCertificateCustomValidationCallback
�� C
=
��D E
(
��F G
sender
��G M
,
��M N
cert
��O S
,
��S T
chain
��U Z
,
��Z [
sslPolicyErrors
��\ k
)
��k l
=>
��m o
{
��p q
return
��r x
true
��y }
;
��} ~
}�� �
;��� �

HttpClient
�� 
client
�� 
=
�� 
new
��  #

HttpClient
��$ .
(
��. /
clientHandler
��/ <
)
��< =
;
��= >
var
�� 
response
�� 
=
�� 
await
��  
client
��! '
.
��' (
GetAsync
��( 0
(
��0 1
apiUrl
��1 7
+
��7 8&
apiAppointmentController
��8 P
+
��P Q
$str
��Q h
+
��h i
model
��i n
.
��n o
AppointmentID
��o |
)
��| }
;
��} ~
HttpClientHandler
�� 
clientHandler2
�� ,
=
��- .
new
��/ 2
HttpClientHandler
��3 D
(
��D E
)
��E F
;
��F G
clientHandler2
�� 
.
�� 7
)ServerCertificateCustomValidationCallback
�� D
=
��E F
(
��G H
sender
��H N
,
��N O
cert
��P T
,
��T U
chain
��V [
,
��[ \
sslPolicyErrors
��] l
)
��l m
=>
��n p
{
��q r
return
��s y
true
��z ~
;
��~ 
}��� �
;��� �

HttpClient
�� 
client2
�� 
=
��  
new
��! $

HttpClient
��% /
(
��/ 0
clientHandler2
��0 >
)
��> ?
;
��? @
var
�� 
	response2
�� 
=
�� 
await
�� !
client2
��" )
.
��) *
GetAsync
��* 2
(
��2 3
apiUrl
��3 9
+
��9 :'
apiProfessionalController
��: S
+
��S T
$str
��T l
+
��l m
model
��m r
.
��r s#
ProfessionalUsername��s �
)��� �
;��� �
	UserModel
�� 
user
�� 
=
�� 
JsonConvert
�� (
.
��( )
DeserializeObject
��) :
<
��: ;
	UserModel
��; D
>
��D E
(
��E F
await
��F K
	response2
��L U
.
��U V
Content
��V ]
.
��] ^
ReadAsStringAsync
��^ o
(
��o p
)
��p q
)
��q r
;
��r s
return
�� 
View
�� 
(
�� 
$str
�� *
,
��* +
user
��, 0
)
��0 1
;
��1 2
}
�� 	
[
�� 	
Route
��	 
(
�� 
$str
�� 
)
�� 
]
�� 
[
�� 	
HttpPost
��	 
]
�� 
public
�� 
async
�� 
Task
�� 
<
�� 
IActionResult
�� '
>
��' (
AcceptAppointment
��) :
(
��: ;"
AppointmentViewModel
��; O
model
��P U
)
��U V
{
�� 	
HttpClientHandler
�� 
clientHandler
�� +
=
��, -
new
��. 1
HttpClientHandler
��2 C
(
��C D
)
��D E
;
��E F
clientHandler
�� 
.
�� 7
)ServerCertificateCustomValidationCallback
�� C
=
��D E
(
��F G
sender
��G M
,
��M N
cert
��O S
,
��S T
chain
��U Z
,
��Z [
sslPolicyErrors
��\ k
)
��k l
=>
��m o
{
��p q
return
��r x
true
��y }
;
��} ~
}�� �
;��� �

HttpClient
�� 
client
�� 
=
�� 
new
��  #

HttpClient
��$ .
(
��. /
clientHandler
��/ <
)
��< =
;
��= >
var
�� 
response
�� 
=
�� 
await
��  
client
��! '
.
��' (
GetAsync
��( 0
(
��0 1
apiUrl
��1 7
+
��7 8&
apiAppointmentController
��8 P
+
��P Q
$str
��Q f
+
��f g
model
��g l
.
��l m
AppointmentID
��m z
)
��z {
;
��{ |
HttpClientHandler
�� 
clientHandler2
�� ,
=
��- .
new
��/ 2
HttpClientHandler
��3 D
(
��D E
)
��E F
;
��F G
clientHandler2
�� 
.
�� 7
)ServerCertificateCustomValidationCallback
�� D
=
��E F
(
��G H
sender
��H N
,
��N O
cert
��P T
,
��T U
chain
��V [
,
��[ \
sslPolicyErrors
��] l
)
��l m
=>
��n p
{
��q r
return
��s y
true
��z ~
;
��~ 
}��� �
;��� �

HttpClient
�� 
client2
�� 
=
��  
new
��! $

HttpClient
��% /
(
��/ 0
clientHandler2
��0 >
)
��> ?
;
��? @
var
�� 
	response2
�� 
=
�� 
await
�� !
client2
��" )
.
��) *
GetAsync
��* 2
(
��2 3
apiUrl
��3 9
+
��9 :'
apiProfessionalController
��: S
+
��S T
$str
��T l
+
��l m
model
��m r
.
��r s#
ProfessionalUsername��s �
)��� �
;��� �
	UserModel
�� 
user
�� 
=
�� 
JsonConvert
�� (
.
��( )
DeserializeObject
��) :
<
��: ;
	UserModel
��; D
>
��D E
(
��E F
await
��F K
	response2
��L U
.
��U V
Content
��V ]
.
��] ^
ReadAsStringAsync
��^ o
(
��o p
)
��p q
)
��q r
;
��r s
return
�� 
View
�� 
(
�� 
$str
�� *
,
��* +
user
��, 0
)
��0 1
;
��1 2
}
�� 	
}
�� 
}�� �
l/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/AccountCreationViewModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class $
AccountCreationViewModel )
{ 
public 
string 
username 
{  
get  #
;# $
set$ '
;' (
}( )
public		 
string		 
password		 
{		  
get		  #
;		# $
set		$ '
;		' (
}		( )
public

 
string

 
	firstname

 
{

  !
get

! $
;

$ %
set

% (
;

( )
}

) *
public 
string 
lastname 
{  
get  #
;# $
set$ '
;' (
}( )
public 
string 
gender 
{ 
get !
;! "
set" %
;% &
}& '
public 
string 
phonenumber !
{" #
get# &
;& '
set' *
;* +
}+ ,
public 
string 
emailaddress "
{# $
get$ '
;' (
set( +
;+ ,
}, -
} 
} �	
d/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/AppointmentModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class 
AppointmentModel !
:" #
EntityModel$ /
{ 
public 
	TimeModel 
Time 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
ProfessionalModel		  
Professional		! -
{		. /
get		0 3
;		3 4
set		5 8
;		8 9
}		: ;
public

 
	UserModel

 
Client

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
bool 

IsAccepted 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
bool 

IsFufilled 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} �
h/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/AppointmentViewModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class  
AppointmentViewModel %
{ 
public 
List 
< 
AppointmentModel $
>$ %
Appointments& 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public		 
string		 
	StartTime		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
public

 
ProfessionalModel

  
Professional

! -
{

. /
get

0 3
;

3 4
set

5 8
;

8 9
}

9 :
public 
string  
ProfessionalUsername *
{* +
get+ .
;. /
set/ 2
;2 3
}3 4
public 
CustomerModel 
Customer %
{& '
get( +
;+ ,
set- 0
;0 1
}1 2
public 
string 
CustomerUsername &
{' (
get( +
;+ ,
set, /
;/ 0
}0 1
public 
DateTime 
Time 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
AppointmentID #
{$ %
get% (
;( )
set) ,
;, -
}- .
public 
bool 

IsFufilled 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
bool 

IsAccepted 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 

HourlyRate  
{! "
get" %
;% &
set' *
;* +
}+ ,
public 
string $
AppointmentLengthInHours .
{. /
get/ 2
;2 3
set3 6
;6 7
}7 8
} 
} �
a/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/CustomerModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class 
CustomerModel 
:  
	UserModel! *
{ 
} 
}		 �
e/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/CustomerViewModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class 
CustomerViewModel "
{ 
[ 	
Required	 
( 
AllowEmptyStrings #
=# $
false$ )
)) *
]* +
public		 
string		 
Username		 
{		 
get		 "
;		" #
set		# &
;		& '
}		' (
public

 
IEnumerable

 
<

 
CustomerModel

 (
>

( )
	Customers

* 3
{

4 5
get

6 9
;

9 :
set

; >
;

> ?
}

@ A
public 
IEnumerable 
< 
ProfessionalModel ,
>, -
Professionals. ;
{< =
get> A
;A B
setC F
;F G
}H I
public 
CustomerModel 
Customer %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
IEnumerable 
< 
AppointmentModel +
>+ ,
AppointmentHistory- ?
{@ A
getA D
;D E
setE H
;H I
}I J
public 
AppointmentModel 
Appointment  +
{, -
get- 0
;0 1
set1 4
;4 5
}5 6
public 
string 
SearchParam !
{" #
get# &
;& '
set' *
;* +
}+ ,
public 
string #
ProfessionalSearchValue -
{. /
get/ 2
;2 3
set3 6
;6 7
}7 8
public 
IEnumerable 
< 
ProfessionalModel ,
>, -
ListOfProfessionals. A
{B C
getC F
;F G
setG J
;J K
}K L
public 
string )
SearchedProfessionalsUsername 3
{4 5
get5 8
;8 9
set9 <
;< =
}= >
public 
ProfessionalModel  
Professional! -
{. /
get/ 2
;2 3
set3 6
;6 7
}7 8
public 
string 

HourlyRate  
{  !
get! $
;$ %
set% (
;( )
}) *
public 
string $
AppointmentLengthInHours .
{. /
get/ 2
;2 3
set3 6
;6 7
}7 8
} 
} �
_/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/EntityModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class 
EntityModel 
{ 
public 
long 
EntityID 
{ 
get !
;! "
set" %
;% &
}& '
}		 
}

 �
b/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/ErrorViewModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class 
ErrorViewModel 
{ 
public 
string 
	RequestId 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
bool		 
ShowRequestId		 !
=>		" $
!		% &
string		& ,
.		, -
IsNullOrEmpty		- :
(		: ;
	RequestId		; D
)		D E
;		E F
} 
} �
b/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/LoginViewModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class 
LoginViewModel 
{ 
[ 	
Required	 
( 
AllowEmptyStrings #
=# $
false$ )
)) *
]* +
public 
string 
Username 
{ 
get "
;" #
set# &
;& '
}' (
[

 	
Required

	 
(

 
AllowEmptyStrings

 #
=

# $
false

$ )
)

) *
]

* +
public 
string 
Password 
{ 
get "
;" #
set# &
;& '
}' (
public 
string 
Error 
{ 
get 
;  
set  #
;# $
}$ %
} 
} �
e/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/ProfessionalModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class 
ProfessionalModel "
:# $
	UserModel% .
{ 
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
public		 
string		 
Location		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
public

 
	TimeModel

 
AvailableTime

 &
{

' (
get

) ,
;

, -
set

. 1
;

1 2
}

3 4
public 
int $
AppointmentLengthInHours +
{, -
get- 0
;0 1
set1 4
;4 5
}5 6
public 
decimal 

HourlyRate !
{" #
get# &
;& '
set' *
;* +
}+ ,
public 
string 
Language 
{  
get  #
;# $
set$ '
;' (
}( )
public 
string 
Bio 
{ 
get 
; 
set "
;" #
}# $
public 
double 
Rating 
{ 
get !
;! "
set" %
;% &
}& '
} 
} �
i/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/ProfessionalViewModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class !
ProfessionalViewModel &
{ 
[ 	
Required	 
( 
AllowEmptyStrings #
=# $
false$ )
)) *
]* +
public		 
string		 
Username		 
{		 
get		 "
;		" #
set		# &
;		& '
}		' (
public

 
IEnumerable

 
<

 
ProfessionalModel

 ,
>

, -
Professionals

. ;
{

< =
get

> A
;

A B
set

C F
;

F G
}

H I
public 
ProfessionalModel  
Professional! -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
IEnumerable 
< 
AppointmentModel +
>+ ,
AppointmentHistory- ?
{@ A
getA D
;D E
setE H
;H I
}I J
public 
IEnumerable 
< 
AppointmentModel +
>+ ,
CurrentAppointmets- ?
{@ A
getA D
;D E
setE H
;H I
}I J
public 
AppointmentModel 
Appointment  +
{, -
get- 0
;0 1
set1 4
;4 5
}5 6
public 
string 
AppointmentID #
{$ %
get% (
;( )
set) ,
;, -
}- .
} 
} �
]/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/TimeModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class 
	TimeModel 
: 
EntityModel (
{ 
public 
DateTime 
Start 
{ 
get  #
;# $
set% (
;( )
}* +
public 
DateTime 
End 
{ 
get !
;! "
set# &
;& '
}( )
}		 
}

 �
a/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/TimeViewModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class 
TimeViewModel 
{ 
} 
}		 �
]/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Models/UserModel.cs
	namespace 	

RevAppoint
 
. 
Client 
. 
Models "
{ 
public 

class 
	UserModel 
: 
EntityModel (
{ 
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
string		 
Password		 
{		  
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
string

 
	FirstName

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Type 
{ 
get 
;  
set! $
;$ %
}% &
public 
string 
Gender 
{ 
get !
;! "
set" %
;% &
}& '
public 
string 
PhoneNumber !
{" #
get# &
;& '
set' *
;* +
}+ ,
public 
string 
EmailAddress "
{# $
get$ '
;' (
set( +
;+ ,
}, -
public 
DateTime 
MemberSince #
{$ %
get% (
;( )
set) ,
;, -
}- .
public 
List 
< 
AppointmentModel $
>$ %
Appointments& 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
} 
} �

T/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Program.cs
	namespace

 	

RevAppoint


 
.

 
Client

 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} �
T/home/elmer/revature/group-projects/p2/aspnet.Client/RevAppointMVC.Client/Startup.cs
	namespace 	

RevAppoint
 
. 
Client 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. #
AddControllersWithViews ,
(, -
)- .
;. /
} 	
public!! 
void!! 
	Configure!! 
(!! 
IApplicationBuilder!! 1
app!!2 5
,!!5 6
IWebHostEnvironment!!7 J
env!!K N
)!!N O
{"" 	
if## 
(## 
env## 
.## 
IsDevelopment## !
(##! "
)##" #
)### $
{$$ 
app%% 
.%% %
UseDeveloperExceptionPage%% -
(%%- .
)%%. /
;%%/ 0
}&& 
else'' 
{(( 
app)) 
.)) 
UseExceptionHandler)) '
())' (
$str))( 5
)))5 6
;))6 7
app++ 
.++ 
UseHsts++ 
(++ 
)++ 
;++ 
},, 
app-- 
.-- 
UseHttpsRedirection-- #
(--# $
)--$ %
;--% &
app.. 
... 
UseStaticFiles.. 
(.. 
)..  
;..  !
app00 
.00 

UseRouting00 
(00 
)00 
;00 
app22 
.22 
UseAuthorization22  
(22  !
)22! "
;22" #
app44 
.44 
UseEndpoints44 
(44 
	endpoints44 &
=>44' )
{55 
	endpoints66 
.66 
MapControllers66 (
(66( )
)66) *
;66* +
}99 
)99 
;99 
}:: 	
};; 
}<< 