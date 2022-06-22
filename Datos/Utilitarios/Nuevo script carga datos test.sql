
INSERT INTO Usuarios VALUES
('francesco@ort.edu.uy','Francesco1992',1),
('plinio@ort.edu.uy','Plinio1972',1),
('juanmanuel@ort.edu.uy','Juanma1995',1),
('martin@ort.edu.uy','Martin1991',1),
('gervaz@ort.edu.uy','Gervaz1951',0);

--IVA, IMPUESTO IMP, TASA ARANCELARIA
INSERT INTO VariablesGlobales VALUES (22,4,8);


INSERT into TiposPlanta
VALUES
--ID-Nombre-Descripcion
('Salicaceae','Familia de plantas '),
('Leguminosae','Familia del polita con aproximadamente setecientos treinta g�neros.'),
('Verbenaceae','Verbenaceae o verben�ceas y hierbas.'),
('Anacardiaceae','Anacardiaclas casi 3000 descritas, propias des tropicales,idos y templados.'),
('Euphorbiaceae','Euphorbiaceae esn los trópicos, árboles y arbustos; monoica se asemejan a los cactus.'),
('Palmae','Las arec�ceas o Palmae son una familia de plaas o palmas. Los individuos de esunque puede haber con eae debido a las similitudes morfol�gicas'),
('Flacourtiaceae','Familia de plantas con flores, incluida en varias caractersticas para ser incluidas en otras familias'),
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
('Año',1);

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
 como medicinal.',3,1000,'schinus_molle_001.png',1400,2,1),
 (5,'Sebastiania klotzschiana Muell','Blanquillo','Porte: arbol que puede alcanzar los 6 metros de altura, de ramas agudo espinosas. Corteza persistente.
Follaje: semi persistente, de color verde claro con tonalidades rojizas en el otoño e invierno.
Hojas: simples, alternas, eliptico-lanceoladas.',1,600,'sebastiania_klotzschiana_muell_001.jpg',1500,6,5),
(6,'Syagrus romanzoffiana','"Pindo", "Chirivo", "Jerivo"','Porte: palmera que puede alcanzar hasta 20 metros de altura, estopite recto de 15 a 30 cm de diametro, anillado, grisaceo.
Follaje: persistente, verde intenso, brillante.',1,20000,'syagrus_romanzoffiana_001.jpg,syagrus_romanzoffiana_002.png',1600,7,1),
(2,'Parapiptadenia rigida','"Angico", "Angico rojo", "Angico cedro", "Angico de los montes"','Porte:  arbol de 18 a 30 metros de altura. Corteza levemente surcada que se desprende en plaquetas. Tronco recto. Inerme.
Follaje: semipersistente, verde oscuro
Hojas: compuestas, bipinnadas, 3-9 yugadas, con 21-39 foluolos por pinna, linear-lanceolados.
Flores: en espigas axilares cilindricas de 5-9 cm de largo, amarillo-verdosas. Florece en primavera.
Fruto: legumbre papiricea o subcoriacea de 9-16 cm de largo. Las semillas son aplanadas, ovalado-orbiculares, castañas, sin linea fisural.',1,30000,'parapiptadenia_rigida_001.jpg',1700,8,3),
(7,'Xylosma warburgii','Espina corona','Porte: arbusto espinoso de dos a cuatro metros de altura. Follaje: caduco, verde intenso que se torna rojizo en otoño. Ramillas en zig-zag rojizas con lenticelas blancuzcas destacadas, Con espinas simples, rectas, axilares, una por nudo de hasta 5 cm de largo.
Hojas: simples, ovales, oblongo elipticas, de borde crenado, glabras.
Flores: unisexuadas en fasciculos, 3-8 floros, con numerosas brocteas. Flores masculinas con estambres numerosos con filamentos libres. Femeninas con ovario globoso sipero unilocular. Florece en primavera.',3,400,'xylosma_warburgii_001.jpg',1800,9,4),
(8,'Terminalia australis','"Palo amarillo", "Amarillo"','Porte: arbol de 7 a 8 metros de altura. Generalmente ramificado desde la base. Inerme.
Follaje: ramas muy flexibles de leño amarillo. Follaje caduco, verde amarillento.
Hojas: simples, alternas, lanceoladas, 3-6 cm de largo. Peciolo corto.',2,800,'terminalia_australis_001.jpg',1900,10,2),
(5,'Sapium montevidense Klotzsch','"Curupe", "Arbol de la leche"','Porte: arbol de 7 a 9 metros de altura, inerme. Tronco algo tortuoso de color grisaceo. Laticofero.
Follaje: semi persistente, de color verde claro.',2,900,'sapium_montevidense_klotzsch_001.png',1000,11,1),
(3,'Vitex megapotamicus','Taruman sin espinas','Porte: arbusto de hasta 6 metros de altura, inerme.
Follaje: persistente, verde brillante.',2,600,'vitex_megapotamicus_001.jpg',1200,12,2);

--COMPRAS
INSERT INTO Compras VALUES ('2022-06-22 18:20','CompraPlaza',null,null,22,1,250,null,null,15744.00)
INSERT INTO Items VALUES (5,1200,1,3)
INSERT INTO Items VALUES (3,1300,1,4)
INSERT INTO Items VALUES (2,1400,1,5)


 