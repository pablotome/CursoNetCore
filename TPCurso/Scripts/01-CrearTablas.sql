use TPCurso
GO

if exists (select * from sysobjects where name like 'Cursa')
	DROP TABLE DBO.Cursa
	
if exists (select * from sysobjects where name like 'Dicta')
	DROP TABLE DBO.Dicta
	
if exists (select * from sysobjects where name like 'Materia')
	DROP TABLE DBO.Materia
	
if exists (select * from sysobjects where name like 'Alumno')
	DROP TABLE DBO.Alumno

if exists (select * from sysobjects where name like 'Docente')
	DROP TABLE DBO.Docente

if exists (select * from sysobjects where name like 'Persona')
	DROP TABLE DBO.Persona

CREATE TABLE DBO.Persona
(
	CodPersona int identity(1, 1), 
	Nombre varchar(50), 
	Apellido varchar(50), 
	FechaNacimiento datetime, 
	CONSTRAINT PK_Persona PRIMARY KEY (CodPersona)
)

CREATE TABLE DBO.Docente
(
	CodDocente int, 
	AnioInicio int, 
	CONSTRAINT PK_Docente PRIMARY KEY (CodDocente), 
	CONSTRAINT FK_Docente_Persona FOREIGN KEY (CodDocente) REFERENCES Persona(CodPersona)
)

CREATE TABLE DBO.Alumno
(
	CodAlumno int, 
	AnioIngreso int, 
	CodDocenteTutor int, 
	CONSTRAINT PK_Alumno PRIMARY KEY (CodAlumno), 
	CONSTRAINT FK_Alumno_Persona FOREIGN KEY (CodAlumno) REFERENCES Persona(CodPersona), 
	CONSTRAINT FK_Alumno_Docente FOREIGN KEY (CodDocenteTutor) REFERENCES Docente(CodDocente)
)

CREATE TABLE DBO.Materia
(
	CodMateria int identity(1, 1), 
	Nombre varchar(50), 
	CargaHoraria int, 
	CONSTRAINT PK_Materia PRIMARY KEY (CodMateria)
)

CREATE TABLE DBO.Dicta
(
	CodDicta int identity(1, 1), 
	CodDocente int, 
	CodMateria int, 
	CONSTRAINT PK_Dicta PRIMARY KEY (CodDicta), 
	CONSTRAINT FK_Dicta_Docente FOREIGN KEY (CodDocente) REFERENCES Docente(CodDocente), 
	CONSTRAINT FK_Dicta_Materia FOREIGN KEY (CodMateria) REFERENCES Materia(CodMateria), 
	CONSTRAINT UK_Dicta_Docente_Materia UNIQUE (CodDocente, CodMateria)
)

CREATE TABLE DBO.Cursa
(
	CodCursa int identity(1, 1), 
	CodAlumno int, 
	CodMateria int, 
	CONSTRAINT PK_Cursa PRIMARY KEY (CodCursa), 
	CONSTRAINT FK_Cursa_Alumno FOREIGN KEY (CodAlumno) REFERENCES Alumno(CodAlumno), 
	CONSTRAINT FK_Cursa_Materia FOREIGN KEY (CodMateria) REFERENCES Materia(CodMateria), 
	CONSTRAINT UK_Cursa_Alumno_Materia UNIQUE (CodAlumno, CodMateria)
)