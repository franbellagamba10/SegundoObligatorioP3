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
('Salicaceae','Familia de plantas perteneciente al orden Malpighiales. La componen árboles o arbustos caducifolios y dioicos. Hojas alternas, simples, estipuladas. Flores inconspicuas, unisexuales, aclamídeas, acompañadas de brácteas y reunidas en amentos.'),
('Leguminosae','Familia del orden de las fabales. Reúne árboles, arbustos y hierbas perennes o anuales, fácilmente reconocibles por su fruto tipo legumbre y sus hojas compuestas y estipuladas.Es una familia de distribución cosmopolita con aproximadamente setecientos treinta géneros.'),
('Verbenaceae','Verbenaceae o verbenáceas es una amplia familia de plantas, principalmente tropicales, de árboles, arbustos y hierbas.'),
('Anacardiaceae','Anacardiaceae es una familia de plantas esencialmente arbóreas y arbustivas perteneciente al orden Sapindales. La constituyen 77 géneros con unas 700 especies aceptadas, de las casi 3000 descritas, propias de países tropicales, cálidos y templados.'),
('Euphorbiaceae','Euphorbiaceae es una familia cosmopolita muy difundida y diversificada en la zona tropical con 300 géneros y alrededor de 7500 especies, la mayoría de ellas matas y hierbas aunque también, en especial en los trópicos, árboles y arbustos; monoicas o dioicas, típicamente con látex. Algunas son suculentas que se asemejan a los cactus.'),
('Palmae','Las arecáceas o Palmae son una familia de plantas monocotiledóneas, la única familia del orden Arecales. Normalmente se las conoce como palmeras o palmas. Los individuos de esta importante familia son fáciles de reconocer visualmente, aunque puede haber confusión con especies de las familias Cycadaceae y Zamiaceae debido a las similitudes morfológicas'),
('Flacourtiaceae','Familia de plantas con flores, incluida en varios sistemas de clasificación, entre ellos el de Cronquist, hoy obsoleto. A menudo se le ha achacado a Arthur Cronquist el hábito de incluir en esta familia a todos los miembros que no poseían una clara característica para ser incluidas en otras familias'),
('Combretaceae','Familia del orden de las mirtales, que comprende alrededor de 600 especies de árboles, arbustos y trepadoras en 20 géneros. Su hábitat se extiende por los trópicos y subtrópicos; en ella se encuentran los géneros Laguncularia y Lumnitzera, dos mangles.');
--(9,'',''),
--(10,'',''),


INSERT into FrecuenciaRiego
VALUES
--ID-Tiempo-Cantidad
('Hora',1),
('Dia',1),
('Semana',1),
('Mes',1),
('Año',1);


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
(1,'Salix humboldtiana Willd','Sauce Criollo','Porte: árbol que alcanza hasta 10 metros de altura, dioico, corteza persistente, inerme.
Follaje: caduco, verde claro, ramillas colgantes.
Hojas: simples, alternas, linearlanceoladas, de borde aserrado, glabras, ápice agudo, base cuneada de 6 a 12 cm. de largo.
Flores: aperiantadas, en amentos. Los masculinos de 7 cm. de largo, amarillentos; los femeninos verdes, de 3-3,5 cm. de largo. Florece en primavera.
Habitat: vive en los bordes de los ríos y arroyos en todo el Uruguay y con más frecuencia en el noroeste del país.
Area de dispersión: crece en América subtropical, en la Argentina hasta el norte de la Patagonia, Brasil, Paraguay y Uruguay.
Usos: la madera es blanda y liviana, se utiliza para la fabricación de envases.',0,1000,'Salix_humboldtiana_Willd_001.JPG',500,1,1),
(2,'Inga uruguensis Hooker et Arnott','"Ingá", "Angá", "Inga banana","Pacay"','Porte: arbusto de altura media, entre 4 y 10 metros. Ramas con lenticelas en líneas transversales, inerme.
Follaje: perenne, verde oscuro, inerme.
Hojas: compuestas, 3-7 yugadas, raquis y pecíolo alado de 2-14 cm. de largo, alas en el raquis semiovales de hasta 4 mm. de largo cada una.
Flores: en espigas axilares, pedunculadas, floríferas en su mitad apical, floración centrípeta. Estambres numerosos en un penacho blanco. Florece en verano.
Fruto: legumbre afelpada oblonga, poco arqueada, coriácea de 7- 13 cm. de ancho por 1,5-2,5 cm. de largo, con dos bordes prominentes.
Habitat: especie heliófila y selectivamente higrófita. Se la encuentra en el Alto y Bajo Río Uruguay, parece tratarse de una especie exclusiva de las márgenes de los ríos.
Area de dispersión: Brasil austral, Paraguay, Uruguay, y nordeste de la Argentina.
Uso:los frutos son comestibles.',0,1000,'Inga_uruguensis_Hooker_et_Arnott_001.JPG',1100,2,2),
(3,'Aloysia gratissima','"Cedrón de Monte", "Niñarupá", "Reseda del campo"','Porte: arbusto que alcanza una altura máxima de 3 metros, de aspecto desordenado, con ramas agudo espinosas.
Follaje: ralo, persistente
Hojas: simples, opuestas, a veces ternadas, íntegras o dentadas, lanceoladas o largamente elípticas, agudas u obtusas, blandas o subcoriáceas, verdes en el haz y blanquecinas en el envés.
Flores: de color blanco, muy perfumadas, dispuestas en racimos axilares solitarios o reunidos en panojas terminales. Florece en primavera y verano.
Fruto: es una cápsula con dos núculas en su interior.
Nombres vulgares: "Cedrón de Monte", "Niñarupá", "Reseda del campo".
Habitat: vive en zonas serranas y en las cumbres de las quebradas. Area de dispersión: América del Sur desde México hasta el Uruguay y Argentina.
Usos: se la utiliza como hierba medicinal y es de gran importancia como melífera.',0,300,'Aloysia_gratissima_001.JPG',1200,3,2),
(3,'Duranta repens','Tala blanco','Porte: arbusto que no alcanza más de cuatro metros de altura, inerme o con pocas espinas, con ramillas cuadrangulares.
Follaje: semipersistente, más o menos compacto.
Hojas: simples, opuestas, ovoides, obovadas o elípticas, el borde es dentado en la mitad superior, el pecíolo tiene menos de 1 cm de largo.
Flores: pequeñas, con pétalos lilacinos, dispuestas en racimos axilares, cáliz tubuloso 5 dentado, corola cigomorfa. Florece en verano.
Fruto: bacciforme de un cm de largo, amarillo anaranjado, unilocular y uniseminado.
Habitat: vive en montes ribereños
Area de dispersión: vive en regiones neotropicales de América del Sur, en nuestro país se cita solamente para el norte.
Usos: no se conocen.',2,400,'Duranta_repens_001.PNG',1300,4,3),
(4,'Schinus molle','"Anacahuita", "Aguaribay", "Molle", "Pimentero"','Porte: árbol que puede alcanzar de 8 a 10 metros de altura, resinoso. Tronco grueso con corteza persistente.
Follaje: persistente, copa amplia, ramillas colgantes de color verde claro.
Hojas: compuestas, pinnadas, alternas, glabras. Raquis ligeramente alado. Con 10-12 pares de folíolos sésiles, dentados.
Flores: amarillentas, dispuestas por lo general en panojas terminales. Florece en primavera y verano.
Fruto: drupa globosa, de color rojizo, reunidos en panojas, uniseminados.
Habitat: montes de quebrada.
Area de dispersión: común en casi toda América del Sur, en nuestro país en la zona norte.
Usos: los frutos tienen gusto a pimienta, usándose como condimento. La infusión de las hojas como medicinal.',2,1000,'Schinus_molle_001.PNG',1400,5,4),
(5,'Sebastiania klotzschiana Muell','Blanquillo','Porte: árbol que puede alcanzar los 6 metros de altura, de ramas agudo espinosas. Corteza persistente.
Follaje: semi persistente, de color verde claro con tonalidades rojizas en el otoño e invierno.
Hojas: simples, alternas, eliptico-lanceoladas, glabras, con una o tres glándulas en la base del limbo. Borde apenas dentado.
Flores: de 3 a 5 cm de largo, amarillas, dispuestas en espigas amentoides. Florece en primavera.
Fruto: cápsula globosa de 8 a 10 mm de diámetro de color marrón, dehiscente con tres semillas en su interior.
Habitat: montes serranos y ribereños.
Area de dispersión: América subtropical.
Usos: no se conocen.
',0,600,'Sebastiania_klotzschiana_Muell_001.JPG',1500,6,5),
(6,'Syagrus romanzoffiana','"Pindó", "Chirivá", "Jerivá"','Porte: palmera que puede alcanzar hasta 20 metros de altura, estípite recto de 15 a 30 cm de diámetro, anillado, grisáceo.
Follaje: persistente, verde intenso, brillante.
Hojas: pinnaticompuestas, con pínulas verde intenso, insertas en varios planos con respecto al raquis. Pecíolo de 1 a 1,5 metros de largo, inerme.
Flores: inflorescencia amarilla, protegida por una espata leñosa, surcada, glabra. Florece en primavera y verano.
Fruto: drupa elíptica, uniseminada, amarillo rojiza, fibrosa, de 1 cm de diámetro. Fructifica en verano y otoño.
Habitat: montes de quebrada, serrano y ribereño
Area de dispersión: suroeste del Brasil, norte de la Argentina y casi todo el Uruguay.
Usos: el fruto es comestible solo para los animales.',0,20000,'Syagrus_romanzoffiana_001.JPG',1600,7,1),
(2,'Parapiptadenia rigida','"Angico", "Angico rojo", "Angico cedro", "Angico de los montes"','Porte:  árbol de 18 a 30 metros de altura. Corteza levemente surcada que se desprende en plaquetas. Tronco recto. Inerme.
Follaje: semipersistente, verde oscuro
Hojas: compuestas, bipinnadas, 3-9 yugadas, con 21-39 folíolos por pinna, linear-lanceolados.
Flores: en espigas axilares cilíndricas de 5-9 cm de largo, amarillo-verdosas. Florece en primavera.
Fruto: legumbre papirácea o subcoriácea de 9-16 cm de largo. Las semillas son aplanadas, ovalado-orbiculares, castañas, sin línea fisural.
Habitat: acompaña los cursos de ríos.
Area de dispersión: Brasil austral, Paraguay, norte de la Argentina y del Uruguay.
Usos: Se usa para vigas de puentes porque soporta la intemperie. Tiene propiedades medicinales.',0,30000,'Parapiptadenia_rigida_001.JPG',1700,8,3),
(7,'Xylosma warburgii','Espina corona','Porte: arbusto espinoso de dos a cuatro metros de altura. Follaje: caduco, verde intenso que se torna rojizo en otoño. Ramillas en zig-zag rojizas con lenticelas blancuzcas destacadas, Con espinas simples, rectas, axilares, una por nudo de hasta 5 cm de largo.
Hojas: simples, ovales, oblongo elípticas, de borde crenado, glabras.
Flores: unisexuadas en fascículos, 3-8 floros, con numerosas brácteas. Flores masculinas con estambres numerosos con filamentos libres. Femeninas con ovario globoso súpero unilocular. Florece en primavera.
Fruto: baya subglobosa de 4-5 mm de diámetro, de color negro. Con 2-5 semillas en su interior.
Habitat: montes serranos y ribereños.
Area de dispersión: sureste de Brasil, Corrientes y Entre Ríos, en Argentina y Uruguay.
Usos: desconocidos.',2,400,'Xylosma_warburgii_001.JPG',1800,9,4),
(8,'Terminalia australis','"Palo amarillo", "Amarillo"','Porte: árbol de 7 a 8 metros de altura. Generalmente ramificado desde la base. Inerme.
Follaje: ramas muy flexibles de leño amarillo. Follaje caduco, verde amarillento.
Hojas: simples, alternas, lanceoladas, 3-6 cm de largo. Pecíolo corto.
Flores: pequeñas, verduzcas, unisexuadas. Masculinas con 10 estambres. Femeninas con pistilo de estilo alargados. Florece en primavera.
Fruto: ovoide, aplanado, 2-3 cm de largo, uniseminado, rojizo
Habitat: orillas de cursos de agua.
Area de dispersión: Sur del Brasil, noreste de la Argentina, más común en el litoral oeste del Uruguay
Usos: con sus ramas flexibles se hacen canastos para vivero de peces.',1,800,'Terminalia_australis_001.JPG',1900,10,2),
(5,'Sapium montevidense Klotzsch','"Curupí", "Arbol de la leche"','Porte: árbol de 7 a 9 metros de altura, inerme. Tronco algo tortuoso de color grisáceo. Laticífero.
Follaje: semi persistente, de color verde claro.
Hojas: Simples de hasta 10 cm de largo, lanceoladas. Borde finamente aserrado. Pecíolo de 1 cm, con dos glándulas cónicas, en la base de la lámina.
Flores: pequeñas, en espigas, de 8-10 cm de largo, amarillas. Florece en primavera.
Fruto: tricoco de 1 cm de diámetro. Castaño rojizo en la madurez, con tres semillas en su interior. Dehiscente.
Habitat: lugares bajos y húmedos, orillas de ríos, arroyos, lagunas y bañados.
Area de dispersión: especie propia del sur de Brasil. Uruguay en todo el país.
Usos: el látex se usa para cazar pájaros, como adhesivo ("pega-pega").',1,900,'Sapium_montevidense_Klotzsch_001.PNG',1000,11,1),
(3,'Vitex megapotamicus','Tarumán sin espinas','Porte: arbusto de hasta 6 metros de altura, inerme.
Follaje: persistente, verde brillante.
Hojas: compuestas, quinquefoliadas. Folíolos elípticos de 4 a 14 cm de largo, por 4 a 5 cm de ancho, de borde íntegro
Flores: lilacinas, pequeñas, en cimas axilares. Florece en primavera.
Fruto: drupa ovobada, negruzca, brillante, de 1 cm de diámetro.
Habitat: monte serrano.
Area de dispersión: Brasil y Uruguay.
Usos: desconocidos.',1,600,'Vitex_megapotamicus_001.JPG',1200,12,2);
