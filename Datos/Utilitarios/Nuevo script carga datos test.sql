
INSERT INTO Usuarios VALUES
('francesco@ort.edu.uy','Francesco1992!',1),
('plinio@ort.edu.uy','Plinio1972!',1),
('juanmanuel@ort.edu.uy','Juanma1995!',1),
('martin@ort.edu.uy','Martin1991!',1),
('gervaz@ort.edu.uy','Gervaz1951!',1);


INSERT into TiposPlanta
VALUES
--ID-Nombre-Descripcion
('Salicaceae','Familia de plantas '),
('Leguminosae','Familia del polita con aproximadamente setecientos treinta g�neros.'),
('Verbenaceae','Verbenaceae o verben�ceas y hierbas.'),
('Anacardiaceae','Anacardiaclas casi 3000 descritas, propias des tropicales,idos y templados.'),
('Euphorbiaceae','Euphorbiaceae esn los tr�picos, �rboles y arbustos; monoica se asemejan a los cactus.'),
('Palmae','Las arec�ceas o Palmae son una familia de plaas o palmas. Los individuos de esunque puede haber con eae debido a las similitudes morfol�gicas'),
('Flacourtiaceae','Familia de plantas con flores, incluida en variocaracter�stica para ser incluidas en otras familias'),
('Combretaceae','Familia del orden de las mirtales, que comprende alr 20 y Lumnitzera, dos mangles.');
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


INSERT INTO Plantas
VALUES 
--(0,'tipo','NombreCientifico','NombresVulgares','descripcion',IDAmbiente,alturaMaxima,'foto',precio,IDficha,IDUsuarioquelain),
(1,'Salix humboldtiana Willd','Sauce Criollo','e la Patagonia, Brasil, Paraguay y Uruguay.
Usos: la madera es blanda y liviana, se utiliza para la fabricacion de envases.',1,1000,'salix_humboldtiana_willd_001.jpg',500,1,1),
(2,'Inga uruguensis Hooker et Arnott','"Ingu", "Angu", "Inga banana","Pacay"','Porte: arbusto de altura media, entre 4 y 10 metros. Ramas con lenticelas en lineas transversales, inerme.
Paraguay, Uruguay, y nordeste de la Argentina.
Uso:los frutos son comestibles.',1,1000,'inga_uruguensis_hooker_et_arnott_001.jpg',1100,2,2),
(3,'Aloysia gratissima','"Cedron de Monte", "Niuarupo", "Reseda del campo"','ran importancia como melofera.',1,300,'aloysia_gratissima_001.jpg',1200,2,2),
(3,'Duranta repens','Tala blanco','Porte: arbusto que no alcanza mas de cuatro metros de altura, inerme o con pocas espinas, con ramillas cuadrangulares.
Follaje: semipersistente, mas o menos compacto.Hojas: simps
Area de dispersion: vive en regiones neotropicales de America del Sur, en nuestro pais se cita solamente para el norte.
Usos: no se conocen.',3,400,'duranta_repens_001.png',1300,1,2),
(4,'Schinus molle','"Anacahuita", "Aguaribay", "Molle", "Pimentero"','Porte: arbol que puede alcanzar de 8 a 10 metros de altura, resinoso. Tronco grueso con corteza persistente.
Follaje: persistente, copa amplia, ramillas colgantes de color verde claro.Area de dispersion: comun en casi toda America del Sur, en nuestro pais en la zona norte.
 como medicinal.',3,1000,'schinus_molle_001.png',1400,2,1)
