create database ObligatorioP3
use ObligatorioP3

create table Usuarios(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	email varchar(50) NOT NULL UNIQUE,
	contrasenia varchar(20) NOT NULL,
	activo bit DEFAULT 1 NOT NULL,
);

create table Compras(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	fecha DateTime NOT NULL,	
);  --No hay List<item> porque es complicado almacenarlo asi
	--hay una tabla Compra_item que guarda como FKs idPlanta y idCompra

create table ComprasImportacion(
	id int NOT NULL UNIQUE, 
	impuestoImportacion decimal not null DEFAULT 0,
	esSudamericano bit NOT NULL,
	tasaArancelaria decimal NOT NULL DEFAULT 0,
	medidasSanitarias varchar(max)

	FOREIGN KEY (id) REFERENCES Compras(id),
);

create table ComprasPlaza(
	id int NOT NULL UNIQUE,
	IVA decimal NOT NULL DEFAULT 0,
	cobroFlete bit NOT NULL,
	costoEnvio decimal DEFAULT 0,

	FOREIGN KEY (id) REFERENCES Compras(id)
);



create table TiposPlantas( 
	id int IDENTITY(1,1) NOT NULL Primary Key,
	nombre varchar(20) UNIQUE,
	descripcion varchar(max)
);



create table FrecuenciasRiego(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	tiempo varchar(20) NOT NULL, -- ??? -----> por que string?
	cantidad int NOT NULL
);

create table TiposIluminacion(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	iluminacion varchar(20) NOT NULL
);	--### podriamos agregarle una descripcion.

create table Fichas(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	frecuenciaRiego int NOT NULL,
	tipoIluminacion int NOT NULL,
	temperatura decimal NOT NULL,

	FOREIGN KEY (frecuenciaRiego) REFERENCES FrecuenciasRiego(id),
	FOREIGN KEY (tipoIluminacion) REFERENCES TiposIluminacion(id)	
);

create table Plantas(
	id int IDENTITY(1,1) NOT NULL Primary Key,
	tipo int NOT NULL,
	nombreCientifico varchar(50) NOT NULL UNIQUE,
	nombresVulgares varchar(max) NOT NULL, --En BD lo manejamos como cadena unica, separados por una coma. pero en la solucion lo recibimos como una lista y la desarmamos.
	descripcion varchar(max) NOT NULL,
	ambiente int NOT NULL,
	alturaMaxima int NOT NULL,
	foto varchar(max),
	precio decimal NOT NULL, -- !!!!! en el UML es DOUBLE, no supe que poner xq double no existe en SQL
	ficha int NOT NULL,
	ingresadoPor int,
	
	FOREIGN KEY (tipo) REFERENCES TiposPlantas(id),
	FOREIGN KEY (ingresadoPor) REFERENCES Usuarios(id),
	FOREIGN KEY (ficha) REFERENCES Fichas(id),
)

create table Items(
	compra int NOT NULL,
	planta int NOT NULL,
	cantidad int NOT NULL DEFAULT 1,
	precioUnidad decimal NOT NULL,

	FOREIGN KEY (compra) REFERENCES Compras(id),
	FOREIGN KEY (planta) REFERENCES Plantas(id),
);

--Ignorar esto, es una idea para guardar las constantes que podamos llegar
-- a necesitar, no esta implementado
create table VariablesGlobales(
	id int IDENTITY(1,1) NOT NULL,
	descripcion varchar(20) NOT NULL,
	valorString varchar(10),
	valorDecimal decimal,
	valorBool bit,
	valorInt int
);


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


INSERT into TiposPlantas
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


INSERT into FrecuenciasRiego
VALUES
--ID-Tiempo-Cantidad
('Hora',1),
('Dia',1),
('Semana',1),
('Mes',1),
('A�o',1);

INSERT into TiposIluminacion VALUES ('Directa'),('Indirecta'),('Sombra');

INSERT into Fichas
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


INSERT	INTO Plantas
VALUES 
--(0,'tipo','NombreCientifico','NombresVulgares','descripcion',IDAmbiente,alturaMaxima,'foto',precio,IDficha,IDUsuarioquelain),
(1,'Salix humboldtiana Willd','Sauce Criollo','Porte: Arbol que alcanza hasta 10 metros de altura, dioico, corteza persistente, inerme.
Follaje: caduco, verde claro, ramillas colgantes.
Hojas: simples, alternas, linearlanceoladas, de borde aserrado, glabras, apice agudo, base cuneada de 6 a 12 cm. de largo.
Flores: aperiantadas, en amentos. Los masculinos de 7 cm. de largo, amarillentos; los femeninos verdes, de 3-3,5 cm. de largo. Florece en primavera.
Habitat: vive en los bordes de los rios y arroyos en todo el Uruguay y con mas frecuencia en el noroeste del pais.
Area de dispersion: crece en Am�rica subtropical, en la Argentina hasta el norte de la Patagonia, Brasil, Paraguay y Uruguay.
Usos: la madera es blanda y liviana, se utiliza para la fabricacion de envases.',1,1000,'salix_humboldtiana_willd_001.jpg',500,1,1),
(2,'Inga uruguensis Hooker et Arnott','"Ingu", "Angu", "Inga banana","Pacay"','Porte: arbusto de altura media, entre 4 y 10 metros. Ramas con lenticelas en lineas transversales, inerme.
Follaje: perenne, verde oscuro, inerme.
Hojas: compuestas, 3-7 yugadas, raquis y pecuolo alado de 2-14 cm. de largo, alas en el raquis semiovales de hasta 4 mm. de largo cada una.
Flores: en espigas axilares, pedunculadas, flor�feras en su mitad apical, floracion centropeta. Estambres numerosos en un penacho blanco. Florece en verano.
Fruto: legumbre afelpada oblonga, poco arqueada, coriacea de 7- 13 cm. de ancho por 1,5-2,5 cm. de largo, con dos bordes prominentes.
Habitat: especie heliofila y selectivamente higrofita. Se la encuentra en el Alto y Bajo Rio Uruguay, parece tratarse de una especie exclusiva de las margenes de los rios.
Area de dispersion: Brasil austral, Paraguay, Uruguay, y nordeste de la Argentina.
Uso:los frutos son comestibles.',1,1000,'inga_uruguensis_hooker_et_arnott_001.jpg',1100,2,2),
(3,'Aloysia gratissima','"Cedron de Monte", "Niuarupo", "Reseda del campo"','Porte: arbusto que alcanza una altura maxima de 3 metros, de aspecto desordenado, con ramas agudo espinosas.
Follaje: ralo, persistente
Hojas: simples, opuestas, a veces ternadas, integras o dentadas, lanceoladas o largamente elopticas, agudas u obtusas, blandas o subcoriaceas, verdes en el haz y blanquecinas en el envis.
Flores: de color blanco, muy perfumadas, dispuestas en racimos axilares solitarios o reunidos en panojas terminales. Florece en primavera y verano.
Fruto: es una capsula con dos niculas en su interior.
Nombres vulgares: "Cedron de Monte", "Niuarupo", "Reseda del campo".
Habitat: vive en zonas serranas y en las cumbres de las quebradas. Area de dispersion: America del Sur desde Mexico hasta el Uruguay y Argentina.
Usos: se la utiliza como hierba medicinal y es de gran importancia como melofera.',1,300,'aloysia_gratissima_001.jpg',1200,3,2),
(3,'Duranta repens','Tala blanco','Porte: arbusto que no alcanza mas de cuatro metros de altura, inerme o con pocas espinas, con ramillas cuadrangulares.
Follaje: semipersistente, mas o menos compacto.
Hojas: simples, opuestas, ovoides, obovadas o elipticas, el borde es dentado en la mitad superior, el pecuolo tiene menos de 1 cm de largo.
Flores: pequeñas, con petalos lilacinos, dispuestas en racimos axilares, caliz tubuloso 5 dentado, corola cigomorfa. Florece en verano.
Fruto: bacciforme de un cm de largo, amarillo anaranjado, unilocular y uniseminado.
Habitat: vive en montes ribereios
Area de dispersion: vive en regiones neotropicales de America del Sur, en nuestro pais se cita solamente para el norte.
Usos: no se conocen.',3,400,'duranta_repens_001.png',1300,4,3),
(4,'Schinus molle','"Anacahuita", "Aguaribay", "Molle", "Pimentero"','Porte: arbol que puede alcanzar de 8 a 10 metros de altura, resinoso. Tronco grueso con corteza persistente.
Follaje: persistente, copa amplia, ramillas colgantes de color verde claro.
Hojas: compuestas, pinnadas, alternas, glabras. Raquis ligeramente alado. Con 10-12 pares de foluolos sosiles, dentados.
Flores: amarillentas, dispuestas por lo general en panojas terminales. Florece en primavera y verano.
Fruto: drupa globosa, de color rojizo, reunidos en panojas, uniseminados.
Habitat: montes de quebrada.
Area de dispersion: comun en casi toda America del Sur, en nuestro pais en la zona norte.
Usos: los frutos tienen gusto a pimienta, usandose como condimento. La infusion de las hojas como medicinal.',3,1000,'schinus_molle_001.png',1400,5,4),
(5,'Sebastiania klotzschiana Muell','Blanquillo','Porte: arbol que puede alcanzar los 6 metros de altura, de ramas agudo espinosas. Corteza persistente.
Follaje: semi persistente, de color verde claro con tonalidades rojizas en el otoño e invierno.
Hojas: simples, alternas, eliptico-lanceoladas, glabras, con una o tres glandulas en la base del limbo. Borde apenas dentado.
Flores: de 3 a 5 cm de largo, amarillas, dispuestas en espigas amentoides. Florece en primavera.
Fruto: capsula globosa de 8 a 10 mm de diametro de color marron, dehiscente con tres semillas en su interior.
Habitat: montes serranos y ribereios.
Area de dispersion: America subtropical.
Usos: no se conocen.
',1,600,'sebastiania_klotzschiana_muell_001.jpg',1500,6,5),
(6,'Syagrus romanzoffiana','"Pindo", "Chirivo", "Jerivo"','Porte: palmera que puede alcanzar hasta 20 metros de altura, estopite recto de 15 a 30 cm de diametro, anillado, grisaceo.
Follaje: persistente, verde intenso, brillante.
Hojas: pinnaticompuestas, con panulas verde intenso, insertas en varios planos con respecto al raquis. Peciolo de 1 a 1,5 metros de largo, inerme.
Flores: inflorescencia amarilla, protegida por una espata le�osa, surcada, glabra. Florece en primavera y verano.
Fruto: drupa eliptica, uniseminada, amarillo rojiza, fibrosa, de 1 cm de diametro. Fructifica en verano y otoño.
Habitat: montes de quebrada, serrano y ribereio
Area de dispersion: suroeste del Brasil, norte de la Argentina y casi todo el Uruguay.
Usos: el fruto es comestible solo para los animales.',1,20000,'syagrus_romanzoffiana_001.jpg,syagrus_romanzoffiana_002.png',1600,7,1),
(2,'Parapiptadenia rigida','"Angico", "Angico rojo", "Angico cedro", "Angico de los montes"','Porte:  arbol de 18 a 30 metros de altura. Corteza levemente surcada que se desprende en plaquetas. Tronco recto. Inerme.
Follaje: semipersistente, verde oscuro
Hojas: compuestas, bipinnadas, 3-9 yugadas, con 21-39 foluolos por pinna, linear-lanceolados.
Flores: en espigas axilares cilindricas de 5-9 cm de largo, amarillo-verdosas. Florece en primavera.
Fruto: legumbre papiricea o subcoriacea de 9-16 cm de largo. Las semillas son aplanadas, ovalado-orbiculares, castañas, sin linea fisural.
Habitat: acompaña los cursos de rios.
Area de dispersion: Brasil austral, Paraguay, norte de la Argentina y del Uruguay.
Usos: Se usa para vigas de puentes porque soporta la intemperie. Tiene propiedades medicinales.',1,30000,'parapiptadenia_rigida_001.jpg',1700,8,3),
(7,'Xylosma warburgii','Espina corona','Porte: arbusto espinoso de dos a cuatro metros de altura. Follaje: caduco, verde intenso que se torna rojizo en otoño. Ramillas en zig-zag rojizas con lenticelas blancuzcas destacadas, Con espinas simples, rectas, axilares, una por nudo de hasta 5 cm de largo.
Hojas: simples, ovales, oblongo elipticas, de borde crenado, glabras.
Flores: unisexuadas en fasciculos, 3-8 floros, con numerosas brocteas. Flores masculinas con estambres numerosos con filamentos libres. Femeninas con ovario globoso sipero unilocular. Florece en primavera.
Fruto: baya subglobosa de 4-5 mm de diametro, de color negro. Con 2-5 semillas en su interior.
Habitat: montes serranos y ribereios.
Area de dispersion: sureste de Brasil, Corrientes y Entre R�os, en Argentina y Uruguay.
Usos: desconocidos.',3,400,'xylosma_warburgii_001.jpg',1800,9,4),
(8,'Terminalia australis','"Palo amarillo", "Amarillo"','Porte: arbol de 7 a 8 metros de altura. Generalmente ramificado desde la base. Inerme.
Follaje: ramas muy flexibles de leño amarillo. Follaje caduco, verde amarillento.
Hojas: simples, alternas, lanceoladas, 3-6 cm de largo. Peciolo corto.
Flores: pequeñas, verduzcas, unisexuadas. Masculinas con 10 estambres. Femeninas con pistilo de estilo alargados. Florece en primavera.
Fruto: ovoide, aplanado, 2-3 cm de largo, uniseminado, rojizo
Habitat: orillas de cursos de agua.
Area de dispersion: Sur del Brasil, noreste de la Argentina, mas comun en el litoral oeste del Uruguay
Usos: con sus ramas flexibles se hacen canastos para vivero de peces.',2,800,'terminalia_australis_001.jpg',1900,10,2),
(5,'Sapium montevidense Klotzsch','"Curupe", "Arbol de la leche"','Porte: arbol de 7 a 9 metros de altura, inerme. Tronco algo tortuoso de color grisaceo. Laticofero.
Follaje: semi persistente, de color verde claro.
Hojas: Simples de hasta 10 cm de largo, lanceoladas. Borde finamente aserrado. Peciolo de 1 cm, con dos glandulas conicas, en la base de la l�mina.
Flores: pequeñas, en espigas, de 8-10 cm de largo, amarillas. Florece en primavera.
Fruto: tricoco de 1 cm de diametro. Castaño rojizo en la madurez, con tres semillas en su interior. Dehiscente.
Habitat: lugares bajos y humedos, orillas de rios, arroyos, lagunas y bañados.
Area de dispersion: especie propia del sur de Brasil. Uruguay en todo el pais.
Usos: el latex se usa para cazar pajaros, como adhesivo ("pega-pega").',2,900,'sapium_montevidense_klotzsch_001.png',1000,11,1),
(3,'Vitex megapotamicus','Taruman sin espinas','Porte: arbusto de hasta 6 metros de altura, inerme.
Follaje: persistente, verde brillante.
Hojas: compuestas, quinquefoliadas. Foluolos elopticos de 4 a 14 cm de largo, por 4 a 5 cm de ancho, de borde integro
Flores: lilacinas, pequeñas, en cimas axilares. Florece en primavera.
Fruto: drupa ovobada, negruzca, brillante, de 1 cm de diametro.
Habitat: monte serrano.
Area de dispersion: Brasil y Uruguay.
Usos: desconocidos.',2,600,'vitex_megapotamicus_001.jpg',1200,12,2);