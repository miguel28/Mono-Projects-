// Type: SysProgUSB.PIC32MXFunctions
// Assembly: Master-Prog
// Assembly location: F:\MASTER-PROG\Master-Prog+.exe

using System;
using System.Threading;

namespace SysProgUSB
{
	public class PIC32MXFunctions
	{
		private static uint[] pe_Loader = new uint[42]
		{
			15367U,
			57005U,
			15366U,
			65312U,
			15365U,
			65312U,
			36036U,
			0U,
			36035U,
			0U,
			4199U,
			11U,
			0U,
			0U,
			4192U,
			65531U,
			0U,
			0U,
			36002U,
			0U,
			9315U,
			(uint) ushort.MaxValue,
			44162U,
			0U,
			9348U,
			4U,
			5216U,
			65531U,
			0U,
			0U,
			4096U,
			65523U,
			0U,
			0U,
			15362U,
			40960U,
			13378U,
			2304U,
			64U,
			8U,
			0U,
			0U
		};
		private static uint[] PIC32_PE = new uint[1200]
		{
			1008508928U,
			664567792U,
			1008574464U,
			935135484U,
			1007198208U,
			621285404U,
			16777224U,
			0U,
			1007075208U,
			2429051232U,
			1007009672U,
			889651264U,
			2697421152U,
			2426691904U,
			604176319U,
			8525860U,
			2695061824U,
			65011720U,
			0U,
			1007075208U,
			2429051232U,
			604372927U,
			17119268U,
			2697421152U,
			1006878600U,
			2422497600U,
			8720420U,
			2690801984U,
			65011720U,
			0U,
			1007075208U,
			2429051233U,
			1007009672U,
			889651201U,
			2697421153U,
			2426691905U,
			604176382U,
			8525860U,
			2695061825U,
			65011720U,
			0U,
			1007075208U,
			2429051233U,
			604372990U,
			17119268U,
			2697421153U,
			1006878600U,
			2422497601U,
			8720420U,
			2690801985U,
			65011720U,
			0U,
			338050U,
			278921243U,
			14369U,
			1007034304U,
			1006878656U,
			1006796799U,
			885600252U,
			879243260U,
			877395967U,
			268435462U,
			604700671U,
			2358837248U,
			388694030U,
			0U,
			281018382U,
			612630532U,
			9027622U,
			8943654U,
			789381121U,
			770572289U,
			619118593U,
			28205093U,
			360775668U,
			15020075U,
			2357329920U,
			273350644U,
			0U,
			65011720U,
			604110849U,
			65011720U,
			4129U,
			1006960416U,
			2357395456U,
			744620034U,
			272629763U,
			604241921U,
			2944630804U,
			8225U,
			65011720U,
			8392737U,
			278921223U,
			1006829344U,
			876806156U,
			2357592064U,
			614858751U,
			2892365824U,
			346095612U,
			612630532U,
			65011720U,
			0U,
			134218978U,
			0U,
			666763216U,
			2947874852U,
			2947809312U,
			2947678232U,
			2948530220U,
			2947940392U,
			2947743772U,
			2947612692U,
			2947547152U,
			10526753U,
			8425505U,
			278921252U,
			1008074528U,
			1006772223U,
			878116863U,
			713228417U,
			605225088U,
			42178571U,
			1255466U,
			278921224U,
			1007067136U,
			616825360U,
			39852065U,
			2393309184U,
			610533375U,
			2894528512U,
			341901308U,
			612630532U,
			604242048U,
			1382285341U,
			1007001600U,
			278921229U,
			34849U,
			1007263744U,
			623903248U,
			2382692352U,
			37756961U,
			201327842U,
			640745473U,
			638582788U,
			36902954U,
			339738631U,
			642908164U,
			1415643128U,
			2382692352U,
			43229219U,
			377552865U,
			713228417U,
			4129U,
			2411659308U,
			2411069480U,
			2411003940U,
			2410938400U,
			2410872860U,
			2410807320U,
			2410741780U,
			2410676240U,
			65011720U,
			666697776U,
			614662672U,
			73400323U,
			46344228U,
			1007173632U,
			6826017U,
			201327850U,
			37756961U,
			339804142U,
			43229219U,
			377552842U,
			642908672U,
			268500970U,
			4129U,
			1006804992U,
			608633360U,
			1007091488U,
			14690337U,
			604176511U,
			2361917440U,
			610533375U,
			2896691200U,
			73531388U,
			614793220U,
			1007042560U,
			14686241U,
			81854468U,
			15083553U,
			1006968831U,
			883425279U,
			6760484U,
			134218986U,
			0U,
			666763232U,
			2947678232U,
			2947612692U,
			2947547152U,
			2948530204U,
			10522657U,
			8421409U,
			346030087U,
			34849U,
			2411659292U,
			2410807320U,
			2410741780U,
			2410676240U,
			65011720U,
			666697760U,
			33562657U,
			201327858U,
			640745473U,
			638586880U,
			272695285U,
			36837419U,
			341901306U,
			33562657U,
			2411659292U,
			2410807320U,
			2410741780U,
			2410676240U,
			65011720U,
			666697760U,
			134219000U,
			0U,
			666763192U,
			1007091713U,
			604770048U,
			2948464704U,
			2947612708U,
			10547233U,
			363522U,
			1007533960U,
			1007402888U,
			873104591U,
			1007271816U,
			887230497U,
			1006878600U,
			604307457U,
			2913742900U,
			2948005948U,
			2909548600U,
			2947547168U,
			2905223232U,
			2948530244U,
			2947940408U,
			2947874868U,
			2947809328U,
			2947743788U,
			2947678248U,
			2892116048U,
			2944761876U,
			12630049U,
			2745171992U,
			2745171993U,
			438304790U,
			8421409U,
			1006911487U,
			882311167U,
			1008050176U,
			1007992832U,
			605224963U,
			1007812609U,
			47202347U,
			34943013U,
			34875425U,
			13117450U,
			48242721U,
			1007026177U,
			604438530U,
			201327972U,
			2947743760U,
			4210721U,
			640811007U,
			339738667U,
			34766881U,
			1579220979U,
			47202347U,
			868679679U,
			281018382U,
			1007828991U,
			911343615U,
			1007656960U,
			36728875U,
			297795587U,
			34547749U,
			1007927296U,
			34809889U,
			48242721U,
			604438530U,
			605028355U,
			201327972U,
			2947547152U,
			4210721U,
			285212686U,
			604176385U,
			2411659332U,
			2411593792U,
			2411135036U,
			2411069496U,
			2411003956U,
			2410938416U,
			2410872876U,
			2410807336U,
			2410741796U,
			2410676256U,
			6295585U,
			65011720U,
			666697800U,
			48242721U,
			665124888U,
			604372994U,
			604438530U,
			605290499U,
			201327972U,
			2947809296U,
			272695275U,
			6177U,
			604176385U,
			2411659332U,
			2411593792U,
			2411135036U,
			2411069496U,
			2411003956U,
			2410938416U,
			2410872876U,
			2410807336U,
			2410741796U,
			2410676256U,
			6295585U,
			65011720U,
			666697800U,
			666763208U,
			2948005932U,
			2947874852U,
			2947743772U,
			2947678232U,
			2947612692U,
			2947547152U,
			2948530228U,
			2948464688U,
			2947940392U,
			2947809312U,
			10520609U,
			8425505U,
			43041U,
			605487105U,
			1007746848U,
			278921273U,
			38945U,
			1006804992U,
			1006837759U,
			609616400U,
			880738303U,
			46145569U,
			604176511U,
			2382692352U,
			610533375U,
			2894397440U,
			73531388U,
			612630532U,
			316670022U,
			0U,
			47137U,
			642055680U,
			9803787U,
			1449132041U,
			640810880U,
			1007173632U,
			64368676U,
			18229281U,
			717684736U,
			13051915U,
			201327866U,
			37756961U,
			640810880U,
			707330176U,
			354418714U,
			642908672U,
			1007394816U,
			627710856U,
			2371092480U,
			604176511U,
			41951265U,
			2383151104U,
			610533375U,
			2894856192U,
			73531388U,
			612630532U,
			201327886U,
			0U,
			642645504U,
			27432971U,
			375390216U,
			4237345U,
			1008222208U,
			714014720U,
			64253988U,
			51652641U,
			30353419U,
			201327866U,
			37756961U,
			640810880U,
			642908672U,
			371261390U,
			46145569U,
			201327886U,
			1286187U,
			165931U,
			36995109U,
			301989913U,
			1008205600U,
			1008140064U,
			918814732U,
			605356034U,
			2895446016U,
			1382023202U,
			643038720U,
			2895314944U,
			2411659316U,
			2411593776U,
			2411135020U,
			2411069480U,
			2411003940U,
			2410938400U,
			2410872860U,
			2410807320U,
			2410741780U,
			2410676240U,
			4129U,
			65011720U,
			666697784U,
			201327886U,
			0U,
			268500921U,
			4237345U,
			921829388U,
			2923429888U,
			2411659316U,
			2411593776U,
			2411135020U,
			2411069480U,
			2411003940U,
			2410938400U,
			2410872860U,
			2410807320U,
			2410741780U,
			2410676240U,
			4129U,
			65011720U,
			666697784U,
			2895314944U,
			268500959U,
			2411659316U,
			666763200U,
			1007009664U,
			2947547184U,
			2948530232U,
			2947612724U,
			883225120U,
			2357395456U,
			604110930U,
			2087729920U,
			302120976U,
			772145235U,
			281018376U,
			604569716U,
			604438580U,
			302448651U,
			772276277U,
			1358954584U,
			604110904U,
			268435542U,
			604110866U,
			302579717U,
			772407413U,
			1363148882U,
			604110968U,
			268435536U,
			604110957U,
			604700673U,
			2945155092U,
			201327926U,
			872742911U,
			1007460352U,
			840040447U,
			630201228U,
			1008271136U,
			2400124928U,
			604897281U,
			996354U,
			837156863U,
			751632396U,
			2945351696U,
			2946891792U,
			2946826260U,
			295698447U,
			604438531U,
			397440U,
			5306401U,
			2415460352U,
			52428808U,
			0U,
			1007025952U,
			2359558144U,
			2946760728U,
			2359492608U,
			6301729U,
			201327270U,
			2946695196U,
			2410020880U,
			4208673U,
			604307463U,
			281346073U,
			604635146U,
			281673759U,
			604962818U,
			282066913U,
			398336U,
			876937218U,
			1006894880U,
			10948619U,
			879034380U,
			2896297984U,
			2409824272U,
			753139713U,
			947847169U,
			804847617U,
			52740132U,
			385875992U,
			946339848U,
			755433473U,
			14954532U,
			1354825682U,
			1008271136U,
			2409889832U,
			2896429056U,
			268500942U,
			1008271136U,
			820576255U,
			1007222791U,
			1007157024U,
			17375269U,
			887488524U,
			2898526208U,
			268500934U,
			1008271136U,
			1007550474U,
			1007550240U,
			36593701U,
			900399116U,
			2909536256U,
			268500927U,
			1008271136U,
			2409889816U,
			201327260U,
			2409955348U,
			268500922U,
			1008271136U,
			302186417U,
			604700673U,
			268500912U,
			2944434196U,
			201327251U,
			0U,
			2410020880U,
			268500937U,
			4208673U,
			268500935U,
			14369U,
			1008271136U,
			2399404032U,
			2946760728U,
			2400124928U,
			1011842U,
			29370401U,
			201327272U,
			2947416084U,
			2410020880U,
			268500924U,
			4208673U,
			2946498600U,
			1006829344U,
			2353266688U,
			665190440U,
			2946760728U,
			2353201152U,
			6301729U,
			201327394U,
			2946695188U,
			2410020880U,
			268500912U,
			4208673U,
			268500910U,
			604438790U,
			1008729888U,
			2414084096U,
			2946760728U,
			2415460352U,
			52439073U,
			201327220U,
			2948136980U,
			2410020880U,
			268500900U,
			4208673U,
			1007222560U,
			2366046208U,
			14688289U,
			201327363U,
			2946957336U,
			2410020880U,
			268500892U,
			4208673U,
			201327392U,
			0U,
			2410020880U,
			268500887U,
			4208673U,
			1007550240U,
			2376335360U,
			2946760728U,
			2376859648U,
			809090U,
			23078945U,
			201327501U,
			2947219476U,
			2410020880U,
			268500876U,
			4208673U,
			1007353632U,
			2370371584U,
			604438530U,
			604171U,
			268500870U,
			2947088408U,
			1006960416U,
			2357592064U,
			12591137U,
			201327344U,
			2946891800U,
			2410020880U,
			268500862U,
			4208673U,
			65011720U,
			4129U,
			881082368U,
			1007009665U,
			2896491520U,
			1007206272U,
			889779200U,
			1007266457U,
			891905621U,
			1007310182U,
			894081450U,
			1007353856U,
			896237568U,
			2903048208U,
			2903113744U,
			2903179272U,
			2359555072U,
			811761664U,
			339804157U,
			0U,
			0U,
			0U,
			0U,
			0U,
			604520448U,
			1007140737U,
			2900947972U,
			2359751680U,
			65011720U,
			818028544U,
			8400929U,
			1006813057U,
			1006878593U,
			604241921U,
			2890331168U,
			2892362800U,
			134218950U,
			0U,
			8400929U,
			1006813057U,
			1006878593U,
			604241923U,
			2890331168U,
			2892362816U,
			134218950U,
			0U,
			8394785U,
			1006813057U,
			604241924U,
			2890134560U,
			134218950U,
			0U,
			134218950U,
			604241934U,
			1007075201U,
			2898588704U,
			1006878593U,
			604258307U,
			1006813057U,
			2892362816U,
			2890200064U,
			1007206272U,
			889779200U,
			1007266457U,
			891905621U,
			1007310182U,
			894081450U,
			1007353856U,
			896237568U,
			2903048208U,
			2903113744U,
			2903179272U,
			65011720U,
			4129U,
			1006944129U,
			2357457920U,
			811761664U,
			339804157U,
			0U,
			0U,
			0U,
			0U,
			0U,
			604454912U,
			1007075201U,
			2898785284U,
			2357588992U,
			65011720U,
			815931392U,
			1006804992U,
			608764432U,
			16417U,
			532992U,
			813957119U,
			10273U,
			604372999U,
			352320U,
			10704934U,
			965152801U,
			2081117728U,
			88080386U,
			820379647U,
			830865407U,
			223296U,
			617021439U,
			79822838U,
			832831487U,
			621281281U,
			688062720U,
			2904883200U,
			341901293U,
			623443972U,
			65011720U,
			0U,
			666763240U,
			2948530192U,
			2810478620U,
			201327901U,
			2944434200U,
			2411659280U,
			604110849U,
			666697752U,
			65011720U,
			2944565272U,
			2542174236U,
			814416127U,
			2093758976U,
			23875622U,
			1007263744U,
			669824U,
			623378960U,
			15212577U,
			2357526528U,
			397824U,
			4528166U,
			65011720U,
			2810413084U,
			666763232U,
			2947612692U,
			2947547152U,
			2948530204U,
			2947678232U,
			8423457U,
			278921224U,
			615579647U,
			605224959U,
			2451832832U,
			638648319U,
			201327936U,
			640745473U,
			1444085756U,
			2451832832U,
			2411659292U,
			2410807320U,
			2410741780U,
			2410676240U,
			65011720U,
			666697760U,
			65011720U,
			2541912092U,
			604504256U,
			1894303746U,
			666763240U,
			2948530192U,
			1008705536U,
			2414418876U,
			1007468424U,
			604635264U,
			2911514676U,
			53035041U,
			2434269184U,
			14702625U,
			2131689920U,
			604569664U,
			604901376U,
			1007533960U,
			872644608U,
			1006813064U,
			770113537U,
			2903048216U,
			2913873924U,
			2890084360U,
			283115523U,
			0U,
			2903113736U,
			2903048216U,
			2433155072U,
			2095710656U,
			356581373U,
			2410217512U,
			604962872U,
			892862472U,
			604962815U,
			604831747U,
			2904031232U,
			1006813064U,
			2903441428U,
			895680704U,
			2903375908U,
			2911711284U,
			1007435776U,
			2890084408U,
			77660164U,
			11276321U,
			1008672767U,
			939130879U,
			12128292U,
			1007304704U,
			2902589488U,
			75563012U,
			9054241U,
			1006968831U,
			883425279U,
			8857636U,
			818151679U,
			2093758976U,
			2902786112U,
			12321U,
			2903244880U,
			604307458U,
			2902720608U,
			201328038U,
			23076897U,
			2411659280U,
			65011720U,
			666697752U,
			604569792U,
			1888040962U,
			1007329280U,
			2370313148U,
			604176512U,
			15212577U,
			604111103U,
			2894200868U,
			20513U,
			2894266376U,
			423979U,
			2894266392U,
			278921277U,
			0U,
			2425094144U,
			2106261696U,
			358613017U,
			604176385U,
			604831745U,
			279773207U,
			610861055U,
			2358116432U,
			297795586U,
			604504320U,
			2357723216U,
			2358771808U,
			318767106U,
			604438784U,
			2357657696U,
			2358837392U,
			320864260U,
			604176640U,
			2357395600U,
			268435458U,
			17254443U,
			17254443U,
			17381386U,
			14893089U,
			620953599U,
			4390939U,
			6291956U,
			6162U,
			610861055U,
			604897281U,
			604831748U,
			604766336U,
			604766207U,
			2357395488U,
			813170691U,
			2087256192U,
			318767110U,
			2087125184U,
			2086928384U,
			276824084U,
			604635138U,
			268435474U,
			604635137U,
			350224400U,
			0U,
			287309832U,
			0U,
			279838732U,
			0U,
			1358954506U,
			604635139U,
			621346815U,
			2894921764U,
			2894856216U,
			299958250U,
			0U,
			617021439U,
			348913639U,
			0U,
			604635141U,
			65011720U,
			20975649U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			0U,
			2684354576U,
			2684359408U,
			2684359384U,
			2684359340U,
			2684358880U,
			2684359320U,
			2684359288U,
			2684359248U,
			2684359240U,
			2684359192U,
			2684359148U,
			2684359140U,
			2684359120U,
			3213373536U
		};
		private const int pic32_PE_Version = 262;
		public static DelegateStatusWin UpdateStatusWinText;
		public static DelegateResetStatusBar ResetStatusBar;
		public static DelegateStepStatusBar StepStatusBar;

		static PIC32MXFunctions()
		{
		}

		public static void EnterSerialExecution()
		{
			int num1 = 0;
			byte[] commandList = new byte[29];
			byte[] numArray1 = commandList;
			int index1 = num1;
			int num2 = 1;
			int num3 = index1 + num2;
			int num4 = 166;
			numArray1[index1] = (byte) num4;
			byte[] numArray2 = commandList;
			int index2 = num3;
			int num5 = 1;
			int num6 = index2 + num5;
			int num7 = 27;
			numArray2[index2] = (byte) num7;
			byte[] numArray3 = commandList;
			int index3 = num6;
			int num8 = 1;
			int num9 = index3 + num8;
			int num10 = 187;
			numArray3[index3] = (byte) num10;
			byte[] numArray4 = commandList;
			int index4 = num9;
			int num11 = 1;
			int num12 = index4 + num11;
			int num13 = 4;
			numArray4[index4] = (byte) num13;
			byte[] numArray5 = commandList;
			int index5 = num12;
			int num14 = 1;
			int num15 = index5 + num14;
			int num16 = 187;
			numArray5[index5] = (byte) num16;
			byte[] numArray6 = commandList;
			int index6 = num15;
			int num17 = 1;
			int num18 = index6 + num17;
			int num19 = 7;
			numArray6[index6] = (byte) num19;
			byte[] numArray7 = commandList;
			int index7 = num18;
			int num20 = 1;
			int num21 = index7 + num20;
			int num22 = 186;
			numArray7[index7] = (byte) num22;
			byte[] numArray8 = commandList;
			int index8 = num21;
			int num23 = 1;
			int num24 = index8 + num23;
			int num25 = 0;
			numArray8[index8] = (byte) num25;
			byte[] numArray9 = commandList;
			int index9 = num24;
			int num26 = 1;
			int num27 = index9 + num26;
			int num28 = 187;
			numArray9[index9] = (byte) num28;
			byte[] numArray10 = commandList;
			int index10 = num27;
			int num29 = 1;
			int num30 = index10 + num29;
			int num31 = 4;
			numArray10[index10] = (byte) num31;
			byte[] numArray11 = commandList;
			int index11 = num30;
			int num32 = 1;
			int num33 = index11 + num32;
			int num34 = 187;
			numArray11[index11] = (byte) num34;
			byte[] numArray12 = commandList;
			int index12 = num33;
			int num35 = 1;
			int num36 = index12 + num35;
			int num37 = 7;
			numArray12[index12] = (byte) num37;
			byte[] numArray13 = commandList;
			int index13 = num36;
			int num38 = 1;
			int num39 = index13 + num38;
			int num40 = 186;
			numArray13[index13] = (byte) num40;
			byte[] numArray14 = commandList;
			int index14 = num39;
			int num41 = 1;
			int num42 = index14 + num41;
			int num43 = 209;
			numArray14[index14] = (byte) num43;
			byte[] numArray15 = commandList;
			int index15 = num42;
			int num44 = 1;
			int num45 = index15 + num44;
			int num46 = 187;
			numArray15[index15] = (byte) num46;
			byte[] numArray16 = commandList;
			int index16 = num45;
			int num47 = 1;
			int num48 = index16 + num47;
			int num49 = 5;
			numArray16[index16] = (byte) num49;
			byte[] numArray17 = commandList;
			int index17 = num48;
			int num50 = 1;
			int num51 = index17 + num50;
			int num52 = 188;
			numArray17[index17] = (byte) num52;
			byte[] numArray18 = commandList;
			int index18 = num51;
			int num53 = 1;
			int num54 = index18 + num53;
			int num55 = 6;
			numArray18[index18] = (byte) num55;
			byte[] numArray19 = commandList;
			int index19 = num54;
			int num56 = 1;
			int num57 = index19 + num56;
			int num58 = 31;
			numArray19[index19] = (byte) num58;
			byte[] numArray20 = commandList;
			int index20 = num57;
			int num59 = 1;
			int num60 = index20 + num59;
			int num61 = 187;
			numArray20[index20] = (byte) num61;
			byte[] numArray21 = commandList;
			int index21 = num60;
			int num62 = 1;
			int num63 = index21 + num62;
			int num64 = 12;
			numArray21[index21] = (byte) num64;
			byte[] numArray22 = commandList;
			int index22 = num63;
			int num65 = 1;
			int num66 = index22 + num65;
			int num67 = 187;
			numArray22[index22] = (byte) num67;
			byte[] numArray23 = commandList;
			int index23 = num66;
			int num68 = 1;
			int num69 = index23 + num68;
			int num70 = 4;
			numArray23[index23] = (byte) num70;
			byte[] numArray24 = commandList;
			int index24 = num69;
			int num71 = 1;
			int num72 = index24 + num71;
			int num73 = 187;
			numArray24[index24] = (byte) num73;
			byte[] numArray25 = commandList;
			int index25 = num72;
			int num74 = 1;
			int num75 = index25 + num74;
			int num76 = 7;
			numArray25[index25] = (byte) num76;
			byte[] numArray26 = commandList;
			int index26 = num75;
			int num77 = 1;
			int num78 = index26 + num77;
			int num79 = 186;
			numArray26[index26] = (byte) num79;
			byte[] numArray27 = commandList;
			int index27 = num78;
			int num80 = 1;
			int num81 = index27 + num80;
			int num82 = 208;
			numArray27[index27] = (byte) num82;
			byte[] numArray28 = commandList;
			int index28 = num81;
			int num83 = 1;
			int num84 = index28 + num83;
			int num85 = 186;
			numArray28[index28] = (byte) num85;
			byte[] numArray29 = commandList;
			int index29 = num84;
			int num86 = 1;
			int num87 = index29 + num86;
			int num88 = 254;
			numArray29[index29] = (byte) num88;
			ProgCommand.writeUSB(commandList);
		}

		public static bool DownloadPE()
		{
			int num1 = 0;
			byte[] numArray1 = new byte[64];
			byte[] numArray2 = numArray1;
			int index1 = num1;
			int num2 = 1;
			int num3 = index1 + num2;
			int num4 = 167;
			numArray2[index1] = (byte) num4;
			byte[] numArray3 = numArray1;
			int index2 = num3;
			int num5 = 1;
			int num6 = index2 + num5;
			int num7 = 168;
			numArray3[index2] = (byte) num7;
			byte[] numArray4 = numArray1;
			int index3 = num6;
			int num8 = 1;
			int offset1 = index3 + num8;
			int num9 = 28;
			numArray4[index3] = (byte) num9;
			int offset2 = PIC32MXFunctions.addInstruction(numArray1, 1006944136U, offset1);
			int offset3 = PIC32MXFunctions.addInstruction(numArray1, 881074176U, offset2);
			int offset4 = PIC32MXFunctions.addInstruction(numArray1, 1006960671U, offset3);
			int offset5 = PIC32MXFunctions.addInstruction(numArray1, 883228736U, offset4);
			int offset6 = PIC32MXFunctions.addInstruction(numArray1, 2894397440U, offset5);
			int offset7 = PIC32MXFunctions.addInstruction(numArray1, 872744960U, offset6);
			int num10 = PIC32MXFunctions.addInstruction(numArray1, 2894397456U, offset7);
			byte[] numArray5 = numArray1;
			int index4 = num10;
			int num11 = 1;
			int num12 = index4 + num11;
			int num13 = 166;
			numArray5[index4] = (byte) num13;
			byte[] numArray6 = numArray1;
			int index5 = num12;
			int num14 = 1;
			int num15 = index5 + num14;
			int num16 = 12;
			numArray6[index5] = (byte) num16;
			byte[] numArray7 = numArray1;
			int index6 = num15;
			int num17 = 1;
			int num18 = index6 + num17;
			int num19 = 187;
			numArray7[index6] = (byte) num19;
			byte[] numArray8 = numArray1;
			int index7 = num18;
			int num20 = 1;
			int num21 = index7 + num20;
			int num22 = 5;
			numArray8[index7] = (byte) num22;
			byte[] numArray9 = numArray1;
			int index8 = num21;
			int num23 = 1;
			int num24 = index8 + num23;
			int num25 = 188;
			numArray9[index8] = (byte) num25;
			byte[] numArray10 = numArray1;
			int index9 = num24;
			int num26 = 1;
			int num27 = index9 + num26;
			int num28 = 6;
			numArray10[index9] = (byte) num28;
			byte[] numArray11 = numArray1;
			int index10 = num27;
			int num29 = 1;
			int num30 = index10 + num29;
			int num31 = 31;
			numArray11[index10] = (byte) num31;
			byte[] numArray12 = numArray1;
			int index11 = num30;
			int num32 = 1;
			int num33 = index11 + num32;
			int num34 = 182;
			numArray12[index11] = (byte) num34;
			byte[] numArray13 = numArray1;
			int index12 = num33;
			int num35 = 1;
			int num36 = index12 + num35;
			int num37 = 182;
			numArray13[index12] = (byte) num37;
			byte[] numArray14 = numArray1;
			int index13 = num36;
			int num38 = 1;
			int num39 = index13 + num38;
			int num40 = 182;
			numArray14[index13] = (byte) num40;
			byte[] numArray15 = numArray1;
			int index14 = num39;
			int num41 = 1;
			int num42 = index14 + num41;
			int num43 = 182;
			numArray15[index14] = (byte) num43;
			byte[] numArray16 = numArray1;
			int index15 = num42;
			int num44 = 1;
			int num45 = index15 + num44;
			int num46 = 182;
			numArray16[index15] = (byte) num46;
			byte[] numArray17 = numArray1;
			int index16 = num45;
			int num47 = 1;
			int num48 = index16 + num47;
			int num49 = 182;
			numArray17[index16] = (byte) num49;
			byte[] numArray18 = numArray1;
			int index17 = num48;
			int num50 = 1;
			int index18 = index17 + num50;
			int num51 = 182;
			numArray18[index17] = (byte) num51;
			for (; index18 < 64; ++index18)
				numArray1[index18] = (byte) 173;
			ProgCommand.writeUSB(numArray1);
			if (ProgCommand.BusErrorCheck())
				return false;
			int num52 = 0;
			byte[] numArray19 = numArray1;
			int index19 = num52;
			int num53 = 1;
			int num54 = index19 + num53;
			int num55 = 167;
			numArray19[index19] = (byte) num55;
			byte[] numArray20 = numArray1;
			int index20 = num54;
			int num56 = 1;
			int num57 = index20 + num56;
			int num58 = 168;
			numArray20[index20] = (byte) num58;
			byte[] numArray21 = numArray1;
			int index21 = num57;
			int num59 = 1;
			int offset8 = index21 + num59;
			int num60 = 20;
			numArray21[index21] = (byte) num60;
			int offset9 = PIC32MXFunctions.addInstruction(numArray1, 872775680U, offset8);
			int offset10 = PIC32MXFunctions.addInstruction(numArray1, 2894397472U, offset9);
			int offset11 = PIC32MXFunctions.addInstruction(numArray1, 2894397488U, offset10);
			int offset12 = PIC32MXFunctions.addInstruction(numArray1, 1006936064U, offset11);
			int num61 = PIC32MXFunctions.addInstruction(numArray1, 881068032U, offset12);
			byte[] numArray22 = numArray1;
			int index22 = num61;
			int num62 = 1;
			int num63 = index22 + num62;
			int num64 = 166;
			numArray22[index22] = (byte) num64;
			byte[] numArray23 = numArray1;
			int index23 = num63;
			int num65 = 1;
			int num66 = index23 + num65;
			int num67 = 5;
			numArray23[index23] = (byte) num67;
			byte[] numArray24 = numArray1;
			int index24 = num66;
			int num68 = 1;
			int num69 = index24 + num68;
			int num70 = 182;
			numArray24[index24] = (byte) num70;
			byte[] numArray25 = numArray1;
			int index25 = num69;
			int num71 = 1;
			int num72 = index25 + num71;
			int num73 = 182;
			numArray25[index25] = (byte) num73;
			byte[] numArray26 = numArray1;
			int index26 = num72;
			int num74 = 1;
			int num75 = index26 + num74;
			int num76 = 182;
			numArray26[index26] = (byte) num76;
			byte[] numArray27 = numArray1;
			int index27 = num75;
			int num77 = 1;
			int num78 = index27 + num77;
			int num79 = 182;
			numArray27[index27] = (byte) num79;
			byte[] numArray28 = numArray1;
			int index28 = num78;
			int num80 = 1;
			int index29 = index28 + num80;
			int num81 = 182;
			numArray28[index28] = (byte) num81;
			for (; index29 < 64; ++index29)
				numArray1[index29] = (byte) 173;
			ProgCommand.writeUSB(numArray1);
			if (ProgCommand.BusErrorCheck())
				return false;
			int index30 = 0;
			while (index30 < PIC32MXFunctions.pe_Loader.Length)
			{
				int num82 = 0;
				byte[] numArray29 = numArray1;
				int index31 = num82;
				int num83 = 1;
				int num84 = index31 + num83;
				int num85 = 167;
				numArray29[index31] = (byte) num85;
				byte[] numArray30 = numArray1;
				int index32 = num84;
				int num86 = 1;
				int num87 = index32 + num86;
				int num88 = 168;
				numArray30[index32] = (byte) num88;
				byte[] numArray31 = numArray1;
				int index33 = num87;
				int num89 = 1;
				int offset13 = index33 + num89;
				int num90 = 16;
				numArray31[index33] = (byte) num90;
				int offset14 = PIC32MXFunctions.addInstruction(numArray1, 1007026176U | PIC32MXFunctions.pe_Loader[index30], offset13);
				int offset15 = PIC32MXFunctions.addInstruction(numArray1, 885391360U | PIC32MXFunctions.pe_Loader[index30 + 1], offset14);
				int offset16 = PIC32MXFunctions.addInstruction(numArray1, 2894462976U, offset15);
				int num91 = PIC32MXFunctions.addInstruction(numArray1, 612630532U, offset16);
				byte[] numArray32 = numArray1;
				int index34 = num91;
				int num92 = 1;
				int num93 = index34 + num92;
				int num94 = 166;
				numArray32[index34] = (byte) num94;
				byte[] numArray33 = numArray1;
				int index35 = num93;
				int num95 = 1;
				int num96 = index35 + num95;
				int num97 = 4;
				numArray33[index35] = (byte) num97;
				byte[] numArray34 = numArray1;
				int index36 = num96;
				int num98 = 1;
				int num99 = index36 + num98;
				int num100 = 182;
				numArray34[index36] = (byte) num100;
				byte[] numArray35 = numArray1;
				int index37 = num99;
				int num101 = 1;
				int num102 = index37 + num101;
				int num103 = 182;
				numArray35[index37] = (byte) num103;
				byte[] numArray36 = numArray1;
				int index38 = num102;
				int num104 = 1;
				int num105 = index38 + num104;
				int num106 = 182;
				numArray36[index38] = (byte) num106;
				byte[] numArray37 = numArray1;
				int index39 = num105;
				int num107 = 1;
				int index40 = index39 + num107;
				int num108 = 182;
				numArray37[index39] = (byte) num108;
				for (; index40 < 64; ++index40)
					numArray1[index40] = (byte) 173;
				ProgCommand.writeUSB(numArray1);
				if (ProgCommand.BusErrorCheck())
					return false;
				index30 += 2;
			}
			int num109 = 0;
			byte[] numArray38 = numArray1;
			int index41 = num109;
			int num110 = 1;
			int num111 = index41 + num110;
			int num112 = 167;
			numArray38[index41] = (byte) num112;
			byte[] numArray39 = numArray1;
			int index42 = num111;
			int num113 = 1;
			int num114 = index42 + num113;
			int num115 = 168;
			numArray39[index42] = (byte) num115;
			byte[] numArray40 = numArray1;
			int index43 = num114;
			int num116 = 1;
			int offset17 = index43 + num116;
			int num117 = 16;
			numArray40[index43] = (byte) num117;
			int offset18 = PIC32MXFunctions.addInstruction(numArray1, 1008312320U, offset17);
			int offset19 = PIC32MXFunctions.addInstruction(numArray1, 926484480U, offset18);
			int offset20 = PIC32MXFunctions.addInstruction(numArray1, 52428808U, offset19);
			int num118 = PIC32MXFunctions.addInstruction(numArray1, 0U, offset20);
			byte[] numArray41 = numArray1;
			int index44 = num118;
			int num119 = 1;
			int num120 = index44 + num119;
			int num121 = 166;
			numArray41[index44] = (byte) num121;
			byte[] numArray42 = numArray1;
			int index45 = num120;
			int num122 = 1;
			int num123 = index45 + num122;
			int num124 = 21;
			numArray42[index45] = (byte) num124;
			byte[] numArray43 = numArray1;
			int index46 = num123;
			int num125 = 1;
			int num126 = index46 + num125;
			int num127 = 182;
			numArray43[index46] = (byte) num127;
			byte[] numArray44 = numArray1;
			int index47 = num126;
			int num128 = 1;
			int num129 = index47 + num128;
			int num130 = 182;
			numArray44[index47] = (byte) num130;
			byte[] numArray45 = numArray1;
			int index48 = num129;
			int num131 = 1;
			int num132 = index48 + num131;
			int num133 = 182;
			numArray45[index48] = (byte) num133;
			byte[] numArray46 = numArray1;
			int index49 = num132;
			int num134 = 1;
			int num135 = index49 + num134;
			int num136 = 182;
			numArray46[index49] = (byte) num136;
			byte[] numArray47 = numArray1;
			int index50 = num135;
			int num137 = 1;
			int num138 = index50 + num137;
			int num139 = 187;
			numArray47[index50] = (byte) num139;
			byte[] numArray48 = numArray1;
			int index51 = num138;
			int num140 = 1;
			int num141 = index51 + num140;
			int num142 = 5;
			numArray48[index51] = (byte) num142;
			byte[] numArray49 = numArray1;
			int index52 = num141;
			int num143 = 1;
			int num144 = index52 + num143;
			int num145 = 188;
			numArray49[index52] = (byte) num145;
			byte[] numArray50 = numArray1;
			int index53 = num144;
			int num146 = 1;
			int num147 = index53 + num146;
			int num148 = 6;
			numArray50[index53] = (byte) num148;
			byte[] numArray51 = numArray1;
			int index54 = num147;
			int num149 = 1;
			int num150 = index54 + num149;
			int num151 = 31;
			numArray51[index54] = (byte) num151;
			byte[] numArray52 = numArray1;
			int index55 = num150;
			int num152 = 1;
			int num153 = index55 + num152;
			int num154 = 187;
			numArray52[index55] = (byte) num154;
			byte[] numArray53 = numArray1;
			int index56 = num153;
			int num155 = 1;
			int num156 = index56 + num155;
			int num157 = 14;
			numArray53[index56] = (byte) num157;
			byte[] numArray54 = numArray1;
			int index57 = num156;
			int num158 = 1;
			int num159 = index57 + num158;
			int num160 = 184;
			numArray54[index57] = (byte) num160;
			byte[] numArray55 = numArray1;
			int index58 = num159;
			int num161 = 1;
			int num162 = index58 + num161;
			int num163 = 0;
			numArray55[index58] = (byte) num163;
			byte[] numArray56 = numArray1;
			int index59 = num162;
			int num164 = 1;
			int num165 = index59 + num164;
			int num166 = 9;
			numArray56[index59] = (byte) num166;
			byte[] numArray57 = numArray1;
			int index60 = num165;
			int num167 = 1;
			int num168 = index60 + num167;
			int num169 = 0;
			numArray57[index60] = (byte) num169;
			byte[] numArray58 = numArray1;
			int index61 = num168;
			int num170 = 1;
			int num171 = index61 + num170;
			int num172 = 160;
			numArray58[index61] = (byte) num172;
			byte[] numArray59 = numArray1;
			int index62 = num171;
			int num173 = 1;
			int num174 = index62 + num173;
			int num175 = 184;
			numArray59[index62] = (byte) num175;
			byte[] numArray60 = numArray1;
			int index63 = num174;
			int num176 = 1;
			int num177 = index63 + num176;
			int num178 = (int) (byte) (PIC32MXFunctions.PIC32_PE.Length & (int) byte.MaxValue);
			numArray60[index63] = (byte) num178;
			byte[] numArray61 = numArray1;
			int index64 = num177;
			int num179 = 1;
			int num180 = index64 + num179;
			int num181 = (int) (byte) (PIC32MXFunctions.PIC32_PE.Length >> 8 & (int) byte.MaxValue);
			numArray61[index64] = (byte) num181;
			byte[] numArray62 = numArray1;
			int index65 = num180;
			int num182 = 1;
			int num183 = index65 + num182;
			int num184 = 0;
			numArray62[index65] = (byte) num184;
			byte[] numArray63 = numArray1;
			int index66 = num183;
			int num185 = 1;
			int index67 = index66 + num185;
			int num186 = 0;
			numArray63[index66] = (byte) num186;
			for (; index67 < 64; ++index67)
				numArray1[index67] = (byte) 173;
			ProgCommand.writeUSB(numArray1);
			if (ProgCommand.BusErrorCheck())
				return false;
			int num187 = PIC32MXFunctions.PIC32_PE.Length / 10;
			int num188 = 0;
			for (; num188 < num187; ++num188)
			{
				int num82 = 0;
				byte[] numArray29 = numArray1;
				int index31 = num82;
				int num83 = 1;
				int num84 = index31 + num83;
				int num85 = 167;
				numArray29[index31] = (byte) num85;
				byte[] numArray30 = numArray1;
				int index32 = num84;
				int num86 = 1;
				int num87 = index32 + num86;
				int num88 = 168;
				numArray30[index32] = (byte) num88;
				byte[] numArray31 = numArray1;
				int index33 = num87;
				int num89 = 1;
				int offset13 = index33 + num89;
				int num90 = 40;
				numArray31[index33] = (byte) num90;
				int index34 = num188 * 10;
				int offset14 = PIC32MXFunctions.addInstruction(numArray1, PIC32MXFunctions.PIC32_PE[index34], offset13);
				int offset15 = PIC32MXFunctions.addInstruction(numArray1, PIC32MXFunctions.PIC32_PE[index34 + 1], offset14);
				int offset16 = PIC32MXFunctions.addInstruction(numArray1, PIC32MXFunctions.PIC32_PE[index34 + 2], offset15);
				int offset21 = PIC32MXFunctions.addInstruction(numArray1, PIC32MXFunctions.PIC32_PE[index34 + 3], offset16);
				int offset22 = PIC32MXFunctions.addInstruction(numArray1, PIC32MXFunctions.PIC32_PE[index34 + 4], offset21);
				int offset23 = PIC32MXFunctions.addInstruction(numArray1, PIC32MXFunctions.PIC32_PE[index34 + 5], offset22);
				int offset24 = PIC32MXFunctions.addInstruction(numArray1, PIC32MXFunctions.PIC32_PE[index34 + 6], offset23);
				int offset25 = PIC32MXFunctions.addInstruction(numArray1, PIC32MXFunctions.PIC32_PE[index34 + 7], offset24);
				int offset26 = PIC32MXFunctions.addInstruction(numArray1, PIC32MXFunctions.PIC32_PE[index34 + 8], offset25);
				int num91 = PIC32MXFunctions.addInstruction(numArray1, PIC32MXFunctions.PIC32_PE[index34 + 9], offset26);
				byte[] numArray32 = numArray1;
				int index35 = num91;
				int num92 = 1;
				int num93 = index35 + num92;
				int num94 = 166;
				numArray32[index35] = (byte) num94;
				byte[] numArray33 = numArray1;
				int index36 = num93;
				int num95 = 1;
				int num96 = index36 + num95;
				int num97 = 10;
				numArray33[index36] = (byte) num97;
				byte[] numArray34 = numArray1;
				int index37 = num96;
				int num98 = 1;
				int num99 = index37 + num98;
				int num100 = 183;
				numArray34[index37] = (byte) num100;
				byte[] numArray35 = numArray1;
				int index38 = num99;
				int num101 = 1;
				int num102 = index38 + num101;
				int num103 = 183;
				numArray35[index38] = (byte) num103;
				byte[] numArray36 = numArray1;
				int index39 = num102;
				int num104 = 1;
				int num105 = index39 + num104;
				int num106 = 183;
				numArray36[index39] = (byte) num106;
				byte[] numArray37 = numArray1;
				int index40 = num105;
				int num107 = 1;
				int num108 = index40 + num107;
				int num189 = 183;
				numArray37[index40] = (byte) num189;
				byte[] numArray64 = numArray1;
				int index68 = num108;
				int num190 = 1;
				int num191 = index68 + num190;
				int num192 = 183;
				numArray64[index68] = (byte) num192;
				byte[] numArray65 = numArray1;
				int index69 = num191;
				int num193 = 1;
				int num194 = index69 + num193;
				int num195 = 183;
				numArray65[index69] = (byte) num195;
				byte[] numArray66 = numArray1;
				int index70 = num194;
				int num196 = 1;
				int num197 = index70 + num196;
				int num198 = 183;
				numArray66[index70] = (byte) num198;
				byte[] numArray67 = numArray1;
				int index71 = num197;
				int num199 = 1;
				int num200 = index71 + num199;
				int num201 = 183;
				numArray67[index71] = (byte) num201;
				byte[] numArray68 = numArray1;
				int index72 = num200;
				int num202 = 1;
				int num203 = index72 + num202;
				int num204 = 183;
				numArray68[index72] = (byte) num204;
				byte[] numArray69 = numArray1;
				int index73 = num203;
				int num205 = 1;
				int index74 = index73 + num205;
				int num206 = 183;
				numArray69[index73] = (byte) num206;
				for (; index74 < 64; ++index74)
					numArray1[index74] = (byte) 173;
				ProgCommand.writeUSB(numArray1);
				if (ProgCommand.BusErrorCheck())
					return false;
			}
			Thread.Sleep(100);
			int num207 = num187 * 10;
			int num208 = PIC32MXFunctions.PIC32_PE.Length % 10;
			if (num208 > 0)
			{
				int num82 = 0;
				byte[] numArray29 = numArray1;
				int index31 = num82;
				int num83 = 1;
				int num84 = index31 + num83;
				int num85 = 167;
				numArray29[index31] = (byte) num85;
				byte[] numArray30 = numArray1;
				int index32 = num84;
				int num86 = 1;
				int num87 = index32 + num86;
				int num88 = 168;
				numArray30[index32] = (byte) num88;
				byte[] numArray31 = numArray1;
				int index33 = num87;
				int num89 = 1;
				int offset13 = index33 + num89;
				int num90 = (int) (byte) (4 * num208);
				numArray31[index33] = (byte) num90;
				for (int index34 = 0; index34 < num208; ++index34)
					offset13 = PIC32MXFunctions.addInstruction(numArray1, PIC32MXFunctions.PIC32_PE[index34 + num207], offset13);
				byte[] numArray32 = numArray1;
				int index35 = offset13;
				int num91 = 1;
				int num92 = index35 + num91;
				int num93 = 166;
				numArray32[index35] = (byte) num93;
				byte[] numArray33 = numArray1;
				int index36 = num92;
				int num94 = 1;
				int index37 = index36 + num94;
				int num95 = (int) (byte) num208;
				numArray33[index36] = (byte) num95;
				for (int index34 = 0; index34 < num208; ++index34)
					numArray1[index37++] = (byte) 183;
				for (; index37 < 64; ++index37)
					numArray1[index37] = (byte) 173;
				ProgCommand.writeUSB(numArray1);
				if (ProgCommand.BusErrorCheck())
					return false;
			}
			int num209 = 0;
			byte[] numArray70 = numArray1;
			int index75 = num209;
			int num210 = 1;
			int num211 = index75 + num210;
			int num212 = 167;
			numArray70[index75] = (byte) num212;
			byte[] numArray71 = numArray1;
			int index76 = num211;
			int num213 = 1;
			int num214 = index76 + num213;
			int num215 = 168;
			numArray71[index76] = (byte) num215;
			byte[] numArray72 = numArray1;
			int index77 = num214;
			int num216 = 1;
			int offset27 = index77 + num216;
			int num217 = 8;
			numArray72[index77] = (byte) num217;
			int offset28 = PIC32MXFunctions.addInstruction(numArray1, 0U, offset27);
			int num218 = PIC32MXFunctions.addInstruction(numArray1, 3735879680U, offset28);
			byte[] numArray73 = numArray1;
			int index78 = num218;
			int num219 = 1;
			int num220 = index78 + num219;
			int num221 = 166;
			numArray73[index78] = (byte) num221;
			byte[] numArray74 = numArray1;
			int index79 = num220;
			int num222 = 1;
			int num223 = index79 + num222;
			int num224 = 2;
			numArray74[index79] = (byte) num224;
			byte[] numArray75 = numArray1;
			int index80 = num223;
			int num225 = 1;
			int num226 = index80 + num225;
			int num227 = 183;
			numArray75[index80] = (byte) num227;
			byte[] numArray76 = numArray1;
			int index81 = num226;
			int num228 = 1;
			int index82 = index81 + num228;
			int num229 = 183;
			numArray76[index81] = (byte) num229;
			for (; index82 < 64; ++index82)
				numArray1[index82] = (byte) 173;
			ProgCommand.writeUSB(numArray1);
			if (ProgCommand.BusErrorCheck())
				return false;
			Thread.Sleep(100);
			return true;
		}

		public static int ReadPEVersion()
		{
			byte[] commandList = new byte[11];
			int num1 = 0;
			byte[] numArray1 = commandList;
			int index1 = num1;
			int num2 = 1;
			int num3 = index1 + num2;
			int num4 = 169;
			numArray1[index1] = (byte) num4;
			byte[] numArray2 = commandList;
			int index2 = num3;
			int num5 = 1;
			int num6 = index2 + num5;
			int num7 = 166;
			numArray2[index2] = (byte) num7;
			byte[] numArray3 = commandList;
			int index3 = num6;
			int num8 = 1;
			int num9 = index3 + num8;
			int num10 = 8;
			numArray3[index3] = (byte) num10;
			byte[] numArray4 = commandList;
			int index4 = num9;
			int num11 = 1;
			int num12 = index4 + num11;
			int num13 = 187;
			numArray4[index4] = (byte) num13;
			byte[] numArray5 = commandList;
			int index5 = num12;
			int num14 = 1;
			int num15 = index5 + num14;
			int num16 = 14;
			numArray5[index5] = (byte) num16;
			byte[] numArray6 = commandList;
			int index6 = num15;
			int num17 = 1;
			int num18 = index6 + num17;
			int num19 = 184;
			numArray6[index6] = (byte) num19;
			byte[] numArray7 = commandList;
			int index7 = num18;
			int num20 = 1;
			int num21 = index7 + num20;
			int num22 = 0;
			numArray7[index7] = (byte) num22;
			byte[] numArray8 = commandList;
			int index8 = num21;
			int num23 = 1;
			int num24 = index8 + num23;
			int num25 = 0;
			numArray8[index8] = (byte) num25;
			byte[] numArray9 = commandList;
			int index9 = num24;
			int num26 = 1;
			int num27 = index9 + num26;
			int num28 = 7;
			numArray9[index9] = (byte) num28;
			byte[] numArray10 = commandList;
			int index10 = num27;
			int num29 = 1;
			int num30 = index10 + num29;
			int num31 = 0;
			numArray10[index10] = (byte) num31;
			byte[] numArray11 = commandList;
			int index11 = num30;
			int num32 = 1;
			int num33 = index11 + num32;
			int num34 = 181;
			numArray11[index11] = (byte) num34;
			ProgCommand.writeUSB(commandList);
			if (ProgCommand.BusErrorCheck() || !ProgCommand.UploadData() || (int) ProgCommand.Usb_read_array[4] + (int) ProgCommand.Usb_read_array[5] * 256 != 7)
				return 0;
			else
				return (int) ProgCommand.Usb_read_array[2] + (int) ProgCommand.Usb_read_array[3] * 256;
		}

		public static bool PEBlankCheck(uint startAddress, uint lengthBytes)
		{
			byte[] commandList = new byte[21];
			int num1 = 0;
			byte[] numArray1 = commandList;
			int index1 = num1;
			int num2 = 1;
			int num3 = index1 + num2;
			int num4 = 169;
			numArray1[index1] = (byte) num4;
			byte[] numArray2 = commandList;
			int index2 = num3;
			int num5 = 1;
			int num6 = index2 + num5;
			int num7 = 166;
			numArray2[index2] = (byte) num7;
			byte[] numArray3 = commandList;
			int index3 = num6;
			int num8 = 1;
			int num9 = index3 + num8;
			int num10 = 18;
			numArray3[index3] = (byte) num10;
			byte[] numArray4 = commandList;
			int index4 = num9;
			int num11 = 1;
			int num12 = index4 + num11;
			int num13 = 187;
			numArray4[index4] = (byte) num13;
			byte[] numArray5 = commandList;
			int index5 = num12;
			int num14 = 1;
			int num15 = index5 + num14;
			int num16 = 14;
			numArray5[index5] = (byte) num16;
			byte[] numArray6 = commandList;
			int index6 = num15;
			int num17 = 1;
			int num18 = index6 + num17;
			int num19 = 184;
			numArray6[index6] = (byte) num19;
			byte[] numArray7 = commandList;
			int index7 = num18;
			int num20 = 1;
			int num21 = index7 + num20;
			int num22 = 0;
			numArray7[index7] = (byte) num22;
			byte[] numArray8 = commandList;
			int index8 = num21;
			int num23 = 1;
			int num24 = index8 + num23;
			int num25 = 0;
			numArray8[index8] = (byte) num25;
			byte[] numArray9 = commandList;
			int index9 = num24;
			int num26 = 1;
			int num27 = index9 + num26;
			int num28 = 6;
			numArray9[index9] = (byte) num28;
			byte[] numArray10 = commandList;
			int index10 = num27;
			int num29 = 1;
			int num30 = index10 + num29;
			int num31 = 0;
			numArray10[index10] = (byte) num31;
			byte[] numArray11 = commandList;
			int index11 = num30;
			int num32 = 1;
			int num33 = index11 + num32;
			int num34 = 184;
			numArray11[index11] = (byte) num34;
			byte[] numArray12 = commandList;
			int index12 = num33;
			int num35 = 1;
			int num36 = index12 + num35;
			int num37 = (int) (byte) (startAddress & (uint) byte.MaxValue);
			numArray12[index12] = (byte) num37;
			byte[] numArray13 = commandList;
			int index13 = num36;
			int num38 = 1;
			int num39 = index13 + num38;
			int num40 = (int) (byte) (startAddress >> 8 & (uint) byte.MaxValue);
			numArray13[index13] = (byte) num40;
			byte[] numArray14 = commandList;
			int index14 = num39;
			int num41 = 1;
			int num42 = index14 + num41;
			int num43 = (int) (byte) (startAddress >> 16 & (uint) byte.MaxValue);
			numArray14[index14] = (byte) num43;
			byte[] numArray15 = commandList;
			int index15 = num42;
			int num44 = 1;
			int num45 = index15 + num44;
			int num46 = (int) (byte) (startAddress >> 24 & (uint) byte.MaxValue);
			numArray15[index15] = (byte) num46;
			byte[] numArray16 = commandList;
			int index16 = num45;
			int num47 = 1;
			int num48 = index16 + num47;
			int num49 = 184;
			numArray16[index16] = (byte) num49;
			byte[] numArray17 = commandList;
			int index17 = num48;
			int num50 = 1;
			int num51 = index17 + num50;
			int num52 = (int) (byte) (lengthBytes & (uint) byte.MaxValue);
			numArray17[index17] = (byte) num52;
			byte[] numArray18 = commandList;
			int index18 = num51;
			int num53 = 1;
			int num54 = index18 + num53;
			int num55 = (int) (byte) (lengthBytes >> 8 & (uint) byte.MaxValue);
			numArray18[index18] = (byte) num55;
			byte[] numArray19 = commandList;
			int index19 = num54;
			int num56 = 1;
			int num57 = index19 + num56;
			int num58 = (int) (byte) (lengthBytes >> 16 & (uint) byte.MaxValue);
			numArray19[index19] = (byte) num58;
			byte[] numArray20 = commandList;
			int index20 = num57;
			int num59 = 1;
			int num60 = index20 + num59;
			int num61 = (int) (byte) (lengthBytes >> 24 & (uint) byte.MaxValue);
			numArray20[index20] = (byte) num61;
			byte[] numArray21 = commandList;
			int index21 = num60;
			int num62 = 1;
			int num63 = index21 + num62;
			int num64 = 181;
			numArray21[index21] = (byte) num64;
			ProgCommand.writeUSB(commandList);
			return !ProgCommand.BusErrorCheck() && ProgCommand.UploadData() && ((int) ProgCommand.Usb_read_array[4] == 6 && (int) ProgCommand.Usb_read_array[2] == 0);
		}

		public static int PEGetCRC(uint startAddress, uint lengthBytes)
		{
			byte[] commandList = new byte[22];
			int num1 = 0;
			byte[] numArray1 = commandList;
			int index1 = num1;
			int num2 = 1;
			int num3 = index1 + num2;
			int num4 = 169;
			numArray1[index1] = (byte) num4;
			byte[] numArray2 = commandList;
			int index2 = num3;
			int num5 = 1;
			int num6 = index2 + num5;
			int num7 = 166;
			numArray2[index2] = (byte) num7;
			byte[] numArray3 = commandList;
			int index3 = num6;
			int num8 = 1;
			int num9 = index3 + num8;
			int num10 = 19;
			numArray3[index3] = (byte) num10;
			byte[] numArray4 = commandList;
			int index4 = num9;
			int num11 = 1;
			int num12 = index4 + num11;
			int num13 = 187;
			numArray4[index4] = (byte) num13;
			byte[] numArray5 = commandList;
			int index5 = num12;
			int num14 = 1;
			int num15 = index5 + num14;
			int num16 = 14;
			numArray5[index5] = (byte) num16;
			byte[] numArray6 = commandList;
			int index6 = num15;
			int num17 = 1;
			int num18 = index6 + num17;
			int num19 = 184;
			numArray6[index6] = (byte) num19;
			byte[] numArray7 = commandList;
			int index7 = num18;
			int num20 = 1;
			int num21 = index7 + num20;
			int num22 = 0;
			numArray7[index7] = (byte) num22;
			byte[] numArray8 = commandList;
			int index8 = num21;
			int num23 = 1;
			int num24 = index8 + num23;
			int num25 = 0;
			numArray8[index8] = (byte) num25;
			byte[] numArray9 = commandList;
			int index9 = num24;
			int num26 = 1;
			int num27 = index9 + num26;
			int num28 = 8;
			numArray9[index9] = (byte) num28;
			byte[] numArray10 = commandList;
			int index10 = num27;
			int num29 = 1;
			int num30 = index10 + num29;
			int num31 = 0;
			numArray10[index10] = (byte) num31;
			byte[] numArray11 = commandList;
			int index11 = num30;
			int num32 = 1;
			int num33 = index11 + num32;
			int num34 = 184;
			numArray11[index11] = (byte) num34;
			byte[] numArray12 = commandList;
			int index12 = num33;
			int num35 = 1;
			int num36 = index12 + num35;
			int num37 = (int) (byte) (startAddress & (uint) byte.MaxValue);
			numArray12[index12] = (byte) num37;
			byte[] numArray13 = commandList;
			int index13 = num36;
			int num38 = 1;
			int num39 = index13 + num38;
			int num40 = (int) (byte) (startAddress >> 8 & (uint) byte.MaxValue);
			numArray13[index13] = (byte) num40;
			byte[] numArray14 = commandList;
			int index14 = num39;
			int num41 = 1;
			int num42 = index14 + num41;
			int num43 = (int) (byte) (startAddress >> 16 & (uint) byte.MaxValue);
			numArray14[index14] = (byte) num43;
			byte[] numArray15 = commandList;
			int index15 = num42;
			int num44 = 1;
			int num45 = index15 + num44;
			int num46 = (int) (byte) (startAddress >> 24 & (uint) byte.MaxValue);
			numArray15[index15] = (byte) num46;
			byte[] numArray16 = commandList;
			int index16 = num45;
			int num47 = 1;
			int num48 = index16 + num47;
			int num49 = 184;
			numArray16[index16] = (byte) num49;
			byte[] numArray17 = commandList;
			int index17 = num48;
			int num50 = 1;
			int num51 = index17 + num50;
			int num52 = (int) (byte) (lengthBytes & (uint) byte.MaxValue);
			numArray17[index17] = (byte) num52;
			byte[] numArray18 = commandList;
			int index18 = num51;
			int num53 = 1;
			int num54 = index18 + num53;
			int num55 = (int) (byte) (lengthBytes >> 8 & (uint) byte.MaxValue);
			numArray18[index18] = (byte) num55;
			byte[] numArray19 = commandList;
			int index19 = num54;
			int num56 = 1;
			int num57 = index19 + num56;
			int num58 = (int) (byte) (lengthBytes >> 16 & (uint) byte.MaxValue);
			numArray19[index19] = (byte) num58;
			byte[] numArray20 = commandList;
			int index20 = num57;
			int num59 = 1;
			int num60 = index20 + num59;
			int num61 = (int) (byte) (lengthBytes >> 24 & (uint) byte.MaxValue);
			numArray20[index20] = (byte) num61;
			byte[] numArray21 = commandList;
			int index21 = num60;
			int num62 = 1;
			int num63 = index21 + num62;
			int num64 = 181;
			numArray21[index21] = (byte) num64;
			byte[] numArray22 = commandList;
			int index22 = num63;
			int num65 = 1;
			int num66 = index22 + num65;
			int num67 = 181;
			numArray22[index22] = (byte) num67;
			ProgCommand.writeUSB(commandList);
			if (ProgCommand.BusErrorCheck() || !ProgCommand.UploadData() || ((int) ProgCommand.Usb_read_array[4] != 8 || (int) ProgCommand.Usb_read_array[2] != 0))
				return 0;
			else
				return (int) ProgCommand.Usb_read_array[6] + ((int) ProgCommand.Usb_read_array[7] << 8);
		}

		private static int addInstruction(byte[] commandarray, uint instruction, int offset)
		{
			commandarray[offset++] = (byte) (instruction & (uint) byte.MaxValue);
			commandarray[offset++] = (byte) (instruction >> 8 & (uint) byte.MaxValue);
			commandarray[offset++] = (byte) (instruction >> 16 & (uint) byte.MaxValue);
			commandarray[offset++] = (byte) (instruction >> 24 & (uint) byte.MaxValue);
			return offset;
		}

		public static bool PE_DownloadAndConnect()
		{
			PIC32MXFunctions.UpdateStatusWinText("Escribiendo SO interno en el PIC32...\n(Requerido para Programación)");
			ProgCommand.RunScript(0, 1);
			ProgCommand.UploadData();
			if (((int) ProgCommand.Usb_read_array[2] & 128) == 0)
			{
				PIC32MXFunctions.UpdateStatusWinText("El PIC32 está Protegido y debe Borrarse antes de Programarlo!");
				ProgCommand.RunScript(1, 1);
				return false;
			}
			else
			{
				PIC32MXFunctions.EnterSerialExecution();
				PIC32MXFunctions.DownloadPE();
				if (PIC32MXFunctions.ReadPEVersion() == 262)
					return true;
				PIC32MXFunctions.UpdateStatusWinText("Error al escribir el SO interno al PIC32!");
				ProgCommand.RunScript(1, 1);
				return false;
			}
		}

		public static bool PIC32Read()
		{
			ProgCommand.SetMCLRTemp(true);
			ProgCommand.VddOn();
			if (!PIC32MXFunctions.PE_DownloadAndConnect())
				return false;
			string dispText1 = "Leyendo Dispositivo...\n";
			PIC32MXFunctions.UpdateStatusWinText(dispText1);
			byte[] numArray1 = new byte[128];
			int num1 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem;
			int num2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BootFlash;
			int num3 = num1 - num2;
			string dispText2 = dispText1 + "Memoria Flash + ";
			PIC32MXFunctions.UpdateStatusWinText(dispText2);
			int num4 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
			int repetitions = 128 / ((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords * num4);
			int num5 = repetitions * (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords;
			int num6 = 0;
			PIC32MXFunctions.ResetStatusBar(num3 / num5);
			do
			{
				int num7 = (num3 - num6) / num5;
				if (num7 > 15)
					num7 = 15;
				uint num8 = (uint) (num6 * num4 + 486539264);
				byte[] numArray2 = new byte[3 + num7 * 4];
				int num9 = 0;
				byte[] numArray3 = numArray2;
				int index1 = num9;
				int num10 = 1;
				int num11 = index1 + num10;
				int num12 = 167;
				numArray3[index1] = (byte) num12;
				byte[] numArray4 = numArray2;
				int index2 = num11;
				int num13 = 1;
				int num14 = index2 + num13;
				int num15 = 168;
				numArray4[index2] = (byte) num15;
				byte[] numArray5 = numArray2;
				int index3 = num14;
				int num16 = 1;
				int offset = index3 + num16;
				int num17 = (int) (byte) (num7 * 4);
				numArray5[index3] = (byte) num17;
				for (int index4 = 0; index4 < num7; ++index4)
					offset = PIC32MXFunctions.addInstruction(numArray2, num8 + (uint) (index4 * (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgMemRdWords * num4), offset);
				ProgCommand.writeUSB(numArray2);
				for (int index4 = 0; index4 < num7; ++index4)
				{
					ProgCommand.RunScriptUploadNoLen2(3, repetitions);
					Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
					ProgCommand.GetUpload();
					Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
					int num18 = 0;
					for (int index5 = 0; index5 < num5; ++index5)
					{
						int num19 = 0;
						byte[] numArray6 = numArray1;
						int num20 = num18;
						int num21 = num19;
						int num22 = 1;
						int num23 = num21 + num22;
						int index6 = num20 + num21;
						uint num24 = (uint) numArray6[index6];
						if (num23 < num4)
							num24 |= (uint) numArray1[num18 + num23++] << 8;
						if (num23 < num4)
							num24 |= (uint) numArray1[num18 + num23++] << 16;
						if (num23 < num4)
							num24 |= (uint) numArray1[num18 + num23++] << 24;
						num18 += num23;
						ProgCommand.DeviceBuffers.ProgramMemory[num6++] = num24;
						if (num6 == num3)
						{
							index4 = num7;
							break;
						}
					}
					PIC32MXFunctions.StepStatusBar();
				}
			}
			while (num6 < num3);
			string dispText3 = dispText2 + "Sector de Arranque + ";
			PIC32MXFunctions.UpdateStatusWinText(dispText3);
			int num25 = 0;
			PIC32MXFunctions.ResetStatusBar(num2 / num5);
			int index7;
			do
			{
				uint instruction = (uint) (num25 * num4 + 532676608);
				byte[] numArray2 = new byte[3 + repetitions * 4];
				int num7 = 0;
				byte[] numArray3 = numArray2;
				int index1 = num7;
				int num8 = 1;
				int num9 = index1 + num8;
				int num10 = 167;
				numArray3[index1] = (byte) num10;
				byte[] numArray4 = numArray2;
				int index2 = num9;
				int num11 = 1;
				int num12 = index2 + num11;
				int num13 = 168;
				numArray4[index2] = (byte) num13;
				byte[] numArray5 = numArray2;
				int index3 = num12;
				int num14 = 1;
				int offset = index3 + num14;
				int num15 = (int) (byte) (repetitions * 4);
				numArray5[index3] = (byte) num15;
				for (int index4 = 0; index4 < repetitions; ++index4)
					offset = PIC32MXFunctions.addInstruction(numArray2, instruction, offset);
				ProgCommand.writeUSB(numArray2);
				ProgCommand.RunScriptUploadNoLen2(3, repetitions);
				Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 0L, 64L);
				ProgCommand.GetUpload();
				Array.Copy((Array) ProgCommand.Usb_read_array, 1L, (Array) numArray1, 64L, 64L);
				index7 = 0;
				for (int index4 = 0; index4 < num5; ++index4)
				{
					int num16 = 0;
					byte[] numArray6 = numArray1;
					int num17 = index7;
					int num18 = num16;
					int num19 = 1;
					int num20 = num18 + num19;
					int index5 = num17 + num18;
					uint num21 = (uint) numArray6[index5];
					if (num20 < num4)
						num21 |= (uint) numArray1[index7 + num20++] << 8;
					if (num20 < num4)
						num21 |= (uint) numArray1[index7 + num20++] << 16;
					if (num20 < num4)
						num21 |= (uint) numArray1[index7 + num20++] << 24;
					index7 += num20;
					ProgCommand.DeviceBuffers.ProgramMemory[num3 + num25++] = num21;
					if (num25 == num2)
						break;
				}
				PIC32MXFunctions.StepStatusBar();
			}
			while (num25 < num2);
			string dispText4 = dispText3 + "ID Bits + ";
			PIC32MXFunctions.UpdateStatusWinText(dispText4);
			ProgCommand.DeviceBuffers.UserIDs[0] = (uint) numArray1[index7];
			ProgCommand.DeviceBuffers.UserIDs[1] = (uint) numArray1[index7 + 1];
			int num26 = index7 + num4;
			string dispText5 = dispText4 + "Config Bits + ";
			PIC32MXFunctions.UpdateStatusWinText(dispText5);
			/*for (int index1 = 0; index1 < (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigWords; ++index1)
			{
				uint[] numArray2 = ProgCommand.DeviceBuffers.ConfigWords;
				int index2 = index1;
				byte[] numArray3 = numArray1;
				int index3 = num26;
				int num7 = 1;
				int num8 = index3 + num7;
				int num9 = (int) numArray3[index3];
				numArray2[index2] = (uint) num9;
				// ISSUE: explicit reference operation
				// ISSUE: variable of a reference type
				//uint& local = @ProgCommand.DeviceBuffers.ConfigWords[index1];
				// ISSUE: explicit reference operation
				int num10 = (int) ^local;
				byte[] numArray4 = numArray1;
				int index4 = num8;
				int num11 = 1;
				num26 = index4 + num11;
				int num12 = (int) numArray4[index4] << 8;
				int num13 = num10 | num12;
				// ISSUE: explicit reference operation
				//^local = (uint) num13;
			}*/
			string dispText6 = dispText5 + "Listo!";
			PIC32MXFunctions.UpdateStatusWinText(dispText6);
			ProgCommand.RunScript(1, 1);
			return true;
		}

		public static bool PIC32BlankCheck()
		{
			ProgCommand.SetMCLRTemp(true);
			ProgCommand.VddOn();
			if (!PIC32MXFunctions.PE_DownloadAndConnect())
				return false;
			string dispText1 = "Verificando si hay datos...\n";
			PIC32MXFunctions.UpdateStatusWinText(dispText1);
			int num1 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem;
			int num2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BootFlash;
			int num3 = num1 - num2;
			int num4 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
			string dispText2 = dispText1 + "Programando Flash... ";
			PIC32MXFunctions.UpdateStatusWinText(dispText2);
			if (!PIC32MXFunctions.PEBlankCheck(486539264U, (uint) (num3 * num4)))
			{
				string dispText3 = "La Memoria Flash No está Borrada! ";
				PIC32MXFunctions.UpdateStatusWinText(dispText3);
				ProgCommand.RunScript(1, 1);
				return false;
			}
			else
			{
				string dispText3 = dispText2 + "Programando Boot Flash (Sector de Arranque)... ";
				PIC32MXFunctions.UpdateStatusWinText(dispText3);
				if (!PIC32MXFunctions.PEBlankCheck(532676608U, (uint) (num2 * num4)))
				{
					string dispText4 = "Area Boot no está borrada!";
					PIC32MXFunctions.UpdateStatusWinText(dispText4);
					ProgCommand.RunScript(1, 1);
					return false;
				}
				else
				{
					string dispText4 = dispText3 + "Bits ID's y de Configuración...";
					PIC32MXFunctions.UpdateStatusWinText(dispText4);
					if (!PIC32MXFunctions.PEBlankCheck((uint) (532676608 + num2 * num4), 16U))
					{
						string dispText5 = "Config+ID no está borrado!";
						PIC32MXFunctions.UpdateStatusWinText(dispText5);
						ProgCommand.RunScript(1, 1);
						return false;
					}
					else
					{
						ProgCommand.RunScript(1, 1);
						string dispText5 = "El Dispoditivo está Borrado!";
						PIC32MXFunctions.UpdateStatusWinText(dispText5);
						return true;
					}
				}
			}
		}

		public static bool P32Write(bool verifyWrite, bool codeProtect)
		{
			ProgCommand.SetMCLRTemp(true);
			ProgCommand.VddOn();
			ProgCommand.RunScript(0, 1);
			ProgCommand.RunScript(22, 1);
			if (!PIC32MXFunctions.PE_DownloadAndConnect())
				return false;
			ProgCommand.RunScript(22, 1);
			string dispText1 = "Programando Dispositivo...\n";
			PIC32MXFunctions.UpdateStatusWinText(dispText1);
			string dispText2 = dispText1 + "Programando Flash... ";
			PIC32MXFunctions.UpdateStatusWinText(dispText2);
			int num1 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem;
			int num2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BootFlash;
			int num3 = num1 - num2;
			int num4 = 128;
			int lastUsedInBuffer1 = ProgCommand.FindLastUsedInBuffer(ProgCommand.DeviceBuffers.ProgramMemory, ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue, num3 - 1);
			int num5 = (lastUsedInBuffer1 + 1) / num4;
			if ((lastUsedInBuffer1 + 1) % num4 > 0)
				++num5;
			if (num5 < 2)
				num5 = 2;
			PIC32MXFunctions.ResetStatusBar(lastUsedInBuffer1 / num4);
			PIC32MXFunctions.PEProgramHeader(486539264U, (uint) (num5 * 512));
			int index1 = 0;
			PIC32MXFunctions.PEProgramSendBlock(index1, false);
			int num6 = num5 - 1;
			PIC32MXFunctions.StepStatusBar();
			do
			{
				index1 += num4;
				PIC32MXFunctions.PEProgramSendBlock(index1, true);
				PIC32MXFunctions.StepStatusBar();
			}
			while (--num6 > 0);
			byte[] commandList1 = new byte[4];
			int num7 = 0;
			byte[] numArray1 = commandList1;
			int index2 = num7;
			int num8 = 1;
			int num9 = index2 + num8;
			int num10 = 169;
			numArray1[index2] = (byte) num10;
			byte[] numArray2 = commandList1;
			int index3 = num9;
			int num11 = 1;
			int num12 = index3 + num11;
			int num13 = 166;
			numArray2[index3] = (byte) num13;
			byte[] numArray3 = commandList1;
			int index4 = num12;
			int num14 = 1;
			int num15 = index4 + num14;
			int num16 = 1;
			numArray3[index4] = (byte) num16;
			byte[] numArray4 = commandList1;
			int index5 = num15;
			int num17 = 1;
			int num18 = index5 + num17;
			int num19 = 181;
			numArray4[index5] = (byte) num19;
			ProgCommand.writeUSB(commandList1);
			string dispText3 = dispText2 + "Programando Area Boot (Arranque)... ";
			PIC32MXFunctions.UpdateStatusWinText(dispText3);
			int num20 = 128;
			int lastUsedInBuffer2 = ProgCommand.FindLastUsedInBuffer(ProgCommand.DeviceBuffers.ProgramMemory, ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BlankValue, ProgCommand.DeviceBuffers.ProgramMemory.Length - 1);
			int num21 = lastUsedInBuffer2 >= num3 ? lastUsedInBuffer2 - num3 : 1;
			int num22 = (num21 + 1) / num20;
			if ((num21 + 1) % num20 > 0)
				++num22;
			if (num22 < 2)
				num22 = 2;
			PIC32MXFunctions.ResetStatusBar(num21 / num20);
			PIC32MXFunctions.PEProgramHeader(532676608U, (uint) (num22 * 512));
			int index6 = num3;
			PIC32MXFunctions.PEProgramSendBlock(index6, false);
			int num23 = num22 - 1;
			PIC32MXFunctions.StepStatusBar();
			do
			{
				index6 += num20;
				PIC32MXFunctions.PEProgramSendBlock(index6, true);
				PIC32MXFunctions.StepStatusBar();
			}
			while (--num23 > 0);
			ProgCommand.writeUSB(commandList1);
			string dispText4 = dispText3 + "Bits ID's y de Configuración...";
			PIC32MXFunctions.UpdateStatusWinText(dispText4);
			uint[] numArray5 = new uint[4];
			numArray5[0] = ProgCommand.DeviceBuffers.UserIDs[0] & (uint) byte.MaxValue;
			numArray5[0] |= (uint) (((int) ProgCommand.DeviceBuffers.UserIDs[1] & (int) byte.MaxValue) << 8);
			numArray5[0] |= 4294901760U;
			numArray5[1] = ProgCommand.DeviceBuffers.ConfigWords[0] | ProgCommand.DeviceBuffers.ConfigWords[1] << 16;
			numArray5[1] |= (uint) ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[0] | ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[1]) << 16);
			numArray5[2] = ProgCommand.DeviceBuffers.ConfigWords[2] | ProgCommand.DeviceBuffers.ConfigWords[3] << 16;
			numArray5[2] |= (uint) ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[2] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[2] | ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[3] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[3]) << 16);
			numArray5[3] = ProgCommand.DeviceBuffers.ConfigWords[4] | ProgCommand.DeviceBuffers.ConfigWords[5] << 16;
			numArray5[3] |= (uint) ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[4] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[4] | ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[5] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[5]) << 16);
			if (codeProtect)
				numArray5[3] &= (uint) ~((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask << 16);
			uint num24 = (uint) (532676608 + num2 * 4);
			byte[] commandList2 = new byte[39];
			int num25 = 0;
			byte[] numArray6 = commandList2;
			int index7 = num25;
			int num26 = 1;
			int num27 = index7 + num26;
			int num28 = 169;
			numArray6[index7] = (byte) num28;
			byte[] numArray7 = commandList2;
			int index8 = num27;
			int num29 = 1;
			int num30 = index8 + num29;
			int num31 = 166;
			numArray7[index8] = (byte) num31;
			byte[] numArray8 = commandList2;
			int index9 = num30;
			int num32 = 1;
			int num33 = index9 + num32;
			int num34 = 36;
			numArray8[index9] = (byte) num34;
			byte[] numArray9 = commandList2;
			int index10 = num33;
			int num35 = 1;
			int num36 = index10 + num35;
			int num37 = 187;
			numArray9[index10] = (byte) num37;
			byte[] numArray10 = commandList2;
			int index11 = num36;
			int num38 = 1;
			int num39 = index11 + num38;
			int num40 = 14;
			numArray10[index11] = (byte) num40;
			byte[] numArray11 = commandList2;
			int index12 = num39;
			int num41 = 1;
			int num42 = index12 + num41;
			int num43 = 184;
			numArray11[index12] = (byte) num43;
			byte[] numArray12 = commandList2;
			int index13 = num42;
			int num44 = 1;
			int num45 = index13 + num44;
			int num46 = 0;
			numArray12[index13] = (byte) num46;
			byte[] numArray13 = commandList2;
			int index14 = num45;
			int num47 = 1;
			int num48 = index14 + num47;
			int num49 = 0;
			numArray13[index14] = (byte) num49;
			byte[] numArray14 = commandList2;
			int index15 = num48;
			int num50 = 1;
			int num51 = index15 + num50;
			int num52 = 3;
			numArray14[index15] = (byte) num52;
			byte[] numArray15 = commandList2;
			int index16 = num51;
			int num53 = 1;
			int num54 = index16 + num53;
			int num55 = 0;
			numArray15[index16] = (byte) num55;
			byte[] numArray16 = commandList2;
			int index17 = num54;
			int num56 = 1;
			int num57 = index17 + num56;
			int num58 = 184;
			numArray16[index17] = (byte) num58;
			byte[] numArray17 = commandList2;
			int index18 = num57;
			int num59 = 1;
			int num60 = index18 + num59;
			int num61 = (int) (byte) (num24 & (uint) byte.MaxValue);
			numArray17[index18] = (byte) num61;
			byte[] numArray18 = commandList2;
			int index19 = num60;
			int num62 = 1;
			int num63 = index19 + num62;
			int num64 = (int) (byte) (num24 >> 8 & (uint) byte.MaxValue);
			numArray18[index19] = (byte) num64;
			byte[] numArray19 = commandList2;
			int index20 = num63;
			int num65 = 1;
			int num66 = index20 + num65;
			int num67 = (int) (byte) (num24 >> 16 & (uint) byte.MaxValue);
			numArray19[index20] = (byte) num67;
			byte[] numArray20 = commandList2;
			int index21 = num66;
			int num68 = 1;
			int num69 = index21 + num68;
			int num70 = (int) (byte) (num24 >> 24 & (uint) byte.MaxValue);
			numArray20[index21] = (byte) num70;
			byte[] numArray21 = commandList2;
			int index22 = num69;
			int num71 = 1;
			int num72 = index22 + num71;
			int num73 = 184;
			numArray21[index22] = (byte) num73;
			byte[] numArray22 = commandList2;
			int index23 = num72;
			int num74 = 1;
			int num75 = index23 + num74;
			int num76 = (int) (byte) (numArray5[0] & (uint) byte.MaxValue);
			numArray22[index23] = (byte) num76;
			byte[] numArray23 = commandList2;
			int index24 = num75;
			int num77 = 1;
			int num78 = index24 + num77;
			int num79 = (int) (byte) (numArray5[0] >> 8 & (uint) byte.MaxValue);
			numArray23[index24] = (byte) num79;
			byte[] numArray24 = commandList2;
			int index25 = num78;
			int num80 = 1;
			int num81 = index25 + num80;
			int num82 = (int) (byte) (numArray5[0] >> 16 & (uint) byte.MaxValue);
			numArray24[index25] = (byte) num82;
			byte[] numArray25 = commandList2;
			int index26 = num81;
			int num83 = 1;
			int num84 = index26 + num83;
			int num85 = (int) (byte) (numArray5[0] >> 24 & (uint) byte.MaxValue);
			numArray25[index26] = (byte) num85;
			byte[] numArray26 = commandList2;
			int index27 = num84;
			int num86 = 1;
			int num87 = index27 + num86;
			int num88 = 180;
			numArray26[index27] = (byte) num88;
			uint num89 = num24 + 4U;
			byte[] numArray27 = commandList2;
			int index28 = num87;
			int num90 = 1;
			int num91 = index28 + num90;
			int num92 = 187;
			numArray27[index28] = (byte) num92;
			byte[] numArray28 = commandList2;
			int index29 = num91;
			int num93 = 1;
			int num94 = index29 + num93;
			int num95 = 14;
			numArray28[index29] = (byte) num95;
			byte[] numArray29 = commandList2;
			int index30 = num94;
			int num96 = 1;
			int num97 = index30 + num96;
			int num98 = 184;
			numArray29[index30] = (byte) num98;
			byte[] numArray30 = commandList2;
			int index31 = num97;
			int num99 = 1;
			int num100 = index31 + num99;
			int num101 = 0;
			numArray30[index31] = (byte) num101;
			byte[] numArray31 = commandList2;
			int index32 = num100;
			int num102 = 1;
			int num103 = index32 + num102;
			int num104 = 0;
			numArray31[index32] = (byte) num104;
			byte[] numArray32 = commandList2;
			int index33 = num103;
			int num105 = 1;
			int num106 = index33 + num105;
			int num107 = 3;
			numArray32[index33] = (byte) num107;
			byte[] numArray33 = commandList2;
			int index34 = num106;
			int num108 = 1;
			int num109 = index34 + num108;
			int num110 = 0;
			numArray33[index34] = (byte) num110;
			byte[] numArray34 = commandList2;
			int index35 = num109;
			int num111 = 1;
			int num112 = index35 + num111;
			int num113 = 184;
			numArray34[index35] = (byte) num113;
			byte[] numArray35 = commandList2;
			int index36 = num112;
			int num114 = 1;
			int num115 = index36 + num114;
			int num116 = (int) (byte) (num89 & (uint) byte.MaxValue);
			numArray35[index36] = (byte) num116;
			byte[] numArray36 = commandList2;
			int index37 = num115;
			int num117 = 1;
			int num118 = index37 + num117;
			int num119 = (int) (byte) (num89 >> 8 & (uint) byte.MaxValue);
			numArray36[index37] = (byte) num119;
			byte[] numArray37 = commandList2;
			int index38 = num118;
			int num120 = 1;
			int num121 = index38 + num120;
			int num122 = (int) (byte) (num89 >> 16 & (uint) byte.MaxValue);
			numArray37[index38] = (byte) num122;
			byte[] numArray38 = commandList2;
			int index39 = num121;
			int num123 = 1;
			int num124 = index39 + num123;
			int num125 = (int) (byte) (num89 >> 24 & (uint) byte.MaxValue);
			numArray38[index39] = (byte) num125;
			byte[] numArray39 = commandList2;
			int index40 = num124;
			int num126 = 1;
			int num127 = index40 + num126;
			int num128 = 184;
			numArray39[index40] = (byte) num128;
			byte[] numArray40 = commandList2;
			int index41 = num127;
			int num129 = 1;
			int num130 = index41 + num129;
			int num131 = (int) (byte) (numArray5[1] & (uint) byte.MaxValue);
			numArray40[index41] = (byte) num131;
			byte[] numArray41 = commandList2;
			int index42 = num130;
			int num132 = 1;
			int num133 = index42 + num132;
			int num134 = (int) (byte) (numArray5[1] >> 8 & (uint) byte.MaxValue);
			numArray41[index42] = (byte) num134;
			byte[] numArray42 = commandList2;
			int index43 = num133;
			int num135 = 1;
			int num136 = index43 + num135;
			int num137 = (int) (byte) (numArray5[1] >> 16 & (uint) byte.MaxValue);
			numArray42[index43] = (byte) num137;
			byte[] numArray43 = commandList2;
			int index44 = num136;
			int num138 = 1;
			int num139 = index44 + num138;
			int num140 = (int) (byte) (numArray5[1] >> 24 & (uint) byte.MaxValue);
			numArray43[index44] = (byte) num140;
			byte[] numArray44 = commandList2;
			int index45 = num139;
			int num141 = 1;
			num18 = index45 + num141;
			int num142 = 180;
			numArray44[index45] = (byte) num142;
			uint num143 = num89 + 4U;
			ProgCommand.writeUSB(commandList2);
			int num144 = 0;
			byte[] numArray45 = commandList2;
			int index46 = num144;
			int num145 = 1;
			int num146 = index46 + num145;
			int num147 = 169;
			numArray45[index46] = (byte) num147;
			byte[] numArray46 = commandList2;
			int index47 = num146;
			int num148 = 1;
			int num149 = index47 + num148;
			int num150 = 166;
			numArray46[index47] = (byte) num150;
			byte[] numArray47 = commandList2;
			int index48 = num149;
			int num151 = 1;
			int num152 = index48 + num151;
			int num153 = 36;
			numArray47[index48] = (byte) num153;
			byte[] numArray48 = commandList2;
			int index49 = num152;
			int num154 = 1;
			int num155 = index49 + num154;
			int num156 = 187;
			numArray48[index49] = (byte) num156;
			byte[] numArray49 = commandList2;
			int index50 = num155;
			int num157 = 1;
			int num158 = index50 + num157;
			int num159 = 14;
			numArray49[index50] = (byte) num159;
			byte[] numArray50 = commandList2;
			int index51 = num158;
			int num160 = 1;
			int num161 = index51 + num160;
			int num162 = 184;
			numArray50[index51] = (byte) num162;
			byte[] numArray51 = commandList2;
			int index52 = num161;
			int num163 = 1;
			int num164 = index52 + num163;
			int num165 = 0;
			numArray51[index52] = (byte) num165;
			byte[] numArray52 = commandList2;
			int index53 = num164;
			int num166 = 1;
			int num167 = index53 + num166;
			int num168 = 0;
			numArray52[index53] = (byte) num168;
			byte[] numArray53 = commandList2;
			int index54 = num167;
			int num169 = 1;
			int num170 = index54 + num169;
			int num171 = 3;
			numArray53[index54] = (byte) num171;
			byte[] numArray54 = commandList2;
			int index55 = num170;
			int num172 = 1;
			int num173 = index55 + num172;
			int num174 = 0;
			numArray54[index55] = (byte) num174;
			byte[] numArray55 = commandList2;
			int index56 = num173;
			int num175 = 1;
			int num176 = index56 + num175;
			int num177 = 184;
			numArray55[index56] = (byte) num177;
			byte[] numArray56 = commandList2;
			int index57 = num176;
			int num178 = 1;
			int num179 = index57 + num178;
			int num180 = (int) (byte) (num143 & (uint) byte.MaxValue);
			numArray56[index57] = (byte) num180;
			byte[] numArray57 = commandList2;
			int index58 = num179;
			int num181 = 1;
			int num182 = index58 + num181;
			int num183 = (int) (byte) (num143 >> 8 & (uint) byte.MaxValue);
			numArray57[index58] = (byte) num183;
			byte[] numArray58 = commandList2;
			int index59 = num182;
			int num184 = 1;
			int num185 = index59 + num184;
			int num186 = (int) (byte) (num143 >> 16 & (uint) byte.MaxValue);
			numArray58[index59] = (byte) num186;
			byte[] numArray59 = commandList2;
			int index60 = num185;
			int num187 = 1;
			int num188 = index60 + num187;
			int num189 = (int) (byte) (num143 >> 24 & (uint) byte.MaxValue);
			numArray59[index60] = (byte) num189;
			byte[] numArray60 = commandList2;
			int index61 = num188;
			int num190 = 1;
			int num191 = index61 + num190;
			int num192 = 184;
			numArray60[index61] = (byte) num192;
			byte[] numArray61 = commandList2;
			int index62 = num191;
			int num193 = 1;
			int num194 = index62 + num193;
			int num195 = (int) (byte) (numArray5[2] & (uint) byte.MaxValue);
			numArray61[index62] = (byte) num195;
			byte[] numArray62 = commandList2;
			int index63 = num194;
			int num196 = 1;
			int num197 = index63 + num196;
			int num198 = (int) (byte) (numArray5[2] >> 8 & (uint) byte.MaxValue);
			numArray62[index63] = (byte) num198;
			byte[] numArray63 = commandList2;
			int index64 = num197;
			int num199 = 1;
			int num200 = index64 + num199;
			int num201 = (int) (byte) (numArray5[2] >> 16 & (uint) byte.MaxValue);
			numArray63[index64] = (byte) num201;
			byte[] numArray64 = commandList2;
			int index65 = num200;
			int num202 = 1;
			int num203 = index65 + num202;
			int num204 = (int) (byte) (numArray5[2] >> 24 & (uint) byte.MaxValue);
			numArray64[index65] = (byte) num204;
			byte[] numArray65 = commandList2;
			int index66 = num203;
			int num205 = 1;
			int num206 = index66 + num205;
			int num207 = 180;
			numArray65[index66] = (byte) num207;
			uint num208 = num143 + 4U;
			byte[] numArray66 = commandList2;
			int index67 = num206;
			int num209 = 1;
			int num210 = index67 + num209;
			int num211 = 187;
			numArray66[index67] = (byte) num211;
			byte[] numArray67 = commandList2;
			int index68 = num210;
			int num212 = 1;
			int num213 = index68 + num212;
			int num214 = 14;
			numArray67[index68] = (byte) num214;
			byte[] numArray68 = commandList2;
			int index69 = num213;
			int num215 = 1;
			int num216 = index69 + num215;
			int num217 = 184;
			numArray68[index69] = (byte) num217;
			byte[] numArray69 = commandList2;
			int index70 = num216;
			int num218 = 1;
			int num219 = index70 + num218;
			int num220 = 0;
			numArray69[index70] = (byte) num220;
			byte[] numArray70 = commandList2;
			int index71 = num219;
			int num221 = 1;
			int num222 = index71 + num221;
			int num223 = 0;
			numArray70[index71] = (byte) num223;
			byte[] numArray71 = commandList2;
			int index72 = num222;
			int num224 = 1;
			int num225 = index72 + num224;
			int num226 = 3;
			numArray71[index72] = (byte) num226;
			byte[] numArray72 = commandList2;
			int index73 = num225;
			int num227 = 1;
			int num228 = index73 + num227;
			int num229 = 0;
			numArray72[index73] = (byte) num229;
			byte[] numArray73 = commandList2;
			int index74 = num228;
			int num230 = 1;
			int num231 = index74 + num230;
			int num232 = 184;
			numArray73[index74] = (byte) num232;
			byte[] numArray74 = commandList2;
			int index75 = num231;
			int num233 = 1;
			int num234 = index75 + num233;
			int num235 = (int) (byte) (num208 & (uint) byte.MaxValue);
			numArray74[index75] = (byte) num235;
			byte[] numArray75 = commandList2;
			int index76 = num234;
			int num236 = 1;
			int num237 = index76 + num236;
			int num238 = (int) (byte) (num208 >> 8 & (uint) byte.MaxValue);
			numArray75[index76] = (byte) num238;
			byte[] numArray76 = commandList2;
			int index77 = num237;
			int num239 = 1;
			int num240 = index77 + num239;
			int num241 = (int) (byte) (num208 >> 16 & (uint) byte.MaxValue);
			numArray76[index77] = (byte) num241;
			byte[] numArray77 = commandList2;
			int index78 = num240;
			int num242 = 1;
			int num243 = index78 + num242;
			int num244 = (int) (byte) (num208 >> 24 & (uint) byte.MaxValue);
			numArray77[index78] = (byte) num244;
			byte[] numArray78 = commandList2;
			int index79 = num243;
			int num245 = 1;
			int num246 = index79 + num245;
			int num247 = 184;
			numArray78[index79] = (byte) num247;
			byte[] numArray79 = commandList2;
			int index80 = num246;
			int num248 = 1;
			int num249 = index80 + num248;
			int num250 = (int) (byte) (numArray5[3] & (uint) byte.MaxValue);
			numArray79[index80] = (byte) num250;
			byte[] numArray80 = commandList2;
			int index81 = num249;
			int num251 = 1;
			int num252 = index81 + num251;
			int num253 = (int) (byte) (numArray5[3] >> 8 & (uint) byte.MaxValue);
			numArray80[index81] = (byte) num253;
			byte[] numArray81 = commandList2;
			int index82 = num252;
			int num254 = 1;
			int num255 = index82 + num254;
			int num256 = (int) (byte) (numArray5[3] >> 16 & (uint) byte.MaxValue);
			numArray81[index82] = (byte) num256;
			byte[] numArray82 = commandList2;
			int index83 = num255;
			int num257 = 1;
			int num258 = index83 + num257;
			int num259 = (int) (byte) (numArray5[3] >> 24 & (uint) byte.MaxValue);
			numArray82[index83] = (byte) num259;
			byte[] numArray83 = commandList2;
			int index84 = num258;
			int num260 = 1;
			num18 = index84 + num260;
			int num261 = 180;
			numArray83[index84] = (byte) num261;
			uint num262 = num208 + 4U;
			ProgCommand.writeUSB(commandList2);
			if (verifyWrite)
				return PIC32MXFunctions.P32Verify(true, codeProtect);
			ProgCommand.RunScript(1, 1);
			return true;
		}

		private static void PEProgramHeader(uint startAddress, uint lengthBytes)
		{
			byte[] commandList = new byte[20];
			int num1 = 0;
			byte[] numArray1 = commandList;
			int index1 = num1;
			int num2 = 1;
			int num3 = index1 + num2;
			int num4 = 169;
			numArray1[index1] = (byte) num4;
			byte[] numArray2 = commandList;
			int index2 = num3;
			int num5 = 1;
			int num6 = index2 + num5;
			int num7 = 166;
			numArray2[index2] = (byte) num7;
			byte[] numArray3 = commandList;
			int index3 = num6;
			int num8 = 1;
			int num9 = index3 + num8;
			int num10 = 17;
			numArray3[index3] = (byte) num10;
			byte[] numArray4 = commandList;
			int index4 = num9;
			int num11 = 1;
			int num12 = index4 + num11;
			int num13 = 187;
			numArray4[index4] = (byte) num13;
			byte[] numArray5 = commandList;
			int index5 = num12;
			int num14 = 1;
			int num15 = index5 + num14;
			int num16 = 14;
			numArray5[index5] = (byte) num16;
			byte[] numArray6 = commandList;
			int index6 = num15;
			int num17 = 1;
			int num18 = index6 + num17;
			int num19 = 184;
			numArray6[index6] = (byte) num19;
			byte[] numArray7 = commandList;
			int index7 = num18;
			int num20 = 1;
			int num21 = index7 + num20;
			int num22 = 0;
			numArray7[index7] = (byte) num22;
			byte[] numArray8 = commandList;
			int index8 = num21;
			int num23 = 1;
			int num24 = index8 + num23;
			int num25 = 0;
			numArray8[index8] = (byte) num25;
			byte[] numArray9 = commandList;
			int index9 = num24;
			int num26 = 1;
			int num27 = index9 + num26;
			int num28 = 2;
			numArray9[index9] = (byte) num28;
			byte[] numArray10 = commandList;
			int index10 = num27;
			int num29 = 1;
			int num30 = index10 + num29;
			int num31 = 0;
			numArray10[index10] = (byte) num31;
			byte[] numArray11 = commandList;
			int index11 = num30;
			int num32 = 1;
			int num33 = index11 + num32;
			int num34 = 184;
			numArray11[index11] = (byte) num34;
			byte[] numArray12 = commandList;
			int index12 = num33;
			int num35 = 1;
			int num36 = index12 + num35;
			int num37 = (int) (byte) (startAddress & (uint) byte.MaxValue);
			numArray12[index12] = (byte) num37;
			byte[] numArray13 = commandList;
			int index13 = num36;
			int num38 = 1;
			int num39 = index13 + num38;
			int num40 = (int) (byte) (startAddress >> 8 & (uint) byte.MaxValue);
			numArray13[index13] = (byte) num40;
			byte[] numArray14 = commandList;
			int index14 = num39;
			int num41 = 1;
			int num42 = index14 + num41;
			int num43 = (int) (byte) (startAddress >> 16 & (uint) byte.MaxValue);
			numArray14[index14] = (byte) num43;
			byte[] numArray15 = commandList;
			int index15 = num42;
			int num44 = 1;
			int num45 = index15 + num44;
			int num46 = (int) (byte) (startAddress >> 24 & (uint) byte.MaxValue);
			numArray15[index15] = (byte) num46;
			byte[] numArray16 = commandList;
			int index16 = num45;
			int num47 = 1;
			int num48 = index16 + num47;
			int num49 = 184;
			numArray16[index16] = (byte) num49;
			byte[] numArray17 = commandList;
			int index17 = num48;
			int num50 = 1;
			int num51 = index17 + num50;
			int num52 = (int) (byte) (lengthBytes & (uint) byte.MaxValue);
			numArray17[index17] = (byte) num52;
			byte[] numArray18 = commandList;
			int index18 = num51;
			int num53 = 1;
			int num54 = index18 + num53;
			int num55 = (int) (byte) (lengthBytes >> 8 & (uint) byte.MaxValue);
			numArray18[index18] = (byte) num55;
			byte[] numArray19 = commandList;
			int index19 = num54;
			int num56 = 1;
			int num57 = index19 + num56;
			int num58 = (int) (byte) (lengthBytes >> 16 & (uint) byte.MaxValue);
			numArray19[index19] = (byte) num58;
			byte[] numArray20 = commandList;
			int index20 = num57;
			int num59 = 1;
			int num60 = index20 + num59;
			int num61 = (int) (byte) (lengthBytes >> 24 & (uint) byte.MaxValue);
			numArray20[index20] = (byte) num61;
			ProgCommand.writeUSB(commandList);
		}

		private static void PEProgramSendBlock(int index, bool peResp)
		{
			byte[] dataArray = new byte[256];
			int num1 = 0;
			int length = ProgCommand.DeviceBuffers.ProgramMemory.Length;
			for (int index1 = 0; index1 < 64; ++index1)
			{
				uint num2 = index >= length ? uint.MaxValue : ProgCommand.DeviceBuffers.ProgramMemory[index++];
				byte[] numArray1 = dataArray;
				int index2 = num1;
				int num3 = 1;
				int num4 = index2 + num3;
				int num5 = (int) (byte) (num2 & (uint) byte.MaxValue);
				numArray1[index2] = (byte) num5;
				byte[] numArray2 = dataArray;
				int index3 = num4;
				int num6 = 1;
				int num7 = index3 + num6;
				int num8 = (int) (byte) (num2 >> 8 & (uint) byte.MaxValue);
				numArray2[index3] = (byte) num8;
				byte[] numArray3 = dataArray;
				int index4 = num7;
				int num9 = 1;
				int num10 = index4 + num9;
				int num11 = (int) (byte) (num2 >> 16 & (uint) byte.MaxValue);
				numArray3[index4] = (byte) num11;
				byte[] numArray4 = dataArray;
				int index5 = num10;
				int num12 = 1;
				num1 = index5 + num12;
				int num13 = (int) (byte) (num2 >> 24 & (uint) byte.MaxValue);
				numArray4[index5] = (byte) num13;
			}
			int startIndex1 = ProgCommand.DataClrAndDownload(dataArray, 0);
			while (num1 - startIndex1 > 62)
				startIndex1 = ProgCommand.DataDownload(dataArray, startIndex1, dataArray.Length);
			int num14 = num1 - startIndex1;
			byte[] commandList = new byte[5 + num14];
			int num15 = 0;
			byte[] numArray5 = commandList;
			int index6 = num15;
			int num16 = 1;
			int num17 = index6 + num16;
			int num18 = 168;
			numArray5[index6] = (byte) num18;
			byte[] numArray6 = commandList;
			int index7 = num17;
			int num19 = 1;
			int num20 = index7 + num19;
			int num21 = (int) (byte) (num14 & (int) byte.MaxValue);
			numArray6[index7] = (byte) num21;
			for (int index1 = 0; index1 < num14; ++index1)
				commandList[num20++] = dataArray[startIndex1 + index1];
			byte[] numArray7 = commandList;
			int index8 = num20;
			int num22 = 1;
			int num23 = index8 + num22;
			int num24 = 165;
			numArray7[index8] = (byte) num24;
			byte[] numArray8 = commandList;
			int index9 = num23;
			int num25 = 1;
			int num26 = index9 + num25;
			int num27 = 6;
			numArray8[index9] = (byte) num27;
			byte[] numArray9 = commandList;
			int index10 = num26;
			int num28 = 1;
			int num29 = index10 + num28;
			int num30 = 1;
			numArray9[index10] = (byte) num30;
			ProgCommand.writeUSB(commandList);
			int num31 = 0;
			for (int index1 = 0; index1 < 64; ++index1)
			{
				uint num2 = index >= length ? uint.MaxValue : ProgCommand.DeviceBuffers.ProgramMemory[index++];
				byte[] numArray1 = dataArray;
				int index2 = num31;
				int num3 = 1;
				int num4 = index2 + num3;
				int num5 = (int) (byte) (num2 & (uint) byte.MaxValue);
				numArray1[index2] = (byte) num5;
				byte[] numArray2 = dataArray;
				int index3 = num4;
				int num6 = 1;
				int num7 = index3 + num6;
				int num8 = (int) (byte) (num2 >> 8 & (uint) byte.MaxValue);
				numArray2[index3] = (byte) num8;
				byte[] numArray3 = dataArray;
				int index4 = num7;
				int num9 = 1;
				int num10 = index4 + num9;
				int num11 = (int) (byte) (num2 >> 16 & (uint) byte.MaxValue);
				numArray3[index4] = (byte) num11;
				byte[] numArray4 = dataArray;
				int index5 = num10;
				int num12 = 1;
				num31 = index5 + num12;
				int num13 = (int) (byte) (num2 >> 24 & (uint) byte.MaxValue);
				numArray4[index5] = (byte) num13;
			}
			int startIndex2 = ProgCommand.DataClrAndDownload(dataArray, 0);
			while (num31 - startIndex2 > 62)
				startIndex2 = ProgCommand.DataDownload(dataArray, startIndex2, dataArray.Length);
			int num32 = num31 - startIndex2;
			int num33 = 0;
			byte[] numArray10 = commandList;
			int index11 = num33;
			int num34 = 1;
			int num35 = index11 + num34;
			int num36 = 168;
			numArray10[index11] = (byte) num36;
			byte[] numArray11 = commandList;
			int index12 = num35;
			int num37 = 1;
			int num38 = index12 + num37;
			int num39 = (int) (byte) (num32 & (int) byte.MaxValue);
			numArray11[index12] = (byte) num39;
			for (int index1 = 0; index1 < num32; ++index1)
				commandList[num38++] = dataArray[startIndex2 + index1];
			byte[] numArray12 = commandList;
			int index13 = num38;
			int num40 = 1;
			int num41 = index13 + num40;
			int num42 = 165;
			numArray12[index13] = (byte) num42;
			int num43;
			if (peResp)
			{
				byte[] numArray1 = commandList;
				int index1 = num41;
				int num2 = 1;
				num43 = index1 + num2;
				int num3 = 7;
				numArray1[index1] = (byte) num3;
			}
			else
			{
				byte[] numArray1 = commandList;
				int index1 = num41;
				int num2 = 1;
				num43 = index1 + num2;
				int num3 = 6;
				numArray1[index1] = (byte) num3;
			}
			byte[] numArray13 = commandList;
			int index14 = num43;
			int num44 = 1;
			num29 = index14 + num44;
			int num45 = 1;
			numArray13[index14] = (byte) num45;
			ProgCommand.writeUSB(commandList);
		}

		public static bool P32Verify(bool writeVerify, bool codeProtect)
		{
			if (!writeVerify)
			{
				ProgCommand.SetMCLRTemp(true);
				ProgCommand.VddOn();
				if (!PIC32MXFunctions.PE_DownloadAndConnect())
					return false;
			}
			string dispText1 = "Verificando Escritura...\n";
			PIC32MXFunctions.UpdateStatusWinText(dispText1);
			int num1 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ProgramMem;
			int num2 = (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].BootFlash;
			int num3 = num1 - num2;
			int num4 = (int) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
			string dispText2 = dispText1 + "Programando Flash... ";
			PIC32MXFunctions.UpdateStatusWinText(dispText2);
			if (PIC32MXFunctions.p32CRC_buf(ProgCommand.DeviceBuffers.ProgramMemory, 0U, (uint) num3) != PIC32MXFunctions.PEGetCRC(486539264U, (uint) (num3 * num4)))
			{
				if (writeVerify)
				{
					string dispText3 = "Error al programar memoria Flash!";
					PIC32MXFunctions.UpdateStatusWinText(dispText3);
				}
				else
				{
					string dispText3 = "Error de verificación de Flash!";
					PIC32MXFunctions.UpdateStatusWinText(dispText3);
				}
				ProgCommand.RunScript(1, 1);
				return false;
			}
			else
			{
				string dispText3 = dispText2 + "Programando sector Boot Flash... ";
				PIC32MXFunctions.UpdateStatusWinText(dispText3);
				if (PIC32MXFunctions.p32CRC_buf(ProgCommand.DeviceBuffers.ProgramMemory, (uint) num3, (uint) num2) != PIC32MXFunctions.PEGetCRC(532676608U, (uint) (num2 * num4)))
				{
					if (writeVerify)
					{
						string dispText4 = "Error al Escribir el Sector de Arranque (Boot)!";
						PIC32MXFunctions.UpdateStatusWinText(dispText4);
					}
					else
					{
						string dispText4 = "Error al Verificar el Sector de Arranque (Boot)!";
						PIC32MXFunctions.UpdateStatusWinText(dispText4);
					}
					ProgCommand.RunScript(1, 1);
					return false;
				}
				else
				{
					string dispText4 = dispText3 + "Bits Config+ID + ";
					PIC32MXFunctions.UpdateStatusWinText(dispText4);
					uint[] buffer = new uint[4];
					buffer[0] = ProgCommand.DeviceBuffers.UserIDs[0] & (uint) byte.MaxValue;
					buffer[0] |= (uint) (((int) ProgCommand.DeviceBuffers.UserIDs[1] & (int) byte.MaxValue) << 8);
					buffer[0] |= 4294901760U;
					buffer[1] = ProgCommand.DeviceBuffers.ConfigWords[0] | ProgCommand.DeviceBuffers.ConfigWords[1] << 16;
					buffer[1] |= (uint) ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[0] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[0] | ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[1] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[1]) << 16);
					buffer[2] = ProgCommand.DeviceBuffers.ConfigWords[2] | ProgCommand.DeviceBuffers.ConfigWords[3] << 16;
					buffer[2] |= (uint) ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[2] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[2] | ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[3] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[3]) << 16);
					buffer[3] = ProgCommand.DeviceBuffers.ConfigWords[4] | ProgCommand.DeviceBuffers.ConfigWords[5] << 16;
					buffer[3] |= (uint) ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[4] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[4] | ((int) ~ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigMasks[5] & (int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].ConfigBlank[5]) << 16);
					if (codeProtect)
						buffer[3] &= (uint) ~((int) ProgCommand.DevFile.PartsList[ProgCommand.ActivePart].CPMask << 16);
					if (PIC32MXFunctions.p32CRC_buf(buffer, 0U, 4U) != PIC32MXFunctions.PEGetCRC((uint) (532676608 + num2 * num4), (uint) (4 * num4)))
					{
						if (writeVerify)
						{
							string dispText5 = "Error al Escribir los Bits Config+ID!";
							PIC32MXFunctions.UpdateStatusWinText(dispText5);
						}
						else
						{
							string dispText5 = "Error al Verificar los Bits Config+ID!";
							PIC32MXFunctions.UpdateStatusWinText(dispText5);
						}
						ProgCommand.RunScript(1, 1);
						return false;
					}
					else
					{
						if (!writeVerify)
						{
							string dispText5 = "Escritura Correcta.\n";
							PIC32MXFunctions.UpdateStatusWinText(dispText5);
						}
						else
						{
							string dispText5 = "Programación Correcta!\n";
							PIC32MXFunctions.UpdateStatusWinText(dispText5);
						}
						ProgCommand.RunScript(1, 1);
						return true;
					}
				}
			}
		}

		private static int p32CRC_buf(uint[] buffer, uint startIdx, uint len)
		{
			uint num1 = 69665U;
			uint num2 = (uint) ushort.MaxValue;
			uint num3 = (uint) ProgCommand.DevFile.Families[ProgCommand.GetActiveFamily()].BytesPerLocation;
			int length = buffer.Length;
			for (uint index1 = startIdx; index1 < startIdx + len; ++index1)
			{
				uint num4 = buffer[(IntPtr) index1];
				for (uint index2 = 0U; index2 < num3; ++index2)
				{
					uint num5 = (uint) (((int) num4 & (int) byte.MaxValue) << 8);
					num4 >>= 8;
					for (uint index3 = 0U; index3 < 8U; ++index3)
					{
						uint num6 = (uint) (((int) num2 ^ (int) num5) & 32768);
						num2 <<= 1;
						num5 <<= 1;
						if (num6 > 0U)
							num2 ^= num1;
					}
				}
			}
			return (int) num2 & (int) ushort.MaxValue;
		}
	}
}
