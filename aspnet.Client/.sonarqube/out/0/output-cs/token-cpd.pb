˘°
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
}	WW Ä
;
WWÄ Å

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
}	hh Ä
;
hhÄ Å

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
)	kk Ä
;
kkÄ Å 
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
}	vv Ä
;
vvÄ Å

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
)	yy Ä
;
yyÄ Å 
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
ÄÄ 	
HttpGet
ÄÄ	 
(
ÄÄ 
$str
ÄÄ ,
)
ÄÄ, -
]
ÄÄ- .
public
ÅÅ 
async
ÅÅ 
Task
ÅÅ 
<
ÅÅ 
IActionResult
ÅÅ '
>
ÅÅ' (!
PendingAppointments
ÅÅ) <
(
ÅÅ< =
string
ÅÅ= C
id
ÅÅD F
)
ÅÅF G
{
ÇÇ 	
HttpClientHandler
ÉÉ 
clientHandler
ÉÉ +
=
ÉÉ, -
new
ÉÉ. 1
HttpClientHandler
ÉÉ2 C
(
ÉÉC D
)
ÉÉD E
;
ÉÉE F
clientHandler
ÑÑ 
.
ÑÑ 7
)ServerCertificateCustomValidationCallback
ÑÑ C
=
ÑÑD E
(
ÑÑF G
sender
ÑÑG M
,
ÑÑM N
cert
ÑÑO S
,
ÑÑS T
chain
ÑÑU Z
,
ÑÑZ [
sslPolicyErrors
ÑÑ\ k
)
ÑÑk l
=>
ÑÑm o
{
ÑÑp q
return
ÑÑr x
true
ÑÑy }
;
ÑÑ} ~
}ÑÑ Ä
;ÑÑÄ Å

HttpClient
ÖÖ 
client
ÖÖ 
=
ÖÖ 
new
ÖÖ  #

HttpClient
ÖÖ$ .
(
ÖÖ. /
clientHandler
ÖÖ/ <
)
ÖÖ< =
;
ÖÖ= >
var
ÜÜ 
response
ÜÜ 
=
ÜÜ 
await
ÜÜ  
client
ÜÜ! '
.
ÜÜ' (
GetAsync
ÜÜ( 0
(
ÜÜ0 1
apiUrl
ÜÜ1 7
+
ÜÜ7 8&
apiAppointmentController
ÜÜ8 P
+
ÜÜP Q
$str
ÜÜQ i
+
ÜÜi j
id
ÜÜj l
)
ÜÜl m
;
ÜÜm n
var
áá 
appointments
áá 
=
áá 
JsonConvert
áá *
.
áá* +
DeserializeObject
áá+ <
<
áá< =
List
áá= A
<
ááA B
AppointmentModel
ááB R
>
ááR S
>
ááS T
(
ááT U
await
ááU Z
response
áá[ c
.
áác d
Content
áád k
.
áák l
ReadAsStringAsync
áál }
(
áá} ~
)
áá~ 
)áá Ä
;ááÄ Å"
AppointmentViewModel
àà  
appointment
àà! ,
=
àà- .
new
àà/ 2"
AppointmentViewModel
àà3 G
(
ààG H
)
ààH I
;
ààI J
appointment
ââ 
.
ââ 
Appointments
ââ $
=
ââ% &
appointments
ââ' 3
;
ââ3 4
appointment
ää 
.
ää 
CustomerUsername
ää (
=
ää) *
id
ää+ -
;
ää- .
return
ãã 
View
ãã 
(
ãã 
$str
ãã -
,
ãã- .
appointment
ãã/ :
)
ãã: ;
;
ãã; <
}
åå 	
[
èè 	
HttpGet
èè	 
(
èè 
$str
èè #
)
èè# $
]
èè$ %
public
êê 
IActionResult
êê 
Home
êê !
(
êê! "
string
êê" (
username
êê) 1
)
êê1 2
{
ëë 	
var
íí 
CustomerViewModel
íí !
=
íí" #
new
íí$ '
	UserModel
íí( 1
(
íí1 2
)
íí2 3
;
íí3 4
CustomerViewModel
ìì 
.
ìì 
Username
ìì &
=
ìì' (
username
ìì) 1
;
ìì1 2
return
îî 
View
îî 
(
îî 
$str
îî "
,
îî" #
CustomerViewModel
îî$ 5
)
îî5 6
;
îî6 7
}
ïï 	
[
òò 	
HttpPost
òò	 
(
òò 
$str
òò 
)
òò 
]
òò 
public
ôô 
async
ôô 
Task
ôô 
<
ôô 
IActionResult
ôô '
>
ôô' ("
DisplayProfessionals
ôô) =
(
ôô= >
CustomerViewModel
ôô> O
model
ôôP U
)
ôôU V
{
öö 	
HttpClientHandler
ûû 
clientHandler
ûû +
=
ûû, -
new
ûû. 1
HttpClientHandler
ûû2 C
(
ûûC D
)
ûûD E
;
ûûE F
clientHandler
üü 
.
üü 7
)ServerCertificateCustomValidationCallback
üü C
=
üüD E
(
üüF G
sender
üüG M
,
üüM N
cert
üüO S
,
üüS T
chain
üüU Z
,
üüZ [
sslPolicyErrors
üü\ k
)
üük l
=>
üüm o
{
üüp q
return
üür x
true
üüy }
;
üü} ~
}üü Ä
;üüÄ Å

HttpClient
°° 
client
°° 
=
°° 
new
°°  #

HttpClient
°°$ .
(
°°. /
clientHandler
°°/ <
)
°°< =
;
°°= >
var
§§ 
response
§§ 
=
§§ 
await
§§  
client
§§! '
.
§§' (
GetAsync
§§( 0
(
§§0 1
apiUrl
§§1 7
+
§§7 8'
apiProfessionalController
§§8 Q
+
§§Q R
$str
§§R l
+
§§l m
model
§§m r
.
§§r s
SearchParam
§§s ~
+
§§~ 
$str§§ Ç
+§§Ç É
model§§É à
.§§à â'
ProfessionalSearchValue§§â †
)§§† °
;§§° ¢
model
•• 
.
•• !
ListOfProfessionals
•• %
=
••& '
JsonConvert
••( 3
.
••3 4
DeserializeObject
••4 E
<
••E F
IEnumerable
••F Q
<
••Q R
ProfessionalModel
••R c
>
••c d
>
••d e
(
••e f
await
••f k
response
••l t
.
••t u
Content
••u |
.
••| } 
ReadAsStringAsync••} é
(••é è
)••è ê
)••ê ë
;••ë í
return
¶¶ 
View
¶¶ 
(
¶¶ 
$str
¶¶ .
,
¶¶. /
model
¶¶0 5
)
¶¶5 6
;
¶¶6 7
}
ßß 	
[
™™ 	
HttpPost
™™	 
(
™™ 
$str
™™ #
)
™™# $
]
™™$ %
public
´´ 
async
´´ 
Task
´´ 
<
´´ 
IActionResult
´´ '
>
´´' (
SetAppointment
´´) 7
(
´´7 8"
AppointmentViewModel
´´8 L
model
´´M R
)
´´R S
{
¨¨ 	
Console
ÆÆ 
.
ÆÆ 
	WriteLine
ÆÆ 
(
ÆÆ 
$str
ÆÆ 2
+
ÆÆ2 3
model
ÆÆ3 8
.
ÆÆ8 9
CustomerUsername
ÆÆ9 I
)
ÆÆI J
;
ÆÆJ K
HttpClientHandler
∞∞ '
professionalclientHandler
∞∞ 7
=
∞∞8 9
new
∞∞: =
HttpClientHandler
∞∞> O
(
∞∞O P
)
∞∞P Q
;
∞∞Q R'
professionalclientHandler
±± %
.
±±% &7
)ServerCertificateCustomValidationCallback
±±& O
=
±±P Q
(
±±R S
sender
±±S Y
,
±±Y Z
cert
±±[ _
,
±±_ `
chain
±±a f
,
±±f g
sslPolicyErrors
±±h w
)
±±w x
=>
±±y {
{
±±| }
return±±~ Ñ
true±±Ö â
;±±â ä
}±±ã å
;±±å ç

HttpClient
≤≤  
professionalclient
≤≤ )
=
≤≤* +
new
≤≤, /

HttpClient
≤≤0 :
(
≤≤: ;'
professionalclientHandler
≤≤; T
)
≤≤T U
;
≤≤U V
var
≥≥ "
professionalresponse
≥≥ $
=
≥≥% &
await
≥≥' , 
professionalclient
≥≥- ?
.
≥≥? @
GetAsync
≥≥@ H
(
≥≥H I
apiUrl
≥≥I O
+
≥≥O P'
apiProfessionalController
≥≥P i
+
≥≥i j
$str
≥≥j ~
+
≥≥~ 
model≥≥ Ñ
.≥≥Ñ Ö$
ProfessionalUsername≥≥Ö ô
)≥≥ô ö
;≥≥ö õ
ProfessionalModel
¥¥ 
professional
¥¥ *
=
¥¥+ ,
JsonConvert
¥¥- 8
.
¥¥8 9
DeserializeObject
¥¥9 J
<
¥¥J K
ProfessionalModel
¥¥K \
>
¥¥\ ]
(
¥¥] ^
await
¥¥^ c"
professionalresponse
¥¥d x
.
¥¥x y
Content¥¥y Ä
.¥¥Ä Å!
ReadAsStringAsync¥¥Å í
(¥¥í ì
)¥¥ì î
)¥¥î ï
;¥¥ï ñ
AppointmentModel
∂∂ 
appointment
∂∂ (
=
∂∂) *
new
∂∂+ .
AppointmentModel
∂∂/ ?
(
∂∂? @
)
∂∂@ A
;
∂∂A B
string
∏∏ 
format
∏∏ 
=
∏∏ 
$str
∏∏ 0
;
∏∏0 1
CultureInfo
ππ 
provider
ππ  
=
ππ! "
CultureInfo
ππ# .
.
ππ. /
InvariantCulture
ππ/ ?
;
ππ? @
try
∫∫ 
{
ªª 
DateTime
ºº 
	startTime
ºº "
=
ºº# $
DateTime
ºº% -
.
ºº- .

ParseExact
ºº. 8
(
ºº8 9
model
ºº9 >
.
ºº> ?
	StartTime
ºº? H
.
ººH I
Trim
ººI M
(
ººM N
)
ººN O
,
ººO P
format
ººQ W
,
ººW X
provider
ººY a
)
ººa b
;
ººb c
appointment
ΩΩ 
.
ΩΩ 
Time
ΩΩ  
=
ΩΩ! "
new
ΩΩ# &
	TimeModel
ΩΩ' 0
(
ΩΩ0 1
)
ΩΩ1 2
;
ΩΩ2 3
appointment
ææ 
.
ææ 
Time
ææ  
.
ææ  !
Start
ææ! &
=
ææ' (
	startTime
ææ) 2
;
ææ2 3
appointment
øø 
.
øø 
Time
øø  
.
øø  !
End
øø! $
=
øø% &
	startTime
øø' 0
.
øø0 1
AddHours
øø1 9
(
øø9 :
professional
øø: F
.
øøF G&
AppointmentLengthInHours
øøG _
)
øø_ `
;
øø` a
}
¿¿ 
catch
¡¡ 
(
¡¡ 
FormatException
¡¡ "
)
¡¡" #
{
¬¬ 
}
√√ 
appointment
≈≈ 
.
≈≈ 

IsFufilled
≈≈ "
=
≈≈# $
false
≈≈% *
;
≈≈* +
appointment
∆∆ 
.
∆∆ 
Professional
∆∆ $
=
∆∆$ %
professional
∆∆& 2
;
∆∆2 3
appointment
«« 
.
«« 
EntityID
««  
=
««  !
DateTime
««" *
.
««* +
Now
««+ .
.
««. /
Ticks
««/ 4
;
««4 5
var
ÀÀ 
json
ÀÀ 
=
ÀÀ 
JsonConvert
ÀÀ "
.
ÀÀ" #
SerializeObject
ÀÀ# 2
(
ÀÀ2 3
appointment
ÀÀ3 >
.
ÀÀ> ?
Time
ÀÀ? C
)
ÀÀC D
;
ÀÀD E
StringContent
ÃÃ 
content
ÃÃ !
=
ÃÃ" #
new
ÃÃ$ '
StringContent
ÃÃ( 5
(
ÃÃ5 6
json
ÃÃ6 :
.
ÃÃ: ;
ToString
ÃÃ; C
(
ÃÃC D
)
ÃÃD E
)
ÃÃE F
;
ÃÃF G
HttpClientHandler
ŒŒ 
clientHandler
ŒŒ +
=
ŒŒ, -
new
ŒŒ. 1
HttpClientHandler
ŒŒ2 C
(
ŒŒC D
)
ŒŒD E
;
ŒŒE F
clientHandler
œœ 
.
œœ 7
)ServerCertificateCustomValidationCallback
œœ C
=
œœD E
(
œœF G
sender
œœG M
,
œœM N
cert
œœO S
,
œœS T
chain
œœU Z
,
œœZ [
sslPolicyErrors
œœ\ k
)
œœk l
=>
œœm o
{
œœp q
return
œœr x
true
œœy }
;
œœ} ~
}œœ Ä
;œœÄ Å

HttpClient
““ 
client
““ 
=
““ 
new
““  #

HttpClient
““$ .
(
““. /
clientHandler
““/ <
)
““< =
;
““= >
var
’’ 
response
’’ 
=
’’ 
await
’’  
client
’’! '
.
’’' (
	PostAsync
’’( 1
(
’’1 2
apiUrl
’’2 8
+
’’8 9
$str
’’9 F
+
’’F G
$str
’’G O
+
’’O P
model
’’P U
.
’’U V
CustomerUsername
’’V f
+
’’f g
$str
’’g j
+
’’j k
model
’’k p
.
’’p q#
ProfessionalUsername’’q Ö
,’’Ö Ü
content’’á é
)’’é è
;’’è ê
CustomerViewModel
◊◊ 
customerView
◊◊ *
=
◊◊+ ,
new
◊◊- 0
CustomerViewModel
◊◊1 B
(
◊◊B C
)
◊◊C D
;
◊◊D E
customerView
ÿÿ 
.
ÿÿ 
Username
ÿÿ !
=
ÿÿ" #
model
ÿÿ$ )
.
ÿÿ) *
CustomerUsername
ÿÿ* :
;
ÿÿ: ;"
AppointmentViewModel
⁄⁄  
appointmentModel
⁄⁄! 1
=
⁄⁄1 2
new
⁄⁄3 6"
AppointmentViewModel
⁄⁄7 K
(
⁄⁄K L
)
⁄⁄L M
;
⁄⁄M N
appointmentModel
€€ 
.
€€ "
ProfessionalUsername
€€ 1
=
€€2 3
model
€€4 9
.
€€9 :"
ProfessionalUsername
€€: N
;
€€N O
appointmentModel
‹‹ 
.
‹‹ 
CustomerUsername
‹‹ -
=
‹‹. /
model
‹‹0 5
.
‹‹5 6
CustomerUsername
‹‹6 F
;
‹‹F G
return
‡‡ 
View
‡‡ 
(
‡‡ 
$str
‡‡ /
,
‡‡/ 0
appointmentModel
‡‡0 @
)
‡‡@ A
;
‡‡A B
}
·· 	
[
„„ 	
HttpGet
„„	 
(
„„ 
$str
„„ $
)
„„$ %
]
„„% &
public
‰‰ 
async
‰‰ 
Task
‰‰ 
<
‰‰ 
IActionResult
‰‰ '
>
‰‰' (
ViewProfessional
‰‰) 9
(
‰‰9 :
CustomerViewModel
‰‰: K
model
‰‰L Q
)
‰‰Q R
{
ÂÂ 	
HttpClientHandler
ÊÊ 
clientHandler
ÊÊ +
=
ÊÊ, -
new
ÊÊ. 1
HttpClientHandler
ÊÊ2 C
(
ÊÊC D
)
ÊÊD E
;
ÊÊE F
clientHandler
ÁÁ 
.
ÁÁ 7
)ServerCertificateCustomValidationCallback
ÁÁ C
=
ÁÁD E
(
ÁÁF G
sender
ÁÁG M
,
ÁÁM N
cert
ÁÁO S
,
ÁÁS T
chain
ÁÁU Z
,
ÁÁZ [
sslPolicyErrors
ÁÁ\ k
)
ÁÁk l
=>
ÁÁm o
{
ÁÁp q
return
ÁÁr x
true
ÁÁy }
;
ÁÁ} ~
}ÁÁ Ä
;ÁÁÄ Å

HttpClient
ËË 
client
ËË 
=
ËË 
new
ËË  #

HttpClient
ËË$ .
(
ËË. /
clientHandler
ËË/ <
)
ËË< =
;
ËË= >
var
ÈÈ 
response
ÈÈ 
=
ÈÈ 
await
ÈÈ  
client
ÈÈ! '
.
ÈÈ' (
GetAsync
ÈÈ( 0
(
ÈÈ0 1
apiUrl
ÈÈ1 7
+
ÈÈ7 8'
apiProfessionalController
ÈÈ8 Q
+
ÈÈQ R
$str
ÈÈR f
+
ÈÈf g
model
ÈÈg l
.
ÈÈl m,
SearchedProfessionalsUsernameÈÈm ä
)ÈÈä ã
;ÈÈã å
var
ÍÍ 
professional
ÍÍ 
=
ÍÍ 
JsonConvert
ÍÍ *
.
ÍÍ* +
DeserializeObject
ÍÍ+ <
<
ÍÍ< =
ProfessionalModel
ÍÍ= N
>
ÍÍN O
(
ÍÍO P
await
ÍÍP U
response
ÍÍV ^
.
ÍÍ^ _
Content
ÍÍ_ f
.
ÍÍf g
ReadAsStringAsync
ÍÍg x
(
ÍÍx y
)
ÍÍy z
)
ÍÍz {
;
ÍÍ{ |
model
ÎÎ 
.
ÎÎ 
Professional
ÎÎ 
=
ÎÎ  
professional
ÎÎ! -
;
ÎÎ- .
return
ÏÏ 
View
ÏÏ 
(
ÏÏ 
$str
ÏÏ .
,
ÏÏ. /
model
ÏÏ0 5
)
ÏÏ5 6
;
ÏÏ6 7
}
ÌÌ 	
[
ÔÔ 	
HttpGet
ÔÔ	 
(
ÔÔ 
$str
ÔÔ 6
)
ÔÔ6 7
]
ÔÔ7 8
public
 
IActionResult
 
CreateAppointment
 .
(
. /
CustomerViewModel
/ @
model
A F
)
F G
{
ÒÒ 	"
AppointmentViewModel
ÚÚ  
appointmentModel
ÚÚ! 1
=
ÚÚ1 2
new
ÚÚ3 6"
AppointmentViewModel
ÚÚ7 K
(
ÚÚK L
)
ÚÚL M
;
ÚÚM N
appointmentModel
ÛÛ 
.
ÛÛ "
ProfessionalUsername
ÛÛ 1
=
ÛÛ2 3
model
ÛÛ4 9
.
ÛÛ9 :+
SearchedProfessionalsUsername
ÛÛ: W
;
ÛÛW X
appointmentModel
ÙÙ 
.
ÙÙ 
CustomerUsername
ÙÙ -
=
ÙÙ. /
model
ÙÙ0 5
.
ÙÙ5 6
Username
ÙÙ6 >
;
ÙÙ> ?
appointmentModel
ıı 
.
ıı &
AppointmentLengthInHours
ıı 5
=
ıı6 7
model
ıı8 =
.
ıı= >&
AppointmentLengthInHours
ıı> V
;
ııV W
appointmentModel
ˆˆ 
.
ˆˆ 

HourlyRate
ˆˆ '
=
ˆˆ( )
model
ˆˆ* /
.
ˆˆ/ 0

HourlyRate
ˆˆ0 :
;
ˆˆ: ;
return
˜˜ 
View
˜˜ 
(
˜˜ 
$str
˜˜ +
,
˜˜+ ,
appointmentModel
˜˜- =
)
˜˜= >
;
˜˜> ?
}
¯¯ 	
[
˙˙	 

HttpGet
˙˙
 
(
˙˙ 
$str
˙˙ ,
)
˙˙, -
]
˙˙- .
public
˚˚	 
IActionResult
˚˚ %
AccountCreationCustomer
˚˚ 5
(
˚˚5 6
)
˚˚6 7
{
¸¸	 
&
AccountCreationViewModel
˛˛ %
accountModel
˛˛& 2
=
˛˛3 4
new
˛˛5 8&
AccountCreationViewModel
˛˛9 Q
(
˛˛Q R
)
˛˛R S
;
˛˛S T
return
ˇˇ 
View
ˇˇ 
(
ˇˇ 
$str
ˇˇ *
,
ˇˇ* +
accountModel
ˇˇ, 8
)
ˇˇ8 9
;
ˇˇ9 :
}
ÄÄ	 

[
ÇÇ	 

HttpGet
ÇÇ
 
(
ÇÇ 
$str
ÇÇ 0
)
ÇÇ0 1
]
ÇÇ1 2
public
ÉÉ	 
IActionResult
ÉÉ )
AccountCreationProfessional
ÉÉ 9
(
ÉÉ9 :
)
ÉÉ: ;
{
ÑÑ	 

ProfessionalModel
ÜÜ 
accountModel
ÜÜ +
=
ÜÜ, -
new
ÜÜ. 1
ProfessionalModel
ÜÜ2 C
(
ÜÜC D
)
ÜÜD E
;
ÜÜE F
return
áá 
View
áá 
(
áá 
$str
áá 6
,
áá6 7
accountModel
áá8 D
)
ááD E
;
ááE F
}
àà	 

[
ää	 

HttpPost
ää
 
(
ää 
$str
ää #
)
ää# $
]
ää$ %
public
ãã 
async
ãã 
Task
ãã 
<
ãã 
IActionResult
ãã '
>
ãã' (
CreateAccount
ãã) 6
(
ãã6 7&
AccountCreationViewModel
ãã7 O
model
ããP U
)
ããU V
{
åå 	
CustomerModel
çç 
customer
çç "
=
çç# $
new
çç% (
CustomerModel
çç) 6
(
çç6 7
)
çç7 8
{
çç8 9
Username
çç9 A
=
ççB C
model
ççD I
.
ççI J
username
ççJ R
,
ççR S
Password
ççT \
=
çç] ^
model
çç_ d
.
ççd e
password
ççe m
,
ççm n
	FirstName
ççn w
=
ççx y
model
ççz 
.çç Ä
	firstnameççÄ â
,ççâ ä
LastNameççä í
=ççì î
modelççï ö
.ççö õ
lastnameççõ £
,çç£ §
Genderçç§ ™
=çç´ ¨
modelçç≠ ≤
.çç≤ ≥
genderçç≥ π
,ççπ ∫
PhoneNumberçç∫ ≈
=çç∆ «
modelçç» Õ
.ççÕ Œ
phonenumberççŒ Ÿ
,ççŸ ⁄
EmailAddressçç⁄ Ê
=ççÁ Ë
modelççÈ Ó
.ççÓ Ô
emailaddressççÔ ˚
}çç˚ ¸
;çç¸ ˝
var
êê 
json
êê 
=
êê 
JsonConvert
êê "
.
êê" #
SerializeObject
êê# 2
(
êê2 3
model
êê3 8
)
êê8 9
;
êê9 :
StringContent
ëë 
content
ëë !
=
ëë" #
new
ëë$ '
StringContent
ëë( 5
(
ëë5 6
json
ëë6 :
.
ëë: ;
ToString
ëë; C
(
ëëC D
)
ëëD E
)
ëëE F
;
ëëF G
HttpClientHandler
îî 
clientHandler
îî +
=
îî, -
new
îî. 1
HttpClientHandler
îî2 C
(
îîC D
)
îîD E
;
îîE F
clientHandler
ïï 
.
ïï 7
)ServerCertificateCustomValidationCallback
ïï C
=
ïïD E
(
ïïF G
sender
ïïG M
,
ïïM N
cert
ïïO S
,
ïïS T
chain
ïïU Z
,
ïïZ [
sslPolicyErrors
ïï\ k
)
ïïk l
=>
ïïm o
{
ïïp q
return
ïïr x
true
ïïy }
;
ïï} ~
}ïï Ä
;ïïÄ Å

HttpClient
òò 
client
òò 
=
òò 
new
òò  #

HttpClient
òò$ .
(
òò. /
clientHandler
òò/ <
)
òò< =
;
òò= >
var
õõ 
response
õõ 
=
õõ 
await
õõ  
client
õõ! '
.
õõ' (
	PostAsync
õõ( 1
(
õõ1 2
apiUrl
õõ2 8
+
õõ8 9
loginController
õõ9 H
+
õõH I
$str
õõI _
,
õõ_ `
content
õõa h
)
õõh i
;
õõi j
LoginViewModel
ùù 
	modelForm
ùù $
=
ùù% &
new
ùù' *
LoginViewModel
ùù+ 9
(
ùù9 :
)
ùù: ;
;
ùù; <
if
üü 
(
üü 
response
üü 
.
üü !
IsSuccessStatusCode
üü +
)
üü+ ,
{
†† 
return
°° 
View
°° 
(
°° 
$str
°° '
,
°°' (
	modelForm
°°) 2
)
°°3 4
;
°°4 5
}
¢¢ 
	modelForm
§§ 
.
§§ 
Error
§§ 
=
§§ 
$str
§§ 9
;
§§9 :
return
•• 
View
•• 
(
•• 
$str
•• #
,
••# $
	modelForm
••% .
)
••. /
;
••/ 0
}
¶¶ 	
[
®® 	
HttpPost
®®	 
(
®® 
$str
®® .
)
®®. /
]
®®/ 0
public
©© 
async
©© 
Task
©© 
<
©© 
IActionResult
©© '
>
©©' ('
CreateAccountProfessional
©©) B
(
©©B C
ProfessionalModel
©©C T
model
©©U Z
)
©©Z [
{
™™ 	
model
≠≠ 
.
≠≠ 
MemberSince
≠≠ 
=
≠≠ 
DateTime
≠≠  (
.
≠≠( )
Now
≠≠) ,
;
≠≠, -
model
ÆÆ 
.
ÆÆ 
Rating
ÆÆ 
=
ÆÆ 
$num
ÆÆ 
;
ÆÆ 
var
ØØ 
json
ØØ 
=
ØØ 
JsonConvert
ØØ "
.
ØØ" #
SerializeObject
ØØ# 2
(
ØØ2 3
model
ØØ3 8
)
ØØ8 9
;
ØØ9 :
StringContent
∞∞ 
content
∞∞ !
=
∞∞" #
new
∞∞$ '
StringContent
∞∞( 5
(
∞∞5 6
json
∞∞6 :
.
∞∞: ;
ToString
∞∞; C
(
∞∞C D
)
∞∞D E
)
∞∞E F
;
∞∞F G
HttpClientHandler
≥≥ 
clientHandler
≥≥ +
=
≥≥, -
new
≥≥. 1
HttpClientHandler
≥≥2 C
(
≥≥C D
)
≥≥D E
;
≥≥E F
clientHandler
¥¥ 
.
¥¥ 7
)ServerCertificateCustomValidationCallback
¥¥ C
=
¥¥D E
(
¥¥F G
sender
¥¥G M
,
¥¥M N
cert
¥¥O S
,
¥¥S T
chain
¥¥U Z
,
¥¥Z [
sslPolicyErrors
¥¥\ k
)
¥¥k l
=>
¥¥m o
{
¥¥p q
return
¥¥r x
true
¥¥y }
;
¥¥} ~
}¥¥ Ä
;¥¥Ä Å

HttpClient
∑∑ 
client
∑∑ 
=
∑∑ 
new
∑∑  #

HttpClient
∑∑$ .
(
∑∑. /
clientHandler
∑∑/ <
)
∑∑< =
;
∑∑= >
var
∫∫ 
response
∫∫ 
=
∫∫ 
await
∫∫  
client
∫∫! '
.
∫∫' (
	PostAsync
∫∫( 1
(
∫∫1 2
apiUrl
∫∫2 8
+
∫∫8 9
loginController
∫∫9 H
+
∫∫H I
$str
∫∫I e
,
∫∫e f
content
∫∫g n
)
∫∫n o
;
∫∫o p
LoginViewModel
¬¬ 
	modelForm
¬¬ $
=
¬¬% &
new
¬¬' *
LoginViewModel
¬¬+ 9
(
¬¬9 :
)
¬¬: ;
;
¬¬; <
if
ƒƒ 
(
ƒƒ 
response
ƒƒ 
.
ƒƒ !
IsSuccessStatusCode
ƒƒ +
)
ƒƒ+ ,
{
≈≈ 
return
∆∆ 
View
∆∆ 
(
∆∆ 
$str
∆∆ '
,
∆∆' (
	modelForm
∆∆) 2
)
∆∆3 4
;
∆∆4 5
}
«« 
	modelForm
…… 
.
…… 
Error
…… 
=
…… 
$str
…… 9
;
……9 :
return
   
View
   
(
   
$str
   #
,
  # $
	modelForm
  % .
)
  . /
;
  / 0
}
ÀÀ 	
}
ÕÕ 
}ŒŒ •
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
}%% ≠ª
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
}	 Ä
;
Ä Å

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
}	++ Ä
;
++Ä Å

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
}	:: Ä
;
::Ä Å

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
)	== Ä
;
==Ä Å 
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
}	YY Ä
;
YYÄ Å

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
}	dd Ä
;
ddÄ Å

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
)	gg Ä
;
ggÄ Å 
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
}	rr Ä
;
rrÄ Å

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
)	uu Ä
;
uuÄ Å 
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
ÄÄ 
clientHandler
ÄÄ +
=
ÄÄ, -
new
ÄÄ. 1
HttpClientHandler
ÄÄ2 C
(
ÄÄC D
)
ÄÄD E
;
ÄÄE F
clientHandler
ÅÅ 
.
ÅÅ 7
)ServerCertificateCustomValidationCallback
ÅÅ C
=
ÅÅD E
(
ÅÅF G
sender
ÅÅG M
,
ÅÅM N
cert
ÅÅO S
,
ÅÅS T
chain
ÅÅU Z
,
ÅÅZ [
sslPolicyErrors
ÅÅ\ k
)
ÅÅk l
=>
ÅÅm o
{
ÅÅp q
return
ÅÅr x
true
ÅÅy }
;
ÅÅ} ~
}ÅÅ Ä
;ÅÅÄ Å

HttpClient
ÇÇ 
client
ÇÇ 
=
ÇÇ 
new
ÇÇ  #

HttpClient
ÇÇ$ .
(
ÇÇ. /
clientHandler
ÇÇ/ <
)
ÇÇ< =
;
ÇÇ= >
var
ÉÉ 
response
ÉÉ 
=
ÉÉ 
await
ÉÉ  
client
ÉÉ! '
.
ÉÉ' (
GetAsync
ÉÉ( 0
(
ÉÉ0 1
apiUrl
ÉÉ1 7
+
ÉÉ7 8&
apiAppointmentController
ÉÉ8 P
+
ÉÉP Q
$str
ÉÉQ h
+
ÉÉh i
model
ÉÉi n
.
ÉÉn o
AppointmentID
ÉÉo |
)
ÉÉ| }
;
ÉÉ} ~
HttpClientHandler
ÑÑ 
clientHandler2
ÑÑ ,
=
ÑÑ- .
new
ÑÑ/ 2
HttpClientHandler
ÑÑ3 D
(
ÑÑD E
)
ÑÑE F
;
ÑÑF G
clientHandler2
ÖÖ 
.
ÖÖ 7
)ServerCertificateCustomValidationCallback
ÖÖ D
=
ÖÖE F
(
ÖÖG H
sender
ÖÖH N
,
ÖÖN O
cert
ÖÖP T
,
ÖÖT U
chain
ÖÖV [
,
ÖÖ[ \
sslPolicyErrors
ÖÖ] l
)
ÖÖl m
=>
ÖÖn p
{
ÖÖq r
return
ÖÖs y
true
ÖÖz ~
;
ÖÖ~ 
}ÖÖÄ Å
;ÖÖÅ Ç

HttpClient
ÜÜ 
client2
ÜÜ 
=
ÜÜ  
new
ÜÜ! $

HttpClient
ÜÜ% /
(
ÜÜ/ 0
clientHandler2
ÜÜ0 >
)
ÜÜ> ?
;
ÜÜ? @
var
áá 
	response2
áá 
=
áá 
await
áá !
client2
áá" )
.
áá) *
GetAsync
áá* 2
(
áá2 3
apiUrl
áá3 9
+
áá9 :'
apiProfessionalController
áá: S
+
ááS T
$str
ááT l
+
áál m
model
áám r
.
áár s#
ProfessionalUsernameáás á
)ááá à
;ááà â
	UserModel
àà 
user
àà 
=
àà 
JsonConvert
àà (
.
àà( )
DeserializeObject
àà) :
<
àà: ;
	UserModel
àà; D
>
ààD E
(
ààE F
await
ààF K
	response2
ààL U
.
ààU V
Content
ààV ]
.
àà] ^
ReadAsStringAsync
àà^ o
(
àào p
)
ààp q
)
ààq r
;
ààr s
return
ää 
View
ää 
(
ää 
$str
ää *
,
ää* +
user
ää, 0
)
ää0 1
;
ää1 2
}
ãã 	
[
åå 	
Route
åå	 
(
åå 
$str
åå 
)
åå 
]
åå 
[
çç 	
HttpPost
çç	 
]
çç 
public
éé 
async
éé 
Task
éé 
<
éé 
IActionResult
éé '
>
éé' (
AcceptAppointment
éé) :
(
éé: ;"
AppointmentViewModel
éé; O
model
ééP U
)
ééU V
{
èè 	
HttpClientHandler
êê 
clientHandler
êê +
=
êê, -
new
êê. 1
HttpClientHandler
êê2 C
(
êêC D
)
êêD E
;
êêE F
clientHandler
ëë 
.
ëë 7
)ServerCertificateCustomValidationCallback
ëë C
=
ëëD E
(
ëëF G
sender
ëëG M
,
ëëM N
cert
ëëO S
,
ëëS T
chain
ëëU Z
,
ëëZ [
sslPolicyErrors
ëë\ k
)
ëëk l
=>
ëëm o
{
ëëp q
return
ëër x
true
ëëy }
;
ëë} ~
}ëë Ä
;ëëÄ Å

HttpClient
íí 
client
íí 
=
íí 
new
íí  #

HttpClient
íí$ .
(
íí. /
clientHandler
íí/ <
)
íí< =
;
íí= >
var
ìì 
response
ìì 
=
ìì 
await
ìì  
client
ìì! '
.
ìì' (
GetAsync
ìì( 0
(
ìì0 1
apiUrl
ìì1 7
+
ìì7 8&
apiAppointmentController
ìì8 P
+
ììP Q
$str
ììQ f
+
ììf g
model
ììg l
.
ììl m
AppointmentID
ììm z
)
ììz {
;
ìì{ |
HttpClientHandler
îî 
clientHandler2
îî ,
=
îî- .
new
îî/ 2
HttpClientHandler
îî3 D
(
îîD E
)
îîE F
;
îîF G
clientHandler2
ïï 
.
ïï 7
)ServerCertificateCustomValidationCallback
ïï D
=
ïïE F
(
ïïG H
sender
ïïH N
,
ïïN O
cert
ïïP T
,
ïïT U
chain
ïïV [
,
ïï[ \
sslPolicyErrors
ïï] l
)
ïïl m
=>
ïïn p
{
ïïq r
return
ïïs y
true
ïïz ~
;
ïï~ 
}ïïÄ Å
;ïïÅ Ç

HttpClient
ññ 
client2
ññ 
=
ññ  
new
ññ! $

HttpClient
ññ% /
(
ññ/ 0
clientHandler2
ññ0 >
)
ññ> ?
;
ññ? @
var
óó 
	response2
óó 
=
óó 
await
óó !
client2
óó" )
.
óó) *
GetAsync
óó* 2
(
óó2 3
apiUrl
óó3 9
+
óó9 :'
apiProfessionalController
óó: S
+
óóS T
$str
óóT l
+
óól m
model
óóm r
.
óór s#
ProfessionalUsernameóós á
)óóá à
;óóà â
	UserModel
òò 
user
òò 
=
òò 
JsonConvert
òò (
.
òò( )
DeserializeObject
òò) :
<
òò: ;
	UserModel
òò; D
>
òòD E
(
òòE F
await
òòF K
	response2
òòL U
.
òòU V
Content
òòV ]
.
òò] ^
ReadAsStringAsync
òò^ o
(
òòo p
)
òòp q
)
òòq r
;
òòr s
return
ôô 
View
ôô 
(
ôô 
$str
ôô *
,
ôô* +
user
ôô, 0
)
ôô0 1
;
ôô1 2
}
öö 	
}
õõ 
}úú ∞
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
} ô	
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
} ¨
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
} ˆ
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
}		 —
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
} Ê
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
 —
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
} …
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
} Ï
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
} µ
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
} §
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
 –
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
}		 Õ
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
} œ

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
} ö
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