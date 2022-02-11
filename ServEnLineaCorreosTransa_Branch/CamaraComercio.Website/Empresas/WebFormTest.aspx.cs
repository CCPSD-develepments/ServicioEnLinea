using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;
using System.Security.Cryptography;
using System.Web.Services.Protocols;
using System.Net;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'WebFormTest'
    public partial class WebFormTest : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'WebFormTest'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'WebFormTest.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'WebFormTest.Page_Load(object, EventArgs)'
        {
            #region .......
            /*

            /*
          
Te cobran impuestos aun después de que dejas de trabajar
La gente que dice: "Trabaja duro, ahorra dinero e invierte en un 401(k)" están trabajando 
para obtener dinero a 50 por ciento. Una vez que te retiras y comienzas a retirar dinero de tu 
plan 401(k), a ese dinero que sale del plan se le cobran impuestos a una taza de ingreso 
ganado, o dinero a 50 por ciento, como lo llamaría mi padre rico. A los intereses de lo 
ahorrado también se le cobran impuestos a una taza de ingreso ganado. Muchas personas 
dicen: "Debo seguir trabajando porque mi ingreso proveniente de la Seguridad Social del 
gobierno no cubre los gastos que tengo para vivir". En el momento en que una persona 
empieza a trabajar para obtener ingreso ganado con el fin de complementar su ingreso de la 
Seguridad  Social, el gobierno no sólo aplica impuestos a su ingreso ganado, sino que 
comienza a reducir los pagos de la Seguridad Social porque tienes un empleo. Cuando mi 
padre rico decía: "La mayoría de las personas planean ser pobres", sabía de qué estaba 
hablando. Conocía las leyes del gobierno con relación al ingreso ganado después del retiro. 
Si no eres pobre y quieres ganar más dinero, el gobierno no te ayudará. A muchas personas 
retiradas simplemente les parece mejor ser pobres y no regresar a trabajar por razones de 
impuestos.
El punto es que, elegir usar las palabras trabaja duro, ahorra dinero e invierte en un 401 (k) 
es elegir usar palabras muy lentas, lo que ocasiona que tengas un plan financiero muy lento. 
Aunque elegir esas palabras en tu plan financiero te puede permitir alcanzar el nivel de las 
personas afluentes de 100 000 a un millón de dólares al año en ingreso de retiro, esas 
mismas palabras en la mayoría de los casos no te permitirán avanzar a los niveles de ingreso 
de los ricos y ultra ricos. Como decía mi padre rico: "Hay más en ser rico que tener mucho 
dinero". Los ricos usan una serie de palabras diferente y esas palabras  los  guían a 
experiencias de vida diferentes... experiencias como aprender a reunir capital en vez de 
ahorrar dinero. Otras palabras son:
Palabras lentas Palabras rápidas
Ahorra dinero Haz dinero
Mi padre rico recomendaba que la mayoría de las personas aprendieran cómo ahorrar dinero. 
Pero él mismo no lo hacía Decía: "Enfocarse en ahorrar dinero consume demasiado de mi 
tiempo y no hay suficiente apalancamiento en ahorrar dinero" Mi padre rico también decía: 
"El dinero que ahorra la mayoría de la gente es dinero que ha quedado después del cobro de 
impuestos". Para que una persona ahorre diez, dólares, la cantidad real ganada era veinte 
dólares porque se trata de ingreso ganado o dinero a 50 por ciento. Además, el interés que 
ganas por tus ahorros también está sujeto a tasas más altas.
En vez de enfocarse en ahorrar dinero, mi padre rico se pasó la vida preparándose en cómo 
hacer dinero. Decía: "Si sabes cómo crear negocios e invertir tu dinero, puedes hacer tanto 
dinero que tu problema sea tener demasiado dinero. Cuando tienes demasiado dinero, tienes 
efectivo en exceso en tu banco en lugar de tener ahorros".
En Guía para invertir de Padre Rico, escribí sobre los dos tipos de problemas de dinero. 
No son carecer de dinero suficiente y tenerlo en exceso. La mayoría de las personas sólo 
conocen el primer problema, el de no tener dinero suficiente.
 Esas personas definitivamente deberían aprender a ahorrar dinero. El plan financiero de mi 
padre era tener dinero en exceso. Su problema era que tenía demasiado dinero en su cuenta de 
ahorros de manera que constantemente estaba buscando inversiones donde mover su exceso 
de dinero. Su realidad o contexto era que el mundo tenía una abundancia de dinero. La reali-dad de mi padre pobre era que el dinero era escaso y por eso luchó toda su vida tratando de 
ahorrar dinero.
¿Cuál es la diferencia entre trabajar por dinero y hacer dinero? Si leíste Padre Rico, Padre 
Pobre es probable que recuerdes la historia de cómo yo escuchaba a mi padre pobre 
(literalmente) y trataba de hacer dinero. Traté de hacer dinero derritiendo el plomo de los 
tubos de dentífrico y luego vaciando monedas de veinticinco, diez y cinco centavos en moldes 
de yeso. Mi padre pobre me tuvo que explicar la diferencia entre hacer dinero y falsificar. Mi 
padre pobre no pudo decirme cómo invertir dinero simplemente porque lo único que sabía 
hacer era Trabajar para ganar dinero. En el mundo real del dinero, mude los ricos se 
vuelven muy ricos haciendo dinero, en lugar de trabajar por dinero. Por ejemplo, Bill Gates 
se volvió el hombre más rico del mundo no trabajando para ganar el dinero, sino haciendo 
dinero. Se convirtió en el hombre más rico del mundo creando una empresa y vendiendo 
acciones de su empresa.
Vender acciones de tu empresa es una forma de hacer dinero. En principio, mientras haya un 
mercado listo de compradores y vendedores para lo que puedas producir, entonces, dentro de 
ese contexto, estás haciendo dinero. Mis libros, por ejemplo, son una forma de hacer dinero. 
Siempre y cuando haya un mercado para ellos a través de vendedores, mis libros me están 
haciendo dinero en vez de que yo esté trabajando por dinero. Si yo fuera un médico que 
tuviera que trabajar personalmente para que le pagaran, sería un médico que trabajaría por 
dinero. Si fuera un médico que inventó una nueva medicina y la vendiera en forma de pastilla 
en las farmacias, la pastilla sería una forma de que el médico hiciera dinero en lugar de 
trabajar por dinero.
En resumen, trabajar por dinero en la mayoría de los casos es lento y encontrar formas de 
hacer dinero puede ser mucho más rápido si sabes lo que estás haciendo. Así que si planeas 
trabajar  por dinero y luego tratar de ahorrar  dinero, entonces puede ser que estés 
empuñando el hacha muy lenta y muy torpe de mamá y papá.
Hay otras palabras que pueden hacer más lenta tu creación de riqueza y hay palabras que 
pueden aumentar la velocidad a la cual haces dinero.
Palabras lentas Palabras rápidas
Apreciación Depreciación
Si no entiendes del todo los términos apreciación y depreciación, no te preocupes. A mí me 
tomó un tiempo entenderlos por completo. Si realmente quieres entenderlos mejor, es 
probable que quieras pedirle a un contador o a un profesional de bienes raíces que te los 
explique. Un breve ejemplo de cómo cada uno de esos términos se aplica a tu plan 
financiero se encuentra a continuación.
El otro día, un programa de televisión presentaba una historia sobre chicos de preparatoria 
que estaban aprendiendo a invertir en la bolsa. Uno de los estudiantes entrevistados dijo: "H 
ice mucho dinero porque compré acciones de la compañía  X y el precio de esas acciones 
aumentó". En otras palabras, estaba jugando a la bolsa en espera de ganancias en bienes de 
capital o de la apreciación de las acciones que había escogido. Cuando la mayoría de las 
personas dice: "Nuestra casa es una  buena inversión", lo dice porque esperan que su casa 
aumente de  valor.
He oído amigos que me han dicho cosas como: "Compré un terreno en este nuevo campo de 
golf. Es una buena inversión y  espero que el terreno duplique su valor en cinco años". Para 
ellos esas ganancias son una buena inversión... y con suerte duplicarán su dinero en cinco 
años.
Mi padre rico nos enseñó a su hijo y a mí a usar palabras diferentes. En lo que se refería a 
comprar cualquier inversión, siempre decía: "Tu ganancia se da cuando compras no cuando 
vendes". En otras palabras, él nunca esperaba que su inversión aumentara de valor. Si lo 
hacía, para él, la apreciación era un extra. Mi padre rico invertía para obtener ganancias 
inmediatas de su inversión o flujo de efectivo. También invertía por una cosa que llamaba 
“fantasma de flujo de efectivo”, léase  depreciación.  Un ejemplo de depreciación de un 
edificio se dio en un capítulo previo. Le encantaban el flujo de efectivo y la depreciación porque 
no tenía que esperar hasta que su inversión aumentara de valor para que él pudiera hacer 
dinero. Solía decir: "Esperar a que una acción o una propiedad de bienes raíces aumente de 
valor es demasiado lento y demasiado arriesgado".
El punto es éste: si estás esperando hacer dinero en algún momento del futuro, tu plan es un 
plan lento porque estás usando palabras lentas, lo que lleva a ideas lentas. Repitiendo lo que 
decía mi padre rico: "Tu ganancia se obtiene cuando compras, no cuando vendes". He 
conocido mucha gente que compra una propiedad de bienes raíces, le pierde dinero cada mes 
y me dice: "Recuperaré mi dinero cuando el valor de la propiedad aumente y la venda".
En Australia, muchas personas compran propiedades, les pierden dinero cada mes y piensan 
que es una buena inversión porque el gobierno les da una reducción de impuestos por 
perder dinero. En mi opinión, ésa es la forma de pensar de un perdedor. Con frecuencia yo 
les pregunto: "¿Por qué no comprar una propiedad que te dé dinero cada mes y tenga una 
reducción de impuestos cada mes?" La respuesta que me dan con frecuencia es: "No, mi 
contador me dijo que buscara una propiedad que me costara dinero cada mes y que ésta me 
diera una reducción de impuestos". Estamos hablando de elegir abordar el tren lento y 
arriesgado en lugar del tren más rápido y de mayores beneficios.
Palabras lentas Palabras rápidas
Evita el riesgo Gana control
Mi padre pobre decía: "Eso es demasiado arriesgado" o "Juega a lo seguro". O "¿Por qué 
correr el riesgo?" Entre más creía en esas ideas, más perdía control sobre su vida financia. 
Al ser un empleado y al jugar a la segura, perdió control sobre sus impuestos. Al decir que 
invertir era arriesgado y que no estaba interesado en el dinero, perdió cada vez más control 
sobre  su educación financiera. Al final, pagó cada vez más impuestos, aunque se retiró, e 
invirtió sólo en inversiones seguras que no fueron a ningún lado o que perdieron dinero.
Tengo un pariente lejano que pasó 25 años en el ejército, se retiró como oficial y hoy se sienta 
frente a la televisión viendo los programas financieros, viendo cómo el valor de sus acciones 
se hunde cada vez más. Cada vez se deprime más simplemente porque no tiene control sobre 
el valor de su portafolio. Un día, vio al presidente de una de las empresas en las que tenía un 
número sustancial de acciones mientras iba en su jet privado, anunciando que todo su 
personal iba a obtener bonos de un millón de dólares. Aunque se unió al coro de furiosos 
accionistas, había muy poco que pudiera hacer.
En Guía para invertir de Padre Rico, escribí sobre los diez controles del inversionista de mi 
padre rico. Esos controles son vitales para cualquiera que desee tener cierto grado de control 
sobre su vida y sobre su futuro. En el presente, mi preocupación es que 90 por ciento de la 
población de Estados Unidos y de muchos otros países occidentales tiene poco control 
sobre su futuro financiero. Ese porcentaje es todavía peor en países en vías de desarrollo. 
Mi padre rico me dijo que debía tener un plan sobre cómo tener cada vez más control sobre 
mi futuro financiero. Dijo: "Para participar como jugador en el carril rápido, lo que cuenta es 
controlar más que dinero". Si te gustaría saber más sobre esos diez controles es probable 
que quieras leer o releer Guía pura invertir de Padre Rico.
Unas últimas palabras sobre riesgo versus control: Mi padre rico decía: "Entre más 
seguridad busca una persona, mayor control cede sobre su vida esa persona". Hoy veo dos 
mundos que están evolucionando. Uno es el mundo que llamo la Sociedad Responsable. Es 
el grupo que cree en ser responsable de sus vidas y del resultado final de sus vidas. Hay 
otro mundo que llamo la Sociedad Víctima, que es el grupo que cree que alguien más, una 
empresa o el gobierno, son responsables de sus vidas. En cualquier grupo, familia o empresa 
siempre hay los dos tipos de sociedades. Ambas ven el mundo desde su propio contexto o 
realidad y ambas piensan que tienen razón. He descubierto que uno de los factores divisorios 
entre las dos sociedades es su visión medular de las ideas sobre riesgo versus control. Las 
víctimas tienden a querer darle el control de su vida a alguien más para evitar correr 
riesgos. Luego se enojan cuando sienten que alguien más abusa del control que ellos le 
confirieron al abusador en primer lugar. En otras palabras, las víctimas con frecuencia son 
víctimas de sí mismas.
En los años venideros, habrá muchas víctimas financieras. Personas que le dieron el control 
a profesionales financieros y mordieron redonditas el anzuelo de sus consejos. Muchas cillas 
víctimas futuras habrán creído el mantra de "Invierte a largo plazo, diversifica, mantente así, 
el mercado ha subido durante los últimos 40 años y juega a la segura". Esas víctimas se 
creyeron esos consejos simplemente porque querían creer en ellos. Si no lograron elegir 
sabiamente a sus asesores, pueden convertirse en víctimas financieras.
Palabras lentas Palabras rápidas
Fondos de inversión                     Regulación D, Regla 506
Hoy, millones y millones de personas están apostando su futuro financiero y su seguridad 
financiera en acciones y fondos de inversión. Hasta yo tengo fondos de inversión en mi plan de 
retiro. Sin embargo, no planeo hacerme rico rápidamente con esos fondos de inversión ni 
estoy contando con ellos para que se encarguen de mí una vez que terminen mis días de trabajo. 
Personalmente, no tengo mucha fe en la bolsa. También me parece que los fondos de 
inversión son demasiado lentos y requieren que use mi propio dinero. Como dije antes en este 
libro, preferiría usar dinero prestado para hacerme rico en lugar de usar mi propio dinero... y 
los bancos no me dejan tomar dinero prestado para comprar fondos de inversión.
La otra razón por la que digo que los fondos de inversión son lentos es porque las grandes 
ganancias o el aumento de valor de cualquier activo en papel se da en la formación de la 
empresa, antes de que la empresa se haga pública. Cuando los inversionistas ricos 
comienzan a invertir en las acciones de una empresa, con frecuencia están invirtiendo según 
los términos y condiciones expresados por la Regulación D, la Regla 506 y otras 
regulaciones semejantes de la SEC (Comisión de Seguridades e Intercambio, por sus siglas 
en inglés). En otras palabras, los ricos invierten en acciones de una compañía cuando ésta 
todavía es una empresa privada. El público   invierte en acciones de una compañía después 
de que se convierte en una empresa pública. La diferencia puede ser enorme. Por ejemplo, 
si has invertido 25 000 dólares en Intel antes de que se hiciera una compañía pública, esos 
25 000 pueden valer más de 40 millones hoy en día dependiendo de los altibajos de la 
bolsa.
El punto es que los ricos ya han hecho su dinero antes de que el público siquiera se dé cuenta 
de que la compañía existe, Eso significa que los ricos con frecuencia invierten con un riesgo 
mucho más bajo y con el potencial de ganancias mucho más altas. Para la época en que un 
fondo de inversión compra acciones de la compañía, las ganancias ya se han hecho. Luego, 
el público general compra el fondo de inversión que ha comprado las acciones de la empresa 
pública, la misma en la que invirtieron los ricos mientras seguía siendo privada. En otras 
palabras, en lugar de invertir en un fondo de inversión o en acciones públicas, los ricos han 
invertido a través de un memorando de ubicación privada, también conocido como 506 reg d. 
La diferencia en el potencial de velocidad para hacerte rico que existe entre los fondos de 
inversión y la oferta pública inicial, o las 506 reg d, es impresionante. Como decía mi padre 
rico: "Invertir en fondos de inversión es invertir al final de la cadena alimenticia".
Eso no significa que los fondos de inversión no sean buenas inversiones. Para la mayoría de 
las personas, los fondos de inversión son excelentes inversiones. Son mejores inversiones si 
sabes lo que estás haciendo, conoces los riesgos que existen y conoces toda la imagen del 
juego completo de invertir en acciones y fondos de inversión... públicos y privados.
Puedo oír a algunos de ustedes diciendo: "Las ofertas públicas iníciales fueron buenas en las 
mejores épocas de un mercado alcista... pero ya no lo son en un mercado bajista". Hay algo de 
verdad en esta afirmación, no obstante, sin importar el mercado, a los ricos siempre se les 
ofrecen inversiones privadas que no se ofrecen al público en general. Por esa razón conocer las 
palabras, el vocabulario y la jerga de las inversiones de los ricos mejora tus posibilidades de 
hacerte rico más rápidamente.
En el futuro cercano, los ricos se harán más ricos porque estarán involucrados en tratos 
anteriores a las ofertas públicas  iniciales. No estarán invirtiendo en tecnología, ni 
computadoras o empresas punto com. En cambio, estarán invirtiendo en nuevas empresas 
atractivas de biotecnología, en empresas de ingeniería genética y en nuevas empresas que 
tengan la palabra sistema o red después de su nombre. Estarán invirtiendo en las compañías 
atractivas del futuro, compañías de las que todavía no hemos escuchado nada. Invertirán en 
compañías y proyectos de bienes raíces de los que la persona promedio escuchará hasta 
después de que se hayan hecho las ganancias. Estarán invirtiendo en memorandos de 
colocación privada de valores, o sociedades limitadas, y en otros vehículos de inversión seme-jantes, más que en fondos de inversión.
Palabras lentas Palabras rápidas
Paga al menudeo Compra al mayoreo
La mayoría de nosotros tiene la suficiente conciencia como para saber que siempre hay un 
precio de mayoreo y uno de menudeo. Lo mismo es cierto en las inversiones. Los ricos se 
hacen más ricos porque pagan a precio de mayoreo en lugar de a precio de menudeo.
Cuando ves el tablero del juego CASHFLOW, ves la Carrera de la rata y la Pista rápida. La 
Carrera de la rata es donde los  inversionistas pagan al menudeo y la Pista rápida es donde 
los  inversionistas pagan al mayor. Los ricos se hacen más ricos porque se les conoce como 
amigos y familiares de las personas que tienen acceso a inversiones con precio al mayoreo.
Palabras lentas Palabras rápidas
Compra acciones Vende acciones
Bill Gates no se volvió el hombre más rico del mundo comprando acciones de Microsoft. Se 
volvió el hombre más rico  del mundo porque es lo que se conoce como "accionista 
vendedor". Como se explicó en la discusión sobre pagar al menudeo o comprar al mayoreo, 
los ricos se hacen ricos porque con frecuencia son accionistas vendedores de determinada 
acción. Para convertirte en accionista vendedor, con frecuencia necesitas ser el fundador o un 
amigo o familiar del fundador.
Palabras lentas Palabras rápidas
Asiste a la escuela                      Asiste a seminarios
Mi padre pobre volvía a la escuela con mucha frecuencia. Por eso asistió a las 
Universidades de Chicago, Northwestern y Standford, todas escuelas excelentes y 
prestigiadas. Mi padre verdadero regresaba emocionado, entusiasta y esperando un ascenso 
porque había invertido su tiempo volviendo a la escuela.
Mi padre rico asistía a seminarios. Decía: "Vas a la escuela si quieres ser un mejor empleado 
o un mejor profesionista como un médico, un abogado o un contador. Si no te importan los 
títulos, los ascensos o tener un trabajo seguro, entonces asistes a seminarios. Los seminarios 
son para gente que quiere mejores resultados financieros más que un ascenso en su trabajo o 
una mayor seguridad de no perder su trabajo".
Yo imparto seminarios en vez de dar clases dentro de una escuela. Las escuelas atraen un 
tipo de estudiante distinto al de los seminarios. Por ejemplo, mi esposa, Kim, y yo tenemos 
el acuerdo de asistir juntos por lo menos a dos seminarios al año. Vamos juntos porque 
pensamos que los seminarios, incluso los malos, fortalecen nuestro matrimonio, nuestra 
amistad y nuestra sociedad de negocios. La información o la preparación tune el poder de 
acercar a las personas a través de la experiencia común así como de abrir una brecha entre 
ellas si no aprenden juntas.
Con los años, hemos asistido a muchos seminarios de mercadotecnia, ventas, desarrollo de 
sistemas, manejo de empleados y, por supuesto, inversión. Nos estamos preparando para 
asistir a un seminario sobre cómo pedir dinero prestado al gobierno para invertir en casas de 
bajo ingreso. El seminario cuesta sólo 85 dólares, fijados por el gobierno, y esperamos hacer 
millones con lo que aprendamos. A eso me refiero con personas que asisten a seminarios 
para obtener resultados en lugar de ascensos.
Conozco autores a quienes les fue bien como escritores en la escuela, pero cuyos libros no se 
venden tanto como los míos. Cuando les sugiero que asistan a cursos de mercadotecnia di-recta o a cursos de preparación en ventas, o a clases de derechos de autor, muchos se 
ofenden bastante. Como dije en Padre Rico, Padre Pobre, soy un autor que vende muy bien, 
no que escribe muy bien.
El otro día, me encontré a un amigo que envió a su hija a una escuela estatal relativamente 
buena. Estaba bastante orgulloso por el hecho de que pagó 85 000 dólares en cuatro años por 
la educación de su hija, quien acaba de encontrar un empleo por 55 000 dólares al año y él 
está de lo más emocionado.
Luego me preguntó cuánto cuestan mis seminarios y le dije que aproximadamente 5 000 
dólares por tres días. Se quedó boquiabierto ante el precio y dijo: "No puedo pagarlo. Es 
demasiado caro por tan poco tiempo". Cuando me preguntó qué era lo que yo enseñaba en 
tres días, le contesté: "El primer día cubrimos cómo crear un negocio como lo hizo Bill 
Gates y hacerlo público a través de una oferta pública inicial. También el primer día 
cubrimos cómo hacernos parte del nivel de los amigos y familiares de la oferta pública 
inicial, en caso de que no quieras ser como Bill Gates y sólo quieras comprar acciones al 
mayor". Luego dije: "En los días dos y tres cubrimos cómo encontrar inversiones en bienes 
raíces, cómo analizarlas rápidamente y cómo financiarlas. En otras palabras, te enseñamos a 
pensar, negociar y analizar tratos de manera similar a la forma en que personas como 
Donald Trump piensan e invierten en bienes raíces. El otro día les enseñamos a las personas 
cómo usar opciones comerciando como lo hacen los administradores de fondos de resguardo 
como George Soros, que no es igual a la forma en que comercian los administradores de 
fondos de inversión. Además de eso, cubrimos cómo usar las corporaciones para pagar menos 
impuestos y proteger tus activos. Conocerás inversionistas internos de la pista rápida que te 
dirán cómo encontrar la inversión con mayor apalancamiento del mundo. Y, lo más 
importante,  conocerás  personas  que  piensan  justo  como  tú.   En  otras  palabras, 
probablemente harás nuevos amigos que se están moviendo a la misma velocidad que tú".
Lo único que pudo decir fue: "Es demasiado dinero para tres días".
Como dije antes, hay palabras lentas y palabras rápidas. Yo preferiría gastar 5 000 dólares y 
tres días para aprender cómo hacer millones y posiblemente miles de millones en lugar de 
gastar cuatro años y 85 000 dólares para aprender cómo trabajar por 55 000 dólares anuales o 
un poco más por el resto de mi vida. Además de eso, esos 55 000 dólares son ingreso ganado,
Hay una fuente más de educación rápida, de bajo costo y alto impacto que uso con 
regularidad. En 1974, cuando dejé la Infantería de Marina y supe que no me iba a quedar en 
el cuadrante E como mi padre pobre, comencé a suscribirme a cintas de audio de la 
Compañía Nightingale-Conant. Tiene  algunos de los  más importantes maestros de 
negocios, motivación y liderazgo del mundo. Todavía recuerdo haber comprado Lead the 
Field {Dirige el Campo) de Earl Nightingale y haber escuchado el programa una y otra vez 
mientras iba por mi zona de ventas, planeando mi escape del cuadrante E y del mundo 
corporativo. De hecho, sigo escuchando ese programa aproximadamente una vez al año 
mientras estoy en el gimnasio.
Cuando la gente me pregunta: "¿Cómo puedo encontrar un mentor?" A menudo respondo: 
"Pide un catálogo a Nightingale-Conant y empieza a escuchar a algunos de los mayores 
mentores de todos los tiempos". Como decía mi padre rico con frecuencia decía: "Los 
verdaderamente ricos se hacen ricos en casa y en su tiempo libre". También dijo: "No es 
trabajo de tu jefe hacerte rico. Es tu trabajo".
Algunos de los mayores maestros de la librería Nightingale-Conant son Sir John Templeton, 
fundador de Templeton Fund, Brian Tracy, Zig Ziglar, Dennos Waitely, Og Mandino, Seth 
Godin, Harvey Mckay, entre otros. He aprendido más, he hecho más dinero, he encontrado 
nueva inspiración para seguir adelante, me han surgido nuevas ideas o he descubierto nuevas 
formas de hacer las cosas simplemente mientras conduzco mi auto, mientras hago ejercicio 
en el gimnasio o mientras salgo a caminar. La colección de maestros de Nightingale-Conant 
es invaluable, sin embargo, por menos de cien dólares puedes pasar el tiempo que quieras 
con algunos de los mayores profesores y maestros del mundo. Lo único que tienes que hacer 
es oprimir el botón que regresa la cinta y ellos repetirán exactamente lo que quieres 
escuchar. Nunca recibí un título universitario por estas cintas, pero encontré la libertad 
financiera y, lo más importante, la confianza para ser fiel a lo que soy.
Por qué algunas personas sólo buscan contenido
Una de las grandes diferencias entre quienes asisten a la escuela y quienes asisten a 
seminarios una vez más es la diferencia entre contexto y contenido. He notado que cuando una 
persona que asiste a escuelas le pregunta a una persona que asiste a seminarios: "¿Qué 
obtuviste del seminario?" la persona que asiste al seminario con frecuencia no es capaz de 
explicar lo que obtuvo. La razón es que muchos seminarios expanden más contexto de lo 
que aumentan el contenido. Una persona a la que le acaban de expandir el contexto con 
frecuencia no puede decir en específico qué fue lo que obtuvo. Una persona orientada a  la 
escuela, que preferiría seguir siendo empleada, con frecuencia no puede entender esa 
vaguedad. Una persona que quiere que su contexto siga siendo el mismo y sólo busca que su 
contenido aumente, no comprenderá a una persona que es feliz de que le expandan la realidad 
y sigue esperando que aparezca el nuevo contenido. Las personas que sólo quieren 
contenido con frecuencia se alteran mucho si se les mezcla su contexto. Por esa razón 
buscan contenido versus una expansión de contexto. La buena noticia es que ambas pueden 
avanzar, sin importar lo que estén buscando. No obstante, la persona que avanza más rápido es 
la que busca tanto que se expanda su contexto como que se incremente su contenido.
¿Es momento de salir de la Carrera de la rata?
El otro día, una persona me dijo: "Jugué tu juego CASHFLO W una vez. ¿Ahora qué hago?"
Le contesté diciendo: "¿Jugaste CASHFLOW una vez? ¿Una sola vez?"
"Una sola vez", contestó.
"¿Por cuánto tiempo jugaste?", pregunté.
"¿Saliste de la Carrera de la rata?", insistió.
"No, nunca lo logré, pero aprendí la lección".
"¿Cuál fue la lección que aprendiste?" pregunté.
"Me aburrí. Aprendí que estar en la Carrera de la rata es aburrido y cansado. Aprendí que 
odio jugar, así que te pregunto qué puedo hacer ahora. No quiero jugar juegos. Quiero 
hacerme rico. Así que dime qué hago ahora".
Saqué el juego de mesa que se ve a continuación y señalé el círculo llamado la Carrera de la 
rata.
De  forma lenta y deliberada, todavía señalando el círculo de la Carrera de la rata, comencé a 
decir: "¿Entonces para ti este juego no es más que un juego tonto?"
Asintiendo, sonrió y dijo: "Sí. Y no quiero sólo jugar. Quiero hacerme rico en la vida real".
"¿Y no crees que este juego es la vida real?", pregunté.
"No", dijo con una ligera sonrisa de afectación. "Ese juego no se aplica a mí".
"Es interesante" dije, todavía señalando la Carrera de la rata. "Para mí este juego es la vida 
real. Déjame preguntarte algo: ¿En qué pista estás? ¿En la Carrera de la rata o en la Pista 
rápida"
El joven me miró perplejo y no dijo nada a cambio.
Siguiendo, dije: "Para mí este juego es la vida real. Y, en la vida real, todos y cada uno de 
nosotros, estamos en una pista o en la otra".
Resultaba que tenía conmigo el artículo de Robert Reich, el es Secretario del Trabajo, citado 
al inicio de esta sección. Saqué el artículo y leí una cita de Robert Reich:
"Ya no es cuestión simplemente de tener trabajo ni incluso de tener una paga decente".
"En la nueva economía, con ganancias impredecibles... están emergiendo dos caminos, el 
camino rápido y el camino lento y la ausencia de grados intermedios".
"¿Quieres decir que el camino rápido sí existe realmente?" preguntó.
Asintiendo, dije: "Claro que existe y también existe la Carrera de la rata. Y quienes están 
en la Carrera de la rata se están quedando cada vez más rezagados. Como dice Robert 
Reich: hay una 'ausencia de grados intermedios'. Lo que significa que estás o en una pista o 
en la otra. De modo que, ¿desde que pista estás invirtiendo?"
"Bueno, tengo un trabajo muy bien pagado y gano mucho dinero. ¿Eso no significa que 
estoy invirtiendo desde el camino rápido?", preguntó.
"No lo creo, pero realmente no sé. Tú tienes que decírmelo ¿En qué estás invirtiendo?" 
pregunté. "¿Eres millonario y ganas más de 200 000 dólares al año?"
"Tengo 350 000 dólares en mi 401(k) y gano más de 120 000 dólares al año. ¿Eso no significa que 
califico para la Pista rápida  preguntó.
"No lo creo", contesté. "Por lo menos, según las regulaciones SEC, no calificas para estar en la 
Pista rápida."
"No entiendo", dijo. "¿Puedes decirme qué es lo que me falta?" Dando un gran suspiro, me sentí 
aliviado de que finalmente le hubiera abierto su contexto o su mente a un nuevo contenido o 
información. Siempre me ha parecido difícil enseñarles algo a alguien que piensa que sabe 
todas las respuestas. Todos sabemos que es difícil poner más agua en un vaso que ya está lleno 
también es difícil enseñarle algo nuevo a alguien que tiene mente cerrada o que ya está 
llena de otro contenido.
Comenzando lentamente, dije: "Diseñé ese juego con dos pistas porque, para mí, ese juego 
es el juego de la vida real. En la vida real cada uno de nosotros está en una pista o en la otra. 
Como dice Robert Reich, hay una 'ausencia de grados'".
"Te refieres a que o estamos en la Carrera de la rata o estamos en la Pista rápida", dijo, 
ahora con un poco más de interés. "Sí, dije. "Y la lección del juego es cómo tú y yo podemos 
salir de la carrera de la rata. El objetivo del juego es abrir tu mente a la posibilidad de 
hacerte rico y financieramente libre... libre de la carrera de la rata que la mayoría de las 
personas conocen... libre de la monserga de pasarse la vida trabajando por dinero y de vivir 
por debajo de tu nivel. Entre más juegas el juego y entre más se lo enseñas a otras personas, 
más se abre tu mente  a esa posibilidad... y más real se vuelve la libertad financiera en tu 
mente y en tu contenido y en tu contexto. Si tu mente no está abierta, las probabilidades son 
que tú seas uno de las 99 personas de cada 100 que se pasan la vida en la carrera de la rata." 
"¿Incluso si gano mucho dinero?", preguntó. "Excelente pregunta", dije con voz fuerte. "La 
mejor pregunta que podías haber hecho. La respuesta es que el dinero solo no te sacará de 
la carrera de la rata y el dinero solo no te asegura estar en la pista rápida. Por eso mi padre 
rico siempre decía 'El dinero no te hace rico'".
 "¿Por qué?", preguntó con una mirada perpleja. "¿Que no lo único que se necesita es mucho 
dinero para entrar en la Pista rápida?"
"Otra excelente pregunta... y la respuesta es no", dije. Ahora me sentía aliviado de que su 
mente se estuviera abriendo a nuevas ideas en vez de pretender saber todas las respuestas. 
"Se necesita  más que dinero para salir de la Carrera de la rata. Pero no entiendo por qué se 
necesita más que dinero para invertir en la pista rápida".
"No entiendo", dijo. "¿Qué es lo que se necesita si se necesita algo más que dinero? Puedo 
entender por qué se necesita más que dinero para salir de la carrera de la rata, pero no 
entiendo por qué se necesita más que dinero para invertir en la pista rápida".
Reuní mis ideas antes de contestar su pregunta. "¿Recuerdas los anuncios en publicaciones 
como The Wall Street Journal y en publicaciones financieras que muestran la foto de un 
hombre bien vestido con la apariencia de alguien afluente parado en una esquina 
sosteniendo un letrero que dice: 'Tengo dinero para invertir'"?
"Sí, sí he visto esos anuncios. En realidad no los entendía", contestó suavemente y un poco 
perplejo.
"Los anuncios como ésos abundaron entre 1995 y 1999. El mensaje era que había muchos 
individuos que habían hecho grandes cantidades de dinero en la bolsa o en su trabajo y ahora 
estaban buscando inversiones de los ricos, inversiones que se encontraban en la pista rápida. 
El problema era que aunque tenían dinero, todavía no se les permitía entrar en las mejores 
inversiones de la pista rápida. Claro que hay muchos tratos endebles y en ocasiones 
retorcidos en la pista rápida que le habrían permitido entrar, pero los mejores tratos están 
cerrados para la mayoría de las personas... aunque tengan dinero".
"¿Aunque tengan dinero?", preguntó. "¿Por qué? No entiendo", "Porque el dinero no cuenta en la 
pista rápida" dije. "En las inversiones de la vida real, el dinero cuenta para las personas que 
están atoradas en la Carrera de la rata".
"¿El dinero no cuenta?", dijo. "¿Por qué el dinero no cuenta?"
"Porque todas las personas de la pista rápida ya tienen mucho dinero. Por eso el dinero ya no 
cuenta. Para entrar en mejores res inversiones en la pista rápida, lo que cuenta es que es lo que 
sabes o a quién conoces".
"Lo que quieres decir es que lo que cuenta es lo que pones en la mesa... no el dinero", dijo 
en voz baja.
"Ya te cayó el veinte", dije sonriendo. "Las cosas no son diferentes entre los ricos y los 
pobres y la clase media. Las cosas son opuestas. Un lado piensa que el dinero es importante y 
entonces, una vez que te haces rico, descubres que el dinero ya no es importante".
Pasé los siguientes minutos mostrándole los diferentes niveles de estrategias de salida. Le 
expliqué que muchos logran alcanzar el nivel de las personas afluentes, que es de 100 000 a 
un millón de dólares de ingreso. Sin embargo, si alcanzaron ese nivel de ingreso trabajando 
duro, ahorrando, siendo frugales, es probable que no se les permita invertir en las inver-siones de los ricos y ultra ricos. A muchos no se les permite Invertir simplemente porque 
tienen dinero pero carecen de la preparación y la experiencia que se requieren para las 
inversiones de la pista rápida. Tienen dinero, pero no ponen nada más a la mesa.
"Entonces, por eso estaban esos anuncios con personas afluentes que sostenían letreros que 
decían: 'Tengo dinero para invertir'", dijo el joven cuya mente ahora estaba ganando un poco 
de contexto. "Tenían dinero pero nadie quería su dinero porque no estaban preparados para 
la Pista rápida".
"Así es", dije. "Y por eso mi padre rico decía: 'Se necesita más para ser rico que tener 
mucho dinero'".
"¿Entonces, ¿qué debería hacer yo?", preguntó el joven.
"Bueno, lo primero que yo haría sería volver a jugar CASHF'LOW 101 por lo menos doce 
veces más. Juega hasta que puedas salir de la Carrera de la rata en menos de una hora,  sin 
importar tu profesión, tú salario, alto o bajo, y cuáles sean las condiciones del mercado o las 
desventajas que encuentres en el juego. Luego échale un vistazo a las palabras de la Pista 
rápida y busca algunas de las definiciones de las palabras. Después de aprender esas 
definiciones empieza a buscar inversionistas que hagan inversiones en la Pista rápida. Pasa 
tiempo con ellos. Escucha lo que tienen que decir y empieza a entender lo que consideran 
importante... además del dinero. Entre más puedas entender sus palabras más podrás 
comunicarte con ellos y comenzar a ver su mundo... el mundo de la Vista rápida.''
"¿Eso es lo que hiciste tú?", preguntó.
"No, eso es lo que yo hago. Eso es lo que hago todos los días de mi vida. Como dije, este 
juego es la vida real. O estás en la Carrera de la rata o estás en la Pista rápida. "
"Entonces, ¿cómo saliste de la Carrera de la rata?", preguntó. "Sé que empezaste sin nada."
"Tenía un plan. Un plan para salir de la Carrera de la rata. La gran diferencia era que mi plan 
era un plan rico desde el principio. Era un plan que me permitiría obtener mucho dinero, pero, 
lo más importante, es que me permitiría obtener las palabras, preparación y experiencia 
necesarias para la pista rápida. Así que invierte un poco de tiempo eligiendo tu estrategia de salida 
y luego empieza a crear y diseñar tu propio plan... un plan que incluirá la preparación, 
experiencia y vocabulario necesarios para la Pista rápida."
El joven asintió. Su mente ahora estaba abierta. "¿Así que muchas personas se retiran pero 
se quedan en la Carrera de la rata?"
"La mayoría se queda", contesté en voz baja. "Sus vidas salieron conforme al plan. Se 
subieron al tren lento y se quedaron en él durante toda su vida. Yo no quería subirme al tren 
lento así que busqué un mejor plan... un plan que me funcionara. Espero que tú encuentres un 
mejor plan". El joven asintió y dijo en voz baja: "Así será".
Resumen sobre darle apalancamiento a tu plan
En mi opinión, la razón por la cual tantas personas trabajan duro toda su vida y aún así 
terminan pobres o atoradas en la Carrera de la rata de la vida es que vivieron su vida 
conforme a un plan lento. Un paso importante si quieres retirarte joven y rico es sentarte en 
silencio y preguntarte: "¿Qué plan y el de quién estoy siguiendo?" Otras preguntas que pude 
ser que quieras preguntarte son las siguientes:
1.¿Cuál es la estrategia de salida de mi vida?
2.¿Qué tan rápidas son mis palabras y mis ideas?
3.¿En qué pista estoy hoy y en qué pista quiero estar en el futuro?
4.¿Para ganar qué tipo de ingreso estoy trabajando actualmente y es el tipo de ingreso que quiero 
ganar el día de mañana?
5.¿Cuál es el precio a largo plazo de la seguridad?
CAPÍTULO 11
El apalancamiento de la integridad
Entre 1985 y 1989, Kim y yo no tuvimos ningún ingreso pasivo ni de portafolio. Estábamos 
trabajando diligentemente para crear un negocio para que pudiéramos tener más ingreso 
ganado con apalancamiento. Todo el dinero extra que ganábamos lo invertíamos en la creación 
del negocio. Sabíamos qué tipo de ingreso queríamos, conocíamos las definiciones de los 
ingresos que queríamos, sabíamos que queríamos convertir el ingreso ganado en ingreso 
pasivo y de portafolio, pero no teníamos nada que mostrar en lo que respectaba a esos dos 
ingresos. A medida que pasaban los años, podía escuchar a mi padre rico diciendo: "En el 
momento en que hagas parte de tu vida al ingreso pasivo y al ingreso de portafolio, tu vida 
cambiará. Esas palabras se harán carne".
Mis dos padres tenían rigor para saber las definiciones de las palabras. La diferencia era que 
no se enfocaban en las mismas palabras. Un padre me hacía buscar palabras para la escuela y 
el otro me hacía buscar palabras que pertenecían al dinero, los negocios y las inversiones. 
Muchas noches me senté con mi diccionario, buscando los diferentes significados de las 
diferentes palabras de mis dos padres.
Conozco a muchas personas que se dicen inversionistas.  Cuando les pregunto cuánto 
ingreso pasivo o de portafolio tienen, muchos admiten que no tienen una gran cantidad, si es 
que tienen algo... sin embargo, dicen ser inversionistas. Mis dos padres decían: "Tu valor 
está en tu palabra. La gente que no mantiene su palabra no tiene gran valor". Una de las 
razones por las que tan pocas personas se retiran jóvenes y ricas es que no se mantienen 
leales a su palabra. Usan palabras que para ellas no son reales.
Más que simples definiciones
Para quienes han leído Padre Rico, Padre Pobre, recordarán las diferentes definiciones que 
mis dos padres tenían para las palabras activo y pasivo. Mi padre pobre asumía que sabía las 
definiciones de ambas palabras, así que nunca se molestó por buscarlas. No habría resultado 
muy útil, aunque mi padre pobre las hubiera buscado, simplemente porque las definiciones 
que se encuentran en la mayoría de los diccionarios académicos no logran explicar 
claramente las diferencias.
Odiaba buscar las definiciones de palabras, sin embargo sigo buscando palabras que realmente 
no comprendo. ¿Por qué las busco? Lo hago porque, en mi opinión, las palabras son las he-rramientas más poderosas que tenemos disponibles los seres humanos. Como decía mi padre 
rico: "Las palabras son herramientas para el cerebro. Las palabras permiten que el cerebro vea 
lo que los ojos no pueden ver". También decía: "Una persona que usa palabras pobres tiene 
ideas pobres y, en consecuencia, tiene una vida pobre". Tómate un momento para pensar en la 
profunda diferencia que el simple hecho de conocer la diferencia entre ingreso ganado, de 
portafolio y pasivo ha hecho en mi vida y en la de muchas otras personas. Son palabras 
relativamente simples, pero el simple hecho de saber la diferencia puede hacer una gran 
diferencia en tu vida.
Si quieres cambiar tu futuro financiero, uno de los pasos más importantes y menos costosos 
que puedes dar es conocer las definiciones de las palabras que usas seriamente. En televi-sión, varias grandes casas de inversión tienen a celebridades  arrojando palabras como 
proporción P/E (precio/ganancia, por  sus siglas en inglés),  plan de reinversión de 
dividendos, capitalización del mercado... y otra jerga en onda en el mundo de la inversión. 
Esas casas de inversión quieren que pienses que saber esas definiciones es importante para 
convertirte en un mejor inversionista y lo son. No obstante, hay definiciones mucho más 
básicas e importantes que uno necesita saber si realmente planea retirarse rico y joven. 
Algunas de estas palabras fundamentales e importantes que debes entender son tu relación 
del circulante, razón de liquidez, índice de liquidez, proporción de deudas y ganancias, así 
como la diferencia entre activos y pasivos y la diferencia entre ingreso ganado, de por-tafolio y pasivo.
Aprovechando el poder de las palabras
¿Por qué las últimas palabras son más importantes? La respuesta es porque las palabras 
proporción P/E, plan de reinversión de dividendos y capitalización del mercado realmente no 
tienen relación contigo... en especial cuando apenas estás empezando en los negocios o en la 
inversión. Para ti y para tu vida es mucho más importante las proporciones básicas como 
deuda y beneficio o las razones de liquidez. ¿Por qué? Porque esas proporciones son útiles 
para ti personalmente, puedes usar esas definiciones en la vida real. Si entiendes de qué manera 
esas proporciones se aplican a ti personalmente y si aplicas esas palabras a tu vida personal, 
entonces las palabras se vuelven parte de tu vida... las palabras se hacen carne y cuando eso 
sucede aprovechas el poder de las palabras.
Las proporciones P/E generalmente se aplican a compañías que se comercian públicamente 
como IBM y Microsoft. Una proporción P/E no aplica a menos de que te pusieras en venta per-sonalmente y creo que ya tiene tiempo que se abolió la esclavitud. Para quienes puede que 
no sepan lo que es una proporción P/E, ésta rápidamente evalúa qué tan cara o barata es una 
acción. Es similar a un comprador que pregunta a cuánto está el kilo de carne de cerdo. Hay 
una diferencia entre la carne de cerdo que se vende a treinta y tantos pesos el kilo y la que se 
vende a veintitantos pesos el kilo... y cualquier comprador consciente sabría que no porque la 
carne de puerco sea barata quiere decir que es un buen trato. Lo mismo resulta cierto en el caso 
de una proporción P/E alta o baja.
Una proporción P/E simplemente mide el precio relativo de una acción en comparación con 
sus ganancias. Por ejemplo, si la acción dio dos dólares por dividendo compartido y cada ac-ción cuesta veinte dólares, la proporción de P/E sería de diez... lo que significaría que te 
tardarías diez años en recuperar tus veinte dólares si las cosas siguieran igual. Sólo porque 
una acción tiene una proporción P/E alta o baja no significa que es una buena compra o una 
mala compra, así como el precio por kilo no te dice si la carne de puerco es una buena 
compra o una mala compra. Hay otros factores que debes verificar antes de comprar carne 
de puerco barata así como así.
Durante la manía de las empresas punto com, muchas acciones tenían precios altos y nada de 
ganancias... lo que hacía que invertir en este tipo de empresas fuera ridículo, si lo único que 
considerabas era la proporción de precio/ganancia. Cuando cayó la bolsa, hubo muchas 
personas que deseaban haber comprando un poco de carne de puerco barata y haberla puesto 
en el congelador, en lugar de haber comprado acciones con precios altos y nada de ganancias. 
Hoy en día, incluso la carne de puerco congelada vale más que las participaciones de 
algunas acciones punto com. Los verdaderos tontos fueron las personas que creyeron que 
podías invertir en la promesa del futuro sin tener ninguna realidad hoy. Muchos promotores 
de empresas punto com jóvenes tenían el contexto adecuado pero no lograron ver el 
contenido adecuado... el contenido llamado preparación y experiencia en negocios e 
inversión.
Hay proporciones más importantes, básicas y fundamentales que hay que entender... y, si las 
entiendes y las usas, tus probabilidades de hacerte más rico y de tener éxito financiero 
mejoran. Una proporción más útil es tu proporción de deuda y beneficio. ¿Por qué es más 
importante? Porque todos y cada uno de nosotros puede usar esta proporción... y 
deberíamos usarla todos y cada uno de los meses. Por ejemplo, si tienes deudas a largo y a 
corto plazo, digamos de 100 000 dólares y tienes 20 000 dólares de beneficio, entonces tu 
proporción de deuda y beneficio se ve de la siguiente forma:
100 000 20 000*
Así que en este caso, tu proporción de deuda y beneficio sería cinco. La pregunta es ¿qué 
significa esto? Bueno, en realidad significa muy poco, no obstante, si el mes siguiente tu 
proporción es diez, eso puede indicarte que podrías estar manejando mal tu vida. Una 
proporción de deuda y beneficio de diez podría significar o que tu deuda ha subido a 200 000 
dólares (Todas las cantidades de las proporciones están en dólares) o que tu beneficio ha bajado a 10 
000 dólares. En cualquier caso, esos números tienen más significado porque son números reales 
que tienen relación con tu vida. Como decía mi padre rico: "Ocúpate de tus negocios". Y 
saber esas simples proporciones es una herramienta excelente para enseñarte cómo ocuparte 
y manejar tu propio negocio... el negocio de tu vida.
Proporciones para aplicarlas a tu vida
Así como las proporciones P/E tienden a reflejar la confianza que tiene la compañía 
inversionista en la administración de una empresa pública, tú como administrador de tu vida 
necesitas tener proporciones que se apliquen a ésta. Las siguientes son algunas proporciones 
de las cuales es probable quieras tener un seguimiento, si quieres ser un mejor administrador 
de tu vida financiera.
Una de las proporciones que mi padre rico me hizo observar y monitorear fue la que llamaba 
proporción de riquezas. Su proporción de riquezas era la siguiente:
Ingreso pasivo + Ingreso de portafolio Total de gastos
La meta de calcular tu proporción de riqueza era que tu ingreso pasivo o de portafolio 
igualara o excediera tus gastos totales. Esto significaría que podías dejar tu trabajo (fuente 
de ingreso ganado) y seguir manteniendo tu estilo de vida, Una vez que tú ingreso pasivo y 
de portafolio excedieran tus gastos, la proporción sería uno o más y habrías salido de la 
carrera de la rata. Ésa es la meta de jugar CASHFLOW 101, mi juego de mesa patentado 
que te enseña cómo crear ingreso pasivo y de portafolio.
Un ejemplo sería:
      600 de ingreso pasivo + 200 de ingreso de portafolio
--------------------------------------------------------------------  =0.2
                                            4 000 gastos
Si mi padre rico hubiera visto esta proporción, 0.2, o ingreso pasivo y de portafolio que iguala 
veinte por ciento de los gastos, me habría hablado con insistencia sobre trabajar más duro 
para aumentar mi ingreso pasivo o de portafolio. Como decía mi padre rico: "En el momento 
en que hagas parte de tu vida al ingreso pasivo y al ingreso de portafolio, tu vida cambiará. 
Esas palabras se harán carne". Para él, entre más supiera realmente lo que eran el ingreso 
pasivo y el de portafolio, mi vida cambiaría porque mi realidad cambiaría.
Mi padre Rico pensaba que la proporción de riqueza era una proporción que había que saber 
muy íntimamente porque era un gran indicador de qué tan bien estabas manejando el 
negocio de tu vida. Decía: "La mayor parte de las personas se retiran pobres simplemente 
porque nunca saben cómo se siente tener realmente en su vida ingreso pasivo y de portafolio. 
Puede que sepan la definición, pero no tienen la integridad para hacer que las palabras sean 
una parte real de su vida".
Por cinco años, Kim y yo supimos cuáles eran las definiciones de las palabras, sabíamos qué 
queríamos en nuestra vida... pero por cinco años no tuvimos esos dos tipos de ingreso en 
nuestra vida. Poco después de que en 1987 cayó la bolsa y siguió una recesión de siete años, 
supimos que la ventana de la oportunidad había llegado. Era nuestro momento de hacer que 
esas palabras se hicieran realidad. Era momento de tener una proporción de riqueza mayor a 
cero. Compramos nuestra primera propiedad en 1989y,para 1994, teníamos un poco más de 
10.000 dólares de ingreso pasivo al mes y nuestros gastos totales eran de menos de 3 000 
dólares mensuales. Eso nos dio una proporción de riqueza de 3.3. Hoy nuestra proporción de 
riqueza es de más de doce, aunque nuestros gastos han aumentado significativamente. Ése 
es el poder de hacer que las palabras sean parte de tu vida.
Si deseas en serio retirarte rico y joven, es probable que quieras hacer que la proporción de 
riqueza de mi padre rico sea parte de tu vida. Pienso que encontrarás que tiene más sentido 
para ti que la proporción P/E de IBM O Microsoft. Si ves esa proporción mes con mes, pienso 
que encontrarás que tu vida cambia mucho más rápido en comparación con alguien que está 
trabajando para obtener una aumento de sueldo. La proporción de riqueza de mi padre rico 
afectó en gran medida lo que yo consideraba importante en mi vida.
Cuando veo mi vida en retrospectiva, fueron esas sencillas lecciones de mi padre rico las que 
me dieron más dinero en mi vida. Hoy, mi proporción personal de deuda y beneficio es de 
alrededor de 0.7, lo que significa que duermo bien por la noche, aunque tengo muchas 
deudas. De ninguna manera estoy libre de deudas ni planeo estarlo. El punto es que esas 
sencillas lecciones de mi padre rico tuvieron un impacto mucho más poderoso en mi vida 
que todos los años que pasé estudiando calculo, trigonometría esférica y química. La razón 
por la que las sencillas lecciones de mi padre rico tuvieron un profundo efecto es que sus 
lecciones son relevantes para mi vida mientras esté vivo. Nunca he usado el cálculo, la 
trigonometría esféricas o una proporción P/E para motivarme a tomar una decisión de 
inversión. No los uso porque no son útiles y tienen poca relevancia para mi éxito financiero 
personal.
Agrega poder a tu vida
Hay dos puntos que quiero dejar en claro en esta sección sobre palabras, acción e integridad. 
Un punto es que unas cuantas definiciones simples y números simples pueden agregar 
mucho poder a la vida de una persona. Así como cualquier buen comprador quisiera saber 
cuál es el precio por kilo de la carne de puerco, todos deberíamos estar conscientes de 
nuestras proporciones de deuda y beneficio, nuestra proporción personal de riqueza y otros 
indicadores matemáticos sencillos, en los que no entraré aquí.
El segundo punto es que en el camino hacia el éxito hay más que el simple hecho que saber 
las definiciones de palabras y andar por ahí arrojando la jerga especializada en un intento por 
sonar inteligente. Hoy en día, demasiadas personas usan palabras que realmente no 
entienden. Muchos vendedores de servicios financieros usan palabras financieras que 
realmente no entienden, como "proporciones P/E", en un intento por sonar más inteligentes 
que sus clientes. El punto principal es que, si quieres retirarte joven y rico, es importante que 
mejores constantemente tu vocabulario financiero. Pero para mejorar del todo tu 
vocabulario, también es importante saber más que sólo la definición de la palabra. En mi 
opinión, es importante hacer que esa palabra sea parte de tu vida y de tu realidad. Por 
ejemplo, cuando digo las palabras ingreso pasivo... las digo con pasión porque son una parte 
importante de mi vida. Ingreso pasivo dignifica tanto para mí como aumento de sueldo para 
muchos empleados. La razón por la que no me apasiona aumento de sueldo es porque un 
aumento de sueldo para mí sería ingreso sin mucho futuro. He pasado años aprendiendo 
cómo convertir ingreso ganado en ingreso pasivo. Entre más tiempo paso realmente 
convirtiendo el ingreso ganado en ingreso pasivo, más experiencia de la vida real obtengo. El 
problema que tengo con muchos vendedores de servicios financieros, como agentes de bolsa, 
agentes de bienes raíces y gente especializada en hacer planes financieros es que mientras a 
ti te están vendiendo productos de inversión ellos mismos sólo están trabajando por ingreso 
ganado. Para mí, eso es estar un poco fuera de integridad.
¿Qué tan larga es la nariz de tu asesor financiero?
A mi padre rico le encantaban los cuentos de hadas. Uno de sus preferidos era la historia de 
Pinocho... el muñeco de madera que quería convertirse en un niño de verdad. En la historia, 
Pinocho mentía y entre más lo hacía más le crecía su nariz de madera. Hasta que encontró 
su corazón y comenzó a decir la verdad se convirtió en un niño de carne y hueso. Cuando 
mi padre rico nos contaba este cuento a su hijo y a mí, solía decir: "Ése es otro ejemplo de 
cómo las palabras se hacen carne... o madera".
Cuando pienso en los millones de personas que están apostando su futuro financiero y su 
seguridad financiera en un mercado bursátil, me estremezco. Millones de personas están 
preocupadas por su futuro financiero a medida que aumentan los despidos y el mercado 
sigue fluctuando. En la copia de un periódico que acabo de leer, hay historias sobre cómo 
algunos retirados han perdido la mayor parte de sus ahorros de retiro con asesores de 
inversión y vendedores de seguros en quienes confiaron. El artículo decía que los asesores 
y agentes de seguros comenzaran a venderles a esos retirados inversiones falsas, sin sanción 
de sus casas de corretaje y compañías de seguros, simplemente porque las compañías para 
las que trabajaban redujeron las comisiones (ingreso ganado) que les pagaban a sus 
agentes... así que encontraron productos nuevos y falsos para venderlos a personas que 
confiaron en ellos... personas que estaban esperando tener algo de ingreso pasivo y de 
portafolio cuando tuvieran una edad avanzada.
En las décadas venideras, habrá millones de personas que estarán en problemas financieros 
en su vejez simplemente porque escucharon a personas que supuestamente eran profesio-nales y que tenían largas narices de madera. La gente hecha de madera, sigue diciendo: "La 
bolsa siempre sube, los fondos de inversión pagan en promedio doce por ciento al año, 
invierte a largo plazo, diversifica y saca un promedio de costo de dinero para tus pérdidas".
El poder de la integridad
Aunque mis dos padres no remarcaban la importancia de las mismas palabras, ambos 
subrayaban la importancia de la palabra integridad. Ambos estaban de acuerdo en que una 
de las definiciones de integridad era la correlación entre las palabras de una persona y sus 
acciones. Ambos decían: "Escucha lo que dice una persona, pero, lo más importante, ve lo 
que hace una persona". En otras palabras, si la persona dice: "Llegaré a recogerte a las siete 
de la mañana" y la persona te recoge a las siete, entonces tiene un ciento por ciento de 
integridad en ese momento. Sus palabras y acciones son un todo. Si una persona dice "llegaré 
a recogerte a las siete de la mañana" y esa persona nunca llega, nunca llama, nunca se 
disculpa, entonces, en ese momento, esa persona tiene un 0 por ciento de integridad. Sus 
acciones y sus palabras no concuerdan, no son un todo.
Mi padre real me señalaba que una de las definiciones del diccionario para la palabra 
integridad era la palabra todo o completo. Constantemente decía: "Tu valor está en tu palabra". 
Constantemente recordaba a sus hijos la importancia de cumplir nuestra palabra. Solía decir: 
"Al final, somos nuestras palabras. Al  final, lo único que tenemos es nuestra palabra. Si 
nuestras palabras no son buenas, entonces tú tampoco". Por eso también decía: "Nunca hagas 
promesas que no pretendas cumplir".
El otro día en Dallas, dos jóvenes me preguntaron si podían asistir a mi seminario de 
inversión. Me pidieron entradas gratis porque no tenían dinero. Como eran muy 
convincentes, Kim y yo aceptamos dejar dos entradas gratis en la puerta. Nunca se 
presentaron y me di cuenta de por qué podían tener problemas de dinero, aunque tenían 
excelentes empleos.
Un plan con integridad
Una de las partes más simples y más poderosas de mi plan para tener una vida de gran riqueza 
era asegurarme de tener la integridad para ser fiel a mis palabras y respetar el poder de éstas 
haciendo que mi palabra y mis acciones concordaran. Con los años, mi padre rico se aseguró 
de que mantuviera mi palabra en mis acuerdos pequeños. Decía: "Si mantienes tus acuerdos 
pequeños mantendrás tus acuerdos grandes. Una persona que no puede mantener sus 
acuerdos pequeños nunca puede hacer que sus sueños se vuelvan realidad". Saco a relucir 
esta idea porque hay muchas personas que tienen grandes planes pero éstos nunca se hacen 
realidad. La razón es que demasiadas personas tienen grandes planes pero no logran mantener sus 
acuerdos pequeños. Como decía mi padre rico: "Las personas que no mantienen sus acuerdos 
pequeños son personas en quienes no se puede confiar. Si no se puede confiar en ti con los 
acuerdos pequeños, la gente no te ayudará a lograr que tus sueños se hagan realidad. Si no 
puedes mantener tu palabra, la gente no logrará confiar en ti y tendrá poca confianza en ti y 
en tus palabras".
He visto desplegarse la sabiduría de los consejos de mis dos padres sobre el poder de las 
palabras. He visto cómo muchas personas muestran su comportamiento medular cuando 
hay presión. Tengo un amigo que nunca mantiene sus citas conmigo y luego se pregunta 
por qué no quiero hacer negocios con él. También rompe sus acuerdos con otras personas 
como sus socios, empleados y banqueros y, con frecuencia, los engaña legalmente. Aunque 
tiene éxito, siempre tiene que buscar nuevas personas con quienes hacer negocios. En lugar 
de ir conformando sus relaciones, las destruye y tiene que empezar de nuevo con personas 
completamente desconocidas. No tiene problemas para encontrar gente nueva pero su nariz 
de madera se sigue haciendo más larga y se está volviendo difícil de esconder. Otra ex 
amiga mía es una persona que miente bajo presión. En lugar de decir la verdad, miente y 
piensa que puede salirse con la suya. Cuando se le acorrala o se le confronta dice: "No es mi 
culpa. No pude evitarlo. Además, yo no mentí. Tú no escuchaste lo que dije". Como decía 
mi padre rico: "La gente que no mantiene sus acuerdos pequeños son personas en quienes no 
se puede confiar. Si no eres digno de confianza en los acuerdos pequeños, la gente no te 
ayudará a hacer que tus sueños grandes se hagan realidad".
De modo que transmito las palabras de sabiduría tanto de mis dos padres y esas palabras 
son: "Asegúrate de que tus palabras y tus acciones sean uno". Mencionando las palabras rápi-das y las palabras lentas, te aseguro que parte de mi plan era comprender del todo cada una 
de esas palabras mental, emocional y físicamente. Mi padre rico insistía en que yo hiciera 
planes para saber el significado de palabras nuevas mental, emocional y físicamente. Por 
ejemplo, decía: "Tu vida cambiará para siempre cuando aprendas a comprar acciones al 
mayoreo versus pagar al menudeo. Cuando sabes lo rico que puedes hacerte comprando al 
mayoreo, nunca querrás volver a pagar al menudeo". También decía: "Tu vida cambiará para 
siempre una vez que sepas la diferencia entre ahorrar dinero y hacer dinero". Y "tu vida 
cambiará para siempre una vez que sepas por qué es mejor tener una depreciación en lugar 
de esperar y rezar para que se dé una apreciación". Decía: "Si dedicas tu vida a hacer que 
las palabras sean reales y formen parte de tu vida, ésta será muy diferente de la de alguien 
que sólo conoce las palabras por su definición mental".
Una parte significativa de mi plan era asegurarme de que las palabras nuevas y más rápidas 
que aprendía o de las que me volvía consciente se convirtieran en una parte activa de mi vida. 
Desde el punto de vista de mi padre rico, carecería de integridad si simplemente anduviera 
por ahí diciendo esas palabras financieras sólo para sonar inteligente, sólo para impresionar a 
otras personas y no las usara realmente en mi vida.
Así que la lección de mi padre rico y mi padre pobre que te transmito es que al crear tu plan, 
hagas que sea parte de él usar y entender por completo el poder de palabras nuevas y más 
rápidas que quieres en tu vida. No sólo debes saber la definición o, todavía peor, desconocer 
la definición e incorporar las palabras como una jerga especializada, esperando impresionar 
a los que estén poco informados. Haz que esas palabras sean parte de tu carne y 
aprovecharás el poder de la palabra.
Mi padre rico a menudo decía: "Hay predicadores y hay maestros. Los predicadores son 
personas que te dicen qué hacer pero ellas no hacen lo que te dicen que hagas. Los 
maestros son personas que le cuentan a la gente sobre lo que están haciendo o sobre lo que 
ya han hecho". Mi padre rico también decía: "En el mundo del dinero, los negocios y la 
inversión, tenemos demasiados predicadores".
En resumen
Si quieres retirarte joven y rico, tómate el tiempo para aumentar constantemente tu 
vocabulario financiero y tener la integridad para vivir tus palabras en vez de sólo decirlas. 
Siempre recuerda que las palabras son herramientas para el cerebro y que hay palabras 
rápidas y palabras lentas en el camino hacia la riqueza.
La palabra más destructiva de todas
Mi padre rico decía a menudo: "La palabra que más destruye la vida es la palabra mañana". 
Decía: "Los pobres, los que no tienen éxito, los que están infelices, los que no tienen salud 
son quienes usan más la palabra mañana. Esas personas con frecuencia dicen: 'Comenzaré a 
invertir mañana' o 'Empezaré mi dieta y comenzaré a hacer ejercicio mañana' y así sucesiva-mente". Mi padre rico decía que la palabra mañana es la que destruye más vidas que 
ninguna otra palabra. Decía: "El problema con la palabra mañana es que nunca he visto un 
mañana. Los mañanas no existen. Los mañanas sólo existen en las mentes de los soñadores y 
los perdedores. Las personas que posponen las cosas para mañana encuentran que los 
pecados y malos hábitos de su pasado al final los alcanzan". Terminó su comentario sobre 
las mañanas diciendo: "Nunca he visto un mañana. Lo único que tengo es hoy. Hoy es la 
palabra para los ganadores y mañana es la palabra para los perdedores".
En los próximos capítulos y lecciones, aprenderás cómo hacer cosas simples hoy... cosas 
simples que pueden mejorar en gran medida tus mañanas.
CAPÍTULO 12
El apalancamiento de los cuentos de hadas
Del patito feo al cisne
A mi padre rico le encantaba la historia de la liebre y la tortuga. Una vez me dijo: "Tengo éxito 
porque siempre he sido una tortuga. Yo no provenía de una familia rica. No fui bueno en los 
estudios. No terminé la escuela. No soy particularmente talentoso. Sin embargo, soy mucho 
más rico que la mayoría de las personas simplemente porque no me detuve. Nunca dejé de 
aprender ni de expandir mi realidad en lo que era posible para mi vida".
A mi padre rico le encantaban los cuentos de hadas y las historias bíblicas. Al comienzo de 
este libro, compartí contigo la historia de David y Goliat. A mi padre rico le encantaba la 
historia de que un chico pequeño haya podido vencer a un gigante usando el apalancamiento 
de una resortera. A mi padre rico le encantaban los cuentos de hadas, aunque no era un gran 
lector... pero absorbió las lecciones de esos cuentos y esas lecciones guiaron su vida... una 
vida que comenzó sin nada y al final se convirtió en un generador financiero.
Hubo muchas veces, cuando Kim y yo estuvimos quebrados v viviendo con muy poco, en que 
yo solía buscar un lugar para sentarme en silencio y escuchar de nuevo a mi padre rico 
contándome la historia de la liebre y la tortuga. Recuerdo que me decía: "Muchas veces en 
la vida encuentras personas que son más listas, más rápidas, más ricas, más poderosas y más 
dotadas que tú. Sólo porque te llevan ventaja no significa que no puedas ganar la carrera. Si 
conservas la fe en ti, haces las cosas que la mayoría de las personas no quiere y sigues 
haciendo progresos diariamente, la carrera de la vida será tuya".
Otro cuento de hadas que le encantaba a mi padre rico era la historia de los tres cochinitos. 
Con frecuencia, solía mezclar la historia de la liebre y la tortuga con la de los tres 
cochinitos.  Cuando yo tenía como doce años, mi padre rico dijo: "Las personas pobres 
construyen casas financieras de paja. La clase media construye casas de varitas. Y los ricos 
construyen casas de ladrillo". Luego añadía: "Para ser una tortuga exitosa, está bien ser lento, 
pero asegúrate de que lentamente estás construyendo una casa de ladrillo".
En 1968, mientras estaba en casa para las vacaciones de Navidad de la academia a la que 
asistía en Nueva York, mi padre rico y su hijo me invitaron a su nueva casa, que era el 
penthouse de su nuevo hotel. "¿Se acuerdan de cuando les contaba esas historias?", dijo 
mientras nosotros mirábamos desde su balcón la arena blanca y el agua azul cristalina del 
océano, "Las historias de la liebre y la tortuga y la de los tres cochinitos?"
"Sí", dije, todavía maravillado por la belleza de su nueva casa, en la cima de su nuevo 
hotel. "Las recuerdo bien."
"Bueno, ésta es la casa de ladrillos", dijo con una sonrisa,
Ese día en 1968, mi padre rico no tuvo que decir mucho más que eso. Había contado y vuelto 
a contar los cuentos de hadas tan a menudo que supe que el cuento de hadas se había 
convertido en realidad. Él era la tortuga que tomó el camino más largo, más lento, menos 
seguro, pero ahora estaba en la cima y estaba subiendo más alto. Tenía 49 años y en el 
camino había sobrepasado a muchas liebres. También supe que mi padre verdadero había 
construido una   casa de varitas, una costosa casa de varitas en un vecindario muy adinerado 
de Honolulú. A mi padre pobre lo acababan de ascender a jefe de los sistemas escolares del 
estado de Hawai.
Él también había alcanzado la cima de la escalera. El también  se había vuelto visible para el 
público, como mi padre rico. La diferencia era que uno controlaba su futuro y el otro no. 
Uno  vivía en una casa hecha de varitas y el otro en un rascacielos hecho de ladrillos. En 
tres años, mi padre perdería su empleo seguro y lo único que tendría sería su casa de varitas.
El valor de ser un patito feo
En 1968, mientras estaba parado en el balcón de su penthouse, mi padre rico me recordó otro 
cuento de hadas. Era un cuento de hadas que yo no me había dado cuenta de lo mucho que había 
significado para él porque nunca nos lo contó a su hijo y a mí cuando    éramos niños. 
"¿Conocen la historia del patito feo?", preguntó.
Asentí con la cabeza mientras me inclinaba en el balcón.
"Bueno, la mayor parte de mi vida me vi a mí mismo como el patito feo."
"Estás bromeando, ¿verdad? ¿Cómo podías verte como el palito feo?", me parecía algo difícil 
de creer porque mi padre rico era un hombre muy rico.
"Cuando me salí de la escuela a los trece años, veía el mundo como alguien externo... alguien 
que no encajaba, alguien que había sido dejado atrás. Mientras trabajaba en la tienda de mis 
padres, algunos chicos de preparatoria que estaban en el equipo de fútbol solían ir y me empujaban 
o dañaban la tienda. Muchos días, esos fortachones atléticos más grandes iban y a golpes bajaban 
las latas de lo estantes o arrojaban naranjas al camino y me retaban a hacer algo si respecto".
"¿Alguna vez les respondiste las provocaciones?", pregunté. "Dos veces lo hice, pero me 
golpearon muy fuerte", dijo mi padre rico. "Pero no sólo les estoy contando esta historia para 
hablarles sobre fortachones atléticos. En este mundo hay otro tipo de fortachones".
Preguntándome a dónde iba mi padre rico con esto, lo único que hice fue mirar hacia abajo 
por el balcón y escuchar mientras el seguía adelante.
"También he conocido personas que eran fortachones intelectuales o académicos. Solían ir a la 
tienda y me menospreciaban porque tenían una mejor preparación. Parecía que sólo porque 
pensaban que eran más listos que otras personas, podían desdeñar a los que no habíamos ido a la 
escuela."
"Yo tengo una escuela llena de esos tipos", agregué. "Parece que sólo porque piensan que son 
más listos que tú o que tienen mejores calificaciones, les da derecho a sonreír con desden 
cuando te hablan o de plano a tratarte con rudeza".
Mi padre rico asintió. Continuando, dijo: "Mientras trabajaba en la tienda, también conocí a 
los fortachones sociales. Miraban por debajo del hombro porque eran de familias ricas o eran 
hermosos, sexys, guapos, populares... y estaban en el grupo. Hubo muchas veces en que esos 
chicos se reían o se burlaban de mí mientras yo los atendía. Recuerdo haberle pedido que saliera 
conmigo a una chica del grupo y sus amigos se ríeron de mí por haber preguntado siquiera. 
Todavía recuerdo a una de las chicas diciendo: '¿Que no sabes que las chicas ricas no salen con 
chicos pobres?' Eso realmente me dolió".
"Todavía es así" dije. "Conocí a una chica que dijo que no saldría conmigo porque yo no asistía 
a una escuela de la Liga Ivy".
"Bueno, por lo menos estás en la universidad", dijo mi padre rico. "Cuando los chicos de mi 
edad se fueron a la universidad, me sentí solo, rezagado e indeseable. Y por eso, durante 
lodos esos años, me he visto a mí mismo como el patito feo". Mi padre rico nunca antes 
había compartido conmigo esa parte de su vida. Ahora yo tenía 21 años y me daba cuenta 
de que su hijo y yo teníamos las ventajas que él no había tenido.
 Sabía que a veces su vida había sido físicamente dura, pero no tenía idea de lo duro que 
había sido para él mental y emocionalmente.
Parado en el balcón de su prestigiado hotel, comencé a darme cuenta de que no me estaba 
contando la historia del patito feo para que sintiera lástima por él. Estaba sonriendo y era 
demasiado feliz como para estar haciendo eso. Así que le pregunté: "Usaste la historia del 
patito feo para seguir adelante, ¿no es así? No usaste esa historia para sentir lástima por ti, 
¿verdad?"
"No", contestó. "Usé la historia del patito feo, la de los tres  cochinitos, la de David y Goliat 
y la de la liebre y la tortuga para seguir adelante. En vez de dejar que esos chicos que eran 
fortachones atléticos, sociales o intelectuales me bajaran la  moral usé sus acciones 
esnobistas para inspirarme a hacerlo mejor. Hoy, tengo una casa de ladrillos y estamos en el 
penthouse de esa casa de ladrillos. Si no fuera por los cuentos de hadas o las historias 
bíblicas, no estaría aquí hoy. Ya no soy el patito feo. Al tomarme tiempo para construir una 
casa de ladrillos, usando tanto apalancamiento como usó David, y tomándome mi tiempo 
como hizo la tortuga, aquí me encuentro, en lo más alto de las calles en donde crecí."
 "¿Te convertiste en el cisne?", dije con una sonrisa. "Bueno, yo no iría tan lejos", rio mi 
padre rico. "El punto es que todos podemos crecer, evolucionar y hacer cambios drásticos en 
nuestras vidas, si así lo queremos. El otro punto es que los cuentos de hadas se pueden hacer 
realidad. Los patitos feos se pueden convertir en bellos cisnes y las tortugas lentas pueden 
ganar la carrera".
De patitos feos a cisnes ricos
En mis seminarios de inversión, con frecuencia doy las siguientes estrategias de salida:
Pobre 25 000 dólares al año
Clase media 25 000 a 100 000 dólares al año
Afluentes 100 000 a 1 millón de dólares al año
Ricos 1 millón o más al año
Ultra ricos 1 millón o más al mes
Les pido a los asistentes que no sean como Pinocho y que en cambio digan la verdad de lo que 
es real para ellos, si siguen haciendo las mismas cosas que están haciendo. Les pregunto: 
"¿Si siguen haciendo lo que están haciendo hoy, en qué nivel saldrán a la edad de 65 años?" 
También les recuerdo que menos de uno de cada 100 salen en el nivel de personas afluentes 
o más arriba?
Muchos admiten que se contentarían con salir al nivel de la clase media. Su preocupación 
principal es no salir en el nivel pobre. Sin embargo, pocos hacen la pregunta que estoy 
buscando, la cual es: "¿Qué tengo que hacer para pasar del nivel de las personas afluentes?" 
En el momento en que alguien hace esa pregunta, tiene la posibilidad de evolucionar de patito 
feo a emerger como un cisne financiero.
En esta etapa del curso de la inversión, es probable que vuelva a contar los cuentos de hadas o 
las historias bíblicas que me contó mi padre rico. Les pregunto: "¿Pueden adoptar las 
lecciones de esas historias como algo posible y real para ustedes? ¿Pueden imaginar dejar de 
ser un pato financieramente pobre y emerger como un cisne rico y poderoso?" Algunos 
pueden y otros sólo miran perplejos, preguntándose por qué estoy hablando de cuentos de 
hadas en una clase de inversión.
Luego digo: "Para mí cambiar de la mentalidad de la clase media a la mentalidad de las 
personas afluentes fue un cambio tan grande como pasar de patito feo a cisne".
De un plan lento a un plan rápido
En una de mis clases, una mujer joven me preguntó: "¿Cuál es el primer paso?"
Antes de contestar, en mi rotafolios dibujo la siguiente imagen:
Luego digo: "En 1989, dos años después de que había caído la bolsa y se había instalado una 
recesión, Kim y yo estábamos trabajando en nuestro plan. Era un plan lento. Kim y yo 
habíamos acordado que compraríamos dos propiedades de bienes raíces al año durante diez 
años. Como la bolsa cayó, encontramos cada vez más tratos a medida que cada vez más gente 
entró en pánico. En menos de un año, habíamos comprado cinco propiedades de alquiler 
pequeñas, cada una con flujo de efectivo positivo. Calculo que vimos 600 propiedades sólo para 
encontrar esas cinco casas pequeñas en las que tenía sentido invertir. Pero la bolsa estaba 
empeorando y cada vez estaban apareciendo más tratos. El problema es que no teníamos 
dinero".
"¿Así que tenían oportunidades pero no tenían dinero?", preguntó la joven.
Señalando el vaso del rotafolios dije: "Me di cuenta de que estábamos en los límites de 
nuestro contexto... de nuestra realidad".
"¿De modo que era momento de cambiar su realidad?", preguntó otro estudiante.
Asintiendo, dije: "Sí. Era momento de cambiar o de perder una ventana de oportunidad".
La clase estaba en silencio y escuchaba con atención. Sabiendo que tenía su atención, 
pregunté: "¿Cuántos de ustedes han visto una oportunidad pero no pudieron aprovecharla?" 
La mayoría de los asistentes levantaron la mano. "Cuando eso sucede", dije, "significa que 
estás en las fronteras de tu contexto, lo que piensas que es posible para ti y tu contenido, el 
conocimiento acumulado a través del cual manejas los problemas y los retos".
"¿Entonces qué pasa?", preguntó un estudiante. "¿Qué debemos hacer?"
"La mayoría de las personas se rinden diciendo 'no puedo hacerlo' o 'no puedo pagarlo'. 
Muchos pedirán su opinión a sus amigos y algunos amigos les dirán que jueguen a la segura, 
que no corran riesgos".
"¿Entonces qué hiciste?", preguntó un estudiante, "¿qué hiciste cuando te diste cuenta de que 
su plan era demasiado lento, de que había una ventana para una ventana de oportunidad y di 
que no tenían dinero?"
"Bueno, lo primero que hice fue admitir ante mí mismo que estaba siendo una tortuga que 
quería renunciar... y no era momento de renunciar, era momento de seguir adelante con fuer-za. También sabía que era momento de ser más cisne que pato. Teniendo en mente las 
lecciones de esos cuentos de hadas, seguí adelante en lugar de darme por vencido. Sabía que 
no tenía idea de qué hacer pero sabía que tenía que hacer algo. Los días sin saber qué íbamos 
a hacer se convirtieron en semanas. Un día después de que Kim y yo acabábamos de 
regresar de un viaje, yo estaba bajando nuestras maletas cuando sonó el teléfono. La 
llamada era de mi agente de bienes raíces preferido, que con voz emocionada dijo: 'Acabo 
de encontrar el trato del año. Si estás interesado, te daré una ventaja de media hora antes de 
decirle a otro de mis clientes'".
"¿Qué tipo de trato era?", preguntó un estudiante. "Me dijo que era un condominio de doce 
departamentos que estaba en una excelente zona y que sólo costaba 350 000 dólares, 35 000 
de pago inicial y que quien lo vendía estaba ansioso por vender. Luego el agente me envió 
por fax la información de venta de la propiedad con una pro forma en sucio sobre ingreso y 
gastos".
"¿La compraste?", preguntó otro estudiante.
"No", contesté. "Le dije al agente que me diera media hora y de inmediato iría hacia allá 
para verla. Cuando llegué me di cuenta de por qué era tan buen trato así que me apresuré 
hacia un teléfono público y le dije al agente que la tomaría."
"¿Aunque no tenías el dinero?", preguntó otro estudiante.
"No teníamos nada", dije. "Acabábamos de comprar la última de nuestras cinco unidades y 
realmente estábamos cortos de dinero porque estábamos invirtiendo en bienes raíces y 
reinvirtiendo también en nuestro negocio. Aunque no teníamos dinero, ofrecí a los 
vendedores lo que estaban pidiendo, es decir, 35 000 dólares de pago inicial y ellos dejarían 
los otros 300 000 dólares a ocho por ciento de interés durante cinco años. Era un trato tan 
bueno que no podía dejarlo pasar."
"¿Por qué era un trato tan bueno?", preguntó otro estudiante.
"Había muchas razones. Una era que los dueños vivían en la propiedad y nunca habían 
aumentado las rentas. Los arrendatarios eran sus amigos y ellos no tenían corazón para 
pedirles más dinero, así que las rentas estaban 25 por ciento por debajo del mercado. Otra 
razón era que la pareja era demasiado mayor como para administrar la propiedad y lo único 
que querían era mudarse. Como no eran inversionistas sofisticados, no apreciaban el valor 
de su propiedad. Tenían tanto miedo de que el valor de su propiedad se depreciara con la 
recesión que estaban muy ansiosos por vender. Otra razón por la que era una buena inversión 
era que se estaba construyendo una nueva fábrica de chips para computadora a casi un 
kilómetro y medio de distancia y más de mil nuevos empleados iban a mudarse a esa zona, lo 
que de nuevo significaba rentas más altas. Sin embargo, el hecho de que no tenía que ir a un 
banco a pedir dinero prestado fue lo que realmente hizo que el trato fuera bueno. Así que 
llamé a mi agente y le dije que aceptaría por completo sus precios y términos. Mi único 
problema ahora era conseguir los 35 000 dólares en 30 días, que era cuando la pareja quería 
mudarse".
"Así que durante 30 días no dejaste de preguntarte ¿Cómo puedo pagarlo? preguntó un 
estudiante.
"Bueno, durante dos noches, Kim y yo no dejamos de movernos, dimos vueltas, sudamos y 
nos preocupamos", dije. "No nos estábamos preguntando cómo podíamos pagarlo. Lo que 
no dejábamos de preguntarnos era por qué estábamos tan lejos. Yo no dejaba de 
preguntarme '¿Por qué estoy haciendo esto?' Nos está yendo bien. Nuestras inversiones 
están funcionando. ¿Por qué tengo que empujar las fronteras de mi zona de comodidad? No 
dejaba de pensar en los 35 000 dólares. Me di cuenta de que 35 000 dólares era más de lo 
que muchas personas ganaban al año antes de que les descontaran impuestos y ahora yo 
tenía que reunir ese dinero en efectivo en un mes. Quería renunciar. La confianza que tenía 
en mí mismo se veía retada, me sentía fuera de lugar, estúpido y tonto. Después de cuatro 
noches, finalmente me calmé y luego comencé a preguntar '¿Cómo podemos pagarlo?'"
"¿Y cómo pudieron pagarlo?", preguntó un estudiante. "¿O, más bien, pudieron pagarlo?"
"Finalmente, después de sudar, rezar y hacer nuestro mejor esfuerzo para no renunciar, 
llevamos los documentos a nuestro banco y presentamos nuestro historial al gerente del 
banco. Después de que nos rechazó, le pregunte por qué y qué podía yo haber hecho mejor. 
Después de que me lo dijo, fui al siguiente banco, aplicando las mejoras del primer gerente 
y de nuevo nos rechazaron. Luego de que nos rechazaron, le preguntamos al banquero el 
porqué. Para el quinto banco, yo había aprendido muchísimo sobre la información que 
querían los banqueros, por qué la querían y cómo querían que se las presentaran. Aunque 
nuestra presentación fue mucho mejor, otra vez fuimos rechazados por el quinto banco. 
Casi listos para renunciar, Kim y yo fuimos al sexto banco. Esta vez, estábamos mucho 
mejor preparados. También sabíamos por qué la inversión era tan buena. Al tratar de 
convencer a cinco banqueros, nos habíamos convencido a nosotros mismos mucho más 
sobre la solidez de esa inversión. Esta vez nuestra presentación fue más clara y mucho más 
profesional. Dijimos las palabras que los banqueros querían escuchar. Nuestros números 
eran claros e incluimos el historial de nuestras otras cinco propiedades. Ahora podíamos 
explicar con las palabras y los números de los banqueros por qué era una excelente 
inversión. El sexto banquero dijo que sí. En dos días tuvo listo nuestro cheque por 35 000 
dólares y en los tres días que nos quedaban fuimos a depositar el dinero y compramos el 
condominio de doce departamentos".
"¿Qué pasó después de eso?", preguntó un estudiante.
"El mercado de bienes raíces siguió bajando y nosotros seguimos comprando", contesté. 
"Aunque todavía teníamos muy poco dinero, seguimos comprando. Para 1994, el mercado 
dio un giro y quedamos financieramente libres por el resto de nuestra vida. Ese edificio de doce 
departamentos se vendió por más de 500 000 dólares en 1994 y nos había puesto en el 
bolsillo más de 1100 dólares mensuales durante ese periodo. Los 165 000 dólares en 
ganancias en bienes de capital se invirtieron con impuestos diferidos en un edificio de 
departamentos de 30 unidades, que es uno de los condominios que seguimos teniendo hoy en 
día. Ese condominio de 30 unidades comenzó dejándonos en el bolsillo un poco más de 5 
000 dólares mensuales. Con las demás propiedades e inversiones que teníamos estábamos 
ganando más de 10 000 dólares mensuales de ingreso pasivo, lo que nos colocó en el nivel 
de personas afluentes y nos permitió retirarnos. Teníamos como 10 000 dólares de ingreso 
pasivo y alrededor de 3 000 dólares de gastos mensuales. Éramos financieramente libres".
"Así que no fue suerte", dijo un estudiante. "Lo que se aceleró fue su plan." "Estábamos 
preparados para la ventana de la oportunidad y la tomamos", dije. "Poco después de 1994 
los precios de los bienes raíces se fueron por los cielos y se volvió un poco más difícil 
encontrar negocios así con gente dispuesta a vender."
"¿Así que hicieron bastante dinero sin poner nada de dinero suyo?", preguntó una estudiante.
"Sí, en ese trato. Pero no les recomiendo hacer lo que hicimos nosotros. Invertir en bienes 
raíces sin tener nada de dinero para el pago inicial puede ser muy arriesgado, si no sabes en 
qué estás invirtiendo y si no tienes las reservas de dinero por si las cosas no salen como lo 
esperabas. He conocido a muchas personas que compraron una propiedad sin tener nada de 
dinero para el pago inicial sólo para descubrir que los gastos de la propiedad eran más altos 
que el ingreso que recibían. He tenido amigos que han quedado en la bancarrota porque 
compraron propiedades o negocios que estaban apalancados demasiado alto. Por eso no 
aconsejo abiertamente comprar bienes raíces sin pago inicial. Recomiendo tener algo de 
experiencia en la compra, la venta y, en especial, la administración de bienes raíces antes de 
entrar en tratos con un apalancamiento alto. Habíamos visto cientos de otras propiedades 
antes de comprar ese condominio de doce departamentos en particular y también teníamos el 
flujo de efectivo de nuestros negocios para respaldar cualquier pérdida inesperada de la 
inversión. El problema con los bienes raíces sin pago inicial es que con frecuencia hay 
demasiado apalancamiento y ese tipo de inversiones con apalancamiento alto fácilmente te 
pueden comer vivo si algo sale mal. Así que repito lo que ya había dicho: No recomiendo a 
nadie que haga lo que hicimos. Les cuento esta historia por una razón".
"¿Y cuál es esa razón?", preguntó otro estudiante.
Volviendo al rotafolio, añadí algo al dibujo que había hecho previamente.
"La razón por la que les cuento esta historia es para explicarles la importancia de estar 
dispuestos a expandir su contexto al igual que a añadirle elementos".
"Así que para usted poder pagar hoy una propiedad de 335 000 dólares es fácil porque aumentó 
su realidad y su preparación. ¿Eso es lo que está diciendo?", preguntó un estudiante.
"Muy fácil", contesté. "Viéndolo en retrospectiva, parece tonto haber dejado que un pago 
inicial de 35 000 dólares pareciera mucho dinero y era un trato muy gordo. Lo importante 
para Kim y para mí fue la disposición de ir más allá de nuestro contexto y nuestro 
contenido."
"Así que la mayoría de las personas no empujan más allá de sus niveles de comodidad", dijo 
otro estudiante. "A la mayoría de las personas les resulta más fácil jugar a la segura y dicen 
'No puedo pagarlo'".
"Ésa ha sido mi experiencia", dije. "Creo que una de las razones principales por las que 
menos del uno por ciento de la población sobrepasa el nivel de las personas afluentes es 
simplemente porque a la mayoría le parece muy incómodo ir más allá de su realidad 
personal, su contexto y su contenido. La mayoría de las personas (raían y resuelven sus 
problemas financieros con lo que saben, en lugar de expandir lo que saben para poder 
resolver un problema mayor. En lugar de tomar mayores retos financieros, la mayoría de las 
personas luchan toda su vida con problemas financieros con los que se sienten cómodos. 
Siguen siendo cisnes pobres pero hermosos en lugar de arriesgarse a volver a ser el patito 
feo".
"¿Tú has vuelto a ser el patito feo?", preguntó un estudiante de una forma un poco cínica.
"Claro", dije. "Después del condominio de 335 000 dólares, nos pareció fácil invertir a un 
nivel de 2.5 millones de dólares. De 1994 al 2001, lo hicimos bien en ese rango hasta 2.5 
millones de de dólares y nuestro ingreso pasivo aumentó a alrededor de 16 000 dólares al mes 
sin mucho esfuerzo. Definitivamente estábamos en el nivel de las personas afluentes y era 
tiempo de pasar al de los ricos. Para quienes conocen nuestro pasado, es probable que 
recuerden que Padre Rico, Padre Pobre estaba en borrador, escrito entre 1995 y 1996, diseñé 
y creé el juego de mesa CASHFLOW en 1996 y regresé al mundo de los negocios. De 
manera simultánea, en 1996, supe que era momento de que yo supiera lo que era hacer 
pública una empresa, por medio del proceso de oferta pública inicial, que fue cuando 
conocí a Peter, como lo describí en el libro número tres Guía para invertir de Padre Rico. 
También en 1996, Kim y yo conocimos a Sharon Lechter y Padre Rico, Padre Pobre se 
publicó. Sharon, Kim y yo fundamos CASHFLOW Technologies, Inc. en el otoño de 1997. 
Estábamos entrando a un nuevo mundo con nuevos contextos, contenidos y amigos. Nuestro 
contexto de inversión en bienes raíces seguía estando en inversiones de 2.5 millones de 
dólares".
"De modo que te moviste para expandir tu contexto en otras áreas pero no expandiste tu 
realidad de bienes raíces. ¿Es eso lo que estás diciendo?", preguntó un estudiante.
"Eso es exactamente lo que estoy diciendo", dije. "Con Sharon Lechter como coautora y 
socia en el negocio, nuestra pequeña compañía creció mucho más allá de nuestros sueños 
más locos. Sin Sharon, no seríamos tan exitosos como lo somos ahora. Después de trabajar 
cinco años con Peter, tenemos entre cuatro y seis empresas que se estarán haciendo públicas 
a través del proceso de oferta pública inicial en los próximos años. Tanto en los negocios 
como en el proceso de oferta pública inicial, nuestra realidad sobre lo que es posible se ha 
expandido de manera considerable. Nuestro contexto en cuanto al negocio y el proceso de 
oferta pública inicial ha dado saltos gigantescos".
"¿Pero tu realidad en bienes raíces siguió siendo la misma?", dijo un estudiante. "Ha seguido 
siendo la misma desde el condominio de doce departamentos de 335 000 dólares. Se ha que-dado atorada entre 335 000 y 2.5 millones de dólares. Ésa es tu lección, ¿verdad?"
"Exactamente", dije. "Sólo porque una persona mejora en un terreno financiero no significa 
que se expanda en todos los terrenos. Por eso, en el 2001, Kim y yo decidimos que era 
momento para regresar a los bienes raíces y empujar de nuevo las paredes de nuestro 
contexto".
Hacerse rico se hace más fácil
Hace años, mi padre rico me dijo: "Una de las razones por las que los ricos se hacen más 
ricos es porque una vez que has encontrado la fórmula para hacerte rico, se hace más fácil 
hacerte rico. Si nunca has encontrado la fórmula, hacerle rico siempre parece difícil y seguir 
siendo pobre parece natural".
La razón por la que he pasado tanto tiempo cuestionando el lema de la realidad, contexto y 
contenido es porque era la fórmula de mi padre rico. Era su fórmula básica para nunca decir 
"no puedo pagarlo" o "no puedo hacerlo" y en cambio elegir expandir su realidad. Como ya 
sabes, mi padre rico usaba cuentos de hadas e historias bíblicas como las lecciones que guiaban 
su vida para seguir adelante a través de tiempos difíciles de duda y miedo. Pero fue su lección 
sobre la aceleración de la riqueza lo que me resultó más interesante. Solía decir: "Una vez que 
sabes que la fórmula para hacerte rico es expandir continuamente tu realidad, lo que aumenta tu 
apalancamiento, hacerte rico se vuelve cada vez más fácil. Para las personas que se quedan 
atoradas en una realidad, que piensan que su realidad es la única realidad, la velocidad a la cual 
pueden hacerse ricos disminuye".
En otras palabras, mi padre rico me enseñó que una vez que te haces rico, hacerte más rico 
todavía se vuelve más fácil y más rápido. Si nunca te vuelves rico, la vida se hace más difícil 
y más lenta. Sabiendo esto, supe que era tiempo de que Kim y yo comenzáramos a expandir 
de nuevo nuestra realidad en bienes raíces. Habíamos invertido durante cinco años 
expandiendo nuestra realidad sobre los negocios y los procesos de oferta pública inicial y nos 
habíamos hecho ricos mucho más rápido que nunca. Yo sabía que, en el siguiente nivel, 
hacerse ricos sería mucho más fácil y rápido. Lo sabía porque vi cómo le sucedió a mi 
padre rico.
Después de cinco millones se vuelve muy fácil
A finales del año 2000, la bolsa estaba cayendo, nuestro negocio se estaba expandiendo con 
rapidez, nuestros libros y juegos se vendían en todo el mundo, las empresas que estábamos 
haciendo públicas tomaban forma de manera agradable y pronto iban a ser redituables. Kim 
me dijo: "Quiero volver a los bienes raíces. Necesitamos invertir en activos más estables si 
queremos mantener nuestra riqueza". Con eso, volvimos al mercado y nos topamos con 
nuestra vieja realidad, nuestro viejo contexto y contenido. Me sentí como si hubiera 
regresado a tratar de conseguir 35 000 dólares para un condominio de 350 000 dólares. 
Aunque fácilmente podíamos escribir un cheque por tres condominios de 350 000 dólares, 
pagando en efectivo sin necesidad de un préstamo, otra vez estábamos teniendo problemas. 
Las cosas no estaban saliendo a nuestro modo. En ese punto, supe que era momento de 
expandir nuestra realidad una vez más.
Hasta entonces, Kim y yo estábamos buscando proyectos que estuvieran alrededor de 
cuatro millones de dólares. Nos sentíamos cómodos con ese número porque sabíamos que 
teníamos más de un millón para el pago inicial, si lo necesitábamos. Pensábamos que 
sabíamos mucho, pero no podíamos encontrar una propiedad ni el financiamiento que tuviera 
sentido o que funcionara de acuerdo con nuestro nuevo plan. Fue entonces cuando llamé a 
un viejo amigo llamado Bill, que ganaba cientos de millones de dólares en los bienes raíces. 
Después de localizarlo, le pregunté que había de malo en nuestro enfoque. La respuesta de 
Bill fue: "El mercado de cuatro millones de dólares es un mercado difícil. A los bancos no 
les gustan las  inversiones tan grandes y los proyectos de ese tamaño no resultan lo 
suficientemente emocionantes para inversionistas privados sofisticados. Pero después de 
cinco millones, otra vez se vuelve fácil".
En el momento en que me dijo eso, supe que estaba en la frontera de mi realidad, de mi 
contexto. Cuatro millones de dólares eran fáciles y cómodos, pero cinco millones ahora 
estaban justo fuera de mi zona de comodidad. Mi mente comenzó a gritar, diciendo: "¿Si no 
puedo hacer que un banco se interese en un proyecto de cuatro millones, cómo haré que se 
interese en una inversión en bienes raíces de cinco millones?" Podía oír cómo mi realidad me 
hablaba en voz alta. También podía oír a mi padre rico diciéndome que recordara los cuentos 
de hadas y que también recordara que hacerse rico se hace más fácil entre más rico te vuelves, 
si sólo sigues la fórmula. Supe que era tiempo de seguir la fórmula y empujar más allá de mi 
realidad.
Se volvió muy fácil
Al inicio de este libro, escribí sobre lo fácil que era retirarse pronto pidiendo dinero a los bancos. 
Una vez que Kim y yo estuvimos dispuestos a empujar más allá nuestra realidad, nuestra zona 
de comodidad, descubrimos que era igual de fácil pedir dinero prestado al gobierno.
He escrito cómo las leyes fiscales están a favor de quienes se encuentran en los cuadrantes D e I y 
en contra de los cuadrantes E y S. También escribí que la mayoría de las personas que se 
quejan por los impuestos son las que se encuentran en los cuadrantes E y A. La razón es que, en 
el lado D e I, el gobierno quiere ser tu socio, simplemente porque es el lado D e I el que crea 
empleos y proporciona vivienda. Siempre lo he sabido, porque mi padre rico me lo dijo, 
pero no tenía idea de lo mucho que el gobierno ayuda a quienes ayudan al gobierno, hasta que 
empecé a analizar inversiones en bienes raíces de más de cinco millones.... hasta que estuve 
dispuesto a expandir mi contexto.
Nuestra búsqueda estaba en curso. Ahora estábamos buscando proyectos más grandes que 
estuvieran mucho más allá de nuestra zona de comodidad. En nuestra primera junta en el 2001 
con  una vendedora de bienes raíces que se especializa en viviendas de bajo ingreso 
patrocinadas por el gobierno, Kim y yo le mostramos a la vendedora nuestro portafolio de 
bienes raíces.
En él teníamos millones de dólares en bienes raíces, principalmente en condominios de 30 a 
50 departamentos.
"¿Saben cómo administrar condominios multifamiliares", dijo la agente de bienes raíces, una 
mujer joven de casi 40 años. "Eso es bueno".
"¿Por qué es bueno?", preguntó Kim.
"Porque uno de los requisitos del gobierno es que cualquiera a quien le preste dinero debe 
tener un historial exitoso en la administración de condominios multifamiliares. Ustedes lo han 
estado haciendo por más de diez años y han hecho que resulten redituables. Muchas personas 
quieren esos préstamos del gobierno pero sólo unas cuantas califican para recibirlos", dijo la 
agente. "Como ustedes saben, la mayoría de las personas que tienen unas cuantas 
propiedades de inversión quieren administrar sus propios bienes raíces, cobrar sus rentas y 
hacer sus propias reparaciones. Por eso nunca aprenden cómo manejar propiedades grandes 
como ustedes".
Kim y yo asentimos. Sabíamos que en los bienes raíces había mucho más que simplemente 
cobrar las rentas y arreglar unos cuantos escusados. Habíamos aprendido mucho en los 
últimos diez años. Pero ahora era tiempo para seguir adelante. Si íbamos a hacerlo, teníamos que 
conocer gente nueva, aprender vocabulario nuevo y estar dispuestos a jugar un juego mucho 
más grande. Escuchando a esas dos nuevas personas en nuestras vidas, me di cuenta de que 
durante los últimos diez años nos habíamos vuelto liebres y cisnes en el mercado de bienes 
raíces de hasta cuatro millones de dólares. Éramos el proverbial pez grande en el estanque 
pequeño. Ahora era momento de seguir adelante y de estar incómodos otra vez, de volvernos 
tortugas lentas y patitos feos en un juego mucho más grande.
Sentado junto a la agente había un banquero de inversiones especializado en exención fiscal 
y contratos con el gobierno con o sin taza para vivienda. Cuando le pregunté qué tipo de 
programas de financiamiento tenía el gobierno, contestó: "Si usted y su proyecto califican, 
el gobierno le ofrecerá un financiamiento del 95 al 110 por ciento".
"¿Quiere usted decir que nos prestarán todo el dinero necesario para comprar nuestra 
siguiente inversión? ¿El gobierno nos dará el dinero para comprar nuestro activo?"
"Hasta más, si califican", dijo. "Si califican, el gobierno incluso les prestará el dinero para 
arreglar o rehabilitar el proyecto".
"¿Quiere usted decir que si el proyecto cuesta diez millones de dólares nos prestarán diez 
millones o más? ¿Y que si se necesitan tres millones de dólares para arreglar el lugar, 
también nos prestarán el dinero? ¿Nos prestarán todo el dinero para nuestra propiedad?"
El banquero de inversiones asintió. "Preferirían prestarle veinte millones de dólares o más, pero 
diez millones sería un buen lugar para empezar. Una vez que haga un proyecto de diez millo-nes de dólares, un proyecto de veinte o incluso 50 millones de dólares no estaría fuera de 
lugar... si tiene un historial probado".
Podía oír a mi padre rico diciendo que las cosas se hacían cada vez más fáciles. Pero no 
podía creer que se volviera así de fácil. Todavía un poco incrédulo pregunte: "¿En qué 
términos?"
"Yo podría asegurar tasas de interés entre cinco y siete por ciento, fijas por 40 años y no 
embargables".
"¿No embargables?", dije boquiabierto. "¿Quiere usted decir que el gobierno no irá tras todos 
mis bienes personales si el proyecto sale mal y no puedo devolver el dinero? Mi banquero odia 
los préstamos con embargo. Cada vez que le pido dinero prestado, se asegura que todo lo que 
tengo también esté en línea".
"Así es", dijo el banquero de inversiones. "Pero debe darse cuenta de que hay muchos 
términos y condiciones que se aplican aquí y no se aplican al financiamiento bancario 
convencional".
"Me doy cuenta de ello", dije. "Pero no tenía idea de lo bueno que podía ser el gobierno".
"En ocasiones, hay programas todavía mejores en esos contratos de exención fiscal del 
gobierno. También hay préstamos de condonación, donde el gobierno simplemente olvida 
que le pediste dinero prestado si haces bien ciertas cosas. Es muy similar a una concesión".
"¿Por qué hace esto el gobierno?", pregunté.
"Porque uno de los problemas que está encontrando este país es tener viviendas accesibles de 
bajo ingreso. El gobierno teme que sin personas como usted, millones y millones de personas se 
queden sin casa y se vean obligadas a vivir en barrios bajos por debajo del estándar y 
amenazados por el crimen. El gobierno está yendo tras los caseros de esas viviendas pobres 
y precios excesivos y está metiendo a algunos en la cárcel. Esos caseros abusan de los pobres 
y el gobierno quiere ponerles un alto. Al mismo tiempo, el gobierno está dispuesto a ofrecer 
miles de millones de dólares a individuos como usted que han demostrado ser administradores 
responsables de proyectos multifamiliares".
"Están dispuestos a darme el dinero para volverme aún más rico".
"Así es", dijo el banquero de inversiones mientras la agente de bienes raíces sonreía. "Es más 
que simple dinero. Es mucho dinero. Si lo hace bien durante unos cuantos años, yo puedo 
ayudarle a pedir prestados miles de millones de dólares, si quiere ser así de grande y de rico. El 
año pasado, una de nuestras divisiones tuvo que devolver más mil millones de dólares 
porque no pudo encontrar a alguien que calificara para el préstamo". Fue Kim la que dijo: 
"Lo mejor de hacerse rico de esta forma es que les hacemos mucho bien a muchas personas. 
Me emociona pensar en convertir un barrio bajo en viviendas seguras para gente con 
familia".
"Eso es exactamente lo que el gobierno quiere que hagan. De nuestros barrios pobres es de 
donde provienen la mayoría de nuestros problemas. De nuestros barrios pobres es de donde 
surge y crece el crimen. Si puedes transformar los barrios pobres en viviendas seguras, 
tendrás cada vez más dinero disponible para ti. Tanto como quieras".
"¿De modo que nos hacemos ricos haciéndonos socios del gobierno?"
"Tan ricos como quieran", sonrió el banquero de inversiones. "Lo único que tienen que 
hacer es lo que han estado haciendo durante los últimos diez años, es decir, tener y 
administrar condominios multifamiliares. Lo único que tienen que hacer es aprovechar sus 
diez años de experiencia. Y a nosotros nos encantaría ayudarlos a hacerse más ricos. ¿Saben 
lo difícil que es encontrar gente con sus años de experiencia? Sólo déjenos saber cuando 
estén listos. Ella les ayudará a encontrar su propiedad y yo les conseguiré todo el dinero 
que quieran".
Pronto terminó la junta, Kim y yo les dimos las gracias y nos dirigimos hacia nuestro auto. 
Una vez en ahí, nos quedamos sentados en silencio aturdidos de incredulidad. Pasaron 
algunos kilómetros antes de que dijéramos algo. Finalmente, Kim dijo: "¿Recuerdas el 
condominio de doce departamentos que compramos hace diez años?"
"Justamente estaba pensando en eso", contesté.
"¿Qué habría pasado si hubiéramos escogido decir: 'No puedo pagarlo?', dijo ella. "¿Cómo 
sería nuestra vida si hubiéramos dejado que esos 35 000 dólares nos detuvieran?"
Pensé por un momento y dije: "Pienso que seguiríamos diciendo lo mismo hoy. Si 35 000 
dólares nos hubieran detenido en ese entonces, probablemente nos estarían deteniendo hoy".
Mientras salíamos del estacionamiento, pude escuchar a mi padre rico diciendo: "Tu futuro 
está determinado por lo que  haces hoy, no mañana". Volviéndome hacia Kim, dije: "Si 
hubiéramos dicho ¡no puedo pagarlo! hace diez años, probablemente hoy seguiríamos 
diciendo 'No puedo pagarlo'".
Regresamos a casa en silencio, sintiéndonos emocionados y bendecidos. A medida que el auto 
subía hacia nuestra casa, pude oír a mi padre rico diciéndome que una vez que te haces rico, 
hacerte rico se vuelve cada vez más fácil. Pude escucharlo diciéndome que la razón por la 
que muchas personas nunca pasaron el nivel de vida de la clase media es porque no creyeron 
en los cuentos de hadas. Como no creyeron en los cuentos, no lograron aprender las 
lecciones de las historias. Mientras salí del coche, en silencio agradecí a mi padre rico y pude 
escuchar que me decía: "Siempre recuerda que los cuentos de hadas se hacen realidad... en 
una u otra forma".
CAPÍTULO 13
El apalancamiento de la generosidad
¿Quién es realmente codicioso?
La otra noche, uno de los comentaristas de noticias de fin de semana más famosos dijo en un 
tono acalorado: "No entré a los negocios porque no soy una persona codiciosa".
Durante gran parte de mi niñez, escuché comentarios como ese. Muchas de las personas que 
visitaban la casa de mis padres eran personas que trabajaban para la universidad, el sistema 
educativo, el sindicato, las fuerzas de paz o el gobierno. Aunque no lo decían de una manera 
tan evidente como el comentarista de televisión, con frecuencia se decía o se dejaba 
implícito que las personas en los negocios estaban en los negocios simplemente porque eran 
codiciosas.
Mi padre rico tenía un punto de vista muy diferente. Con frecuencia decía: "Todos somos 
codiciosos hasta cierto punto. Lo único natural es desear una supervivencia básica, una mejor 
vida y suficiente ayuda para vivir bien cuando dejamos de trabajar. Pero sólo porque alguien 
está en los negocios o es rico no necesariamente significa que es más codicioso que algún 
otro. De hecho, podría ser completamente lo opuesto". Luego decía: "La razón por la que 
muchas personas no son ricas es simplemente porque no son lo suficientemente generosas".
En el capítulo anterior, cuando Kim y yo decidimos incrementar nuestras posesiones de 
bienes raíces, la compuerta del dinero del gobierno también se abrió. En nuestro deseo por 
hacernos más ricos, uno de los primeros pasos era encontrar formas de ser más generosos... 
en este caso proporcionar mejor vivienda par más personas y a un mejor precio.
Cuando ves la historia, te das cuenta de que las personas más ricas han sido muy generosas 
de una u otra forma. Como mencioné antes, Henry Ford se hizo multimillonario 
proporcionando automóviles accesibles para las masas, en un tiempo en que los autos eran 
sólo para los ricos. De hecho, muchas de las compañías de autos que sólo hacían autos para 
los ricos ya no están en el negocio hoy en día. Las compañías automotrices para los ricos 
salieron del negocio, mientras Ford Motor Company se convirtió en una potencia industrial 
en todo el mundo, cumpliendo con la misión de Henry Ford. Así que si quieres retirarte 
joven y rico, está bien ser codicioso, siempre y cuando trabajes constantemente para encontrar 
formas de darle más a cada vez más personas. Si haces eso, encontrarás tu pro-pió camino 
hacia una gran riqueza.
Proporciones de los ricos
A mi padre rico le gustaban las proporciones porque, como él decía, "puedes decir mucho con 
sólo una pequeña comparación".  Para mi padre rico, las proporciones eran simplemente 
comparaciones, así como la proporción P/E es simplemente una comparación. En lo que 
respectaba al dinero, mi padre rico decía: "Una de las razones principales por las que las clases 
pobre y media luchan es porque sus proporciones no tienen apalancamiento". Él solía usar la 
proporción 1:1 para ilustrar la proporción de apalancamiento de una persona pobre o de 
clase media.
Un día, cuando todavía estaba en la universidad, mi padre rico me mostró sus proporciones. 
En un papel, escribió:
Negocios 1:5
Trabajadores 1:300
Bienes raíces                                                   1:450
Dólares: 1:6 millones
Acciones: 1:2
En otras palabras, su proporción de negocios significaba que tenía intereses en cinco negocios. 
Tenía más de 300 empleados que trabajaban para él. En bienes raíces, tenía más de 450 
inquilinos y esa cifra no incluía sus bienes raíces industriales, tiendas o restaurantes. A 
medida que pasaron los años, los números del lado derecho de la proporción siguieron 
aumentando continuamente, razón por la cual se volvió cada vez más rico,  mientras 
trabajaba cada vez menos.
La proporción de mi padre pobre comenzó en 1:1 y terminó en 1:1... razón por la cual se hizo 
cada vez más pobre. Como puedes decirlo a partir de la proporción de apalancamiento, mi 
padre pobre creía en el pago diario por un día de trabajo. Hubo veces en que mi padre pobre 
trabajó en dos empleos distintos. Aunque trabajaba en dos empleos su proporción siguió 
siendo de 1:1 según la definición de mi padre rico. El decía: "Si la mayoría de las personas 
tienen dos empleos, lo único que hacen es trabajar más horas según la misma proporción".
Entre 1985 y 1990, las proporciones para Kim y para mí se veían así:
Negocios 1: 1
Bienes raíces 1: 0
Dólares 1: no mucho
Teníamos un negocio que estábamos construyendo, éramos dueños de una casa pero no la 
contábamos como activo puesto que nos quitaba dinero cada mes y no teníamos casi nada 
ahorrado. Las acciones y otros activos en papel eran insignificantes, puesto que nos costaban 
dinero y nunca ponían dinero en el bolsillo.
Para 1995, nuestras proporciones de apalancamiento se veían así:
Negocios 1:0
Bienes raíces 1:70
Dólares                        1:300 000
Para esa fecha, habíamos vendido nuestro negocio, habíamos comprado bienes raíces que 
producían más ingresos y habíamos ahorrado algo de dinero en el banco. Lo importante era 
que los bienes raíces nos proporcionaban suficiente dinero para vivir en el nivel de personas 
afluentes y para nunca volver a trabajar.
Para el año 2000, nuestras proporciones de apalancamiento
se veían así:
Negocios 1:7
Bienes raíces 1:70
Dólares    1: millones
Acciones 1: 1.5 millones
A pesar de que las proporciones ilustran una imagen interesante del progreso financiero, las 
ganancias reales están en el terreno de los negocios, el terreno donde las valuaciones 
verdaderas del dinero, o flujos de efectivo, no se reflejan en las proporciones. No presento 
estos números para impresionar, puesto que no son tan impresionantes, ni los presento para 
presumir. De hecho, dudo en mostrar esos números porque son personales y preferiría no 
mostrarlos. Los enseño simplemente para ilustrar nuestro camino y nuestro plan. También 
los presento para dejarle saber a la gente cómo es posible empezar con muy poco y no 
obstante construir una casa financiera de ladrillos, como en la historia de los tres cochinitos.
Aunque los números no son grandes, cuando se los compara con el mundo de los ultra ricos, 
nuestro plan es continuar la aceleración de la riqueza por unos cuantos años más. Si las 
cosas van conforme al plan, pasaremos al mundo de los ultra ricos en unos cuantos años.
Es probable que por los números notes que nuestro plan de los últimos años era pasar a 
construir negocios en lugar de adquirir bienes raíces. Durante los siguientes cinco a diez 
años, nuestro plan es seguir creando más negocios, pero enfocarnos más en adquirir 
propiedades más grandes de bienes raíces con ayuda de los fondos del gobierno.
El punto que quisiera dejarte muy en claro ahora es la idea de la continua expansión de 
contexto, o realidad, y la constante búsqueda de un contenido más rápido y mejor, o educación. 
Si quieres seguir un camino similar hacia la riqueza, no puedo remarcar lo suficiente la 
importancia de tener una mente abierta, de ir más  allá de las dudas, limitaciones y 
complacencia personales, de estar dispuestos a aprender y a poner manos a la obra. He 
conocido muchas personas que quieren crecer financieramente a esa proporción, o más rápido, 
pero muchas no están dispuestas a expandir su contexto o a aumentar su contenido. De modo 
que ésas son personas que luchan en una cosa o pasan de un proyecto a otro, esperando que ése 
sea el que las haga ricas. Yo sostengo que si una persona tiene un contexto y un contenido en 
constante aumento, se hará cada vez más rica, sin importar cuál sea el proyecto. No es el 
proyecto o la idea nueva la que te hará rico. Es tu contexto y contenido lo que te hace rico. 
Como dije en otros libros, Ray Kroc se hizo multimillonario vendiendo miles de millones de 
hamburguesas promedio y Starbucks se hizo de una marca famosa en todo el mundo 
vendiendo tazas de café.
Con frecuencia mi padre rico decía: "Si no cambias tu contexto o tu contenido, tus 
proporciones seguirán siendo las mismas". Tengo un amigo que siempre tiene la idea nueva 
que hará millones de dólares. El otro día, me llamó y me pidió que invirtiera en su esquema 
más reciente. Tenía una idea excelente para una línea de ropa que no vende la tienda en la que 
trabaja medio tiempo. Dijo: "Todos los días, la gente viene a esta tienda buscando esa marca de 
ropa. Mi jefe no quiere llevarla. ¿Por qué no me das un poco de dinero para que abra una tienda 
justo enfrente de ésa? Dividiremos las ganancias a mitades".
Cuando le pregunté a este amigo si asistiría a clases sobre manejo de flujo de efectivo, 
manejo de mercancía al menudeo, mercadotecnia y contratación, y despido de personal, se 
negó. Su respuesta fue: "¿Para qué necesito hacer eso? He trabajado en esa tienda durante 
años. No necesito aprender nada más para dirigir una tienda". Después de que lo rechacé, 
volvió a llamar con otro proyecto y de nuevo lo rechacé.
Lo hice simplemente porque dudo que esté dispuesto a cambiar su contexto y su contenido. 
Lo único que quiere es hacer dinero... y debido a su edad, si fuera bueno con el dinero, ya 
sería rico. Así que sigue pensando que es la siguiente idea grandiosa, u oportunidad de 
negocios, la que lo hará rico, en vez de pensar que su limitado contexto y contenido es lo 
que lo está deteniendo. Aunque sí abriera esa tienda y sus nuevos productos fueran exitosos, 
sospecho que su proporción seguiría siendo 1:1. En otras palabras, probablemente tendría que 
estar en la tienda día y noche con muy poca oportunidad de expansión, debido a su contexto 
y contenido existentes.
Por qué es difícil hacerse rico
Es difícil o casi imposible hacerse rico con un contexto y contenido que te limita a una 
proporción de apalancamiento de 1:1. Es difícil hacerse rico porque no hay apalancamiento. 
Cuando ves el cuadrante de flujo de efectivo que se muestra a continuación, puedes 
empezar a entender por qué para el lado izquierdo del cuadrante, el lado E y A, es más 
difícil hacerse rico debido a las proporciones de apalancamiento:
Para la mayoría, el lado E y A tiene una proporción de 1:1, con muy poca excepciones. Por 
ejemplo, la mayoría de los empleados sólo pueden trabajar para una compañía a la vez. 
Aunque puedan tener un segundo empleo, sigue entrando en la proporción de 1:1. Lo mismo 
es cierto para muchos dueños de negocios pequeños o autoempleados. Lo más probable es 
que ese amigo mío que quería abrir una tienda de ropa estuviera encadenado a una tienda. 
Sinceramente, dudo de que pudiera manejar más de una tienda. Un dentista sólo puede 
taladrar en una boca a la vez y un abogado o contador sólo tiene una cierta cantidad de horas 
facturables al día.
Cuando hablé con mi asesora, Diane Kennedy, me dijo: "Una gran mayoría de profesionistas 
con ingresos altos del cuadrante A se quedan atascados en un rango de ingreso de 100 000 a 
150 000 dólares". Diane va más allá diciendo: " Los que ganan más lo hacen porque están 
altamente especializados y cobran mucho más por hora o por proyecto. Los rangos de ese 
grupo son de alrededor de 500 000 dólares al año. Muy pocos ganan más". De nuevo, el 
problema es la proporción de apalancamiento de 1:1.
En el capítulo anterior sobre los cuentos de hadas, uno de los mencionados fue la historia 
de la liebre y la tortuga. Una de las formas en que las liebres o conejos de la vida arrancan 
con un inicio rápido es porque tienen algún don, inteligencia o talento especiales. Pueden 
ser excelentes académicos, personas que aprenden rápido, atletas geniales o artistas como 
estrellas de cine. A muchos les va bien, muy pronto en la vida. Sin embargo, una tortuga 
como yo sabía que la forma en que ganaría mi propia carrera era usando las proporciones 
de apalancamiento. Era el mismo plan que usó mi padre rico. Tal vez si yo hubiera sido 
realmente listo y fuera un científico espacial, habría podido tener éxito en el mundo más 
tradicional de los negocios y escalar la escalera corporativa. Sin embargo, pronto en la vida, 
cuando comencé a tener problemas en la escuela, supe que tenía que encontrar mi propia 
forma de ganar la carrera. Hoy mi ingreso es mayor que el de muchos de mis compañeros 
que obtuvieron empleos bien paga dos pronto en la vida. Mi ingreso es más alto porque usé 
el apalancamiento de los activos en vez de usar el apalancamiento de mi mano de obra.
Para quienes quieren retirarse jóvenes y ricos, una de las decisiones que puede ser que 
necesiten tomar es encontrar en qué carrera tienen mayor oportunidad de ganar. Por 
ejemplo, si eres como la estrella del béisbol, Alex Rodríguez, a quien se le pagaron 252 
millones de dólares por un contrato de diez años, más apoyos comerciales, entonces 
obviamente el cuadrante E es el mejor para ti. Aunque la proporción de Rodríguez es 1:1 por 
diez años, es una proporción bastante buena cuando se añade el signo de dólares. Si puedes 
ser una estrella de cine como Julia Roberts, que gana veinte millones de dólares por 
película, entonces obviamente es el mejor camino para ti. El Secretario del Tesoro, en la 
administración de George W. Bush, Paul O'Neill, recibía más de 100 millones de dólares en 
participaciones y opciones de acciones como empleado de Alcoa. Aunque estaba en una 
situación de trabajo con una proporción 1:1, su compensación tenía mucho apalancamiento. 
Si piensas que tus posibilidades de tener éxito son mejores en el camino hacia la cima de la 
escalera corporativa de una empresa muy importante, entonces ése es el mejor camino para 
ti, aunque sea una proporción de 1:1. La razón por la que Kim y yo seguimos el mismo 
camino que usó mi padre rico fue simplemente porque sentíamos que en ese camino 
teníamos las mejores oportunidades de éxito financiero. Era un camino que nos requería de 
adquirir activos. Era un camino que requería de nosotros trabajar para incrementar 
constantemente nuestras proporciones de apalancamiento.
Un buen camino para las tortugas
Hay otra razón por la que yo personalmente elegí el camino de mi padre rico. La razón se 
encuentra en el diagrama del cuadrante de flujo de efectivo que se muestra a continuación.
Hace años, mi padre rico señaló el lado izquierdo del cuadrante y dijo: "El potencial de 
ganancias en el lado E y A es limitado. El potencial de ganancias en el lado derecho es 
infinito".
Mi padre rico explicó un poco más, diciendo: "El problema con vender tu mano de obra por 
dinero es que es lo único que puedes hacer. Si aprendes a adquirir o a crear activos para 
generar dinero, lento pero seguro puedes aumentar tu ingreso. De hecho, el lado derecho del 
cuadrante es un lado excelente para las tortugas, tortugas que lentas pero seguras van a 
adquirir más activos".
Mi padre rico también dijo: "El problema con vender tu mano de obra es que ésta no tiene 
valor residual a largo plazo, Si compras una propiedad de alquiler y la rentas de manera 
provechosa, la mano de obra que usaste para adquirir esa propio dad puede verse 
recompensada una y otra vez, por años  En otras palabras, te pueden pagar durante años por 
algo que tal vez te tomó menos de una semana de trabajo". Un ejemplo es el siguiente: En 
1991, Kim y yo compramos una propiedad en una zona recreativa por 50 000 dólares en 
efectivo. Fue un gran trato pues originalmente se vendía en 134 000 dólares. La compramos 
en una ejecución de hipoteca de un banco. Desde 1991, nos han pagado más de mil dólares al 
mes de ingreso neto o más de 12 000 dólares anuales durante años. El tiempo total que nos 
tomó comprar y poner en renta la propiedad fue de menos de ocho horas de trabajo. 
Habíamos pensado en vender la propiedad y tomar la apreciación, pero eso sería demasiado 
problema en este momento.
El problema con trabajar por dinero en un empleo es que tienes que empezar de nuevo a 
vender tu mano de obra todas las mañanas sin falta. En la mayoría de los casos, tu mano de 
obra no tiene valor residual a largo plazo, si estás trabajando por dinero. Además de eso, si 
estás trabajando por dinero tu potencial de ganancias es limitado. Si trabajas lentamente 
adquiriendo activos tu potencial de ingreso es infinito y ese ingreso puede legarse a las 
generaciones por venir. Tu trabajo o profesión no es algo que puedas legarles a tus hijos en 
tu testamento.
La vida se hace más fácil
Mi padre rico señalaba que trabajar por dinero vendiendo tu mano de obra con frecuencia 
significa que la vida se hace más difícil simplemente porque tienes que trabajar más duro 
para ganar más dinero. Decía: "Si la proporción de apalancamiento de tu vida permanece en 
1:1, entonces tu vida se hará más difícil.  Si trabajas para conseguir una proporción de 
apalancamiento en constante aumento, entonces la vida se hace más fácil y tú obtienes cada 
vez más dinero".
Un salto cuántico en la riqueza
La mayoría de nosotros hemos escuchado el término salto cuántico. Otros pueden usar el 
término exponencial, que significa más allá de un incremento lineal en algo. En otras pala-bras, uno más uno no es igual a dos. En un salto cuántico en la riqueza o en un aumento 
exponencial del dinero, uno más uno pude ser igual a cinco, seis, siete o más. En otras 
palabras, si trabajas diligentemente y construyes una casa fuerte de ladrillos, he descubierto 
que con frecuencia hay repentinos saltos  cuánticos de riqueza, saltos cuánticos que las 
personas que siguen una proporción de 1:1 no parecen tener.
Por ejemplo, entre 1985 y 1990, para Kim y para mí la vida tuvo mucho de lucha financiera. 
De pronto, entre 1990 y 1994, Kim y yo tuvimos una explosión repentina y exponencial en 
riqueza y éxito financiero. De 1994 a 1998, otra vez la vida fue bastante estable. Trabajamos 
con diligencia construyendo activos, más específicamente negocios. No compramos mucho 
en el terreno de los bienes raíces, porque los precios de las propiedades habían subido 
demasiado y encontrar un buen trato tomaba demasiado tiempo. Luego, de repente, en 
1999, no sólo mis libros y juegos comenzaron a despegar, sino que muchos otros negocios e 
inversiones comenzaron a despuntar.
Parecía como un auge repentino de buena suerte, nuevos amigos y nuevas oportunidades, 
sin embargo, en realidad, la fuente de ese auge de riqueza exponencial fueron años de 
trabajar sin muchos resultados y de padecer obstáculos financieros. La razón por la que 
pasa esto es porque el valor de los activos con frecuencia aumenta de manera exponencial 
mientras que el valor de tu mano de obra sólo aumenta incrementalmente. Por ejemplo, mi 
contadora me dijo que el valor de una de mis compañías ascendió a la cantidad de 40 
millones en el año 2000. Ése era el precio al que consideraba que podíamos venderla si 
queríamos. Al mismo tiempo, uno de mis abogados aumentó su tarifa por hora a 25 dólares. 
Ése es un ejemplo de activos que aumentan de manera exponencial y de un ingreso que 
aumenta incrementalmente. Es otro ejemplo de cómo el potencial de ganancias del lado 
izquierdo del cuadrante es limitado y el potencial de ganancias del lado derecho es casi 
infinito.
Otro ejemplo de salto cuántico sucedió en el número de acciones de empresas que teníamos. 
Entre 1996 y 1998, trabajamos en la adquisición de acciones de una compañía pública. Ésta 
quebró de repente y nosotros perdimos todo lo que teníamos en esa empresa. Nuestras 
acciones prácticamente perdieron todo su valor. Sin embargo, debido a la experiencia que 
obtuvimos trabajando para adquirir una participación mayor en la compañía, transferimos lo 
que habíamos aprendido a adquirir acciones en buenas empresas que comenzaban y esas 
acciones han seguido haciéndolo muy bien, incluso en un mercado bursátil a la baja.
Al comienzo de este libro, escribí sobre el periodista que me criticó diciendo que la mayoría 
de las nuevas compañías fracasan al principio. Hoy, aunque los riesgos para empezar un ne-gocio siguen siendo altos, la experiencia que obtuvimos con esas pequeñas empresas con 
problemas que fracasaron se ha agregado a mi habilidad para empezar compañías más 
estables y que tienen mejores probabilidades de éxito a largo plazo. Cuando veo el éxito de 
Padre Rico, Padre Pobre y de nuestra compañía, richdad.com, gran parte de nuestro éxito 
actual se debe en gran parte a mis fracasos del pasado. Sharon y Kim también tuvieron sus 
obstáculos, sus desilusiones en los negocios, sin embargo, esos obstáculos se convirtieron 
en las lecciones aprendidas que contribuyeron a nuestro éxito combinado actual. Lo que 
nosotros, como grupo, aprendimos de nuestros pasados individuales es lo que nos da lo que 
parece ser el repentino salto cuántico de éxito que disfrutamos hoy.
Menciono todo esto como una forma de animarte a seguir adelante, aunque puedas 
encontrar algunos obstáculos en el camino de tu vida. Si aprendes de cada obstáculo, en vez 
de culpar o inventar excusas, tu riqueza de conocimiento aumentará. Si trabajas con 
persistencia para ser más generoso, para servirle a más gente, para incrementar tus 
proporciones de apalancamiento, estoy bastante seguro de que tú también experimentarás 
esos auges repentinos, saltos cuánticos o exponenciales en la riqueza. Parece que hasta las 
tortugas pueden avanzar con una repentina ráfaga de viento a favor.
El poder de las redes
Me topé con una ley conocida como Ley Metcalfe que explica parcialmente el salto cuántico 
o el estallido exponencial de riqueza. Robert Metcalfe es uno de los fundadores de 3Com, la 
empresa que te dio PalmPilot. Su ley dice que el poder económico de un negocio es el 
cuadrado del número en la red.
La historia del fax nos ayuda a entender este concepto más claramente. En mis primeros 
días en Xerox Corporation, nos dieron la tarea de vender máquinas de fax. El problema a 
comienzos de los setenta era que muy pocas personas tenían fax y menos todavía sabían lo 
que hacía. Como había tan pocas máquinas de fax, su valor económico era bajo. No 
obstante, a medida que pasó el tiempo y cada vez las usó más gente, hubo un repentino 
estallido en su popularidad, Hoy, la mayoría de mis amigos tienen fax en su casa y en su 
negocio.
Así que la Ley Metcalfe es la siguiente: Si tienes sólo un fax, tu valor económico es uno, 
según la fórmula:
1:1 (al cuadrado)
El valor económico de uno sigue siendo uno. Pero en el momento en que tienes dos 
máquinas, el valor económico de la red no asciende linealmente. Se incrementa de manera 
cuántica. Al momento en que tienes el segundo fax, el valor económico asciende a cuatro, no 
a dos:
1:2 (al cuadrado) = valor económico de 4
Cuando había diez máquinas de fax en la red los números se veían así:
1: 10 (al cuadrado) = valor económico de 100
El cuadrante A sufre
Las personas que operan como propietarios individuales, u otras formas de autoempleados o 
dueños de negocios pequeños, con frecuencia no tienen el beneficio de la Ley Metcalfe. Una 
de las razones por las que una franquicia como McDonald's es más poderosa que un 
restaurante familiar de hamburguesas se debe otra vez a la Ley Metcalfe.
He descubierto que las personas que trabajan duro para ser individuos resistentes con 
frecuencia tienen que trabajar más sólo para mantener su autonomía. Por eso muchos 
profesionistas se unen a asociaciones para tener más poder en el mundo.
El cuadrante E se sindicaliza
Por años, las personas del cuadrante E han conocido el valor de organizarse en un sindicato. 
Juntos, los empleados del cuadrante E tienen mucho más poder que si trataran de negociar 
como individuos. Hoy en día, uno de los sindicatos más ricos y poderosos de Estados Unidos 
es la NEA (Asociación de Educación Nacional, por sus siglas en inglés). Una de las razones 
por las que nuestro sistema educativo cambia muy lento se debe en gran medida al poder 
del sindicato de maestros. Ellos conocen el poder de una red.
El poder del monopolio
Mi padre rico con frecuencia decía: "La fórmula para una gran riqueza se encuentra en el 
juego Monopolio". Muchos de nosotros conocemos esa fórmula, la de comprar cuatro casas 
verdes y cambiarlas por un hotel rojo. La fórmula para la riqueza que se encuentra en el juego 
Monopolio también sigue la Ley Metcalfe. Al ver la comparación entre la proporción de mi 
padre pobre y la de mi padre rico, es probable que entiendas por qué el poder económico de 
mi padre pobre siguió siendo el mismo.
                              Padre Pobre               Padre Rico
Bienes raíces      1:1 nunca cambió 1:450 en constante aumento
En otras palabras, el poder económico de mi padre pobre siguió en el nivel uno. Uno al cuadrado 
sigue siendo uno. Lo único que tenía era su casa. En este ejemplo, el poder económico de mi 
padre rico era de 450 al cuadrado. Controlaba más de 450 unidades de alquiler. Su poder 
económico estaba subiendo de manera exponencial. Cuando ves la proporción de 1:1 de mi 
padre rico y luego incluyes el efecto negativo que los impuestos tenían en su ingreso, ganado al 
50 por ciento, realmente puedes ver cómo el poder económico de mi padre pobre no aumentó, 
aunque trabajó cada vez más y más duro. El ingreso de mi padre rico subía, su poder 
económico aumentaba y estaba pagando cada ve/ menos impuestos.
En 1985, Kim y yo teníamos un plan para adquirir dos nuevas unidades de alquiler al año. 
Comenzamos comprando nuestra primera propiedad en 1989. Cuando tuvimos cinco 
unidades, nuestro poder económico era de cinco al cuadrado o 25. Nuestro poder económico 
no sólo subió, nuestra confianza también había subido a medida que aumentó nuestra 
experiencia. Cuando compramos el condominio de departamentos de doce unidades, nuestra 
proporción de apalancamiento era de 1:17 y nuestro poder económico era 1:17 al cuadrado o 
289. Para otros que lo único que tenían era su casa y que no compraron propiedades de 
inversión durante la baja del mercado, su proporción de bienes raíces se quedó en 1:1 y su 
poder económico se quedó en uno. Para Kim y para mí, nuestra meta para el año 2005 es tener 
mil  unidades de alquiler o más en nuestro portafolio. La pregunta es ¿cuál es el poder 
económico de mil al cuadrado?
Este ejemplo explica cómo una persona que opera en los cuadrantes D o I rápidamente 
pueden pasar a una persona muy inteligente, talentosa o bien educada en los cuadrantes E o 
A, aunque la persona de los cuadrantes E o A gane más dinero. La ley Metcalfe explica por 
qué mi padre rico al final ganaba más en un año de lo que mi padre pobre ganó en toda su 
vida. La Ley Metcalfe también explica por qué las tortugas pueden vencer a las liebres si 
continúan adquiriendo activos en lugar de trabajar por dinero como muy a menudo lo hacen 
muchos conejos.
Negocios de mercadotecnia en red
Después de entender la Ley Metcalfe, la ley de las redes, supe por qué las organizaciones de 
mercadotecnia en red ofrecen una herramienta tan poderosa a las personas promedio como 
tú y como yo. Al aplicar la Ley Metcalfe a un negocio de mercadotecnia en red, comienzas 
a ver el poder de esta forma de negocios.
Por ejemplo:
Una persona del cuadrante E o A decide unirse a una organización de mercadotecnia en red y 
aprende a pasar al cuadrante D. Trabaja por un año o dos, obteniendo la preparación y men-talidad necesarias. Digamos que por dos años, no pasa mucho. La gente va y viene de su 
negocio, en lugar de quedarse. Así que después de un año o dos, su proporción de 
apalancamiento o poder económico es el mismo. No es muy distinto de estar en el cuadrante 
E o A:
1:1 al cuadrado Poder económico de 1
De pronto, en el tercer año, el contexto de esa persona se expande y tienen un nuevo 
contenido y de repente atrae y entrena a tres candidatos fuertes que también quieren crear 
negocios.
Su proporción de apalancamiento y su poder económico se ven de la siguiente manera:
1:3 Poder económico de 9
En tres años, es un salto cuántico de poder. Después de cinco años, esa persona tiene una 
red de diez y su proporción de apalancamiento se ve de la siguiente manera:
1:10 Poder económico de 100
Y ahora digamos que esta persona decide que diez personas son suficientes y se enfoca sólo 
a las diez personas que están cada una en su negocio. Poco después de unos años, digamos 
que las diez personas de su red también tienen a diez personas (1:10:10). Eso significa que 
la persona original ahora tiene a 100 personas en su red.
Luego, con su excedente de efectivo, esa persona empieza a comprar condominios. 
Comienza con uno de cien unidades:
Negocios 1:10:10 Bienes raíces 1:100
En cinco o diez años, este individuo no sólo ha hecho el cambio del lado E y A del 
cuadrante, sino que ha elevado su poder económico tanto en el cuadrante D como en el I, 
algo difícil de hacer en los cuadrantes E y A. De repente, la persona que hizo el cambio es 
mucho más acaudalada, gana mucho más dinero y tiene más poder económico que los 
compañeros que dejó atrás en los cuadrantes E o A.
Después de quince años, los números podrían ser impresionantes.
Éste es un ejemplo demasiado simplificado de por qué recomiendo a algunas de las empresas 
de mercadotecnia en red. Como su nombre lo indica, es una red... que aprovecha la Ley 
Metcalfe, que mide el poder de las redes.
Hoy, cuando hablo con personas que están preocupadas por su retiro o los fondos de 
inversión en su cuenta de retiro, con frecuencia les recomiendo que agreguen a su portafolio 
negocios de mercadotecnia en red. Les digo: "Si realmente sigues las lecciones que enseñan 
algunos de los negocios de mercadotecnia en red y construyes un negocio sólido en tu red, 
encontrarás que ese negocio es mucho más seguro que los fondos de inversión que se 
encuentran en tu fondo de retiro. Si verdaderamente trabajas duro para que quienes están en 
tu red sean ricos, a su vez, ellos te harán rico y te darán mucha seguridad.
En mi opinión, un negocio de mercadotecnia en red es mucho más seguro que la bolsa 
porque cuentas con personas que has llegado a querer y en quienes has llegado a confiar y 
todos están aprovechando el poder de la Ley Metcalfe... la ley que mide el poder de las 
redes".
Las redes aprovechan el poder de la generosidad
Los ricos y poderosos entienden el poder de las redes. McDonald's es una red de 
restaurantes de hamburguesas ligada por todo el mundo. General Motors es una red de 
concesionarios de automóviles en toda América. Exxon es una empresa de petróleo con 
campos, tanques y pipas de petróleo, así como gasolineras ligados por todo el mundo. Si el 
rico y poderoso usa redes, ¿no deberías hacerlo tú también? Safeway es una cadena de 
tiendas de comida que distribuye alimentos por todo Estados Unidos, CBS, NBC, ABC, CNN, PBS, 
CBN son redes de comunicación muy poderosas.
Mi padre rico decía: "Si quieres ser rico, debes construir redes y unirlas con otras redes. La 
razón es que es fácil hacerte rico a través de las redes porque es fácil ser generoso a través 
de las redes. Por otro lado, la gente que actúa sola o como individuo limita sus posibilidades de 
éxito económico". Luego agregaba: "Las redes son personas, negocios u organizaciones con 
las que eres generoso porque las apoyas y ellas te apoyan. Las redes son formas poderosas 
de apalancamiento. Si quieres ser rico, construye una red y únete a otras redes".
Nuestro plan de negocios para richdad.com está basado en hacer redes en vez de competir 
contra organizaciones, en especial si son más grandes que nosotros. Hoy, tenemos redes con 
AOL Time Warner, Time Life, Nightingale-Conant, PBS, editores en más de cuarenta países 
diferentes, muchas organizaciones de iglesias y varias compañías de mercadotecnia en red. 
Trabajamos juntos para hacer que el otro sea más fuerte y viable, así como más rico. Hay un 
dar y tomar, compartimos fuerzas y minimizamos las debilidades para hacernos todos más 
fuertes.
Hemos descubierto que por medio de ser cooperativos y de enfocarnos en asegurarnos de 
que las personas con quienes hacemos negocios  tengan éxito financiero crecemos 
exponencialmente. He notado que los individuos o negocios que se enfocan principalmente 
sólo en hacerse ricos o en tomar más de lo que dan no son buenos socios de redes. He 
notado que las personas que sólo quieren tomar y que sólo están preocupadas por ellas 
mismas con frecuencia tienen que trabajar más duro y ganan menos a largo plazo.
Una vez estuve en una mesa directiva de una empresa en donde era obvio que el presidente 
no se preocupaba por la compañía. Lo único que le preocupaba eran sus pagos y su paracaídas 
dorado. No le preocupaba la red, en este caso un negocio con cientos de empleados que le 
daban vida. Lo único que le preocupaba era él mismo. Sobra decir que pusimos a un nuevo 
presidente. El punto clave para tener éxito en las redes es estar interesado sinceramente en 
asegurarse primero de que a los individuos u organizaciones con quienes haces redes también 
les está yendo bien. No sólo puedes preocuparte por ti, como parecen hacerlo demasiadas 
personas y organizaciones.
En el transcurso de los años, Kim, Sharon y yo hemos encontrado individuos, asesores u 
organizaciones que sólo estarían dispuestos a trabajar con nosotros si tenían la seguridad de 
que se les pagará antes. En otras palabras, los honorarios totales que les pagamos parecían 
ser más importantes que el servicio que proporcionaban.
Recientemente, contratamos a una firma de consultoría para que fuera a revisar nuestros 
sistemas internos de mercadotecnia. Pidieron unos honorarios considerables antes de hacer 
cualquier tipo de trabajo. Les pagamos y tres meses después llegó su reporte. Después de 
revisar el galimatías de su reporte, nos dimos cuenta de que lo único que éste decía era que 
debíamos conservar su firma y pagarles durante tres años más. No había una sola 
recomendación de cómo mejorar nuestros sistemas de mercadotecnia. Sólo había una 
propuesta para más trabajo. Éste es un ejemplo de un vendedor que antepone sus honorarios 
frente a las necesidades del cliente. Sobra decir que no firmamos el contrato.
Cuando estaba en preparatoria, mi padre rico me pidió que fuera y viera cómo contrataba a 
un nuevo empleado para manejar uno de sus parques industriales. En la junta, en su sala de 
conferencias, había tres candidatos. Después de que mi padre rico terminó de explicar el 
trabajo, preguntó si alguno tenía alguna pregunta. Las preguntas fueron interesantes:
1.¿Cuánto tiempo libre tendré diario?
2.¿Cuántas incapacidades por enfermedad hay?
3.¿Cuáles son los beneficios?
4.¿Cuándo puedo obtener un aumento de sueldo y un ascenso?
5.¿Cuántas vacaciones pagadas tengo?
Después de la junta, mi padre rico me preguntó qué había notado.
Contesté: "Sólo estaban interesados en lo que tenían enfrente. Ninguno te preguntó de qué 
manera podía ayudarte a construir tu negocio o qué podía hacer para que el negocio fuera 
más rentable".
"Eso es lo que noté", dijo mi padre rico.
"¿Vas a contratar a alguno de ellos?"
"Claro", dijo mi padre rico. "Estoy buscando un empleado, no un socio. Estoy buscando a 
alguien que quiera ganar dinero, no hacerse rico".
"¿No te sonó codicioso?", pregunté. Quienes han leído mis demás libros, es probable que 
recuerden que mi padre rico siempre me hizo trabajar gratis, no por dinero.
"Sí, así es", dijo mi padre. "Pero todos somos codiciosos hasta cierto punto. La razón por la 
que probablemente ellos nunca serán ricos es porque no son lo bastante generosos".
En otras palabras, su proporción de apalancamiento probablemente será de 1:1. Repitiendo lo 
que dijo mi padre rico: "La mayoría de las personas no se harán ricas porque en lo único en 
que piensan es en recibir un pago diario por día trabajado. No hay mucho apalancamiento en 
un pago diario por día trabajado porque sin importar lo mucho que trabajes o lo mucho que 
te paguen, la proporción sigue siendo 1:1".
Una de las razones por las que mi padre rico hizo que su hijo y yo aprendiéramos a trabajar 
gratis fue porque de esa forma aprenderíamos a dar y construir un activo antes de recibirlo. 
Hace años, mi padre rico dibujó el siguiente diagrama para explicar su punto. Mi padre rico 
lo llamaba el diagrama de "A quién le pagan primero y a quién le pagan más":
5. Dueño del negocio
4. Inversionistas
3. Especialistas (contadores, empleados, asesores)
2. Empleados
1.. Activo (negocio u otra inversión)
Mi padre rico decía: "El dueño de un negocio debe pagar primero el activo. Eso significa 
reinvertir continuamente dinero y recursos suficientes para mantener al activo fuerte y cre-ciendo. Demasiados dueños de negocios se ponen primero que al activo, los empleados y 
cualquier otra persona. Por eso sus negocios fracasan. La razón por la que el dueño de un 
negocio recibe su pago al último es porque comienza un negocio para ser a quien se le 
pague más. Pero para ser a quien se le pague más, el dueño del negocio debe asegurarse de 
pagar primero el resto del negocio. Por eso te estoy entrenando para que no trabajes por 
dinero. Estás aprendiendo a delegar gratificación y trabajo para construir activos que 
aumenten de valor. Quiero que aprendas a construir activos, no a trabajar por dinero".
Demasiadas empresas punto com y otras empresas nuevas no logran seguir este diagrama o 
el consejo de personas como mi padre rico. He conocido a muchas personas que forman un 
negocio pidiendo dinero prestado o consiguiendo capital de amigos, familiares y otros 
inversionistas. De inmediato, rentan una oficina grande, compran un auto elegante y se 
pagan sueldos exorbitantes del capital de los inversionistas en lugar de hacerlo del ingreso 
del negocio. Como el capital de los inversionistas está mal administrado y sigue sin ingreso, 
entonces tratan de pagarle lo menos posible al negocio, a sus empleados y a sus 
inversionistas. En negocios así, los inversionistas son quienes con frecuencia se quedan 
atorados con la cuenta, como fue el caso de muchas empresas punto com y empresas 
nuevas.
Mi padre rico nos decía a su hijo y a mí: "Las personas a quienes se les paga primero al 
final se les paga menos. El dueño del negocio debería pagarse a sí mismo al final porque está 
en el negocio para construir un activo. Si está en los negocios para obtener un sueldazo, no 
debería estar en los negocios... debería estar buscando trabajo. Si el dueño del negocio ha 
hecho un buen trabajo pagándoles a todos los demás para construir un activo, el activo 
debería valer mucho más de lo que habría podido pagarse alguna vez".
Mi padre rico decía: "La mayoría de las personas no están en el mundo de los negocios para 
construir o crear activos. La mayoría están en el mundo de los negocios como empleados o 
autoempleados especialistas porque quieren un sueldo. Esa es una de las razones principales 
por las que menos del cinco por ciento de la población de Estados Unidos es rica. Sólo el 
cinco por ciento de la población se da cuenta del valor de los activos sobre el del dinero". 
También decía: "El dueño del negocio o empresario se queda con buen dinero al final del 
día porque debe ser más generoso al comienzo. El dueño del negocio corre los mayores 
riesgos y también se le paga al último. Si ha hecho un buen trabajo, la cantidad de dinero 
puede ser impresionante". Por eso todavía sigo el diagrama de mi padre rico cuando 
comienzo cualquier negocio y por eso sigo trabajando gratis. Lo hago porque quiero el 
mayor dinero al final del día.
Demasiadas personas en los cuadrantes E o A están limitadas por el número de personas u 
organizaciones a quienes pueden servir... de ahí que su ingreso sea limitado. Un verdadero 
dueño del cuadrante D, que se enfoca a crear un negocio que continuamente sirva a cada vez 
más personas, se hará cada vez más rico. Obtiene una gran recompensa simplemente porque 
construye un sistema o activo para servir a más personas. Por eso el dueño de un negocio 
puede hacerse rico de manera exponencial y la gente que trabaja para obtener un sueldo se 
hace rica de manera incremental.
¿Qué tan rápido puedes hacerte rico?
La buena noticia es que nunca ha sido más fácil y menos costoso hacerse rico. En lo único en 
lo que tienes que enfocarte es en servirle a cada vez más personas. En la época de John D. 
Rockefeller, le tomó aproximadamente quince años hacerse multimillonario. Para que lo 
lograra, tuvo que adquirir muchos pozos petroleros y crear una red de gasolineras y sistemas 
de entrega de gasolina. Eso le tomó mucho tiempo y dinero. Hoy se necesitarían miles de 
millones de dólares para construir lo que construyó Rockefeller.
A Bill Gates le tomó aproximadamente diez años hacerse millonario. Tuvo la visión de usar 
la red de IBM para crecer con rapidez. A Michael Dell y Steve Case, fundadores de AOL, les 
tomó menos de cinco años hacerse multimillonarios. Un empresario usó la creciente 
demanda de computadoras y el otro uso el poder explosivo de la Red Global Mundial para 
aprovechar el poder de una red explosiva. Para cada nueva generación de empresarios, toma 
menos tiempo y menos capital hacerse multimillonarios, debido al advenimiento de nuevas 
redes. Tú también puedes.
Si entiendes el poder de las redes y la importancia de las proporciones de apalancamiento, 
tú también puedes volverte exponencialmente rico en un breve periodo y a una fracción del 
costo. Tienes bases y experiencia de negocios sólidas, puedes venderle al mundo por medio 
de la red. A medida que baja el costo de hacer negocios por Internet, el poder de la red sube, 
Una de las razones por las que Steve Case y AOL (una persona y empresa muy jóvenes) 
pudieron comprar Time Warner y CNN (una empresa más vieja con directores más viejos) fue 
simple-mente porque AOL había sido una red mayor. Entre más grande sea la red, mayor es el 
poder económico.
Con frecuencia he escrito sobre personas que se hicieron muy ricas en su tiempo libre. 
Muchos de los ultra ricos de la actualidad comenzaron con negocios en su cusa o en la 
mesa de la cocina, así como Hewlett-Packard empezó en una cochera y Dell Computer 
comenzó en un dormitorio. Así que aunque tengas un trabajo mal pagado, puedes hacerte 
muy, muy rico si empiezas un negocio en tu casa o en tu cochera, todo en tu tiempo libre. 
Recuerda: "No es trabajo de tu jefe hacer que te hagas rico. El trabajo de tu jefe es pagarte 
por lo que haces y tu trabajo es hacerte rico en casa y en tu tiempo libre".
Nunca ha sido más fácil hacerte rico más allá de tus sueños más locos por menos esfuerzo y 
menos capital inicial. Sé que muchas de las empresas punto com con mucha volatilidad se 
fueron a la quiebra... como muchos pensamos que pasaría. En mi opinión, las empresas 
punto com que se fueron a la quiebra pudieron haber tenido el contexto adecuado, pero no 
tuvieron el contenido adecuado. Muchas empresas punto com tuvieron la idea adecuada pero 
a demasiadas les faltó la verdadera experiencia de negocios y los fundamentos de negocios. 
Muchas sólo estaban tratando de hacerse ricas con una moda, en vez de servir realmente a 
más gente.
Hace poco leí que una compañía le pagaba a su presidente un salario equivalente a más de 
mil millones de dólares del dinero de los inversionistas y que éste echó por tierra la empresa. 
En 1999, otra compañía punto com le pagaba a sus empleados un bono de Navidad 
equivalente a tres meses de sueldo. Esa misma compañía salió del negocio y quedó en 
bancarrota antes de la Navidad de 2000. Definitivamente, éste es un caso en donde la misión 
de la compañía era hacer más ricos a los  empleados y empresarios en lugar de servir 
primero al cliente. Los inversionistas fueron quienes pagaron la falla en la misión y propósito 
de la compañía. No lograron seguir el diagrama anterior de mi padre rico sobre a quién se le 
paga primero y a quién se le paga al último. Esas personas, incluidos los inversionistas, se 
enfocaron en ser codiciosos en vez de enfocarse en el propósito de un negocio, que es ser 
generoso.
Hoy en día, nuestro sitio de Internet recibe más de 50 por ciento de sus negocios de clientes 
que viven en otros lugares fuera de Estados Unidos. Estamos trabajando en desarrollar 
nuestro juego CASHFLOW para que se pueda jugar por la red. Nuestra visión es que 
CASHFLOW se juegue por alguien en África, Asia, Australia, Albania y América de manera 
simultánea. El sitio será una comunidad de jugadores que pagan una suscripción nominal 
mensual para aprender mientras juegan, tomando distancia, estudiando cursos diseñados a 
enseñarles a ser ricos en lugar de trabajadores. El propósito del sitio de Internet es que la 
comunidad se ayude entre sí para lograr retirarse jóvenes y ricos. Todo este trabajo se está 
haciendo con un propósito y ése es servirle a la mayor cantidad de gente posible. Al 
enfocarnos en ser generosos, construimos un activo que construye una red en todo el 
mundo.
Clientes con potencial de 6 500 millones de dólares
Ahora, si aplicas las proporciones y mercados potenciales de los que todavía no se ha dado 
cuenta ningún jugador en línea, ve si puedes calcular el valor de ese activo que richdad.com 
está construyendo. Hoy, en el mundo, hay aproximadamente 6 500 millones de personas. De 
esos 6 500 millones, aproximadamente dos mil millones son clientes potenciales, CNN, fundada 
por Ted Turner, tiene un estimado de 30 millones de subscriptores en todo el mundo. Esos 
subscriptores hicieron que Ted Turner fuera lo bastante rico como para donar mil millones de 
dólares a las Naciones Unidas.
Si nosotros en richdad.com atraemos a un millón de clientes para que se unan al servicio y 
paguen esa cuota nominal mensual, entonces, según la Ley Mctcalfc, ¿cuál sería el valor 
económico de richdad.com? ¿Qué pasaría si creciera a cinco millones, diez millones, 30 
millones? La pregunta en realidad es ¿cuál es el mercado en el nivel mundial de la gente 
que quiere aprender a ser rica? ¿Qué pasará cuando Internet sea capaz de hacer 
traducciones simultáneas de manera que personas de diferentes países y lenguas puedan 
jugar y aprender de personas de otros países y lenguas? (Lo cual es nuestro plan para el 
juego en línea) ¿Qué sucederá con el mercado de inversión cuando un sitio de Internet 
comience a realizar inversiones excelentes en ciudades como Phoenix, Tokio, Seúl, Detroit, 
Virginia Beach, Singapur, Kuala Lumpur, Hong Kong, Portland, Dubai, Cairo, Sidney, Perth, 
Shanghai, Johanesburgo, Florencia, York, Bruselas, Sao Paulo, ciudad de México, Hanoi, 
Londres, Lima, Toronto, Nueva York, entre otras muchas? ¿Cuánto costaría construir una 
red mundial de este tipo? ¿Costaría tanto como le costó a Rockefeller, Ford o Ted Turner 
construir sus redes?
Otra  red  que  richdad.com  está  buscando  lograr   son  las  instituciones   educativas. 
Desarrollando cursos que podrían enseñarle a los jóvenes cómo administrar su dinero de 
manera responsable, invertir y manejar sus propios portafolios, ¿cuántas redes educativas 
podríamos incluir? Si pudiéramos volvernos parte de la curricula de las redes escolares de 
todo el mundo, ¿cuál podría ser nuestro valor económico?
En el futuro, cuando la nueva tecnología de banda ancha alcance la red mundial, ¿cuál será 
nuestro valor económico cuando nos convirtamos en uno de los miles de negocios que tenga-mos nuestro sistema privado de televisión en la red? Sé que sigue siendo el futuro, pero 
como decía mi padre rico: "Tu trabajo es posicionarte y estar listo cuando la oportunidad se 
presente". También decía: "Está bien llegar cinco años antes, pero no un día después".
No estoy citando nuestro plan de negocios para presumir ni para decir que se volverá 
realidad. Es un plan y, como todos sabemos, no todo sale conforme a lo planeado. Me doy 
cuenta de que podemos cambiarlo en el camino o de que podemos fracasar... pero como tú 
sabes he fracasado antes y, si fracaso nuevamente, nuestra compañía corregirá, aprenderá y 
se levantará de nuevo más inteligente y más fuerte. El punto de compartir nuestro plan de 
negocios es ilustrar el poder explosivo del apalancamiento para más y más personas hoy, por 
medio de diferentes redes. No muchos de nosotros tenemos el dinero para construir una red de 
televisión como hizo Ted Turner. Pero la mayoría podemos pagar una computadora usada de 
500 dólares y empezar a construir una red en el nivel mundial.
En unos cuantos años, quienes estén preparados y posicionados aprovecharán el poder 
explosivo que traerá la banda ancha. La gente que aproveche la nueva tecnología puede 
hacerse mucho más rica que Ted Turner con la televisión o que Bill Gates con el software 
para computadora o que Jeff Bezos con el Internet.
Hace años, mi padre rico me dijo: "La gente en el lado D e I del cuadrante tiene acceso a 
riqueza infinita. La gente en el lado E y A está restringida por las limitantes de su mano de 
obra física. Para que las personas del lado E y A pasen al lado D e I, el primer cambio es el 
cambio hacia la generosidad... el deseo primero de servir a más personas, en vez de ser el 
primero a quien le paguen".
Si ves a Sam Walton de Wal-Mart lo único que hizo fue construir una red de grandes tiendas de 
descuento, tiendas que llevaron productos excelentes por precios cada vez más bajos a 
millones y millones de personas. Por eso Sam Walton valía más que un abogado que cobra 
750 dólares por hora. La clave es la generosidad.
Unas palabras finales sobre la generosidad
Durante la moda de las empresas punto com, se hablaba mucho sobre negocios de la vieja 
economía y negocios de la nueva economía. Sin importar si el negocio es de la vieja o la nueva 
economía, todos los negocios e individuos exitosos deben seguir ciertos principios y leyes de 
la vieja era.
La generosidad entra en la ley de la vieja era, la Ley de la Reciprocidad. Es la ley que dice: 
"Da y se te dará". No es una ley que dice: "Recibe... y entonces da". Es una ley que ha so-brevivido a la prueba del tiempo y sobrevivirá la prueba del futuro. Hoy, más que nunca 
antes, es muy importante querer cuidarte a ti y a tus seres queridos... pero si quieres ser 
rico, primero tienes que pensar en servir a las necesidades de la mayor cantidad de personas 
que puedas... al principio. Es la ley.
Mi padre rico creía en la Ley de la Reciprocidad y en la idea de que ser generoso era la mejor 
forma de hacerse rico, muy rico. Era su contexto sobre la vida y sus acciones iban de acuerdo 
con su contexto.
Mi padre rico a menudo nos daba ejemplos de cómo usar la Ley de la Reciprocidad. 
Constantemente nos recordaba la necesidad de ser generoso. Solía decir: "Si quieres una 
sonrisa, sé el primero en dar una sonrisa. Si quieres amor, sé el primero en dar amor. Si quieres 
que te comprendan, entonces sé el primero en ofrecer comprensión". También decía: "Si 
quieres que te den un golpe en la boca, sé el primero en golpear a alguien en la boca".
Mi padre rico no sólo creía en ser generoso al servir a cada vez más personas, también creía 
en ser generoso con su dinero. En esa línea de pensamiento, verdaderamente creía en el 
poder del diezmo o en el poder de dar dinero. Por eso mi padre rico daba dinero 
generosamente a su iglesia, a obras de caridad y escuelas. Daba dinero porque quería más 
dinero.
Con frecuencia solía decir: "Dios no necesita recibir, pero los humanos sí". Solía decir: 
"Muchas personas dicen que son generosas con su tiempo porque no tienen dinero. Las 
personas que son generosas con su tiempo tienen mucho porque dan su tiempo. No tienen 
mucho dinero porque no dan dinero. No dan dinero porque son aferrados y tacaños en cuanto 
al dinero, siempre temerosos de que no haya dinero suficiente... así que su miedo se vuelve 
realidad. Si quieres más dinero, da dinero... no tiempo. Si quieres más tiempo, da tiempo".
Si te cuesta trabajo dar dinero, es probable que quieras empezar dando un poco a la vez 
regularmente. Cada vez que das, escucharás cómo tu contexto, o tu realidad, te está hablando 
en voz alta. En el momento en que escuchas cómo te habla tu realidad, y es la realidad de una 
persona pobre, tienes la oportunidad de elegir y volver a elegir tu realidad. En el momento 
en que das aunque sea un dólar para tu iglesia o tu obra de caridad preferida, tu mundo ha 
cambiado. En el momento en que sinceramente creas un negocio o inviertes para aumentar tu 
servicio para más personas, para siempre habrás aumentado tus posibilidades de volverte 
extremadamente rico y de retirarte joven y rico.
La política de nuestra empresa
Quienes han jugado CASHFLOW, habrán notado que hay muchos cuadros dedicados a obras 
de caridad y otros eventos de responsabilidad social. El juego se creó de esa forma mante-niendo las lecciones de mi padre rico.
Además, en la época de fiestas de Navidad honramos a todos los empleados de richdad.com 
dando un diezmo o donando cierta cantidad de dinero a la iglesia u obra de candad que elijan. 
Hacemos que los empleados nos ayuden a decidir a quién se le darán los donativos de la empresa. 
La empresa es quien hace el donativo,  pero lo hace en honor de los empleados porque 
reconocemos que el éxito de nuestra empresa se debe a los esfuerzos del equipo completo, de 
ahí que el equipo deba ayudar a determinar a quién se deberán dar los donativos de la empresa. 
Es nuestra forma de tener integridad con las lecciones y la filosofía de mi padre rico y de 
nuestros productos. También es una de las cosas más alegres que hacemos en nuestra empresa. 
Hemos descubierto que uno de los mejores apalancamientos es el de ser generosos.
Comienza siendo generoso contigo mismo
Mi padre rico siempre decía: "Comienza en pequeño y sueña en grande". En lo que respecta 
a mejorar tus proporciones de apalancamiento, el consejo de mi padre rico sigue siendo cierto 
hoy en día. En el libro número cuatro, Niño Rico, Niño Listo, escribí sobre los tres sistemas 
de alcancía para niños, sistema que Kim y yo usamos actualmente. Una alcancía es para 
ahorros, otra es para invertir y la otra para el diezmo, para dar dinero a la iglesia y a obras 
de caridad. Mejorar tus proporciones de apalancamiento puede comenzar con algo tan 
simple como tres alcancías, poniendo diez centavos, 50 centavos o un dólar diario en cada 
una. Si pones un dólar diario en cada alcancía, al final del mes, tus proporciones se verán de la 
siguiente forma:
Ahorros 1:30
Inversiones 1:30
Diezmo 1:30
Es un excelente comienzo. En un mes, tus proporciones están incrementando todos los días 
sin excepción. Imagina lo que podría pasar en 30 años. El punto que debes recordar es que en 
realidad estás incrementando el hábito de pagarte a ti mismo primero o de ser generoso 
contigo mismo. Mi padre rico decía: "Una de las razones por las que las personas pobres son 
pobres es porque se tratan pobremente a sí mismas". Y con eso no quería decir debes salir 
corriendo a comprar un nuevo vestido o nuevos palos de golf. Lo que quería decir era que 
las personas pobres no hacen cosas que las enriquezcan financieramente. Al pagarte a ti 
primero, estás enriqueciendo financieramente a ti, a tu alma y a tu futuro.
TERCERA PARTE
El apalancamiento de tus actos
Sólo hazlo.
NIKE
Hablar es fácil. Aprende a escuchar con los ojos. Los hechos
hablan más que las palabras. Observa lo que una persona
hace, más que escuchar lo que dice.
PADRE RICO
¿Todo el mundo puede hacerse rico?
Una vez le pregunté a mi padre rico si cualquiera podía hacerse rico. Su respuesta fue: "Sí. Lo 
que una persona debe hacer para hacerse rica no es tan difícil. De hecho, hacerse rico es fácil. 
El problema es que la mayoría de las personas prefieren hacer cosas de la forma difícil. Muchas 
trabajarán duro toda su vida viviendo por debajo de su nivel, invertirán en cosas que no 
entienden, trabajarán duro para los ricos en lugar de trabajar duro para hacerse ricas ellas 
mismas y harán lo que están haciendo todos los demás en lugar de hacer lo que están 
haciendo los ricos".
Las primeras dos secciones de este libro principalmente han sido sobre el proceso mental y 
de planeación para adquirir gran riqueza. Ambos procesos son importantes para retirarte 
joven y rico. La siguiente sección es lo que uno debe y puede hacer para retirarse joven y 
rico. Aunque los procesos mentales y de planeación son importantes, al final lo que cuenta es 
lo que haces con lo que sabes. Como decía mi padre rico: "Hablar es fácil".
Hay muchos libros sobre cómo hacerse rico. El problema con muchos de ellos es que te 
dicen que hagas cosas que con frecuencia son demasiado difíciles para la mayoría de las 
personas. Esta parte del libro trata sobre las cosas simples que casi todo el mundo puede hacer. 
Después de leer esta sección sabrás que tienes la habilidad para hacerte muy rico... si eso 
quieres. O, por lo menos, encontrarás una o dos cosas que puedes hacer para hacerte más 
rico, si eliges hacerlas. Después de leer esta sección, la única pregunta será: ¿Con cuánta 
fuerza quieres hacerte rico?
CAPÍTULO 14
El apalancamiento de los hábitos
Mi padre rico decía: "Hay hábitos que te hacen rico y hábitos que te hacen pobre. La 
mayoría de las personas son pobres porque tienen hábitos pobres. Si quieres ser rico, lo 
único que tienes que hacer es preparare para tener hábitos ricos".
Si en serio deseas hacerte rico, debes hacer las siguientes cosas una y otra vez, desde ahora 
y para siempre, por el resto de tu vida. Todas las personas del mundo occidental pueden 
darse el lujo y hacer lo que se recomienda. El problema es que sólo unas cuantas las harán y 
las harán y las harán.
Hábito #1: Contrata un contador
Al comienzo de este libro, escribí que es más fácil pedir prestado un millón de dólares que 
ahorrar un millón de dólares. Hay una pequeña trampa. Antes de que tu banquero te preste el 
millón de dólares, querrá saber que eres responsable con el dinero. Una de las formas en que 
un banquero se sentirá cómodo prestándote una cantidad tan grande de dinero es si tienes 
un historial financiero profesional limpio.
La mayoría de las personas no pueden calificar para préstamos grandes porque tienen malos 
historiales. Muchas personas  pagan tazas de  intereses  más altas de lo necesario 
simplemente  porque tienen historiales financieros pobres. En Padre Rico, Padre Pobre, 
escribí sobre la importancia de tener educación financiera. La base de ésta es un estado de 
cuenta y es lo que tu banquero querrá ver si va a prestarte cantidades sustanciales de dinero.
Aun si no tienes un negocio, tu vida personal es un negocio y todos los negocios reales 
tienen contadores. Por eso recomiendo mucho que contrates a un contador y que lo tengas 
toda tu vida. Al hacer que un contador maneje tu ingreso, gastos, activos y pasivos en línea, 
empiezas a llevar registros profesionales. También recomiendo mucho que te sientes con tu 
contador y revises tus cuentas mes con mes. La repetición es la forma en que aprendemos y 
al repasar repetidamente tus cuentas mensuales, no sólo establecerás un buen hábito, sino 
que obtendrás mayor comprensión de tus patrones de gastos, podrás hacer correcciones más 
pronto y al final tomarás el control de tu vida financiera.
¿Por qué no hacerlo tú mismo? ¿Por qué contratar a alguien externo? Algunas de las razones 
son las siguientes:
1.Quieres empezar a ser un profesionista del cuadrante D o I. Todos los profesionistas del cuadrante 
D o I tienen contadores profesionales. Así que ahora trata tu vida financiera como un negocio. Como se 
describió en Padre Rico, Padre Pobre, una de las seis lecciones de mi padre rico era "ocúpate de tus 
propios negocios" y eso comienza con contratar a un contador profesional.
2.Quieres que una tercera persona externa y desinteresada mire objetivamente tu dinero y rus hábitos 
de gasto. Como tú sabrás, el dinero puede ser un tema emocional, en especial si es tuyo. Una 
persona que no tenga un apego emocional por tus finanzas puede poner las cosas en orden y 
hablarlo de manera lógica y clara. Recuerdo que mi mamá y mi papá no hablaban sobre 
dinero. Discutían y gritaban sobre el dinero. Difícilmente ése es un manejo o discusión 
objetivos sobre el dinero.
3.Mi padre pobre no quería ver su situación financiera. Guardaba nuestros problemas 
financieros como un secreto personal, un secreto para él mismo, su familia y cualquier otra 
persona. De niños sabíamos que nuestra familia tenía problemas financieros... pero no lo 
hablábamos y manteníamos nuestros problemas financieros como un secreto. Los psicólogos 
te dirían que los secretos de familia se vuelven tóxicos, lo que significa que los secretos 
envenenan a la familia. Sé que el dolor emocional de nuestras luchas financieras sí nos 
afectó de hecho a todos, aunque lo "mantuvimos en secreto.
4.Al contratar a un contador profesional que no sienta apego emocional, puedes sacar a la luz 
tus retos financieros. Al ser capaz de discutir tus estados financieros con tu contador pro-fesional, sacas a la luz el tema del dinero y el negocio de tu vida. Si es en lo abierto y 
discutes tus finanzas con un profesional, serás más capaz de hacer los cambios o de tomar las 
decisiones difíciles que sean necesarios...antes de que los problemas financieros se vuelvan 
tóxicos.
5.Si ganas menos de 50 000 dólares y estás en el cuadrante E, un contador profesional no 
debería costarte más de entre cien y 200 dólares al mes. Escucho gente que dice que pre-ferirían gastarse ese dinero en comida o vivienda. El problema con esa mentalidad es que 
gastarte el dinero en ropa o vivienda no resolverá tus problemas de dinero y no te hará más 
rico. Como decía siempre mi padre rico: "Hay deuda buena y deuda mala, buen ingreso y 
mal ingreso y buenos gastos y malos gastos". Me decía que contratar a un contador y a otros 
asesores financieros profesionales era dinero que iba a gastos buenos, simplemente porque ésos son 
gastos que te hacen más rico, hacen que tu vida sea más fácil y te preparan para un mejor futuro.
Si verdaderamente no puedes pagar un contador, encuentra uno e intercambien servicios. Tú 
puedes limpiar su casa o su jardín y a cambio él puede llevar tu contabilidad. Lo más im-portante es hacerlo, sin importar cuál sea el precio... porque el precio a largo plazo es 
demasiado alto. Como decía mi padre rico: "Tu mayor gasto en la vida es el dinero que no 
ganas".
6. Lo más importante: Contratar a un contador profesional reafirma ante ti mismo que te estás 
tomando en serio tu vida financiera personal. Significa que por lo menos una vez al mes, te sientas 
con tu contador, revisas las cuentas y aprendes, corriges y rediriges el futuro financiero de tu vida.
En Niño Listo, Niño Rico, la introducción comienza: "Por qué tu banquero no te pide tu 
boleta de calificaciones". Lo que te pide tu banquero es tu estado de cuenta. Mi padre rico 
decía: "Tu estado de cuenta es tu boleta de calificaciones una vez que terminas la escuela". 
En la escuela, recibíamos boletas de calificaciones por lo menos una vez al trimestre. 
Aunque tuvieras malas calificaciones, la boleta daba a ti y a tus padres la oportunidad de 
saber en qué eras bueno y en qué eras débil... y entonces te daba la oportunidad de hacer 
correcciones. En la  vida real, la gente que no tiene estados financieros, o boletas de 
calificaciones, no puede hacer correcciones si no saben dónde están cada mes, trimestre o 
año. Piensa en tu estado de cuenta como tu boleta de calificaciones y trabaja diligentemente 
para que tu boleta financiera se mida en millones o quizá miles de millones de dólares. Por 
eso tu contador es importante. Tu contador te entrega tu boleta de calificaciones una vez al 
mes. Se deben seguir tres pasos:
1.Encontrar y contratar a un contador.
2.Llevar una contabilidad precisa cada mes sobre tu situación financiera.
3.Revisar tus estados financieros cada mes con tu asesor para que puedas hacer correcciones 
rápidamente.
Hábito #2: Crea un equipo ganador
En Guía para invertir de Padre Rico, escribí que los cuadrantes D e I eran trabajo en 
equipo. Una de las razones por las que las personas de los cuadrantes E y A en ocasiones 
tienen problemas en las transiciones es porque no están habituadas a tener un equipo que 
las ayude con sus decisiones y planes financieros.
De niño, me di cuenta de que mi padre pobre lidiaba los problemas financieros él solo. Si 
tenía problemas, se sentaba en silencio durante la cena, discutía con mi madre si se sentía 
frustrado por el dinero y se sentaba solo hasta entrada la noche, tratando de cuadrar las 
cuentas. Hubo muchas veces en que regresé a casa para encontrar a mi mamá llorando 
porque sabía que teníamos problemas financieros y no tenía a nadie con quien hablar. En lo 
que respectaba al dinero, mi papá era el hombre de la casa y nunca discutía sus retos 
financieros con nadie.
Por otro lado, mi padre rico se sentaba en una mesa de su restaurante, rodeado por su equipo, 
y discutía abiertamente sus problemas financieros. Mi padre rico decía: "Todo el mundo tiene 
problemas financieros. Los ricos tienen problemas de dinero, los pobres, los negocios, los 
gobiernos y las iglesias. Lo que determina si alguien va a ser rico o pobre es simplemente qué tan 
bien maneja esos problemas. Las personas pobres son pobres simplemente porque manejan 
pobremente sus problemas de dinero". Por esa razón mi padre rico discutía sus problemas de 
dinero de manera abierta con su equipo financiero. Decía: "Ninguna persona puede saberlo 
todo. Si quieres ganar el juego del dinero, quieres que en tu equipo esté la mejor gente, la más 
inteligente". Mi padre pobre perdió porque pensó que debía saber todas las respuestas... y no 
era así.
Después de que tu contador te dé tus estados financieros mensuales reúnete con tu equipo 
cada mes. Es probable que quieras tener un banquero, un contador, un abogado, un agente de 
bienes raíces, un agente de seguros y otros especialistas. Cada profesional llega a la mesa 
con una visión diferente y con distintas formas de resolver tus problemas. Sólo porque tienes 
muchas opiniones no quiere decir que tengas que seguir alguna. Lo más importante es que 
no mantengas en secreto tus problemas financieros, que escuches a personas más 
inteligentes que tú en diferentes áreas de experiencia y que, al final, tomes tu propia 
decisión.
Cuando la gente me pregunta cómo aprendí tanto sobre dinero, inversiones y negocios, 
simplemente contesto: "Mi equipo me enseña". He aprendido más sobre negocios e 
inversiones fuera de la escuela simplemente porque uso mi vida como una escuela de la vida 
real. He descubierto que estoy más interesado en resolver mis propios problemas que 
sentado en la escuela tratando de resolver problemas ficticios.
El siguiente es un ejemplo de cómo usé a mi equipo para que me enseñara cosas. El otro 
día, me reuní con uno de mis  abogados que trataba de explicarme cómo usar bonos 
gubernamentales con exención de impuestos. Sus explicaciones me rebasaban y su 
vocabulario estaba lleno de palabras que yo nunca antes había usado. En lugar de 
desperdiciar su tiempo sentado ahí fingiendo que entendía, detuve la junta y programé otra. 
En la siguiente junta, mi contador y ese abogado se sentaron con Kim y conmigo y los dos 
ayudaron a explicar lo que él nos estaba diciendo, en nuestro lenguaje.
Antes dije que las palabras son herramientas para el cerebro. Cada profesión usa diferentes 
palabras. Por ejemplo, los abogados usan palabras diferentes a las de los contadores. Al 
invertir el tiempo para comprender del todo esas palabras, al hacer que me tradujeran sus 
significados, soy más capaz de usar las palabras y de hacerlas parte de mi vida. En otras 
palabras, uso a los diferentes profesionistas como traductores de modo que pueda usar sus 
palabras en mi vida. Entre más palabras puedo entender y usar, más rápido puedo hacer más 
dinero y mejor se vuelve mi futuro financiero.
Esa junta me costó unos cientos de dólares de honorarios, pero sé que la ganancia será 
exponencial. Me ayudó a entender cómo pedir prestadas decenas de millones de dólares del 
gobierno con tazas de interés muy bajas. La preparación combinada de mi abogado y mi 
contador sobre ese tema acelerará en gran medida mis proporciones de apalancamiento. 
Como dije antes, puedes aumentar tu ingreso incremental o exponencialmente. Al invertir 
en mi vocabulario y comprensión, mi riqueza se incrementará de manera exponencial.
Así que empieza a reunir a tu equipo. Si no puedes pagar un equipo que cueste mucho, es 
probable que quieras encontrar a una persona retirada que disfrute de ayudar y guiar a la 
gente.  Muchas veces, lo único que tienes que hacer es pagarles su almuerzo. Te 
sorprendería cuánta gente simplemente disfruta de que le pidan que comparta la experiencia 
de su vida para ayudar a otros. Lo único que tienes que hacer es ser respetuoso, no discutir y 
escuchar con atención. Hazlo una vez al mes y tu futuro se enriquecerá para siempre.
Hábito #3: Constantemente expande tu contexto y tu contenido
Ahora vivimos en la Era de la Información, no en la Era Industrial. En la Era de la 
Información, tu mayor activo no son tus acciones, bonos, fondos de inversión, negocios o 
bienes raíces. Tu mayor activo es la información que hay en tu mente y la edad de tu 
información. Demasiadas personas se están quedando rezagadas porque la información de su 
mente es historia antigua o porque se aferran a respuestas que fueron correctas ayer, pero 
que hoy son incorrectas. Si quieres retirarte joven y rico, necesitarás mantenerte al nivel de 
un mundo de información que cambia con rapidez.
Entonces, ¿cómo te mantienes al nivel de la Era de la Información? Las siguientes son 
algunas de las cosas que yo hago para seguir aprendiendo. No te estoy diciendo que hagas 
exactamente las mismas cosas que yo, simplemente comparto contigo lo que estoy 
haciendo. Si te funciona, bien y, si no, busca lo que sí te funcione.
1. Librería de audio Nightingale-Conant. En 1974, después de que decidí seguir el camino de 
mi padre rico, supe que necesitaba encontrar más mentores que sólo mi padre rico. Supe que 
necesitaba información que no se encuentra en los terrenos tradicionales de la educación. En 
1974, me topé con cintas de audio repletas de invaluable información, información que se 
añadía no sólo a mi contenido, sino que también expandía mi contexto. Esas cintas me 
dieron información pertinente y relevante y también expandieron mi realidad de modo que 
puede usarla.
Hoy, más de 25 años después, sigo usando los productos de Nightingale-Conant. Cada vez 
que necesito información oportuna reviso su catálogo en busca de un programa en audio o 
video que me enseñe lo que quiero aprender. Cuando necesito información invaluable y de 
eterna validez de alguno de los mayores maestros del mundo, reviso su catálogo.
Algunas de las cintas de audio con las que es posible que quieras empezar son:
1.Lead the Field {Dirige el campo) de Earl Nightingale. Esta cinta es uno de los clásicos de todos los 
tiempos que siempre será relevante. Earl Nightingale es uno de los líderes de los negocios modernos 
y la educación de motivación. Antigua sabiduría sobre liderazgo es lo que todos necesitamos si que-remos mantenernos al corriente en la Era de la Información.
2.Making Money on the Web {Haciendo dinero en la red) de Seth Godin. Este grupo de cintas está 
lleno de información práctica, básica y útil sobre cómo comenzar tu red de negocios en todo el 
mundo. Aun si no planeas hacer negocios por Internet, esta cinta está llena de fundamentos básicos de 
negocios con sentido común para cualquiera que quiera ser rico.
3.Thinking Big {Pensando en grande) de Brian Tracy, Este juego de cintas es esencial para cualquiera 
que se dé cuenta de que puede estar pensando muy en pequeño. Una de las razones por las que las 
personas tienen un contexto de escasez o no tienen suficiente dinero es simplemente porque por lo 
general piensan muy pequeño. Este juego de cintas ayudará a abrir tu mente a mayores posibilidades 
para tu vida.
4.The Art of Excepcional Living {El arte de una vida excepcional) de Jim Rohn. Se trata de un 
programa educativo excelente para expandir tu contexto. La razón por la que se trata de un 
juego de cintas excelente es porque muchas personas piensan que tienen que hacer cosas 
grandiosas, o superar obstáculos gigantescos, para ser grandiosas. Jim Rohn señala que hay 
una diferencia entre hacer cosas grandiosas y vivir una vida excepcional... haciendo las 
cosas simples de la vida de manera excepcional. Como expresé en este libro, no siento que 
me haya sido otorgado ningún talento, apariencia, personalidad o mente geniales. Después 
de escuchar esta cinta, dejé de enfocarme en hacer cosas grandiosas y en cambio me enfoqué 
en hacer lo que hacía, excepcionalmente bien.
5. How to Be a No-limit Person {Cómo ser una persona sin límites) del doctor Wayne Dyer. 
Éste es un juego de cintas excelente sobre cómo hacer que cada día de tu vida cuente, 
expandiendo tu contexto o realidad para permitir que se den más oportunidades, mejor salud, 
mayor felicidad y para enfrentar los problemas con una mejor actitud.
Cuando voy al gimnasio o voy manejando en el coche, con frecuencia tengo puesta alguna 
cinta de la librería Nightingalc-Conant de cintas de audio de mentores excelentes. Cuando 
me preguntan cómo encontrar mentores, con vehemencia recomiendo a la persona que 
consiga un catálogo de cintas y busque al mentor de quien quiere aprender.
2. Me suscribo a los siguientes boletines de noticias financieras y de negocios:
a.  Louis Rukeyser's Wall Street (Wall Street de Louis Rukeyser). Me parece que su información 
es aguda. Este boletín de noticias es importante para cualquiera que desee estar al corriente 
sobre lo que está pasando en Wall Street.
b. Strategic Investment (Inversión estratégica) de James Dale Davidson y Lord Rees-Mogg. Estos dos hombres tienen una perspectiva global sobre la economía mundial. 
Encuentro
que su información es aguda, a menudo de muchas posturas y especialmente buena para el 
inversionista rico.
c. Audio-Tech Business Book Summaries (Resúmenes de libros de negocios Audio-Tech). 
Esta organización publica mensualmente el resumen de un libro y un programa en cinta de 
audio sobre los libros de negocios más recientes. Me parece mejor leer el resumen y escuchar 
la cinta antes de decidir si quiero leer el libro.
Estamos pasando a una era de oportunidades sin precedentes... estamos pasando a la Era del 
Empresario. Si lo único que quieres es un cheque con un sueldo más alto, puedes perderte 
esta era mientras otros se vuelven súper ricos. Si no quieres perdértela, te sugiero que hagas 
el hábito de estar delante de la masa y de ver el futuro que la masa no puede ver.
Hábito #4: Sigue creciendo
El otro día, un amigo mío se estaba quejando de que había perdido millones de dólares en la 
bolsa. Nunca había invertido antes de 1995, había pedido dinero prestado para comprar ac-ciones y ahora, después de que cayó la bolsa, lo había perdido casi todo, incluyendo su 
casa. No dejaba de quejarse a voz en cuello y finalmente tuve suficiente. Dije: "Crece. Ya 
eres un hombre. ¿Qué te hizo pensar que la bolsa siempre subiría?"
Mi comentario no lo detuvo. Seguía diciendo: "¿Por qué Alan Greenspan no bajó las tasas 
de interés antes? ¿Por qué tuvo que subirlas? Es culpa suya y de mi corredor de bolsa que lo 
haya perdido todo. ¿Cómo voy a devolver todo ese dinero? ¿Por qué el gobierno federal no 
hace algo sobre las pérdidas en la bolsa?"
Mientras me alejaba, repetí lo que había? dicho antes: "Crece".
Mi padre rico decía con frecuencia: "La gente se hace más vieja, pero no necesariamente 
crece". Muchas personas pasan del cobijo de papá y mamá al cobijo de una empresa o del 
gobierno. Muchos esperan que alguien más se encargue de ellos o sea responsable de su falta 
de sabiduría y sentido común. Por eso buscan un trabajo seguro o santuarios gubernamentales. 
Demasiadas personas se pasan la vida buscando garantías y gastan su vida evitando los 
riesgos, evitando crecer y buscando siempre a un padre sustituto que cuide de ellas. Conozco 
a muchas personas que no son capaces de sobrevivir sin la Seguridad Social. Sé de gente que 
todavía no tiene la edad suficiente para cobrar la Seguridad Social y, no obstante, están 
contando con ella y con Medicare para que las respalde. Esas redes de seguridad del gobierno 
se crearon en la Era Industrial y se crearon sólo como redes de seguridad para los muy 
necesitados. Hoy, desafortunadamente, muchas personas, incluso personas muy preparadas y 
muy bien pagadas, siguen contando con el gobierno para que cuide de ellas. Estamos en la 
Era de la Información y es tiempo de que nosotros como cultura comencemos a crecer y 
madurar financieramente. Deja las redes de seguridad del gobierno y los programas sociales 
para quienes realmente los necesitan.
Cuando dejé la preparatoria, pensé que había crecido y que sabía todas las respuestas. Hoy, 
con frecuencia digo: "Desearía haber sabido entonces lo que sé hoy". Hay muchas cosas que 
hice en mi pasado que estoy feliz de haber hecho, pero no las haría hoy. Creo que crecer es 
darse cuenta de que crecer significa hacer las cosas de manera diferente a medida que 
envejecemos. Hacer continuamente lo mismo todos los días de tu vida sin excepción en 
muchas formas es impedir el desarrollo mental y emocional. El mundo está cambiando, se 
está haciendo más sofisticado y lo mismo debería pasar con nosotros.
Una de las formas en que está cambiando el mundo es que ya no hay mucha seguridad en el 
trabajo ni seguridad financiera. Las empresas están empujando a la gente al mundo frío y 
cruel diciéndoles: "No esperes que cuidemos de ti una vez que dejes de trabajar para 
nosotros". También están diciendo: "Mejor cuenta con la bolsa para que cuide de ti cuando 
dejes de trabajar". Sin embargo, en el mundo frío y cruel, esperar que la bolsa siempre vaya 
hacia a la alza es una fantasía infantil y tan tonta como esperar que el ratón de los dientes 
pague tu cuenta del dentista. Crecer significa estar dispuesto a ser cada vez más responsable 
de ti mismo, de tus acciones, de tu educación continua y de tu madurez. Si quieres tener un 
futuro financiero rico y seguro, es imperativo saber que los mercados bursátiles suben y 
bajan y que no hay nadie ahí para protegerte. Entre más rápidos crezcamos y enfrentemos la 
realidad, mejor podemos enfrentar el futuro con mayor madurez. En la Era de la Infor-mación, somos más los que necesitamos crecer y alejarnos de las ideas de la Era Industrial 
que consisten en esperar que alguien más sea responsable de tu seguridad en el trabajo y de 
tu seguridad financiera.
Me temo que en menos de veinte años será obvio que la Era Industrial está muerta y 
desaparecida. Lo sabremos cuando el gobierno finalmente admita que está quebrado y no 
sea capaz de cumplir muchas de sus promesas financieras. Si en veinte años demasiadas 
personas entran en pánico y comienzan a drenar su 401 (k), la bolsa caerá, muchas personas 
se verán decepcionadas y Estados Unidos puede entrar en una profunda recesión, 
posiblemente en una depresión. Si esto sucede, millones y millones de personas nacidas 
durante el baby boom y sus hijos finalmente tendrán que crecer. Crecer significa que te 
vuelvas cada vez menos dependiente de los demás y cada vez más capaz de cuidarte a ti 
mismo, tus necesidades y las necesidades de otros. Para mí, crecer es un proceso de toda la 
vida, un proceso que muchas personas están evitando al buscar seguridad en el trabajo y 
seguridad financiera proporcionada por alguien más... alguien aparte de ellos.
Crecer continuamente es un hábito importante. Si vas a retirarte joven y rico, necesitarás 
crecer mucho más rápido de lo que están dispuestas la mayoría de las personas.
Hábito #5: Debes estar dispuesto a fracasar más
Una de las diferencias más grandes entre mi padre rico y mi padre pobre era que mi padre 
pobre no estaba dispuesto a fracasar. Pensaba que cometer errores era un signo de fracaso... 
después de todo era maestro. Mi padre pobre también pensaba que en la vida sólo había una 
respuesta correcta.
Mi padre rico constantemente se aventuraba en áreas de las que no sabía nada. Mi padre rico 
creía en soñar en grande, en probar cosas nuevas y en cometer pequeños errores. Al final de 
su vida me dijo: "Tu papá se pasó la vida pretendiendo que sabía todas las respuestas 
correctas y evitando errores. Por eso, al final de su vida, comenzó a cometer grandes 
errores". Mi padre rico también dijo: "Una de las cosas magníficas sobre estar dispuesto a 
probar cosas nuevas y a cometer errores es que cometer errores te hace humilde. Las 
personas que son humildes aprenden más que las que son arrogantes".
Con los años, vi a mi padre rico entrar en negocios, empresas y proyectos de los que con 
frecuencia no sabía nada. Solía sentarse, escuchar y hacer preguntas durante horas, días y 
meses y obtenía el conocimiento que necesitaba. Siempre estaba dispuesto a ser humilde y a 
hacer preguntas estúpidas. Sobre esto decía: "Lo que es estúpido es pretender que eres 
inteligente. Cuando pretendes ser inteligente, estás en la cima de la estupidez".
Mi padre rico también estaba dispuesto a estar equivocado. Si cometía un error, siempre 
estaba listo para disculparse. No trataba de tener la razón todo el tiempo. Decía: "En la 
escuela sólo hay una respuesta correcta. Si alguien tiene una mejor respuesta que la tuya, 
tómala. Así tendrás dos respuestas correctas". También solía decir: "Las personas que tienen 
sólo una respuesta correcta por lo general son tres cosas. Una: generalmente son 
argumentativas o defensivas. Dos: con frecuencia son personas muy aburridas. Y tres: con 
frecuencia se vuelven obsoletas porque no logran darse cuenta de que su única respuesta 
correcta ahora es equivocada".
De modo que el consejo de mi padre rico era: "Vive un poco. Todos los días haz algo atrevido 
y un poco arriesgado. Aun si no te haces rico, este hábito hará que tu vida se mantenga emo-cionante y te mantendrá más joven durante más años".
Desafortunadamente, mi padre pobre se pasó la vida haciendo las cosas correctas. Hizo lo 
correcto cuando fue a la escuela. Consiguió un trabajo de maestro porque en su mente era lo 
correcto. Trabajó duro y subió la escalera porque era lo correcto. Se opuso a su jefe porque 
estaba alterado con la corrupción del gobierno porque era lo correcto. Al final de su vida, 
pasó veinte años frente a la televisión molesto porque había hecho todo lo correcto y a nadie 
parecía importarle que él lo hubiera hecho. Se molestaba mucho cuando pensaba en todos sus 
compañeros que él consideraba habían hecho lo incorrecto, pero ahora eran ricos o tenían 
puestos de poder.
Mi padre rico decía: "A veces lo que te parece correcto al comienzo de la vida no es lo 
correcto para ti al final de tu vida. Demasiadas personas no tienen éxito simplemente porque 
tienen miedo de cambiar o porque son incapaces de cambiar con los tiempos. La razón por 
la que son incapaces de cambiar es porque tienen miedo de estar equivocados. A veces, para 
estar en lo correcto, todos necesitamos estar equivocados. Si queremos aprender a andar en 
bicicleta, debemos pasar por el proceso de estar equivocados durante algún tiempo. La 
mayoría de las personas no tienen éxito simplemente porque quieren estar en lo correcto 
pero no están dispuestas a estar equivocadas. Es su miedo de fracasar lo que ocasiona que 
fracasen. Es su necesidad de ser perfectas lo que las hace ser imperfectas. Es su miedo a 
verse mal lo que causa que al final se sientan mal sobre sí mismas".
Para las personas que tienen miedo al fracaso, o que le temen a cometer errores, he creado 
una cinta de audio con Nightingale-Conant titulada Rich Dad Secrets {Secretos de Padre 
Rico). El secreto de mi padre rico era que el mundo está diseñado para que no fracasemos. 
El mundo está diseñado para que ganemos. El reto es estar dispuesto a fracasar primero 
para poder ganar. El problema que esta cinta ayuda a superar es el miedo al fracaso que 
tiene una persona. Una vez que entiendas los Secretos de Padre Rico, estarás más dispuesto 
a fracasar, para poder ganar. Como decía con frecuencia mi padre rico: "Las personas que 
evitan fracasar, también evitan el éxito. Fracasar es una parte integral del éxito".
En resumen, lo que mi padre rico hizo diariamente fue estar dispuesto a fracasar un poco 
todos los días. Mi padre pobre hizo todo lo posible por no fracasar en lo absoluto. La 
diferencia en esos pequeños hábitos hizo una gran diferencia hacia el final de su vida.
Hábito #6: Escúchate a ti mismo
El último y el más importante de los hábitos para cualquiera que quiera retirarse joven y 
rico es escucharse a sí mismo. Mi padre rico decía con frecuencia: "La fuerza más poderosa 
que tengo es lo que me digo a mí mismo y lo que creo". Este hábito es otra forma de expresar 
tu realidad o tu contexto. Lo que mi padre rico quería decir con tu fuerza más poderosa se 
refiere al concepto bíblico de que tus palabras se hacen carne. En otras palabras, presta 
mucha atención a lo que te estás diciendo a ti mismo, porque lo que te estás diciendo es en 
lo que te convertirás cada día.
Mi padre rico solía decir: "Los perdedores se enfocan mucho en lo que no quieren en la 
vida, en vez de ser específicos con lo que sí quieren. Eso es lo que hacen diferente. Es un 
hábito. Lo mismo es cierto con el dinero".
"Así que hay una gran diferencia entre alguien que constantemente dice: 'No quiero ser rico' 
y alguien que dice: 'Quiero ser rico'", contesté.
Mi padre rico asintió y dijo: "Me parece que la mente humana no escucha hazlo sino no lo 
hagas. Sólo escucha el tema que se discute... palabras como gordo, sano, pobre y rico. Sea 
cual sea el tema, es en lo que te conviertes".
"¿Entonces cuando alguien dice: 'No quiero perder dinero' lo único que escucha la mente es 
'Quiero perder dinero'?" pregunté, buscando mayor claridad de la lección de mi padre rico.
"Así es como me parece", dijo.
"¿Entonces lo que hacen muchas personas es hablar sobre lo que no quieren o sobre lo que no 
pueden tener?", dije.
"Así es. Pero hago algo más que eso. Es uno de mis hábitos", dijo mi padre rico.
"¿Algo más que simplemente decir lo que quieres?", pregunté.
Mi padre rico asintió y me dio uno de los hábitos más importantes para mi vida. Dijo: "A 
veces, todos nos sentimos asustados, inseguros y llenos de dudas. Es parte de ser seres 
humanos. Cuando me siento así, lo primero que hago es revisar mis pensamientos. Si me 
siento mal o me siento asustado, sé que estoy diciendo o pensando algo que hace que me 
sienta de ese modo".
"Está bien", dije. "¿Cuál es el siguiente paso?"
"Cambio mis pensamientos o palabras por palabras que quiero", dijo mi padre rico. "Por 
ejemplo, si tengo miedo de perder, me digo: '¿De qué tengo miedo, qué quiero hacer en 
cambio y qué necesito hacer para llegar a donde quiero?' Si te das cuenta, todas son 
preguntas que primero abren mi realidad a nuevas posibilidades y realidades".
Asentí y dije: "¿Entonces qué?"
"Entonces me siento en silencio hasta que el sentimiento de miedo se aleja y el sentimiento 
que quiero llega a la zona de mi corazón, mi pecho y mi estómago. Cuando puedo sentir el 
sentimiento que quiero y cuando tengo los pensamientos que quiero, entro en acción. Me 
preparo primero, entro en la mentalidad adecuada, el sentimiento emocional que quiero en 
lugar del que no quiero, luego entro en acción".
El resumen de este proceso es:
1.Nota los pensamientos que no quieres... cambia a pensamientos sobre cosas que quieres.
2.Nota los sentimientos que no quieres... cambiar a sentimientos que quieres.
3.Entra en acción y sigue adelante, corrigiendo si es necesario, hasta que consigas lo que quieres... 
en vez de lo que no quieres.
Poniéndolo en práctica
Hace unos años, estaba en Las Vegas por una noche. No suelo jugar mucho, pero como tenía 
que matar el tiempo, decidí jugar un poco de blackjack. En cuanto llegué a la mesa, noté que 
mi cuerpo se empezaba a tensar con el miedo de perder y mi mente comenzó a decir: "Sólo 
puedes perder 200 dólares. Luego tienes que parar".
De inmediato, cambié mis pensamientos a: "Tengo 200 dólares para jugar y cuando gane 500 
voy a parar." Tenía en su lugar mi estrategia de entrada y de salida. Luego me senté a la 
mesa, viendo cómo repartía el tallador, pero no puse nada de dinero. En lo profundo de mi 
pecho, podía sentir el miedo a perder. Enfoqué mi atención en cambiar el sentimiento de per-der por el de ganar. Sólo cuando pude sentir la confianza de un ganador en mi pecho, mi 
corazón y mi estómago comencé a jugar dinero. Aunque perdí las primeras manos, lo único 
que hice fue enfocarme en pensamientos ganadores y en sentimientos ganadores. Después 
de una hora, salí con mis 500 dólares.
La otra noche, me encontré otra vez en Las Vegas. De nuevo, pasé por el proceso. El 
problema era que esta vez no podía ganar, sin importar qué tan enfocados estaban mis 
pensamientos y mis sentimientos. Una vez que desaparecieron mis 200 dólares, tuve que 
luchar contra mis sentimientos para no poner más dinero. Alejarme de la mesa fue una de
las cosas más difíciles que tuve que hacer.. Quería ir detrás de mi dinero.
A medida que me alejaba, pude escucha! a mi padre rico diciendo: "Aun con los mejores 
pensamientos v sentimientos, a veces las cosas simplemente no salen a in manera. Un 
ganador sabe cuándo renunciar y alejarse. Un ganador debe saber que perder es parte de 
ganar. Sólo un perdedor se queda en la mesa equivocada para siempre, perdiéndolo todo, 
esperando demostrar que no es un perdedor".
Relaciones felices
Este proceso de elegir cómo pensar y sentir funciona también en las relaciones. He notado que 
me siento terrible cuando pienso en todas las cosas que mi esposa, Kim, no hace... y me 
siento locamente enamorado de ella cuando pienso en todas las cosas maravillosas que hace 
y que hacemos juntos.
Los Righteous Brothers tenían un éxito titulado You've Lost That Loving Feeling ("Has 
perdido ese sentimiento de amor"). En lo que respecta a los negocios y a las inversiones, 
muchas personas han "perdido ese sentimiento ganador".
Manteniendo la fe
Durante el periodo de 1985 a 1994, Kim y yo nos enfocamos en lo que queríamos e hicimos 
nuestro mejor esfuerzo para sentirnos como queríamos sentirnos y como nos sentiríamos 
cuando nuestros sueños se hicieran realidad. Aunque hubo veces en que las cosas no salieron 
como queríamos que salieran, lo que nos ayudó a salir durante los tiempos difíciles fue 
enfocarnos en lo que queríamos y sentirnos como queríamos sentirnos. Elegir cómo quieres 
sentirte y elegir pensar lo que quieres pensar es un hábito muy importante que me enseñó mi 
padre rico. Si tan sólo pudiera sentirme y pensar así sobre la fría ensalada verde que tengo 
frente a mí...
El punto de este hábito es que paso por el proceso de pensar y sentir en especial cuando 
siento miedo o dudas sobre mi mismo. Para mí, hacer eso es un mejor hábito que permitir 
que tus sentimientos de duda e incertidumbre dirijan tu vida. Aunque el proceso no siempre 
asegura que gane, sigue siendo un buen hábito que me ha permitido ganar en ocasiones 
cuando las probabilidades me eran adversas y quería correr. Siempre recuerda que todos los 
ganadores pierden una que otra vez... pero eso no significa que tengan que sentir o pensar 
como un perdedor.
Como dice Nike: "Sólo hazlo". En la vida, parece que lo que hacen los ganadores es enfocarse 
en lo que quieren y los perdedores parecen enfocarse en lo que no quieren. Por eso es tan 
importante hacerte el hábito de escucharte a ti mismo con regularidad. Los ganadores 
mantienen esos sentimientos ganadores  y pensamientos  ganadores, aunque no estén 
ganando. Se trata de un hábito muy importante.
¿Puedes adoptar esos hábitos?
Antes de ir más lejos, quiero volver a remarcar lo importante que me parecen estos hábitos 
básicos. Se trata de hábitos muy fáciles que prácticamente cualquier persona de más de 
dieciocho años puede seguir. No obstante, aunque son fáciles, temo que sólo unos cuantos 
los harán sus hábitos.
Si puedes hacer que estos hábitos sencillos se conviertan en hábitos tuyos durante toda tu 
vida, los pasos de los siguientes capítulos te resultarán fáciles y te harán más rico de lo que 
alguna vez hubieras podido imaginarte. Como decía mi padre rico: "La historia de los tres 
cochinitos es más que un cuento de hadas. Es una historia llena de verdades. Si quieres 
construir una casa de ladrillos necesitas buenos hábitos... puesto que los buenos hábitos son 
los ladrillos de los ricos".
CAPÍTULO 15
El apalancamiento de tu dinero
¿Quién trabaja más duro? ¿Tú o tu dinero?
El 12 de marzo de 2001, los canales financieros estaban llorando amargamente la caída de 
la bolsa. El 10 de marzo de 2000, sólo un año antes, el NASDAQ estaba a una altura histórica de 
5048.62. Ese día, el 12 de marzo de 2001, el NASDAQ estaba en 1923, una caída de 62 por 
ciento aproximadamente en un año. También en ese mismo día, los accionistas perdieron 445 
mil millones de dólares en transacciones de cambio. Obviamente, muchas personas estaban 
muy preocupadas, asustadas o enojadas.
En uno de los canales, un comentarista dijo algo sobre lo que yo había estado preocupado 
por años. Dijo: "Muchos inversionistas ricos sólo están haciéndose más ricos con esta caída 
de la bolsa. Se hacen ricos porque entran y salen del mercado. Me preocupa la persona 
trabajadora a quien le han arrebatado su plan de pensión. Estas personas dejaron el dinero de 
su retiro en la bolsa porque tuvieron que hacerlo".
Mi esposa, Kim, también estaba viendo el programa y escuchando al comentarista. Kim dijo: 
"Ver cómo desaparece tu plan de retiro debe ser semejante a ver cómo se quema tu casa sin 
tener una manguera para apagar el fuego".
En Guía para invertir de Padre Rico, escribí que los pobres y la clase media invierten en 
fondos de inversión mientras los ricos invierten en fondos de resguardo. Aunque muchas 
personas dicen que los fondos de resguardo son demasiado arriesgados, yo tiendo a estar en 
desacuerdo. Pienso que los fondos de inversión son mucho más arriesgados, simplemente 
porque la mayoría tiende a tener un buen desempeño sólo cuando los mercados bursátiles 
están a la alza. Por lo menos con algunos fondos de resguardo, puedes hacer dinero en un 
mercado bursátil tanto a la alza como a la baja. ¿Cuál crees que es más arriesgado a largo 
plazo? ¿Cómo te sentirías si te estuvieras preparando para retirarte y acabaras de ver cómo tu 
fondo de retiro se reduce a la mitad? Por lo menos si tienes un seguro contra incendios puedes 
reconstruir tu casa en menos de un año si se quema. Para muchas personas, es posible que no 
tengan suficiente tiempo para reconstruir su fondo de retiro si éste desaparece al final de su 
vida.
¿Tu dinero simplemente está ahí parado sin hacer nada?
Una de las razones por las que la gente trabaja tan duro toda su vida simplemente es porque 
le enseñaron a trabajar más duro que su dinero. Cuando la mayoría de las personas piensan 
en invertir, muchas simplemente estacionan su dinero en una cuenta de ahorros o en su cuenta 
de retiro, mientras continúan con su vida de trabajo duro. Mientras trabajan, esperan que su 
dinero también esté trabajando. Luego, cuando sucede algo como un desastre financiero, su 
dinero estacionado se ve diezmado y la mayoría carece de un seguro contra desastres 
financieros.
Mi padre rico decía: "La mayoría de las personas se pasan la vida construyendo casas 
financieras de paja, casas susceptibles al viento, a la lluvia, al fuego y a los lobos malos".
Por eso mi padre rico nos enseñó a su hijo y a mí cómo hacer que nuestro dinero no dejara de 
moverse. Para ilustrar más este punto, un día, en un campamento, hizo que Mike y yo saltára-mos una y otra vez la crepitante fogata. Dijo: "Si se están moviendo, ni siquiera el fuego 
podrá lastimarlos. Si están de pie quietos cerca del fuego, aunque no estén en el fuego, al 
final el calor llegará hasta ustedes". Esa mañana, mientras veía cómo la bolsa se hundía cada 
vez más bajo, pude escuchar a mi padre rico contándonos esta historia a su hijo y a mí. Son las 
personas que están de pie quietas con su dinero estacionado quienes están sintiendo el calor. 
Si quieres retirarte joven y rico, necesitarás trabajar más duro y más rápido. Tu dinero tendrá 
que hacer lo mismo. Dejar tu dinero parado en un lugar es como ver una pila de hojas 
otoñales secas, esperando la chispa... la chispa que las convertirá en una hoguera.
¿Qué tan rápido es tu dinero?
Una de las razones por las que Kim y yo nos retiramos pronto fue porque mantuvimos 
nuestro dinero en movimiento Mi padre rico con frecuencia se refería a este concepto como 
velocidad del dinero. Decía: "Tu dinero debe ser como un buen porro cazador de pájaros. Te 
ayuda a encontrar un pájaro, lo atrapa y luego se vaya te consigue otro pájaro. La mayor pal 
te del dinero de la gente actúa como el pájaro que simplemente se aleja volando". Si quieres 
retirarte joven y rico, es muy importante que tu dinero sea como un perro cazador de pájaros, 
que sale todos los días y lleva a casa cada vez más activos.
Hoy, muchos especialistas en planeación financiera y muchos administradores de fondos de 
inversión dicen al inversionista promedio: "Sólo danos dinero y nosotros lo pondremos a 
trabajar para ti". La mayor parte de los inversionistas asienten y repiten el mantra: "Invierte 
a largo plazo, compra y conserva, y diversifica". Su dinero se queda estacionado y ellos 
regresan a trabajar. Para la mayoría de los inversionistas, se trata de ideas muy buenas, dado 
que muchos inversionistas no tienen ningún interés en aprender cómo poner a trabajar su 
dinero, puesto que prefieren trabajar más duro que su dinero. El problema con esos planes 
de los inversionistas promedio es que no necesariamente son estrategias productivas de in-versión ni necesariamente son más seguros.
Kim y yo no guardábamos nuestro dinero en una cuenta de retiro para retirarnos jóvenes. 
Sabíamos que teníamos que mantener nuestro dinero trabajando, y duro para adquirir cada 
vez más activos. Una vez que nuestro dinero nos compraba un activo, ese dinero pronto se 
volvía a emplear para salir y conseguirnos otro activo. La estrategia que usamos para 
mantener nuestro dinero en movimiento y comprándonos cada vez más activos es una 
estrategia que casi todo el mundo puede usar. Como lo prometí, este libro enlistará cosas 
que casi cualquiera puede hacer para hacerse rico.
Mantén el dinero en movimiento
Una de las estrategias que usamos para mantener en movimiento nuestro dinero fue comprar 
propiedades de alquiler y, en un año o dos, pedir prestado nuestro propio pago inicial para 
comprar otra propiedad de alquiler. Eso fue seguir el consejo de mi padre rico sobre usar el 
dinero como un perro cazador de pájaros. La persona promedio denomina este proceso 
préstamo sobre hipoteca. Algunas personas lo llaman préstamo de consolidación sobre 
factura para pagar deudas de tarjetas de crédito Puedes notar que Kim y yo pedimos dinero 
prestado para comprar inversiones y que la persona promedio usa el capital de deuda para 
pagar deudas malas. Éste es un ejemplo del pájaro que salía volando por la ventana. Aunque 
sigue siendo velocidad del dinero, es velocidad del dinero que se aleja de ti, en vez de 
comprarte activos.
Un ejemplo simple
El siguiente es un ejemplo de cómo invertimos y luego pedimos dinero prestado para 
invertir en otros activos. En 1990, Kim y yo notamos una casa en venta en un hermoso 
vecindario de Portland, Oregon. El dueño estaba pidiendo 95 000 dólares pero la propiedad 
no se vendía. La economía estaba mal, la gente sufría recortes de personal y había muchas 
casas en el mercado. Habríamos hecho una oferta antes, pero esa casa no encajaba en 
nuestro portafolio de inversión. Era demasiado costosa y demasiado bella como para 
considerarla una propiedad de alquiler a largo plazo. Si esta casa estuviera en San Francisco, 
habría sido una casa de 450 000 dólares. No obstante,  vimos esta propiedad porque 
podíamos darnos cuenta de que tenía mucho valor y potencial.
En nuestro camino de ida y de regreso al aeropuerto, pasábamos por la casa para ver si seguía 
en venta. Después de cerca de seis meses finalmente tocamos la puerta y descubrimos que el 
dueño estaba muy ansioso por vender y listo para escuchar cualquier oferta. Debía 56 000 
dólares así que le ofrecí 60.000 y nos arreglamos en 66 000. Le di 10.000 dólares y nos hicimos 
cargo de la hipoteca que ya tenía. Un mes después, el dueño y su familia se habían mudado y 
estaban en camino a California felices de haber vendido su casa. No hicieron mucho dinero y no 
perdieron mucho dinero. La casa se rentó de inmediato y terminamos obteniendo como 75 
dólares al mes de flujo de efectivo positivo después de pagar toda la deuda y los gastos. 
Cerca de  dos años después, el mercado había mejorado y muchas personas nos estaban 
haciendo ofertas para comprarla, entre las cuales la mejor era de 86 000 dólares. Kim y yo 
no aceptamos la oferta, aunque era tentadora. Si hubiéramos vendido, habríamos tenido un 
aumento de aproximadamente un ciento por ciento de ganancia anual en nuestro pago inicial 
como se ilustra en los números siguientes.
86 000 dólares oferta inicial
-66 000               precio de compra
20 000 ganancia
20 000 = aproximadamente 200 por ciento en dos años, 10 000 dólares de pago inicial, cien por 
ciento al año en ganancia efectivo sobre efectivo. (Digo aproximadamente porque habría otros 
gastos involucrados en la transacción y no toma en cuenta la combinación.)
Aunque el 100 por ciento de ganancias era atractivo, no vendimos. La casa estaba en un 
vecindario excelente y sentimos que al final alcanzaría el rango de 150 000 dólares en tres o 
cuatro años. En lugar de vender esa casa, decidimos comenzar a comprar más, ahora que el 
mercado estaba dando buen precio de venta y también ingreso de alquiler.
Debido a los fuertes indicadores del mercado, Kim y yo solicitamos un préstamo sobre 
hipoteca, El balance en la hipoteca ahora era menos de 55 000 dólares y el aumento de valor 
llegó a aproximadamente 95 000 dólares. La renta podía cubrir una hipoteca de alrededor de 
70  000  dólares,  así  que  refinanciamos  la  casa  y  pusimos  en  nuestro  bolsillo 
aproximadamente 15 000 dólares. Habíamos recuperado nuestro dinero y seguíamos 
teniendo el activo. El perro había atrapado al pájaro y ahora podíamos salir a buscar otro 
pájaro. Además de eso, el perro ahora valía 15 000 dólares.
En unos cuantos meses, después de ver varios cientos de propiedades, encontramos nuestro 
nuevo blanco. Era una casa excelente en el mismo vecindario. La casa no se había mostrado 
bien puesto que el dueño había dejado que sus hijos vivieran en ella sin pagar renta durante 
años. El precio que pedían era de 98 000 dólares y, después de varias ofertas y contraofertas, la 
compramos por 72 000 dólares, gastamos 4 000 dólares para pintura y reparaciones y la 
pusimos en renta.
A finales de 1994, vendimos las dos casas justo por un poco menos de 150 000 dólares cada 
una y tomamos ese dinero para comprar un condominio grande en Arizona, donde los precios 
del mercado seguían bajos.
Además de mantener en movimiento nuestro dinero, hay algunos puntos que quisiera señalar.
1.Nos fue bien porque el mercado seguía bajo y eso nos dio tiempo para buscar y negociar 
inversiones sensatas. Si el mercado hubiera estado alto, tenderíamos a buscar con mayor esfuerzo 
y tenderíamos a ser aún más cautelosos.
2.Las inversiones tenían que tener sentido hoy, no mañana. Digo esto porque demasiadas personas 
tienen la estrategia de compra, conserva y reza. Mi padre rico siempre decía: "Tu ganancia se 
produce cuando compras, no cuando vendes". Cada propiedad que compramos tenía que tener un flujo 
de efectivo positivo en el día que la comprábamos incluso en una economía mala. Si el mercado no 
hubiera subido, Kim y yo seguiríamos felices con la inversión.
3.Como dije antes en este libro, cada inversionista tiene una estrategia de salida antes de entrar en el 
mercado. Como éste era un nuevo tipo de' mercado, aunque era inversión en bienes raíces, era un tipo 
diferente de inversión en bienes raíces. Esta diferencia nos exigió comenzar de nuevo, haciendo nuestra 
investigación y dando con nuevas estrategias de entrada y salida.
4.Esas dos casas se venderían por 200 000 a 250 000 dólares hoy en día, ahora que se ha 
recuperado el mercado de Portland. La razón por la que vendimos antes fue para dejar algo de 
dinero en la mesa para el siguiente comprador, para también aprovechar un mercado que estaba 
bajo y a punto de subir, en este caso, el de Phoenix, y porque nuestro portafolio de inversión había 
cambiado. Ya no teníamos casas para una sola familia; ahora nos habíamos graduado para pasar a 
condominios cada vez más grandes, otra vez para tener más apalancamiento.
5.Conoce la diferencia entre ser inversionista y comerciante. Nosotros fuimos inversionistas cuando 
estuvimos dispuestos a comprar y conservar propiedades por su flujo de efectivo. Fuimos 
comerciantes cuando supimos nuestra estrategia de entrada y de salida. En otras palabras, un 
inversionista compra para conservar y un comerciante compra para vender. Si quieres retirarte rico, 
necesitas saber en qué son diferentes y cómo ser las dos cosas.
En mi opinión, una de las razones por las que tantas personas perdieron dinero en esa última 
caída de la bolsa se debió a que en realidad eran comerciantes que pensaban que eran 
inversionistas. De nuevo, esto ilustra aún más la importancia de saber las definiciones de 
las palabras.
6.. Kim y yo invertimos a largo plazo. Pero para nosotros invertir a largo plazo no significa estacionar el 
dinero, dejarlo en una gran pila, pensando que estás diversificado cuando en realidad todas tus 
inversiones están en ese único vehículo, un vehículo como los fondos de inversión v luego te encuentras 
en espera de que el viento no sople o de que el fuego no arda. Para nosotros, invertir significa estar en 
el mercado todos y cada uno de los días de nuestra vida, reuniendo más información, obteniendo cada 
vez más experiencia de la vida real y manteniendo en movimiento nuestro dinero, sobre el fuego. 
Nosotros no compramos, conservamos y rezamos, que es lo que hacen, significando a largo plazo, 
millones de personas.
"Quiero recuperar mi dinero"
La mayoría de los compradores saben que pueden recuperar su dinero si no les gusta el 
producto que acaban de comprar. La mayoría de los minoristas ofrecen una garantía de 
devolución del dinero si el cliente no está satisfecho. El problema con la mayoría de las 
garantías de devolución del dinero es que, para poder recuperarlo, primero tienes que 
devolver el producto. Si eres un inversionista sofisticado, lo que quieres es la devolución de 
tu dinero y también quieres conservar el activo. Ésa el la razón por la que me encanta invertir. 
Logro quedarme con lo que compré y recupero mi dinero. Por esa razón mi padre rico decía: 
"Una de las cosas más importantes que necesita decir  un inversionista real es: 'Quiero 
recuperar mi dinero. También quiero conservar mi inversión'".
Si puedes entender el principio de la inversión, entenderás lo que significa velocidad del 
dinero. Significa que quieres recuperar tu dinero lo más rápido posible para reinvertirlo con 
el fin de adquirir otros activos.
Más de una forma de acelerar tu dinero
Esta idea de la velocidad de tu dinero no se aplica sólo a los bienes raíces. La idea de la 
velocidad del dinero es realmente un principio o herramienta mental de los ricos. Una vez 
que entiendes el principio, quieres ser capaz de aplicarlo en todo lo que haces. La velocidad 
del dinero es un aspecto importante del apalancamiento.
Otra forma de aumentar la velocidad del dinero es a través de conocer las leyes en materia 
de impuestos y a través del uso de entidades corporativas. Por ejemplo, digamos que 
alguien es dueño de un negocio y también tiene parte de un segundo negocio que invierte 
en bienes raíces. El diagrama y la explicación se ven de la siguiente manera:
El egreso por arriendos de una compañía fluye al ingreso por arriendos de la otra. Es probable 
que no reconozcas por qué esto es importante. Como es probable que sepas, a un negocio se le 
cobran impuestos después de tomar en cuenta sus gastos, mientras que a los individuos se les 
cobran impuestos antes de sus gastos. Así que un individuo que renta una casa paga por ella 
con dinero después de impuestos. El negocio puede pagar esa renta con dinero previo a 
impuestos. El ingreso por arriendos pasa a otra entidad corporativa pero ese ingreso se 
clasifica ahora como ingreso pasivo, en vez de ingreso ganado. (Hay una excepción donde el 
dueño de dos empresas es el mismo y el ingreso debe tratarse como ingreso ganado. Por 
ejemplo, si tienes un negocio en tu casa y te pagas renta a ti mismo, tendrás que tratar ese 
ingreso como ingreso ganado.) El ingreso pasivo, si se maneja adecuadamente, puede pasar al 
individuo o al negocio pagando sustancialmente menos en impuestos. Como siempre, 
recomendamos tener consejeros competentes en materia de leyes y de impuestos antes de 
hacer algo similar.
Una persona que administra su portafolio de inversión o de negocios de esta forma puede 
mantener su dinero moviéndose más rápido pagando mucho menos impuestos. Si fluyera 
hacia una sola entidad corporativa, se estancaría y se le cobrarían muchos impuestos.
Al ver las columnas de activos de ambos negocios, notarás que está el activo del negocio en 
una columna y el activo de la propiedad de alquiler en la otra. En este ejemplo, el dinero de 
esa persona se usa para crear o adquirir dos activos con impuestos eficaces. Éste es otro 
ejemplo de velocidad del dinero o dinero que trabaja en lugar de estar estacionado.
No puedes hacer eso
Cuatro palabras que escucho a menudo cuando uso el ejemplo anterior en mis clases de 
inversión son: "No puedes hacer eso". Como sabes, ésas son palabras que definen la realidad o 
contexto de una persona. En mis tiempos anteriores, iba con empresas pequeñas y les 
explicaba esas estrategias para empleados de la compañía.
Al final de mis pláticas, casi siempre escuchaba que decían: "No puedes comprar bienes raíces 
tan barato". O: "No puedes comprar una casa sin una nueva hipoteca o sin la aprobación de un 
banquero". O: "No puedes ser el dueño del negocio y de la compañía que le renta los bienes raíces 
a tu negocio". O: "Eso puede funcionar en Estados Unidos, pero no se puede hacer en mi país".
Ya no doy esas pláticas sobre inversión a empleados ni auto-empleados. Sólo doy esas pláticas 
a personas que son o quieren ser dueños de negocios o inversionistas. Dejo que asesores de 
inversión tradicionales hablen con grupos de empleados o de autoempleados, no por los 
individuos involucrados sino por la conciencia colectiva de esos grupos. Como dije antes, las 
palabras "No puedo" a menudo son las palabras que definen el cuadrante del que proviene 
una persona.
El ejemplo usado arriba se hace todos los días en todo el mundo. En todos los países en los 
que he hecho negocios, es una práctica común comprar un edificio con sólo hacerse cargo de 
la hipoteca. Pero esto se hace principalmente en inversiones grandes. La idea de un negocio 
que renta bienes raíces de otro cuyo propietario es la misma persona se hace todo el tiempo. 
Es una práctica común. McDonald's usa esta misma fórmula. Le vende una franquicia a un 
individuo. Luego el individuo le paga a McDonald's una cuota de franquicia y también le 
paga renta a McDonald's por el bien raíz. De Padre Rico, Padre Pobre, es probable que 
recuerdes que Ray Kroc, el fundador de McDonald's decía: "Mi negocio no son las 
hamburguesas, mi negocio son los bienes raíces". Ray Kroc y su equipo obviamente 
comprendían la velocidad del dinero y cómo usarlo para adquirir más de un activo.
Velocidad del dinero con activos en documentos
La idea de la velocidad del dinero se aplica a todos los activos, incluyendo los activos en 
documentos. Cuando alguien ve una proporción P/E de una acción, están viendo la velocidad 
en muchas formas. Cuando alguien dice que la proporción P/E de una acción es veinte 
significa que te tomará veinte años recuperar tu dinero, con base en el precio y las 
ganancias actuales. Por ejemplo, si el precio de una acción es de veinte dólares hoy y está 
pagando un dólar de dividendo anual, entonces te tomará veinte años recuperar tu dinero.
La regla del 72
La regla del 72 es otra medida de velocidad del dinero. Esta regla mide el interés o 
porcentaje anual de crecimiento de algo, Por ejemplo, si recibes diez por ciento de interés en 
tus ahorros, tu dinero se duplicará en 7.2 años. Si tu acción esté aumentando de valor en 
cinco por ciento al año, eso significa que te tomará 14.4 años duplicar tu dinero. Si aumenta 
de valor en veinte por ciento al año, entonces tomará 3.6 años duplicar el valor. La regla del 
72 es simplemente dividir el número 72 entre el interés o porcentaje de ganancia en valor 
para dar la relativa velocidad a la cual se duplicará tu dinero.
Durante el auge económico de finales de los noventa, muchos especialistas en planeación 
financiera y asesores de inversión estaban vendiendo la sabiduría de la regla del 72. Hace unos 
años, un joven asesor de inversiones me dijo que su portafolio de inversión estaba duplicando 
de valor cada cinco años.  Le pregunté cómo sabía eso puesto que sólo había estado 
invirtiendo desde tres años atrás. Su respuesta fue: "Porque el fondo de inversión donde está 
mi dinero ha promediado más de quince por ciento anual durante los últimos dos años". Le 
agradecí su entusiasmo en su intento por venderme más fondos de inversión, pero decliné. 
Me pregunto qué estará diciendo hoy. Pensé en contarle la historia del toro y el oso. Esa 
historia dice que el toro sube por las escaleras pero el oso baja saltando por la ventana. En 
otras palabras, como diría mi padre rico: "Los promedios  son para inversionistas 
promedio".
Jugando con dinero de la casa
Se trata de una forma más en la que un inversionista puede usar la velocidad del dinero a su 
favor y se hace jugando con dinero de la casa.
Hay dos razones por las que me encantan las acciones de capital pequeño. La razón número 
uno es porque soy empresario más que una persona corporativa. Me gustan y entiendo los 
problemas de las pequeñas compañías que empiezan y puedo sentir si un negocio tiene 
posibilidades de crecimiento o no. La razón número dos es porque una acción de capital 
pequeño, puede duplicar o triplicar su valor mucho más rápido que una acción de primera 
con precios superiores de demanda. Como una acción de capital pequeño tiene una mejor 
probabilidad de duplicarse o triplicarse más rápido que muchas acciones de capital alto, en 
las condiciones de mercado adecuadas es más fácil jugar con dinero de la casa. El siguiente 
es un ejemplo de jugar con dinero de la casa.
Digamos que compras 5 000 acciones de una compañía X por cinco dólares cada acción. 
Ahora tienes 25 000 dólares en la bolsa. La bolsa te sonríe y, en menos de un año, el precio 
de la compañía X es ahora de diez dólares por acción. Ahora tienes una valorización del 
mercado de 50 000 dólares. Un inversionista codicioso, cosa que yo he sido, diría: "La bolsa 
seguirá subiendo así que esperaré". Una vez más, una estrategia de salida es importante antes 
de entrar a la bolsa.
En lugar de quedarte y sólo estacionar tu dinero, una forma de aumentar la velocidad de tu 
dinero es simplemente vender 25 000 dólares en valor de acciones. De esa forma, seguirás 
teniendo 25 000 dólares en valor de acciones y habrás recuperado tu dinero. Las acciones 
restantes que tienen la valorización de 25 000 dólares en ese momento son un ejemplo de 
jugar con dinero de la casa.
Yo uso esta estrategia con frecuencia, pero no todo el tiempo. Ha habido veces en que el 
precio de la acción pasó de cinco a ocho dólares, sin alcanzar el precio de salida de diez 
dólares, así que esperé. Muchas veces, la acción no se ha mantenido y ha bajado por debajo 
de cinco dólares, dejándome ya sea sin dinero o todavía en la mesa. Debo admitir que las 
veces en que he usado esta estrategia de vender acciones para recuperar mi inversión inicial, 
me he sentido mucho mejor con relación a mi inversión, aunque probablemente no haya 
ganado tanto, debido al hecho de que tomé algo de dinero de la mesa.
Adiós, dinero
Mi amigo Keith Cunningham a menudo recita un poema corto que dice:
Que el dinero habla no lo puedo negar una vez lo escuché adiós me dijo sin más.
Nunca he entendido por qué la gente llora por perder dinero en el mercado de inversiones. No 
lloran cuando van a la tienda de abarrotes y gastan dinero que no recuperan. No lloran cuando 
compran un coche y pierden dinero al venderlo. ¿Así que por qué las inversiones deberían 
ser diferentes?
Con frecuencia escucho a inversionistas que dicen: "No has perdido nada de dinero siempre y 
cuando no vendas la acción".
Cuando escucho que alguien dice algo semejante, con frecuencia significa que compraron a 
un precio alto y que ahora está bajo y están esperando que el precio vuelva a subir. Hay 
algo de validez en esa forma de pensar, pero sólo en situaciones de casos especiales. Una 
mentalidad opuesta a ésa es cortar tus pérdidas pronto. Hay veces en que he invertido de 
manera equivocada y el precio de mi inversión cae en lugar de subir. Si el precio de una 
acción baja más de diez por ciento las más de las veces reduzco mis pérdidas y busco algo 
nuevo. Hay dos razones por las que puedo hacerlo:
Razón #1: Si mi atención está demasiado enfocada en la pérdida y me siento mal por tomar una 
mala decisión, vendo. Sólo quiero cortar y seguir adelante. Como he dicho en otros libros, sé que 
de diez inversiones, las probabilidades indican que dos a tres serán malas, dos a tres serán 
buenas y todo lo que haya en medio simplemente estará ahí como un costal de papas. En 
ocasiones, dejo que los costales de papas se queden por ahí siempre y cuando no estén 
perdiendo dinero. Si se convierten en papas de verdad, corto, reviso mis errores y tomo las 
lecciones.
Razón #2: Me encanta comprar. Así que si tengo menos dinero con qué comprar soy más 
feliz comprando que vendiendo, conservando y rezando para que algún día la inversión vuelva a 
subir. Como dije antes, la mayoría de las personas no lloran cuando venden su coche nuevo 
que ahora es usado y le pierden. La razón por la que no lloran es porque por lo general 
están comprando un coche nuevo.
¿Cuánto duran las acciones de primera con precios superiores de demanda?
Hay otra estrategia de inversión que escucho a menudo y que es: "Invierte a largo plazo y 
sólo compra acciones de primera".
Para mí, se trata de una idea obsoleta, funcionaba en la Era Industrial pero no funciona en 
la Era de la Información. La razón por la que esa vieja estrategia no funciona es porque las 
acciones de primera ya no son de primera. Por ejemplo, si hubieras invertido en Xerox hace 
veinte años, estarías sufriendo hoy, a pesar de que es una acción de primera clase. La pregunta 
real que cada uno de nosotros nos tenemos que hacer es por cuánto tiempo una acción de 
primera será de primera.
Muchas de las empresas actuales de Fortune 500 puede ser que no existan dentro de diez 
años, debido a cambios tecnológicos y otras innovaciones. Las empresas de primera, que 
solían durar 65 años, ahora están durando sólo diez. Esos puntos demuestran que la vieja 
estrategia de negocios ya no funciona en el mundo de hoy.
En esta época de tecnología que se mueve más rápido, una compañía puede elevarse y caer 
en tan solo unos años, Esita velocidad de cambio requiere entonces que todos estemos más 
vigilantes y que nos enfoquemos en mantener en movimiento nuestro dinero, en vez de 
simplemente dejarlo estacionado esperando que la bolsa suba y suba siempre. La estrategia de 
compra, conserva y reza está bien para el inversionista promedio, pero no es una estrategia 
buena para alguien que quiere retirarse joven y rico.
CAPÍTULO 16
El apalancamiento de los bienes raíces
Invirtiendo con el dinero de tu banquero
La otra noche cené con una amiga y con su padre. Él es un piloto de aerolínea retirado. La 
bolsa acababa de caer otro tres por ciento ese día y él estaba muy alterado porque su cuenta 
de retiro estaba perdiendo todas sus ganancias. Cuando le pregunté qué pensaba sobre la 
bolsa dijo: "Mi otra hija me llamó por teléfono y me dijo que podía mudarme a su casa si lo 
perdía todo".
Con cautela, pregunté: "¿Quiere usted decir que las únicas inversiones que tiene están en la 
bolsa?"
"Bueno, sí", dijo. "¿Qué otro tipo de inversiones hay? La bolsa es el único lugar que 
conozco. ¿En dónde más se puede invertir?"
No “diversi-empeores” tu portafolio
El mantra común que hoy se escucha en todas partes es: "Invierte a largo plazo, promedia el 
costo, diversifica tu portafolio, etcétera, etcétera, etcétera". Ése es una mantra excelente para 
las personas que no saben mucho sobre inversiones. La palabra que yo siempre he cuestionado 
es diversifica. Cuando escucho que alguien dice que tiene un portafolio diversificado, con 
frecuencia pregunto qué quiere decir con esa palabra. Las más de las veces, dicen algo así 
como "tengo algunos fondos de crecimiento, fondos de bonos, fondos internacionales, fon-dos sectoriales, fondos de capital medio" y así sucesivamente.
Mi siguiente pregunta es "¿todos están en fondos de inversión?" De nuevo, en la mayoría de 
los casos, la respuesta es: "Sí, la mayoría de mis inversiones están diversificadas en 
diferentes  fondos   de  inversión".  Aunque  sus  fondos   de  inversión   pueden  estar 
diversificados, la realidad es que el instrumento de inversión de su elección, en este caso 
los fondos de inversión, no está diversificado. Aun si dicen: "Sí entro un poco en acciones, 
invierto en REITS (fideicomisos de inversión en bienes raíces) y tengo algunas anualidades", 
el hecho difícil es que la mayoría de las personas se encuentran sólo en la categoría de activos 
en papel. ¿Por qué?... porque es más fácil entrar y administrar los activos en papel. Como 
decía mi padre rico: "Los activos en papel son más estériles. Son más puros y más limpios. 
La mayoría de las personas no son del cuadrante D y nunca construirán un negocio de 
cuadrante D y la mayoría de las personas no invertirán en bienes raíces por los retos de ad-quisición, liquidez y administración".
En Estados Unidos, hay más de 11 000 fondos de inversión para elegir y ese número está 
creciendo. Hay más fondos de inversión que empresas en las que invierten estos fondos. ¿Por 
qué hay tantos fondos de inversión? Por las mismas razones enlistadas antes. Son estériles y 
con frecuencia esterilizados con la idea de proteger al público. El problema que tiene el 
público es averiguar cuál de esos 11 000 fondos es mejor para ellos. ¿Cómo vas a saber si el 
fondo de moda hoy será el de moda el día de mañana? ¿Cómo demonios eliges el fondo ga-nador hoy para tu retiro el día de mañana? Y si más de 80 por ciento de tu portafolio de 
inversión está en fondos de inversión,  ¿realmente es diversificación y es inteligente? 
Personalmente, no lo creo. Cualquiera que tenga 80 por ciento o más de su portafolio en 
diferentes fondos no está diversificando realmente, en realidad está diversiempeorando su 
portafolio.
El trágico defecto de los fondos de inversión
Es probable que algunos de ustedes conozcan el defecto fiscal de los fondos de inversión. 
Desafortunadamente, hay muchos inversionistas de fondos de inversión que no conocen el 
defecto fiscal de estos, defecto que cobra impuestos al inversionista sobre ganancias en 
bienes de capital. Eso significa que, si hay una utilidad y una consecuencia fiscal sobre 
ganancias en bienes de capital, el fondo no paga el impuesto, lo paga el inversionista. Este 
defecto es especialmente pronunciado en un mercado bajista. Sin embargo, hay excepciones; 
por ejemplo, las utilidades de fondos de inversión que se tienen en ciertos fondos de retiro 
son diferidas.
Digamos que el fondo ha tenido gran éxito durante varios años. Ha comprado bien y muchas de 
las acciones que ha elegido han aumentado de valor en gran medida. De pronto, baja la bolsa, 
los inversionistas entran en pánico y empiezan a pedir que les devuelvan su dinero. Entonces, 
el fondo debe vender sus mejores acciones rápidamente para poder devolver el dinero de los 
inversionistas. Cuando el fondo vende sus acciones, se deben pagar ganancias en bienes de 
capital por las acciones. Por ejemplo, el fondo compró a una empresa X hace diez años por 
diez dólares cada acción y, cuando lo venden, se vende en 50 dólares cada acción. De modo 
que el administrador del fondo hizo bien en elegir las acciones a tiempo, pero ahora, al 
momento de la venta, el inversionista tiene que pagar el impuesto sobre ganancias capitales de 
sus 40 dólares de ganancia. En momentos como éste, el inversionista puede perder dinero porque 
el valor del fondo puede haber bajado mientras que, al mismo tiempo, debe pagar impuestos 
sobre ganancias en bienes de capital. Así que a un inversionista de fondos de inversión se le 
puede pedir que pague impuestos sobre ganancias en bienes de capital, a pesar de que puede 
haber perdido dinero en lugar de ganar. Personalmente, no me gusta tener que pagar 
impuestos cuando en realidad he perdido dinero. Es como pagar impuestos a dinero ganado 
que no recibiste. A comienzos de 2001, hubo muchos inversionistas a quienes se les redujo a la 
mitad el valor de sus fondos de inversión y al mismo tiempo tuvieron que pagar impuestos 
sobre ganancias en bienes de capital que les dieron sus fondos de inversión. Para mí, se trata 
de un defecto trágico.
¿Qué estoy diciendo, que no hay que invertir en fondos de inversión? No, yo tengo dinero en 
fondos de inversión. En Guía para invertir de Padre Rico hablé sobre que los planes 
financieros deben ser seguros, cómodos y ricos. Los fondos de inversión pueden 
desempeñar un papel importante para que tus planes financieros sean seguros y cómodos. 
Busca un asesor financiero competente para que te ayude a desarrollar el plan adecuado 
para ti, pero entre más te prepares sobre las inversiones financieras disponibles más 
alfabetizado financieramente serás. Hay algunos fondos de inversión que usan enfoques 
sistematizados al seleccionar a las empresas en las que invierten, estudiando sus principios 
subyacentes.
La belleza de invertir en bienes raíces
El padre de mi amiga, el piloto de aerolínea retirado que pensaba que el único tipo de inversión 
era la inversión en activos en papel, hasta ahora se daba cuenta del defecto trágico de los fondos 
de inversión. Conforme la cena se acercaba a su fin, dijo: "He perdido gran parte de mis 
ahorros porque el valor de acciones de mis fondos ha bajado y ahora tengo que pagar 
impuestos sobre ganancias en bienes de capital aunque el valor está bajo. Desearía que hubiera 
algo más en lo que pudiera invertir".
"¿Por qué no invierte en bienes raíces?", pregunté.
"¿Por qué? ¿Cuál es la diferencia?", preguntó.
"Hay muchas diferencias", contesté. "Déjeme contarle sobre una diferencia que realmente 
es bastante interesante".
El piloto retirado dio un sorbo a su café y dijo: "Cuéntame. Soy todo oídos".
"En los bienes raíces, puedo hacer dinero y el gobierno me deja contarlo como una pérdida 
de dinero".
"Quieres decir que haces dinero y obtienes una exención de impuestos en vez de tener que 
pagar impuestos sobre el dinero que hiciste?", preguntó el piloto.
"El gobierno me da una exención de impuestos sobre mis ganancias en lugar de hacerme 
pagar impuestos sobre mis ganancias en bienes de capital", dije. "El gobierno me deja 
quedarme con más dinero en lugar de pagar más impuestos. Una forma es a través de la 
depreciación o lo que mi padre rico llamaba flujo de efectivo fantasma, que es flujo de 
efectivo que el inversionista promedio no puede ver".
El piloto retirado escuchó en silencio durante un momento largo y al final dijo: "¿Hay más?"
"Mucho más", dije. "Hasta me podrían dar dinero".
"¿Cómo?", preguntó el piloto.
"Si un edificio es histórico, el gobierno le puede dar un crédito fiscal, lo cual es mucho 
mejor que una deducción de impuestos, para mejorar su inversión", dije. "¿Cree que el go-bierno le dará un crédito fiscal para comprar más fondos de inversión?"
"No que yo sepa", dijo el piloto. "Lo único que he visto últimamente es un impuesto sobre 
ganancias en bienes de capital aplicado a dinero que nunca he ganado y que de hecho he 
perdido. Suena como que yo pago impuestos sobre dinero que he perdido y tú obtienes una 
exención de impuestos sobre dinero que has hecho. ¿Hay algo más que deba saber?"
"Sí, hay algo más", dije. "Puede recibir un crédito de impuestos por 50 por ciento del costo 
de la mejora relacionada con el Decreto de Norteamericanos con Discapacidad. Por ejemplo, si 
paga 10 000 dólares para poner una rampa para silla de ruedas para que personas con 
discapacidad puedan tener acceso a su edificio comercial, podría recibir el crédito máximo 
de 5 000 dólares".
"¿Obtienes un crédito de impuestos de 5 000 dólares?", preguntó el piloto. "¿Y qué tal si no te 
cuesta 10 000 dólares poner la rampa para silla de ruedas? ¿Qué tal si construir la rampa 
sólo te cuesta mil dólares?"
"Aun así conseguirá un crédito de impuestos por el 50 por ciento del costo de la mejora", 
dije. "Pero claro, le recomiendo mucho que lo verifique con su contador antes de hacer algo 
semejante. Querrá asegurarse de conocer las regulaciones y beneficios actuales antes de 
hacer algo".
El piloto permanecía sentado en silencio, pensando. "¿Algo más?"
"Mucho más. En realidad es demasiado para discutirlo en la cena", dije. "Pero déjeme darle 
tres ventajas más de los bienes raíces sobre los fondos de inversión".
"¿Tan sólo tres más?", dijo el piloto con una gran sonrisa sarcástica.
"Una ventaja más es que el banco le prestará el dinero para comprar su propiedad. Hasta 
donde yo sé, dudo de que el banco le preste dinero para invertirlo en fondos de inversión o 
acciones. Pueden usar activos como colateral, pero sólo después de que usted ha invertido 
su dinero para adquirirlos".
El piloto asintió con la cabeza y dijo: "¿Y la número dos?"
"La número dos es no pagar impuestos sobre ganancias en bienes de capital", dije. "Si sabe 
lo que está haciendo".
"Quieres decir que yo debo pagar impuestos sobre ganancia de capital en dinero que no gané, 
que de hecho perdí, y que con los bienes raíces se pueden evitar los impuestos a las ganancias 
en bienes de capital".
Asentí con la cabeza. "Se hace todo el tiempo. Se hace a través de un intercambio llamado 
intercambio 1031. Por ejemplo, digamos que compro una casa por 50 000 dólares, dando 
sólo 5 000 dólares de pago inicial, pidiendo prestados al banco los 45 000 dólares restantes. Y 
digamos que la renta cubre mis gastos mensuales y todavía queda dinero de manera que 
tengo flujo de efectivo de mi inversión".
"Entonces tu dinero está trabajando para ti", dijo el piloto.
"Sí", contesté. "Y el ingreso es ingreso pasivo así que se le cobran impuestos en una tasa más 
baja que en el caso del ingreso ganado como el ingreso de un sueldo, el ingreso de los ahorros y 
su 401(k)".
El piloto agitó la cabeza en silencio. Antes esa misma noche ya habíamos hablado sobre las 
diferencias entre ingreso ganado, de portafolio y pasivo.
Siguiendo adelante, dije: "Después de unos años, se da cuenta de que su casa en alquiler de 50 
000 dólares ahora vale 85 000 dólares. La vende por una ganancia de 35 000 dólares pero no 
tiene que pagar las ganancias en bienes de capital si quiere ponerlas en una inversión más 
grande".
De nuevo el piloto agitó la cabeza en silencio, diciendo: "En este ejemplo, ganas 35 000 
dólares en ganancias en bienes de capital y no pagas ningún impuesto sobre ganancias en 
bienes  de capital. Yo pierdo dinero en mis fondos de inversión y pago impuestos sobre 
ganancia capital. Tú recibes flujo de efectivo y tienes esa compensación de ingreso mediante 
pérdidas y gastos fantasma y pagas menos en impuestos sobre el ingreso de los impuestos 
que pagas, porque es ingreso pasivo, no ingreso ganado".
"Y no olvides los créditos fiscales por mejoras hechas para el Decreto de Norteamericanos 
con Discapacidad en una propiedad comercial o si la propiedad es histórica", añadí.
"Ah, no", dijo el piloto. "¿Cómo podría olvidar los créditos fiscales? Todo el mundo sabe 
sobre los créditos fiscales. ¿Entonces cuál es el tercer punto?"
"El tercer punto es que entre más grande sea la inversión en bienes raíces, más querrán los 
bancos y el gobierno prestarte dinero", dije.
"¿Por qué es así?", preguntó el piloto.
"Cuando vas con tu banquero y le presentas una inversión en bienes raíces digamos de más 
de un millón de dólares, el banquero no te está prestando dinero a ti. Está prestando dinero 
sobre la propiedad".
"¿Cuál es la diferencia?", preguntó el piloto.
"Cuando la persona promedio va al banco a pedir un préstamo, el banco evalúa si el 
individuo es sujeto de crédito. Cuando esa misma persona quiere comprar, por decir algo, 
una pequeña propiedad de alquiler, una propiedad como un condominio individual, una casa, 
un dúplex, el banquero sigue evaluando principalmente a la persona. Mientras tengas un 
trabajo fijo y suficiente ingreso como para pagar esas propiedades pequeñas, el banco con 
frecuencia te prestará el dinero a ti, no a la propiedad".
"Pero en propiedades más grandes, cuando el precio está más allá del ingreso del individuo, 
el banco analiza el ingreso y los gastos de la propiedad en sí", dijo el piloto. "¿Es ésa la 
diferencia?"
"Bastante cerca", dije. "En las propiedades más grandes el activo realmente es la propiedad y 
su flujo de ingreso, no el flujo de ingreso del individuo que pidió el dinero".
"Así que puede ser más fácil comprar una propiedad más grande en lugar de una más 
pequeña", dijo el piloto.
"Si sabes lo que estás haciendo", dije. "Lo mismo es cierto con los préstamos del gobierno. 
Si acudes al gobierno con una propiedad de 150 000 dólares, en muchos casos la agencia del 
gobierno no está interesada. Pero si quieres adquirir una propiedad en un barrio bajo y la 
quieres convertir en un lugar de viviendas seguras para personas con poco ingreso, el 
gobierno tiene millones de dólares para prestarte. De hecho, si tu inversión no supera cinco 
millones de dólares, es difícil lograr que alguien del gobierno se interese en tu propiedad".
"¿Algo más?", preguntó el piloto.
"La lista sigue", contesté. "Pero déjame darte la desventaja de los bienes raíces".
"¿Como cuál?", preguntó el piloto.
"Los bienes raíces, en la mayoría de los casos, no tienen tanta liquidez como los activos en 
papel. Eso significa que puede tomar más tiempo comprar y vender bienes raíces. El mercado 
de bienes raíces tampoco es tan eficaz como el mercado en papel. Y los bienes raíces 
pueden requerir de una administración intensa", dije con una sonrisa.
"¿Por qué estás sonriendo?", preguntó el piloto.
"Porque las desventajas con frecuencia son las mayores ventajas del inversionista profesional 
en bienes raíces", dije. "Las desventajas con frecuencia sólo son desventajas para los 
inversionistas nuevos o poco sofisticados".
"Dame un ejemplo", dijo el piloto.
"Muy brevemente", contesté. "Como los bienes raíces no tienen tanta liquidez y puede ser 
más difícil encontrar a alguien que compre o que venda, el inversionista profesional con 
frecuencia puede tomarse ese tiempo para hacer un trato".
"Quieres decir que puedes hacer algo de negociación uno a uno con el que vende", dijo el 
piloto.
"O con el que compra", contesté. "En la bolsa, con frecuencia es sólo comprar o vender. 
Muy rara vez hay algún tipo de negociación uno a uno entre quien compra y quien vende... 
por lo menos no para la mayoría de los inversionistas".
"¿Quieres decir que en la bolsa puede haber negociaciones uno a uno entre quienes compran 
y quienes venden?", preguntó el piloto.
"Sí", contesté. "Pero eso entra en el área gris de los jugadores profesionales e internos. Se 
puede hacer legalmente, pero no es algo que haga por lo general el inversionista promedio".
"Ah", dijo el piloto. "Pero se hace todo el tiempo en los bienes raíces".
"Eso es lo divertido de los bienes raíces", contesté. "Ahí es donde se puede ser creativo, 
negociar términos, hacer un mejor trato, bajar el precio o subirlo. Pida a quien vende que 
meta un barco o que dé el pago inicial por usted. Se vuelve divertido una vez que se 
aprende el juego".
"¿Qué más?", dijo el piloto.
"Puede reducir gastos, mejorar el valor de la propiedad, agregar un dormitorio adicional, 
pintar, vender terreno extra y así sucesivamente. Los bienes raíces son excelentes para el 
inversionista creativo que es buen negociante. Si eres creativo y un buen negociante, puedes 
hacer una fortuna en los bienes raíces y divertirte al mismo tiempo".
"Nunca lo vi de esa forma", dijo el piloto. "Lo único que he hecho es comprar y vender las 
casas en las que ha vivido mi familia. Pero ahora que lo pienso fue divertido y obtuve mejo-res ganancias en mis casas de las que obtuve en mis fondos de inversión".
Pude ver cómo le estaba cayendo el veinte. Ahora podía ver que había algo más en lo que 
podía invertir además de diversi-empeorar su portafolio con fondos de inversión. Aunque le 
estaba cayendo el veinte, se estaba haciendo tarde y era hora de volver a casa... y la velada 
pronto terminó. Unas semanas después, me llamó para decirme que estaba buscando su 
primera propiedad en renta y que se estaba divirtiendo, en vez de preocuparse. Dijo: "Aunque 
mi ingreso por rentas queda parejo con mis gastos, todavía puedo hacer dinero en los bienes 
raíces. Entender el  flujo de efectivo fantasma  y las leyes fiscales es como ganar 
financieramente sin ganar nada de dinero".
Lo único que dije fue: "Está empezando a entender".
Malos consejos de malos asesores
Los asesores son importantes. El problema es que muchos asesores financieros no son 
inversionistas ricos ni exitosos. En una publicación estadounidense muy importante, una 
especialista certificada en planeación financiera dijo lo siguiente con relación a mis consejos 
sobre bienes raíces: "Muchas personas han hecho mucho dinero en los bienes raíces, pero 
principalmente en lugares como California, Connecticut. Nuestros clientes que están aquí en 
los estados del centro no han experimentado eso". Sus clientes deberían despedirla. La razón 
por la que sus clientes en los estados centrales no han ganado nada de dinero en los bienes 
raíces es que la tenían a ella como asesora. Si entiendes los bienes raíces, las leyes fiscales y 
las leyes corporativas y si tienes un buen agente y contador, puedes hacer dinero en los bienes 
raíces aunque la propiedad no aumente de valor ni dé utilidades del ingreso de renta. Su 
reporte sobre que las propiedades sólo aumentan de valor en California y Connecticut también 
está equivocado. Si conociera su mercado, sabría que los mercados de crecimiento más 
rápido en Estados Unidos fueron Las Vegas, Nevada, en cuanto a las ciudades pequeñas, y 
Phoenix, Arizona, en cuanto al crecimiento de grandes ciudades. Sólo escuchó sobre California 
y Connecticut porque sólo sabe lo que dicen en las noticias y la mayoría de las noticias sobre 
inversión se enfocan en los activos en papel. Ella no sabe lo que sabe el inversionista 
profesional en bienes raíces, no obstante, aconseja como si supiera.
Como decía mi padre rico a menudo: "Nunca le preguntes a un vendedor de seguros si 
deberías comprar un seguro". La mayoría de los especialistas en planeación financiera son 
principalmente vendedores de seguros, no inversionistas. Los seguros son un producto de 
inversión muy importante, pero no es el único.
Cómo encontrar una inversión excelente
Como con cualquier inversión, con frecuencia me preguntan: "¿Cómo encuentras una buena 
inversión en bienes raíces?" Mi respuesta es: "Debes entrenar a tu cerebro para que vea lo 
que otros no pueden ver".
La siguiente pregunta es: "¿Cómo lo haces?" La respuesta es: "De la misma forma en que 
cualquier comprador encuentra un buen trato". Al comienzo de este libro escribí sobre 
personas que se enfocaban en ahorrar yendo de una tienda a otra comprando comida en 
oferta. Lo mismo resulta cierto para los bienes raíces o para cualquier inversión... necesitas 
convertirte en un comprador profesional.
100:10:3:1
El doctor Dolf DeRoos, amigo mío desde hace mucho, ha escrito un libro para la serie de 
Asesores de Padre Rico, Ricos de los bienes raíces: Cómo hacerte rico usando el dinero de 
tu banquero. Obviamente, nos confabulamos con el título. En este libro, Dolf detalla cómo 
encontrar ofertas de bienes raíces que se le escaparían a la mayoría de las personas. También 
explica cómo mejorar tu propiedad para mejorar con ello el valor de ésta. El punto básico 
que subraya es cómo comprar una propiedad. Él lo llama método 100:10:3:1 para comprar. 
Eso significa que analiza 100 propiedades, hace ofertas en diez, tiene tres vendedores que 
dicen sí y compra una. En otras palabras, para comprar una propiedad se necesita ver más de 
cien propiedades.
Besa muchas ranas
Como ya sabes, a mi padre rico le encantaban los cuentos de hadas como herramientas de 
aprendizaje. Le encantaba la historia de la princesa que tuvo que besar a una rana para 
encontrar a su príncipe encantador. Mi padre rico decía con frecuencia: "Tienes que besar a 
muchas ranas para saber cuál es un príncipe". En las inversiones, y en muchos aspectos de la 
vida, esta afirmación resulta cierta. Hoy, siempre me sorprende cuando escucho que alguien 
obtuvo un trabajo a los 25 años y se quedó ahí toda su vida. Me pregunto cómo saben cuál es 
la diferencia entre un trabajo bueno y uno malo. Cuando conozco a una persona que decidió ser 
médico a la edad de quince años, me pregunto si realmente usaron la realidad para tomar su 
decisión. Lo mismo resulta cierto en las relaciones y las inversiones.
Mi padre rico decía: "La mayoría de las personas evitan besar a las ranas así que en cambio se 
casan con ellas". Lo que mi padre rico quería decir era que en lo que respecta a la inversión y a 
su futuro, la mayoría de las personas no se toman suficiente tiempo besando. En lugar de 
tomarse el tiempo para buscar buenas inversiones, la mayoría de las personas actúan por 
impulsos, consejos de moda o dejando que un amigo o pariente maneje sus inversiones 
financieras.
Matrimonio con un sapo
Una amiga mía recientemente vino y me dijo "Tomé tu consejo e invertí en una propiedad de 
alquiler".
Con curiosidad, le pregunté: "¿Qué compraste"
"Compré un agradable condominio cerca de la playa en San Diego".
"¿Cuántas propiedades viste?", le pregunté.
"Dos", dijo. "El agente me mostró dos unidades en el mismo complejo y compré una".
Como un año después, le pregunté cómo iba su inversión en la propiedad. "Estoy perdiendo 
como 460 dólares al mes", contestó.
"¿Por qué tanto?"
"Una razón es que la junta que dirige la asociación de propietarios elevó la cuota de 
mantenimiento mensual. La otra razón es que yo no sabía cuánto podía cobrar de rentas 
mensuales. Fue mucho más bajo de lo que pensé", dijo un poco avergonzada. "He intentado 
vender pero descubrí que pagué 25 000 dólares más de lo que el mercado está dispuesto a 
pagar. Así que no quiero perder dinero cada mes y no puedo permitirme darme el lujo de 
perder 25 000 dólares vendiéndola por menos de lo que pagué por ella".
Como diría mi padre rico: "Ése es el precio de no haber besado suficientes ranas. Si no 
besas suficientes ranas, puedes terminar casándote con un sapo". Como mi amiga no hizo su 
tarea, terminó casándose con un sapo, un sapo costoso.
¿Cómo evalúas una buena inversión en bienes raíces? La experiencia es la mayor maestra. 
A continuación se esbozan diez lecciones muy importantes que mis amigos y yo hemos ido 
aprendiendo. Además, esbozaré muchos recursos más que te pueden ser de utilidad.
El precio de no ir de compras
Cuando las personas me preguntan cómo aprendí a encontrar una inversión de bienes raíces 
excelente, simplemente digo: "Necesitas ir de compras".
Estoy de acuerdo con la fórmula 100:10:3:1 de Dolf DeRoos para encontrar una excelente 
inversión. Con los años, Kim y yo hemos visto y analizado literalmente miles de 
propiedades. Cuando nos preguntan "¿cómo aprendieron tanto sobre bienes  raíces?", 
simplemente decimos: "Vimos miles y miles de oportunidades de inversión". También 
hicimos cientos de ofertas para comprar propiedades, de muchas se rieron. El punto es que 
con cada propiedad que veíamos y con cada oferta que hacíamos, crecían nuestro 
conocimiento y experiencia sobre el mercado de bienes raíces y sobre la naturaleza humana.
Cuando nos preguntaban: "¿Qué hacen cuando no tienen dinero?" La respuesta es la misma: 
"Vamos de compras". En mis seminarios de inversión, con frecuencia digo: "Cuando vas a un 
centro comercial, nadie te pregunta si tienes dinero. Los minoristas quieren que compres y 
curiosees. Lo mismo es cierto con la mayoría de las inversiones. Ir de compras, hacer 
preguntas, analizar tratos es la forma en que obtuve mi preparación. Lo que aprendí sobre 
inversiones no se puede encontrar en un libro. Así como no puedes aprender a jugar golf 
mediante un libro, no puedes entrenar a tu cerebro para ver inversiones que otros no pueden 
ver mediante un libro. Debes salir de compras".
La percepción retrospectiva es 20/20
Mi amiga que se casó con un sapo pudo haber aprendido algunas lecciones valiosas, si no se 
hubiera decidido a decir: "Los bienes raíces son una inversión despreciable. No se puede ha-cer nada de dinero en los bienes raíces". Cuando le pregunté qué había aprendido, enojada, 
dijo: "Nunca debí haberte escuchado. El mercado ha cambiado y hoy en día no puedes hacer 
dinero en los bienes raíces".
Hay un dicho que dice: "La percepción retrospectiva es 20/ 20". El problema es que en 
realidad tienes que darte vuelta y mirar detrás de ti. Mi amiga no miró y aprendió. Aunque 
yo la felicité por haber actuado, ella siguió convencida de que los bienes raíces son una 
inversión despreciable, lo cual significa que su incursión en los bienes raíces es extra costosa 
porque no logró aprender de sus invaluables errores, errores y lecciones que pudieron 
haberla hecho más inteligente y más rica en el futuro. Ése es el precio por tener un contexto 
que dice: "Los errores son malos". Si ella hubiera tenido un contexto que marcara: "Actué, 
cometí algunos errores y ahora puedo aprender de esos errores", sería una persona más rica. 
Las personas que deben ser perfectas, o que no se pueden permitir cometer errores, con 
frecuencia son personas sin mucha visión 20/20 y con frecuencia cometen el mismo error, 
que es no lograr aprender de sus errores.
Las lecciones que mi amiga pasó por alto de esa simple inversión son:
1.Ve más propiedades.
2.Tómate tu tiempo. Hay más de un buen trato. Demasiadas personas compran porque creen que el 
trato que han encontrado es el único en el mundo.
3.Analiza el mercado de rentas así como el mercado de compras.
4.Habla con más de un vendedor de bienes raíces.
5.Ten cuidado en invertir en condominios. Con mucha frecuencia, los condominios tienen una junta 
de directores, constituida por propietarios. Los propietarios y los inversionistas no siempre están 
completamente de acuerdo. La mayoría de los propietarios quieren mantener agradable su 
propiedad así que gastan excesivamente en mantenimiento. Aunque esto es bueno para mantener tu 
propiedad en buen estado, un inversionista pierde control sobre esa área muy importante de la 
inversión, el área del control de gastos.
6.Si los gastos están fuera de control, también afecta el futuro precio de venta de la propiedad.
7.Nunca compres esperando que aumente el precio de la propiedad. La propiedad debería ser una 
buena inversión en una buena economía y en una mala economía. Como decía mi padre rico: "Tu 
ganancia se da cuando compras!, no cuando vendes".
8.No inviertas emocionalmente. Cuando compras tu propia inversión personal, está bien ponerse 
emocional Cuando compras una propiedad con fines de inversión, las emociones pueden cegarte. 
Mi amiga estaba más emocionada por el hecho de que la playa estaba cerca de la propiedad que 
por la ganancia sobre la inversión. Veía la playa en vez de los estados financieros.
9.No había mucho que ella pudiera hacer para mejorar la propiedad. Una de las formas en que puedes 
hacer mucho dinero es teniendo control sobre el valor de la propiedad que cambia, se modifica o 
mejora... algo que no puedes hacer con acciones ni con fondos de inversión. Muchas veces, el simple 
hecho de agregar una cochera o una habitación extra puede multiplicar en gran medida tu ganancia 
sobre la inversión.
10. Ella no aprendió de esta experiencia. Aunque fue una lección relativamente costosa, ella podía 
haber convertido el costo de esta lección en millones de dólares si hubiera estado dispuesta a ser 
humilde, a aprender y a intentarlo de nuevo. En cambio, prefería decir: "No puedes hacer dinero en 
los bienes raíces".
Los errores mejoran tu visión
Al invertir el tiempo necesario para analizar miles de inversiones, mi visión mejoró 
lentamente. Cada vez que hice una oferta para comprar una propiedad, aprendí algo, aun si 
se reían de las ofertas o las rechazaban rotundamente. Cada vez que arreglé un 
financiamiento con un banquero, aprendí algo. Cada vez que compré una propiedad, aprendí 
algo nuevo y valioso, aun si perdí dinero en la propiedad. Hoy, la acumulación de todas esas 
lecciones, buenas y malas, es la educación y experiencia que me hace rico y que permite que 
mi esposa y yo ganemos cada vez más dinero en los bienes raíces.
Las grandes inversiones se ven en el ojo de tu mente y en ningún otro lado. En el mundo 
real, no hay letreros de "se vende" que avisen "aquí hay un gran trato". Lo único que dicen los 
letreros es: "Se vende". Es tu tarea entrenar a tu cerebro para que vea un gran trato y también 
para que negocie un gran trato. Eso requiere de preparación y práctica.
Lo que todo el mundo puede hacer
Como prometí, afirmé que todo el mundo puede hacer lo que se necesita para ser rico. Lo 
que todo el mundo puede hacer es salir de compras en busca de bienes raíces. Si tú y un 
socio acuerdan ver cinco, diez, veinte o veinticinco propiedades por semana, aun si no tienes 
dinero, te prometo que tu visión mejorará. Después de analizar cien tratos, sé que encontrarás 
una o dos inversiones que te emocionarán. Cuando estás emocionado sobre hacerte rico, tu 
cerebro cambia a otro contexto y comienzas a buscar una nueva satisfacción, satisfacción que 
puede responder a la pregunta: "¿Cómo consigo el dinero para poder hacerme rico?"
Todo el mundo puede hacer esto, incluso si no tiene nada de dinero. Eso es todo lo que Kim y 
yo hacemos regularmente. Ahora que tenemos un poco más de experiencia, el proceso de 
analizar propiedades va más rápido. En la mejor y en la peor de las economías, siempre hemos 
logrado encontrar un excelente trato. No siempre compramos o hacemos ofertas, pero el 
proceso de buscar inversiones y analizarlas mantiene aguda nuestra mente y nos mantiene en 
contacto con la abundancia de las oportunidades por encontrar, si simplemente sales a 
buscarlas.
Un producto que te puede ayudar en tu carrera de inversiones en bienes raíces es una cinta de 
audio titulada Educación financiera. En esa cinta hay muestras de diferentes formas financieras 
que uno debe saber cómo leer. Una forma es una "Lista de verificación de pagarés". Esa lista 
es vital para examinar la condición física de un edificio. Aunque los estados financieros y los 
estados de pro forma te dan los puntos financieros que debes analizar, esta lista te guía para 
examinar la propiedad en sí y te puede ahorrar dinero así como hacerte ganar mucho. 
También se puede usar como una herramienta de análisis así como de negociación. Como 
decía mi padre rico: "La educación financiera es más que números. La educación financiera 
es saber las palabras que le señalan a tu cerebro cuáles son las fortalezas y debilidades de tu 
inversión. La educación financiera es saber qué ver, cosas que el inversionista promedio pasa 
por alto". Este producto también se puede ordenar en el sitio richdad.com.
Un último punto. Invertir en bienes raíces, o para el caso en cualquier producto de inversión, 
requiere más que comprar una cosa y esperar que un producto te haga rico. En bienes raíces, 
Kim y yo tenemos un plan que consiste en comprar diez propiedades, lo que significa que 
necesitamos ver mil. De esas diez propiedades, esperamos que dos sean excelentes inversio-nes y dos sean papas, inversiones en las que podríamos perder dinero. Por lo general, ésas se 
venden de inmediato. Eso deja seis inversiones que tenemos que mejorar o bien vender. Sin 
importar si se trata de bienes raíces, acciones, fondos de inversión o creación de negocios, las 
proporciones tienden a permanecer igual. Un inversionista profesional lo sabe.
Recompensas que otros no ven
Todo pescador tiene una historia de "uno que se fue". Todo inversionista de bienes raíces 
tiene una historia de una que encontró, una que los demás no vieron. Las siguientes son dos 
historias escritas con el fin de inspirarte a comenzar a ver tus primeras cien inversiones.
Convirtiendo los problemas en oportunidades
Historia número uno: Hace unos años, Kim y yo estábamos viajando en las montañas, a 
unas horas de distancia de nuestra casa. Habíamos decidido tomarnos unos días de descanso 
y disfrutar la paz y soledad de los bosques. Como siempre hacíamos, nos detuvimos en una 
oficina de bienes raíces y vimos lo  que tenían en venta. La agente nos mostró las 
propiedades sobrevaluadas de siempre que rechazamos. Luego, en su libro de ventas tenía 
una pequeña cabaña maltrecha con seis hectáreas de tierra en lista por sólo 43 000 dólares. 
Le pregunté por qué estaba tan subvaluada.
Su respuesta fue: "Tiene un problema de agua".
"¿Qué clase de problema?", pregunté.
"El pozo no siempre proporciona suficiente agua. Es intermitente. Por eso ha estado en 
venta durante años. A todo el mundo le encanta, pero simplemente no tiene suficiente agua".
"Lléveme a verla", dije.
"Oh, no le va a gustar", contestó. "Pero lo voy a llevar".
Como media hora después, estábamos caminando por ese adorable terreno forestado, con 
una adorable cabaña.
"Éste es el problema", dijo la agente de bienes raíces a medida que nos llevaba hacia el 
pozo. "El pozo y el terreno no tienen suficiente agua".
Asintiendo, dije: "Sí, el problema del agua es serio".
Al día siguiente, regresé a la propiedad con un experto en pozos de la zona. Vimos el pozo y 
dijo: "Este problema se puede resolver fácilmente. El pozo produce suficiente agua, pero lo hace 
en diferentes momentos. Lo único que necesita hacer es agregar  un tanque de depósito 
adicional y el problema estará resuelto".
"¿Cuánto cuesta un tanque de depósito?", pregunté.
"Un tanque de 3 000 galones (11 340 litros) con instalación cuesta 2 300 dólares", dijo.
Asintiendo, volví a la oficina de bienes raíces e hice mi oferta. "Le ofrezco 24 000 dólares al 
dueño por la propiedad".
"Realmente es bajo", dijo. "Aun con un problema de agua".
"Ésa es mi oferta", contesté. "Por cierto, ¿cuándo fue la última vez que se presentó una 
oferta?"
"Hace mucho", dijo. "Creo que hace más de un año".
Esa noche, la agente llamó y dijo. "No puedo creerlo. Su oferta ha sido aceptada. No puedo 
creer que hayan aceptado su precio y sus términos".
"Gracias", fue todo lo que dije.
En mi cabeza y en mi corazón, estaba brincando de emoción. El vendedor no había recibido 
una oferta en más de un año y estaba harto y cansado de hacerle reparaciones a la casa. El 
vendedor había aceptado mi precio, mi pago inicial de tan solo 2 000 dólares y los términos 
de pagarle el balance en un año. En otras palabras, conseguí la propiedad por un pequeño 
pago inicial y sin pagar nada durante un año.
A la mañana siguiente, me reuní con el experto en pozos y le pedí que instalara el tanque de 3 
000 galones. El problema del agua se solucionó por menos de 5 000 dólares. Un mes 
después, Kim y yo fuimos a quedarnos en nuestra nueva cabaña, con mucha agua fresca. 
Cuando dejamos el pueblo, pusimos en venta la propiedad. La pusimos por 66 000 dólares y 
se vendió dos semanas después. El problema se resolvió y la propiedad está en manos de 
una joven pareja que ahora tiene la casa de sus sueños en las montañas.
Un cambio de contexto
Historia número dos: Tengo un amigo, Jeff, que es arquitecto de paisaje. Él me contó una 
excelente historia de inversión que compartiré contigo.
Jeff dijo: "Hace como un año, una mujer me llamó y dijo: 'Tengo 16 hectáreas de terreno y 
quiero que usted vaya a verlas'. Había comprado ese terreno por 275 000 dólares en una 
opción. El pueblo donde se encontraba el terreno estaba en contra de cualquier tipo de 
desarrollo".
"¿Por qué te llamó?", pregunté.
"Quería que dibujara una visión del futuro, para el pueblo y para toda la propiedad. También 
había contratado a un antiguo especialista en planeación urbana para que fuera parte del equipo".
"¿Entonces qué pasó?", pregunté.
"Bueno, hicimos todos nuestros dibujos, escribimos nuestra propuesta para el futuro y 
fuimos al consejo municipal. Nos rechazaron tres veces", dijo.
"¿Por qué?", pregunté.
"El consejo municipal estaba preocupado y no dejaba de pedirnos que revisáramos nuestros 
dibujos y nuestra propuesta".
"¿Seguían pidiéndote cosas?"
"Más o menos. En realidad, nosotros seguíamos preguntando por sus preocupaciones y 
seguíamos regresando con planes y dibujos que atendían a sus preocupaciones. Al final, el 
consejo aprobó nuestro plan y rezonificaron la propiedad de agrícola a comercial".
"¿Rezonificaron su propiedad?", dije. "¿De agrícola a comercial? ¿Cuánto aumento el valor 
de la propiedad ese cambio?", pregunté.
"Después de que los planes de la señora se aprobaron, vendió la propiedad a una compañía 
de seguros por 6.5 millones de dólares. Van a poner un hotel grande en la propiedad".
"¿Cuánto tiempo tomó el proceso?", pregunté.
"Un total de nueve meses", dijo Jeff. "Al especialista en planeación urbana y a mí nos pagó 
25 000 dólares a cada uno como habíamos acordado".
"Así que gastó 50 000 dólares y ganó casi seis millones de dólares?", dije atónito.
Mi amigo Jeff sonrió y asintió con la cabeza. "Esa propiedad había estado parada por años. 
Todo el mundo la veía y decía que era demasiado costosa. Pero ella pudo ver lo que 
nosotros no pudimos y, profesionalmente, fue por ahí mostrándonos a todos lo que estaba 
justo enfrente de la nariz".
"¿Estás molesto por haber ganado sólo 25 000 dólares?", pregunté.
"No. Fue una ganancia justa por el trabajo que invertí. Además, yo acepté esa cantidad y ella 
corrió el riesgo. Si no hubiéramos logrado rezonificar la propiedad, ella habría perdido 
dinero. Pero por lo que estaré eternamente agradecido es por el hecho de que ella me dio 
visión. Me enseñó a ver lo que yo nunca habría podido ver. Me enseñó a ver la abundancia 
que está parada enfrente de todos y cada uno de nosotros, si tan sólo invirtiéramos el tiempo 
para entrenar a nuestro cerebro y a nuestros ojos para verla".
"Felicitándolo por su nueva realidad, dije: "¿Ganaste" algo mucho más valioso que tu pago 
de 25 000 dólares, ¿verdad?"
Asintiendo, Jeff dijo: "Algo mucho más valioso. El especialista en planeación urbana se 
siente estafado, pero yo no. Siempre te he escuchado hablar sobre la realidad y el contexto de 
tu padre rico pero esas palabras nunca tuvieron mucho sentido para mí. Ahora sí lo tienen. 
Me di cuenta de que, desde mi contexto, pensaba en términos de miles de dólares. Me di 
cuenta de que ella es más rica porque su contexto es mayor y piensa en términos de millones. 
También me di cuenta de que yo sigo pensando desde el cuadrante A y ella piensa desde los 
cuadrantes D e I. Aunque no me hubiera pagado nada, lo que aprendí es invaluable porque 
cambió mi vida para siempre. Ella me enseñó como ser un hombre rico".
Rezonificar una propiedad de bienes raíces es simplemente un cambio de contexto. La 
transición de pobre a rico también es simplemente un cambio de contexto. Todo el mundo 
puede hacerlo, si eso quiere.
Dónde guardar tu dinero
De adolescente, Dolf DeRoos hizo un completo estudio sobre las personas ricas. A la edad de 
diecisiete años, su investigación encontró que la mayoría de las personas ricas o hacían dinero 
en los bienes raíces, o tenían gran parte de su riqueza en bienes raíces, después de haberla 
hecho. Lo mismo pasó con mi padre rico. Aunque ganó mucho dinero en sus negocios y 
jugando en la bolsa, en los bienes raíces fue donde estacionó su riqueza. Hay muchas razones 
por las que los ricos hacen eso:
1.Las leyes fiscales animan a los ricos a invertir en bienes raíces.
2.Hay gran apalancamiento en los bienes raíces. Una persona rica se puede hacer todavía más rica 
invirtiendo con el dinero de su banquero.
3.El ingreso de los bienes raíces es ingreso pasivo, el ingreso al que se le cobran menos impuestos de 
todos. Si hay ganancias en bienes de capital por la venta de una propiedad, éstas se pueden diferir por 
años, permitiendo que el inversionista reinvierta con lo que debió haber sido dinero del gobierno.
4.Los bienes raíces le dan al inversionista mucho más control directo sobre sus activos.
5.Es un lugar mucho más seguro donde estacionar dinero, una vez más si el inversionista sabe cómo 
administrar dinero y propiedades.
El inversionista promedio está en tremendo riesgo manteniendo el grueso de su dinero en 
activos en papel. Como se ha afirmado a lo largo de todo este libro, ¿qué sucede si el portafo-lio de activos en papel de un retirado desaparece en una caída de la bolsa? ¿Todo está 
perdido? La respuesta es no, no si la persona sabe cómo proteger sus activos en papel de una 
pérdida en un mercado bajista. Sin embargo, si solamente quieres mantener tu riqueza en 
activos en papel, los siguientes capítulos son muy importantes.
CAPÍTULO 17
El apalancamiento de los activos en 
documentos
Cómo invertir con menos riesgo y más ganancias
Hace unos meses, un amigo mío me contó que había perdido más de un millón de dólares en 
la bolsa. Ahora tiene que volver a trabajar. Cuando le pregunté por qué perdió tanto, dijo: "¿Qué 
más podía hacer? Hice lo que me aconsejaron mis asesores, que fue 'compra las caídas 
temporales'. Así que eso hice y sigo perdiendo. Ahora que he perdido más de un millón de 
dólares, esos mismos asesores me están diciendo que no me mueva y que invierta a largo plazo. 
No me quedan muchos meses para esperar".
Invertir no tiene que ser arriesgado. Como decía mi padre rico: "Aunque hay riesgo, invertir 
no tiene que ser arriesgado". Tampoco tienes que perder si la bolsa cambia de dirección. De 
hecho, si la bolsa comienza a bajar, muchos inversionistas sofisticados ganan mucho dinero. 
Las siguientes son las lecciones de mi padre rico sobre cómo invertir en la bolsa y hacer dinero, 
sin importar si ésta sube o baja.
Mantén un contexto abierto
Es en esta sección del libro donde es importante tener una mente abierta y un contexto flexible, Si 
escuchas que tu contexto  te dice: "Eso es imposible" o "no puedes hacer eso" o "eso es ilegal" 
o "eso es demasiado arriesgado" o "me resultaría muy difícil aprender eso", simplemente 
recuérdate a ti mismo que debes mantener tu contexto abierto para escuchar el contenido 
que se está transmitiendo.
Invirtiendo con seguros en activos en documentos
"¿Conducirías un auto sin seguro?", me preguntó mi padre rico.
"No", contesté. "Seria tonto. ¿Por qué me haces esa pregunta?"
Mi padre rico sonrió y preguntó: "¿Invertirías sin seguro?"
"No", contesté. "Pero estoy invirtiendo en bienes raíces. Siempre aseguro mis propiedades 
de las pérdidas. De hecho, el banco requiere que tenga seguro en todas las propiedades que 
poseo".
"Buena respuesta", contestó mi padre rico.
"¿Por qué me estás haciendo esas preguntas sobre seguros?", pregunté de nuevo.
"Porque es momento de que aprendas cómo invertir en activos en documentos. Activos como 
acciones, bonos y fondos de inversión".
"¿Puedes invertir con seguro en activos en documentos?", pregunté. "¿Quieres decir que 
puedes asegurarte contra las pérdidas o minimizarlas?"
Mi padre rico asintió.
"¿Así que invertir en activos en papel no tiene que ser arriesgado?", pregunté.
"No tiene por qué serlo", dijo mi padre rico. "Invertir no tiene que ser arriesgado en lo absoluto, 
si sabes lo que estás haciendo".
"¿Pero que no invertir es arriesgado para el inversionista promedio en activos en 
documentos?", pregunté. "¿Qué no el inversionista promedio está invirtiendo sin seguro?"
Mi padre rico asintió de nuevo, mirándome a los ojos y dijo: "Por eso te estoy enseñando esto. 
No quiero que seas el inversionista promedio. El inversionista promedio está interesado en los 
promedios, razón por la cual él mismo es promedio. Por eso es que hay un Promedio 
Industrial Dow Jones. Los promedios son para personas promedio. Por eso hay tantas personas 
que escuchan a su asesor financiero y se emocionan cuando éste dice: La bolsa ha promediado 
un porcentaje de ganancia de doce por ciento durante 40 años. O Este fondo de inversión ha 
promediado un porcentaje de ganancias de dieciséis por ciento en los últimos cinco años. Los 
inversionistas promedio piensan en promedios".
"¿Qué hay de malo en los promedios?", pregunté.
"Nada realmente", dijo mi padre rico. "Pero si quieres ser rico, necesitas ser mucho mejor 
que el promedio".
"¿Entonces por qué los promedios te impiden ser rico?", pregunté.
"Porque los promedios son la suma de ganancias y pérdidas", dijo mi padre rico. "Por 
ejemplo, aunque es cierto que la bolsa ha subido en promedio durante los últimos 40 años, 
en realidad, ha subido y bajado".
"¿Y qué?", dije. "¿Que eso no lo sabe la mayoría de la gente?"
"Sí, la mayoría de la gente lo sabe", dijo mi padre rico. "Pero, ¿por qué perder si no tienes que 
hacerlo? Los inversionistas promedio ganan dinero cuando sube la bolsa y pierden cuando 
ésta baja. Ésa es la razón por la que son promedio. ¿Cuáles serían tus promedios si hicieras 
dinero cuando la bolsa sube y cuando baja?"
"Eso sería bueno", contesté. "Pero, ¿qué hacen los inversionistas sofisticados?", pregunté. 
"¿No usan promedios?"
"Sí, usan promedios, pero usan promedios diferentes. El punto que estoy haciendo aquí es que 
el inversionista promedio sólo sabe hacer dinero en una bolsa a la alza y por esa razón se 
siente feliz de escuchar que la bolsa por lo general ha promediado a la alza con los años. El 
inversionista sofisticado no está buscando información promedio. En realidad no le 
preocupan si la bolsa promedia a la alza o a la baja porque gana dinero en cualquier 
condición de la bolsa".
"¿Quieres decir que nunca pierden?", pregunté.
"No. Eso no fue lo que dije. Todos los inversionistas pierden en uno u otro momento. Pero a 
lo que me refiero es a que el inversionista sofisticado es capaz de ganar en una bolsa que 
sube o que baja. El inversionista promedio sólo tiene una estrategia para ganar en una bolsa a 
la alza y recibe una paliza en una bolsa a la baja. A los inversionistas sofisticados no les gusta 
recibir las palizas financieras que recibe el inversionista promedio. El inversionista 
sofisticado no siempre está en lo correcto y es capaz de perder... pero la diferencia, debido a 
su preparación, herramientas y estrategias es que sus pérdidas generalmente son mucho 
menos y sus ganancias mucho mayores que en el caso del inversionista promedio".
En el transcurso de los años, me parecía extraño que las personas invirtieran el dinero 
ganado con mucho esfuerzo, pero que no invirtieran mucho tiempo en aprender cómo 
invertir. Después de todos mis años con mi padre rico, nunca pude entender por qué tantas 
personas preferían trabajar duro toda su vida en lugar de aprender a hacer que su dinero 
trabajara por ellas. Y cuando invertían en la bolsa el dinero ganado con mucho esfuerzo, 
estaban dispuestas a arriesgarlo sin ningún seguro que las cubriera de las pérdidas. Pensé en 
mi padre pobre, quien trabajó duro y siempre dijo: "Invertir es arriesgado". Lo decía sin 
hacer nunca una investigación y sin tomar clases sobre inversión. Mi padre rico me enseñó 
cómo invertir de manera segura con los bienes raíces y ahora me estaba enseñando cómo 
invertir de manera segura en activos en documentos.
"¿Así que invertir en la bolsa no tiene que ser arriesgado?", pregunté para que me quedara 
más claro.
"No. Absolutamente no", dijo mi padre rico.
"No obstante millones de personas invierten sin protegerse de la pérdida, sin mucha 
preparación y eso hace que sean inversionistas arriesgados".
"Extremadamente arriesgados", dijo mi padre rico. "Por eso te pregunté si tus inversiones en 
bienes raíces tenían seguro. Sabía que sí porque tu banquero te lo pide. Pero la persona 
promedio en la bolsa carece de seguro. Millones y millones de personas están invirtiendo en 
su futuro retiro sin ningún seguro contra catástrofes. Eso es arriesgado. Muy arriesgado".
"Entonces, ¿por qué no se los dicen los asesores financieros,  corredores de bolsa y 
vendedores de fondos de inversión?", pregunté.
"No lo sé", dijo mi padre rico. "Con frecuencia me lo he preguntado yo mismo. Pienso que la 
razón es porque la mayoría de los asesores financieros, corredores de bolsa y asesores de 
fondos de inversión no son ellos mismos inversionistas realmente, mucho menos inversionistas 
sofisticados. La mayoría de las personas que trabajan en servicios financieros son vendedores 
asalariados o por comisión, que trabajan por un sueldo de la misma manera en que sus clientes 
trabajan por un sueldo".
"Y aconsejan a otras personas, inversionistas promedio", dije. "Personas justo como ellos".
Mi padre rico asintió. "Un inversionista sofisticado puede hacer dinero en una bolsa a la 
alza o a la baja. El inversionista promedio en ocasiones gana dinero en una bolsa a la alza y 
pierde dinero en una bolsa a la baja. Luego, después de perder  mucho dinero, el 
inversionista promedio llama a su asesor y dice: '¿Qué hago ahora?'"
"¿Y qué dice el corredor de bolsa?", pregunté.
"Con frecuencia dice: 'No se mueva, la bolsa regresará en unos meses'. O dicen: 'Compre 
más y saque un promedio de dinero a la baja'".
"Tú no harías eso", dije.
"No", dijo mi padre rico. "Yo no haría eso. Pero el inversionista promedio lo hace".
"Me estás diciendo que puedo invertir con menos riesgo y ganar más dinero en la bolsa".
"Así es", dijo mi padre rico. "Lo único que tienes que hacer es no ser un inversionista 
promedio".
Palabras que te hacen rico
En el libro número cuatro, Guía para invertir de Padre Rico, escribí que la clase media y la 
pobre invertía en fondos de inversión. Luego escribí que los ricos preferían los fondos de 
resguardo. De nuevo, el poder de las palabras entra en juego. La misma palabra resguardo es 
una palabra importante para el inversionista sofisticado y hay un mundo de diferencia entre un 
fondo de inversión y un fondo de resguardo. La mayoría hemos escuchado el término 
"resguardar nuestras apuestas". El término resguardar en este contexto es otra forma de decir 
seguro. Así como un jardinero puede poner un resguardo para proteger su jardín de los 
animales que pastan, un inversionista sofisticado pondrá un resguardo para proteger sus 
activos.
Dicho simplemente, la palabra resguardo en este contexto significa protección de la 
pérdida. Así como no conducirías o no deberías conducir un auto sin seguro, tú como 
inversionista no deberías invertir sin seguro o sin un resguardo contra la  pérdida 
catastrófica. Por mucho sentido común que tenga esto, el inversionista promedio invierte al 
descubierto,  que es otro término empleado por los  inversionistas sofisticados.  Al 
descubierto en este término no se refiere al cuerpo humano, se refiere a un activo que se 
expone sin alguna forma de protección por las pérdidas. A un inversionista sofisticado no le 
gusta invertir al descubierto, lo que significa estar expuesto a un riesgo innecesario. Un 
inversionista sofisticado invertirá con sus posiciones financieras cubiertas. Así como un 
vendedor de seguros preguntaría: "¿Está usted cubierto?"... los inversionistas sofisticados 
también se harán la misma pregunta. En general, el inversionista promedio y el 
inversionista en fondos de inversión lo hacen al descubierto porque no están cubiertos 
contra las pérdidas.
No proteger tus activos es arriesgado
Hace unos días, fui uno de los principales oradores en una conferencia para inversionistas. La 
oradora principal era una personalidad muy importante de la televisión, que da las noticias en 
una de las mayores cadenas de televisión financiera. Su charla fue informativa y aprendí 
mucho. No obstante, encontré interesante escucharla decir que ella sólo invierte en fondos de 
inversión.
De pronto, un participante levantó la mano y dijo: "¿No se siente culpable por ser la 
responsable de que sus televidentes hayan perdido miles de millones de dólares en la 
bolsa?" Su tono era molesto y, a medida que hablaba, yo podía sentir que muchos 
inversionistas estaban de acuerdo con él. Parecía que los inversionistas habían asistido a esa 
conferencia no para aprender sobre en qué invertir su dinero, sino para descubrir que había 
pasado con el dinero que habían perdido.
"¿Por qué habría de sentirme culpable?", contestó. "Mi trabajo es darles información y les 
doy mucha información. Yo no les di consejos de inversión. Sólo les di información sobre la 
bolsa. ¿Por qué dice usted que debería sentirme culpable?"
"Porque usted fue una gran animadora durante el auge del mercado alcista", dijo el 
participante enojado. "Por su culpa seguí invirtiendo y ahora lo he perdido todo".
"Yo no estaba animando", dijo ella. "Sólo estaba dando información en un buen mercado, 
justo como ahora estoy dando información en un mal mercado".
Durante los siguientes cinco minutos, el enojo en la sala estalló. Algunas personas estaban de 
acuerdo con el participante enojado y otras se estaban poniendo del lado de la reportera. Al 
final, las cosas se calmaron. La reportera de televisión quiso saber si había más preguntas. 
Una mano se levantó y le preguntó: "¿Por qué no le dijo a su audiencia que debía minimizar 
sus riesgos con opciones?", preguntó. Ese participante no estaba enojado. Sonaba más 
curioso y quería dejarle saber a la audiencia que podían minimizar su exposición al riesgo 
empleando opciones.
"¿Opciones?", dijo ella. "¿Por qué debía decirles sobre las opciones?"
"Como un resguardo contra las pérdidas en un mercado alcista", dijo él.
"Oh, yo nunca haría eso", contestó. "Las opciones son demasiado arriesgadas. ¿Alguna otra 
pregunta?", preguntó, indicando con la mano que la persona que había preguntado sobre las 
opciones debía sentarse.
No podía creer lo que estaba escuchando. Esta personalidad de la televisión es una de las 
personas más respetadas en el periodismo financiero. Ella tiene influencia en la vida de mi-llones de personas. Muchas personas buscan su consejo en materia de inversión y ahora ella 
estaba diciendo: "Las opciones son demasiado arriesgadas". Para mí, no proteger tus activos 
es demasiado arriesgado. Para mí, ser ignorante en cuanto al terreno financiero es 
arriesgado. Saber cómo usar las opciones para proteger tus activos en papel es fácil y no es 
tan difícil de hacer. De hecho, si tienes a un buen corredor de bolsa, el proceso es muy 
simple. Hasta un niño podría hacerlo. Lo único que tienes que hacer es aprender las 
definiciones de unas cuantas palabras nuevas, encontrar un buen corredor y comenzar con 
poco para obtener un poco de experiencia. En cambio, yo vi como asentían muchas de las 
miles de personas que había en la sala, aceptando que invertir con opciones era arriesgado.
Mientras estaba sentado ahí, observando cómo sus fieles seguidores asentían de acuerdo con 
su idea de que las opciones son arriesgadas, mi mente volvió a las primeras lecciones de mi 
padre rico sobre la inversión en activos en documentos. Podía escucharlo diciendo: "Hace 
cientos de años, en el Japón antiguo, los granjeros japoneses comenzaron a usar las opciones 
para proteger el precio de sus cosechas de arroz".
"¿Hace cientos de años?", pregunté. "¿Hace cientos de años estaban usando las opciones 
como resguardos contra las pérdidas?"
Mi padre rico asintió: "Sí, hace cientos de años. Comenzando en la Era Agraria, los 
negociantes inteligentes han estado usando opciones para proteger de las pérdidas sus 
negocios. Los pequeños negociantes lo siguen haciendo hoy en día".
Mi mente regresó a la sala de Chicago donde estaba hablando esa periodista de televisión. Me 
pregunté para mis adentros: "Si los negociantes inteligentes han estado usando las opciones 
durante años, ¿por qué esta persona muy influyente está informando mal a sus televidentes?" 
Luego me pregunté: "¿Qué es más arriesgado? Comprar una acción o fondo de inversión y 
verlo caer 40 a 60 por ciento, hasta a 90 por ciento de valor y no protegerte? Mi banquero me 
pide que tenga un seguro en mis bienes raíces. ¿Por qué la industria de los activos en 
documentos  no pide a todos  los  inversionistas  que compren un seguro para sus 
documentos... activos con los que millones de personas están contando para su vejez?" 
Hasta la fecha, no tengo una respuesta para esas preguntas. Como se dijo antes, si tu casa se 
quema, puede ser reemplazada en menos de un año y pagada por tu compañía de seguros. 
Pero si tu plan de retiro se viene abajo con la bolsa después de que te hayas retirado, ¿qué 
harás entonces? ¿Comprar, mantener y rezar de nuevo? ¿Esperar que haya otro mercado 
alcista? Así que yo sigo preguntándome por qué los banqueros piden a los inversionistas 
que inviertan con seguro y, no obstante, la industria de los activos en documentos no lo hace. 
Sigo preguntándome por qué los inversionistas profesionales invierten con seguros y, sin 
embargo, el inversionista promedio, el inversionista que cuenta con la bolsa para su 
seguridad financiera cuando terminen sus días como trabajador, invierte desnudo y sin estar 
cubierto?
Vocabulario de seguros
Si quieres retirarte joven y rico, es importante que inviertas algo de tiempo aprendiendo cómo 
proteger tus activos, en especial si planeas mantener tu riqueza en activos en documentos. Eso 
lo haces aprendiendo y comprendiendo lo que mi padre rico llamaba "el lenguaje del 
inversionista sofisticado". En mis seminarios de inversión, yo lo llamo el vocabulario de los 
seguros.
Antes de entrar en esas palabras, creo que es importante revisar otras palabras. A 
continuación hay otras palabras que necesitan ser definidas antes de entrar en las palabras 
de los seguros:
1. Inversionista vs. comerciante: La mayoría de las personas que piensan que son inversionistas en 
realidad son comerciantes. Así como la mayoría de las personas piensan que sus pasivos son 
activos, muchos inversionistas son comerciantes en lugar de inversionistas. Un punto más. Muchas 
personas que piensan que son inversionistas en realidad son ahorradoras. Por esa razón la mayoría 
de las personas que tienen planes de retiro 401(k) o IRA, planes Keogh, con frecuencia dicen: "Estoy 
ahorrando para mi retiro". Un ahorrador simplemente pone dinero en una cuenta y no hace nada más. 
Un inversionista es una persona que maneja su portafolio o cuenta de manera activa.
¿Así que cuál es la diferencia entre un inversionista y un comerciante? Un inversionista compra 
para conservar y un comerciante compra para vender. Cuando una persona dice: "Compré esta 
acción o propiedad de bienes raíces porque sé que el precio está subiendo", yo sé que esa 
persona en realidad es un comerciante... en otras palabras, están comprando sólo para comerciar, 
no para usar. Por esa razón digo que la mayoría de las personas son comerciantes más que 
inversionistas. Un comerciante por lo general quiere que el precio de su activo suba para 
venderlo por una ganancia. Un inversionista quiere que la inversión le devuelva su dinero lo más 
rápido posible, al tiempo que conserva el activo. Mi padre rico decía: "Un inversionista compra 
una vaca para tener leche y vaquillas. Un comerciante compra una vaca para matarla".
Si quieres tener éxito en el mundo de la inversión, sin importar si es en activos en documentos, en 
negocios o en bienes raíces, necesitas ser tanto inversionista como comerciante. Un inversionista 
sabe qué analizar y cómo administrar inversiones y un comerciante sabe cómo y cuándo vender y 
comprar. Un inversionista por lo general quiere flujo de efectivo de un activo y el comerciante quiere 
obtener una ganancia en bienes de capital por comprar bajo y vender alto.
2. Inversionista fundamental vs. inversionista técnico: Un inversionista fundamental mira el 
estado financiero de una empresa o propiedad. A menudo está preocupado por las ganancias, 
el equipo de administración y el potencial que tiene el negocio a largo plazo. Un 
inversionista puramente técnico no se preocupa por los fundamentos de la empresa. Ni 
siquiera se preocupa por si la empresa es rentable o si está bien dirigida. El inversionista 
técnico sólo se preocupa por el sentimiento del mercado en ese momento. Mientras un 
inversionista fundamental mira estados financieros, un inversionista técnico más bien vería 
las gráficas históricas que reflejan el sentimiento del mercado. Más adelante en este capítulo 
habrá algunas gráficas para que las veas.
Un inversionista técnico puede ser bueno y perder dinero simplemente porque carece de los 
fundamentos adecuados. Muchos "comerciantes de día" finalmente pierden o quedan en la 
ruina porque tienen fundamentos de administración de dinero personal pobres. Lo mismo es 
cierto en el caso de los inversionistas fundamentales. Muchos inversionistas fundamentales 
se preguntan por qué no hacen dinero, o pierden dinero, aunque están invirtiendo con 
buenos fundamentos porque carecen del conocimiento del comercio técnico.
Esta realidad es la razón por la que mi padre rico quería que su hijo y yo fuéramos 
inversionistas calificados o sofisticados, inversionistas con buenas habilidades fundamenta-les y buenas habilidades técnicas.
3.Inversionista promedio vs. inversionista sofisticado: El inversionista promedio apenas 
sabe lo que es un estado financiero. Se encuentra mejor invirtiendo a largo plazo, 
diversiempeorando su portafolio, invirtiendo en fondos de inversión y luego comprando, 
manteniendo y rezando.
El inversionista sofisticado es alguien que tiene dinero y entiende las técnicas de inversión 
fundamentales al igual que las técnicas de comercio técnico.
Palabras que te ayudan a ganar en cualquier mercado
Si quieres retirarte joven y rico, protegerte o asegurar tus activos de una pérdida 
catastrófica es vital. El inversionista promedio en documentos nunca se siente seguro. Por 
eso el inversionista promedio siente que invertir es arriesgado y, para ellos, lo es. Como se 
sienten inseguros, le confían su dinero al administrador de un fondo o a su hermano, que es 
corredor de bolsa, o a un especialista en planeación financiera, esperando y rezando para 
que esa persona los proteja de los desastres del mercado. El problema es que el 
administrador promedio de un fondo de inversión o el corredor de bolsa promedio no puede 
protegerlos de una caída ni puede ayudarlos a hacer dinero en un mercado plano que se está 
moviendo hacia los lados.
La forma de ganar y proteger tus activos en cualquier mercado es aprender y entender 
realmente el vocabulario del inversionista técnico y fundamental, en especial en los activos 
en documentos. Es fácil de hacer si inviertes un poco de tiempo. De la misma forma en que 
un banquero te pedirá ver tu estado de cuentas antes de darte un préstamo, lo que es 
fundamental, y te exigirá tener una propiedad, título y seguro de hipoteca para una 
inversión en bienes raíces, lo que es asegurar el riesgo técnico o catastrófico, tú deberías 
exigirte lo mismo si quieres invertir en activos en papel. La forma en que haces eso es 
empezar a entender las palabras de los seguros al invertir en activos en papel. Algunas de 
ellas son:
1.Tendencias
2.Promedios móviles
3.Órdenes de suspensión
4.Opciones de compra de valores
5.Opciones de venta de acciones
6.Opciones combinadas de compra y venta
7.Reducciones
8.Y muchas más
El inversionista promedio puede haber escuchado algunos de esos términos  pero 
probablemente no los entiende o nunca los ha usado. Muchos inversionistas promedio 
simplemente descartan esas palabras tan importantes diciendo: "Es demasiado arriesgado". 
Decir que algo es arriesgado también puede significar: "Simplemente soy demasiado flojo 
como para estudiar el tema".
Lo que debes saber
Si quieres retener tu riqueza en activos en documentos, debes saber cómo asegurar éstos 
contra caídas del mercado. Lo siguiente es una muestra de lo que debes saber. Una vez más, 
comienza con las palabras.
Tendencias
Todo inversionista sofisticado debe entender las tendencias. Hay un dicho que todos los 
inversionistas sofisticados dicen y es: "La tendencia es tu amiga". Por favor recuerda y usa 
ese dicho. ¿Entonces qué es una tendencia? La mejor forma de explicarlo es contándote una 
historia. Cuando era adolescente, creciendo en Hawai, la mayoría de mis amigos estaban 
entrenando para ser surfistas de grandes olas. Todos los inviernos, cuando venían las olas del 
norte, entrábamos en el agua para demostrar nuestro valor y mejorar nuestras habilidades. Un 
año, llegó un nuevo estudiante del territorio continental. Era bastante buen surfista en las 
pequeñas olas de verano. Cuando llegó el invierno, se aventuró a entrar en el agua pensando 
que nada había cambiado, excepto la altura de las olas. En su primera incursión en una ola 
grande, perdió el control y terminó al final de la ola. La enorme ola se curveó sobre él y no lo 
vimos por mucho tiempo. Finalmente, salió a un poco de distancia de nosotros, tosiendo y 
nadando lo más fuerte que pudo. Quienes estábamos surfeando con él no podíamos creer lo 
que veíamos. No podíamos creer que estaba nadando contra la corriente. Uno de nosotros 
finalmente dijo: "Oh no. No puedo creer que esté tratando de nadar contra la corriente. 
Nadie es un nadador tan fuerte".
Cuando las olas grandes llegan a la orilla, toda esa agua debe encontrar una forma de regresar 
al mar. Es ese movimiento de agua fuera del mar el que causa una corriente de resaca. Es 
como un río de agua que se mueve paralelo a la playa y luego hacia el mar. Los que 
habíamos crecido en las islas, sabíamos relajarnos simplemente y dejar que la corriente nos 
llevara a aguas más profundas. Una vez que la corriente se ha disipado, sabemos que 
simplemente hay que nadar o surfear con el cuerpo a través de un canal más seguro. Este 
nuevo amigo no sabía lo poderosa que podía ser una corriente de resaca. En lugar de irse con 
la corriente, trató de luchar contra ella, se agotó y casi se ahogó. Lo mismo sucede con los 
nuevos inversionistas.
Los ciclos de inversión vienen en olas, como las del océano. También cambian con las 
estaciones. Los surfistas aprenden a respetar el cambio en la potencia de las olas y el agua 
con cada cambio de estación. Los inversionistas sofisticados hacen lo mismo. Por esa razón 
los inversionistas sofisticados dicen: "La tendencia es tu amiga". Así como los inversionistas 
sofisticados aprenden a no luchar contra las olas o las corrientes, los inversionistas 
sofisticados van con las tendencias, cambiando de estrategias cuando es apropiado o 
manteniéndose de lado si las cosas son demasiado agitadas. Los inversionistas promedio 
siguen comprando y manteniendo, comprando a la baja o llamando a sus corredores para 
preguntarles: "Éste es el fondo?", a medida que los golpean con violencia.
Tres tendencias básicas
Hay tres tendencias básicas que afectan a los activos en documentos así como a todos los 
demás productos de inversión. Una es un mercado que tiende a subir, a menudo llamado 
mercado alcista. La segunda es un mercado que se dirige hacia abajo y se denomina 
mercado bajista. La tercera tendencia es un mercado que avanza hacia los lados, es decir, 
un mercado que no está ni subiendo ni bajando. El inversionista sofisticado utiliza diferentes 
estrategias para las diferentes tendencias. El inversionista promedio sólo tiene una estrategia 
y trata de usarla en las tres tendencias. Ésa es la razón por la que finalmente pierde. La idea 
de invertir a largo plazo es básicamente una buena idea, pero invertir a largo plazo con tan 
sólo una estrategia es la forma de invertir de un perdedor.
Hasta los animales son conscientes de los cambios de estaciones. Cuando llegan los 
primeros fríos del invierno con el otoño, la mayoría de los animales saben que necesitan 
prepararse para el cambio que trae consigo el invierno. Lo mismo es cierto para los 
inversionistas sofisticados. El inversionista promedio es el único que cree en las palabras de 
sus asesores financieros: "Invierte a largo plazo. Compra y conserva aunque el mercado 
baje". Si los animales son lo bastante listos como para saber que las cosas cambian, ¿por 
qué los seres humanos no?
Promedios móviles
Las tendencias son ocasionadas por compradores y vendedores. Si hay más compradores, 
entonces la tendencia es a la alza. Si hay más vendedores, entonces la tendencia es a la baja. 
Un inversionista promedio se siente cómodo cuando su asesor financiero le dice: "La bolsa 
ha subido durante los últimos 40 años". El inversionista sofisticado no está observando un 
promedio a largo plazo, sino un promedio móvil. De la misma manera en que un surfista 
observa el levantamiento y la caída diarios de las mareas, el inversionista sofisticado 
observa la mengua y el flujo de dinero dentro y fuera del mercado. El inversionista 
sofisticado observa esas gráficas porque le dicen cuándo cambiar de estrategia.
El diagrama de abajo es una gráfica de un promedio móvil.  Como se dijo antes, los 
inversionistas fundamentales ven estados financieros y equipos de administración, un 
inversionista técnico ve gráficas y el diagrama siguiente es una de las gráficas que ven.

¿Cómo sabes si la tendencia está cambiando?
¿El mercado te da señales de que está a punto de cambiar? La respuesta es sí. No es una 
ciencia exacta, pero con toda seguridad es mejor que andar adivinando, guiarse por 
corazonadas e invertir con base en tips de moda.
La mayoría de nosotros sabe que un meteorólogo puede predecir un huracán. Aunque 
predecir el clima no es una ciencia exacta, no obstante hoy en día nos dan una amplia 
advertencia si se acerca una gran tormenta. Un comerciante técnico puede hacer casi lo 
mismo. Eso significa que mientras el inversionista promedio está conservando y rezando 
para que el mercado se mantenga arriba, los inversionistas profesionales están vendiendo 
antes de que azotara la tormenta.
Hay muchas señales que busca el comerciante técnico. Las siguientes gráficas muestran uno 
de los patrones reveladores que observa el comerciante técnico.
Los comerciantes técnicos llaman a esta gráfica patrón de doble techo. Cuando los 
inversionistas técnicos ven este patrón se vuelven cautelosos y comienzan a cambiar de 
estrategias de inversión o salen del mercado por completo. Si ves, el precio de la acción se 
fue hacia abajo justo después de un doble techo.
Un patrón similar se presenta en el fondo del mercado. Este patrón se llama doble fondo. 
Cuando los inversionistas técnicos ven que emerge este patrón, de nuevo cambian de estrate-gias o comienzan a comprar acciones mientras los inversionistas promedio han perdido toda 
esperanza y están vendiendo.
Hay muchos tipos diferentes de patrones que los inversionistas técnicos buscan. Estos 
patrones no son absolutos ni garantías. No obstante, sí le dan al inversionista sofisticado una 
ventaja significativa sobre el inversionista promedio, quien no tiene idea de estas señales. 
Una gran ventaja que tiene un inversionista técnico es que tiene el tiempo para proteger los 
precios de sus activos mediante un seguro. El inversionista promedio se queda parado ahí 
completamente expuesto, sin seguro ni protección. Millones de inversionistas tienen su 
futuro financiero en nesgo, esperando y rezando para que el consejo de su asesor financiero 
lo proteja de las tormentas que regresan regularmente a cualquier mercado financiero.
Cada vez que escucho a los supuestos expertos que advierten: "Invierte a largo plazo. No 
entres en pánico. Simplemente no hagas nada. Siempre recuerda que la bolsa en promedio 
ha subido durante los últimos 40 años", me estremezco. Cuando escucho a los expertos que 
dicen esas palabras, agito la cabeza y me siento mal por esos millones de personas que 
escuchan a tales expertos y les confían su futuro financiero. Invertir no tiene que ser 
arriesgado, si sabes lo que estás haciendo.
Las herramientas del inversionista sofisticado
El inversionista promedio sólo tiene dos elecciones en un mercado que cambia de dirección. 
Puede conservar sus activos y perder o vender y perder. El otro día, escuché que un asesor de 
inversiones respetado decía: "En febrero de 2000 les dije que vendieran todo lo que 
tuvieran". Es probable que ése haya sido un buen consejo para el inversionista promedio, 
pero el inversionista sofisticado tiene otras elecciones además de comprar y perder o vender 
y perder.
A continuación están algunas de las herramientas mentales que usan los inversionistas 
sofisticados con el fin de proteger sus activos y hacer dinero en mercados que suben y bajan. 
Son herramientas que los ayudarán a hacer dinero y que protegerán su dinero cuando el 
mercado vaya hacia abajo.
Ordenes de suspensión
Un inversionista sofisticado puede llamar a su corredor y pedirle una orden de suspensión si 
sospecha que el precio de su acción puede bajar, en especial si la tendencia del mercado es a 
la baja. El inversionista promedio no hace nada y si el precio de su acción baja, 
simplemente lo mira bajar. Sin saber qué hacer, su estrategia de compra, conserva y reza se 
convierte en una estrategia de compra, conserva y pierde.
Así es como funciona una orden de suspensión. Digamos que tu acción está en 50 dólares hoy y 
las gráficas te indican que el mercado está tendiendo a bajar. Lo único que tienes que hacer es 
llamar a tu corredor y poner una orden de suspensión, digamos en 48 dólares. Si el precio de la 
acción comienza a bajar, digamos a 30 dólares porque más vendedores han entrado al mercado, 
tu orden de suspensión se convierte en una orden bursátil y la acción se vende en 48 dólares y tus 
pérdidas se limitan a dos dólares. El inversionista promedio perdería dieciocho dólares y 
seguiría aferrándose a la acción.
Aunque las órdenes de suspensión con frecuencia se usan como "seguros" para los 
inversionistas, no siempre las usan inversionistas muy sofisticados. Con frecuencia los 
precios de las acciones tienden a tener una brecha en la transacción de apertura y los 
inversionistas sofisticados ya tienen la noticia y han decidido si venden sus acciones o 
cancelan la orden de suspensión límite. Las siguientes son dos razones por las cuales las ór-denes de suspensión pueden no tener éxito y fracasar en un mercado volátil.
La primera razón por la que un inversionista profesional puede no usar una orden de 
suspensión es porque la tendencia se está dirigiendo hacia abajo demasiado rápido. A veces 
en un mercado que está cayendo muy rápido, la orden de suspensión puede pasar sin ser 
ejecutada. Por ejemplo, digamos que el precio de la acción es de 50 dólares. Como la 
tendencia es a la baja, el inversionista pone una orden de suspensión en 48 dólares. Eso 
significa que si el precio baja a 48 dólares, la acción se vende automáticamente. Sin embargo, 
si el mercado bajara rápidamente, es posible que el precio de 48 dólares se encuentre dentro 
de una "brecha" o se salte. Eso significa que hay tantas personas vendiendo que no hay 
compradores a 48 dólares, de modo que la suspensión se pasa o queda en una brecha. Si el 
precio se detiene en 40 dólares porque unos cuantos compradores dieron un paso adelante, 
lo mejor que puede hacer el inversionista es esperar en 40 dólares o vender a 40 dólares. Su 
suspensión fue rebasada.
Otra razón por la que un inversionista profesional puede no usar una suspensión es porque 
no está seguro de la tendencia del mercado. Por ejemplo, otra vez la acción está en 50 
dólares y se fija una suspensión en 48 dólares. Como se esperaba, la acción baja a 47 
dólares, la acción se vende a 48 dólares. El inversionista se siente aliviado hasta que se da 
cuenta de que la bolsa repentinamente ha subido y el precio de su acción ahora es de 65 
dólares. No sólo ha perdido dos dólares por cada acción, sino que ha perdido diecisiete 
dólares en un movimiento hacia arriba.
Amasando una fortuna o quedando amasado
Con frecuencia hemos escuchado a alguien decir: "Estoy amasando una fortuna en la bolsa". 
Durante el auge de las compañías punto com, hubo muchas personas que entraron en la 
manía con la idea de amasar una fortuna y, en cambio, ellas fueron quienes quedaron 
amasadas. En las noticias actuales, muchas personas se ríen de la manía punto com, diciendo: 
"¿Cómo pudo ser tan tonta la gente?" Lo que muchas personas no escuchan es sobre las 
personas que sí amasaron una fortuna en el camino hacia arriba y en el camino hacia abajo.
Un amigo mío ganó muchísimo dinero comprando a comienzos del furor de la oferta pública 
inicial de empresas punto com. Amasó una fortuna, como dicen. También amasó una fortuna 
en el camino hacia abajo. Justo antes de la cima, a finales de 1999, vendió todas las acciones 
de punto com que tenía. Luego conforme se acercó la cima, comenzó a reducir (se explica más 
adelante) de manera selectiva algunas de las acciones de las mismas compañías punto com 
que lo habían hecho rico en el camino hacia arriba. Tres de esas compañías cayeron tanto 
que se fueron a la bancarrota. Así que hizo una fortuna en el camino hacia arriba y una fortuna 
aún mayor en el camino hacia abajo. ¿Por qué? La razón por la que ganó más dinero en el 
camino hacia abajo es porque no usó nada de su propio dinero y no ha pagado impuestos por 
el dinero que consiguió al reducir las acciones de compañías que se fueron a la bancarrota.
Cuando le pregunté por qué, me dijo: "Reduje acciones en la cima, lo que significa que las pedí 
prestadas. Luego las compañías se fueron hacia abajo y quebraron. Aún no tengo que pagar im-puestos porque no ha habido transacción de cierre, así que no debo ningún impuesto. Lo único que 
hice fue vender acciones que no poseía o pedí prestadas y ahora espero el momento en que 
pueda volverlas a comprar y devolvérselas a la persona de quien las tomé prestadas". Hoy, tiene 
casi 875 000 dólares en dinero que hizo reduciendo unas cuantas acciones, sentado en un fondo 
de bonos municipales libre de impuestos, reuniendo interés libre de impuestos. Interés por 
dinero que recibió vendiendo acciones que no poseía. Él dice: "Estoy esperando la 
oportunidad de volver a comprar esas acciones, pero hasta entonces junto los intereses sobre 
dinero de ganancias en bienes de capital".
Si no entiendes esta transacción, no te preocupes. La mayoría de las personas no la 
entienden. Si te gustaría entenderla mejor, contacta a un corredor de bolsa o a tu contador y 
pregúntale si te la puede explicar mejor.
El punto es que si quieres amasar una fortuna en el camino hacia arriba también necesitas 
saber cómo amasar una fortuna  en el camino hacia abajo. Si no, entonces con frecuencia tú 
eres el que queda amasado por las personas que están amasando una fortuna.
Hay mucho más que aprender sobre el uso de herramientas profesionales para hacer 
transacciones como las suspensiones. También se necesita mucho más para invertir con 
estas herramientas que simplemente pedirle a tu corredor que ponga una suspensión de 
venta o de compra, que es una suspensión en otra dirección. Los inversionistas sofisticados 
necesitan tener muchas herramientas más que los inversionistas promedio. Si no es así, ellos 
también terminarán amasados mientras sus compañeros estén amasando una fortuna.
Esta desventaja injusta que tienen los inversionistas sofisticados es la razón por la que me 
preguntan: "¿Qué consejo le daría usted al inversionista promedio?" Mi respuesta es: "No 
seas promedio". Lo digo porque tu futuro financiero y tu seguridad financiera son demasiado 
importantes para sólo ser promedio.
Unas palabras de advertencia: Éste no es un libro sobre comercio técnico. El ejemplo anterior 
sobre una suspensión es una explicación muy simple. Un inversionista sofisticado sabe cómo y 
cuándo usar una suspensión porque hay veces en que éstas funcionan bien y otras en que no 
funcionan en lo absoluto. Antes de correr a usar cualquiera de estos procesos técnicos, por favor, lee, 
pregunta, asiste a clases y de nuevo experimenta antes de intentar usar cualquiera de las técnicas que 
he descrito y que estaré describiendo.
La razón principal por la que enlisto algunas de esas técnicas es para que las personas que 
piensan que invertir es arriesgado sepan que no tiene que serlo. Sigue dependiendo del 
individuo buscar más conocimiento si quiere usar esas técnicas.
Opciones de compra
Otra palabra para opciones es seguros. Dicho simplemente, una opción de compra le otorga al 
propietario de la opción el derecho de comprar acciones a cierto precio por acción en un 
periodo predeterminado. Una opción de compra es una póliza de seguro que protege al 
inversionista de quedar fuera en un repentino incremento en el precio de una acción. Por 
ejemplo, digamos que las gráficas de tendencias y de promedio móvil indican que más 
compradores están entrando al mercado, de modo que los precios están subiendo y el 
inversionista quiere asegurarse de que puede comprar la acción a un mejor precio en el caso 
de que ésta aumente de valor. Usemos como ejemplo una acción que hoy tiene un precio de 50 
dólares por acción. El inversionista llama a su corredor y dice que quiere comprar una 
opción de compra de acciones para comprar 100 acciones a 50 dólares cada una. Puede ser 
que pague un dólar por acción por esa opción de compra de acciones, lo que le costaría 100 
dólares (cada opción cubre 100 acciones). Se está protegiendo a sí mismo de un cambio 
repentino moviendo hacia arriba.
Tres semanas después, el inversionista regresa de pescar y descubre que la acción ha 
aumentado a 60 dólares por acción. La opción de compra de acciones técnicamente permite 
que el inversionista compre 100 acciones a un precio de 50 dólares por acción. Entonces, si 
eso elige, podría vender las mismas 100 acciones a 60 dólares cada una.
De otro modo, si la acción hubiera permanecido a un precio bursátil de 50 dólares por acción 
o menos, la opción expiraría sin valor, o como dicen los inversionistas sofisticados, "fuera 
del dinero".
En el ejemplo de las acciones que aumentaron a 60 dólares por acción, el inversionista 
promedio podría ejercer entonces su derecho a comprar 100 acciones a 50 dólares por 
acción por 5 000 dólares y de manera simultánea vender 100 acciones por 6 000 dólares, 
obteniendo una ganancia de 900 dólares (6 000 dólares menos los 5 000 dólares menos 100 
dólares del costo de la opción). Por otro lado, un inversionista sofisticado elegiría vender su 
opción a 10 dólares por acción o 1 000 dólares por la unidad de 100 acciones, obteniendo 
una ganancia de 900 dólares (1 000 dólares menos 100 dólares del costo de la opción).
Cuando examinas la transacción, te das cuenta de que el inversionista promedio puso 5,000 
dólares para ganar 900. El inversionista sofisticado puso 100 dólares para ganar los mismos 
900 dólares. En este ejemplo demasiado simplificado, ¿cuál inversionista ganó más dinero con 
su dinero?
La respuesta que yo daría es que el inversionista que compró y vendió opciones, o el 
inversionista sofisticado. El inversionista promedio puso 5 000 dólares para ganar 900, o 
una ganancia del 18 por ciento mensual. El inversionista sofisticado puso 100 dólares y ganó 
900 en menos de un mes con una ganancia del 900 por ciento.
De nuevo, se trata de un ejemplo demasiado simplificado y te recomiendo mucho que 
estudies más, que adquieras algo de experiencia y que encuentres a un corredor de bolsa 
competente para que te asista a través de este proceso de aprendizaje.
Este ejemplo ilustra por qué mi padre rico no quería tener mucho y por qué en cambio 
buscaba sólo controlar. Las opciones te dan control sobre el proceso de compra y venta. Tam-bién ilustra un ejemplo sobre cómo se puede crear apalancamiento en los activos en 
documentos y cómo éste puede ser usado con menos riesgo y mayores ganancias si sabes lo 
que estás haciendo. En este ejemplo, el inversionista sofisticado sólo arriesgó un dólar por 
opción y el inversionista promedio puso 50 dólares por acción. Cuando regresas a la 
discusión sobre la velocidad del dinero, ¿el dinero de cuál inversionista se está moviendo 
más rápido? ¿Qué inversionista se puede hacer rico más rápido?
A los ricos no les gusta poseer cosas
Es probable que hayas notado algo con este último ejemplo. Puede ser que hayas notado 
que no necesariamente tienes que poseer la acción para poseer una opción. Este detalle que 
con frecuencia se pasa por alto puede tener grandes consecuencias  financieras si lo 
entiendes.
El punto es que mi padre rico nunca quiso poseer nada y mi padre pobre sí. Mi padre pobre a 
menudo decía: "Esta casa está a mi nombre". "Mi coche está a mi nombre". Mi padre rico de-cía: "Tú no quieres poseer nada. Lo único que quieres es controlarlo". Las opciones son otro 
ejemplo de esta forma de pensar. Mi padre pobre quería poseer las acciones y mi padre rico 
sólo quería poseer la opción para comprarla o venderla. Hoy, noto que muchas personas se 
enorgullecen de poseer acciones cuando, en muchas formas, hay mucho mejor apalancamiento 
en comprar y vender opciones. En otras palabras, puede que se necesite mucho menos dinero 
para hacer mucho más dinero comerciando con acciones en lugar de comprarlas.
Opciones de venta
En el ejemplo anterior, viste cómo las opciones de compra se usan para hacer dinero en un 
mercado que tiende a subir o mercado alcista. Cuando la tendencia del mercado es a la baja, 
el inversionista sofisticado usará las opciones de venta no sólo para hacer dinero, sino 
también para proteger el valor de sus acciones en el caso de que los precios comiencen a 
caer.
Por ejemplo, el precio por acción es de 50 dólares. El mercado se mueve hacia abajo y el precio 
de la acción cae a 40 dólares. El inversionista promedio ha perdido 10 dólares por acción. Si 
ha perdido 1999 acciones, ha perdido 1 000 dólares, en papel. El punto aquí es que el 
inversionista sólo ha perdido en papel, pero no en la realidad. Si vendiera a 40 dólares por 
acción, entonces habría perdido. Es esta idea de que la pérdida es sólo en papel por lo que 
tantos inversionistas que están perdiendo de pronto dicen: "Estoy aquí para largo". Esas 
palabras generalmente significan que ese inversionista ahora esperará hasta que la acción 
vuelva a subir a 50 dólares, lo que puede pasar de la noche a la mañana, en diez años o 
nunca. Ésa es la estrategia de compra, conserva y pierde de alguien que es el eterno optimista 
o alguien que odia admitir que cometió un error y perdió.
El inversionista sofisticado invertiría de diferente manera. En lugar de sentarse ahí a 
preocuparse por el hecho de que el precio de su acción está bajando, ese inversionista haría 
que su corredor pusiera una orden de suspensión o que comprara una opción de venta. Una 
vez más, hay diferentes razones para usar una suspensión y para usar una opción de venta. El 
punto aquí es que el inversionista sofisticado hará algo en el caso de que la bolsa cambie de 
direcciones y comience la tendencia de baja.
En lugar de rezar para que la bolsa no baje, digamos que el inversionista sofisticado compra 
una opción de venta de acciones a un dólar por acción por el derecho a vender sus acciones 
a 50 dólares cada una. La opción le costaría 100 dólares, un dólar por acción, por 100 
acciones. El mercado baja a medida que más vendedores entran al mercado y el precio de la 
acción baja a 40 dólares por acción. El inversionista sofisticado está feliz porque acaba de 
proteger su posición a un precio de 50 dólares por acción. Lo que sigue perdiendo en la 
posición de acciones a medida que éstas bajan de 50 dólares lo vuelve a captar en el valor 
cada vez mayor de la opción de venta. El inversionista que no tiene una opción pierde dólar 
por dólar a medida que baja el precio de la acción. El inversionista sofisticado, o 
resguardado, realmente está igual. La pérdida de las acciones se han vuelto a captar con una 
ganancia en la opción.
¿Cómo hace dinero el inversionista sofisticado mediante una opción cuando el inversionista 
promedio pierde? El inversionista promedio podría ejercer su opción, o su derecho a vender 
100 acciones a 50 dólares cada una y recibir 5 000 dólares. Si eso elige, podría entonces ir a 
la bolsa y comprar 100 acciones a 40 dólares por 4 000 dólares. El resultado neto es que 
tiene 100 acciones y 900 dólares adicionales (1 000 menos el costo de la opción). (Hay 
muchas reglas de seguridad y regulaciones que deben seguirse y tomarse en consideración.)
El inversionista promedio, sin opción de venta de acciones, sólo tiene sus acciones, que 
ahora valen menos y sigue sin recuperar nada de su dinero.
Si esto te resulta confuso, no te preocupes, la primera vez es confuso para la mayoría de las 
personas. Es importante recordar lo que se escribió antes en este libro sobre la necesidad de 
pensar en los opuestos. Para muchas personas aprender a usar las opciones es muy parecido 
a aprender a comer con la mano izquierda después de haber pasado años comiendo con la 
derecha. Se puede hacer. Sólo se necesita un poco de práctica. El punto que hay que recordar 
es que el proceso de usar opciones para proteger tus activos al igual que para hacer dinero en 
mercados a la alza o a la baja no es un proceso complejo. La mayoría de las personas 
pueden aprenderlo si se conceden un poco de tiempo para entenderlo. Lo digo una vez más 
porque es importante, invertir no tiene que ser arriesgado, si tienes el consejo adecuado y 
los asesores adecuados. No tienes que pasarte la vida preocupándote por el hecho de que tu 
portafolio de activos en papel desaparezca en una caída de la bolsa. En lugar de preocuparte 
por caídas de la bolsa, puedes prepararte para volverte cada vez más rico entre más suba, 
baje o se mueva hacia los lados.
Lo que es importante notar es que el inversionista promedio que perdió dinero con frecuencia 
está sentado, esperando y escuchando el consejo de su asesor financiero que consiste en 
"esperar e invertir a largo plazo". Hace eso porque sólo tienen una estrategia para una sola 
tendencia del mercado, y, como tú sabes, hay tres tendencias distintas.
Un inversionista sofisticado puede no comprar acciones
Hay inversionistas sofisticados que nunca compran o venden acciones. Comercian sólo en 
opciones. Cuando le pregunté a uno de mis amigos que comercia con opciones por qué sólo 
invertía en opciones en lugar de en acciones dijo: "Invertir en acciones es demasiado lento. 
Puedo ganar mucho dinero con menos dinero al invertir en opciones. También puedo hacer 
más dinero en menos tiempo. Invertir en acciones y esperar hacer dinero es como sentarse a 
esperar que se seque la pintura".
Opciones combinadas de compra y venta
Las opciones combinadas de compra y venta son la máxima protección de seguros. En 
términos extremadamente simples, una opción combinada de compra y venta es colocar una 
opción de venta de acciones y una opción de compra de acciones alrededor de una posición 
de precios. Por ejemplo, si el precio de la acción del inversionista es de 50 dólares por 
acción, un inversionista sofisticado podría tener una opción de compra de acciones colocada 
en 52 dólares por acción y una opción de venta de acciones en 48 dólares por acción. Si el 
mercado sube repentinamente a 62 dólares por acción, el inversionista tiene el derecho de 
seguir comprando sus acciones a 52 dólares. Si el mercado baja a 42 dólares, el inversionista 
tiene el derecho de comprar sus acciones a 48 dólares, minimizando la pérdida. Si el precio 
del mercado de la acción está en 42 dólares y el inversionista tiene una opción de venta, que 
es la opción de vender una acción a 48 dólares, esa opción de repente se vuelve muy valiosa, 
en algunos casos, mucho más valiosa que la acción misma. El punto es que las opciones 
combinadas de compra y venta se usan para proteger tanto las oportunidades como los 
riesgos de aumento y baja. Puede ser una estrategia ultra conservadora si sabes lo que estás 
haciendo.
Una vez más, éste no pretende ser un libro sobre opciones de comercio. Obviamente, he 
simplificado en exceso el proceso con el único propósito de promover una comprensión 
básica de las opciones. Además, hay estrategias mucho más sofisticadas que se pueden usar y 
se usan para proteger activos e incrementar las ganancias.
Ventas en corto
Cuando era niño, me dijeron que no tocara ni usara cosas que no fueran mías. Eso no es 
cierto en la bolsa. Cuantío alguien vende en corto una acción, literalmente significa que está 
vendiendo algo que no le pertenece. Si mi mamá supiera que estoy haciendo esto, tendría 
conmigo una discusión fuerte y larga. Pero, una vez más, mi mamá no era inversionista.
Primero que nada, una venta en corto no es una opción. Cuan do alguien dice: "Estoy 
vendiendo en corto esta acción", están  comerciando en acciones no en opciones. Un 
inversionista sofisticado sabe las diferencias que hay entre una venta en corto y opciones y 
sabe cuándo usarlas y cuándo no. Una vez más, saber cuándo usarlas y cuándo no, está más 
allá de la esfera de acción de este libro.
¿Por qué vender en corto una acción? Generalmente, si el inversionista siente que el precio 
de una acción es demasiado alto y la tendencia del mercado es hacia abajo, a un inversio-nista sofisticado puede parecerle rentable comenzar a usar reducciones para hacer dinero. 
Vender en corto una acción es simplemente tomar prestadas las acciones de alguien más, 
venderlas en el mercado y embolsarte el dinero. Si baja el precio en el mercado de una 
acción y, cuando baja, el inversionista vuelve a comprar la acción y se la devuelve a la 
persona de quien tomó prestadas las acciones.
Por ejemplo, digamos que el precio en el mercado de una acción de la Corporación X es de 
50 dólares y que el mercado está tendiendo a bajar. El siguiente ejemplo es una secuencia 
de eventos involucrados en la reducción de una acción:
1.El inversionista llama a su corredor de bolsa y le pide venda en corto 100 acciones de las acciones 
de X.
2.Entonces el corredor toma prestadas 100 acciones de la cuenta de otro cliente y vende las 100 
acciones por 5 000 dólares.
3.El corredor deposita los 5 000 dólares en la cuenta del inversionista... el inversionista que no 
era dueño de las acciones.
4.En la cuenta de su cliente, la cuenta de donde se tomaron prestadas las acciones, hay un pagaré 
por 100 acciones, no 5 000 dólares.
5.Con el tiempo, el precio de las acciones de X bajan a 40 dólares.
6.El inversionista que pidió prestadas las acciones llama al corredor de bolsa y dice: "Cómprame 
100 acciones de X a 40 dólares".
7.El corredor compra las 100 acciones a 40 dólares y las devuelve a la cuenta del cliente, el cliente 
que le prestó las acciones al inversionista.
8.El corredor paga por las 100 acciones con los 5 000 dólares de la cuenta del inversionista. Los 5 
000 han salido de la venta original de las 100 acciones a 50 dólares.
9.El inversionista ha obtenido una ganancia de 1 000 dólares, menos honorarios, comisiones e 
impuestos, mediante la venta de acciones que no poseía. El inversionista hizo dinero sin tener dinero. 
Ése es, en términos simplificados, el proceso de vender en corto una acción.
Unos cuantos puntos más:
Punto #1: El momento en el que el inversionista compró las acciones a 40 dólares y devolvió 
las 100 acciones al inversionista original, el inversionista que llevó a cabo la venta en corto 
se dice que "cubrió su posición de cortos". Éstas son palabras muy importantes que hay que 
recordar.
Punto #2: Como puedes darte cuenta, hay un enorme riesgo en vender en corto una acción. 
Una persona puede perder mucho dinero reduciendo una acción si la tendencia del mercado es a 
la alza y el precio de la acción sube. En este ejemplo, ese mismo inversionista perdería 1 000 
dólares si el precio de la acción subiera a 60 dólares. Pero como decía a menudo mi padre 
rico: "Sólo porque hay riesgo no quiere decir que tenga que ser arriesgado". Hay inversionistas 
sofisticados que usan opciones combinadas de compra y venta en una venta en corto 
mediante la compra de una opción de compra por 51 dólares. Si la tendencia en realidad 
subiera y el precio de la acción aumentara a 60 dólares, el inversionista pagaría 51 dólares por 
acción en vez de 60 dólares, de nuevo minimizando su exposición.
Punto #3: Probablemente habrás notado que hice referencia a las tendencias del mercado. 
Recuerda el dicho: "La tendencia es tu amiga". No seas como mi amigo que trató de nadar 
contra la corriente de resaca. Más que conocer la definición de palabras como reducciones, 
opciones combinadas de compra y venta, opción de compra, entre otras, es importante saber 
cómo se relacionan entre sí. En otras palabras, usar cortos es bastante seguro en un mercado 
con tendencia a la baja y mucho más arriesgado en un mercado con tendencia a la alza o con 
movimiento hacia los lados.
Punto #4: Si no tienes idea de lo que se acaba de explicar, no te preocupes. Sólo se necesita 
un poco de tiempo y un poco de práctica para hacer que esas palabras sean parte de tu 
vocabulario si así lo quieres. El punto principal de todo esto es que invertir no tiene que ser 
arriesgado, si estás dispuesto a invertir un poco de tiempo para aumentar tu preparación, como 
lo estás haciendo ahora. Una vez que aprendas a minimizar el riesgo, podrás aumentar en 
gran medida tus ganancias porque no estás haciendo lo que hacen los inversionistas 
promedio.
Por qué no se necesita dinero para hacer dinero
La gente a menudo me pregunta: "¿No se necesita dinero para hacer dinero?" Si entiendes 
el proceso de vender en corto una acción, sabrás la respuesta a la pregunta. Cuando una 
persona vende en corto una acción, recibe dinero por vender algo que no posee. Así que en 
realidad no se necesita dinero para hacer dinero. No obstante, la respuesta real a la pregunta: 
"¿No se necesita dinero para hacer dinero?", es "depende de quién esté haciendo la 
inversión".
Mi padre rico decía: "Entre menos inteligente seas financieramente, más dinero necesitarás 
para hacer un poco de dinero. Si eres inteligente financieramente, no se necesita nada de di-nero para hacer mucho dinero". El siguiente ejemplo ilustra con mayor detalle este punto y 
también ilustra el valor de tener un vocabulario financiero rico y fuerte.
Hace unos meses, llamé a mi corredor de bolsa y le dije: "Escribe una opción de venta al 
descubierto para X. Escríbela para diez contratos".
Mi corredor, Tom, me hizo algunas preguntas más y luego dijo: "Ya está hecho". Lo que me 
preguntó fue el horizonte de tiempo para la opción y otras preguntas que de nuevo se en-cuentran fuera del ámbito de este libro.
Lo que yo acababa de hacer era vender opciones de venta, no comprarlas. Ése es un punto 
importante. La razón por la que es importante es porque ahora las opciones han sido usadas 
como pólizas de seguro, por lo que la mayoría de las personas compran opciones. Cuando usas 
las palabras "escribe una opción" significa que estás vendiendo la opción, no comprándola. 
Los que son muy ricos venden opciones así como venden acciones, no las compran. Bill Gates 
se convirtió en el hombre más rico del mundo vendiendo acciones de Microsoft, no comprando 
acciones de Microsoft. Lo mismo es cierto en el mundo de las opciones... sólo que es mucho 
más rápido, más fácil y puede ser más rentable, de nuevo si sabes lo que estás haciendo.
Cuando le dije a mi corredor: "Escribe una opción de venta al descubierto", le estaba 
diciendo "Quiero vender opciones de acciones que no tengo". En este caso son opciones de 
venta y yo quería diez contratos, lo que significa 1 000 acciones, puesto que un contrato 
consta de 100 acciones.
Tom me volvió a llamar más tarde ese día y dijo: "Ganaste cinco dólares".
Le di las gracias y la transacción terminó por ese momento. No tuve que ver las acciones o el 
mercado y estuve en libertad de ir a hacer lo que quisiera. Cuando Tom dijo que había 
"ganado" cinco dólares para mí, eso significaba que había puesto 5 000 dólares en mi cuenta 
ese día. Además de eso, yo no puse nada de dinero ni vendí nada tangible. En muchas 
formas, no vendí nada y gané 5 000 dólares en menos de cinco minutos. (Como un punto de 
aclaración, aunque no puse nada de dinero ni vendí nada tangible, tengo otros activos en mi 
cuenta de acciones que actúan como un colateral para la transacción, lo cual me permite 
trabajar con mi corredor de este modo.)
Unas semanas después, Tom me volvió a llamar y me dijo: "Expiró fuera del dinero".
"Excelente", contesté. "Por cierto, ¿cuándo vamos a jugar golf?"
Traducción
Antes que nada, no escribo sobre esta transacción para presumir. Escribo sobre esta 
transacción en sí sólo para ilustrar el poder de las palabras. Esas palabras son más que 
palabras para mí. Son reales y están vivas en mi cerebro. Esas palabras son herramientas, 
herramientas que me hacen rico... herramientas que me permiten hacer dinero sin nada de 
dinero. Como siempre decía mi padre rico: "Hay palabras que te hacen rico y palabras que te 
hacen pobre".
Cuando le dije a Tom: "Escribe una opción de venta de acciones al descubierto en X", estaba 
diciendo: "Véndele a alguien el derecho de venderme las acciones que tiene por un cierto 
precio". Ese día, X se estaba vendiendo en alrededor de 45 dólares por acción. Mi opción de 
venta de acciones le aseguraba a la persona que comprara la opción de venta de acciones 
que yo compraría la acción en 40 dólares por acción. En otras palabras, le estaba vendiendo 
un seguro al dueño de la acción X. Si el precio de la acción hubiera bajado a 40 dólares por 
acción y se hubiera ejercido la opción, yo habría comprado a ese precio, protegiéndolo de 
futuras pérdidas.
Cuando Tom me volvió a llamar y dijo "ganaste cinco dólares" quiso decir que había ganado 
cinco dólares por acción cubierto por la opción de venta. En el vocabulario de opciones de 
los comerciantes de opciones "escribir" significa vender. También es la misma palabra que 
se usa en la industria de los seguros. A muchos de nosotros un vendedor de seguros nos ha 
dicho: "Le estoy escribiendo una póliza de seguro de vida con un beneficio de muerte de 
100 000 dólares". Otra palabra que se usa en la industria de los seguros es "suscribir", que 
significa que te están garantizando algo por un precio. En otras palabras, escribir significa 
vender en el mundo de los seguros y en el mundo de las opciones. En este caso, yo estaba 
suscribiendo la exposición al riesgo de 45 dólares del inversionista por cinco dólares por 
acción. Le estaba garantizando al inversionista que yo compraría sus acciones por 40 
dólares si el precio bajaba a ese punto. En este caso, yo me convertí en la compañía de 
seguros, razón por la cual estaba "escribiendo una opción de venta al descubierto". Estaba 
asegurando algo que yo no poseía, que es lo que hacen las compañías de seguros.
El contexto de un perdedor
Ahora puedo escuchar a alguien de tu contexto mental diciendo: "Pero eso es demasiado 
arriesgado. ¿Qué tal si la bolsa tiene una caída? ¿Qué tal si tienes que comprar las acciones 
a 40 dólares?" Como se ha dicho a lo largo de todo este libro,  una persona necesita 
mantener abierto su contexto si quiere aprender algo. O, como decía mi padre rico: "No sólo 
porque haya un riesgo significa que tiene que ser arriesgado".
Guardé esta sección para el final de este libro porque quería asegurarme de que tu contexto 
estuviera preparado en cierta forma para recibir esta información. Nunca había escrito sobre 
esto porque nunca antes había escrito sobre la importancia del contexto. Para la mayoría de 
las personas, su contexto no es capaz de comprender, mucho menos de aceptar, lo que estoy 
por explicar. Si te has quedado conmigo hasta aquí te felicito. Cuando hablo con algunos de 
mis amigos o con otras personas que tienen el contexto de un perdedor, es decir uno movido 
por el miedo de perder, el ruido del miedo es tan fuerte que no pueden escuchar lo que estoy 
diciendo o estoy por decir. Entra su miedo al riesgo y a perder y sus mentes empiezan a 
alejarse diciendo: "Eso es demasiado arriesgado. No me digas nada más. No puedo hacerlo". 
Así que gracias por haberte quedado por todo este tiempo.
En esa transacción de cinco minutos, básicamente acepté comprar mil acciones de X por 40 
dólares cada una si el inversionista que tenía las acciones me pagaba cinco dólares por cada 
prima de acción. El dinero, o 5 000 dólares, fue depositado en mi cuenta. Unas semanas 
después, el precio de la acción estaba alrededor de 43 dólares de modo que la opción o póliza 
de seguro expiró sin valor o "fuera del dinero" como suele decirse. Los 5 000 dólares eran 
míos, menos comisiones, honorarios e impuestos. El punto que quiero remarcar es que me 
tomó menos de cinco minutos, no vendí nada, no hice nada después, lo que significa que no 
me tuve que sentar frente a una computadora observando las altas y bajas del mercado, y gané 
5 000 dólares.
Hay muchas personas que no ganan 5 000 dólares al mes y, si los ganan, pagan muchos más 
impuestos de los que yo pagué por la misma cantidad de dinero. Un trabajador pagaría un 
impuesto de autoempleo sobre esos 5 000 dólares y yo no porque no fue el mismo tipo de 
ingreso. Un trabajador gana 5 000 dólares de ingreso ganado y yo gané 5 000 dólares de 
ingreso de portafolio.
Haciendo dinero de la nada
Antes de avanzar, pienso que es importante que ponderes cómo se ganaron los 5 000 dólares 
porque se hizo de la nada. Cuando inspecciones esta transacción, comenzarás a darte cuenta 
de que hice el dinero vendiendo algo que yo no poseía. También hice el dinero vendiendo 
algo que no existía, hasta que yo decidí que existía. La transacción fue como hacer dinero de 
la nada. Si verdaderamente puedes entender lo que sucedió en esta transacción, tanto física 
como mentalmente, puedes comenzar a entender el poder que tiene tu mente para crear 
dinero de la nada. Esa habilidad a menudo se denomina "poder de la alquimia". Ahora es 
probable que entiendas mejor por qué mi padre rico me hizo trabajar gratis cuando era niño. 
Quería entrenarme para pensar en crear dinero en lugar de trabajar por dinero. Quería que 
desarrollara un contexto diferente, un contexto que no dependiera de trabajar duro para 
hacerme rico.
Haciendo felices a los perdedores
Rara vez le cuento a la gente sobre este proceso. Me he cansado de discutir y tratar de 
explicarle este proceso al contexto de un perdedor. Las veces que he hablado sobre este 
proceso de opción, con frecuencia escucho comentarios como:
1. Se necesita demasiado tiempo. Yo no me paso los días observando el mercado.
2.Es demasiado arriesgado y no puedo da me el lujo de perder.
3.No tengo idea de lo que estás hablando.
4.No puedes hacer eso. Es ilegal.
5.Mi corredor de bolsa dice que no es tan fácil.
6.¿Qué tal si estás equivocado y cometes un error?
7.Estás mintiendo. No puedes hacer eso.
En otras palabras, los perdedores pierden porque no pueden escuchar sin que su contexto se 
entrometa. Este libro ha tratado sobre contexto y sobre la realidad de una persona. La razón 
por la que dudo en darle contenido a la gente es porque el contexto de la mayoría de las 
personas no puede manejar el contenido que acabo de explicar. Ahora que el libro se acerca 
a su fin, estoy más dispuesto a darte el contenido que tantas personas quieren. Simplemente 
confío en que tu contexto te permita absorber y te permita usar el contenido y convertirlo en 
acción.
En otras palabras, cuando me piden que diga lo que hago y lo digo, en muchos casos el que 
contraataca es su contexto. Su contexto contraataca, se cierra herméticamente, discute o 
encuentra razones de por qué no puede hacerse. Ahora que he pasado tiempo explicando el 
contexto, te daré el contenido final de por qué escribir estás opciones al descubierto es una 
inversión de bajo riesgo y alto rendimiento, incluso si las cosas no salen a tu manera.
El precio baja a 35 dólares
Primero que nada, yo no estaba preocupado realmente por tener que reunir los 40 000 
dólares para cubrir mi posición al descubierto. Hay tres razones por las que no me 
preocupaba estar equivocado y son las siguientes:
1.Tenía dinero para cubrir mi posición en el caso de que tuviera que comprar las acciones.
2.La historia demuestra que 85 por ciento de todas las opciones expiran sin que se les ejerza. Una 
posibilidad de ganar de 85 por ciento es mucho mejor que las probabilidades que ofrecen la bolsa o 
Las Vegas.
3.De cualquier manera quería tener las acciones. Sólo quería comprarlas con un buen descuento.
De modo que la pregunta es ¿el precio de la acción podía haber bajado y yo podía haberme 
visto obligado a comprar las acciones a 40 dólares cada una? La respuesta es sí. Ése es el 
acuerdo que vendí como opción de venta al descubierto. La diferencia es que una persona 
que tiene un contexto ganador sabe que puede ganar incluso cuando pierde. Por esa razón 
no tiene miedo de perder. Un perdedor sólo puede pensar en perder y por eso es que rara vez 
logra ganar.
Digamos que el precio de una acción baja a 35 dólares por acción. Alguien que tiene un 
contexto de perdedor sólo vería la pérdida y nunca ganaría. Un perdedor diría: "Acabo de 
perder 40 000 dólares porque tuve que comprar 1 000 acciones a 40 dólares cada una". El 
perdedor vería cuánto riesgo hay y nunca haría el trato.  Su contexto se cerraría 
herméticamente o se pondría a hablar sobre lo arriesgada que era la idea. No sería capaz de 
pensar más allá porque sus emociones se habrán apoderado de su cerebro. El perdedor vería 
la exposición de 40 000 dólares como un riesgo de pérdida mayor que el potencial de 
ganancia de 5 000 dólares en cinco minutos. Además, si la acción hubiera bajado a 35 
dólares cada una, el perdedor habría visto una pérdida adicional de 5 000 dólares. El 
contexto de perdedor tendría el control absoluto sobre la persona.
La razón por la que al comienzo del libro he pasado tanto tiempo hablando sobre el 
apalancamiento de la mente es por los ejemplos de esas transacciones. Cuando le cuento a la 
gente lo que hago, sin importar si es en la construcción de un negocio, al invertir en bienes 
raíces o al invertir en activos en papel, las más de las veces es el contexto de la persona lo 
que determina la validez de mi contenido. Un perdedor siempre, y quiero decir siempre, 
piensa que no puede darse el lujo de hacer lo que yo estoy haciendo. Una persona 
trabajadora a menudo dirá: "No tengo el tiempo para hacer lo que tú haces porque estoy 
demasiado ocupado trabajando". Y una persona que no está interesada en lo que hago dirá: 
"Suena demasiado complicado. Simplemente no lo entiendo. Además, no me interesa el 
dinero".
La mayoría de las personas nunca lograrán retirarse jóvenes y ricas simplemente porque no 
tienen un contexto capaz de convertir en realidad esa idea. Por eso, al comienzo de este 
libro, pasé tanto tiempo hablando sobre el apalancamiento de tu mente y sobre el 
apalancamiento de tu plan. El contexto es más importante que el contenido. Lo que yo hice y 
sigo haciendo para haberme retirado joven y rico es simple, si tienes el contexto apropiado. 
Lo que hago no es tan difícil, ni tan complicado. Como dije, me tomó menos de cinco 
minutos hacer 5 000 dólares. Para muchas personas, esa posibilidad está fuera de su 
contexto, lo que es lo mismo que decir que está fuera de su realidad. Muchas personas 
estarían dispuestas a trabajar 30 días sólo para ganar 5 000 dólares. Están dispuestas a 
trabajar durante 30 días porque su contexto les permite pensar que 5 000 dólares en treintas es 
posible o real. Pero 5 000 dólares en cinco minutos no entra dentro de su contexto, así que 
la idea se encuentra con: "Está mintiendo, es demasiado arriesgado, no puedo hacerlo". En 
otras palabras, su contexto rechaza la posibilidad. En cambio, su contexto da con ideas que 
encajan en él. Ésa es la razón por la que tantas personas se pasan la vida trabajando duro 
físicamente en vez de trabajar duro para expandir su contexto. Físicamente, trabajan duro por 
dinero en vez de expandir su contexto financiero para incrementar el contenido financiero 
que ponen en su cerebro.
El contexto de un ganador
La pregunta que haría una persona que tiene un contexto ganador sería: "¿Cómo gano si 
pierdo?", "¿Qué pasa si el precio de X baja más allá de 40 dólares?", "¿Cómo gano 
entonces?" Ése es el contexto de un ganador. Saben que pueden ganar aun si pierden. Lo 
más importante, pueden mantener la mente abierta, aunque lo que estén escuchando esté 
fuera de su contexto. En otras palabras, un ganador puede mantener una mente muy abierta, 
aunque lo que esté escuchando lo asuste o le resulte completamente nuevo. Como siempre 
decía mi padre rico: "La mente de un perdedor se cierra más rápido que la de un ganador".
Antes en este libro escribí sobre la importancia de una estrategia de salida. Un ganador 
siempre está buscando una estrategia de salida aunque esté perdiendo. Usemos como 
ejemplo esta opción de venta al descubierto. Antes de entrar en la transacción, yo ya tenía 
una estrategia de salida que me permitiría ganar, incluso si las cosas no salían a mi manera. 
De nuevo, es el contexto más que el contenido. Sin importar si es en acciones, bienes raíces 
o negocios, es un contexto ganador el que permite que los ganadores ganen, sin importar si 
están perdiendo. En este ejemplo, es el contexto de tener una estrategia de salida el que es 
parte del contexto de un ganador. Un perdedor sólo ve el riesgo o las pérdidas y nunca ve la 
posibilidad de ganar, aun si pierde. Un perdedor sólo corre un riesgo si se le garantiza que 
las cosas van a salir a su manera. Por eso es que muchas personas quieren un pago 
garantizado y beneficios garantizados. Prefieren tener garantías que posibilidades. Un ga-nador buscará oportunidades sabiendo que ganará incluso si las cosas no salen a su manera. 
No es simplemente ser optimista. Como decía mi padre rico: "Hay muchas personas que tie-nen pensamientos positivos, pero los tienen dentro de un contexto de perdedor. Tener un 
contexto ganador es saber que vas a ganar, aun si pierdes".
Cómo ganar si pierdes
El día que le hablé a Tom, yo ya había hecho mi tarea, la cual me tomó menos de un minuto. 
Lo siguiente es lo que sabía antes de poner la orden:
1.El mercado tenía una tendencia a la baja.
2.El precio de X recientemente se había derribado, bajando a cerca de 20 a 45 dólares. Los 
inversionistas que tenían las acciones tenían que estar bastante nerviosos.
3.Sabía que X era una buena compañía, con buenas ganancias y dividendos. Estaba bien 
administrada y le iría bien en una buena economía y en una mala economía.
4.Es una compañía que muchos siguen, lo que significa que tiene muchos inversionistas 
interesados en ella.
5.Es una compañía que yo quería tener y conservar, si el precio era el correcto.
6.Yo tenía 100 000 dólares en una cuenta de interés por si tenía que comprar la acción. Lo único que 
tuvo que hacer Tom fue transferir el dinero y tenía la autoridad para hacerlo.
Si las acciones hubieran caído a 35 dólares cada una, yo habría estado en éxtasis, incluso si 
hubiera tenido que pagar los 40 000 dólares para cumplir con mi acuerdo de opción de venta. 
¿Por qué? De nuevo, la respuesta es mi estrategia de salida.
Digamos que tuve que pagar 40 000 dólares por 1 000 acciones. ¿Cuál es el precio real de las 
acciones?
La respuesta es 35 000 dólares porque yo ya había recibido 5 000 de la opción. Así que 
aunque el precio cayó por debajo del precio de mi opción de venta de 40 dólares cada una, yo 
seguía pagando sólo 35 dólares por cada una, lo que de cualquier forma sería un gran precio para 
esa acción y yo habría sido el dueño de las acciones.
El siguiente paso sería de inmediato vender diez opciones de compra cubiertas (100 acciones por 
opción de compra) a cinco dólares por acción en las 1 000 acciones que tenía. La razón por la 
que se llama cubierta es porque esta vez en realidad yo sí poseía las acciones por las que 
estaba vendiendo la opción. Usé el término al descubierto frente a opción de venta porque yo 
no era el dueño de las acciones. Una vez más, la mayoría de las personas simplemente dirían: "Es 
demasiado arriesgado vender algo que no es tuyo". Y lo es, si no tienes el contexto y el 
contenido adecuados.
¿Por qué vender una opción de compra cubierta? La respuesta se encuentra en el término 
velocidad del dinero, un término que se discutió antes. Al vender una opción de compra 
cubierta, acepto vender mis acción digamos por 40 dólares cada una, en caso de que el 
precio se dispare rápidamente. Una persona temerosa de quedar fuera en un movimiento del 
mercado pagará por una opción. Si el precio de las acciones hubiera subido digamos a 50 
dólares por acción, entonces habría estado obligado a vender mis 1000 acciones por 40 000 
dólares. En ese caso, habría recuperado todo mi dinero más el dinero que reuní de mis 
opciones. Así que habría ganado incluso si hubiera perdido.
Si el precio de las acciones no subiera, de cualquier forma habría reunido algo de dinero, en 
este caso 5 000 dólares por las opción de compra, aun si el precio de la acción no hubiera 
hecho nada.
El inversionista promedio estaría manteniendo una posición perdedora en estas acciones y 
estaría escuchando decir a su asesor financiero: "Invierte a largo plazo. Sé paciente. La bolsa 
en promedio ha subido durante los últimos 40 años. Así que no hagas nada y espera". Eso es 
más de la mentalidad de compra, conserva y reza que tiene la mayoría de los inversionistas 
y muchos asesores de inversión.
Al vender opción de compra de acciones cubiertas, es probable que yo haya puesto en mi bolsa 
otros 5 000 dólares, de nuevo bajando la base de mis acciones a 30 dólares por acción, lo que 
me habría hecho más feliz, puesto que yo quería tener las acciones de cualquier modo. Debido 
a mis opciones de compra y opción de compra de acciones, en vez de pagar 40 000 dólares por 
las acciones que quería tener, en realidad pagué 30 000, aunque en este ejemplo la bolsa 
hubiera estado en 35 000 dólares.
Es como aprender a comer con tu otra mano
De nuevo, si no entendiste por completo lo anterior, no te preocupes. En teoría es simple y 
no es difícil de entender, si pasas un poco de tiempo estudiando la materia. Es muy pare-cido a aprender a comer con tu mano izquierda después de haber pasado toda tu vida 
comiendo con la derecha. Es simple en teoría y es simple una vez que aprendes a hacerlo. 
Aprender a pensar y a hacer las cosas de diferente manera es lo que a veces es difícil.
Lo que todo el mundo puede hacer
Para mí, comprar opciones para proteger tus activos tiene sentido y vender opciones para 
conseguir flujo de efectivo es divertido. Una de las razones por las que no me preocupo por 
dinero es simplemente porque sé que puedo ir a la bolsa y hacer más dinero en minutos de lo 
que la mayoría de las personas conseguirían en meses... y pagar menos impuestos.
¿Todo el mundo puede hacer lo que hago yo? Las siguientes son algunas sugerencias:
1.Ve a la biblioteca y pide prestado un libro sobre comercio de opciones. Primero aprende las 
definiciones de las palabras y luego lee para comprender mejor.
2.Compra un libro en alguna librería del lugar donde vives u ordénalo por Internet. Recomiendo que 
revises físicamente el libro antes de comprarlo porque querrás empezar primero con un libro 
simple.
3.Asiste a un seminario sobre comercio de opciones. Hay muchos disponibles.
4.Encuentra un corredor de bolsa que te enseñe y te guíe en el proceso.
5.Juega CASHFLOW 101 por lo menos doce veces para que aprendas la mentalidad de la inversión 
fundamental. Después de que hayas dominado el 101, puedes pasar al CASHFLOW 202, que es el 
juego que enseña cómo usar las opciones de compra, las opciones de venta, los cortos y las opciones 
combinadas de compra y venta de acciones. Lo más importante es que el CASHFLOW 202 te enseña a 
pensar en múltiples direcciones dependiendo de las cambiantes tendencias del mercado. Creo que el 
aspecto más poderos de CASHFLOW 202 es que es una forma física, mental y emocional de aprender 
un tema multidimensional. En otras palabras, el juego te enseñará a pensar en diferentes direcciones. 
La razón por la que la mayoría de los inversionistas pierden es porque en la casa, en la escuela y en su 
lugar de trabajo han sido entrenados para pensar en una sola dirección. Un inversionista sofisticado ne-cesita pensar en cómo hacer dinero en un mercado con tendencia a la alza, en un mercado con tendencia 
a la baja y en un mercado que tienda a moverse hacia los lados. CASHFLOW 202 te enseña a pensar de 
esa forma, a divertirte y a aprender usando dinero de juguete en lugar de dinero real.
¿Invertir es arriesgado?
Entonces, ¿invertir es arriesgado? Mi respuesta es rotundamente no. En mi opinión, ser 
ignorante es arriesgado. Si quieres retirarte joven y rico, aprender cómo asegurar tus activos en 
contra de la pérdida es fundamental. El inversionista promedio es quien preferiría no estudiar 
y decir que invertir es arriesgado... ése es el mayor de los riesgos. Como dije: "Nunca en la 
historia de la humanidad, tantas personas han apostado su futuro financiero y su seguridad 
financiera en las altas y bajas del mercado bursátil". Eso es arriesgado sólo si esos 
inversionistas saben que es arriesgado y, no obstante, no hacen nada con relación a los ries-gos. Como decía mi padre rico: "El cuadrante I es de inversionista, no de ignorancia". 
También decía: "Invertir en sí no es arriesgado. Pero ser financieramente ignorante y tomar 
consejos de asesores financieros ignorantes es muy arriesgado. No sólo es arriesgado, también 
es costoso. Es costoso no sólo en términos de dinero, es costoso en términos de tiempo. 
Millones de personas se pasan la vida aferrándose a un trabajo seguro en lugar de buscar la 
libertad financiera debido a la ignorancia financiera.
Debido a la ignorancia financiera, muchas personas se aferran a un pequeño cheque en lugar 
de buscar la abundancia de dinero que hay disponible. Debido a la ignorancia financiera, las 
personas ponen dinero en sus cuentas de retiro y luego se preocupan porque esté ahí cuando lo 
necesiten. Debido a la ignorancia financiera, millones de personas pasan más tiempo en el 
trabajo, haciendo que el rico sea más rico en vez de pasar su tiempo enriqueciendo las vidas de 
sus seres queridos. No, yo no diría que invertir es arriesgado. Pero diría que ser 
financieramente ignorante es arriesgado y muy costoso".
La educación contenida aquí es sólo para fines didácticos y está basada en reportes, comunicaciones 
o fuentes que se consideran confiables. Sin embargo, tal información no ha sido verificada y no 
hacemos ninguna representación de su precisión. Las transacciones de opciones pueden acarrear un 
nivel de riesgo adicional. Antes de llevar a cabo cualquier transacción de opciones todos los 
inversionistas deberían buscar la guía y el consejo de un profesional de opciones certificado.

CAPÍTULO 18
El apalancamiento de un negocio del 
cuadrante D
El juego más rico del mundo
Las personas que se hicieron más ricas a sí mismas son empresarios del cuadrante D. Son 
mucho más ricas que las estrellas de cine, las estrellas de los deportes y los profesionistas 
mejor pagados. Cuando tomé la decisión de no seguir las huellas de mi padre pobre luego de 
regresar de Vietnam, fue mi padre rico quien me sugirió que empezara a aprender cómo crear 
negocios. Dijo: "La razón por la que las personas más ricas del mundo son del cuadrante D es 
porque es el cuadrante en el que resulta más difícil tener éxito. Pero, si tienes éxito, las 
compuertas de la abundancia se abren y la riqueza se vierte sobre ti. Si puedes crear un 
negocio del cuadrante D, estarás jugando en el juego más rico del mundo".
Cuando ves en retrospectiva la historia reciente, son persona como Bill Gates, Michael Dell, 
Thomas Edison, Henry Ford, Ted Turner, John D. Rockefeller entre otros quienes se encuentran 
en los primeros lugares de la lista de famosos del cuadrante D. Hay muchos más que no son tan 
famosos. Todos se convirtieron en gigantes financieros porque construyeron un activo 
gigantesco. Usaron el mayor apalancamiento que existe, el apalancamiento de construir un 
negocio que servía a millones de personas.
Se ha dicho que la mejor inversión que puedes hacer es invertir en un negocio propio... y yo 
estoy de acuerdo. Las ganancias por tu inversión desafinan los cálculos de inversión 
normales, si sabes lo que estás haciendo. Es posible tomar unos cuantos cientos de dólares y 
convertirlos en miles de millones de dólares. También es posible no sólo hacerte rico a ti 
mismo, sino también hacer ricos a tus amigos, familiares, socios de negocios, empleados e 
inversionistas más allá de sus sueños más locos. Por esa razón es que se llama el juego más 
rico del mundo.
Cuando era más joven, mi padre rico constantemente me recordaba que había tres clases de 
activos básicos, las cuales son:
1.Bienes raíces
2.Activos en documentos
3.Negocios
Mientras yo comenzaba a entrar en los activos en papel y en los bienes raíces, era en crear el 
activo de negocio en lo que mi padre rico me animaba a enfocarme. Decía: "Empieza primero 
con lo más difícil y el resto será fácil". Hoy, tiendo a estar de acuerdo con él.
Estrategia de salida
En este libro escribí sobre la importancia de una estrategia de salida. Hay:
Pobre 25 000 dólares al año
Clase media 25 000 a 100 000 dólares al año
Afluentes 100 000 a 1 millón de dólares al año
Ricos 1 millón o más al año
Ultra ricos 1 millón o más al mes
A medida que este libro se acerca a su fin, te pido que empieces a prestarle un poco de atención a 
la idea de tu propia estrategia de salida personal. También nota tu mentalidad o contexto mientras 
ponderas tu elección. ¿Tu mente te está diciendo "no puedo hacerlo" o "eso sería demasiado 
problema" o "no soy lo bastante inteligente" o alguna otra realidad personal similar que define el 
contexto?
Cuando mi padre rico trabajaba conmigo en mi estrategia de salida personal, yo tenía que repasar 
las dudas y limitaciones causadas por mi contexto limitado. Después de unos meses de 
discusión, supe que mis mejores posibilidades estaban en el cuadrante D. En mi opinión, aun 
antes de elegir tu nivel de salida, querrás evaluar tus fortalezas y debilidades personales y qué 
cuadrante te ofrece la mejor posibilidad de retirarte joven y rico.
Recientemente, alguien de mi clase de inversión dijo: "Oprah Winfrey se convirtió en la mujer 
más rica del mundo del entretenimiento a través del cuadrante de los autoempleados".
Luego le pregunté al individuo por qué pensaba eso. Su respuesta fue: "Porque es una 
autoempleada. Si dejara de trabajar, su ingreso se detendría".
"¿Cómo lo sabes?", pregunté. "Luego le pregunté qué eran las producciones HARPO. No 
sabía."
Mi respuesta fue: "Producciones HARPO, el respaldo de Oprah, es la compañía de Oprah... su 
negocio del cuadrante D.  Ese negocio es dirigido por otras personas e invierte en otras 
inversiones. Puede que ella sea una estrella en el cuadrante A, pero su contexto está en el 
cuadrante D".
El punto de decir todo esto es que el cuadrante en el que estás tiene poco que ver con cuál 
sea tu profesión. Michael Jordan puede haber sido un empleado de los Toros de Chicago, no 
obstante, a un lado tenía su propio negocio del cuadrante D. Un médico puede estar en el 
cuadrante E, A, D o I, dependiendo de su contexto. Un conserje también puede estar en los 
cuatro cuadrantes. Digo esto porque demasiadas personas tienen un contexto en sólo un 
contexto, en vez de aprender a tener más de un contexto. Esas personas que tienen un 
contexto con paredes apretadas o rígidas con frecuencia son quienes trabajan más duro, más 
tiempo y con frecuencia terminan con menos. En la actual Era de la Información, es 
imperativo que todos tengamos más de un contexto y que estemos en más de un cuadrante. 
Si puedes hacerlo, encontrarás que tus posibilidades de alcanzar una estrategia de salida de 
un nivel más alto se harán más sencillas y posiblemente más realistas.
En otras palabras, la razón por la que Kim y yo pudimos salir en o por arriba del nivel de los 
ultra ricos es porque operamos principalmente desde el cuadrante D. En vez de trabajar para 
ganar miles o millones, trabajamos para tener decenas de millones, y quizá más, como 
nuestra estrategia de salida.
Guía para invertir de Padre Rico
En el libro número tres, Guía para invertir de Padre Rico, escribí sobre mi decisión de 
aprender a convertirme en empresario. En todos mis libros, escribí sobre el número de veces 
en que fracasé y en lo que me tomó levantarme. En mi opinión, es el contexto de ser exitoso, 
sin importar en qué cuadrante estés. La razón por la que menciono el libro número tres es 
porque la segunda mitad de ese libro trata sobre cómo crear un negocio, el mayor y más rico 
activo de todos. Si te gustaría construir un negocio del cuadrante D, es probable que quieras 
leer o releer ese libro, puesto que en este capítulo no voy a entrar en cómo crear ese activo.
Además, la razón por la que apoyo tanto la mercadotecnia en red es porque la palabra red es la 
palabra que usan los que son muy ricos. Recientemente, escribí un libro para la industria de 
mercadotecnia en red titulado La escuela de negocios para personas a quienes les gusta 
ayudar a la gente. Ese libro simple y breve está escrito principalmente para cualquiera que 
quiera cambiar del cuadrante E al A. El libro y la cinta de audio apoyan a cualquiera que quiera 
invertir el tiempo necesario para cambiar su contexto del cuadrante E y A al cuadrante D, el 
cuadrante que produce a la gente más rica del mundo. El libro y la cinta de audio explican por 
qué personas como John D. Rockefeller y Bill Gates construyeron redes. El libro y la cinta 
abren con la afirmación de mi padre rico de que: "Las personas más ricas del mundo buscan y 
construyen redes; todos los demás buscan trabajo".
Si te gustaría tener una copia del libro y de la cinta, puedes entrar a nuestro sitio de Internet 
en richdad.com y ordenarlos.
El año pasado, un amigo vino conmigo y me dijo "Tuve una ganancia de 35 por ciento en mis 
fondos de inversión en 1999". Yo contesté con una felicitación sincera. Cuando me preguntó 
cuáles eran mis ganancias, le dije: "En realidad no lo sé". No es que no lo sepa, lo que no sabía 
era cómo decirle que mis ganancias no se adaptan a estándares de medida normales. Mientras el 
fondo de inversión de mi amigo le había dado 35 por ciento de ganancia por su dinero, lo cual 
es muy bueno, mis ganancias personales eran de millones de dólares sin invertir un centavo de 
mi dinero original. Probablemente recuerdas el capítulo anterior en donde se discutía la 
velocidad del dinero que tenemos. La razón por la que tuve dificultades para responder a su 
pregunta es que mi dinero ya había avanzado y mis ganancias por las inversiones 
técnicamente eran infinitas. Por eso dije poco sobre mis ganancias y lo felicité por su éxito en 
el mercado de 1999.
De nuevo, mi punto al citar esto no es jactarme de mis resultados. El punto que quiero dejar 
en claro es sobre las diferencias de contexto. Mi amigo está feliz de recibir una ganancia de 
35 por ciento mientras que una persona que construye un negocio no lo estaría. En mi 
opinión, es el poder que se encuentra en las diferencias de contexto. Una persona del 
cuadrante E y A con frecuencia tiene un punto de vista distinto sobre lo que es posible 
financieramente. Una persona del cuadrante E o A con frecuencia está dispuesta a trabajar 
duro para siempre, sin preguntarse nunca realmente si existe otra forma de lograr lo que 
quiere lograr. Así que la razón por la que recomiendo la industria de la mercadotecnia en 
red y sus programas educativos es principalmente para dar a los individuos una oportunidad 
de abrir su contexto a otros puntos de vista.
Por cierto, la ganancia de 35 por ciento de mi amigo se convirtió en una ganancia negativa 
después de marzo de 2000. Ahora está enojado con Alan Greenspan, el presidente de la 
Oficialía de la Reserva Federal, y está esperando y rezando para que el mercado regrese. Si 
no lo hace, es probable que mi amigo tenga que volver a trabajar.
¿Por qué no hay más gente que cree negocios del cuadrante D?
La pregunta es: ¿si crear un negocio del cuadrante D es tan lucrativo, entonces por qué no 
hay más gente que lo haga? Una parte de la respuesta se encuentra en la siguiente lección de 
mi padre rico.
Cuando estaba tomando mi decisión de empezar mi primer negocio real del cuadrante D, le 
pregunté a mi padre rico: "Si crear negocios es el juego más rico del mundo, por qué no hay 
más personas que jueguen ese juego? ¿Es por la falta de dinero, habilidades o talento?"
La respuesta de mi padre rico fue breve y al grano. Dijo "Lo más difícil sobre los negocios 
es trabajar con la gente".
"¿La gente?", repliqué. "¿Trabajar con la gente es la parte más difícil del negocio?"
Mi padre rico asintió y dijo: "La mayoría de las personas no pueden crear un negocio 
simplemente porque carecen de habilidades para el trato con gente. La gente trabaja con otras 
personas todo el día, pero sólo porque trabajan juntas no significa que pueden empezar un 
negocio juntas. Y sólo porque empiecen un negocio juntas no quiere decir que el negocio 
crecerá y se convertirá en un negocio grande".
"¿Así que si aprendo a trabajar con la gente, puedo jugar el juego más rico del mundo?"
Mi padre rico asintió.
Si puedes trabajar con diferentes personas puedes volverte más rico 
de lo que has soñado en tu vida
Con los años, mi padre rico pasó una cantidad sustancial de tiempo enseñándonos a su hijo 
y a mí cómo trabajar y lidiar con diferentes tipos de personas. Si leíste Niño Rico, Niño Lis-
to, probablemente recuerdes que mi padre rico con frecuencia hacía que su hijo y yo nos 
sentáramos con él mientras entrevistaba personas. Aprender a contratar y despedir personas 
fue un proceso de aprendizaje interesante, en especial cuando las personas que mi padre rico 
contrataba y despedía tenían la edad de mi mamá y mi papá. Para él, enseñarnos a su hijo y a 
mí cómo tratar con los distintos tipos de personas fue una de las ventajas iniciales educativas 
más importantes que podía darnos. Solía decir: "Si puedes trabajar con diferentes personas, 
puedes volverte más rico de lo que has soñado en tu vida".
Quienes leyeron El Cuadrante de FLUJO DE EFECTIVO de Padre Rico, recordarán lo 
importante que era para mi padre rico este simple diagrama.
Mi padre rico había creado este diagrama para ilustrar su punto de que el mundo de los 
negocios está constituido de cuatro tipos distintos de personas. El cuadrante E representa a 
los empleados, el A es para los pequeños negocios o auto empleados, el cuadrante D es el de 
los dueños de negocios y el cuadrante I, el de los inversionistas.
El punto principal de este diagrama era que las personas de los diferentes cuadrantes son en 
esencia diferentes. Mi padre rico solía decir: "Para tener éxito en el cuadrante D, necesitas 
saber cómo comunicarte y trabajar con las personas de todos los cuadrantes. Es el único 
cuadrante que requiere absolutamente de esa habilidad". En otras palabras, una de las 
razones por las que tantos negocios fracasan es porque el empresario con frecuencia es 
incapaz de trabajar y llevarse bien con los diferentes tipos de personas.
Durante la década de los ochenta, estuve de vuelta en Hawai, y mi padre rico me invitó a estar 
presente en una reunión de miembros de una junta directiva de la cual él era uno de los 
directores. La compañía estaba en problemas y quería que yo aprendiera de esa experiencia 
desagradable. La compañía era una empresa pequeña que estaba empezando; buscaba 
petróleo en Canadá. Mi padre rico no formó la compañía, pero ahora ésta estaba en 
problemas y había sido invitado a unirse a la junta directiva para ver si la compañía se 
podía salvar.
La compañía se metió en problemas debido a una decisión del director general de finanzas. 
Esa decisión había dejado muy endeudada a la compañía y casi a punto de la bancarrota. 
Después de que comenzó la reunión, mi padre rico preguntó al resto de la junta: "¿Por qué 
permitieron que él [el director general de finanzas] tomara una decisión financiera tan grande 
sin verificarlo con la junta directiva?"
La respuesta de otro miembro de la junta fue: "Porque era un vicepresidente ejecutivo de X 
Compañía de Petróleo Gigantesca".
Mi padre rico levantó la voz y dijo: "¿Y qué? ¿Y qué si en una época fue el vicepresidente 
ejecutivo de una gran compañía de petróleo?"
"Bueno, pensamos que sabía mucho más que nosotros. Así que lo dejamos actuar por su 
cuenta", dijo otro miembro de la junta directiva.
Mi padre rico dio golpecitos a la mesa con los dedos y luego dijo: "Puede que haya sido 
vicepresidente ejecutivo pero de cualquier forma fue empleado durante 30 años. Era 
empleado de una compañía grande. No tiene la menor idea de cómo dirigir un negocio 
pequeño que está empezando y que tiene un presupuesto muy limitado. Les recomiendo que 
lo reemplacen, preferentemente por alguien que haya sido dueño de su propia compañía y 
que haya tenido responsabilidades financieras completas, aunque no fuera en una compañía de 
petróleo. Hay una diferencia muy grande entre un empleado y un empresario sin importar de 
qué industria venga. Hay una diferencia muy grande entre dirigir una empresa pequeña y 
una empresa grande. En una empresa grande un error de este tamaño no lastima la 
compañía. En una compañía pequeña, un error de este tamaño destruye la compañía".
La compañía finalmente se fue a la bancarrota. Un año después, le pregunté a mi padre rico 
por qué finalmente se había ido para abajo. Me dijo: "La compañía estuvo muy mal ma-nejada desde los directores de la junta hacia abajo. Aunque ésta había contratado personal 
excelente y le había pagado mucho dinero, ese personal nunca se convirtió en un gran equipo. 
Los empresarios exitosos crean excelentes equipos. Así es como compiten con grandes 
compañías que tienen más dinero y más personal".
Las diferentes habilidades
En el libro número tres, Guía para invertir de Padre Rico, escribí sobre el Triángulo DI de 
mi padre rico, que se reproduce en la página siguiente.
El Triángulo DI es importante para cualquiera que quiera comenzar un negocio del cuadrante D 
o que ya tenga uno. También es importante para cualquiera que tenga una idea que valga un 
millón de dólares y planee convertirla en un negocio. En otras palabras, una de las razones 
por las que las personas tienen dificultades para empezar un negocio del cuadrante D es 
porque un verdadero negocio necesita más de una habilidad o especialidad.
Nuestro sistema escolar produce personas especializadas en esas habilidades. Se requiere de 
un verdadero empresario para juntar esas habilidades y hacer que funcionen como un equipo 
con el fin de construir una compañía con poder.
El gran problema
El gran problema va más allá de simplemente tener los cuatro cuadrantes en tu negocio y 
tener las diferentes habilidades técnicas del Triángulo DI. El problema es encontrar un líder, 
un empresario que pueda conseguir que esas diferentes personas con diferentes habilidades 
y diferentes valores esenciales trabajen juntas como un equipo. Por eso mi padre rico decía: 
"Lo más difícil de los negocios es trabajar con la gente".
También decía: "Los negocios serían fáciles si no fuera por las personas".
En otras palabras, un empresario primero debe ser un gran líder y todos podemos trabajar 
para mejorar nuestras habilidades de liderazgo.
¿Qué es un empresario?
Mi padre rico nos enseñó a su hijo ya mí a ser empresarios. Cuando le pregunté qué era un 
empresario, dijo: "Un empresario ve una oportunidad, reúne un equipo, crea un negocio que 
se beneficia de esa oportunidad".
Luego le pregunté: "¿Qué tal si veo una oportunidad y no puedo aprovecharla por mí 
mismo?"
"Excelente pregunta", dijo mi padre rico. "Si ves una oportunidad y no puedes aprovecharla 
tú mismo, entonces eres un pequeño negociante o un auto empleado".
Mi padre rico prosiguió explicando la diferencia entre un comerciante y un empresario. 
Dijo: "Un comerciante o artesano es alguien que produce un producto o proporciona un 
servicio principalmente para sí mismo. Por ejemplo, un artista puede pintar un retrato él 
mismo o un dentista te puede arreglar los dientes él mismo. Un empresario debe ser capaz de 
reunir personas inteligentes de diferentes mundos y disciplinas y hacer que trabajen juntas 
para alcanzar una meta común. En otras palabras, un empresario construye equipos que se 
encargan de productos que ningún individuo podría hacer por sí mismo. La razón por la que 
la mayoría de las personas siguen siendo pequeñas es porque resuelven problemas que 
pueden resolver por sí mismas".
"Así que un empresario asume una tarea que requiere de un equipo", dije. "A una persona del 
cuadrante D no se le paga a menos de que su equipo pueda hacer lo que se necesita hacer 
como equipo. A la mayoría de los empleados y autoempleados les pagan por lo que pueden 
hacer como individuos. A un empresario no se le paga a menos de que su equipo sea 
exitoso".
Mi padre rico asintió y explicó con más detalle, diciendo: "De la misma manera en que un 
contratista usa comerciantes como plomeros, electricistas, carpinteros y profesionistas como 
arquitectos y contadores para construir una casa, un empresario reúne a diferentes 
comerciantes, técnicos y profesionistas para que le ayuden a crear un negocio".
"¿De modo que en tu opinión un empresario es en realidad el líder de un equipo, aunque 
puede ser que no trabaje físicamente en el equipo?", pregunté.
"Entre mejor puedas dirigir a un equipo de personas inteligentes y calificadas, sin tener que 
trabajar como parte del equipo, mejor y mayor empresario podrás ser", dijo mi padre rico. 
"Yo soy dueño de varias compañías, pero no hago nada de trabajo dentro de la compañía. 
De esa manera puedo hacer más dinero y hacer más cosas sin tener que hacer el trabajo. Por 
eso el liderazgo es un habilidad esencial que se requiere para ser un verdadero empresario".
"¿Las habilidades de liderazgo se pueden aprender?", pregunté.
"Sí", dijo mi padre rico. "He notado que todos tenemos algunas habilidades de liderazgo. El 
problema con la mayoría de las personas es que dedican su vida a desarrollar sus habilida-des profesionales o las correspondientes a su carrera, razón por la cual hay más personas en 
los cuadrantes E y A. Muy pocas personas dedican su vida a desarrollar sus habilidades de 
liderazgo, que es la habilidad que más se requiere para el cuadrante D. De modo que, sí, el 
liderazgo puede ser aprendido".
Años después mi padre rico dijo: "Los líderes se enfrentan a los retos mientras que los demás 
buscan un trabajo seguro".
Lecciones de liderazgo de Vietnam
Es probable que algunos de ustedes sepan que fui a Vietnam por varias razones. Una fue 
que mis dos padres pensaban que era obligación de sus hijos defender y pelear por su país. 
Otra razón era para aprender habilidades de liderazgo. Mi padre rico decía: "Pedir a los 
soldados que superen sus miedos y se desempeñen valerosamente sometidos a intensa 
presión y arriesgando su vida es una prueba de las habilidades de liderazgo de cualquiera". 
Mientras estaba en Vietnam, vi a hombres que hicieron cosas horribles, pero también vi a 
hombres que desempeñaron hazañas de valor que nunca olvidaré. Uno de mis comandantes 
en jefe decía: "Dentro de cada soldado hay un héroe. Es tarea del líder sacar al héroe que 
vive en cada uno de nosotros". Hoy en día, en mis negocios, uso muchas de las habilidades 
de liderazgo que aprendí en combate. En combate, no dábamos órdenes a los jóvenes y 
esperábamos que las siguieran ciegamente. En combate, aprendimos a pedirles a los jóvenes 
que fueran héroes y esa habilidad funciona en los negocios al igual que en combate.
Desarrolla tus propias habilidades de liderazgo
No tienes que ir a la guerra para desarrollar tus habilidades de liderazgo. Lo único que 
tienes que hacer es asumir los retos de los que otros huyen. La mayoría hemos escuchado el 
dicho que dice: "Nuca te ofrezcas como voluntario para nada". Para mí, ése es el credo de 
una persona que va hacia atrás en la vida. Mi padre rico decía con frecuencia: "Los líderes 
asumen retos que otros temen". También decía: "El tamaño del líder se mide con el tamaño 
de la tarea que asume". Dwight Eisenhower es famoso porque asumió el mando el día del 
desembarco en Normandía y la campaña europea durante la Segunda Guerra Mundial. John 
Kennedy asumió la tarea de poner a un hombre en la luna. Los líderes buscan retos de los 
que otros se alejan. Demasiadas personas nunca desarrollan sus habilidades de liderazgo 
simplemente porque convierten en hábito el alejarse de los retos que se colocan frente a 
ellos. Convierten en hábito el nunca ofrecerse como voluntarios.
Todo negocio, toda iglesia, toda caridad, toda comunidad necesita más líderes. Cada 
organización te da la oportunidad de ofrecerte y ser responsable. Cada oportunidad te da una 
oportunidad de aprender esas invaluables habilidades de liderazgo que se requieran en el 
mundo empresarial.
Muchas personas no están calificadas para participar en el juego más rico del mundo, el 
juego de crear negocios, simplemente porque no logran obtener las habilidades de 
liderazgo.
Si te ofreces para hacerte cargo de la sencilla cena de tu iglesia, te estás ofreciendo para 
obtener más habilidades de liderazgo. Aunque nadie se ofrezca como voluntario para ha-cerlo contigo, aprenderás algo importante. Aprenderás cómo llegarle y cómo hablarle al 
héroe que se encuentra dentro de todos y cada uno de nosotros. Si aprendes a hacerlo, la 
siguiente tarea de liderazgo que realices será más sencilla, más exitosa y aprenderás más 
sobre liderazgo. Si no desarrollas  tus habilidades de liderazgo, es probable que las 
posibilidades de que crees un negocio y de que participes en el juego más rico de todos no 
se desarrollen nunca. He conocido demasiadas personas inteligentes con excelentes ideas de 
negocios, pero que simplemente carecen de habilidades de liderazgo, la habilidad que se 
requiere para crear un equipo de negocios y para hacer que ese equipo convierta sus ideas 
en millones, quizá miles de millones de dólares. En el juego más rico del mundo, el 
liderazgo es la clave, porque se necesita a un líder, para convertir en un equipo a los 
individuos.
Lecturas sugeridas
Hay varios libros que he leído que pueden ayudar al desarrollo empresarial de una persona. 
Son los siguientes:
1.The Monk and the Riddle {El monje y el acertijo) de Randy Komisar (Harvard Business 
School Press). Este libro me lo regaló mi amigo Tom, mi corredor de bolsa. Tom es un 
excelente negociante de opciones pero es mejor para elegir pequeñas compañías que están 
empezando e invertir en ellas a medida que se hacen cada vez más grandes. Él me dio este 
libro en el momento en que estaba listo para vender una de mis compañías y seguir 
adelante. Después de leer el libro, me quedé con la compañía y comencé a construirla en 
lugar de venderla. Es un excelente libro sobre los grandes acertijos de la vida.
2.First, BreakAll the Rules {Primero, rompe todas las reglas) de Marcus Buckingham y Curt 
Coffman (Simón and Schuster). Es un libro excelente para cualquiera que maneje o sea líder 
de un grupo de personas. Este libro está basado en entrevistas a profundidad realizadas por 
la Organización Gallup a más de 80 000 gerentes de más de 400 compañías. En la Era 
Industrial, manejar personas era como pastorear ovejas. Hoy en día, en la Era de la 
Información, manejar personas es como pastorear gatos. Esto significa que actualmente cada 
persona necesita ser tratada como un individuo en lugar de como parte de un grupo. Este 
libro proporciona excelentes reflexiones sobre cómo lidiar con diferentes tipos de personas 
que van en diferentes direcciones y convertirlas en un equipo.
3.Emocional Branding {Marcas emocionales) de Daryl Travis (Prima Publishing). ¿Qué es el 
valor de una marca? Hace poco leía que la planta, el equipo y otros activos de capital de Coca 
Cola valían aproximadamente ocho mil millones de dólares, mientras que la marca vale 80 
mil millones.
Uno de los beneficios menos conocidos de invertir el tiempo necesario para crear un negocio 
es el beneficio de crear también una marca. En el mundo de competencia global cada vez 
mayor, entre mejor seas para crear un negocio así como para crear una marca, más rico te 
volverás.
Imagina por un momento el poder que IBM tiene sobre X Computadoras. X puede tener una 
mejor computadora, pero IBM tiene una mejor marca. Nosotros en richdad.com nos damos 
cuenta de que nuestro valor va mucho más allá de nuestros libros, juegos y demás 
productos. Estamos muy conscientes de crear una marca mundial así como de crear un 
negocio.
4. Protecting Your #7 Asset {Protegiendo tu activo #7) de Michael Lechter (Warner Books). 
Este libro pertenece a la serie de libros de los Asesores de Padre Rico. Michael Lechter es 
mi abogado. También es el esposo de mi socia de negocios y coautora, Sharon Lechter. 
Michael es uno de los abogados más importantes en cuanto a propiedad intelectual como 
marcas, marcas registradas y patentes. Como podrás darte cuenta a partir del ejemplo de 
Coca Cola, una marca o una idea pueden valer millones de dólares.
Quienes tienen en la cabeza una idea millonaria para un negocio o un producto no deben 
dejar de leer este libro. Tu activo número uno en la Era de la Información son tus ideas. Antes 
de divulgarlas, es importante que leas este libro. Los honorarios de Michael son altos, de 
modo que este libro es una ganga en información invaluable.
5. SalesDogs (Vendedores perros) de Blair Singer (Warner Books). Este libro también 
pertenece a la serie de libros de los Asesores de Padre Rico. Blair Singer ha sido uno de mis 
mejores amigos por más de veinte años. Blair y yo comenzamos juntos como vendedores 
peinando las calles de Hawai, buscando negocios.
Uno de los procesos educativos más importantes por los que pasé fue en primer lugar 
aprender a vender y en segundo aprender a manejar un equipo de más de 350 vendedores, 
esparcidos por Estados Unidos y Canadá. Era un trabajo duro pero aprendí mucho en el 
proceso. Comencé siendo un terrible vendedor y un terrible gerente de ventas. El proceso de 
aprender cómo ser un buen vendedor y un buen gerente de ventas fue invaluable aunque a veces 
fue doloroso.
El libro de Blair es esencial para cualquiera que quiera mejorar sus habilidades de ventas 
personales, una habilidad esencial para cualquiera que trabaje con gente y necesite dirigirla. Este 
libro también es importante para gerentes de ventas, porque aprender cómo manejar a un 
equipo de vendedores es una tarea en sí misma. Si el manejo de gente actualmente es como 
manejar gatos, manejar a un equipo de ventas es como manejar a un equipo de perros, perros con 
diferentes ladridos y diferentes hábitos. Por esa razón el libro se titula Vendedores perros porque 
una sala llena de vendedores en realidad es como una perrera, más que una oficina. Este libro 
ofrece reflexiones muy importantes sobre administración y negocios, envueltas en una 
visión humorística de los diferentes perros que constituyen un equipo de ventas.
Vendedores perros es un libro importante para cualquiera que quiera mejorar su habilidad de 
negocios número uno, que es la habilidad de ser capaz de vender una idea a otras personas. 
En mi vida, he conocido a muchas personas inteligentes que luchaban financieramente 
simplemente porque no podían vender ni manejar a otras personas.
Un tip de la Infantería de Marina
Cuando recién me habían nombrado teniente de Marina en Vietnam, un comandante en jefe 
me dio el siguiente diagrama:
Misión
Equipo
Individuo
Dijo: "La mayor prioridad es la misión. El individuo es lo último".
Después de regresar de Vietnam, con frecuencia vi a más personas con un rango de 
prioridades diferente. Fin los negocios y en el mundo civil, con frecuencia veo gente que 
tiene una lista con el siguiente rango de prioridades:
Individuo Equipo Misión
En otras palabras, ellos están primero, su grupo en segundo lugar y la misión completa del 
negocio o la organización se encuentra al último, si es que se aparece.
En Vietnam, mi comandante en jefe explicó que, como oficiales subalternos, nuestro 
trabajo consistía en proteger la misión y el equipo de las traiciones de los individuos. En 
otras palabras, nos entrenaron para deshacernos, de una u otra forma, de cualquiera dentro 
de nuestras filas que pensara en sí mismo primero y que, al hacerlo, pusiera en riesgo al 
equipo y a la misión. Aprender y practicar eso en combate afectó mucho mi forma de ser líder 
en los negocios.
Para quienes vieron la película de Steven Spielberg, Rescatando al soldado Ryan, en mi 
opinión la película más realista que he visto sobre la guerra, hay una gran moraleja en la 
película. En ella, Tom Hanks, un maestro de escuela que se convirtió en teniente del ejército, 
no pudo dispararle a un prisionero alemán. Para mí, ése fue el punto fundamental de la 
película... y también una de sus grandes moralejas. Como Tom Hanks no pudo hacer su 
trabajo, que en este caso era deshacerse de un individuo, el prisionero alemán, se puso en 
gran riesgo a sí mismo, a su equipo y a la misión del equipo. Al final, no sólo muchos de sus 
hombres fueron asesinados debido a su incapacidad de matar al prisionero alemán, sino que 
la misión casi fracasa y al final Tom Hanks es asesinado por el hombre a quien él no pudo 
matar.
Es una suerte que la mayoría de las personas nunca tendrán que enfrentar los horrores de la 
guerra ni algunas de las difíciles decisiones que te rompen el corazón que con frecuencia hay 
que tomar. No obstante, todos enfrentamos decisiones difíciles en nuestra vida personal y en 
nuestra vida de negocios. Algunos ejemplos son los siguientes:
1. La otra noche en una fiesta en casa de un amigo uno de los invitados se emborrachó mucho. 
Cuando se puso de pie para irse, el anfitrión le pidió que le entregara las llaves del coche y se ofreció a 
llamar a un taxi. El invitado se alteró mucho, negando que estaba demasiado borracho para manejar. 
Se dio una escena desagradable y el anfitrión persistió, al final luchando contra el huésped en el piso 
y quitándole las llaves por la fuerza. Llamaron un taxi y mandaron a casa al invitado, seguro, pero 
muy alterado. El invitado y el anfitrión no se han hablado desde entonces. Para empeorar todavía 
las cosas, algunos de los demás invitados piensan que el anfitrión reaccionó de manera exagerada y 
ellos también han decidido no hablarle. Personalmente, pienso que el anfitrión fue muy valiente e 
hizo lo mejor que pudo hacer en ese momento. ¿Podía haber manejado las cosas de manera diferente? 
Claro. Pero hizo lo que pensaba que era mejor en ese momento. Eso es lo que hacen los líderes, 
incluso si lo que tienen que hacer no es lo mejor.
2. Hace años, mi padre rico descubrió que uno de sus gerentes más importantes estaba teniendo una 
aventura con una de las secretarias de su compañía. De inmediato, llamó al hombre y le pidió que se 
fuera. También le pidió que se fuera a la secretaria. Cuando le pregunté por qué, simplemente dijo: 
"Los dos están casados y tienen hijos. Cualquiera capaz de engañar a su cónyuge y a sus hijos es 
alguien que engañaría a cualquiera". No estoy diciendo que mi padre rico haya hecho lo correcto, 
pero, de nuevo, hizo lo que pensaba que era lo mejor en ese momento. Aunque ambos empleados eran 
muy importantes para él, sintió que sus acciones no estaban en el nivel de los valores que él quería 
para su compañía. Decía: "Cuando tomo una decisión, todos los demás saben en dónde están 
parados".
Las dos historias son ejemplos de liderazgo. Se ha dicho que "los líderes hacen las cosas 
correctas y los gerentes hacen las cosas de manera correcta". Mi padre rico estaba de 
acuerdo con esa afirmación. Decía: "El liderazgo no es un concurso de popularidad. Los 
líderes inspiran a otros para ser líderes".
Una lección final de Vietnam
Al final de su plática con los oficiales subalternos, mi comandante en jefe añadió las 
siguientes palabras a su plática y a su diagrama:
El comandante en jefe dijo después: "Un líder es responsable con la misión, con el equipo y 
con los individuos. Pero, como puedes ver, un buen líder también debe ser un buen se-guidor... dándose cuenta de que la misión de su equipo es importante porque es parte de una 
misión más grande y que responde a una llamada mayor".
Mi padre rico decía: "Una honda es sólo una honda. Cuando David se ofreció a encargarse de 
Goliat, las mayores fuerzas del mundo se ofrecieron con él". También decía: "Siempre re-cuerda que el juego más rico del mundo es sólo un juego con una misión y una llamada 
mayor".
Así que, para cerrar, te dejo con este pensamiento. Todos los días sin excepción, nacen 
nuevos Goliats y nuevos Goliats se ofrecen. Lo que necesita el mundo son Davides cada 
vez más poderosos, armados con tan sólo una honda, pero respaldados por las fuerzas más 
poderosas del mundo. Sin importar si eliges jugar el juego más rico del mundo o no, sólo 
debes saber que tú también puedes tener acceso al poder de la honda de David. Lo único 
que tienes que saber es quién es tu Goliat y luego encontrar el valor para dar un paso adelante 
con valentía. En el momento en que lo haces, empiezas a jugar el juego más rico del mundo, 
un juego en donde las recompensas son mucho más importantes que el dinero. Cuando das 
un paso adelante tomas el poder que estaba detrás de la honda de David. Cuando encuentres 
ese poder, tu vida nunca volverá a ser la misma. Como decían en La guerra de las galaxias, 
la versión moderna de David y Goliat: "Que la fuerza esté contigo". Esa fuerza invisible es 
el mayor apalancamiento de todos y está disponible para todos nosotros. Lo único que 
tienes que hacer es dar un paso adelante y asumir algo mayor que tú mismo.
La conclusión de este libro es sobre las recompensas de construir o adquirir activos que 
trabajen duro para que tú no tengas que hacerlo.
CAPÍTULO 19 
Excelentes tips
Cosas que la mayoría de las personas pueden hacer para hacerse ricas 
rápidamente y mantenerse ricas para siempre
El proceso de retirarte joven y rico es un proceso mental y emocional, más que un proceso 
físico. Si estás preparado mental y emocionalmente, lo que tienes que hacer físicamente es 
muy poco. Los siguientes son algunos procesos mentales y emocionales extra que 
probablemente querrás incorporar a tu vida. Si regularmente llevas a cabo esos sencillos 
procesos que se sugieren y se convierten en parte de tu vida, confío en que retirarte joven y 
rico se convertirá en una posibilidad más real para ti.
¿Por qué necesitas un cheque quincenal?
Cuando estaba en la preparatoria, mi padre rico con frecuencia hacía que me sentara junto a 
él cuando llegaban personas que solicitaban un empleo. Durante una de esas entrevistas, un 
hombre pocos años mayor que él llegó  para hacer una solicitud para un puesto 
administrativo en una de las compañías de mi padre rico. Ese solicitante tenía alrededor de 
45 años, estaba bien preparado, tenía un curriculum impresionante, un excelente historial 
de empleo, estaba bien vestido y parecía seguro y competente. A medida que progresaba la 
entrevista, ese caballero continuamente le recordaba a mi padre rico que había asistido a 
una excelente universidad estatal y que había  recibido  su título  de maestría en 
administración de empresas por parte de una prestigiada universidad de la Costa Este, con 
honores.
"Tengo interés en contratarlo", dijo mi padre rico, después de entrevistarlo durante 
aproximadamente una hora. "Pero, ¿por qué quiere un sueldo tan alto?"
De nuevo, el solicitante hizo referencia a su impresionante preparación y a su historial de 
trabajo, diciendo: "Estoy bien preparado, tengo la experiencia de trabajo adecuada, lo que 
me hace estar altamente calificado para el empleo y me hace merecedor del sueldo".
"No estoy en desacuerdo", dijo mi padre rico. "Pero déjeme preguntarle lo siguiente. Si usted 
está tan bien preparado y tiene tanta experiencia, ¿por qué necesita un empleo? Si es tan 
inteligente, ¿por qué necesita un cheque quincenal?"
Esta pregunta desconcertó al solicitante. Tartamudeó un poco y luego dijo: "Bueno, todo el 
mundo necesita un empleo. Todos necesitamos un cheque quincenal".
La habitación se quedó muy silenciosa mientras mi padre rico dejaba que su respuesta hiciera 
eco. Era obvio que el solicitante provenía de una realidad diferente, de un contexto diferente, 
de una mentalidad diferente a la de mi padre rico. Se estaba llenando de argumentos y estaba 
comenzando a defender su realidad, en vez de tratar de entender la realidad de mi padre rico. 
Mirando al solicitante, mi padre rico dijo con tranquilidad: "Yo no. Si el negocio se 
desplomara, yo de todas formas nunca necesitaría un cheque quincenal". Luego se volvió 
hacia su hijo y hacia mí y dijo: "Esos chicos no. Trabajan para mí gratis. Por eso un día van a 
ser mucho más ricos que usted, incluso si no asisten a una escuela tan buena como a la que 
usted asistió o si no reciben los honores académicos que usted tiene. No quiero que esos chicos 
quieran o necesiten nunca un cheque quincenal". Con eso, mi padre rico tomó el curriculum 
del solicitante, lo colocó encima de una pila de otros currículos y dijo: "Lo llamaré si estoy 
interesado en contratarlo". La entrevista terminó.
Tips sobre cómo hacerse rico rápidamente
En Padre Rico, Padre Pobre, escribí sobre cómo mi padre rico tomó mi trabajo de diez 
centavos por hora y me ofreció su realidad, la realidad de que podía hacerme rico más 
rápidamente si trabajaba gratis. La gente con frecuencia dice: "En realidad tú no trabajaste 
gratis" o "mi casa es un activo". Poco saben que a pesar de haber leído el libro siguen viendo 
el mundo desde su misma realidad, contexto o mentalidad.
Cuando mi padre rico preguntó al solicitante "si usted está tan bien preparado y tiene tanta 
experiencia, ¿por qué necesita un empleo? Si es tan inteligente, ¿por qué necesita un cheque 
quincenal?", le estaba pidiendo que expandiera su realidad. Sin embargo, en vez de hacer su 
mejor esfuerzo para expandir su realidad, el solicitante discutió y defendió su realidad, su 
mentalidad cerrada y, por todo propósito práctico, acabó con sus posibilidades de que mi 
padre rico lo empleara.
Un mundo sin cheques quincenales
Creé el juego CASHFLOW para enseñarle a la gente cómo vivir en un mundo sin cheques 
quincenales. Las personas que juegan repetidamente, con frecuencia descubren que la 
posibilidad de un mundo así es mucho más emocionante que trabajar duro toda su vida para 
obtener un cheque quincenal. Si quieres retirarte lo más joven y rico posible, necesitarás 
considerar la existencia de un mundo sin cheques salariales. Si en tu realidad, contexto o 
mentalidad necesitas un cheque salarial, las posibilidades de retirarte joven y rico son pocas. 
Mi padre rico decía con frecuencia: "Las personas que necesitan un cheque quincenal son 
esclavas del dinero. Si quieres quedar en libertad, nunca debes necesitar un salario ni un 
empleo". Así que, si deseas en serio retirarte joven y rico, tú también necesitarás cambiar tu 
realidad a la posibilidad de un mundo sin una paga ni un empleo fijo. Cuando cito este 
contexto a la mayoría de las personas, casi puedes sentir cómo se eleva su presión arterial, 
cómo se endurece su pecho y su estómago y casi puedes escuchar cómo su mente 
subconsciente se apodera de su pensamiento consciente. El miedo de no tener una paga 
segura para cubrir su supervivencia financiera es un miedo que la mayoría conocemos bien. 
Si tienes dificultades para verte en un mundo donde no se necesita una paga o un empleo 
seguro, entonces tu primer paso es comenzar preguntándote: "¿Cómo puedo hacerme rico sin 
una paga o un empleo fijos?" En el momento en que comienzas a hacerte esa pregunta, 
abres tu mente y comienzas tu viaje hacia otra realidad.
Cuando mi padre rico le preguntó a la persona que solicitaba el empleo: "Si usted está tan 
bien preparado y tiene tanta experiencia, ¿por qué necesita un empleo? Si es tan inteligente, 
¿por qué necesita un salario?", le estaba pidiendo que extendiera su realidad y viera otra 
realidad. En cambio, el solicitante discutió y defendió su realidad, pensando que era la única. 
He visto a mi padre rico haciéndole la misma pregunta a otros solicitantes. Era su manera de 
tratar de ayudar al solicitante. Era su manera de intentar enseñarle una lección financiera muy 
básica y muy importante, la lección de que el dinero no te hará rico... de que un empleo muy 
bien remunerado por sí mismo no soluciona las necesidades financieras de una persona. 
Cuando mi padre rico le hacía esa pregunta a cualquiera, estaba tratando de hacer que esa 
persona entendiera que el éxito académico no necesariamente es igual al éxito financiero. 
Como decía a menudo: "Un coeficiente intelectual académico alto no necesariamente 
significa que tienes un coeficiente intelectual financiero alto". Durante las entrevistas con la 
persona que estaba tan orgullosa de sus logros financieros, en realidad mi padre rico estaba 
haciendo su mejor esfuerzo para descubrir si esa persona estaba interesada en aprender 
cómo elevar su coeficiente intelectual financiero. Como dije, he visto a mi padre rico 
hacerle esa misma pregunta a otros solicitantes. Quienes escuchaban su realidad y 
estudiaban con mi padre rico mientras trabajaban con él se hicieron muy ricos, se retiraron 
pronto y vivieron vidas de libertad financiera... aunque no les pagaron los salarios altos que 
querían en un inicio.
El punto es el siguiente: Si quieres retirarte joven y rico, el coeficiente intelectual financiero 
es más importante que el académico. Los siguientes son realmente tips de cómo incrementar 
tu coeficiente intelectual financiero para que puedas empezar a vivir en un mundo sin 
necesidad de cheques con sueldos. Entre más pronto puedas ver un mundo sin cheques con 
sueldos, mejores oportunidades tendrás de hacerte rico más rápido.
Tip excelente #1
Así que el tip excelente #1 es empezar a verte en un mundo o realidad donde nunca más 
necesitarás un salario ni un empleo. No significa que no trabajarás nunca más, simplemente 
significa que dejarás de estar tan necesitado financieramente o incluso desesperado, 
vendiendo tu preciosa vida por un poco de dinero, viviendo con el miedo de perder el 
cheque quincenal o incluso ser sustituido.
Una vez que puedes visualizar un mundo en donde nunca más necesites un salario, comenzarás 
a ver el otro mundo... el mundo sin empleos ni pagas.
Bill Gates está mal pagado
Hace unos años, vi un encabezado que decía: "Bill Gates no es el hombre mejor pagado del 
mundo". El artículo decía que hay muchos ejecutivos en el mundo de los negocios a quienes 
se les paga mucho más que a Bill Gates y, no obstante, él es el hombre más rico del mundo. 
El artículo afirmaba que, en ese momento, a Gates sólo se le pagaban alrededor de 500 000 
dólares al año, pero que su base de activos era de miles de millones y estaba creciendo.
Tip excelente #2
Si te deshaces de la idea de que necesitas un salario fijo por un ingreso ganado, la siguiente 
pregunta que debes hacerte es qué tipo de ingreso quieres. Por ejemplo, antes en este libro 
afirmé que existen tres tipos básicos de ingreso, los cuales son:
1.Ganado - dinero a 50 por ciento
2.Portafolio - dinero a 20 por ciento
3.Pasivo - dinero a 0 por ciento
Ésas son las tres categorías principales, sin embargo, hay muchos otros tipos de ingreso. La 
mayoría de las personas se pasan la vida estudiando y trabajando duro para obtener un 
ingreso ganado, razón por la cual tan pocas personas se retiran jóvenes o ricas. Si deseas en 
serio retirarte joven, comienza a estudiar los diferentes tipos de ingreso, que te permiten 
hacerte rico sin trabajar para siempre. Algunos de los demás tipos de ingreso son los 
siguientes:
4.Ingreso residual, que es el ingreso de un negocio, como los negocios de mercadotecnia en red o 
los negocios en franquicia que tienes pero que alguien más dirige.
5.Ingreso de dividendos, que puede ser el que proviene de acciones.
6.Ingreso de intereses, es el que proviene de ahorros o bonos.
7.Ingreso de regalías, puede ser el que proviene de canciones o libros que has escrito y de marcas e 
inventos (sean o no patentables) que has creado.
8.Ingreso de instrumentos financieros, como el que proviene de escrituras fiduciarias de bienes 
raíces
Así que el tip excelente es que, una vez que te acostumbres a la idea de no tener el ingreso 
de un empleo o de tu mano de obra, entonces podrás comenzar a investigar los distintos 
tipos de ingreso que provienen de distintos tipos de activos. Mi padre rico quería que Mike y 
yo estudiáramos e investigáramos los diferentes tipos de ingreso y que luego decidiéramos 
qué tipo queríamos estudiar con mayor profundidad.
Puedes ir a la biblioteca o preguntarle a tu contador sobre los diferentes tipos de ingreso que 
hay... ingreso que se deriva de otras cosas además de tu mano de obra. En el momento en 
que comiences a estudiar y a encontrar los diferentes tipos de ingreso que te interesan, éstos 
comienzan a crecer para hacerse parte de tu nueva realidad que se está expandiendo.
El punto es no hagas demasiado. Simplemente deja que los demás tipos de ingreso y activos 
entren en tu realidad. Entre más se establece la idea de los diferentes tipos de ingreso, entre 
más piensas sobre tal ingreso, sin la presión de tener que hacer algo, más se arraiga en tu 
cerebro la idea y comienza a crecer. La mayoría de las personas piensan que deben hacer 
algo de inmediato, pero ésa no es mi experiencia. Yo simplemente dejé que la idea de invertir 
en bienes raíces para obtener ingreso pasivo me rondara en la mente años antes de comprar 
mi primera propiedad. Un día me desperté y supe que era momento de comenzar a tomar 
clases y comenzar a invertir. Relativamente no requirió de ningún esfuerzo... pero sólo 
después de que dejé que la idea se volviera parte de mi nueva realidad.
Cuando ves un estado financiero, es comprensible por qué mi padre pobre insistía en tener 
un empleo seguro.
Como mi padre pobre no tenía activos y siempre decía: "Invertir es arriesgado", naturalmente 
se aferraba desesperadamente a su empleo. Después de todo, eso era lo único que tenía y el 
único ingreso que conocía era el ingreso ganado.
Mi padre rico hizo que su hijo y yo enfocáramos nuestra atención en adquirir activos y en 
desarrollar nuestro coeficiente intelectual financiero por medio del cual íbamos a adquirir 
nuestros activos. Como habíamos adquirido la importancia del  coeficiente intelectual 
financiero, su hijo y yo trabajamos diligentemente incrementando siempre nuestras 
habilidades para adquirir esos activos. Aunque estábamos nerviosos al inicio, hoy, adquirir 
activos es divertido, fácil y emocionante. Cuando digo que es fácil hacerse rico rápidamente 
y mantenerse rico para siempre, es cierto, si te das el tiempo para permitir que esa realidad 
crezca en tu realidad.
Mientras estaba de viaje en Australia, un joven maletero tomó mis maletas en el aeropuerto 
y dijo: "Me encantan sus libros".
Le agradecí por habérmelo dicho y le pregunté qué había aprendido.
"Bueno, lo primero que aprendí es que un empleo nunca me hará rico. Así que tengo un 
empleo en las noches e invierto el dinero de mi segundo empleo en bienes raíces".
"Genial", contesté. "¿Qué has hecho hasta ahora?"
"He comprado seis propiedades en un año y medio".
"Genial", dije. "Estoy orgulloso de ti. ¿Has ganado algo de dinero?"
"No, todavía no", dijo el joven apuesto. "Pero he aprendido algo muy importante".
"¿Y qué es?", pregunté.
"Se vuelve más fácil. Una vez que superé mi duda, miedo y falta de dinero iniciales, 
encuentro que se vuelve más fácil ser  inversionista. Entre más tratos veo y entre más 
inversiones compro, más fácil se vuelve invertir. Mi coeficiente intelectual financiero nunca 
habría aumentado si hubiera dejado que mi duda y mi miedo me mantuvieran paralizado. En 
vez de sentir miedo hoy, me siento emocionado, aunque todavía no he ganado mucho dinero... 
de hecho pierdo dinero en dos de mis seis inversiones. Como usted dice en sus libros, los 
errores son experiencias de aprendizaje. Son invaluables si aprendes de ellos. Así que ahora puedo 
verme siendo un inversionista de bienes raíces de tiempo completo algún día no muy lejano. 
En unos años, nunca más volveré a necesitar un empleo o un cheque quincenal".
"¿Tienes una meta, una fecha específica en la que habrás salido de la carrera de la rata 
financieramente libre?", pregunté.
"Definitivamente", dijo el joven con una sonrisa. "Tengo otros tres amigos como de la 
misma edad. Todos lo estamos haciendo juntos. No desperdiciamos nuestro tiempo como lo 
hacen otros chicos de nuestra edad. Estudiamos, asistimos juntos a seminarios y nos 
ayudamos a invertir entre nosotros. No planeamos seguir las huellas de nuestros padres. No 
queremos cometer los mismos errores que cometieron ellos, trabajando  por 45 años, 
temerosos de perder nuestros empleos, esperando un aumento de sueldo y esperando hasta 
los 65 años para retirarnos. Mis padres trabajaron tan duro para ascender por la escalera 
corporativa que no tuvieron tiempo para los niños ni para las cosas que realmente amaban. 
Ahora se están preparando para retirarse, pero están viejos. Yo no quiero ser como ellos. No 
quiero ser viejo cuando deje de trabajar. Los cuatro tenemos menos de 24 años y todos 
tenemos la meta de ser libres financieramente para la edad de 30 años".
"Felicidades", dije y le di un apretón de manos. Mientras terminaba de procesar mis maletas 
para el vuelo, le agradecí por haber leído mi libro y por haberme hecho sentir como un 
padre orgulloso.
Mientras yo dejaba el mostrador, el joven sonrió y gritó: "Lo mejor es que se está haciendo más 
fácil", dijo el joven. "Entre más me enfoco en construir mis activos, más fácil se está haciendo".
Le dije adiós con la mano y me apresuré a tomar mi vuelo.
Revisa nuestro sitio de Internet en busca de nuevas ideas
En los próximos años, los que formamos  richdad.com  estaremos  agregando cada vez 
información a nuestro sitio de Internet. Nuestro sitio está dedicado a ayudar a cualquiera a 
obtener las ideas, la educación y la experiencia necesarias a través de las cuales poder retirarse 
joven y rico. Revisa nuestro sitio de Internet con regularidad y haz que retirarte joven y rico sea 
tu realidad.
En mi realidad, entre mejor seas en adquirir activos, más fácil se vuelve hacerse rico más y 
más rápido. Si mantienes tu humildad, a pesar de ser rico, si eres agradecido con relación a 
tu riqueza en vez de ser arrogante, creo que tienes una mejor posibilidad de conservar ese 
dinero para siempre.
Así que sigue revisando nuestro sitio de Internet para obtener la información y las ideas más 
recientes. En el futuro cercano, tendremos en línea nuestros juegos CASHFLOW 101 y 202 en 
Internet para que puedas divertirte jugando y aprendiendo de personas justo como tú... 
personas que quieren retirarse jóvenes y ricas.
Específicamente de Sharon
La mayoría de las veces, entrelazo mis filosofías financieras con las de Robert cuando 
escribimos en coautoría los libros de Padre Rico. Yo permanezco relativamente invisible. Sin 
embargo, de vez en cuando, tengo una opinión tan fuerte sobre un tema que decidimos destacarlo 
para ti. ¡Ésta es una de esas veces!
¡La mayoría de mis compañeros contadores, especialistas en planeación financiera y banqueros 
simplemente no lo entienden! El camino hacia la libertad financiera es simplemente:
COMPRAR ACTIVOS
"Compra activos que generen flujo de efectivo AHORA, ¡no en algún momento en el futuro!"
Recuerda la forma en que el padre rico define los activos: "Los activos te ponen dinero en la 
bolsa, los pasivos quitan dinero de tu bolsa". Es así de simple. Entre más activos puedas comprar, 
más estará trabajando para ti tu dinero.
Muchos contadores, especialistas en planeación financiera y banqueros están atorados en cálculos 
de valor neto. Simplemente no entienden el flujo de efectivo. Han sido formados con la idea de 
que apartas dinero hasta que lo necesitas en algún momento en el futuro, ésta es la mentalidad de 
un ahorrador. Si trabajaran con sus clientes para generar flujo de efectivo de activos AHORA, sus 
clientes tendrían una situación financiera mejor, ahora y en el futuro.
El problema es que cuentan tu valor neto, incluyendo tu casa, tu coche, tus palos de golf y todas 
las demás propiedades personales, como activos. Nosotros a todo eso lo denominamos 
chucherías. Así NO es cómo un inversionista analiza el valor neto. Revisa tus estados financieros 
y quita todos los elementos de tu columna de activos que no te genere flujo de efectivo 
actualmente.
Cuando tienes activos que generan suficiente flujo mensual para cubrir tus gastos mensuales, 
¡eres financieramente libre!
¡COMPRA ACTIVOS, no pasivos!
Sharon Lechter.
Tip excelente #3
El tip excelente #3 puede sonar extraño así que por favor lee con cuidado. El tip excelente #3 es 
decir mentiras sobre tu futuro.
El joven maletero podía ver su futuro y estaba emocionado al respecto. No todo el mundo es 
capaz de ver un futuro tan brillante, razón por la cual el tip excelente #3 puede sonar 
extraño, aunque es una parte importante en el proceso de retirarte joven y rico.
Hace unos meses, estaba impartiendo un curso sobre inversión y varios de los participantes 
no pudieron dejar de decir cosas como:
1.No puedo hacer eso.
2.Yo nunca seré rico.
3.No soy buen inversionista.
4.No soy lo bastante listo.
5.Invertir es arriesgado.
6.Nunca conseguiré el dinero par hacer lo que quiero.
En la clase había una psicoterapeuta muy importante que levantó la mano para ayudar. Dijo: 
"Todo lo que se diga sobre el futuro es una mentira".
"¿El futuro es una mentira?", pregunté. "¿Por qué lo dice?"
"Primero que nada", dijo. "Quiero dejar en claro que no estoy animando a nadie a que mienta 
con el propósito de engañar. ¿Está claro?"
Yo asentí con la cabeza. "Entiendo, pero mi pregunta es ¿por qué dice usted que el futuro es 
una mentira?"
"Buena pregunta", dijo. "Me alegra saber que usted mantiene una mente abierta. A lo que me 
refiero con que el futuro es una mentira es a que cualquier cosa que se diga sobre el futuro no 
es un hecho, así que todo lo que se diga sobre el futuro técnicamente es una mentira".
"¿Y eso de qué manera resulta útil para estos participantes que no parecen poder sacudirse 
algunas de sus percepciones negativas sobre sí mismos o sobre sus pasivos?"
"Cuando la persona que dijo: 'Yo nunca seré rico' estaba haciendo una afirmación sobre algo 
que supuestamente era verdad en el futuro... en este caso la idea de que él nunca será rico", dijo 
la terapeuta. "Bueno, esa afirmación técnicamente es una mentira. No estoy diciendo que ese 
individuo sea un mentiroso, sólo estoy diciendo que la afirmación es una mentira, puesto que 
el futuro todavía no ha sucedido".
"Entonces, ¿qué significa?", pregunté.
"Significa exactamente lo que usted ha estado tratando de que se dé cuenta la clase. 
Necesitan entender que lo que dicen y lo que piensan tiene el poder de hacerse real y 
hacerse su realidad. Así que muchas personas dicen mentiras sobre su futuro y esas mentiras 
se convierten en su futuro."
"Quiere usted decir que cuando alguien dice 'Yo nunca seré rico', está diciendo una mentira 
porque está haciendo referencia a un evento proyectado en algún momento en el futuro. ¿Es 
eso lo que quiere decir?"
"Exactamente", dijo la terapeuta. "Y el problema es que una mentira se convierte en verdad".
"¿Así que, cuando alguien dice 'Invertir es arriesgado', en alguna forma está diciendo una 
mentira si está hablando sobre el futuro?"
"Sí... y entonces una mentira se convierte en verdad, si no cambia la mentira. Siempre 
recuerde que cualquier cosa en referencia con el futuro técnicamente es una mentira 
simplemente porque nada en el futuro es todavía un hecho o una verdad".
"Entonces, ¿de qué manera está información es útil?", volví a preguntar.
"Bueno, como terapeuta, he descubierto que las personas menos exitosas, más infelices y 
menos satisfechas dicen las mentiras más horribles sobre sí mismas. Dicen lo que usted ha 
estado tratando de impedir que diga la gente. Dicen: 'Yo nunca seré rico', 'yo nunca haré eso', 
'eso nunca funcionará'. Todas son mentiras... pero son mentiras que tienen el poder de 
convertirse en verdades".
"Y si no dicen esas mentiras, pasan tiempo con otras personas que les dirán esas mismas 
mentiras", agregué.
"Es verdad", dijo la terapeuta. "Dios los hace y ellos vaya que se juntan".
"Y también pasa con los mentirosos", dije.
La terapeuta rió entre dientes y asintió para mostrar que estaba de acuerdo.
"De modo que le pregunto una vez más, ¿de qué manera es  útil esta información 
iluminada?", pregunté.
"Bueno, como todo lo que se diga sobre el futuro técnicamente es una mentira, ¿por qué no 
decir mentiras sobre el tipo de futuro que quieres en vez de sobre el tipo de futuro que no 
quieres?", contestó la terapeuta.
En silencio, pensé en lo que ella había dicho, al igual que el resto de la clase. Finalmente 
dije: "¿Mentir sobre el futuro a propósito?"
"Claro, todos lo hacemos, algunos lo hacemos de manera inconsciente o automática. 
Déjeme preguntarle algo: ¿Con relación al dinero, su padre rico hablaba del futuro de 
manera positiva?"
"Sí", dije.
"¿Y gran parte de lo que él decía se volvió verdad?", preguntó.
De nuevo dije: "Sí".
"Y con relación al dinero y al futuro, ¿su padre rico hablaba de manera negativa?"
"Sí", dije.
"¿Y lo que decía se volvió verdad?"
Asentí con la cabeza.
"Entonces las dos mentiras se volvieron verdad", dijo la terapeuta.
Yo sólo asentí, dándome cuenta de que los dos hombres estaban mintiendo sobre su futuro 
y no obstante sus mentiras se volvieron verdad. "¿Entonces usted está diciendo que yo 
debería mentir sobre el futuro que quiero en lugar de sobre el futuro que no quiero?"
"Sí", dijo ella. "Eso es exactamente lo que estoy diciendo. De hecho, le apuesto que ya lo 
hace. Le apuesto que cuando estaba deprimido seguía diciéndoles a su esposa y a sus amigos 
cercanos lo bueno que iba a ser el futuro y la enorme cantidad de dinero que iba a hacer. 
Seguía diciéndolo aunque no tenía un centavo a su nombre".
Riendo entre dientes dije: "Sí, lo hacía. Pero sólo les contaba mis mentiras a amigos que me 
querían y me apoyaban. Nunca le conté mis mentiras positivas sobre mi futuro a personas 
que las echaran por tierra".
"Muy sabio de su parte", dijo la terapeuta. "¿Y qué mentiras le decía a su esposa durante 
sus momentos financieros más oscuros?"
"¿Quiere que se las diga a la clase?", pregunté, avergonzándome un poco.
"Sí. Dígale a la clase lo que usted decía realmente en los peores momentos".
Pensé durante un tiempo y recordé un momento en que Kim y yo estábamos en nuestro 
punto financiero más bajo. Lentamente dije a la clase: "Me recuerdo abrazando fuerte a Kim 
y diciéndole: 'Algún día todo esto habrá quedado atrás. Algún día seremos más ricos de lo 
que jamás hayamos imaginado. Hoy nuestro problema es no tener suficiente dinero, pero, 
algún día no muy lejano, nuestro problema será tener demasiado dinero'."
"¿Y eso se ha vuelto verdad?", preguntó la terapeuta.
"Sí, así es", contesté. "Más de lo que pudimos haber soñado. Me da un poco de vergüenza 
decir que hoy tenemos un gran problema de demasiado dinero. Me doy cuenta del medio tan 
pobre del que provengo porque hoy Kim y yo tenemos dificultades para pensar en cosas que 
podemos comprar. Gran parte de nuestro dinero va a obras de caridad, pero sigue quedando 
bastante y necesitamos expandir nuestra realidad sobre lo que compramos puesto que 
podemos pagar casi cualquier cosa en la que podemos pensar. Tratar de encontrar cosas que 
comprar que estén más allá de lo que podemos pagar es un proceso muy interesante".
"¿Por qué cree que sus mentiras se hicieron verdad?", contestó.
El veinte por ciento de las personas son mentirosas de hueso colorado
"Porque mis dos padres insistían en que nunca hiciera una promesa que no pudiera cumplir. 
Y si no podía cumplir la promesa, yo debía ser el primero en informar a la persona con 
quien rompiera la promesa que el acuerdo no podía ser mantenido. Mis dos padres 
remarcaban que nuestro valor está en nuestra palabra y los dos eran fieles a su palabra".
"Muy bien", dijo la terapeuta. "Verás, cerca de 80 por ciento de las personas básicamente son 
honestas. Cerca de veinte por ciento son mentirosas de hueso colorado y no importa lo que 
hagan, tienen que mentir. Así que aunque mienten positivamente sobre su futuro financiero, de 
cualquier forma se convierte en una mentira negativa, puesto que los mentirosos de hueso 
colorado no tienen integridad en el alma. Pero he descubierto que la mayoría de las personas 
son honestas, así que aun cuando mienten, sus mentiras se vuelven verdad".
La terapeuta hizo una pausa por un momento y luego dijo: "Ya fue suficiente de hablar sobre 
mentiras. Empecemos a aprender cómo mentir positivamente sobre nuestro futuro. Y recuer-den, el propósito de este ejercicio no es engañar sino ayudar a que cada uno de nosotros 
pase a una realidad nueva y mejor sobre sí mismo".
Acepté y la terapeuta hizo que los alumnos se pusieran en parejas. "Ahora" dijo. "Quiero 
que le digan a su compañero la mejor y mayor mentira de lo ricos que quieren ser en el 
futuro. Cuéntenles sobre los millones de dólares que reciben al mes de sus inversiones de 
bienes raíces, sobre la ganancia que reciben de su compañía de petróleo y sobre lo grande que 
es la mansión en donde viven".
Algunas personas tenían dificultades para decir mentiras  exageradas sobre su éxito 
financiero futuro. Otras estaban bastante experimentadas en el proceso. No obstante, en 
cuestión de minutos, la energía de la habitación estaba al ciento por ciento y el ruido era 
ensordecedor. Hubo estallidos de risa histérica cuando la gente decía mentiras gigantescas y 
exageradas sobre su futuro. A la mayoría de las personas realmente les encantó que se les 
diera permiso para contar historias exageradas sobre su éxito financiero futuro. Muchas 
reportaron que su vida y su futuro habían cambiado en ese momento.
Así que el tip #3 es que cada vez que te sientas deprimido y que estés contando mentiras 
negativas sobre ti y sobre tu futuro financiero, encuentra a un amigo de confianza y 
pregúntale si le puedes decir una enorme mentira sobre el inmenso éxito financiero que 
tendrás en el futuro. Pienso que te parecerá una excelente terapia y, quién sabe, tal vez la 
mentira sobre tu futuro financiero se vuelva verdad algún día.
Si tienes el valor suficiente, no esperes hasta que te sientas deprimido para comenzar a 
mentir de manera positiva. Lo antes posible, encuentra a un amigo o ser querido de 
confianza y pídele permiso para que te deje contarle enormes mentiras sobre lo fantástico 
que será algún día tu futuro financiero. Como dije, puede ser muy divertido y la mentira que 
dices o puede volverse verdad el día de mañana.
El rey del jonrón
El punto es que tu futuro todavía está por hacerse. Bien puedes conformarlo hoy y 
conformarlo de la manera en que quieres que sea, en vez de pensar en lo que temes que no 
sea. Cuando piensan en cambiar su futuro, demasiadas personas se van al escenario del 
peor caso posible, en vez de al escenario del mejor caso posible. Peor o mejor, de cualquier 
forma el escenario futuro es una mentira, por lo menos según con la terapeuta. El gran Babe 
Ruth tenía el hábito de tomar su bat y dirigirlo hacia la valla de jonrón. Era su manera de 
decir "voy por la pared". Lo hacía continuamente aunque le hacían más strickes que a la 
mayoría de las personas. Aunque era a quien más strickes le hacían, nunca dejó de señalar su 
bat a la lejana pared y hoy en día se le conoce como el rey del jonrón, no como el rey de los 
strickes.
El coco
Cuando éramos niños, muchos nos imaginábamos que el coco se escondía debajo de nuestra 
cama o en nuestro clóset. Algunos permanecíamos despiertos temblando y preocupándonos por 
ese personaje que existía sólo en nuestra mente, bien entrada la noche, cuando todas las luces 
estaban apagadas. Después de que crecimos, muchos reemplazamos al coco con el cobrador de 
cuentas o con algún horrible desastre financiero que todavía no ha sucedido. Sin importar si es el 
coco o el cobrador de cuentas, los resultados son los mismos... permanecemos despiertos por la 
noche preocupándonos por cosas de las que realmente no deberíamos de preocuparnos. 
También deprimimos nuestro futuro diciéndonos mentiras a nosotros mismos sobre alguna 
calamidad o desastre financieros que no ha ocurrido y puede ser que no ocurra nunca.
Así que en vez de despertar por la mañana y actuar como Babe Ruth señalando nuestro bat 
de jonrón hacia la valla, nos dirigimos a tumbos hacia un trabajo, vendiendo nuestra preciada 
vida por un poco de dinero, viviendo con una falsa sensación de seguridad financiera 
proveniente de un coco imaginario que dice: "¿Qué tal si pasa esto?", "¿Qué tal si pasa 
aquello?", "¿Qué pasa si...?" La persona puede ser mayor, pero el coco sigue existiendo y 
continúa despojando a las personas de maravillosas posibilidades de vida. Por eso este 
proceso de mentir sobre el futuro puede se un proceso valioso para las personas honestas que 
quieren avanzar con valentía, señalando su bat de béisbol a la valla lejana, muy lejana.
Mi padre rico decía: "Todos tenemos buena suerte y mala suerte. Las personas que no tienen 
éxito viven su vida sin hacer nada, evitando la mala suerte y también la buena suerte. Es 
difícil tener cualquier tipo de suerte si estás sin hacer nada, paralizado por el miedo. Una 
persona exitosa es alguien que pone manos a la obra y toma lo bueno con lo malo, sabiendo 
que puede convertir la mala suerte en buena suerte".
Un día un reportero me preguntó cómo superé mi miedo al fracaso y cuáles eran algunos tips 
sobre el secreto de mi éxito.
Pensé por un momento y dije: "Mi padre rico me enseñó a convertir la mala suerte en buena 
suerte". Así que en cuanto a la buena suerte, comienza con pasos de bebé y ve tras la vida 
que sueñas en vez de vivir temiendo alguna pesadilla imaginaria. No dejes que el coco te 
robe tus sueños. Sé como Babe Ruth... di grandes mentiras sobre tu futuro y batea con 
valentía hacia la valla.
Una nota importante: Por favor recuerda que este tip no es una licencia para mentir con el intento 
de engañar o encubrir la verdad. Yo nunca aprobaría una práctica así. La recomendación anterior es 
sólo para personas honestas, no para mentirosos habituales. Si tú eres un mentiroso habitual, por 
favor busca ayuda profesional y comienza a decir la verdad en lugar de mentir.
12 Tips más para ti
Resumen de tips anteriores de este libro con la inclusión de algunos tips adicionales
En la introducción, prometí que proporcionaría una lista de cosas que cualquiera puede hacer 
para mejorar su posibilidad de retirarse joven y rico. La mayoría ya se han discutido, pero 
una lista de revisión simple y condensada puede resultar útil.
Se trata de cosas que yo hago con regularidad. Son cosas que me han ayudado en gran 
medida para retirarme joven y rico. Confío en que también te pueden resultar útiles a ti. 
Siempre recuerda que el proceso de retirarte joven y rico es principalmente un proceso 
mental y emocional... más que un proceso físico. Una vez que empieces el viaje en tu mente 
y en tu corazón, el resto de ti pronto seguirá.
1. Decide. Todos los días, me levanto y elijo quién y qué quiero ser. Me pregunto: "¿Quiero 
vivir hoy como una persona con un contexto pobre, un contexto de clase media o un contexto 
rico?"
Recuerda que una persona con un contexto pobre dirá algo como: "Yo nunca seré rico". Una 
persona con un contexto de clase media puede decir: "Tener un trabajo seguro es algo 
importante". Una persona con un contexto rico puede decir: "Necesito incrementar mi 
coeficiente intelectual financiero para poder trabajar menos y ganar más dinero".
2. Encuentra un amigo o ser querido que quiera hacer el viaje contigo. Sé que yo no lo 
habría hecho sin mi esposa, Kim, y mis amigos como Larry Clark. Asegúrate de tener 
amigos que exijan más de ti en vez de decirte por qué no puedes hacer lo que quieres hacer.
Elegir los amigos o compañeros de vida adecuados es muy importante para lograr una vida 
exitosa. Si tienes amigos o familiares que no están comprometidos con mejorar su 
coeficiente intelectual financiero, la vida puede ser una larga lucha financiera, sin importar 
cuánto dinero ganes.
3. Busca consejo competente y comienza a construir tu propio equipo de asesores legales 
y financieros. Siempre recuerda lo que decía mi padre rico: "Tu consejo más costoso es el
consejo gratuito que recibes de amigos y familiares que luchan financieramente". Mi padre 
rico más adelante expandió su afirmación para incluir a asesores financieros que no ponían 
en práctica sus palabras o que no compraban los productos de inversión que te vendían. De 
nuevo, elegir a las personas adecuadas es una habilidad muy importante. Las personas 
pueden ser activos o bien pasivos.
Un día, mi padre rico me dijo: "Si tu auto está descompuesto lo llevas con un mecánico 
capacitado para que lo arregle. En el momento en que recoges el auto, sabes si el mecánico fue 
bueno o no. El problema con esos supuestos asesores financieros profesionales es que hasta años 
después sabrás si te dieron un buen o un mal consejo. ¿Qué pasa si empiezas a tomar los 
consejos de un asesor financiero a los 25 años y a los 65 descubres que te estaba dando un mal 
consejo?. No le puedes devolver tu vida financiera arruinada al asesor financiero como puedes 
devolverle tu coche descompuesto al mecánico. Yo confío más en los mecánicos automotrices y 
en los vendedores de coches usados que en la mayoría de los asesores financieros simplemente 
porque puedo ver más rápido los resultados de su trabajo. La razón por la que la mayoría de las 
personas terminan en la clase pobre o en la clase media es porque pasan más tiempo 
seleccionando un coche usado del que pasan buscando un buen consejo financiero".
El punto es que debes ser muy cuidadoso sobre el consejo que colocas en tu mente. Tómate 
tu tiempo para encontrar buenos asesores financieros. Están allá afuera y los honorarios que 
les pagues pueden ser la mejor inversión que hagas.
4. Fija una fecha para retirarte. Siéntate con tus seres queridos, tus asesores, y fija una 
fecha para retirarte pronto. Esto es como Babe Ruth señalando hacia la lejana pared. Si real-mente llevas a cabo este proceso y discutes una fecha real con esas personas, tu contexto 
presente comenzará a discutir con tu contexto futuro. Es un proceso excelente y divertido por 
el cual pasar. Definitivamente escucharás muchas realidades diferentes y contextos 
diferentes.
Ten reuniones trimestrales con este grupo y sigue discutiendo tu focha de retiro temprano.
5. Escribe un plan en papel una vez que hayas fijado la fecha de tu retiro temprano. Pon 
ese plan en tu refrigerador para que puedas verlo todos los días. Actualiza el plan a medida 
que progreses y aprendas cada vez más.
Cuando Kim, Larry y yo pasamos esa semana en la montaña Whistler, congelados en la 
nieve, el plan que creamos cambió la dirección de nuestra vida. Ése es el poder de un plan. 
El punto es que sólo porque eres pobre hoy no significa que tengas que ser pobre mañana. 
Hacerte rico y seguirlo siendo requiere de un plan y de la determinación para seguirlo, un 
día a la vez. Kim y yo seguimos nuestro plan un día a la vez durante casi diez años. Como 
dije, hoy nuestro problema es que tenemos demasiado dinero y luchamos para encontrar 
formas de gastarlo sabiamente. Puede ser una lucha, pero es el tipo de lucha que me gusta y 
que quiero que tú también tengas.
6.Planea tu fiesta de retiro prematuro. Sé excesivo y espléndido. Una vez que puedas retirarte 
pronto, tu dinero ya no será un problema. Aunque no logres tu meta, te divertirás mucho 
pasando por el proceso. Y quién sabe, quizá tengas que dar esa fiesta de retiro prematuro de 
manera prematura.
7.Analiza un trato diario. Recuerda que no te cuesta nada ir de compras. El punto es hacer 
algo todos los días para mejorar tu inteligencia financiera por lo menos durante diez minutos 
al día. Puede ser algo simple como leer un artículo de la sección de dinero o negocios de tu 
periódico... aunque no estés interesado en él. Comenzará a mejorar tu vocabulario. Escucha 
discos compactos o cintas de información financiera o de negocios mientras manejas o haces 
ejercicio en el gimnasio. Asiste a un seminario financiero por lo menos una vez al año. Si no 
quieres pagar por un seminario, simplemente ve la sección financiera de tu periódico local 
y encontrarás muchos seminarios de inversión gratuitos. Aunque no aprendas nada, es 
probable que conozcas a otras personas justo como tú.
8. Recuerda que todos los mercados siguen tres tendencias principales. Son a la alza, a la baja 
o laterales. Algunos mercados suben, bajan y se mueven lateralmente con los años y en 
ocasiones los mercados pueden tender a subir, bajar y moverse lateralmente en menos de un 
minuto. Por eso cuando alguien te aconseja "invierte a largo plazo", pregúntale a qué se 
refiere. Pídele una explicación más detallada. La mayoría de los asesores financieros 
simplemente repiten lo que les ha enseñado su gerente de ventas de modo que pueden tener 
dificultades para explicar lo que dicen.
Si quieres hacerte rico rápidamente, una de las mejores formas de hacerlo es en el punto en el 
que cambia una tendencia. Hay mucha verdad en el viejo dicho que dice: "Estar en el lugar 
correcto en el momento correcto". Si ves tratos diariamente, sentirás mejor los cambios y 
mejorarás tus posibilidades de estar en el lugar adecuado en el momento adecuado. Por 
ejemplo, si hubieras entrado a la bolsa en 1991 y hubieras invertido mucho dinero en acciones 
de tecnología, hoy serías rico. Pero cuando la tendencia bajó, en marzo de 2000, de no 
cambiar tu estrategia habrías perdido todo lo que habías ganado. Si hubieras cambiado la 
estrategia en marzo de 2000, habrías hecho dinero más rápido en el camino hacia abajo... 
sólo incrementando tu riqueza en vez de perderla. Por eso, si quieres hacerte rico rápidamente y 
seguir siendo rico para siempre, debes estar consciente de las tendencias y tener tres estrategias 
diferentes para las tres tendencias diferentes. He conocido a muchas personas que hicieron 
dinero en una tendencia v quedaron en bancarrota cuando ésta cambio.
Compra alto, vende bajo
El número de junio de 2001 de la revista Forbes contenía un artículo interesante. El 
encabezado decía:
Compra alto, vende bajo. Lo que siempre supiste: los analistas son excelentes asesores si haces lo 
contrario.
Cito el artículo:
Nuevas investigaciones realizadas por cuatro profesores de California muestran que no sólo 
habrías perdido dinero comprando acciones que los analistas apoyaron el año pasado, sino que 
habrías ganado dinero comprando las que recomendaron vender. Y no sólo ganancias pequeñas. 
Habrías ganado 38 por ciento por tu dinero, mejor del desempeño que S&P 500 ha tenido desde 
1958.
En otro artículo, titulado "¿Wall Street toma en serio la reforma?", en la edición del 16 de julio de 
2001 de la revista Fortune, el escritor Shawn Tully parece estar de acuerdo. Ese artículo dice: 
"En una húmeda mañana de junio, Richard Baker, representante del Congreso y rústico 
republicano de Louisiana, abrió una dramática audiencia del Congreso insistiendo en un 
tema que conmociona a todos, desde cantineros hasta mamas de niños que juegan sóccer, 
llamado 'Cómo Wall Street se friega al tipo pequeño'. En una lenta enunciación melosa, Baker 
dio voz a su rabia por la forma en que los nuevos aristócratas de Wall Street, los analistas de 
seguridades, trasquilan a los pequeños accionistas".
En mi opinión, la mayoría de los analistas y asesores financieros no son inversionistas 
profesionales. No saben lo que debe saber un inversionista profesional. Así que la mayoría de los 
consejos sobre inversión son buenos consejos para el inversionista promedio, pero ese mismo 
consejo es un mal consejo para el inversionista profesional... en especial si quieres hacerte rico 
rápidamente y seguir siendo rico para siempre.
Un inversionista profesional sabe que la tendencia es tu amiga. Un inversionista profesional es 
alguien que sabe que nadie es lo bastante fuerte como para ir en contra de la tendencia. Como 
niños que surfeaban, siempre tuvimos un enorme respeto por los cambios de las tendencias o el 
estado del océano. El turista, quien llegaba sabiendo sólo lo que era nadar en un lago o 
alberca, era el que se metía en problemas en el océano, algunos incluso se ahogaban. Debes 
respetar las tendencias de la misma forma en que un surfista respeta el poder del océano. Si 
quieres mantenerte actualizado en cuanto a las tendencias y cambios, definitivamente querrás 
tomar el tip #9.
9. Visita nuestro sito de Internet con regularidad. Es nuestro compromiso mantenerlo fresco e 
interesante. Piensa en nuestro sitio de Internet como el lugar para personas que van a retirarse 
jóvenes y ricas.
En el futuro cercano, tendremos en línea nuestros juegos CASHFLOW para que puedas divertirte, 
aprender rápidamente y conocer personas que piensan justo como tú. En el futuro cercano, jugarás 
nuestros juegos y aprenderás como manejar una tendencia a la alta, una tendencia a la baja y una 
tendencia que se mueve lateralmente y aprenderás cómo hacer dinero en cualquier dirección.
Cuando alguien te dice "invierte a largo plazo" pregúntale qué quiere decir con largo plazo. Largo 
plazo significa una cosa para el inversionista promedio y otra para el inversionista profesional. Si 
quieres hacerte rico rápidamente y seguir siendo rico para siempre, no puedes ser un inversionista 
promedio a largo plazo. Debes ser un inversionista profesional que esté mucho mejor preparado que 
el inversionista promedio. Por eso recomiendo que revises nuestro sitio de Internet, richdad.com, con 
regularidad. Nuestro trabajo consiste en mantenerte actualizado con la educación financiera más 
divertida y fructífera del mundo.
Si no planeas seguir las huellas de tus padres y trabajar duro toda tu vida, entonces empieza 
revisando regularmente el sitio richdad.com. Uno de los problemas de seguir el consejo de tus padres 
con relación al dinero es que la tecnología y el coeficiente intelectual financiero están cambiando más 
rápido de lo que muchas personas pueden cambiar. Hoy, es posible hacerse rico rápidamente y 
seguir siendo rico para siempre si te mantienes al corriente de los cambios en la tecnología y la 
inteligencia financiera. Por ejemplo, en el mundo de las opciones, hay nuevas opciones que 
surgen hoy que se llaman "opciones knockout". Son mucho más rápidas que las opciones 
comunes de compra y venta de acciones que están empleando hoy la mayoría de los negociantes. 
La razón por la que la mayoría de las personas no saben sobre las "opciones knockout" es porque 
fueron inventadas por negociantes de intercambio extranjero o moneda extranjera. En unos 
cuantos años, esas nuevas "opciones exóticas", como se les denomina, comenzarán a filtrarse a la 
bolsa. Sin entrar en muchos detalles, dicho simplemente, una opción knockout significa que 
puedes hacer más dinero, más rápido y más seguro que con las opciones comunes. Sólo recuerda 
lo siguiente: a medida que hacemos avances en la tecnología, también los seres humanos hacemos 
avances en inteligencia financiera. Eso significa que se vuelve cada vez más fácil hacerse rico más 
rápido y con más seguridad. ¿La trampa? Necesitas mantenerte al  ritmo y mantenerte 
aprendiendo y conseguir buenos asesores. Por eso querrás mantenerte actualizado, revisando 
nuestro sitio de Internet con regularidad.
Los perros viejos aprenden nuevos trucos
Como habrás adivinado, me encanta la revista Forbes. En el número correspondiente a 
mayo de 2001 de su revista Forbes Global, su revista para personas de negocios e 
inversionistas  internacionales, apareció un artículo interesante sobre Sir John Templeton, 
quien es conocido como un inversionista de valor que invierte en acciones subvaluadas 
globalmente y las observa crecer. El artículo de Forbes, titulado "Perro viejo, trucos 
nuevos", describe cómo incluso Templeton, un inversionista alcista y fundamental, puede 
aprender a ser un negociante técnico, invirtiendo en un mercado bajista. El artículo habla 
sobre cómo en el año 2000, en vez de invertir a largo plazo, lo que solía aconsejar, por 
primera vez se fue al corto. Era una nueva forma de invertir para él. En un año ganó más de 
86 millones de dólares aprendiendo una nueva forma de invertir. Como decía mi padre rico: 
"El dinero es sólo una idea". En este momento y en esta época, se puede seguir teniendo 
nuevas ideas. Si Sir John Templeton puede cambiar su contexto a los 88 años, tú también 
puedes.
Mientras el inversionista promedio estaba escuchando a sus asesores financieros que le 
aconsejaban invertir a largo plazo, los inversionistas reales estaban cambiando de estrategia 
y se  estaban yendo al corto. Millones de inversionistas que invirtieron a largo plazo 
escuchando esos consejos al final perdieron mil millones de dólares. ¿Esto puede pasar otra 
vez? Es bastante seguro. Por eso si quieres hacerte rico rápidamente y seguir siendo rico 
para siempre, necesitas tener cuidado sobre quién te está dando consejos financieros.
10. Siempre recuerda que las palabras son gratis. Si quieres hacerte rico rápidamente, 
necesitas un vocabulario rico. Siempre recuerda que hay tres clases básicas de activos. Son 
los negocios, los activos en documentos y los bienes raíces. Cada uno de esos activos 
emplea palabras diferentes. Cada uno es como un país extranjero con una lengua extranjera. 
Una vez que aprendas las palabras, serás más capaz de comunicarte contigo y con los demás 
en esa clase de activos.
Las palabras son las herramientas más poderosos que tenemos como seres humanos. Así que 
elige tus palabras cuidadosamente. Siempre recuerda que hay dos tipos básicos de palabras:
• Un tipo son las palabras de contenido. Por ejemplo, la tasa interna de ganancia es 
un grupo de palabras importante en especial para los inversionistas en bienes raíces 
que usan mucho apalancamiento con el cual invertir. Las tasas internas de ganancia 
son palabras de contenido.
• El segundo tipo de palabras son las palabras de contexto. Por ejemplo, cuando 
alguien dice: "Nunca entenderé las tasas internas de ganancia", esa persona está 
describiendo su contexto mental sobre las palabras de contenido, en este caso las 
tasas internas de ganancia.
Debes estar consciente de mejorar tu vocabulario de contenido y observar tu vocabulario de 
contexto constantemente... porque las palabras son las herramientas que dan poder a uno de 
tus activos más poderosos... tu cerebro. Por eso sugerí que te prohibieras decir "no puedo 
pagarlo" o "no puedo hacerlo" o "yo nunca podría aprender eso". En cambio, pregúntate a ti 
mismo "¿Cómo puedo pagarlo?" o "¿Cómo puedo hacerlo?" o "¿Cómo puedo aprenderlo?"
Recuerda que una gran diferencia entre una persona rica y una persona pobre es simplemente 
la cualidad de sus palabras. Tu coeficiente intelectual financiero comienza con tu 
vocabulario financiero. Así que cuida tus palabras porque éstas se hacen carne y se 
convierten en tu futuro. Si quieres hacerte rico rápidamente y seguir siendo rico para 
siempre de modo que te puedas retirar joven y rico, tus palabras tienen la clave... y las 
palabras son gratis.
11. Habla de dinero. Hace poco, cuando estuve en China y en Japón, muchas personas se 
me acercaron y dijeron: "En la cultura oriental, no es educado hablar de dinero... así que 
nunca lo hacemos". Cuando estoy en Estados Unidos o en Australia o en Europa, escucho a 
muchas personas que dicen lo mismo. Dicen: "En nuestra familia no discutíamos sobre 
dinero".
Así que el tip excelente es que hables de dinero. Si tus amigos no quieren hacerlo, es 
probable que quieras buscarte un nuevo grupo de amigos. En el mío, hablamos de dinero, 
negocios, inversiones, éxitos y problemas. La mayoría de mis amigos también son muy 
ricos y no tienen el contexto de que hablar de dinero es malo y sucio. Mi esposa, Kim, y yo 
hablamos de dinero constantemente. Para nosotros, hacer dinero, volvernos ricos y tener un 
estilo de vida abundante es divertido... y disfrutamos del juego del dinero de modo que 
hablamos de dinero. Disfrutamos del juego del dinero así como muchas personas disfrutan 
de otros deportes. Como tenemos en común al dinero como un juego, nuestro matrimonio es 
más cercano, educativo, emocionante y divertido. El dinero es un tema que todas las 
personas de todo el mundo tienen en común... así que, ¿por qué no hablar de él?
12. Haz un millón de dólares empezando sin nada. Una de las razones por las que no necesito un 
trabajo ni un salario es porque mi padre rico me formó para hacer dinero de la nada.
Una de las cosas más tristes que veo hoy en día es a personas que no saben cómo hacer dinero 
de la nada. El otro día, una joven solicitó un empleo en una de mis compañías. Venía de una 
enorme  corporación   multinacional  donde  había  sido  vicepresidenta  ejecutiva  de 
mercadotecnia. Había salido de la empresa en un recorte de personal y quería probar como 
vicepresidenta de mercadotecnia en mi pequeña compañía empresarial. Así que, como una 
prueba, le pedí que preparara un presupuesto de medios para esta compañía. Tres días 
después, regresó con un presupuesto de 1.6 millones de dólares al año.
"1.6 millones de dólares", dije atónito. "Es mucho dinero."
"Estoy consciente de ello", dijo en el mayor tono corporativo. "Pero si quieres lograr el 
resultado que deseas, eso es lo que costará".
"Estoy dispuesto a pagarlo", contesté. "Pero antes de aceptar este presupuesto, dime cómo 
podríamos lograr el mismo resultado por 160,000 dólares o incluso sin nada".
"Oh, usted no puede hacer eso", dijo en su presuntuoso tono corporativo. "Debe gastar 
dinero para hacer dinero".
Sobra decir que no obtuvo el empleo. Obviamente provenimos de una realidad o contexto 
diferente. Como empresario, he construido compañías que no gastan absolutamente nada en 
publicidad formal. Nosotros sí gastamos en relaciones públicas, pero no gastamos en lo que 
se conoce como publicidad formal. Cuando ves el éxito de richdad.com, estás viendo un 
éxito mundial, cientos de millones de dólares en ventas y ni un centavo gastado en 
publicidad formal... y tal vez algún día la forma en que lo hicimos sea el tema de otro libro. 
Pero ese éxito se debe a que mi padre rico nos enseñó a su hijo y a mí cómo hacer millones 
a partir de nada o de prácticamente nada.
El punto es que me entristece ver a ejecutivos maduros, muy bien pagados de corporaciones 
importantes que saben cómo gastar mucho dinero, pero que realmente no saben cómo hacer 
mucho dinero por su cuenta. Asisto a reuniones de mesas directivas de unas cuantas 
compañías públicas y observo cómo esos ejecutivos hacen mil cosas con el dinero de los 
inversionistas, como hicieron las empresas punto com a finales de los noventa, pero no son 
capaces de dar una ganancia.
Mi padre rico con frecuencia decía: "Hay grandes diferencias entre los empresarios y los 
burócratas. La mayoría de las personas son burócratas porque nuestras escuelas enseñan a la 
gente a convertirse en burócratas. Un empresario debe saber cómo ser las dos cosas. 
Muchos burócratas sueñan con convertirse en empresarios, pero muchos nunca lo 
conseguirán". Mi padre rico decía: "Un burócrata sólo sabe cómo hacer dinero si se lo dan. 
Un empresario puede hacer dinero de la nada".
Hace unos meses, estaba sentado con un ejecutivo de una enorme editorial internacional. 
Acababa de asistir a una de mil pláticas sobre empresas y sobre cómo hacer que crezca un 
negocio. Me miró directamente a los ojos y dijo: "Yo nunca seré rico porque se necesita 
mucho dinero para hacer dinero. Tengo un presupuesto de veinte millones de dólares para 
publicidad y necesito cada uno de esos dólares para producir el volumen de ventas que 
quiero". En ese momento supe por qué era un burócrata de una enorme corporación y no un 
empresario. Su realidad siempre lo mantendrá ahí.
También me entristece ver pequeñas compañías que no son capaces de crecer porque el 
empresario no sabe cómo hacer dinero de la nada o casi de la nada. Mi padre rico decía: 
"Hay una gran diferencia entre un negocio bebé y un negocio pequeño. Un negocio bebé 
tiene el potencial de convertirse en un gran negocio del cuadrante D. Un negocio pequeño 
puede ser rentable pero no tiene potencial de convertirse en un negocio del cuadrante D". 
Mi padre rico siguió explicando que la diferencia no se encuentra en el negocio, sino en la 
mentalidad del empresario que está detrás del negocio. Un ejemplo clásico es la historia de 
los hermanos McDonald y Ray Kroc. Ray Kroc tomó un pequeño puesto de hamburguesas 
que manejaban dos hermanos y lo convirtió en un negocio muy, muy, muy grande a nivel 
mundial conocido como McDonald's.
En resumen, Ray Kroc era un empleado del cuadrante E que vendía malteadas y que compró 
un negocio del cuadrante A y lo convirtió en un enorme negocio del cuadrante D. Ése es el 
poder de este simple procedimiento que compartiré ahora contigo... un proceso que puedes 
hacer con regularidad y que no te costará nada... pero que podría hacerte más rico de lo que 
jamás has soñado.
Así que el último tip es que pases tiempo con tu ser querido o con tus amigos que estén en el 
viaje contigo, haciendo lluvia de ideas sobre cómo pueden tomar una idea y convertirla en 
millones de dólares, empezando sin nada de dinero o con muy poco. Este proceso es como ir 
al gimnasio a ejercitar tus músculos. Ese ejercicio regular fortalece tu cerebro y lo alista para 
el momento en que haces tu movida.
Antes de conocer a Kim, Larry y yo nos sentábamos en una cafetería en la planta baja del 
edificio donde se encontraba la oficina de Xerox. Pasábamos horas tomando café dando 
ideas de cómo hacer millones de dólares de la nada. Dimos con algunas ideas realmente 
buenas y con muchas, pero muchas ideas estúpidas. Dimos ideas de playeras, rompecabezas 
de madera, un producto para turistas que tenía que ver con paquetes de azúcar de Hawai, un 
boletín de noticias financieras. La mayoría de las ideas nunca aterrizaron, no obstante, nos 
dieron un excelente ejercicio mental. Aunque la mayoría de las ideas no funcionaron, dimos 
con la idea de la cartera para surfistas hecha de nylon y velero, la tomamos y la convertimos 
en millones de dólares. Desafortunadamente, no dimos los pasos necesarios para proteger la 
idea y terminamos perdiéndola en la competencia.
Antes, mencioné que había leído que la capitalización de la compañía Coca-Cola era de más de 
ocho mil millones de dólares, pero que el valor de la marca Coca-Cola es de cerca de 80 mil 
millones, casi diez veces la capitalización de la compañía completa. ¿Cómo es posible eso? Coca-Cola ha protegido agresivamente su propiedad intelectual en todo el mundo y, como resultado, 
la marca Coca-Cola se ha vuelto increíblemente valiosa.
¡"Padre Rico" son sólo dos palabras!
Revisemos el éxito de las palabras "Padre Rico". Padre Rico son sólo dos palabras.
Cuando Kim y yo conocimos a Sharon Lechter y empezamos CASHFLOW Technologies, Inc. en 
1997, las palabras "Padre Rico" eran sólo dos palabras sin significado y que no valían nada.
Hoy en día, las palabras "Padre Rico" valen decenas de millones de dólares. ¿Cómo pasó eso? 
Tomamos el consejo de Michael Lechter, el esposo de Sharon y nuestro abogado sobre propiedad 
intelectual (quien, como algunos de ustedes saben, en realidad nos presentó con Sharon). Tomamos 
el tiempo para sentamos con él y crear una estrategia para construir internacionalmente activos de 
propiedad intelectual. Nos aseguramos de proteger nuestros inventos con patentes. Hemos creado y 
protegido con fuerza las marcas "Padre Rico" y "CASHFLOW" y un vestido comercial 
(morado, negro y dorado) que se puede reconocer en todo el mundo. Nos costó menos de mil 
dólares registrar la marca inicial. Al año siguiente, cuando lanzamos la versión en línea del juego 
CASHFLOW, el valor de las marcas pudieron alcanzar miles de millones de dólares. Nuestra 
experiencia demuestra que puedes hacer dinero con poco o nada de dinero.
Para mayor información sobre cómo puedes crear dinero con poco o nada de dinero, puedes leer el libro de 
Michael, Protecting your #1 Asset: Creating Fortunes from Your Ideas -An Intellectual Property 
Handbook (Protegiendo tu activo #1: Creando fortunas de tus ideas -Un manual de propiedad inte-lectual), publicado por Warner Books. Michael es un abogado de propiedad intelectual reconocido 
internacionalmente que ha ayudado a incontables personas a crear fortunas de sus ideas. En sus 
palabras, él "construye fuertes y combate piratas" para proteger la propiedad intelectual. Michael dice a 
menudo: "¡Cada  uno de nosotros ha tenido una idea que vale un millón de dólares!" 
Desafortunadamente, muy pocos damos los pasos necesarios para proteger esa idea, y, si no la proteges, 
no serás tú quien gane el millón de dólares por la idea. La inversión de veinte dólares en el libro de 
Michael te podría ayudar a ver cómo hacer una fortuna de tu propia idea.
En conclusión
Tú y yo sabemos que tu cerebro sigue siendo tu activo menos usado. Tiene muchos caballos 
de fuerza por usarse. Mi padre rico solía decir: "Las personas flojas quieren hacerse ricas 
rápidamente y las personas exitosas quieren hacerse inteligentes financieramente rápido y 
seguir haciéndose inteligentes". El punto es que, si quieres retirarte joven y rico, y no tienes 
mucho dinero, preparación o experiencia, debes comenzar a usar tu cerebro. En mi realidad, 
no se necesita dinero para hacerse rico. En mi realidad, lo que se necesita es poder mental y 
emocional. Todos los excelentes tips enlistados están ahí para que los tomes en cuenta y los 
pongas en práctica si eso es lo que quieres.
El punto final de todos esos tips es que ninguno de los ejercicios anteriores requiere de 
mucho tiempo. Todos los ejercicios anteriores te ayudarán a retirarte joven y rico si los 
haces con regularidad y fidelidad. Siempre recuerda que tu futuro está determinado por lo que 
haces hoy, no mañana.
Si haces fielmente que algunos de esos sencillos ejercicios sean parte de tu vida cotidiana, 
puedes encontrarte atravesando el cristal hacia un mundo completamente distinto. Y ése es el 
tema de la siguiente sección.
Un pensamiento final sobre la sección 3: Ya eres un experto
Como ya habrás podido darte cuenta, no es tanto lo que haces lo que te hace rico o pobre. Es más el 
contexto que rodea lo que haces lo que te hace rico o pobre. Por eso cuando las personas me 
preguntan qué hago o en qué invierto, contesto: "Por  favor no me pregunten lo que hago. 
Pregúntenme qué pienso sobre lo que hago". Por ejemplo, muchas personas invierten en acciones, 
pero sólo unas cuantas se hacen ricas de este modo. Lo mismo es cierto para los bienes raíces o la 
creación de un negocio. ¿Cuál es la diferencia? Yo digo que es el contexto que rodea a las acciones 
o contenido. He conocido personas que me dicen: "Los bienes raíces son una terrible inversión. No 
he ganado nada de dinero así". Bueno, en mi opinión, los bienes raíces no son lo que es una inversión 
terrible, es la persona quien es un inversionista terrible. Una persona con un contexto de 
inversionista rico puede tomar una mala inversión y convertirla en una inversión rica. De 
hecho, eso es lo que hace la mayor parte de los inversionistas.
"Toda deuda es buena "
Lo mismo es cierto con el tema de la deuda. La mayoría de las personas sabe cómo 
endeudarse. La mayoría son expertos en endeudarse. El problema es que se endeudan y se 
hacen más pobres. La mayoría de las personas toman deudas buenas y las hacen malas. Como 
solía decirme mi padre rico: "Toda deuda es una deuda buena. Pero no todas las personas 
saben cómo usar la deuda, así que convierten la deuda buena en mala".
Si quieres ser rico, lo primero que necesitas es trabajar en tu contexto, más que en lo que 
haces. Como decía mi padre rico: "La mayoría de las personas ya saben cómo endeudarse. 
El problema es que no saben cómo usar la deuda a su favor. Si alguien quiere hacerse rico 
usando la deuda, primero necesita cambiar su contexto y luego puede usar la deuda para 
hacerse muy rico". Si no puedes cambiar tu contexto de persona pobre o de clase media con 
relación al tema de la deuda, es mejor que canceles tus tarjetas de crédito, que pagues tu casa 
lo más rápido posible y simplemente trates de ahorrar dinero.
Si quieres retirarte joven y rico, primero debes cambiar tu contexto. Por eso recomiendo que 
ocasionalmente revises esos tips excelentes y que continuamente trabajes en aumentar tu 
contexto. Si tienes el contexto de una persona rica, sin importar lo que hagas, te harás cada 
vez más rico. Si tienes el contexto de una persona pobre, sin importar qué estudies o qué 
hagas, los resultados serán los mismos, serán los resultados de una persona pobre. Recuerda 
que es tu contexto o lo que consideras real lo que se convierte en tu realidad, sin importar lo 
que hagas. Como decía mi padre rico: "La deuda no necesariamente significa hacerte pobre. 
Pero un contexto de persona pobre o de clase media sí".
Libre oferta
Si quieres escucharme explicando personalmente esos tips excelentes, por favor ve a nuestro 
sitio de Internet en richdad.com y escucha el audio de presentación que hice para personas justo 
como tú... personas que quieren retirarse jóvenes y ricas. Si estás comprometido con retirarte 
joven y rico, nuestro sitio de Internet es para ti. Si quieres trabajar duro toda tu vida para 
tener un empleo seguro o invertir con altos riesgos y ganancias bajas, hay mejores sitios de 
Internet que el nuestro.
CAPÍTULO 20
La prueba final
El siguiente es un ejercicio opcional que puedes hacer, si tienes el valor suficiente. Estas 
preguntas las debes hacer en la próxima cena a la que acudas o durante el almuerzo con tus 
compañeros de trabajo o con amigos y familiares. La razón por la que digo que es opcional 
es porque las siguientes preguntas sacarán a la luz diferentes realidades sobre el dinero de las 
personas a quienes preguntes.
Si das tiempo a la persona para responder completamente cada pregunta, escucharás 
muchas realidades, razones, excusas, mentiras, suposiciones y otros procesos psicológicos 
diferentes que la gente tiene sobre el dinero y sobre su vida. Es probable que escuches 
respuestas como: "Qué pregunta tan estúpida". "¿Y este tipo quién se cree que es?", "No 
puedes hacer eso", "Eso es imposible". "Me encanta mi trabajo. Nunca dejaré de trabajar". 
En vez de mostrar que estás de acuerdo o en desacuerdo con las respuestas o comentarios a 
las preguntas, simplemente escucha y ve si puedes asir más claramente la realidad que tiene 
la persona con relación al dinero y a su vida financiera. Si tienes el valor para hacer esas 
preguntas a tus seres queridos, amigos y compañeros de trabajo, te deseo suerte. Si haces el 
ejercicio con otras personas, pienso que aprenderás muchísimo sobre el poder que tiene la realidad 
propia sobre la condición financiera en la vida de esas personas.
A continuación están las preguntas o grupos de preguntas que debes hacer:
¿Qué tipo de vida quieres vivir?
Una comparación de realidades
1.Si tuvieras todo el dinero del mundo y nunca tuvieras que volver a trabajar, ¿qué harías 
con tu dinero?
2.Si tú (y tu cónyuge si estás casado) dejaran de trabajar hoy, ¿qué sucedería con tu vida? 
¿Por cuánto tiempo podrías sobrevivir y seguir manteniendo tu estándar de vida y tu estilo de 
vida?
3.¿A qué edad podrás retirarte si todavía no lo has hecho? ¿Te  gustaría retirarte 
prematuramente? Cuando te retires, ¿estarás ganando más o menos dinero de lo que ganas 
hoy?
4.¿Preferirías vivir una vida en la que ya no necesites un cheque por un sueldo o una vida en 
la que siempre estés trabajando o buscando un trabajo que te pague más? ¿Preferirías ser 
alguien no disponible o alguien más disponible para emplearse? ¿Qué vida llevas hoy?
5.¿Quieres vivir una vida en la que trabajes duro tratando de gastar más dinero porque 
tienes demasiado o una vida en la que trabajes duro tratando de ahorrar dinero? ¿Qué vida 
llevas hoy?
6.¿Preferirías vivir una vida en la que no tengas que trabajar duro para ganar más o una vida 
en la que tengas que trabajar más duro para ganar más? ¿Qué vida vives?
7.¿Piensas que invertir es arriesgado? ¿Piensas que se necesita dinero para hacer dinero? ¿Te 
gustaría ser capaz de invertir sin dinero y sin mucho riesgo para obtener ganancias altas? Si 
pudieras invertir con el dinero de alguien más, ¿lo harías?
8.¿Quiénes son las seis personas además de tu familia con quienes pasas más tiempo? ¿Cuál 
es su actitud hacia el dinero? ¿Es rica, pobre o de clase media? De esas seis personas, 
¿cuántas podrán retirarse jóvenes y ricas? ¿Es momento para que hagas nuevos amigos?
9.¿Preferirías vivir una vida en la que trabajes para hacerte rico construyendo o comprando 
activos, o preferirías vivir una vida trabajando para tener un empleo seguro y un cheque 
fijo? ¿Qué vida estás viviendo?
10.Si te ofrecieran mil millones de dólares para dejar tu empleo, ¿lo harías? Si mil millones 
de dólares son más importante que tú trabajo, ¿por qué no ir tras los mil millones de 
dólares? ¿Específicamente qué es lo que te está deteniendo? Si no renunciarías a tu trabajo 
por mil millones de dólares... ¿entonces por qué? ¿Podrías no usar el dinero para hacer más 
cosas buenas de las que estás haciendo ahora?
11.¿Vives una vida en la que haces dinero sin importar si la bolsa va a la alza o a la baja o 
vives una vida en la que tienes miedo de que la bolsa se caiga y pierdas tu dinero? ¿Qué vida 
vives? ¿Por qué?
12.En cuanto al tema del dinero, si pudieras hacer las cosas de manera diferente, ¿qué 
harías distinto? Si hay algo que harías diferente, ¿por qué no lo estás haciendo?
La razón por la que sugiero este ejercicio, sólo si tienes el valor suficiente es porque 
después de la discusión, puedes terminar sin amigos y puedes necesitar hacer nuevos. Si 
descubres que tus familiares, amigos y compañeros de trabajo no provienen del contexto 
del que tú quieres provenir, entonces consulta nuestro sitio de Internet para que conozcas 
personas que sí provengan de tu mismo contexto. Por lo menos te divertirás discutiendo las 
respuestas que obtengas de esta prueba final de doce preguntas. Lo más importante es que 
verás las realidades y mundos diferentes de los que provienen personas diferentes en lo que 
respecta al tema del dinero. Como decía mi padre rico: "El dinero es sólo una idea". Cuando 
hagas esas preguntas, descubrirás muchas ideas y realidades diferentes.
Lo más importante de este ejercicio es escuchar diferentes pensamientos y realidades y 
decidir qué tipo de realidad o mundo financiero quieres ver. Tener dos papás me permitió ver 
ambos mundos y yo tomé mi decisión de que mundo quería ver. Así que la elección te 
corresponde a ti. Si haces esas preguntas a tus familiares y amigos, escucharás sus ideas. 
Después de escucharlas, puedes empezar a elegir mejor las ideas que quieres y el tipo de 
vida que deseas vivir.
Comparte tus resultados
Ve a nuestro sitio de Internet en richdad.com y comparte las respuestas que recibas de esta 
prueba. En nuestro foro de discusión, comparte las respuestas más cómicas, cínicas, entrete-nidas o sorprendentes que obtengas de esas preguntas. En esos foros puedes encontrar a tus 
futuros socios de negocios y volverte más rico que tus amigos o incluso más que Bill Gates. 
Hasta puedes retirarte joven y rico.
CUARTA PARTE
El apalancamiento del primer paso
Mi padre rico decía: "El primer paso es decidir en qué tipo de mundo quieres vivir. ¿Quieres 
vivir en el mundo de los pobres, la clase media o los ricos?"
"¿Qué no la mayoría de las personas elegirían vivir en el mundo de los ricos?", pregunté.
"No", dijo mi padre rico. "La mayoría de las personas sueñan con vivir en el mundo de los 
ricos... pero no dan el primer paso y eso es lo que decide. Una vez que decidas, todo cambia-rá en tu mundo".
CAPÍTULO 21
Cómo seguir adelante
Con frecuencia me preguntan: "Después de que tomaste la decisión de retirarte joven, ¿qué 
fue lo que hizo que tú y Kim siguieran adelante? ¿Cómo manejaste la adversidad y no diste 
marcha atrás en los momentos difíciles? La mayor parte del tiempo, respondo con clichés 
como determinación, gran fuerza de voluntad y visión. Empleo esos clichés usados en 
exceso porque rara vez tengo el tiempo de explicar mucho de lo que ya he explicado en este 
libro. Como ya has leído hasta aquí y, ojalá, has comprendido la mayor parte de lo que se 
ha escrito hasta este punto, compartiré contigo en mayor profundidad una explicación más 
honesta de lo que nos hizo seguir adelante.
Dos de los cuentos clásicos más profundos que mi padre rico me hizo leer fueron los de 
Lewis Carroll, Alicia en el país de las maravillas y A través del espejo. Las dos historias 
comparten el viaje a diferentes realidades. En Alicia en el país de las maravillas, Alicia 
sigue al Conejo Blanco hacia su madriguera y hacia un mundo distinto, un mundo que me 
recuerda a la industria de servicios financieros. En A través del espejo, Alicia de nuevo 
viaja a otra realidad detrás del espejo. Detrás del espejo, Alicia encuentra libros en espejo 
que no se pueden leer a menos de que se sostengan frente a un espejo, lo que se parece 
mucho a un estado financiero personal. No obstante, para mi padre rico, el valor de las dos 
historias era la idea de viajar de una realidad a otra. Mi padre rico decía: "El problema es 
que la mayoría de las personas viven sólo una realidad y tienden a pensar que su realidad es 
la única realidad".
Respondiendo una pregunta frecuente
La mayor parte del tiempo, cuando me hacen una pregunta como: "¿Qué fue lo que hizo que 
Kim y tú siguieran adelante? ¿Cómo siguieron adelante cuando estaban sin dinero, sin 
trabajo y en una ola de pérdida financiera?" Yo respondo con simples clichés desgastados y 
verdaderos. Contesto diciendo: "Se necesitó determinación". O "sabíamos que no íbamos a 
dar marcha atrás". Pero esos clichés no cuentan la historia real. Dudo en iniciar la verdadera 
explicación porque la respuesta está fuera de la realidad de la mayoría de las personas, así 
que simplemente digo muy poco.
Hace unas semanas, en un seminario, tuve el tiempo para explicar más completamente la 
razón por la que Kim y yo seguimos adelante. Como has leído hasta aquí, te diré la respuesta 
que compartí con la clase. No creo que responda por completo a la pregunta, de cómo 
hicimos para seguir adelante, pero pienso que la respuesta te dará un poco de alimento 
adicional para el pensamiento.
A medida que el seminario se acercaba al cierre, un estudiante levantó la mano y preguntó: 
"Cuando todo se veía más oscuro, ¿qué los hizo seguir adelante? Quiero escuchar la razón 
real... no las que usted ha estado dando hasta ahora".
La respuesta
Pensé un poco en su petición y al final decidí revelar la motivación que nos hizo seguir 
adelante, una vez que Kim y yo tomamos la decisión de retirarnos jóvenes y ricos. La 
explicación comenzó:
"Cuando me acercaba a los 30, mi padre rico impartió una lección que comenzó con esta 
pregunta. La lección y el diálogo duraron por años... y, aunque él se ha ido, sigo revisando la 
lección y buscando más respuestas".
Un mundo sin riesgo que no requiere nada de dinero
"¿Qué harías si no hubiera ningún riesgo y si no se requiriera nada de dinero para hacerse 
rico?", preguntó mi padre rico.
"¿Ningún riesgo y nada de dinero?", repetí, sin estar seguro de hacia dónde se dirigía mi 
padre rico con esta pregunta. "¿Por qué haces esta pregunta?" finalmente pregunté. "Un 
mundo así no existe."
Mi padre rico me dejó pensar mi respuesta durante un momento. Su silencio fue lo que me 
indicó que debía escuchar mejor mi respuesta y tomarme el tiempo de repensarla. Cuando 
supo que yo había repensado mi respuesta finalmente dijo: "¿Estás seguro de que ese mundo 
no existe?"
"¿Un mundo sin riesgo y sin que se requiera dinero?", pregunté, buscando asegurarme de 
que estábamos discutiendo los mismos puntos. Lo único que podía escuchar era a mi propio 
padre que decía: 'Invertir es arriesgado' y 'se necesita dinero para hacer dinero'.
Mi padre rico asintió con la cabeza. "Sí. ¿Qué harías si ese mundo existiera?"
"Bueno, iría a buscarlo", dije. "Pero sólo si existiera".
"¿Y por qué no habría de existir?", preguntó mi padre rico.
"Porque es imposible", repliqué. "¿Cómo podría haber un mundo donde no hubiera ningún 
riesgo monetario necesario para hacerse rico?"
"Bueno, si ya has decidido que es imposible que exista ese mundo, entonces no puede existir", 
dijo suavemente mi padre rico.
"¿Estás diciendo que no existe?", pregunté.
"No importa lo que yo piense. Lo que es importante es lo que tú piensas", dijo mi padre 
rico." Si dices que no existe... no existe. Lo que yo pienso es irrelevante".
"Pero ese mundo es imposible", repetí. "Sé que es imposible. Tiene que haber riesgo".
"Entonces no existe", mi padre rico se encogió de hombros. "Si piensas que es imposible, 
entonces es imposible". Mi padre rico ahora me estaba contestando con un poco más de 
energía y una huella de frustración en el tono de su voz. "La razón por la que no existe un 
mundo así es porque ésa es la realidad en la que fuiste educado. No puedo enseñarte más a 
menos de que estés dispuesto a cambiar de realidad. Puedo darte más y más respuestas sobre 
cómo hacerte rico, pero mis respuestas no son buenas si te aferras a la realidad de tu familia 
respecto al dinero y a cómo es la vida".
"¿Pero nada de dinero y ningún riesgo? Vamos", dije. "Sé realista. Nadie cree que exista un 
mundo donde no se necesite dinero y no haya ningún riesgo".
"Lo sé", dijo mi padre rico. "Por eso tantas personas se afeitan a un trabajo seguro y con 
frecuencia suponen que invertir es arriesgado o que se necesita dinero para hacer dinero. 
No cuestionan sus suposiciones. No retan sus suposiciones. En cambio, creen que lo que 
suponen es real, sin preguntarse nunca si podría haber otra realidad o quizá una suposición 
diferente. No puedes hacerte más rico si primero no cuestionas las suposiciones de tus 
creencias. Por eso muy pocas personas se hacen ricas o alcanzan la libertad financiera. Pero 
sigues sin responder la pregunta."
"Pues repite la pregunta", contesté, sintiéndome muy frustrado y preguntándome lo que 
quería decir con no cuestionar mis suposiciones.
"La pregunta fue: ¿Qué harías si no hubiera riesgo y no se necesitara hacer dinero para 
volverse rico?", dijo mi padre rico, repitiendo sus palabras lenta y deliberadamente, haciendo 
su mejor esfuerzo para dejar pasar mi reacción a la pregunta, de modo que pudiera escuchar 
la pregunta.
"Sigo pensando que es una pregunta ridícula, pero de cualquier manera la responderé", 
contesté.
"¿Por qué dices que es ridícula?", preguntó mi padre rico.
"Porque no existe un mundo así", contesté bruscamente. "Es una pregunta tonta y un 
desperdicio de tiempo. ¿Por qué debería contestar o pensar siquiera en una pregunta así?"
"Está bien", dijo mi padre rico. "Ya obtuve mi respuesta. También puedo escuchar tu suposición 
subyacente. Para ti es un desperdicio de tiempo siquiera pensar en ese mundo así que no te 
molestarías en pensar en la pregunta. Supones que ese mundo no existe de modo que piensas 
que cuestionar esa idea es un desperdicio de tiempo. No quieres cuestionar tu suposición. Así 
que como no piensas que ese mundo exista no quieres pensar en ello. Sólo quieres pensar en la 
forma en que siempre has pensado. Quieres hacerte rico pero vives con miedo de perder dinero 
o vives con la idea de que no tienes suficiente dinero. Para mí, ésa es una realidad extraña, pero 
puedo aceptar tu respuesta. Entiendo tus suposiciones, porque son suposiciones comunes".
"No, no, no", dije. "Voy a responder a tu pregunta. Sólo te estoy preguntando si estás diciendo 
que ese mundo existe", dije, alzando la voz, poniéndome muy enojado y a la defensiva.
Mi padre rico se quedó sentado en silencio, otra vez sin responder a mi pregunta y dejando 
que me escuchara a mí mismo. Estaba dejando que escuchara mi realidad.
"¿Quieres que crea que ese mundo existe?", pregunté acaloradamente.
"Déjame que repita lo que ya dije. No importa lo que yo crea", dijo mi padre rico. "Es lo 
que tú creas."
"Bueno, bueno, bueno", dije. "Si existiera un mundo así, un mundo sin riesgo financiero y 
un mundo donde no se necesitara usar nada de dinero para hacerme rico, entonces sería más 
rico de lo que jamás he soñado. No estaría asustado. No inventaría la excusa de que no 
tengo nada de dinero o de que podría fracasar. Viviría en un mundo de abundancia infinita... 
un mundo donde podría tener todo lo que deseara. Viviría en un mundo completamente 
diferente... definitivamente no en un mundo en el que fui educado".
"Así que si ese mundo existiera, ¿valdría la pena el viaje?", preguntó mi padre rico.
"Por supuesto", contesté firmemente. "¿Quién no haría el viaje?"
Mi padre rico simplemente se encogió de hombros en silencio, dejando que yo escuchara de 
nuevo mis propias palabras.
"¿Estás diciendo que ese mundo existe?", volví a preguntar.
"Eso lo tienes que decidir tú. Puedes decidir qué tipo de mundo existe. Yo no puedo hacerlo 
por ti", dijo mi padre rico. "Yo tomé mi decisión años atrás respecto a qué tipo de mundo 
quería hacer que existiera."
"¿Encontraste tu mundo", pregunté.
Mi padre rico nunca contestó la pregunta. Su única respuesta fue: "¿Recuerdas la historia de 
Alicia y A través del espejo?"
Asentí con la cabeza.
"Hace años, atravesé el espejo. Si crees que ese mundo existe, entonces debes decidir hacer el 
viaje a través del espejo. Pero sólo harás el viaje si crees en la posibilidad de que exista un 
mundo así. Si no crees que existe, entonces sólo verás un espejo y seguirás de este lado del 
espejo, mirando solamente cómo te miras".
Mi respuesta a la clase
Cuando compartí esa historia con la clase, se quedaron en silencio. No sé si mi respuesta tenía 
sentido. Sin importar si lo tenía o no, les había dado la historia detrás de la historia. 
Comenzando a retomar la respuesta, dije: "Así que entonces fue cuando comenzó el viaje. 
Después de esa conversación con mi padre rico me entró mucha curiosidad. Pensé sobre lo 
que él dijo durante varios años. Entre más pensaba en ello, más se volvía una posibilidad lo 
que decía. Cuando tenía treinta y tantos años, supe que tenía que empujar mi realidad. Supe que 
mis días de escuela con mi padre rico habían terminado. Supe que él no podía enseñarme 
mucho más ni darme más respuestas hasta que yo decidiera cambiar mi realidad y comenzar 
mi viaje. Más respuestas no iban a ayudar. Necesitaba una nueva realidad expandida. Supe que 
era momento de dejar el nido, como suelen decir. No sabía si existía un mundo así, pero yo 
quería que existiera. De modo que mi viaje comenzó una vez que tomé la decisión de que un 
mundo así era posible. Con esa decisión, fui a buscar ese mundo, un mundo donde no 
hubiera riesgo y un mundo donde no se necesitara dinero para hacer dinero. Estaba cansado de 
mirar al espejo y de que no me gustara lo que veía. Fue en entonces cuando fui a buscar un 
mundo a través del espejo".
La clase permaneció en silencio. Podía sentir que algunos estaban abiertos a la idea y que 
otros estaban luchando con ella. Un estudiante levantó la mano y dijo: "¿Así que creíste que 
ese mundo existía? ¿Es eso lo que nos estás diciendo?"
No respondí a su pregunta. En cambio, simplemente seguí con la historia.
"Poco después de tomar la decisión de que ese mundo podía ser posible, conocí a Kim y le 
conté del viaje en el que me estaba embarcando. Por alguna razón, ella quería venir 
conmigo". Dijo: "Bueno, lo que dices sacude la realidad que tengo ahora... la realidad de 
trabajar en un empleo toda mi vida. No me gusta mi realidad actual de modo que estoy 
dispuesta a encontrar una nueva realidad".
El estudiante que estaba tratando de que yo respondiera a su pregunta finalmente bajó la 
mano y simplemente escuchó.
"Kim era la primera mujer que conocía que estaba dispuesta a dar cabida a una idea tan loca. 
Yo dudé en decirle, sin embargo, ella no luchó contra mis ideas. En cambio, escuchó durante 
días mientras yo le contaba sobre el mundo que pensaba era posible. Fue entonces cuando 
nuestro viaje comenzó. Así que, fielmente, les digo a todos ustedes que, más que cualquier 
otra cosa, fue la búsqueda de ese mundo lo que hizo que Kim y yo siguiéramos adelante.
"Una vez que tomamos la decisión, comenzamos nuestro viaje a través del espejo. Sabíamos 
que una vez que comenzara el viaje, necesitaríamos ser valientes, humildes, tendríamos que 
estudiar, seguir aprendiendo, aprender rápidamente a medida que aparecieran lecciones, y, lo 
más importante, seguimos empujando nuestra realidad, pues sabíamos que el viaje estaba sólo 
en nuestra mente y en nuestro corazón. Sabíamos que el viaje tenía poco que ver con el 
mundo fuera de nosotros y tenía todo que ver con las realidades dentro de nosotros. Cuando 
las cosas se pusieron realmente mal, fue esa búsqueda de una realidad diferente, un mundo 
diferente, lo que al final nos hizo seguir adelante. Una vez que el viaje comenzó, supimos 
que nunca íbamos a volver atrás. La búsqueda de un mundo diferente es lo que nos hizo 
seguir adelante".
Hubo un largo silencio en la sala del seminario. De pronto, una estudiante levantó la mano y 
preguntó: "¿Así que lo encontraron? Dígame que lo encontraron. Si existe, yo quiero ir. No 
quiero pasarme 50 años de mi vida trabajando por dinero. No quiero pasar una vida entera 
recibiendo órdenes por dinero, viviendo con el miedo de no tener dinero suficiente. Dígame 
que existe otro tipo de mundo".
Hice una pausa por un momento, haciendo con ellos lo que mi padre rico había hecho 
conmigo una y otra vez muchos años atrás, dándoles el tiempo necesario para escuchar sus 
propias realidades.
"Eso lo tienes que decidir tú", respondí finalmente después de un silencio prolongado. "No es 
lo que yo creo, es lo que tú crees que existe. Si piensas que ese mundo existe para ti, en-tonces atravesarás el espejo. Si no, entonces te quedarás de este lado del espejo, mirándote 
cómo te miras. En lo que respecta al dinero, tienes el poder de decidir lo que es real y en qué 
tipo de realidad quieres vivir".
La clase terminó. La mayoría de los  alumnos estaban enfrascados en profundos 
pensamientos. Mientras terminaba de guardar mis cosas en el portafolio, me volví hacia 
ellos y dije: "Gracias por su atención. Gracias por escuchar. La clase ha terminado, pueden 
irse".
Para cerrar
En el otoño de 1994, Kim y yo nos tomamos una pausa prolongada en Fidji. Un amigo nos 
había recomendado ese pequeño resort exclusivo en una pequeña isla privada. Antes de que 
saliera el sol una mañana, un miembro del personal del hotel nos saludó en nuestra lujosa 
cabaña de hojas. "Sus caballos están listos", dijo con una sonrisa y en un susurro.
En ese momento, llevábamos cinco días en la isla. Yo finalmente me estaba relajando, 
tranquilizando y estaba entrando más en sincronía con el lento y suave ritmo de esa hermosa 
isla paradisíaca, rodeada por las aguas azules y cristalinas del océano Pacífico. Habían pasado 
nueve años desde que Larry, Kim y yo nos habíamos sentado en la montaña Whistler, al 
norte de Vancouver, en la Columbia Británica, cubiertos de nieve, congelados y creando 
nuestros planes de libertad financiera. Mientras subía a mi caballo, miré en retrospectiva esa 
época en la helada montaña. Acomodando la silla de montar, pensé en lo diferentes que eran 
las cosas ahora en nuestras vidas. Ya no estábamos tiritando de frío y ya no éramos pobres, 
sin nada de dinero. Más importante que simplemente tener mucho dinero, ahora éramos 
libres. Nunca más teníamos que trabajar por el resto de nuestra vida.
Los caballos lentamente vagaron por el sendero que corría paralelo a la hermosa playa de 
arena blanca que rodeaba la isla. Aunque yo no podía ver nada pues seguía estando oscuro, 
podía escuchar el océano a unos centímetros de distancia y podía sentir la brisa del mar a 
medida que el caballo navegaba suavemente por el sendero angosto de la playa. El olor del 
suelo de la isla y de las plantas tropicales, combinado con el aire salado, me llevó de regreso 
a mi niñez en Hawai, en la época en que Hawai seguía siendo Hawai. Aunque el paseo en 
caballo fue corto, los recuerdos que vinieron abarcaban toda una vida.
Después de un paseo de media hora, el miembro del personal del hotel detuvo los caballos y 
nos ayudó a bajar. A una distancia cercana, podía ver varias velas que bailaban al viento. El 
guía nos tomó de la mano y suavemente nos llevó hacia las velas. Las velas estaban sobre una 
mesa con un mantel blanco, en la arena, a unos cuantos centímetros de las olas que rompían 
sutilmente. El miembro del personal del hotel hizo que Kim y yo nos sentáramos en la única 
mesa del restaurante más hermoso del mundo. En cuanto nos sentamos, apareció otro 
miembro del personal del hotel con una botella de la champaña preferida de mi esposa. A la 
luz de las velas, Kim y yo brindamos por nosotros y por nuestro viaje. Nunca en mi vida 
había sentido más amor por mi bella esposa. Se había quedado conmigo en medio de algunas 
de las épocas de mayor prueba de mi vida. No dijimos nada. En silencio, nos acercamos a 
través de la pequeña mesa y nos tomamos de la mano, con la otra, sostuvimos nuestras copas 
de champaña y, con la mirada, dijimos: "Gracias y te amo". Lo habíamos logrado.
Como en señal, el resplandor del sol se asomó por el horizonte del océano y empezamos a 
ver cómo nos rodeaba la obra maestra de la naturaleza. En un lado pudimos ver cómo la 
exuberante isla verde se elevaba del mar. Frente a nosotros había prístina arena blanca y 
detrás había altos árboles verdes con pájaros que comenzaban a trinar. A través de la arena, 
como uniendo todas las cosas, estaba un mar azul en calma que se extendía de la playa y 
saludaba al sol.
El mesero nos trajo el desayuno de frutas tropicales mientras permanecíamos sentados en 
silencio viendo cómo el sol se levantaba del agua, iluminando la belleza que nos rodeaba. 
Excepto por el mesero, ahí sólo había tres personas. Había casi un silencio perfecto, sólo los 
sonidos de la naturaleza. No había vecinos, ni autos ni gente que paseara por la playa ni 
música fuerte, ni teléfonos celulares. Lo mejor de todo es que no había un negocio al que 
tuviéramos que regresar. Nada de juntas. Nada de fechas límite. Nada de presupuestos. El 
negocio había desaparecido. Había hecho su trabajo y lo habíamos vendido. No había nada a 
lo que tuviéramos que regresar en casa, excepto a nuestra libertad. Lo único que había en ese 
momento éramos Kim y yo y la avasalladora belleza de la naturaleza... la magnificente 
creación de Dios.
Justo cuando el sol finalmente salió libre del agua, algo estalló dentro de mi cabeza. Mi 
visión no se nubló, simplemente pareció vibrar y luego el resto de mi cuerpo se agitó muy 
brevemente. Fue un terremoto diminuto, un temblor repentinamente había movido mi cuerpo y 
mi alma. Algo estaba cambiando muy dentro de mí. La experiencia hizo que me relajara 
aún más. A medida que la calidez del sol comenzó a llegar a nosotros a través del agua, un 
sentimiento de enorme gratitud empezó en mi pecho y se extendió a todo mi cuerpo. Sin 
darme cuenta, mi contexto había cambiado por completo... había cruzado el espejo y ahora 
podía ver claramente una nueva forma de vida. Comencé a llorar, no con tristeza, sino 
profundamente maravillado por la perfección, generosidad y abundancia que nos rodeaba no 
sólo a Kim y a mí... sino a todos nosotros.
Lentamente, me di cuenta de que demasiado tiempo mi miedo de no ser suficiente o de no 
tener suficiente me impidió disfrutar de la abundancia que ofrece la vida aquí en la tierra. 
Me di cuenta de que mi lucha personal por hacerme rico era principalmente mi lucha 
personal contra mi miedo de ser pobre. También me di cuenta de por qué mi padre rico 
siempre dijo: "Es tu miedo lo que te hace tu propio prisionero. Es tu miedo lo que te 
encierra en tu propia celda, una prisión que no deja entrar la abundancia de Dios". Mi mente 
vagó hacia mi juventud y pude escucharlo diciendo: "Demasiado a menudo pensamos que 
estamos solos y que tenemos que sobrevivir por nuestra cuenta. A menudo nos enseñan que 
es la supervivencia de los mejor armados y que si no estamos bien armados no podemos 
sobrevivir. Ésa es la forma como piensa un prisionero. Muchas personas son prisioneros 
financieros de sus miedos. Por eso se aferran a hilos de seguridad, se vuelven codiciosos y 
luchan por sobras de dinero como perros hambrientos por un hueso sin carne, en vez de 
buscar la libertad financiera.
"Encontrar tu propia libertad es fácil. Lo único que tienes que hacer es primero ver y darte 
cuenta de lo que Dios quiere que se haga y luego hacer lo que Él quiere que se haga con los 
dones que te ha dado. Si lo haces fielmente, la abundancia de Dios se derramará en tu vida. 
Vivir no se trata de ganarse la vida. Sólo mira las aves, las plantas y toda la creación de la 
naturaleza que hay a tu alrededor. Las aves no se ganan la vida. Las aves y las demás criaturas 
de Dios simplemente hacen lo que fueron enviadas a hacer aquí. Si simplemente confías en 
Dios y haces lo que fuiste enviado a hacer, la abundancia de Dios estará contigo para siempre". 
Mi padre rico también decía: "No tienes que hacer el trabajo de las aves... las aves ya lo están 
haciendo". Lo dijo porque vio a demasiados seres humanos compitiendo por empleos en lugar 
de ver lo que se necesita hacer. Decía: "Si miras para darte cuenta de lo que se necesita hacer, 
y haces lo que se necesita hacer, entrarás en la abundancia de Dios".
Kim y yo permanecimos sentados en nuestra pequeña mesa en la playa durante otra hora. Por 
primera vez en mi vida, entendí lo que mi padre rico estaba diciendo. No lo había entendido 
por completo antes de esto. Seguía teniendo mi contexto o realidad personal en la forma en 
que dejaba que sus palabras entraran. Pero, sentado en la playa, finalmente di el paso para 
cruzar el espejo y comprendí por completo a mi padre rico.
Mientras el viento del océano comenzaba a soplar, podía escuchar cómo los caballos se 
inquietaban en el fondo. Era momento de que se fueran a casa y también lo era para Kim y 
para mí. Un año después, estaba sentado en silencio en mi cabaña de la cima de la montaña 
haciéndome las siguientes preguntas: "¿Qué se necesita hacer?" y "¿qué puedo hacer?"
Cuando hoy en día las personas me preguntan por qué sigo trabajando a pesar de que no 
necesito el dinero, la respuesta es la de mi padre rico. Digo: "Sigo trabajando porque hay 
cosas que se necesitan hacer". Hoy, lo único que hacemos Kim y yo es apalancar lo que 
hemos aprendido para hacer más de lo que se necesita hacer. Irónicamente, entre más 
aplicamos apalancamiento Kim y yo para hacer lo que se necesita hacer, más felices y más 
ricos nos volvemos.
La buena noticia es que no tienes que renunciar a tu trabajo para hacer lo que se necesita 
hacer. No tienes que retirarte para hacer lo que se necesita. Sólo mira a tu alrededor y verás 
qué es lo que se necesita hacer. Lo único que tienes que hacer es lo que se necesita hacer 
con los dones que has recibido. Si lo haces, entrarás en la abundancia... la abundancia que 
siempre ha estado ahí para todos nosotros... no sólo para algunos.
Pasé mi último día en la hermosa isla privada en Fidji sentado en la playa sin hacer 
absolutamente nada. No tenía nada para lo cual ir a casa excepto por una forma de vida 
completamente nueva... viviendo como una persona libre. Apreté la mano de Kim, dejándole 
saber lo mucho que la amaba, la respetaba y le agradecía por haberse quedado a mi lado a lo 
largo de este viaje. No lo habría podido lograr sin ella. Justo antes de que recogiéramos 
nuestro tapete de playa y nos dirigiéramos de regreso para la cena, pude escuchar a mi padre 
rico que decía: "Muchas personas pequeñas se pasan la vida atacando gigantes. Critican, 
chismean, extienden rumores y mienten al respecto, haciendo su mejor esfuerzo por 
despedazarlos. Ven lo que está mal en el gigante en lugar de ver lo que está bien. Por esa 
razón permanecen pequeñas. David pudo haber sido joven, y no tenía mucho, sólo una 
simple honda, y pudo haber sido físicamente más pequeño que Goliat, pero David no era 
una persona pequeña". El objetivo de este libro es que cada uno de nosotros tiene a una 
persona pequeña, un David, y a un Goliat en el interior. David pudo haberse quedado como 
una persona pequeña tomando el contexto de una persona pequeña, diciendo: "Él es más 
grande que yo. ¿Cómo puedo encargarme de un gigante tan solo con una honda?" En cambio, 
David se convirtió en un gigante al elegir tomar el contexto de un gigante. Así es cómo 
venció a Goliat y se convirtió en gigante él mismo. Tú puedes hacer lo mismo.
Para cerrar, el apalancamiento está en todas partes. El apalancamiento es poder. El 
apalancamiento se encuentra dentro de nosotros, en todo lo que nos rodea y ha sido 
inventado para nosotros. Con cada nuevo invento, inventos como el automóvil, el aeroplano, 
el teléfono, la televisión y el Internet, se ha inventado un nuevo apalancamiento. Con cada 
nueva forma de apalancamiento, se crean nuevos millonarios y multimillonarios porque 
usaron el apalancamiento, no arruinaron o abusaron del nuevo apalancamiento. Así que 
siempre recuerda que el poder del apalancamiento en tu vida depende de ti y sólo de ti.
Gracias por haber leído este libro y recuerda mantener un contexto abierto. El futuro es 
muy brillante y traerá libertad para más y más personas.
Sobre los autores
Robert T. Kiyosaki
"La principal razón por la que las personas tienen dificultades financieras es porque pasan 
años en la escuela pero no aprenden nada sobre el dinero. El resultado es que la gente aprende 
a trabajar por dinero... pero nunca aprenden a hacer que el dinero trabaje por ellos", afirma 
Robert.
Nacido y criado en Hawai, Robert es un estadounidense-japonés de cuarta generación. 
Proviene de una prominente familia de educadores. Su padre fue director de educación del 
Estado de Hawai. Después de la preparatoria, Robert fue educado en Nueva York y, tras su 
graduación, se unió al Cuerpo de Marines de Estados Unidos y viajó a Vietnam como oficial 
y piloto de un helicóptero de artillería.
Al regreso de la guerra comenzó su carrera de negocios. En 1977 fundó una compañía que 
introdujo al mercado las primeras carteras "de surfista" hechas de nylon y velero, que se con-virtieron en un producto de ventas multimillonarias en el mundo entero. Él y sus productos 
fueron presentados en las revistas  Runner´s World, Gentleman´s Quarterly, Success 
Magazine, Newsweek, incluso en Playboy.
Al dejar el mundo de los negocios, fue cofundador, en 1985, de una compañía educativa 
internacional que operaba en siete países, enseñando negocios e inversión a decenas de 
miles de graduados.
Después de retirarse a la edad de 47 años, Robert hace lo que más disfruta... invierte. 
Preocupado por la creciente brecha entre los que tienen y los que no tienen, Robert creó un 
juego de mesa denominado CASHFLOW, que enseña el juego del dinero antes sólo 
conocido por los ricos.
A pesar de que el negocio de Robert son los bienes raíces y el desarrollo de compañías de 
pequeña capitalización, su verdadero amor y pasión es la enseñanza. Ha compartido el esce-nario en conferencias con grandes como Og Mandino, Zig Ziglar y Anthony Robbins. El 
mensaje de Robert Kiyosaki es claro. "Asuma la responsabilidad por sus finanzas u obedez-ca órdenes toda su vida. Usted es el amo del dinero o su esclavo". Robert ofrece clases que 
duran entre una hora y tres días, para enseñar a la gente sobre los secretos de los ricos. 
Aunque sus materias van desde la inversión en pos de altos rendimientos y bajo riesgo, 
enseñar a sus hijos a ser ricos, fundar compañías y venderlas, tiene un sólido mensaje 
trepidante. Y ese mensaje es: "Despierte el genio financiero que lleva dentro. Su genio está 
esperando salir".
Esto es lo que el mundialmente famoso conferencista y autor Anthony Robbins dice acerca 
del trabajo de Robert:
"El trabajo de Robert Kiyosaki en la educación es poderoso, profundo y capaz de cambiar 
vidas. Reconozco sus esfuerzos y lo recomiendo enormemente".
Durante esta época de grandes cambios económicos, el mensaje de Robert no tiene precio.
Sharon L. Lechter
Esposa y madre de tres hijos, contadora pública certificada, consultora de las industrias de 
publicaciones y juguetes, y propietaria de su negocio, Sharon Lechter ha dedicado sus 
esfuerzos profesionales al campo de la educación.
Se graduó con honores en la Universidad Estatal de Florida con un grado académico en 
contabilidad. Se unió a las filas de lo que entonces era uno de los ocho grandes despachos de 
contadores y siguió adelante hasta convertirse en directora financiera de una compañía 
innovadora de la industria de la computación, directora de asuntos fiscales de una compañía 
nacional de seguros y editora asociada de la primera revista regional femenina en Wisconsin, 
al mismo tiempo que mantenía sus credenciales profesionales como contadora pública.
Su enfoque cambió rápidamente hacia el ámbito de la educación al observar a sus tres hijos 
crecer. Era difícil lograr que leyeran. Ellos preferían ver la televisión.
De manera que estuvo encantada de unir sus fuerzas con el inventor del primer "libro 
parlante" electrónico y ayudar a expandir la industria del libro electrónico hasta convertirla 
en un mercado internacional de muchos millones de dólares. Actualmente sigue siendo 
pionera en el desarrollo de nuevas tecnologías encaminadas a llevar nuevamente el libro a la 
vida de los niños.
Conforme sus propios hijos crecieron, ella se involucró activamente en su educación. Se 
convirtió en una activista de la audioenseñanza en las áreas educativas de matemáticas, 
computadoras, lectura y escritura.
"Nuestro sistema educativo no ha sido capaz de seguir el paso a los cambios globales y 
tecnológicos del mundo actual. Debemos enseñarle a nuestros jóvenes las habilidades, tanto 
académicas como financieras, que necesitarán no sólo para sobrevivir, sino para florecer en 
el mundo que enfrentan".
Como coautora de Padre rico, padre pobre y de CASHFLOW Quadrant (El cuadrante del 
flujo de dinero), ahora enfoca sus esfuerzos en ayudar a crear herramientas educativas para 
cualquiera que esté interesado en mejorar su propia educación financiera.
             * 
             * 
             */

            #endregion
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'WebFormTest.Button1_Click(object, EventArgs)'
        protected void Button1_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'WebFormTest.Button1_Click(object, EventArgs)'
        {
            svrkofax.wsCSI csi = new svrkofax.wsCSI();
            System.Data.DataSet ds = new System.Data.DataSet();

            //1: registro mercantil
            //2: nombre social
            switch (rbList.SelectedValue)
            {
                case "RM":
                    ds = csi.getPathCamaraOnline(1, txtValue.Text);
                    rdDocumentos.DataSource = ds.Tables[0];
                    break;
                case "Nombre":
                    ds = csi.getPathCamaraOnline(2, txtValue.Text);
                    rdDocumentos.DataSource = ds.Tables[0];
                    break;
            }
            rdDocumentos.DataBind();

            //Onapi
            //wsOnapi2.ServicioCC onapi = new wsOnapi2.ServicioCC();
            //wsOnapi2.ResultadoBusquedaNombre res =  onapi.BuscarNombrePorNumero(123456, "cc", "abc");


        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'WebFormTest.Button2_Click(object, EventArgs)'
        protected void Button2_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'WebFormTest.Button2_Click(object, EventArgs)'
        {
            string key = Cryptography.Decrypt(Request["test"]);

            Response.Redirect(string.Format("/Empresas/WebFormTest.aspx?test={0}", key));
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Cryptography'
    public class Cryptography
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Cryptography'
    {

        #region Fields

        private static byte[] key = { };
        private static byte[] IV = { 38, 55, 206, 48, 28, 64, 20, 16 };
        private static string stringKey = "!5663a#KN";

        #endregion
        #region Public Methods

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Cryptography.Encrypt(string)'
        public static string Encrypt(string text)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Cryptography.Encrypt(string)'
        {
            try
            {

                key = Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                Byte[] byteArray = Encoding.UTF8.GetBytes(text);

                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                    des.CreateEncryptor(key, IV), CryptoStreamMode.Write);

                cryptoStream.Write(byteArray, 0, byteArray.Length);
                cryptoStream.FlushFinalBlock();

                return Convert.ToBase64String(memoryStream.ToArray());

            }

#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                // Handle Exception Here
            }

            return string.Empty;

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Cryptography.Decrypt(string)'
        public static string Decrypt(string text)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Cryptography.Decrypt(string)'
        {
            try
            {

                key = Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] byteArray = Convert.FromBase64String(text);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                des.CreateDecryptor(key, IV), CryptoStreamMode.Write);

                cryptoStream.Write(byteArray, 0, byteArray.Length);
                cryptoStream.FlushFinalBlock();

                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }

#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                // Handle Exception Here

            }

            return string.Empty;
        }

        #endregion

    }
}