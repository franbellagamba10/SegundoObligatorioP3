create database ObligatorioP3
use ObligatorioP3

create table Usuarios(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	email varchar(50) NOT NULL UNIQUE,
	contrasenia varchar(20) NOT NULL,
	activo bit DEFAULT 1 NOT NULL,
);

create table Compra(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	fecha DateTime NOT NULL,	
);  --No hay List<item> porque es complicado almacenarlo asi
	--hay una tabla Compra_item que guarda como FKs idPlanta y idCompra

create table CompraImportacion(
	id int NOT NULL UNIQUE, 
	impuestoImportacion decimal not null DEFAULT 0,
	esSudamericano bit NOT NULL,
	tasaArancelaria decimal NOT NULL DEFAULT 0,
	medidasSanitarias varchar(max)

	FOREIGN KEY (id) REFERENCES Compra(id),
);

create table CompraPlaza(
	id int NOT NULL UNIQUE,
	IVA decimal NOT NULL DEFAULT 0,
	cobroFlete bit NOT NULL,
	costoEnvio decimal DEFAULT 0,

	FOREIGN KEY (id) REFERENCES Compra(id)
);



create table TipoPlanta( 
	id int IDENTITY(1,1) NOT NULL Primary Key,
	nombre varchar(20) UNIQUE,
	descripcion varchar(max)
);



create table FrecuenciaRiego(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	tiempo varchar(20) NOT NULL, -- ??? -----> por que string?
	cantidad int NOT NULL
);

create table TipoIluminacion(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	iluminacion varchar(20) NOT NULL
);	--### podriamos agregarle una descripcion.

create table Ficha(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	frecuenciaRiego int NOT NULL,
	tipoIluminacion int NOT NULL,
	temperatura decimal NOT NULL,

	FOREIGN KEY (frecuenciaRiego) REFERENCES FrecuenciaRiego(id),
	FOREIGN KEY (tipoIluminacion) REFERENCES TipoIluminacion(id)	
);

create table Planta(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	tipo int NOT NULL,
	nombreCientifico varchar(50) NOT NULL UNIQUE,
	nombresVulgares varchar(max) NOT NULL, --En BD lo manejamos como cadena unica, separados por una coma. pero en la solucion lo recibimos como una lista y la desarmamos.
	descripcion varchar(max) NOT NULL,
	ambiente int NOT NULL,
	alturaMaxima int NOT NULL,
	foto varchar(50),
	precio decimal NOT NULL, -- !!!!! en el UML es DOUBLE, no supe que poner xq double no existe en SQL
	ficha int NOT NULL,
	ingresadoPor int,
	
	FOREIGN KEY (tipo) REFERENCES TipoPlanta(id),
	FOREIGN KEY (ingresadoPor) REFERENCES Usuarios(id),
	FOREIGN KEY (ficha) REFERENCES Ficha(id),
)

create table Items(
	compra int NOT NULL,
	planta int NOT NULL,
	cantidad int NOT NULL DEFAULT 1,
	precioUnidad decimal NOT NULL,

	FOREIGN KEY (compra) REFERENCES Compra(id),
	FOREIGN KEY (planta) REFERENCES Planta(id),
);

--Ignorar esto, es una idea para guardar las constantes que podamos llegar
-- a necesitar, no esta implementado
create table Constantes(
	id int IDENTITY(1,1) NOT NULL,
	descripcion varchar(20) NOT NULL,
	valorString varchar(10),
	valorDecimal decimal,
	valorBool bit,
	valorInt int
);
drop table Constantes;


-- ####################################
--			PRECARGA DE DATOS
-- ####################################

INSERT INTO Usuarios
VALUES
('francesco@ort.edu.uy','Francesco1992!',1),
('plinio@ort.edu.uy','Plinio1972!',1),
('juanmanuel@ort.edu.uy','Juanma1995!',1),
('martin@ort.edu.uy','Martin1991!',1),
('gervaz@ort.edu.uy','Gervaz1951!',1);


INSERT into TipoPlanta
VALUES
--ID-Nombre-Descripcion
('Salicaceae','Familia de plantas perteneciente al orden Malpighiales. La componen �rboles o arbustos caducifolios y dioicos. Hojas alternas, simples, estipuladas. Flores inconspicuas, unisexuales, aclam�deas, acompa�adas de br�cteas y reunidas en amentos.'),
('Leguminosae','Familia del orden de las fabales. Re�ne �rboles, arbustos y hierbas perennes o anuales, f�cilmente reconocibles por su fruto tipo legumbre y sus hojas compuestas y estipuladas.Es una familia de distribuci�n cosmopolita con aproximadamente setecientos treinta g�neros.'),
('Verbenaceae','Verbenaceae o verben�ceas es una amplia familia de plantas, principalmente tropicales, de �rboles, arbustos y hierbas.'),
('Anacardiaceae','Anacardiaceae es una familia de plantas esencialmente arb�reas y arbustivas perteneciente al orden Sapindales. La constituyen 77 g�neros con unas 700 especies aceptadas, de las casi 3000 descritas, propias de pa�ses tropicales, c�lidos y templados.'),
('Euphorbiaceae','Euphorbiaceae es una familia cosmopolita muy difundida y diversificada en la zona tropical con 300 g�neros y alrededor de 7500 especies, la mayor�a de ellas matas y hierbas aunque tambi�n, en especial en los tr�picos, �rboles y arbustos; monoicas o dioicas, t�picamente con l�tex. Algunas son suculentas que se asemejan a los cactus.'),
('Palmae','Las arec�ceas o Palmae son una familia de plantas monocotiled�neas, la �nica familia del orden Arecales. Normalmente se las conoce como palmeras o palmas. Los individuos de esta importante familia son f�ciles de reconocer visualmente, aunque puede haber confusi�n con especies de las familias Cycadaceae y Zamiaceae debido a las similitudes morfol�gicas'),
('Flacourtiaceae','Familia de plantas con flores, incluida en varios sistemas de clasificaci�n, entre ellos el de Cronquist, hoy obsoleto. A menudo se le ha achacado a Arthur Cronquist el h�bito de incluir en esta familia a todos los miembros que no pose�an una clara caracter�stica para ser incluidas en otras familias'),
('Combretaceae','Familia del orden de las mirtales, que comprende alrededor de 600 especies de �rboles, arbustos y trepadoras en 20 g�neros. Su h�bitat se extiende por los tr�picos y subtr�picos; en ella se encuentran los g�neros Laguncularia y Lumnitzera, dos mangles.');
--(9,'',''),
--(10,'',''),


INSERT into FrecuenciaRiego
VALUES
--ID-Tiempo-Cantidad
('Hora',1),
('Dia',1),
('Semana',1),
('Mes',1),
('A�o',1);

INSERT into TipoIluminacion VALUES ('Directa'),('Indirecta'),('Sombra');

INSERT into Ficha
VALUES
--ID-IDFR-IDTI-Temperatura
(1,1,25),
(2,1,25),
(2,2,20),
(3,1,25),
(3,1,25),
(2,2,20),
(2,2,20),
(3,1,25),
(3,1,25),
(2,3,10),
(2,2,20),
(3,3,15);
--(13,3,1,25),
--(14,2,1,10),
--(15,2,1,20),
--(16,3,1,15)


INSERT	INTO Planta
VALUES 
--(0,'tipo','NombreCientifico','NombresVulgares','descripcion',IDAmbiente,alturaMaxima,'foto',precio,IDficha,IDUsuarioquelain),
(1,'Salix humboldtiana Willd','Sauce Criollo','Porte: �rbol que alcanza hasta 10 metros de altura, dioico, corteza persistente, inerme.
Follaje: caduco, verde claro, ramillas colgantes.
Hojas: simples, alternas, linearlanceoladas, de borde aserrado, glabras, �pice agudo, base cuneada de 6 a 12 cm. de largo.
Flores: aperiantadas, en amentos. Los masculinos de 7 cm. de largo, amarillentos; los femeninos verdes, de 3-3,5 cm. de largo. Florece en primavera.
Habitat: vive en los bordes de los r�os y arroyos en todo el Uruguay y con m�s frecuencia en el noroeste del pa�s.
Area de dispersi�n: crece en Am�rica subtropical, en la Argentina hasta el norte de la Patagonia, Brasil, Paraguay y Uruguay.
Usos: la madera es blanda y liviana, se utiliza para la fabricaci�n de envases.',1,1000,'Salix_humboldtiana_Willd_001.JPG',500,1,1),
(2,'Inga uruguensis Hooker et Arnott','"Ing�", "Ang�", "Inga banana","Pacay"','Porte: arbusto de altura media, entre 4 y 10 metros. Ramas con lenticelas en l�neas transversales, inerme.
Follaje: perenne, verde oscuro, inerme.
Hojas: compuestas, 3-7 yugadas, raquis y pec�olo alado de 2-14 cm. de largo, alas en el raquis semiovales de hasta 4 mm. de largo cada una.
Flores: en espigas axilares, pedunculadas, flor�feras en su mitad apical, floraci�n centr�peta. Estambres numerosos en un penacho blanco. Florece en verano.
Fruto: legumbre afelpada oblonga, poco arqueada, cori�cea de 7- 13 cm. de ancho por 1,5-2,5 cm. de largo, con dos bordes prominentes.
Habitat: especie heli�fila y selectivamente higr�fita. Se la encuentra en el Alto y Bajo R�o Uruguay, parece tratarse de una especie exclusiva de las m�rgenes de los r�os.
Area de dispersi�n: Brasil austral, Paraguay, Uruguay, y nordeste de la Argentina.
Uso:los frutos son comestibles.',1,1000,'Inga_uruguensis_Hooker_et_Arnott_001.JPG',1100,2,2),
(3,'Aloysia gratissima','"Cedr�n de Monte", "Ni�arup�", "Reseda del campo"','Porte: arbusto que alcanza una altura m�xima de 3 metros, de aspecto desordenado, con ramas agudo espinosas.
Follaje: ralo, persistente
Hojas: simples, opuestas, a veces ternadas, �ntegras o dentadas, lanceoladas o largamente el�pticas, agudas u obtusas, blandas o subcori�ceas, verdes en el haz y blanquecinas en el env�s.
Flores: de color blanco, muy perfumadas, dispuestas en racimos axilares solitarios o reunidos en panojas terminales. Florece en primavera y verano.
Fruto: es una c�psula con dos n�culas en su interior.
Nombres vulgares: "Cedr�n de Monte", "Ni�arup�", "Reseda del campo".
Habitat: vive en zonas serranas y en las cumbres de las quebradas. Area de dispersi�n: Am�rica del Sur desde M�xico hasta el Uruguay y Argentina.
Usos: se la utiliza como hierba medicinal y es de gran importancia como mel�fera.',1,300,'Aloysia_gratissima_001.JPG',1200,3,2),
(3,'Duranta repens','Tala blanco','Porte: arbusto que no alcanza m�s de cuatro metros de altura, inerme o con pocas espinas, con ramillas cuadrangulares.
Follaje: semipersistente, m�s o menos compacto.
Hojas: simples, opuestas, ovoides, obovadas o el�pticas, el borde es dentado en la mitad superior, el pec�olo tiene menos de 1 cm de largo.
Flores: peque�as, con p�talos lilacinos, dispuestas en racimos axilares, c�liz tubuloso 5 dentado, corola cigomorfa. Florece en verano.
Fruto: bacciforme de un cm de largo, amarillo anaranjado, unilocular y uniseminado.
Habitat: vive en montes ribere�os
Area de dispersi�n: vive en regiones neotropicales de Am�rica del Sur, en nuestro pa�s se cita solamente para el norte.
Usos: no se conocen.',3,400,'Duranta_repens_001.PNG',1300,4,3),
(4,'Schinus molle','"Anacahuita", "Aguaribay", "Molle", "Pimentero"','Porte: �rbol que puede alcanzar de 8 a 10 metros de altura, resinoso. Tronco grueso con corteza persistente.
Follaje: persistente, copa amplia, ramillas colgantes de color verde claro.
Hojas: compuestas, pinnadas, alternas, glabras. Raquis ligeramente alado. Con 10-12 pares de fol�olos s�siles, dentados.
Flores: amarillentas, dispuestas por lo general en panojas terminales. Florece en primavera y verano.
Fruto: drupa globosa, de color rojizo, reunidos en panojas, uniseminados.
Habitat: montes de quebrada.
Area de dispersi�n: com�n en casi toda Am�rica del Sur, en nuestro pa�s en la zona norte.
Usos: los frutos tienen gusto a pimienta, us�ndose como condimento. La infusi�n de las hojas como medicinal.',3,1000,'Schinus_molle_001.PNG',1400,5,4),
(5,'Sebastiania klotzschiana Muell','Blanquillo','Porte: �rbol que puede alcanzar los 6 metros de altura, de ramas agudo espinosas. Corteza persistente.
Follaje: semi persistente, de color verde claro con tonalidades rojizas en el oto�o e invierno.
Hojas: simples, alternas, eliptico-lanceoladas, glabras, con una o tres gl�ndulas en la base del limbo. Borde apenas dentado.
Flores: de 3 a 5 cm de largo, amarillas, dispuestas en espigas amentoides. Florece en primavera.
Fruto: c�psula globosa de 8 a 10 mm de di�metro de color marr�n, dehiscente con tres semillas en su interior.
Habitat: montes serranos y ribere�os.
Area de dispersi�n: Am�rica subtropical.
Usos: no se conocen.
',1,600,'Sebastiania_klotzschiana_Muell_001.JPG',1500,6,5),
(6,'Syagrus romanzoffiana','"Pind�", "Chiriv�", "Jeriv�"','Porte: palmera que puede alcanzar hasta 20 metros de altura, est�pite recto de 15 a 30 cm de di�metro, anillado, gris�ceo.
Follaje: persistente, verde intenso, brillante.
Hojas: pinnaticompuestas, con p�nulas verde intenso, insertas en varios planos con respecto al raquis. Pec�olo de 1 a 1,5 metros de largo, inerme.
Flores: inflorescencia amarilla, protegida por una espata le�osa, surcada, glabra. Florece en primavera y verano.
Fruto: drupa el�ptica, uniseminada, amarillo rojiza, fibrosa, de 1 cm de di�metro. Fructifica en verano y oto�o.
Habitat: montes de quebrada, serrano y ribere�o
Area de dispersi�n: suroeste del Brasil, norte de la Argentina y casi todo el Uruguay.
Usos: el fruto es comestible solo para los animales.',1,20000,'Syagrus_romanzoffiana_001.JPG',1600,7,1),
(2,'Parapiptadenia rigida','"Angico", "Angico rojo", "Angico cedro", "Angico de los montes"','Porte:  �rbol de 18 a 30 metros de altura. Corteza levemente surcada que se desprende en plaquetas. Tronco recto. Inerme.
Follaje: semipersistente, verde oscuro
Hojas: compuestas, bipinnadas, 3-9 yugadas, con 21-39 fol�olos por pinna, linear-lanceolados.
Flores: en espigas axilares cil�ndricas de 5-9 cm de largo, amarillo-verdosas. Florece en primavera.
Fruto: legumbre papir�cea o subcori�cea de 9-16 cm de largo. Las semillas son aplanadas, ovalado-orbiculares, casta�as, sin l�nea fisural.
Habitat: acompa�a los cursos de r�os.
Area de dispersi�n: Brasil austral, Paraguay, norte de la Argentina y del Uruguay.
Usos: Se usa para vigas de puentes porque soporta la intemperie. Tiene propiedades medicinales.',1,30000,'Parapiptadenia_rigida_001.JPG',1700,8,3),
(7,'Xylosma warburgii','Espina corona','Porte: arbusto espinoso de dos a cuatro metros de altura. Follaje: caduco, verde intenso que se torna rojizo en oto�o. Ramillas en zig-zag rojizas con lenticelas blancuzcas destacadas, Con espinas simples, rectas, axilares, una por nudo de hasta 5 cm de largo.
Hojas: simples, ovales, oblongo el�pticas, de borde crenado, glabras.
Flores: unisexuadas en fasc�culos, 3-8 floros, con numerosas br�cteas. Flores masculinas con estambres numerosos con filamentos libres. Femeninas con ovario globoso s�pero unilocular. Florece en primavera.
Fruto: baya subglobosa de 4-5 mm de di�metro, de color negro. Con 2-5 semillas en su interior.
Habitat: montes serranos y ribere�os.
Area de dispersi�n: sureste de Brasil, Corrientes y Entre R�os, en Argentina y Uruguay.
Usos: desconocidos.',3,400,'Xylosma_warburgii_001.JPG',1800,9,4),
(8,'Terminalia australis','"Palo amarillo", "Amarillo"','Porte: �rbol de 7 a 8 metros de altura. Generalmente ramificado desde la base. Inerme.
Follaje: ramas muy flexibles de le�o amarillo. Follaje caduco, verde amarillento.
Hojas: simples, alternas, lanceoladas, 3-6 cm de largo. Pec�olo corto.
Flores: peque�as, verduzcas, unisexuadas. Masculinas con 10 estambres. Femeninas con pistilo de estilo alargados. Florece en primavera.
Fruto: ovoide, aplanado, 2-3 cm de largo, uniseminado, rojizo
Habitat: orillas de cursos de agua.
Area de dispersi�n: Sur del Brasil, noreste de la Argentina, m�s com�n en el litoral oeste del Uruguay
Usos: con sus ramas flexibles se hacen canastos para vivero de peces.',2,800,'Terminalia_australis_001.JPG',1900,10,2),
(5,'Sapium montevidense Klotzsch','"Curup�", "Arbol de la leche"','Porte: �rbol de 7 a 9 metros de altura, inerme. Tronco algo tortuoso de color gris�ceo. Latic�fero.
Follaje: semi persistente, de color verde claro.
Hojas: Simples de hasta 10 cm de largo, lanceoladas. Borde finamente aserrado. Pec�olo de 1 cm, con dos gl�ndulas c�nicas, en la base de la l�mina.
Flores: peque�as, en espigas, de 8-10 cm de largo, amarillas. Florece en primavera.
Fruto: tricoco de 1 cm de di�metro. Casta�o rojizo en la madurez, con tres semillas en su interior. Dehiscente.
Habitat: lugares bajos y h�medos, orillas de r�os, arroyos, lagunas y ba�ados.
Area de dispersi�n: especie propia del sur de Brasil. Uruguay en todo el pa�s.
Usos: el l�tex se usa para cazar p�jaros, como adhesivo ("pega-pega").',2,900,'Sapium_montevidense_Klotzsch_001.PNG',1000,11,1),
(3,'Vitex megapotamicus','Tarum�n sin espinas','Porte: arbusto de hasta 6 metros de altura, inerme.
Follaje: persistente, verde brillante.
Hojas: compuestas, quinquefoliadas. Fol�olos el�pticos de 4 a 14 cm de largo, por 4 a 5 cm de ancho, de borde �ntegro
Flores: lilacinas, peque�as, en cimas axilares. Florece en primavera.
Fruto: drupa ovobada, negruzca, brillante, de 1 cm de di�metro.
Habitat: monte serrano.
Area de dispersi�n: Brasil y Uruguay.
Usos: desconocidos.',2,600,'Vitex_megapotamicus_001.JPG',1200,12,2);